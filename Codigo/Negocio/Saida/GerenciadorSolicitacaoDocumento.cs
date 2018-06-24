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
        private static GerenciadorSolicitacaoDocumento gCupom;
        private static SaceEntities saceContext;
        private static RepositorioGenerico<tb_solicitacao_documento> repSolicitacaoDocumento;

        public static GerenciadorSolicitacaoDocumento GetInstance()
        {
            if (gCupom == null)
            {
                gCupom = new GerenciadorSolicitacaoDocumento();
            }
            repSolicitacaoDocumento = new RepositorioGenerico<tb_solicitacao_documento>();
            saceContext = (SaceEntities)repSolicitacaoDocumento.ObterContexto();
            return gCupom;
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
            if (tipoSolicitacao.Equals(DocumentoFiscal.TipoSolicitacao.ECF))
            {
                var repSaida = new RepositorioGenerico<tb_saida>();
                SaceEntities saceEntities = (SaceEntities)repSaida.ObterContexto();
                var query = from saida in saceEntities.tb_saida
                            where listaCodSaidas.Contains(saida.codSaida) && !String.IsNullOrEmpty(saida.pedidoGerado)
                            select saida;
                if (query.Count() > 0)
                    throw new NegocioException("Cumpom Fiscal já foi emitido para algum dos pedidos dessa solicitação.");
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
        /// Atualiza dados do cupom
        /// </summary>
        /// <param name="cupom"></param>
        public void EnviarProximoECF()
        {
            try
            {
                var repSolicitacao = new RepositorioGenerico<tb_solicitacao_documento>();
                var repSolicitacao2 = new RepositorioGenerico<tb_solicitacao_documento>();
                DirectoryInfo pastaECF = new DirectoryInfo(Global.PASTA_COMUNICACAO_FRENTE_LOJA);
                if (pastaECF.Exists)
                {
                    FileInfo[] files = pastaECF.GetFiles("*.TXT", SearchOption.TopDirectoryOnly);
                    if (files.Length == 0)
                    {
                        var saceEntities = (SaceEntities)repSolicitacao.ObterContexto();
                        var query = from solicitacao in saceEntities.tb_solicitacao_documento
                                    where solicitacao.tipoSolicitacao.Equals("ECF")
                                    orderby solicitacao.dataSolicitacao
                                    select solicitacao;
                        List<tb_solicitacao_documento> solicitacoes = query.ToList();
                        if (solicitacoes.Count() > 0)
                        {
                            tb_solicitacao_documento solicitacaoE = solicitacoes.FirstOrDefault();
                            List<tb_solicitacao_saida> listaSolicitacaoSaida = solicitacaoE.tb_solicitacao_saida.ToList();
                            List<tb_solicitacao_pagamento> listaPagamentos = solicitacaoE.tb_solicitacao_pagamento.ToList();

                            repSolicitacao2.Remover(s => s.codSolicitacao == solicitacaoE.codSolicitacao);
                            repSolicitacao2.SaveChanges();


                            GerarDocumentoECF(listaSolicitacaoSaida, listaPagamentos);
                            //RemoverSolicitacaoDocumento(listaSolicitacaoSaida.FirstOrDefault().codSaida);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Cupom", e.Message, e);
            }
        }


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
        public void EnviarProximoNFe(string servidorNfeDeposito)
        {
            try
            {
                string nomeComputador = System.Windows.Forms.SystemInformation.ComputerName;
                var repSolicitacao = new RepositorioGenerico<tb_solicitacao_documento>();

                var repSolicitacao2 = new RepositorioGenerico<tb_solicitacao_documento>();
                var repSolicitacaoPagamento = new RepositorioGenerico<tb_solicitacao_pagamento>();
                var repSolicitacaoSaida = new RepositorioGenerico<tb_solicitacao_saida>();

                List<tb_solicitacao_documento> solicitacoes = repSolicitacao.ObterTodos().Where(C => 
                    //    C.tipoSolicitacao.Equals(DocumentoFiscal.TipoSolicitacao.NFCE.ToString()) ||
                    C.tipoSolicitacao.Equals(DocumentoFiscal.TipoSolicitacao.NFE.ToString())).OrderBy(s => s.dataSolicitacao).ToList();

                if (solicitacoes.Count() > 0)
                {
                    tb_solicitacao_documento solicitacaoE = solicitacoes.FirstOrDefault();
                    List<tb_solicitacao_saida> listaSolicitacaoSaida = solicitacaoE.tb_solicitacao_saida.ToList();
                    int codLoja = listaSolicitacaoSaida.FirstOrDefault().tb_saida.codLojaOrigem;
                    if (codLoja.Equals(Global.LOJA_PADRAO) || nomeComputador.Equals(servidorNfeDeposito)) {
                        List<tb_solicitacao_pagamento> listaSolicitacaoPagamentos = solicitacaoE.tb_solicitacao_pagamento.ToList();
                        repSolicitacao2.Remover(s => s.codSolicitacao == solicitacaoE.codSolicitacao);
                        repSolicitacao2.SaveChanges();
                        
                        GerenciadorNFe.GetInstance().EnviarNFE(listaSolicitacaoSaida, listaSolicitacaoPagamentos, DocumentoFiscal.TipoSolicitacao.NFE, solicitacaoE);
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
                string nomeComputador = System.Windows.Forms.SystemInformation.ComputerName;

                var repSolicitacao = new RepositorioGenerico<tb_solicitacao_documento>();
                var repSolicitacao2 = new RepositorioGenerico<tb_solicitacao_documento>();
                
                IEnumerable<tb_solicitacao_documento> todasSolicitacoesNFCE = repSolicitacao.ObterTodos().Where(s => s.tipoSolicitacao.Equals(DocumentoFiscal.TipoSolicitacao.NFCE.ToString()) && !s.emProcessamento);

                IEnumerable<tb_solicitacao_documento> solicitacoes;
                //if (nomeComputador.Equals(servidorCartao))
                //{
                //    solicitacoes = todasSolicitacoesNFCE.Where(s => s.haPagamentoCartao || s.hostSolicitante.Equals(nomeComputador)).ToList();
                //}
                //else
                //{
                //    solicitacoes = todasSolicitacoesNFCE.Where(s => s.hostSolicitante.Equals(nomeComputador)).ToList();
                //}
                solicitacoes = todasSolicitacoesNFCE.ToList();
                


                if (solicitacoes.Count() > 0)
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

        /// <summary>
        /// Atualiza dados do cupom NFCe
        /// </summary>
        /// <param name="cupom"></param>
        public void EnviarProximoNFCeMKS(string servidorCartao, int nfceServidor, int nfceOnline)
        {
            try
            {
                string nomeComputador = System.Windows.Forms.SystemInformation.ComputerName;

                var repSolicitacao = new RepositorioGenerico<tb_solicitacao_documento>();
                IEnumerable<tb_solicitacao_documento> todasSolicitacoesNFCE = repSolicitacao.ObterTodos().Where(s=> s.tipoSolicitacao.Equals(DocumentoFiscal.TipoSolicitacao.NFCE.ToString()) && !s.emProcessamento) ;

                IEnumerable<tb_solicitacao_documento> solicitacoes;
                if (nomeComputador.Equals(servidorCartao))
                {
                    solicitacoes = todasSolicitacoesNFCE.Where(s => s.haPagamentoCartao || s.hostSolicitante.Equals(nomeComputador)).ToList();
                }
                else
                {
                    solicitacoes = todasSolicitacoesNFCE.Where(s => s.hostSolicitante.Equals(nomeComputador)).ToList();
                }

                
                if (solicitacoes.Count() > 0)
                {
                    tb_solicitacao_documento solicitacaoE = solicitacoes.OrderBy(s => s.dataSolicitacao).FirstOrDefault();
                    SolicitarNFCeMKS(solicitacaoE, nfceServidor, nfceOnline);
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Cupom", e.Message, e);
            }
        }

        /// <summary>
        /// Gera o NFCe a partir das saídas e valores a vista de cada saía
        /// </summary>
        /// <param name="saidaPagamentos"></param>
        private void SolicitarNFCeMKS(tb_solicitacao_documento solicitacaoE, int nfceServidor, int nfceOnline)
        {
            var repSolicitacao = new RepositorioGenerico<tb_solicitacao_documento>();
            List<tb_solicitacao_saida> listaSolicitacaoSaida = solicitacaoE.tb_solicitacao_saida.ToList();
            List<tb_solicitacao_pagamento> listaSolicitacaoPagamentos = solicitacaoE.tb_solicitacao_pagamento.ToList();

            solicitacaoE.emProcessamento = true;
            repSolicitacao.SaveChanges();

            // nome dos arquivos padronizado pelo MKS
            String nomeArqDocumento = Global.PASTA_COMUNICACAO_NFCE_RECEBER + "DOCUMENTO.txt";
            String nomeArqPagamento = Global.PASTA_COMUNICACAO_NFCE_RECEBER + "PAGAMENTO.txt";
            String nomeArqProdutos = Global.PASTA_COMUNICACAO_NFCE_RECEBER + "PRODUTOS.txt";

            try
            {
                DirectoryInfo pastaECF = new DirectoryInfo(Global.PASTA_COMUNICACAO_NFCE_RECEBER);
                string arquivosComunicaMKS = "*.txt";
                FileInfo[] filesComunicacao = null;
                if (pastaECF.Exists)
                    filesComunicacao = pastaECF.GetFiles(arquivosComunicaMKS, SearchOption.TopDirectoryOnly);
                if (filesComunicacao != null && filesComunicacao.Count() == 0)
                {
                    List<Saida> saidas = new List<Saida>();
                    decimal totalSolicitacaoSaidas = 0;
                    // alguma saida já possui cupom fiscal impresso?
                    foreach (tb_solicitacao_saida solicitacaoSaida in listaSolicitacaoSaida)
                    {
                        Saida saida = GerenciadorSaida.GetInstance(null).Obter(solicitacaoSaida.codSaida);
                        if (!string.IsNullOrEmpty(saida.CupomFiscal))
                        {
                            RemoverSolicitacaoDocumento(saida.CodSaida);
                        }
                        else
                        {
                            saidas.Add(saida);
                            totalSolicitacaoSaidas += solicitacaoSaida.valorTotal;
                        }
                    }

                    if (saidas.Count > 0)
                    {
                        // Criar lista de Produtos associados as saídas
                        List<SaidaProduto> listaSaidaProdutos = new List<SaidaProduto>();
                        Pessoa cliente = (Pessoa)GerenciadorPessoa.GetInstance().Obter(saidas[0].CodCliente).ElementAt(0);
                        foreach (Saida saida in saidas)
                        {
                            List<SaidaProduto> saidaProdutos = new List<SaidaProduto>();
                            if (cliente.ImprimirCF)
                                saidaProdutos = GerenciadorSaidaProduto.GetInstance(null).ObterPorSaida(saida.CodSaida);
                            else
                                saidaProdutos = GerenciadorSaidaProduto.GetInstance(null).ObterPorSaidaSemCST(saida.CodSaida, Cst.ST_OUTRAS);

                            decimal totalAVista = listaSolicitacaoSaida.Where(cs => cs.codSaida.Equals(saida.CodSaida)).Sum(cs => cs.valorTotal);
                            if (saidaProdutos.Count > 0)
                            {
                                // associa as saídas ao pedido que foi gerado para emissão do cupom fiscal
                                if (GerenciadorSaidaPedido.GetInstance().ObterPorSaida(saida.CodSaida).Count == 0)
                                {
                                    GerenciadorSaidaPedido.GetInstance().Inserir(new SaidaPedido() { CodSaida = saida.CodSaida, CodPedido = saidas[0].CodSaida, TotalAVista = totalAVista });
                                }
                                else
                                {
                                    GerenciadorSaidaPedido.GetInstance().Atualizar(new SaidaPedido() { CodSaida = saida.CodSaida, CodPedido = saidas[0].CodSaida, TotalAVista = totalAVista });
                                }
                                listaSaidaProdutos.AddRange(saidaProdutos);
                            }
                            else
                            {
                                GerenciadorSaida.GetInstance(null).AtualizarTipoPedidoGeradoPorSaida(Saida.TIPO_VENDA, "", Saida.TIPO_DOCUMENTO_NFCE, totalAVista, saida.CodSaida);
                            }
                        }

                        Loja loja = GerenciadorLoja.GetInstance().Obter(Global.LOJA_PADRAO).ElementAtOrDefault(0);
                        long numeroCupom = GerenciadorNFe.GetInstance().ObterProximoNumeroSequenciaNfeLoja(loja, NfeControle.MODELO_NFCE);
                        bool haPagamentoCartao = listaSolicitacaoPagamentos.Where(s => s.codFormaPagamento.Equals(FormaPagamento.CARTAO)).Count() > 0;
                        if (haPagamentoCartao)
                            SolicitarAutorizacaoCartao(numeroCupom, listaSolicitacaoPagamentos, solicitacaoE.codSolicitacao);

                        // gravar DOCUMENTO.txt
                        StreamWriter arqDocumento = new StreamWriter(nomeArqDocumento, false, Encoding.ASCII);
                        decimal valorImposto = GerenciadorImposto.GetInstance().CalcularValorImpostoProdutos(listaSaidaProdutos).Sum(sp => sp.ValorImposto);
                        decimal valorImpostoPercentual = valorImposto / totalSolicitacaoSaidas * 100;
                        decimal troco = totalSolicitacaoSaidas - listaSolicitacaoPagamentos.Sum(p => p.valor);

                        String linhaArqDocumento = (numeroCupom.ToString().PadLeft(6, '0') + "|");
                        linhaArqDocumento += ("Valor.Aprox.Imp. R$" + valorImposto.ToString("N2") + " " + valorImpostoPercentual.ToString("N2") + "% " + " Fonte IBPT").PadRight(51)+"|";
                        linhaArqDocumento += (saidas[0].CpfCnpj + "|").PadLeft(12);
                        linhaArqDocumento += (troco.ToString("N2") + "|").PadLeft(07);
                        linhaArqDocumento += nfceServidor + "|";  
                        linhaArqDocumento += nfceOnline +""; 
                        arqDocumento.WriteLine(linhaArqDocumento);

                        // PRODUTOS.txt
                        StreamWriter arqProdutos = new StreamWriter(nomeArqProdutos, false, Encoding.ASCII);

                        listaSaidaProdutos = GerenciadorSaida.GetInstance(null).ExcluirProdutosDevolvidosMesmoPreco(listaSaidaProdutos);
                        decimal valorDesconto = listaSaidaProdutos.Sum(s => s.Subtotal) - totalSolicitacaoSaidas;
                        decimal valorDescontoPadrao = listaSaidaProdutos.Sum(s => s.Subtotal) - listaSaidaProdutos.Sum(s => s.SubtotalAVista);
                        decimal totalProdutos = listaSaidaProdutos.Where(sp => sp.Quantidade > 0).Sum(sp => sp.Subtotal);
                        listaSaidaProdutos = GerenciadorNFe.GetInstance().DistribuirDescontoProdutos(listaSaidaProdutos, valorDesconto, totalProdutos);

                        foreach (SaidaProduto saidaProduto in listaSaidaProdutos)
                        {
                            if ((saidaProduto.Quantidade > 0) && (saidaProduto.ValorVenda > 0))
                            {
                                Produto produto = new Produto();
                                produto.CodProduto = saidaProduto.CodProduto;
                                produto.CodCST = saidaProduto.CodCST;
                                String cst = produto.EhTributacaoIntegral ? "102" : "500";  //01-17%  02-25% 03-27%
                                String linhaArqProdutos = saidaProduto.CodProduto.ToString().PadLeft(13) + "|";
                                linhaArqProdutos += saidaProduto.Nome.PadLeft(65) + "|";
                                linhaArqProdutos += saidaProduto.Quantidade.ToString().PadLeft(7) + "|";
                                if (valorDesconto == valorDescontoPadrao)
                                    linhaArqProdutos += saidaProduto.ValorVendaAVista.ToString().PadLeft(10) + "|";
                                else
                                    linhaArqProdutos += ((saidaProduto.SubtotalAVista - saidaProduto.ValorDesconto) / saidaProduto.Quantidade).ToString().PadLeft(10) + "|";
                                linhaArqProdutos += cst.PadLeft(3) + "|";
                                linhaArqProdutos += saidaProduto.Ncmsh.PadLeft(8) + "|";
                                linhaArqProdutos += "ASD|"; //TODO:CEST
                                linhaArqProdutos += produto.EhTributacaoIntegral ? "5102|" : "5405|";
                                linhaArqProdutos += saidaProduto.Unidade.Length > 2 ? saidaProduto.Unidade.Substring(0,2) : saidaProduto.Unidade.PadLeft(2) + "|";
                                linhaArqProdutos += "18,00";
                                arqProdutos.WriteLine(linhaArqProdutos);
                            }
                        }

                        // PAGAMENTOS.txt
                        StreamWriter arqPagamento = new StreamWriter(nomeArqPagamento, false, Encoding.ASCII);
                        if (listaSaidaProdutos.Count > 0)
                        {
                            foreach (tb_solicitacao_pagamento pagamento in listaSolicitacaoPagamentos)
                            {
                                if (pagamento.codFormaPagamento.Equals(FormaPagamento.CARTAO))
                                {
                                    CartaoCredito cartaoCredito = GerenciadorCartaoCredito.GetInstance().Obter(pagamento.codCartao).ElementAtOrDefault(0);
                                    if (cartaoCredito.TipoCartao.Equals(CartaoCredito.TIPO_CARTAO_CREDITO))
                                        arqPagamento.WriteLine("CARTAOCREDITO  |".PadRight(16) + pagamento.valor.ToString("N2").PadLeft(10));
                                    else
                                        arqPagamento.WriteLine("CARTAODEBITO   |" + pagamento.valor.ToString("N2").PadLeft(10));

                                }
                                else
                                {
                                    arqPagamento.WriteLine("DINHEIRO       |" + pagamento.valor.ToString("N2").PadLeft(10));
                                }
                                //CHEQUE CREDITOLOJA VALEALIMENTACAO VALEREFEICAO VALEPRESENTE VALECOMBUSTIVEL OUTRO
                            }
                        }
                        arqDocumento.Close();
                        arqProdutos.Close();
                        arqPagamento.Close();
                        var repSolicitacao2 = new RepositorioGenerico<tb_solicitacao_documento>();
                        repSolicitacao2.Remover(s => s.codSolicitacao == solicitacaoE.codSolicitacao);
                        repSolicitacao2.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                if (e is NegocioException)
                {
                    throw e;
                }
            }
            finally
            {
                solicitacaoE.emProcessamento = false;
                repSolicitacao.SaveChanges();
            }
        }

        /// <summary>
        /// Gera o arquivo para solicitar autorização de cartão de crédito.
        /// </summary>
        /// <param name="solicitacaoE"></param>
        public void SolicitarAutorizacaoCartao(long numeroCupom, List<tb_solicitacao_pagamento> listaSolicitacaoPagamentos, long codSolicitacao)
        {
            // nome dos arquivos padronizado pelo MKS
            String nomeArqVendas = Global.PASTA_COMUNICACAO_TEF_REQUISICAO + "Vendas.txt";
            try
            {
                DirectoryInfo pastaTEF = new DirectoryInfo(Global.PASTA_COMUNICACAO_TEF_REQUISICAO);
                string arquivosComunicaMKS = "*.txt";
                FileInfo[] filesComunicacao = null;
                if (pastaTEF.Exists)
                    filesComunicacao = pastaTEF.GetFiles(arquivosComunicaMKS, SearchOption.TopDirectoryOnly);
                if (filesComunicacao != null && filesComunicacao.Count() == 0)
                {
                    StreamWriter arqVendas = new StreamWriter(nomeArqVendas, false, Encoding.ASCII);
                    // gravar VENDAS.txt
                    foreach (tb_solicitacao_pagamento pagamento in listaSolicitacaoPagamentos)
                    {
                        String linhaCartao = "Venda";
                        CartaoCredito cartaoCredito = GerenciadorCartaoCredito.GetInstance().Obter(pagamento.codCartao).ElementAtOrDefault(0);
                        if (cartaoCredito.TipoCartao.Equals(CartaoCredito.TIPO_CARTAO_DEBITO))
                            linhaCartao += "SDA"; // SDA - DEBITO A VISTA
                        else if (cartaoCredito.TipoCartao.Equals(CartaoCredito.TIPO_CARTAO_CREDITO) && pagamento.parcelas > 1)
                            linhaCartao += "SDP"; // SDP - CREDITO PARCELADO
                        else
                            linhaCartao += "SCA"; // SCA - CREDITO A VISTA

                        linhaCartao += pagamento.valor.ToString("0000000000").Replace(".", "");
                        linhaCartao += numeroCupom.ToString("0000000");

                        arqVendas.WriteLine(linhaCartao);
                    }
                    arqVendas.Close();
                }
                bool retornouRespostaCartao = false;
                while (!retornouRespostaCartao)
                {
                    retornouRespostaCartao = ReceberRespostaCartao(codSolicitacao);
                    Thread.Sleep(500);
                }
            }
            catch (Exception e)
            {
                if (e is NegocioException)
                {
                    throw e;
                }
            }
        }

        private bool ReceberRespostaCartao(long codSolicitacao)
        {
            bool processouCartao = false;
            DirectoryInfo PastaRetornoCartao = new DirectoryInfo(Global.PASTA_COMUNICACAO_TEF_RETORNO);
            if (PastaRetornoCartao.Exists)
            {
                FileInfo[] Files = PastaRetornoCartao.GetFiles("*.TXT", SearchOption.TopDirectoryOnly);
                if (Files.Length != 0)
                {
                    foreach (FileInfo file in Files)
                    {
                        StreamReader reader = new StreamReader(file.FullName);
                        bool aprovado = false;
                        String linha = null;
                        if ((linha = reader.ReadLine()) != null)
                        {
                            aprovado = !linha.EndsWith("NAOAPROVADO");
                        }
                        reader.Close();

                        // quando cupom fiscal impresso com sucesso atualiza saidas
                        long numeroNFCE = Convert.ToInt64(file.Name.Replace(".TXT", ""));
                        List<SaidaPedido> _listaSaidaPedido = GerenciadorSaidaPedido.GetInstance().ObterPorPedido(numeroNFCE);
                       
                        var query = from documento in saceContext.tb_solicitacao_documento
                        where documento.codSolicitacao == codSolicitacao
                        select documento;
                        tb_solicitacao_documento solicitacao = query.FirstOrDefault();
                        
                        if (aprovado)
                        {
                            foreach (SaidaPedido saidaPedido in _listaSaidaPedido)
                            {
                                GerenciadorSaida.GetInstance(null).AtualizarTipoPedidoGeradoPorSaida(Saida.TIPO_VENDA, numeroNFCE.ToString(), Saida.TIPO_DOCUMENTO_NFCE, saidaPedido.TotalAVista, saidaPedido.CodSaida);
                                RemoverSolicitacaoDocumento(saidaPedido.CodSaida);
                            }
                            solicitacao.cartaoProcessado = true;
                            solicitacao.cartaoAutorizado = true;
                            processouCartao = true;
                        }
                        else
                        {
                            foreach (SaidaPedido saidaPedido in _listaSaidaPedido)
                            {
                                bool temPagamentoCrediario = GerenciadorSaidaPagamento.GetInstance(null).ObterPorSaidaFormaPagamento(saidaPedido.CodSaida, FormaPagamento.CREDIARIO).ToList().Count > 0;
                                if (!temPagamentoCrediario)
                                {
                                    Saida saida = GerenciadorSaida.GetInstance(null).Obter(saidaPedido.CodSaida);
                                    if ((saida != null) && (saida.TipoSaida != Saida.TIPO_VENDA))
                                    {
                                        saida.TipoSaida = Saida.TIPO_PRE_VENDA;
                                        GerenciadorSaida.GetInstance(null).PrepararEdicaoSaida(saida);
                                    }
                                }
                            }
                            solicitacao.cartaoProcessado = true;
                            solicitacao.cartaoAutorizado = false;
                            processouCartao = true;
                        }
                        repSolicitacaoDocumento.SaveChanges();
                        GerenciadorSaidaPedido.GetInstance().RemoverPorPedido(numeroNFCE);
                        DirectoryInfo PastaBackup = new DirectoryInfo(Global.PASTA_COMUNICACAO_FRENTE_LOJA_BACKUP);
                        if (PastaBackup.Exists)
                        {
                            file.CopyTo(Global.PASTA_COMUNICACAO_FRENTE_LOJA_BACKUP + file.Name, true);
                        }
                        if (file.Exists)
                        {
                            file.Delete();
                        }
                    }
                }
            }
            return processouCartao;
        }


        /// <summary>
        /// Atualiza documento NFCE com retorno da GestorMKS
        /// </summary>
        /// <returns></returns>
        public Boolean AtualizarPedidosComDocumentosNFCEMKS()
        {
            Boolean atualizou = false;
            string FORMATO_DATA_HORA = "yyyy-MM-ddTHH:mm:sszzz";
            DirectoryInfo PastaRetornoDevolver = new DirectoryInfo(Global.PASTA_COMUNICACAO_NFCE_DEVOLVER);
            DirectoryInfo PastaRetornoXML = new DirectoryInfo(Global.PASTA_COMUNICACAO_NFCE_XML);
            string nomeComputador = System.Windows.Forms.SystemInformation.ComputerName;
            if (PastaRetornoDevolver.Exists && PastaRetornoXML.Exists)
            {
                // Busca automaticamente todos os arquivos em todos os subdiretórios
                FileInfo[] Files = PastaRetornoDevolver.GetFiles("*", SearchOption.TopDirectoryOnly);
                FileInfo[] FilesXML = PastaRetornoXML.GetFiles("*.xml", SearchOption.TopDirectoryOnly);

                if (Files.Length == 0)
                {
                    atualizou = true;
                }
                else
                {
                    foreach (FileInfo file in Files)
                    {
                        try
                        {
                            bool sucesso = false;
                            StreamReader reader = new StreamReader(file.FullName);

                            String linha = null;
                            if ((linha = reader.ReadLine()) != null)
                            {
                                sucesso = linha.EndsWith("OK");
                            }
                            reader.Close();

                            // quando cupom fiscal impresso com sucesso atualiza saidas
                            long numeroNFCE = Convert.ToInt64(file.Name.Replace(".TXT", ""));
                            List<SaidaPedido> _listaSaidaPedido = GerenciadorSaidaPedido.GetInstance().ObterPorPedido(numeroNFCE);
                            if (sucesso)
                            {
                                foreach (SaidaPedido saidaPedido in _listaSaidaPedido)
                                {
                                    GerenciadorSaida.GetInstance(null).AtualizarTipoPedidoGeradoPorSaida(Saida.TIPO_VENDA, numeroNFCE.ToString(), Saida.TIPO_DOCUMENTO_NFCE, saidaPedido.TotalAVista, saidaPedido.CodSaida);
                                    RemoverSolicitacaoDocumento(saidaPedido.CodSaida);
                                    atualizou = true;
                                }

                                foreach (FileInfo filexml in FilesXML)
                                {
                                    TNfeProc nfce = GerenciadorNFe.GetInstance().LerNFE(filexml.FullName);
                                    NfeControle nfeControle = new NfeControle();
                                    nfeControle.Chave = nfce.protNFe.infProt.chNFe;
                                    nfeControle.CodLoja = Global.LOJA_PADRAO;
                                    DateTime dataEmissao;
                                    DateTime.TryParse(nfce.NFe.infNFe.ide.dhEmi, out dataEmissao);
                                    nfeControle.DataEmissao = dataEmissao;
                                    if (_listaSaidaPedido.Count > 0)
                                        nfeControle.CodSaida = _listaSaidaPedido.FirstOrDefault().CodSaida;
                                    nfeControle.Modelo = nfce.NFe.infNFe.ide.mod.Equals(TMod.Item55) ? NfeControle.MODELO_NFE : NfeControle.MODELO_NFCE;
                                    nfeControle.NumeroProtocoloUso = nfce.protNFe.infProt.nProt;
                                    nfeControle.NumeroSequenciaNfe = Int32.Parse(nfce.NFe.infNFe.ide.nNF);
                                    if (nfce.protNFe.infProt.cStat.Equals(NfeStatusResposta.NFE100_AUTORIZADO_USO_NFE))
                                        nfeControle.SituacaoNfe = NfeControle.SITUACAO_AUTORIZADA;
                                    else if (nfce.protNFe.infProt.cStat.Equals(NfeStatusResposta.NFE110_USO_DENEGADO))
                                        nfeControle.SituacaoNfe = NfeControle.SITUACAO_DENEGADA;
                                    else
                                        nfeControle.SituacaoNfe = NfeControle.SITUACAO_REJEITADA;
                                    nfeControle.SituacaoProtocoloUso = nfce.protNFe.infProt.cStat;
                                    Saida saida = GerenciadorSaida.GetInstance(null).Obter(nfeControle.CodSaida);
                                    //GerenciadorNFe.GetInstance().Inserir(nfeControle, saida, false, listaSolicitacaoSaida);
                                    Loja loja = GerenciadorLoja.GetInstance().Obter(nfeControle.CodLoja).FirstOrDefault();

                                    string dirDestino = loja.PastaNfeAutorizados
                                        + dataEmissao.Year + dataEmissao.Month.ToString("00")
                                        + dataEmissao.Day.ToString("00") + "\\";
                                    string namefile = dirDestino + nfeControle.Chave + "-nfe.xml";
                                    if (!Directory.Exists(dirDestino))
                                    {
                                        Directory.CreateDirectory(dirDestino);
                                    }
                                    if (File.Exists(namefile))
                                    {
                                        File.Delete(namefile);
                                    }

                                    filexml.MoveTo(namefile);
                                }
                            }
                            else
                            {
                                GerenciadorSaidaPedido.GetInstance().TransformarOrcamentoPorRecusaDocumentoFiscal(_listaSaidaPedido.Select(s=>s.CodSaida));
                            }
                            GerenciadorSaidaPedido.GetInstance().RemoverPorPedido(numeroNFCE);
                        }
                        catch (Exception)
                        {
                            // Se houver algum impossibilidade de trasnformar o pedido em pré-venda
                            // não tem problema. Pode acontecer quando cliente quita a conta gerada
                            // mas há algum problema na impressora para imprimir o cupom fiscal
                            // Nesses casos é só fazer a reimpressão do cupom. 
                        }
                        finally
                        {
                            DirectoryInfo PastaBackup = new DirectoryInfo(Global.PASTA_COMUNICACAO_FRENTE_LOJA_BACKUP);
                            if (PastaBackup.Exists)
                            {
                                file.CopyTo(Global.PASTA_COMUNICACAO_FRENTE_LOJA_BACKUP + file.Name, true);
                            }
                            if (file.Exists)
                            {
                                file.Delete();
                            }
                        }
                    }
                }
            }
            return atualizou;
        }


        /// <summary>
        /// Gera o cupom fiscal a partir das saídas e valores a vista de cada saía
        /// </summary>
        /// <param name="saidaPagamentos"></param>
        private void GerarDocumentoECF(List<tb_solicitacao_saida> listaSolicitacaoSaida, List<tb_solicitacao_pagamento> listaPagamentos)
        {
            try
            {
                List<Saida> saidas = new List<Saida>();
                decimal totalSolicitacaoSaidas = 0;
                foreach (tb_solicitacao_saida solicitacaoSaida in listaSolicitacaoSaida)
                {
                    Saida saida = GerenciadorSaida.GetInstance(null).Obter(solicitacaoSaida.codSaida);
                    if (!string.IsNullOrEmpty(saida.CupomFiscal))
                    {
                        throw new NegocioException("Cupom Fiscal referente a essa pré-venda já foi impresso.");
                    }
                    saidas.Add(saida);
                    totalSolicitacaoSaidas += solicitacaoSaida.valorTotal;
                }

                if (saidas.Count > 0)
                {
                    DirectoryInfo pastaECF = new DirectoryInfo(Global.PASTA_COMUNICACAO_FRENTE_LOJA);

                    if (pastaECF.Exists)
                    {
                        // nome do arquivo é igual ao primeiro da lista
                        String nomeArquivo = Global.PASTA_COMUNICACAO_FRENTE_LOJA + saidas[0].CodSaida + ".txt";
                        StreamWriter arquivo = new StreamWriter(nomeArquivo, false, Encoding.ASCII);

                        // imprime dados do cliente no cupom fiscal
                        if (!saidas[0].CpfCnpj.Trim().Equals(""))
                            arquivo.WriteLine("<CPF>" + saidas[0].CpfCnpj);
                        decimal precoTotalProdutosVendidos = 0;

                        // imprime produtos dos cupons fiscais
                        List<SaidaProduto> listaSaidaProdutos = new List<SaidaProduto>();
                        Pessoa cliente = (Pessoa)GerenciadorPessoa.GetInstance().Obter(saidas[0].CodCliente).ElementAt(0);
                        foreach (Saida saida in saidas)
                        {
                            List<SaidaProduto> saidaProdutos = new List<SaidaProduto>();
                            if (cliente.ImprimirCF)
                                saidaProdutos = GerenciadorSaidaProduto.GetInstance(null).ObterPorSaida(saida.CodSaida);
                            else
                                saidaProdutos = GerenciadorSaidaProduto.GetInstance(null).ObterPorSaidaSemCST(saida.CodSaida, Cst.ST_OUTRAS);

                            decimal totalAVista = listaSolicitacaoSaida.Where(cs => cs.codSaida.Equals(saida.CodSaida)).Sum(cs => cs.valorTotal);
                            if (saidaProdutos.Count > 0)
                            {
                                // associa as saídas ao pedido que foi gerado para emissão do cupom fiscal
                                //GerenciadorSaidaPedido.GetInstance().RemoverPorSaida(saida.CodSaida, saceContext);
                                if (GerenciadorSaidaPedido.GetInstance().ObterPorSaida(saida.CodSaida).Count == 0)
                                {
                                    GerenciadorSaidaPedido.GetInstance().Inserir(new SaidaPedido() { CodSaida = saida.CodSaida, CodPedido = saidas[0].CodSaida, TotalAVista = totalAVista });
                                }
                                else
                                {
                                    GerenciadorSaidaPedido.GetInstance().Atualizar(new SaidaPedido() { CodSaida = saida.CodSaida, CodPedido = saidas[0].CodSaida, TotalAVista = totalAVista });
                                }
                                listaSaidaProdutos.AddRange(saidaProdutos);
                            }
                            else
                            {
                                GerenciadorSaida.GetInstance(null).AtualizarTipoPedidoGeradoPorSaida(Saida.TIPO_VENDA, "", Saida.TIPO_DOCUMENTO_ECF, totalAVista, saida.CodSaida);
                            }
                        }

                        int quantidadeProdutosImpressos = ImprimirProdutosCupomFiscal(arquivo, ref precoTotalProdutosVendidos, listaSaidaProdutos);

                        if (quantidadeProdutosImpressos > 0)
                        {
                            // imprime detalhes do cliente
                            if (!saidas[0].CodCliente.Equals(Global.CLIENTE_PADRAO))
                            {
                                arquivo.WriteLine("<NOME> Cliente: " + saidas[0].NomeCliente);
                                arquivo.WriteLine("<CPF> CPF/CNPJ: " + saidas[0].CpfCnpj);
                            }

                            // imprimir imposto na nota
                            decimal valorImposto = GerenciadorImposto.GetInstance().CalcularValorImpostoProdutos(listaSaidaProdutos).Sum(sp => sp.ValorImposto);
                            decimal valorImpostoPercentual = valorImposto / saidas.Sum(s => s.TotalAVista) * 100;
                            arquivo.WriteLine("<OBS>Val Aprox dos Tributos R$ " + valorImposto.ToString("N2") + " (" + valorImpostoPercentual.ToString("N2") + "%) " + "  Fonte: IBPT");


                            // imprime desconto
                            decimal desconto = (precoTotalProdutosVendidos - listaSolicitacaoSaida.Sum(cs => cs.valorTotal));
                            if (desconto >= 0)
                            {
                                arquivo.WriteLine("<DESCONTO>" + desconto.ToString("N2"));
                            }

                            //arquivo.WriteLine("<OBS> Total de Impostos pagos:" + saida.
                            ImprimirPagamentosCF(listaPagamentos, arquivo);
                            arquivo.Close();
                        }
                        else if (saidas.FirstOrDefault().TipoSaida.Equals(Saida.TIPO_CREDITO))
                        {
                            ImprimirPagamentosCF(listaPagamentos, arquivo);
                            arquivo.Close();
                        }
                        else
                        {
                            arquivo.Close();
                            ExcluirDocumentoFiscal(saidas[0].CodSaida);
                        }

                    }
                }
                //transaction.Commit();
            }
            catch (Exception e)
            {
                //transaction.Rollback();
                if (e is NegocioException)
                {
                    throw e;
                }
                //TODO: definir mecanismo para lançar exceção de processo background
            }
        }

        private static void ImprimirPagamentosCF(List<tb_solicitacao_pagamento> listaPagamentos, StreamWriter arquivo)
        {
            foreach (tb_solicitacao_pagamento pagamento in listaPagamentos)
            {
                if (pagamento.codFormaPagamento != FormaPagamento.CARTAO)
                {
                    arquivo.Write("<PGTO> 01;DINHEIRO;");
                    arquivo.Write(pagamento.valor + ";");
                    arquivo.WriteLine("N;"); //N ou V
                }
                else
                {
                    CartaoCredito cartaoCredito = GerenciadorCartaoCredito.GetInstance().Obter(pagamento.codCartao).ElementAtOrDefault(0);
                    arquivo.Write("<PGTO>" + cartaoCredito.Mapeamento + ";");
                    arquivo.Write(cartaoCredito.Nome + ";");
                    arquivo.Write(pagamento.valor + ";");
                    arquivo.WriteLine("V;"); //N ou V vinculado ao TEF
                }
            }
        }



        private int ImprimirProdutosCupomFiscal(StreamWriter arquivo, ref decimal precoTotalProdutosVendidos, List<SaidaProduto> saidaProdutos)
        {
            int quantidadeProdutosImpressos = 0;
            saidaProdutos = GerenciadorSaida.GetInstance(null).ExcluirProdutosDevolvidosMesmoPreco(saidaProdutos);
            foreach (SaidaProduto saidaProduto in saidaProdutos)
            {
                if ((saidaProduto.Quantidade > 0) && (saidaProduto.ValorVenda > 0))
                {
                    Produto produto = new Produto();
                    produto.CodProduto = saidaProduto.CodProduto;
                    produto.CodCST = saidaProduto.CodCST;
                    String situacaoFiscal = produto.EhTributacaoIntegral ? "01" : "FF";  //01-17%  02-25% 03-27%

                    arquivo.Write(saidaProduto.CodProduto + ";");
                    arquivo.Write(saidaProduto.Nome + ";");
                    arquivo.Write(saidaProduto.Quantidade.ToString() + ";");
                    arquivo.Write(saidaProduto.ValorVenda.ToString() + ";");
                    arquivo.Write(situacaoFiscal + ";");
                    arquivo.Write("0;");
                    arquivo.Write(saidaProduto.ValorVenda.ToString() + ";");
                    arquivo.WriteLine(saidaProduto.Unidade + ";");

                    precoTotalProdutosVendidos += saidaProduto.Subtotal;
                    quantidadeProdutosImpressos++;
                }
            }

            return quantidadeProdutosImpressos;
        }


        public void ExcluirDocumentoFiscal(long codPedido)
        {
            try
            {
                String arquivo = Global.PASTA_COMUNICACAO_FRENTE_LOJA + codPedido + ".txt";

                DirectoryInfo pastaECF = new DirectoryInfo(Global.PASTA_COMUNICACAO_FRENTE_LOJA);
                if (pastaECF.Exists)
                {
                    FileInfo cupomFiscal = new FileInfo(arquivo);

                    if (cupomFiscal.Exists)
                    {
                        cupomFiscal.Delete();
                        GerenciadorSaidaPedido.GetInstance().RemoverPorPedido(codPedido);
                    }
                }
            }
            catch (Exception)
            {
                throw new NegocioException("Não é possível editar essa Pré-Venda. É provável que o Cupom Fiscal esteja sendo impresso.");
            }
        }


        public Boolean AtualizarPedidosComDocumentosECF(string nomeServidor)
        {
            Boolean atualizou = false;
            DirectoryInfo PastaRetorno = new DirectoryInfo(Global.PASTA_COMUNICACAO_FRENTE_LOJA_RETORNO);
            string nomeComputador = System.Windows.Forms.SystemInformation.ComputerName;
            if (nomeComputador.Equals(nomeServidor) && PastaRetorno.Exists)
            {
                // Busca automaticamente todos os arquivos em todos os subdiretórios
                FileInfo[] Files = PastaRetorno.GetFiles("*", SearchOption.TopDirectoryOnly);
                if (Files.Length == 0)
                {
                    atualizou = true;
                }
                else
                {
                    foreach (FileInfo file in Files)
                    {
                        try
                        {

                            bool sucesso = false;
                            String numeroCF = null;
                            String linha = null;
                            StreamReader reader = new StreamReader(file.FullName);

                            // sucesso = true quando cupum fiscal foi impresso
                            if ((linha = reader.ReadLine()) != null)
                            {
                                sucesso = linha.Equals("OK");
                                if (sucesso && ((linha = reader.ReadLine()) != null))
                                {
                                    numeroCF = linha;
                                }
                            }
                            reader.Close();

                            // quando cupom fiscal impresso com sucesso atualiza saidas
                            long codPedido = Convert.ToInt64(file.Name.Replace(".TXT", ""));
                            List<SaidaPedido> _listaSaidaPedido = GerenciadorSaidaPedido.GetInstance().ObterPorPedido(codPedido);
                            if (sucesso)
                            {
                                foreach (SaidaPedido saidaPedido in _listaSaidaPedido)
                                {
                                    GerenciadorSaida.GetInstance(null).AtualizarTipoPedidoGeradoPorSaida(Saida.TIPO_VENDA, numeroCF, Saida.TIPO_DOCUMENTO_ECF, saidaPedido.TotalAVista, saidaPedido.CodSaida);
                                    RemoverSolicitacaoDocumento(saidaPedido.CodSaida);
                                    atualizou = true;
                                }
                            }
                            else
                            {
                                GerenciadorSaidaPedido.GetInstance().TransformarOrcamentoPorRecusaDocumentoFiscal(_listaSaidaPedido.Select(s=>s.CodSaida));
                            }
                            GerenciadorSaidaPedido.GetInstance().RemoverPorPedido(codPedido);
                        }
                        catch (Exception)
                        {
                            // Se houver algum impossibilidade de trasnformar o pedido em pré-venda
                            // não tem problema. Pode acontecer quando cliente quita a conta gerada
                            // mas há algum problema na impressora para imprimir o cupom fiscal
                            // Nesses casos é só fazer a reimpressão do cupom. 
                        }
                        finally
                        {
                            DirectoryInfo PastaBackup = new DirectoryInfo(Global.PASTA_COMUNICACAO_FRENTE_LOJA_BACKUP);
                            if (PastaBackup.Exists)
                            {
                                file.CopyTo(Global.PASTA_COMUNICACAO_FRENTE_LOJA_BACKUP + file.Name, true);
                            }
                            if (file.Exists)
                            {
                                file.Delete();
                            }
                        }
                    }
                }
            }
            return atualizou;
        }

    }
}