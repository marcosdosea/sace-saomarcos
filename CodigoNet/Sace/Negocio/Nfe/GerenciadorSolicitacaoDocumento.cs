using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Util;


namespace Negocio
{
    public class GerenciadorSolicitacaoDocumento
    {
        private readonly SaceContext context;
        private readonly GerenciadorSaida gerenciadorSaida;
        private readonly GerenciadorNFe gerenciadorNFe;

        public GerenciadorSolicitacaoDocumento(SaceContext saceContext)
        {
            context = saceContext;
        }

        /// <summary>
        /// Insere dados do cupom
        /// </summary>
        /// <param name="cupom"></param>
        /// <returns></returns>
        public long Inserir(List<SaidaPedido> listaSaidaPedido, List<SaidaPagamento> listaSaidaPagamento, DocumentoFiscal.TipoSolicitacao tipoSolicitacao, bool ehComplementar, bool ehEspelho)
        {

            EhPossivelEnviarSolicitacao(listaSaidaPedido, tipoSolicitacao, ehComplementar);

            var _solicitacao_documento = new TbSolicitacaoDocumento();
            try
            {
                context.Database.BeginTransaction();
                _solicitacao_documento.DataSolicitacao = DateTime.Now;
                _solicitacao_documento.HaPagamentoCartao = listaSaidaPagamento.Where(sp => sp.CodFormaPagamento.Equals(FormaPagamento.CARTAO)).Count() > 0;
                _solicitacao_documento.CartaoProcessado = false;
                _solicitacao_documento.CartaoAutorizado = false;
                _solicitacao_documento.EhComplementar = ehComplementar;
                _solicitacao_documento.EhEspelho = ehEspelho;
                _solicitacao_documento.MotivoCartaoNegado = "";
                _solicitacao_documento.TipoSolicitacao = tipoSolicitacao.ToString();
                _solicitacao_documento.HostSolicitante = SystemInformation.ComputerName;
                context.Add(_solicitacao_documento);

                context.SaveChanges();

                foreach (SaidaPedido _saidaPedido in listaSaidaPedido)
                {
                    var _solicitacao_saida = new TbSolicitacaoSaidum();
                    _solicitacao_saida.CodSaida = _saidaPedido.CodSaida;
                    _solicitacao_saida.CodSolicitacao = _solicitacao_documento.CodSolicitacao;
                    _solicitacao_saida.ValorTotal = _saidaPedido.TotalAVista;
                    context.Add(_solicitacao_saida);
                }
                context.SaveChanges();

                foreach (SaidaPagamento _solicitacaoPagamento in listaSaidaPagamento)
                {

                    var pagamento = new TbSolicitacaoPagamento();
                    pagamento.CodCartao = _solicitacaoPagamento.CodCartaoCredito;
                    pagamento.CodFormaPagamento = _solicitacaoPagamento.CodFormaPagamento;
                    pagamento.Parcelas = _solicitacaoPagamento.Parcelas;
                    pagamento.Valor = _solicitacaoPagamento.Valor;
                    pagamento.CodSolicitacao = _solicitacao_documento.CodSolicitacao;
                    pagamento.CupomCliente = "";
                    pagamento.CupomEstabelecimento = "";
                    pagamento.CupomReduzido = "";
                    context.Add(pagamento);
                }
                context.SaveChanges();
                context.Database.CommitTransaction();
                return _solicitacao_documento.CodSolicitacao;
            }
            catch (Exception e)
            {
                context.Database.RollbackTransaction();
                throw new DadosException("Cupom", e.Message, e);
            }


        }

        private void EhPossivelEnviarSolicitacao(List<SaidaPedido> listaSaidaPedido, DocumentoFiscal.TipoSolicitacao tipoSolicitacao, bool ehComplementar)
        {
            List<long> listaCodSaidas = listaSaidaPedido.Select(s => s.CodSaida).ToList();

            var solicitacoes = context.TbSolicitacaoSaida.Where(ss => listaCodSaidas.Contains(ss.CodSaida));
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
                foreach (long codSaida in listaCodSaidas)
                {
                    // Verifica se existem notas emitidas
                    IEnumerable<NfeControle> nfeControles = gerenciadorNFe.ObterPorSaida(codSaida);

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

       
        /// <summary>
        /// Remove dados do cupom
        /// </summary>
        /// <param name="codCupom"></param>
        public void Remover(long codSaida)
        {
            try
            {
                var query = from solicitacaoSaida in context.TbSolicitacaoSaida
                            where solicitacaoSaida.CodSaida == codSaida
                            select solicitacaoSaida;
                var solicitacao_saida = query.ToList().FirstOrDefault();
                if (solicitacao_saida != null)
                {
                    if (solicitacao_saida.CodSolicitacaoNavigation.EmProcessamento)
                    {
                        throw new NegocioException("Não é possível editar/remover esse pedido. Documento sendo autorizado/impresso. Favor aguardar até a conclusão do processamento.");
                    }
                    var solicitacaoDocumento = new TbSolicitacaoDocumento() { CodSolicitacao = solicitacao_saida.CodSolicitacao };
                    context.Remove(solicitacaoDocumento);
                    context.SaveChanges();
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
        public SolicitacaoDocumento ObterSolicitacaoDocumento(long codSolicitacao)
        {
            var query = from documento in context.TbSolicitacaoDocumentos
                        where documento.CodSolicitacao == codSolicitacao
                        select new SolicitacaoDocumento
                        {
                            CartaoAutorizado = documento.CartaoAutorizado,
                            CartaoProcessado = documento.CartaoProcessado,
                            CodMotivoCartaoNegado = documento.CodMotivoCartaoNegado,
                            CodSolicitacao = documento.CodSolicitacao,
                            DataSolicitacao = documento.DataSolicitacao,
                            EhComplementar = documento.EhComplementar,
                            EhEspelho = documento.EhEspelho,
                            EmProcessamento = documento.EmProcessamento,
                            HaPagamentoCartao = documento.HaPagamentoCartao,
                            HostSolicitante = documento.HostSolicitante,
                            MotivoCartaoNegado = documento.MotivoCartaoNegado,
                            NfeProcessada = documento.NfeProcessada,
                            TipoSolicitacao = documento.TipoSolicitacao    
                        };
            return query.FirstOrDefault();
        }


        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<SolicitacaoSaida> ObterSolicitacaoSaida(long codSolicitacao)
        {
            var query = from solicitacao_saida in context.TbSolicitacaoSaida
                        where solicitacao_saida.CodSolicitacao == codSolicitacao
                        select new SolicitacaoSaida
                        {
                            CodSaida = solicitacao_saida.CodSaida,
                            CodSolicitacao = solicitacao_saida.CodSolicitacao,
                            ValorTotal = solicitacao_saida.ValorTotal
                        };
            return query.AsNoTracking();
        }

        /// <summary>
        /// Obtém lista de cupons emitidos
        /// </summary>
        /// <returns></returns>
        public List<DocumentoFiscal> ObterDocumentosFiscais()
        {
            var query = from saida in context.TbSaida
                        where !saida.PedidoGerado.Trim().Equals("")
                        orderby saida.PedidoGerado
                        select new DocumentoFiscal
                        {
                            CodCliente = saida.CodCliente,
                            CodSaida = saida.CodSaida,
                            NumeroCupomFiscal = saida.PedidoGerado,
                            DataEmissaoCupomFiscal = (DateTime)saida.DataEmissaoDocFiscal,
                            NomeCliente = saida.CodClienteNavigation.Nome
                        };
            return query.AsNoTracking().ToList();
        }

        /// <summary>
        /// Atualiza dados do cupom
        /// </summary>
        /// <param name="cupom"></param>
        public void EnviarProximoNFe(string servidor)
        {
            try
            {
                string nomeComputador = SystemInformation.ComputerName;
                
                List<TbSolicitacaoDocumento> solicitacoes = context.TbSolicitacaoDocumentos.Where(C =>
                    C.TipoSolicitacao.Equals(DocumentoFiscal.TipoSolicitacao.NFE.ToString())).OrderBy(s => s.DataSolicitacao).ToList();

                if (solicitacoes.Any())
                {
                    var solicitacaoDocumento = solicitacoes.FirstOrDefault();
                    var listaSolicitacaoSaida = solicitacaoDocumento.TbSolicitacaoSaida.ToList();
                    if (listaSolicitacaoSaida.Count > 0)
                    {
                        int codLoja = listaSolicitacaoSaida.FirstOrDefault().CodSaidaNavigation.CodLojaOrigem;
                        if (codLoja.Equals(UtilConfig.Default.LOJA_PADRAO) || nomeComputador.Equals(servidor))
                        {
                            var query = from solicitacaoPagamento in context.TbSolicitacaoPagamentos
                                        where solicitacaoPagamento.CodSolicitacao == solicitacaoDocumento.CodSolicitacao
                                        select new SolicitacaoPagamento
                                        {
                                            CodCartao = solicitacaoPagamento.CodCartao,
                                            CodFormaPagamento = solicitacaoPagamento.CodFormaPagamento,
                                            CodSolicitacao = solicitacaoPagamento.CodSolicitacao,
                                            CodSolicitacaoPagamento = solicitacaoPagamento.CodSolicitacaoPagamento,
                                            CupomCliente = solicitacaoPagamento.CupomCliente,
                                            CupomEstabelecimento = solicitacaoPagamento.CupomEstabelecimento,
                                            CupomReduzido = solicitacaoPagamento.CupomReduzido,
                                            Parcelas = solicitacaoPagamento.Parcelas,
                                            Valor = solicitacaoPagamento.Valor
                                        };
                            var listaSolicitacaoPagamentos = query.AsNoTracking().ToList();

                            context.Remove(solicitacaoDocumento);
                            context.SaveChanges();
                            var solicitacaoDocumentoE = new SolicitacaoDocumento();
                            
                            gerenciadorNFe.EnviarNFE(listaSolicitacaoSaida, listaSolicitacaoPagamentos, DocumentoFiscal.TipoSolicitacao.NFE, solicitacaoE);
                        }
                    }
                    else
                    {
                        context.Remove(solicitacaoDocumento);
                        context.SaveChanges();
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
                var querySolicitacoesNFCE = context.TbSolicitacaoDocumentos.Where(s => s.TipoSolicitacao.Equals(DocumentoFiscal.TipoSolicitacao.NFCE.ToString()) && !s.EmProcessamento);

                var solicitacoes = querySolicitacoesNFCE.ToList();

                if (solicitacoes.Any())
                {
                    var solicitacaoE = solicitacoes.FirstOrDefault();
                    var listaSolicitacaoSaida = solicitacaoE.TbSolicitacaoSaida.ToList();
                    var listaSolicitacaoPagamentos = solicitacaoE.TbSolicitacaoPagamentos.ToList();


                    context.Remove(new TbSolicitacaoDocumento() { CodSolicitacao = solicitacaoE.codSolicitacao });
                    context.SaveChanges();
                    gerenciadorNFe.EnviarNFE(listaSolicitacaoSaida, listaSolicitacaoPagamentos, DocumentoFiscal.TipoSolicitacao.NFCE, solicitacaoE);
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Cupom", e.Message, e);
            }
        }
    }
}