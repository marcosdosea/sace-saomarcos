using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Util;


namespace Negocio
{
    public static class GerenciadorSolicitacaoDocumento
    {
        /// <summary>
        /// Insere dados do cupom
        /// </summary>
        /// <param name="cupom"></param>
        /// <returns></returns>
        public static long Inserir(List<SaidaPedido> listaSaidaPedido, List<SaidaPagamento> listaSaidaPagamento, DocumentoFiscal.TipoSolicitacao tipoSolicitacao, bool ehComplementar, bool ehEspelho)
        {
            using (var context = new SaceContext())
            {

                EhPossivelEnviarSolicitacao(listaSaidaPedido, tipoSolicitacao, ehComplementar, context);

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
                        pagamento.Parcelas = (uint)_solicitacaoPagamento.Parcelas;
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
        }

        private static void EhPossivelEnviarSolicitacao(List<SaidaPedido> listaSaidaPedido, DocumentoFiscal.TipoSolicitacao tipoSolicitacao, bool ehComplementar, SaceContext context)
        {
            List<long> listaCodSaidas = listaSaidaPedido.Select(s => s.CodSaida).ToList();

            var solicitacoes = context.TbSolicitacaoSaida.Where(ss => listaCodSaidas.Contains(ss.CodSaida));
            if (solicitacoes.Count() > 0)
                throw new NegocioException("A solicitação já foi enviada. Favor aguardar processamento.");
            // Verifica se cupom fiscal já foi emitido em algumas das saidas

            if (listaSaidaPedido.Count > 1)
            {
                List<SaidaPesquisa> listaSaidas = GerenciadorSaida.ObterPorCodSaidas(listaSaidaPedido.Select(s => s.CodSaida).ToList());
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
                    IEnumerable<NfeControle> nfeControles = GerenciadorNFe.ObterPorSaida(codSaida);

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
        public static void Remover(long codSaida, SaceContext context)
        {
            try
            {
                var query = from solicitacaoSaida in context.TbSolicitacaoSaida
                            where solicitacaoSaida.CodSaida == codSaida
                            select new
                            {
                                CodSolicitacao = solicitacaoSaida.CodSolicitacao,
                                EmProcessamento = solicitacaoSaida.CodSolicitacaoNavigation.EmProcessamento
                            };
                var solicitacaoSaidaProcessamento = query.FirstOrDefault();
                if (solicitacaoSaidaProcessamento != null)
                {
                    if (solicitacaoSaidaProcessamento.EmProcessamento)
                    {
                        throw new NegocioException("Não é possível editar/remover esse pedido. Documento sendo autorizado/impresso. Favor aguardar até a conclusão do processamento.");
                    }
                    var solicitacaoDocumento = new TbSolicitacaoDocumento() { CodSolicitacao = solicitacaoSaidaProcessamento.CodSolicitacao };
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
        public static SolicitacaoDocumento ObterSolicitacaoDocumento(long codSolicitacao)
        {
            using (var context = new SaceContext())
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
        }


        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private static IQueryable<SolicitacaoSaida> ObterSolicitacaoSaida(long codSolicitacao)
        {
            using (var context = new SaceContext())
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
        }

        /// <summary>
        /// Obtém lista de cupons emitidos
        /// </summary>
        /// <returns></returns>
        public static List<DocumentoFiscal> ObterDocumentosFiscais()
        {
            using (var context = new SaceContext())
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
        }

        /// <summary>
        /// Atualiza dados do cupom
        /// </summary>
        /// <param name="cupom"></param>
        public static void EnviarProximoNF(string servidor, DocumentoFiscal.TipoSolicitacao tipoDocumento)
        {
            using (var context = new SaceContext())
            {
                try
                {
                    string nomeComputador = SystemInformation.ComputerName;
                    var query = from solicitacaoDocumento in context.TbSolicitacaoDocumentos
                                where solicitacaoDocumento.TipoSolicitacao.Equals(tipoDocumento.ToString())
                                    && !solicitacaoDocumento.EmProcessamento
                                orderby solicitacaoDocumento.DataSolicitacao
                                select new SolicitacaoDocumento
                                {
                                    CartaoAutorizado = solicitacaoDocumento.CartaoAutorizado,
                                    CartaoProcessado = solicitacaoDocumento.CartaoProcessado,
                                    CodMotivoCartaoNegado = solicitacaoDocumento.CodMotivoCartaoNegado,
                                    CodSolicitacao = solicitacaoDocumento.CodSolicitacao,
                                    DataSolicitacao = solicitacaoDocumento.DataSolicitacao,
                                    EhComplementar = solicitacaoDocumento.EhComplementar,
                                    EhEspelho = solicitacaoDocumento.EhEspelho,
                                    EmProcessamento = solicitacaoDocumento.EmProcessamento,
                                    HaPagamentoCartao = solicitacaoDocumento.HaPagamentoCartao,
                                    HostSolicitante = solicitacaoDocumento.HostSolicitante,
                                    MotivoCartaoNegado = solicitacaoDocumento.MotivoCartaoNegado,
                                    NfeProcessada = solicitacaoDocumento.NfeProcessada,
                                    TipoSolicitacao = solicitacaoDocumento.TipoSolicitacao
                                };
                    var _solicitacaoDocumento = query.FirstOrDefault();
                    if (_solicitacaoDocumento != null)
                    {
                        var query2 = from solicitacaoSaida in context.TbSolicitacaoSaida
                                     where solicitacaoSaida.CodSolicitacao == _solicitacaoDocumento.CodSolicitacao
                                     select new SolicitacaoSaida
                                     {
                                         CodSaida = solicitacaoSaida.CodSaida,
                                         CodSolicitacao = solicitacaoSaida.CodSolicitacao,
                                         ValorTotal = solicitacaoSaida.ValorTotal,
                                         CodLojaOrigem = solicitacaoSaida.CodSaidaNavigation.CodLojaOrigem

                                     };

                        var listaSolicitacaoSaida = query2.ToList();
                        if (listaSolicitacaoSaida.Count > 0)
                        {
                            int codLoja = listaSolicitacaoSaida.FirstOrDefault().CodLojaOrigem;
                            var query3 = from solicitacaoPagamento in context.TbSolicitacaoPagamentos
                                         where solicitacaoPagamento.CodSolicitacao == _solicitacaoDocumento.CodSolicitacao
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
                            var listaSolicitacaoPagamentos = query3.AsNoTracking().ToList();

                            context.Remove(new TbSolicitacaoDocumento() { CodSolicitacao = _solicitacaoDocumento.CodSolicitacao });
                            context.SaveChanges();
                            GerenciadorNFe.EnviarNFE(listaSolicitacaoSaida, listaSolicitacaoPagamentos, tipoDocumento, _solicitacaoDocumento);

                        }
                        else
                        {
                            context.Remove(new TbSolicitacaoDocumento() { CodSolicitacao = _solicitacaoDocumento.CodSolicitacao });
                            context.SaveChanges();
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new DadosException("Cupom", e.Message, e);
                }
            }
        }
    }
}