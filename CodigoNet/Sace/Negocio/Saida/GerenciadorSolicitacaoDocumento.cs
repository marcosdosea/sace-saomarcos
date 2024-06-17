using System;
using System.Collections.Generic;
using System.Linq;
using Dados;
using Dominio;
using Util;
using System.IO;
using System.Threading;
using System.Text;
using System.Transactions;
using System.Globalization;


namespace Negocio
{
    public class GerenciadorSolicitacaoDocumento
    {
        private readonly SaceContext context;

        public GerenciadorSolicitacaoDocumento(SaceContext saceContext)
        {
            context = saceContext;
        }

        /// <summary>
        /// Insere dados do cupom
        /// </summary>
        /// <param name="cupom"></param>
        /// <returns></returns>
        public long InserirSolicitacaoDocumento(List<SaidaPedido> listaSaidaPedido, List<SaidaPagamento> listaSaidaPagamento, DocumentoFiscal.TipoSolicitacao tipoSolicitacao, bool ehComplementar, bool ehEspelho)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                EhPossivelEnviarSolicitacao(listaSaidaPedido, tipoSolicitacao, ehComplementar);

                //var repSolicitacaoDocumento = new RepositorioGenerico<tb_solicitacao_documento>();
                tb_solicitacao_documento _solicitacao_documentoE = new tb_solicitacao_documento();
                try
                {
                    _solicitacao_documentoE.dataSolicitacao = DateTime.Now;
                    _solicitacao_documentoE.haPagamentoCartao = listaSaidaPagamento.Where(sp => sp.CodFormaPagamento.Equals(FormaPagamento.CARTAO)).Count() > 0;
                    _solicitacao_documentoE.cartaoProcessado = false;
                    _solicitacao_documentoE.cartaoAutorizado = false;
                    _solicitacao_documentoE.ehComplementar = ehComplementar;
                    _solicitacao_documentoE.ehEspelho = ehEspelho;
                    _solicitacao_documentoE.motivoCartaoNegado = "";
                    _solicitacao_documentoE.tipoSolicitacao = tipoSolicitacao.ToString();
                    _solicitacao_documentoE.hostSolicitante = System.Windows.Forms.SystemInformation.ComputerName;
                    repSolicitacaoDocumento.Inserir(_solicitacao_documentoE);

                    repSolicitacaoDocumento.SaveChanges();

                    var repSolicitacaoSaida = new RepositorioGenerico<tb_solicitacao_saida>();
                    foreach (SaidaPedido _saidaPedido in listaSaidaPedido)
                    {
                        tb_solicitacao_saida _solicitacao_saida = new tb_solicitacao_saida();
                        _solicitacao_saida.codSaida = _saidaPedido.CodSaida;
                        _solicitacao_saida.codSolicitacao = _solicitacao_documentoE.codSolicitacao;
                        _solicitacao_saida.valorTotal = _saidaPedido.TotalAVista;
                        repSolicitacaoSaida.Inserir(_solicitacao_saida);
                    }
                    repSolicitacaoSaida.SaveChanges();

                    var repSolicitacaoPagamento = new RepositorioGenerico<tb_solicitacao_pagamento>();
                    foreach (SaidaPagamento _solicitacaoPagamento in listaSaidaPagamento)
                    {

                        tb_solicitacao_pagamento pagamento = new tb_solicitacao_pagamento();
                        pagamento.codCartao = _solicitacaoPagamento.CodCartaoCredito;
                        pagamento.codFormaPagamento = _solicitacaoPagamento.CodFormaPagamento;
                        pagamento.parcelas = _solicitacaoPagamento.Parcelas;
                        pagamento.valor = _solicitacaoPagamento.Valor;
                        pagamento.codSolicitacao = _solicitacao_documentoE.codSolicitacao;
                        pagamento.cupomCliente = "";
                        pagamento.cupomEstabelecimento = "";
                        pagamento.cupomReduzido = "";
                        repSolicitacaoPagamento.Inserir(pagamento);
                    }
                    repSolicitacaoPagamento.SaveChanges();
                    transaction.Complete();
                    return _solicitacao_documentoE.codSolicitacao;
                }
                catch (Exception e)
                {
                    throw new DadosException("Cupom", e.Message, e);
                }

            }
        }

        private void EhPossivelEnviarSolicitacao(List<SaidaPedido> listaSaidaPedido, DocumentoFiscal.TipoSolicitacao tipoSolicitacao, bool ehComplementar)
        {
            var repSolicitacaoSaida = new RepositorioGenerico<tb_solicitacao_saida>();
            List<long> listaCodSaidas = listaSaidaPedido.Select(s => s.CodSaida).ToList();

            var solicitacoes = repSolicitacaoSaida.Obter(ss => listaCodSaidas.Contains(ss.codSaida));
            if (solicitacoes.Count() > 0)
                throw new NegocioException("A solicitação já foi enviada. Favor aguardar processamento.");
            // Verifica se cupom fiscal já foi emitido em algumas das saidas

            if (listaSaidaPedido.Count > 1)
            {
                List<SaidaPesquisa> listaSaidas = gerenciadorSaida.ObterPorCodSaidas(listaSaidaPedido.Select(s => s.CodSaida).ToList());
                HashSet<string> listaDocumentosFiscais = new HashSet<string>();
                foreach (SaidaPesquisa saida in listaSaidas)
                    listaDocumentosFiscais.Add(saida.CupomFiscal.Trim());
                if (listaDocumentosFiscais.Count > 1)
                {
                    if (tipoSolicitacao.Equals(DocumentoFiscal.TipoSolicitacao.NFCE))
                        throw new NegocioException("NFC-e só pode ser emitida se nenhum dos pedidos selecionados possui NFC-e já autorizada.");
                    if (tipoSolicitacao.Equals(DocumentoFiscal.TipoSolicitacao.NFE))
                    {
                        int contIniciaComC = 0;
                        int contDocBranco = 0;
                        foreach (string documento in listaDocumentosFiscais)
                        {
                            if (documento.StartsWith("C"))
                                contIniciaComC++;
                            if (string.IsNullOrEmpty(documento))
                                contDocBranco++;
                        }
                        if ((contIniciaComC != listaDocumentosFiscais.Count()) && (contDocBranco != listaDocumentosFiscais.Count()))
                            throw new NegocioException("NF-e só pode ser emitida se nenhuma NF-e já foi autorizada para os pedidos selecioados ou se todos os pedidos possuem uma NFCe associada.");
                    }

                }
            }

            if (tipoSolicitacao.Equals(DocumentoFiscal.TipoSolicitacao.NFE) || tipoSolicitacao.Equals(DocumentoFiscal.TipoSolicitacao.NFCE))
            {
                var repSaida = new RepositorioGenerico<tb_nfe>();
                SaceEntities saceEntities = (SaceEntities)repSaida.ObterContexto();
                foreach (long codSaida in listaCodSaidas)
                {
                    // Verifica se existem notas emitidas
                    IEnumerable<NfeControle> nfeControles = GerenciadorNFe.GetInstance().ObterPorSaida(codSaida);

                    if (!ehComplementar && nfeControles.Where(nfeC => nfeC.SituacaoNfe.Equals(NfeControle.SITUACAO_AUTORIZADA) && nfeC.Modelo.Equals(NfeControle.MODELO_NFE)).Count() > 0)
                    {
                        throw new NegocioException("Uma NF-e já foi AUTORIZADA para esse pedido.");
                    }
                    if ((ehComplementar) && nfeControles.Where(nfeC => nfeC.SituacaoNfe.Equals(NfeControle.SITUACAO_AUTORIZADA)).Count() == 0)
                    {
                        throw new NegocioException("Uma NF-e Complementar só pode ser emitida quando existe uma NF-e enviada e Autorizada.");
                    }
                }
            }

        }

        //public void AtualizarSolicitacaoDocumentoCartao(Cartao.ResultadoProcessamento resultado)
        //{
        //    var repSolicitacao = new RepositorioGenerico<tb_solicitacao_documento>();

        //    var saceContext = (SaceEntities)repSolicitacao.ObterContexto();
        //    tb_solicitacao_documento documentoE = repSolicitacao.ObterEntidade(sd => sd.codSolicitacao == resultado.CodSolicitacao);
        //    documentoE.cartaoProcessado = true;
        //    documentoE.cartaoAutorizado = resultado.Aprovado;
        //    documentoE.emProcessamento = false;
        //    if (resultado.Aprovado)
        //    {
        //        foreach (Cartao.RespostaAprovada respostaAprovada in resultado.ListaRespostaAprovada)
        //        {
        //            tb_solicitacao_pagamento solicitacaoPagamento = documentoE.tb_solicitacao_pagamento.Where(sp => sp.codSolicitacaoPagamento == respostaAprovada.CodSolicitacaoPagamento).FirstOrDefault();
        //            solicitacaoPagamento.cupomCliente = respostaAprovada.CupomCliente;
        //            solicitacaoPagamento.cupomEstabelecimento = respostaAprovada.CupomLojista;
        //            solicitacaoPagamento.cupomReduzido = respostaAprovada.CupomReduzido;
        //        }
        //    }
        //    else
        //    {
        //        Cartao.RespostaRecusada recusada = resultado.RespostaRecusada;
        //        documentoE.codMotivoCartaoNegado = recusada.CodMotivo;
        //        documentoE.motivoCartaoNegado = recusada.Motivo;
        //    }
        //    repSolicitacao.SaveChanges();
        //}

        //public List<SolicitacaoPagamento> ObterSolicitacaoPagamentoCartao()
        //{
        //    var repSolicitacoes = new RepositorioGenerico<tb_solicitacao_documento>();
        //    var saceEntities = (SaceEntities)repSolicitacoes.ObterContexto();
        //    var query = from solicitacao in saceEntities.tb_solicitacao_documento
        //                where solicitacao.tipoSolicitacao.Equals("NFCE") && solicitacao.haPagamentoCartao == true &&
        //                    solicitacao.cartaoProcessado == false
        //                orderby solicitacao.dataSolicitacao
        //                select solicitacao;
        //    List<tb_solicitacao_documento> listaSolicitacoes = query.ToList();
        //    List<SolicitacaoPagamento> listaPagamentos = new List<SolicitacaoPagamento>();

        //    if (listaSolicitacoes.Count > 0)
        //    {
        //        tb_solicitacao_documento solicitacao = listaSolicitacoes.First();
        //        foreach (tb_solicitacao_pagamento pagamento in solicitacao.tb_solicitacao_pagamento)
        //        {
        //            listaPagamentos.Add(
        //                new SolicitacaoPagamento()
        //                {
        //                    CodSolicitacao = pagamento.codSolicitacao,
        //                    CodSolicitacaoPagamento = (long)pagamento.codSolicitacaoPagamento,
        //                    CodCartaoCredito = pagamento.codCartao,
        //                    NomeCartaoCredito = pagamento.tb_cartao_credito.nome,
        //                    CodFormaPagamento = pagamento.codFormaPagamento,
        //                    QtdDiasPagar = (int)pagamento.tb_cartao_credito.diaBase,
        //                    Parcelas = (int)pagamento.parcelas,
        //                    Valor = pagamento.valor
        //                }
        //            );
        //        }

        //    }
        //    return listaPagamentos;
        //}


        /// <summary>
        /// Remove dados do cupom
        /// </summary>
        /// <param name="codCupom"></param>
        public void RemoverSolicitacaoDocumento(long codSaida)
        {
            try
            {
                var repSolicitacao = new RepositorioGenerico<tb_solicitacao_documento>();
                var saceEntities = (SaceEntities)repSolicitacao.ObterContexto();
                var query = from solicitacaoSaida in saceEntities.tb_solicitacao_saida
                            where solicitacaoSaida.codSaida == codSaida
                            select solicitacaoSaida;
                tb_solicitacao_saida solicitacao_saidaE = query.ToList().FirstOrDefault();
                if (solicitacao_saidaE != null)
                {
                    if (solicitacao_saidaE.tb_solicitacao_documento.emProcessamento == true)
                    {
                        throw new NegocioException("Não é possível editar/remover esse pedido. Documento sendo autorizado/impresso. Favor aguardar até a conclusão do processamento.");
                    }

                    repSolicitacao.Remover(s => s.codSolicitacao == solicitacao_saidaE.codSolicitacao);
                    repSolicitacao.SaveChanges();
                }

            }
            catch (Exception e)
            {
                throw new DadosException("Documento Fiscal", e.Message, e);
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        public tb_solicitacao_documento ObterSolicitacaoDocumento(long codSolicitacao)
        {
            //var repSolicitacao = new RepositorioGenerico<tb_solicitacao_documento>();
            //var saceEntities = (SaceEntities)repSolicitacao.ObterContexto();
            var query = from documento in saceContext.tb_solicitacao_documento
                        where documento.codSolicitacao == codSolicitacao
                        select documento;
            return query.FirstOrDefault();
        }


        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<tb_solicitacao_saida> ObterSolicitacaoSaida(long codSolicitacao)
        {
            var repSolicitacaoSaida = new RepositorioGenerico<tb_solicitacao_saida>();
            var saceEntities = (SaceEntities)repSolicitacaoSaida.ObterContexto();
            var query = from solicitacao_saida in saceEntities.tb_solicitacao_saida
                        where solicitacao_saida.codSolicitacao == codSolicitacao
                        select solicitacao_saida;
            return query;
        }

        /// <summary>
        /// Obtém lista de cupons emitidos
        /// </summary>
        /// <returns></returns>
        public List<DocumentoFiscal> ObterDocumentosFiscais()
        {
            var repCupom = new RepositorioGenerico<tb_saida>();
            var saceEntities = (SaceEntities)repCupom.ObterContexto();
            var query = from saida in saceEntities.tb_saida
                        where !saida.pedidoGerado.Trim().Equals("")
                        orderby saida.pedidoGerado
                        select new DocumentoFiscal
                        {
                            CodCliente = saida.codCliente,
                            CodSaida = saida.codSaida,
                            NumeroCupomFiscal = saida.pedidoGerado,
                            DataEmissaoCupomFiscal = (DateTime)saida.dataEmissaoDocFiscal,
                            NomeCliente = saida.tb_pessoa.nome
                        };
            return query.ToList();
        }

        /// <summary>
        /// Atualiza dados do cupom
        /// </summary>
        /// <param name="cupom"></param>
        public void EnviarProximoNFe(string servidor)
        {
            try
            {
                string nomeComputador = System.Windows.Forms.SystemInformation.ComputerName;
                var repSolicitacao = new RepositorioGenerico<tb_solicitacao_documento>();

                var repSolicitacao2 = new RepositorioGenerico<tb_solicitacao_documento>();

                List<tb_solicitacao_documento> solicitacoes = repSolicitacao.ObterTodos().Where(C =>
                    //    C.tipoSolicitacao.Equals(DocumentoFiscal.TipoSolicitacao.NFCE.ToString()) ||
                    C.tipoSolicitacao.Equals(DocumentoFiscal.TipoSolicitacao.NFE.ToString())).OrderBy(s => s.dataSolicitacao).ToList();

                if (solicitacoes.Any())
                {
                    tb_solicitacao_documento solicitacaoE = solicitacoes.FirstOrDefault();
                    List<tb_solicitacao_saida> listaSolicitacaoSaida = solicitacaoE.tb_solicitacao_saida.ToList();
                    if (listaSolicitacaoSaida.Count > 0)
                    {
                        int codLoja = listaSolicitacaoSaida.FirstOrDefault().tb_saida.codLojaOrigem;
                        if (codLoja.Equals(UtilConfig.Default.LOJA_PADRAO) || nomeComputador.Equals(servidor))
                        {
                            List<tb_solicitacao_pagamento> listaSolicitacaoPagamentos = solicitacaoE.tb_solicitacao_pagamento.ToList();
                            repSolicitacao2.Remover(s => s.codSolicitacao == solicitacaoE.codSolicitacao);
                            repSolicitacao2.SaveChanges();

                            GerenciadorNFe.GetInstance().EnviarNFE(listaSolicitacaoSaida, listaSolicitacaoPagamentos, DocumentoFiscal.TipoSolicitacao.NFE, solicitacaoE);
                        }
                    }
                    else
                    {
                        repSolicitacao2.Remover(s => s.codSolicitacao == solicitacaoE.codSolicitacao);
                        repSolicitacao2.SaveChanges();
                    }
                }
            }

            catch (Exception e)
            {
                throw new DadosException("Cupom", e.Message, e);
            }
        }

        /// <summary>
        /// Atualiza dados do cupom NFCe
        /// </summary>
        /// <param name="cupom"></param>
        public void EnviarProximoNFCe(string servidorCartao)
        {
            try
            {
                var repSolicitacao = new RepositorioGenerico<tb_solicitacao_documento>();
                var repSolicitacao2 = new RepositorioGenerico<tb_solicitacao_documento>();

                IEnumerable<tb_solicitacao_documento> todasSolicitacoesNFCE = repSolicitacao.ObterTodos().Where(s => s.tipoSolicitacao.Equals(DocumentoFiscal.TipoSolicitacao.NFCE.ToString()) && !s.emProcessamento);

                IEnumerable<tb_solicitacao_documento> solicitacoes;
                solicitacoes = todasSolicitacoesNFCE.ToList();

                if (solicitacoes.Any())
                {
                    tb_solicitacao_documento solicitacaoE = solicitacoes.FirstOrDefault();
                    List<tb_solicitacao_saida> listaSolicitacaoSaida = solicitacaoE.tb_solicitacao_saida.ToList();
                    List<tb_solicitacao_pagamento> listaSolicitacaoPagamentos = solicitacaoE.tb_solicitacao_pagamento.ToList();

                    repSolicitacao2.Remover(s => s.codSolicitacao == solicitacaoE.codSolicitacao);
                    repSolicitacao2.SaveChanges();
                    GerenciadorNFe.GetInstance().EnviarNFE(listaSolicitacaoSaida, listaSolicitacaoPagamentos, DocumentoFiscal.TipoSolicitacao.NFCE, solicitacaoE);
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Cupom", e.Message, e);
            }
        }
    }
}