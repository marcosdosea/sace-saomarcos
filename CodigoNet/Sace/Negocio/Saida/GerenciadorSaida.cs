using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using Util;
using Vip.Printer;
using Vip.Printer.Enums;

namespace Negocio
{
    public class GerenciadorSaida
    {
        private readonly SaceContext context;

        private readonly GerenciadorNFe gerenciadorNFe;
        private readonly GerenciadorLoja gerenciadorLoja;
        private readonly GerenciadorConta gerenciadorConta;
        private readonly GerenciadorProduto gerenciadorProduto;
        private readonly GerenciadorPessoa gerenciadorPessoa;
        private readonly GerenciadorCartaoCredito gerenciadorCartaoCredito;
        private readonly GerenciadorSaidaPagamento gerenciadorSaidaPagamento;
        private readonly GerenciadorSaidaProduto gerenciadorSaidaProduto;
        private readonly GerenciadorEntradaProduto gerenciadorEntradaProduto;
        private readonly GerenciadorProdutoLoja gerenciadorProdutoLoja;
        private readonly GerenciadorMovimentacaoConta gerenciadorMovimentacaoConta;
        private readonly GerenciadorSolicitacaoDocumento gerenciadorSolicitacaoDocumento;
        private readonly GerenciadorImprimirDocumento gerenciadorImprimirDocumento;

        public GerenciadorSaida(SaceContext saceContext)
        {
            context = saceContext;
            gerenciadorNFe = new GerenciadorNFe(context);
            gerenciadorConta = new GerenciadorConta(context);
            gerenciadorLoja = new GerenciadorLoja(context);
            gerenciadorPessoa = new GerenciadorPessoa(context);
            gerenciadorCartaoCredito = new GerenciadorCartaoCredito(context);
            gerenciadorSaidaPagamento = new GerenciadorSaidaPagamento(context);
            gerenciadorSaidaProduto = new GerenciadorSaidaProduto(context);
            gerenciadorEntradaProduto = new GerenciadorEntradaProduto(context); 
            gerenciadorProdutoLoja = new GerenciadorProdutoLoja(context);
            gerenciadorProduto = new GerenciadorProduto(context);
            gerenciadorMovimentacaoConta = new GerenciadorMovimentacaoConta(context);
            gerenciadorSolicitacaoDocumento = new GerenciadorSolicitacaoDocumento(context);
            gerenciadorImprimirDocumento = new GerenciadorImprimirDocumento(context);
        }

        /// <summary>
        /// Insere dados de uma saída (orçamento/pré-venda/venda/saída depósito)
        /// </summary>
        /// <param name="saida"></param>
        /// <returns></returns>
        public long Inserir(Saida saida)
        {
            try
            {
                var _saida = new TbSaidum();
                Atribuir(saida, _saida);

                context.Add(_saida);
                context.SaveChanges();

                return _saida.CodSaida;
            }
            catch (Exception e)
            {
                throw new DadosException("Saída", e.Message, e);
            }
        }


        /// <summary>
        /// Atualiza dados de uma saída (orçamento/pré-venda/venda/saída depósito)
        /// </summary>
        /// <param name="saida"></param>
        public void Atualizar(Saida saida)
        {
            try
            {
                var _saida = new TbSaidum() { CodSaida = saida.CodSaida };
                _saida = context.TbSaida.Find(_saida);

                if (_saida != null)
                {
                    Atribuir(saida, _saida);
                    context.SaveChanges();
                }
                else
                {
                    throw new NegocioException("Não foi possível atualizar a saída");
                }

                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Saída", e.Message, e);
            }
        }

        /// <summary>
        /// Atualizar situação pagamentos de uma saída
        /// </summary>
        /// <param name="codSituacaoPagamentos"></param>
        /// <param name="codSaida"></param>
        public void AtualizarSituacaoPagamentoPorSaida(int codSituacaoPagamentos, long codSaida)
        {
            try
            {
                var query = from saidaE in context.TbSaida
                            where saidaE.CodSaida == codSaida
                            select saidaE;

                foreach (TbSaidum _saida in query)
                {
                    _saida.CodSituacaoPagamentos = codSituacaoPagamentos;
                }

                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Saida", e.Message, e);
            }
        }

        /// <summary>
        /// Atualiza o número da nota fiscal gerada a partir do pedido (cupom fiscal) gerado
        /// </summary>
        /// <param name="nfe"></param>
        /// <param name="pedidoGerado"></param>
        public void AtualizarPorPedido(string nfe, string observacao, long codCliente, string pedidoGerado)
        {
            try
            {
                var query = from saidaE in context.TbSaida
                            where saidaE.PedidoGerado.Equals(pedidoGerado)
                            select saidaE;
                foreach (TbSaidum _saida in query)
                {
                    _saida.Nfe = nfe;
                    _saida.Observacao = observacao;
                    _saida.CodCliente = codCliente;
                }
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Saida", e.Message, e);
            }
        }

        /// <summary>
        /// Mudar o tipo do documento fiscal a ser gerado
        /// </summary>
        /// <param name="codSaida"></param>
        /// <param name="tipoDocumento"></param>
        public void AtualizarTipoDocumentoFiscal(long codSaida, string tipoDocumento)
        {
            try
            {
                var query = from saidaE in context.TbSaida
                            where saidaE.CodSaida.Equals(codSaida)
                            select saidaE;
                foreach (TbSaidum _saida in query)
                {
                    _saida.TipoDocumentoFiscal = tipoDocumento;
                }
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Saida", e.Message, e);
            }
        }

        /// <summary>
        /// Atualiza o número da nota fiscal gerada num determinado codigo saida
        /// </summary>
        /// <param name="nfe"></param>
        /// <param name="pedidoGerado"></param>
        public void AtualizarSaidasPorNfeSituacao(NfeControle nfeControle)
        {
            try
            {
                var query = from nfe in context.TbNves
                            where nfe.CodNfe == nfeControle.CodNfe
                            select nfe;
                List<TbNfe> listaNfes = query.ToList();

                if (listaNfes.Count() > 0)
                {
                    TbNfe nfe = listaNfes.FirstOrDefault();
                    List<TbSaidum> saidas = nfe.CodSaida.ToList();
                    foreach (TbSaidum saida in saidas)
                    {
                        if (nfeControle.SituacaoNfe.Equals(NfeControle.SITUACAO_AUTORIZADA))
                        {
                            if (nfeControle.Modelo.Equals(NfeControle.MODELO_NFCE))
                            {
                                saida.Nfe = "NFCe";
                                saida.PedidoGerado = "C" + nfe.NumeroSequenciaNfe;
                                if (saida.CodTipoSaida.Equals(Saida.TIPO_PRE_VENDA))
                                    saida.CodTipoSaida = Saida.TIPO_VENDA;
                            }
                            else
                            {
                                saida.Nfe = "NFe";
                                saida.PedidoGerado = "N" + nfe.NumeroSequenciaNfe;
                                if (saida.CodTipoSaida.Equals(Saida.TIPO_PRE_VENDA))
                                    saida.CodTipoSaida = Saida.TIPO_VENDA;
                            }
                        }
                        else
                        {
                            if (!saida.CodTipoSaida.Equals(Saida.TIPO_DEVOLUCAO_CONSUMIDOR) && !saida.CodTipoSaida.Equals(Saida.TIPO_DEVOLUCAO_FORNECEDOR))
                                saida.Nfe = "";
                            saida.PedidoGerado = "";
                            if (saida.CodTipoSaida.Equals(Saida.TIPO_VENDA))
                                saida.CodTipoSaida = Saida.TIPO_PRE_VENDA;
                        }

                    }
                }
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Saida", e.Message, e);
            }
        }


        /// <summary>
        /// Atualiza o número da nota fiscal gerada num determinado codigo saida
        /// </summary>
        /// <param name="nfe"></param>
        /// <param name="pedidoGerado"></param>
        public void AtualizarNfePorCodSaida(string nfe, string observacao, long codSaida)
        {
            try
            {
                var query = from saidaE in context.TbSaida
                            where saidaE.CodSaida == codSaida
                            select saidaE;
                foreach (TbSaidum _saida in query)
                {
                    _saida.Nfe = nfe;
                    _saida.Observacao = observacao;
                }
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Saida", e.Message, e);
            }
        }


        /// <summary>
        /// Remove os dados de uma saída. No caso de vendas e pré-vendas transforma em orçamento.
        /// </summary>
        /// <param name="saida"></param>
        public void Remover(Saida saida)
        {
            try
            {
                context.Database.BeginTransaction();

                List<NfeControle> listaNfeControle = gerenciadorNFe.ObterPorSaida(saida.CodSaida).ToList();
                if (listaNfeControle.Where(nfe => nfe.SituacaoNfe.Equals(NfeControle.SITUACAO_AUTORIZADA)).Count() > 0)
                    throw new NegocioException("Não é possível remover saídas / devoluções com NF-e AUTORIZADAS pelo sistema");

                if ((listaNfeControle.Count() > 0) && (saida.TipoSaida.Equals(Saida.TIPO_ORCAMENTO)))
                    throw new NegocioException("Não é possível remover pedidos com NF-e associadas");


                gerenciadorSaidaPagamento.RemoverPorSaida(saida);

                if (saida.TipoSaida.Equals(Saida.TIPO_CREDITO))
                {
                    List<Conta> listaContas = gerenciadorConta.ObterPorSaida(saida.CodSaida).ToList();
                    gerenciadorSolicitacaoDocumento.Remover(saida.CodSaida);
                    foreach (Conta conta in listaContas)
                    {
                        gerenciadorConta.Remover(conta.CodConta);
                    }
                }

                if (saida.TipoSaida.Equals(Saida.TIPO_ORCAMENTO) || saida.TipoSaida.Equals(Saida.TIPO_PRE_DEVOLUCAO_FORNECEDOR) ||
                    saida.TipoSaida.Equals(Saida.TIPO_PRE_DEVOLUCAO_CONSUMIDOR) || saida.TipoSaida.Equals(Saida.TIPO_PRE_REMESSA_DEPOSITO) ||
                    saida.TipoSaida.Equals(Saida.TIPO_PRE_RETORNO_DEPOSITO) || saida.TipoSaida.Equals(Saida.TIPO_PRE_CREDITO))
                {
                    var query = from saidaE in context.TbSaida
                                where saidaE.CodSaida == saida.CodSaida
                                select saidaE;
                    TbSaidum _saida = query.FirstOrDefault();
                    if (_saida != null)
                        context.Remove(_saida);
                    context.SaveChanges();
                }
                else if (saida.TipoSaida.Equals(Saida.TIPO_REMESSA_DEPOSITO) || saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_FORNECEDOR)
                    || saida.TipoSaida.Equals(Saida.TIPO_RETORNO_DEPOSITO) || saida.TipoSaida.Equals(Saida.TIPO_REMESSA_CONSERTO))
                {
                    RegistrarEstornoEstoque(saida, null);
                    var query = from saidaE in context.TbSaida
                                where saidaE.CodSaida == saida.CodSaida
                                select saidaE;
                    var _saida = query.FirstOrDefault();
                    if (_saida != null)
                        context.Remove(_saida);
                    context.SaveChanges();
                }
                else if (saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_CONSUMIDOR))
                {
                    List<SaidaProduto> saidaProdutos = gerenciadorSaidaProduto.ObterPorSaida(saida.CodSaida);
                    RegistrarBaixaEstoque(saidaProdutos);
                    var query = from saidaE in context.TbSaida
                                where saidaE.CodSaida == saida.CodSaida
                                select saidaE;
                    var _saida = query.FirstOrDefault();
                    if (_saida != null)
                    {
                        context.Remove(_saida);
                    }
                    context.SaveChanges();
                }
                else if (saida.TipoSaida.Equals(Saida.TIPO_PRE_VENDA) || saida.TipoSaida.Equals(Saida.TIPO_VENDA))
                {
                    gerenciadorSolicitacaoDocumento.Remover(saida.CodSaida);
                    RegistrarEstornoEstoque(saida, null);
                    saida.TipoSaida = Saida.TIPO_ORCAMENTO;
                    saida.CupomFiscal = "";
                    Atualizar(saida);
                }
                context.Database.CommitTransaction();
            }
            catch (Exception e)
            {
                context.Database.RollbackTransaction();
                throw new DadosException("Saída", e.Message, e);
            }
        }



        /// <summary>
        /// Verifica se é possível editar um saída e caso possível tranforma-a em um orçamento
        /// </summary>
        /// <param name="saida"></param>
        public void PrepararEdicaoSaida(Saida saida)
        {
            try
            {
                if (saida.TipoSaida == Saida.TIPO_CREDITO)
                    throw new NegocioException("Não é possível editar créditos. Se necessário, exclua o crédito e lançe um novo.");

                if (saida.TipoSaida == Saida.TIPO_VENDA)
                    throw new NegocioException("Não é possível editar uma saída cujo Comprovante Fiscal já foi emitido.");


                bool possuiNfeAutorizada = gerenciadorNFe.ObterPorSaida(saida.CodSaida).Where(nfe => nfe.SituacaoNfe.Equals(NfeControle.SITUACAO_AUTORIZADA)).Count() > 0;
                if ((saida.TipoSaida == Saida.TIPO_BAIXA_ESTOQUE_PERDA) && (possuiNfeAutorizada))
                    throw new NegocioException("Não é possível editar Baixa de Estoque cuja Nota Fiscal já foi emitida e autorizada.");
                if ((saida.TipoSaida == Saida.TIPO_USO_INTERNO) && (possuiNfeAutorizada))
                    throw new NegocioException("Não é possível editar Uso Interno cuja Nota Fiscal já foi emitida e autorizada.");
                if ((saida.TipoSaida == Saida.TIPO_REMESSA_DEPOSITO) && (possuiNfeAutorizada))
                    throw new NegocioException("Não é possível editar Transferência para Depósito cuja Nota Fiscal já foi emitida e autorizada.");
                if ((saida.TipoSaida == Saida.TIPO_RETORNO_DEPOSITO) && (possuiNfeAutorizada))
                    throw new NegocioException("Não é possível editar um retorno de Depósito cuja Nota Fiscal já foi emitida e autorizada.");
                else if ((saida.TipoSaida == Saida.TIPO_DEVOLUCAO_FORNECEDOR) && (possuiNfeAutorizada))
                    throw new NegocioException("Não é possível editar uma Devolução para Fornecedor cuja Nota Fiscal já foi emitida e autorizada.");
                else if ((saida.TipoSaida == Saida.TIPO_PRE_VENDA) && (saida.CodCliente != UtilConfig.Default.CLIENTE_PADRAO))
                {
                    IEnumerable<SaidaPagamento> pagamentos = gerenciadorSaidaPagamento.ObterPorSaida(saida.CodSaida);
                    // houve pagamento não realizado em dinheiro
                    if (pagamentos.Where(p => p.CodFormaPagamento.Equals(FormaPagamento.DINHEIRO)).Count() != pagamentos.Count())
                    {
                        IEnumerable<Conta> contas = gerenciadorConta.ObterPorSaida(saida.CodSaida);
                        foreach (Conta conta in contas)
                        {
                            bool possuiMovimentacaoFinanceira = gerenciadorMovimentacaoConta.ObterPorConta(conta.CodConta).Count() > 0;
                            if (possuiMovimentacaoFinanceira)
                                throw new NegocioException("Não é possível editar pedidos que já possuem PAGAMENTOS REALIZADOS.");
                        }
                    }
                }
                // Se houver documento fiscal aguardando impressão
                if (saida.TipoSaida == Saida.TIPO_PRE_VENDA)
                {
                    gerenciadorSolicitacaoDocumento.Remover(saida.CodSaida);
                }

                gerenciadorSaidaPagamento.RemoverPorSaida(saida);
                if (saida.TipoSaida.Equals(Saida.TIPO_PRE_VENDA) || saida.TipoSaida.Equals(Saida.TIPO_REMESSA_DEPOSITO) ||
                    saida.TipoSaida.Equals(Saida.TIPO_RETORNO_DEPOSITO) || saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_FORNECEDOR) ||
                    saida.TipoSaida.Equals(Saida.TIPO_BAIXA_ESTOQUE_PERDA) || saida.TipoSaida.Equals(Saida.TIPO_USO_INTERNO) ||
                    saida.TipoSaida.Equals(Saida.TIPO_RETORNO_FORNECEDOR))
                {
                    RegistrarEstornoEstoque(saida, null);
                }
                if (saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_CONSUMIDOR))
                {
                    List<SaidaProduto> saidaProdutos = gerenciadorSaidaProduto.ObterPorSaida(saida.CodSaida);
                    RegistrarBaixaEstoque(saidaProdutos);
                }
                if (saida.TipoSaida.Equals(Saida.TIPO_PRE_VENDA) || saida.TipoSaida.Equals(Saida.TIPO_VENDA) ||
                    saida.TipoSaida.Equals(Saida.TIPO_BAIXA_ESTOQUE_PERDA) || saida.TipoSaida.Equals(Saida.TIPO_USO_INTERNO))
                    saida.TipoSaida = Saida.TIPO_ORCAMENTO;
                else if (saida.TipoSaida.Equals(Saida.TIPO_REMESSA_DEPOSITO))
                    saida.TipoSaida = Saida.TIPO_PRE_REMESSA_DEPOSITO;
                else if (saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_FORNECEDOR))
                    saida.TipoSaida = Saida.TIPO_PRE_DEVOLUCAO_FORNECEDOR;
                else if (saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_CONSUMIDOR))
                    saida.TipoSaida = Saida.TIPO_PRE_DEVOLUCAO_CONSUMIDOR;
                else if (saida.TipoSaida.Equals(Saida.TIPO_RETORNO_DEPOSITO))
                    saida.TipoSaida = Saida.TIPO_PRE_RETORNO_DEPOSITO;
                else if (saida.TipoSaida.Equals(Saida.TIPO_RETORNO_FORNECEDOR))
                    saida.TipoSaida = Saida.TIPO_PRE_RETORNO_FORNECEDOR;
                saida.CodSituacaoPagamentos = SituacaoPagamentos.ABERTA;
                saida.CupomFiscal = "";
                saida.TotalPago = 0;
                Atualizar(saida);
            }
            catch (Exception e)
            {
                throw new DadosException("Saída", e.Message, e);
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<Saida> GetQuery()
        {
            var query = from saida in context.TbSaida
                        select new Saida
                        {
                            BaseCalculoICMS = (decimal)saida.BaseCalculoIcms,
                            BaseCalculoICMSSubst = (decimal)saida.BaseCalculoIcmssubst,
                            CodCliente = saida.CodCliente,
                            CodEmpresaFrete = saida.CodEmpresaFrete,
                            CodProfissional = (long)saida.CodProfissional,
                            CodEntrada = saida.CodEntrada,
                            CodSituacaoPagamentos = saida.CodSituacaoPagamentos,
                            CodSaida = saida.CodSaida,
                            CpfCnpj = saida.CpfCnpj,
                            DataSaida = saida.DataSaida,
                            Desconto = (decimal)saida.Desconto,
                            DescricaoSituacaoPagamentos = saida.CodSituacaoPagamentosNavigation.DescricaoSituacaoPagamentos,
                            DescricaoTipoSaida = saida.CodTipoSaidaNavigation.DescricaoTipoSaida,
                            EntregaRealizada = (bool)saida.EntregaRealizada,
                            EspecieVolumes = saida.EspecieVolumes,
                            Marca = saida.Marca,
                            Nfe = saida.Nfe == null ? "" : saida.Nfe,
                            NomeCliente = saida.CodClienteNavigation.NomeFantasia,// cliente.nomeFantasia,
                            LoginVendedor = saida.CodProfissionalNavigation.TbUsuario.Login,
                            Numero = (decimal)saida.Numero,
                            NumeroCartaoVenda = (int)saida.NumeroCartaoVenda,
                            OutrasDespesas = (decimal)saida.OutrasDespesas,
                            Observacao = saida.Observacao,
                            CupomFiscal = saida.PedidoGerado == null ? "" : saida.PedidoGerado,
                            DataEmissaoCupomFiscal = saida.DataEmissaoDocFiscal == null ? saida.DataSaida : (DateTime)saida.DataEmissaoDocFiscal,
                            PesoBruto = (decimal)saida.PesoBruto,
                            PesoLiquido = (decimal)saida.PesoLiquido,
                            QuantidadeVolumes = (decimal)saida.QuantidadeVolumes,
                            TipoSaida = saida.CodTipoSaida,
                            Total = (decimal)saida.Total,
                            TotalAVista = (decimal)saida.TotalAvista,
                            TotalLucro = (decimal)saida.TotalLucro,
                            TotalNotaFiscal = (decimal)saida.TotalNotaFiscal,
                            TotalPago = (decimal)saida.TotalPago,
                            Troco = (decimal)saida.Troco,
                            ValorFrete = (decimal)saida.ValorFrete,
                            ValorICMS = (decimal)saida.ValorIcms,
                            ValorICMSSubst = (decimal)saida.ValorIcmssubst,
                            ValorIPI = (decimal)saida.ValorIpi,
                            ValorSeguro = (decimal)saida.ValorSeguro,
                            CodLojaOrigem = saida.CodLojaOrigem,
                            TipoDocumentoFiscal = saida.TipoDocumentoFiscal
                        };
            return query.AsNoTracking();
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<SaidaPesquisa> GetQueryPesquisa()
        {
            var query = from saida in context.TbSaida
                        select new SaidaPesquisa
                        {
                            CodSaida = saida.CodSaida,
                            DataSaida = saida.DataSaida,
                            CodCliente = saida.CodCliente,
                            NomeCliente = saida.CodClienteNavigation.NomeFantasia,// cliente.nomeFantasia,
                            CupomFiscal = saida.PedidoGerado == null ? "" : saida.PedidoGerado,
                            TotalAVista = (decimal)saida.TotalAvista,
                            CodSituacaoPagamentos = saida.CodSituacaoPagamentos,
                            TipoSaida = saida.CodTipoSaida
                        };
            return query.AsNoTracking();
        }

        /// <summary>
        /// Obtme todos os dados de uma saída
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public Saida Obter(long codSaida)
        {
            List<Saida> saidas = GetQuery().Where(saida => saida.CodSaida == codSaida).ToList();
            if (saidas.Count == 1)
                return saidas[0];
            else
                return null;
        }


        /// <summary>
        /// Obtme todos os dados de uma saída
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public List<Saida> ObterPorTipoSaida(List<int> listaTiposSaida)
        {
            return GetQuery().Where(saida => listaTiposSaida.Contains(saida.TipoSaida)).OrderBy(s => s.CodSaida).ToList();
        }

        /// <summary>
        /// Obtem saidas pela data do pedido informada
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public object ObterPorDataPedido(string data)
        {
            DateTime dataConvertida = DateTime.Now;
            try
            {
                dataConvertida = Convert.ToDateTime(data);
            }
            catch (Exception)
            {
                // não precisa fazer nada
            }
            return GetQuery().Where(saida => saida.DataSaida >= dataConvertida).OrderBy(s => s.CodSaida).ToList();
        }


        /// <summary>
        /// Obtme todos os dados de uma saída por cupom fiscal
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public List<SaidaPesquisa> ObterPorCupomFiscal(String cupomFiscal)
        {
            var query = from saida in context.TbSaida
                        where saida.PedidoGerado.Equals(cupomFiscal)
                        select new SaidaPesquisa
                        {
                            CodSaida = saida.CodSaida,
                            DataSaida = saida.DataSaida,
                            CodCliente = saida.CodCliente,
                            NomeCliente = saida.CodClienteNavigation.NomeFantasia,// cliente.nomeFantasia,
                            CupomFiscal = saida.PedidoGerado == null ? "" : saida.PedidoGerado,
                            TotalAVista = (decimal)saida.TotalAvista,
                            CodSituacaoPagamentos = saida.CodSituacaoPagamentos,
                            TipoSaida = saida.CodTipoSaida
                        };
            return query.AsNoTracking().ToList();
        }

        public List<SaidaPesquisa> ObterSaidaPorNfe(int codNfe)
        {

            var query = from saida in context.TbSaida
                        where saida.CodNves.Select(nfe => nfe.CodNfe).Contains(codNfe)
                        select new SaidaPesquisa
                        {

                            CodSaida = saida.CodSaida,
                            DataSaida = saida.DataSaida,
                            CodCliente = saida.CodCliente,
                            NomeCliente = saida.CodClienteNavigation.NomeFantasia,// cliente.nomeFantasia,
                            CupomFiscal = saida.PedidoGerado == null ? "" : saida.PedidoGerado,
                            TotalAVista = (decimal)saida.TotalAvista,
                            CodSituacaoPagamentos = saida.CodSituacaoPagamentos,
                            TipoSaida = saida.CodTipoSaida
                        };
            return query.AsNoTracking().ToList();
        }

        /// <summary>
        /// Obtme todos os dados de uma saída
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public List<Saida> ObterSaidaConsumidor(long codSaidaInicial)
        {
            List<int> listaCodSaidasExibir = new List<int>();
            listaCodSaidasExibir.AddRange(Saida.LISTA_TIPOS_VENDA);
            listaCodSaidasExibir.Add(Saida.TIPO_BAIXA_ESTOQUE_PERDA);
            listaCodSaidasExibir.Add(Saida.TIPO_USO_INTERNO);

            var query = (from saida in context.TbSaida
                         where (listaCodSaidasExibir.Contains(saida.CodTipoSaida) && (saida.CodSaida >= codSaidaInicial))
                         orderby saida.CodSaida descending
                         select saida.CodSaida).Take(20);
            List<long> listaSaidas = query.ToList();

            return GetQuery().Where(saida => listaCodSaidasExibir.Contains(saida.TipoSaida) && (saida.CodSaida >= listaSaidas.Min() || saida.CodSaida == codSaidaInicial)).OrderBy(s => s.CodSaida).ToList();
        }


        /// <summary>
        /// Obtme todos os dados de uma saída
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public List<Saida> ObterSaidaPorAno(int ano)
        {
            return GetQuery().Where(saida => saida.DataSaida.Year == 2017).OrderBy(s => s.CodSaida).ToList();

        }
        /// <summary>
        /// Obter Troco por Período para todos os pagamentos
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public decimal ObterTrocoPagamentos(DateTime dataInicial, DateTime dataFinal)
        {
            var query = (from saida in context.TbSaida
                         where (saida.CodTipoSaida == Saida.TIPO_PRE_VENDA
                         || saida.CodTipoSaida == Saida.TIPO_VENDA
                         || saida.CodTipoSaida == Saida.TIPO_CREDITO)
                               && saida.DataSaida >= dataInicial
                               && saida.DataSaida <= dataFinal
                         select saida.Troco);

            return query.Count() > 0 ? (decimal)query.Sum() : 0;
        }

        /// <summary>
        /// Obter Troco por Período apenas para Saidas
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public decimal ObterTrocoSaidas(DateTime dataInicial, DateTime dataFinal)
        {
            var query = (from saida in context.TbSaida
                         where (saida.CodTipoSaida == Saida.TIPO_PRE_VENDA || saida.CodTipoSaida == Saida.TIPO_VENDA)
                               && saida.DataSaida >= dataInicial
                               && saida.DataSaida <= dataFinal
                         select saida.Troco);

            return query.Count() > 0 ? (decimal)query.Sum() : 0;
        }

        /// <summary>
        /// Obtem todos as pré-vendas cujo cupom fiscal não foi emitido
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public List<SaidaPesquisa> ObterPorPedido(string pedidoGerado)
        {
            var query = from saida in context.TbSaida
                        where saida.PedidoGerado.StartsWith(pedidoGerado)
                        orderby saida.CodSaida
                        select new SaidaPesquisa
                        {
                            CodSaida = saida.CodSaida,
                            DataSaida = saida.DataSaida,
                            CodCliente = saida.CodCliente,
                            NomeCliente = saida.CodClienteNavigation.NomeFantasia,// cliente.nomeFantasia,
                            CupomFiscal = saida.PedidoGerado == null ? "" : saida.PedidoGerado,
                            TotalAVista = (decimal)saida.TotalAvista,
                            CodSituacaoPagamentos = saida.CodSituacaoPagamentos,
                            TipoSaida = saida.CodTipoSaida
                        };
            return query.AsNoTracking().ToList();
        }

        /// <summary>
        /// Obtme todos as pré-vendas cujo cupom fiscal não foi emitido
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public List<SaidaPesquisa> ObterPorCodSaidas(List<long> listaCodSaidas)
        {
            var query = from saida in context.TbSaida
                        where listaCodSaidas.Contains(saida.CodSaida)
                        orderby saida.CodSaida
                        select new SaidaPesquisa
                        {
                            CodSaida = saida.CodSaida,
                            DataSaida = saida.DataSaida,
                            CodCliente = saida.CodCliente,
                            NomeCliente = saida.CodClienteNavigation.NomeFantasia,// cliente.nomeFantasia,
                            CupomFiscal = saida.PedidoGerado == null ? "" : saida.PedidoGerado,
                            TotalAVista = (decimal)saida.TotalAvista,
                            CodSituacaoPagamentos = saida.CodSituacaoPagamentos,
                            TipoSaida = saida.CodTipoSaida
                        };
            return query.AsNoTracking().ToList();
        }


        /// <summary>
        /// Obtme todos as pré-vendas cujo cupom fiscal não foi emitido
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public List<SaidaPesquisa> ObterPorSolicitacaoSaida(List<SolicitacaoSaida> listaSolicitacaoSaida)
        {
            List<long> listaCodSaida = listaSolicitacaoSaida.Select(s => s.CodSaida).ToList();
            var query = from saida in context.TbSaida
                        where listaCodSaida.Contains(saida.CodSaida)
                        orderby saida.CodSaida
                        select new SaidaPesquisa
                        {
                            CodSaida = saida.CodSaida,
                            DataSaida = saida.DataSaida,
                            CodCliente = saida.CodCliente,
                            NomeCliente = saida.CodClienteNavigation.NomeFantasia,
                            CupomFiscal = saida.PedidoGerado == null ? "" : saida.PedidoGerado,
                            TotalAVista = (decimal)saida.TotalAvista,
                            CodSituacaoPagamentos = saida.CodSituacaoPagamentos,
                            TipoSaida = saida.CodTipoSaida
                        };
            return query.AsNoTracking().ToList();
        }


        /// <summary>
        /// Obtme todos as pré-vendas cujo cupom fiscal não foi emitido
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public List<SaidaPesquisa> ObterPorNomeCliente(string nomeCliente)
        {
            return GetQueryPesquisa().Where(saida => saida.NomeCliente.StartsWith(nomeCliente)).OrderBy(s => s.CodSaida).ToList();
        }

        /// <summary>
        /// Obtme todos as pré-vendas cujo cupom fiscal não foi emitido
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public List<SaidaPesquisa> ObterPreVendasPendentes()
        {
            return GetQueryPesquisa().Where(saida => saida.TipoSaida == Saida.TIPO_PRE_VENDA &&
                saida.CupomFiscal.Trim().Equals("") && saida.CodSituacaoPagamentos == SituacaoPagamentos.QUITADA && saida.CodCliente == UtilConfig.Default.CLIENTE_PADRAO).OrderBy(s => s.CodSaida).ToList();
        }


        /// <summary>
        /// Obtme todos as pré-vendas cujo cupom fiscal não foi emitido
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public List<Saida> ObterVendasParticipacaoLucros(DateTime dataInicial, DateTime dataFinal, decimal valorVenda)
        {
            return GetQuery().Where(saida => (saida.TipoSaida == Saida.TIPO_PRE_VENDA || saida.TipoSaida == Saida.TIPO_VENDA || saida.TipoSaida == Saida.TIPO_BAIXA_ESTOQUE_PERDA || saida.TipoSaida == Saida.TIPO_USO_INTERNO) &&
                saida.CodCliente != 1324 &&
                saida.DataSaida >= dataInicial &&
                saida.DataSaida <= dataFinal &&
                saida.TotalAVista >= valorVenda).ToList();
        }

        public NumerosPeriodo ObterVendasMensalComparandoAnoAnterior()
        {
            DateTime dataAtual = DateTime.Now.AddDays(-1);

            var query = from saida in context.TbSaida
                        where saida.DataSaida.Year == dataAtual.Year
                        && saida.DataSaida.Month == dataAtual.Month
                        && saida.DataSaida.Day <= dataAtual.Day
                        && (saida.CodTipoSaida == 2 || saida.CodTipoSaida == 3)
                        group saida by new
                        {
                            PeriodoAno = saida.DataSaida.Year,

                        } into saidaPeriodoAno
                        select new NumerosPeriodo
                        {
                            NumeroVendas = saidaPeriodoAno.Count(),
                            TotalVendas = (decimal)saidaPeriodoAno.Sum(s => s.TotalAvista)
                        };
            NumerosPeriodo numerosPeriodo = query.FirstOrDefault();


            var query2 = from saida in context.TbSaida
                         where saida.DataSaida.Year == (dataAtual.Year - 1)
                         && saida.DataSaida.Month == dataAtual.Month
                         && saida.DataSaida.Day <= dataAtual.Day
                         && (saida.CodTipoSaida == 2 || saida.CodTipoSaida == 3)
                         group saida by new
                         {
                             PeriodoAno = saida.DataSaida.Year,

                         } into saidaPeriodoAno
                         select new NumerosPeriodo
                         {
                             NumeroVendas = saidaPeriodoAno.Count(),
                             TotalVendas = (decimal)saidaPeriodoAno.Sum(s => s.TotalAvista)
                         };
            NumerosPeriodo numerosPeriodoAnoAnterior = query2.FirstOrDefault();

            NumerosPeriodo resultado = new NumerosPeriodo();
            if (numerosPeriodo != null && numerosPeriodoAnoAnterior != null)
            {
                resultado.NumeroVendas = (numerosPeriodo.NumeroVendas / numerosPeriodoAnoAnterior.NumeroVendas - 1) * 100;
                resultado.TotalVendas = (numerosPeriodo.TotalVendas / numerosPeriodoAnoAnterior.TotalVendas - 1) * 100;
            }
            return resultado;
        }



        /// <summary>
        /// Obter cfop padrão de um determinado tipo de saída do sistema
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int ObterCfopTipoSaida(int codTipoSaida)
        {
            var query = from tipoSaida in context.TbTipoSaida
                        where tipoSaida.CodTipoSaida == codTipoSaida
                        select tipoSaida.Cfop;
            return query.ToList().FirstOrDefault();
        }

        /// <summary>
        /// Obtém somatório de vendas por grupo de produtos em um dado período de tempo
        /// </summary>
        /// <param name="codGrupo"></param>
        /// <param name="dataInicial"></param>
        /// <param name="dataFinal"></param>
        /// <returns></returns>
        public List<VendasGrupoProduto> ObterVendasPorGrupo(int codGrupo, DateTime dataInicial, DateTime dataFinal)
        {
            var query = from saidaProduto in context.TbSaidaProdutos
                        where saidaProduto.CodProdutoNavigation.CodGrupo == codGrupo &&
                        saidaProduto.CodSaidaNavigation.DataSaida >= dataInicial &&
                        saidaProduto.CodSaidaNavigation.DataSaida <= dataFinal &&
                        (saidaProduto.CodSaidaNavigation.CodTipoSaida == 2 ||
                        saidaProduto.CodSaidaNavigation.CodTipoSaida == 3)
                        group saidaProduto by new
                        {
                            Ano = saidaProduto.CodSaidaNavigation.DataSaida.Year,
                            Mes = saidaProduto.CodSaidaNavigation.DataSaida.Month,

                        } into groupSaidaProduto
                        orderby groupSaidaProduto.Key.Ano, groupSaidaProduto.Key.Mes
                        select new VendasGrupoProduto
                        {
                            CodGrupo = codGrupo,
                            MesAno = groupSaidaProduto.Key.Mes + "/" + groupSaidaProduto.Key.Ano,
                            TotalVendas = groupSaidaProduto.Sum(p => p.SubtotalAvista)
                        };
            return query.ToList();
        }

        public List<VendasVendedor> ObterVendasPorVendedor(DateTime dataInicial, DateTime dataFinal)
        {
            dataInicial = dataInicial.Date;
            dataFinal = dataFinal.Date.AddDays(1);

            var query = from saida in context.TbSaida
                        where saida.DataSaida >= dataInicial &&
                            saida.DataSaida <= dataFinal &&
                            (saida.CodTipoSaida == 2 || saida.CodTipoSaida == 3)
                        group saida by saida.CodProfissional into groupSaidaProduto
                        select new VendasVendedor
                        {
                            CodProfissional = groupSaidaProduto.Key.Value,
                            TotalVendas = groupSaidaProduto.Sum(s => s.TotalAvista),
                            TotalLucro = groupSaidaProduto.Sum(s => s.TotalLucro)
                        };
            var listaInicial = query.ToList();
            decimal? somaTotalAVista = listaInicial.Sum(s => s.TotalVendas);
            decimal? somaLucro = listaInicial.Sum(s => s.TotalLucro);
            foreach (var item in listaInicial)
            {
                item.PercentualVendas = item.TotalVendas / somaTotalAVista * 100;
                item.PercentualLucro = item.TotalLucro / somaLucro * 100;
                item.Login = context.TbUsuarios.Find(new TbUsuario() { CodPessoa = item.CodProfissional }).Login;
            }
            return listaInicial.OrderBy(v => v.Login).ToList();
        }




        /// <summary>
        /// Encerra uma saída fazendo movimentações de estoque e lançamentos no contas a pagar/receber
        /// </summary>
        /// <param name="saida"></param>
        /// <param name="tipo_encerramento"></param>
        public void Encerrar(Saida saida, int tipo_encerramento, List<SaidaPagamento> saidaPagamentos, Pessoa cliente)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    if (saida.TipoSaida.Equals(Saida.TIPO_ORCAMENTO) && tipo_encerramento.Equals(Saida.TIPO_ORCAMENTO))
                    {
                        saida.TipoSaida = Saida.TIPO_ORCAMENTO;
                        Atualizar(saida);
                    }
                    else if (saida.TipoSaida.Equals(Saida.TIPO_ORCAMENTO) && (tipo_encerramento.Equals(Saida.TIPO_PRE_VENDA)))
                    {
                        if (cliente.BloquearCrediario)
                        {
                            foreach (SaidaPagamento sp in saidaPagamentos)
                            {
                                if (sp.CodFormaPagamento == FormaPagamento.CREDIARIO)
                                    throw new NegocioException("CREDIÁRIO BLOQUEADO. Autorização da Gerência é necessária.");
                            }
                        }
                        saida.TipoSaida = tipo_encerramento;
                        saida.CodSituacaoPagamentos = SituacaoPagamentos.LANCADOS;

                        List<SaidaProduto> saidaProdutos = gerenciadorSaidaProduto.ObterPorSaida(saida.CodSaida);
                        Decimal somaPrecosCusto = RegistrarBaixaEstoque(saidaProdutos);

                        saida.TotalLucro = saida.TotalAVista - somaPrecosCusto;
                        Atualizar(saida);

                        RegistrarPagamentosSaida(saidaPagamentos, saida);
                    }
                    else if (tipo_encerramento.Equals(Saida.TIPO_BAIXA_ESTOQUE_PERDA) || tipo_encerramento.Equals(Saida.TIPO_USO_INTERNO))
                    {
                        saida.TipoSaida = tipo_encerramento;
                        saida.CodSituacaoPagamentos = SituacaoPagamentos.QUITADA;

                        List<SaidaProduto> saidaProdutos = gerenciadorSaidaProduto.ObterPorSaida(saida.CodSaida);
                        Decimal somaPrecosCusto = RegistrarBaixaEstoque(saidaProdutos);
                        saida.TotalLucro = 0;
                        saida.TotalLucro -= somaPrecosCusto;
                        Atualizar(saida);
                    }
                    else if (tipo_encerramento.Equals(Saida.TIPO_REMESSA_DEPOSITO))
                    {
                        saida.TipoSaida = Saida.TIPO_REMESSA_DEPOSITO;

                        Loja lojaDestino = gerenciadorLoja.ObterPorPessoa(saida.CodCliente).ElementAt(0);
                        if (lojaDestino.CodLoja.Equals(saida.CodLojaOrigem))
                        {
                            throw new NegocioException("Não pode ser feita transferência de produtos para a mesma loja.");
                        }

                        List<SaidaProduto> saidaProdutos = gerenciadorSaidaProduto.ObterPorSaida(saida.CodSaida);
                        Atualizar(saida);
                        RegistrarTransferenciaEstoque(saidaProdutos, UtilConfig.Default.LOJA_PADRAO, lojaDestino.CodLoja);
                    }
                    else if (tipo_encerramento.Equals(Saida.TIPO_RETORNO_DEPOSITO))
                    {
                        saida.TipoSaida = Saida.TIPO_RETORNO_DEPOSITO;
                        if (saida.CodLojaOrigem.Equals(UtilConfig.Default.LOJA_PADRAO))
                        {
                            throw new NegocioException("Não pode ser feita transferência de produtos para a mesma loja.");
                        }
                        Atualizar(saida);
                        List<SaidaProduto> saidaProdutos = gerenciadorSaidaProduto.ObterPorSaida(saida.CodSaida);
                        RegistrarTransferenciaEstoque(saidaProdutos, saida.CodLojaOrigem, UtilConfig.Default.LOJA_PADRAO);
                    }
                    else if (tipo_encerramento.Equals(Saida.TIPO_DEVOLUCAO_FORNECEDOR))
                    {
                        saida.TipoSaida = Saida.TIPO_DEVOLUCAO_FORNECEDOR;
                        Atualizar(saida);
                        List<SaidaProduto> saidaProdutos = gerenciadorSaidaProduto.ObterPorSaida(saida.CodSaida);
                        RegistrarBaixaEstoque(saidaProdutos);
                        AtualizarCfopProdutosDevolucao(saidaProdutos, saida);
                    }
                    else if (tipo_encerramento.Equals(Saida.TIPO_REMESSA_CONSERTO))
                    {
                        saida.TipoSaida = Saida.TIPO_REMESSA_CONSERTO;
                        Atualizar(saida);
                        List<SaidaProduto> saidaProdutos = gerenciadorSaidaProduto.ObterPorSaida(saida.CodSaida);
                        RegistrarBaixaEstoque(saidaProdutos);
                        //AtualizarCfopProdutosDevolucao(saidaProdutos, saida);
                    }
                    transaction.Complete();
                }
                catch (NegocioException ne)
                {
                    throw ne;
                }
                catch (DadosException de)
                {
                    throw de;
                }
                catch (Exception e)
                {
                    throw new DadosException("Problemas no encerramento da saída. Favor contactar o administrador.", e);
                }

            }
        }

        /// <summary>
        /// Faz o encerramento de um devolução de produtos pelo consumidor
        /// </summary>
        /// <param name="saida"></param>
        /// <param name="consumidor"></param>
        public void EncerrarDevolucaoConsumidor(Saida saida)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    saida.TipoSaida = Saida.TIPO_DEVOLUCAO_CONSUMIDOR;
                    //saida.CodCliente = consumidor.CodPessoa;
                    Atualizar(saida);
                    List<SaidaProduto> saidaProdutos = gerenciadorSaidaProduto.ObterPorSaida(saida.CodSaida);
                    RegistrarEstornoEstoque(saida, saidaProdutos);
                    AtualizarCfopProdutosDevolucao(saidaProdutos, saida);
                    transaction.Complete();
                }
                catch (NegocioException ne)
                {
                    throw ne;
                }
                catch (DadosException de)
                {
                    throw de;
                }
                catch (Exception e)
                {
                    throw new DadosException("Problemas no encerramento da saída. Favor contactar o administrador.", e);
                }

            }
        }

        /// <summary>
        /// Faz o encerramento de um retorno de mercadorias que o fornecedor não aceitou a devolução
        /// </summary>
        /// <param name="saida"></param>
        /// <param name="consumidor"></param>
        public void EncerrarRetornoFornecedor(Saida saida)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    saida.TipoSaida = Saida.TIPO_RETORNO_FORNECEDOR;
                    Atualizar(saida);
                    List<SaidaProduto> saidaProdutos = gerenciadorSaidaProduto.ObterPorSaida(saida.CodSaida);
                    RegistrarEstornoEstoque(saida, saidaProdutos);
                    AtualizarCfopProdutosDevolucao(saidaProdutos, saida);
                    transaction.Complete();
                }
                catch (NegocioException ne)
                {
                    throw ne;
                }
                catch (DadosException de)
                {
                    throw de;
                }
                catch (Exception e)
                {
                    throw new DadosException("Problemas no encerramento da saída. Favor contactar o administrador.", e);
                }

            }
        }

        /// <summary>
        /// Atualiza os cfops de produtos de acordo com os dados de devolução na NF-e
        /// </summary>
        /// <param name="saidaProdutos"></param>
        /// <param name="_saida"></param>
        private void AtualizarCfopProdutosDevolucao(List<SaidaProduto> saidaProdutos, Saida saida)
        {
            Pessoa fornecedor = gerenciadorPessoa.Obter(saida.CodCliente).ElementAtOrDefault(0);
            Loja loja = gerenciadorLoja.Obter(UtilConfig.Default.LOJA_PADRAO).ElementAtOrDefault(0);
            Pessoa pessoaLoja = gerenciadorPessoa.Obter(loja.CodPessoa).ElementAtOrDefault(0);

            bool ehMesmoUF = false;
            if (pessoaLoja != null && fornecedor != null)
            {
                ehMesmoUF = pessoaLoja.Uf.Equals(fornecedor.Uf);
            }
            foreach (SaidaProduto saidaProduto in saidaProdutos)
            {
                if (saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_CONSUMIDOR))
                {
                    if (saidaProduto.EhTributacaoIntegral)
                    {
                        saidaProduto.CodCfop = Cfop.DEVOLUCAO_CONSUMIDOR_NORMAL;
                    }
                    else if (!saidaProduto.EhTributacaoIntegral)
                    {
                        saidaProduto.CodCfop = Cfop.DEVOLUCAO_CONSUMIDOR_ST;
                    }
                }
                else
                {
                    if (saidaProduto.EhTributacaoIntegral)
                    {
                        saidaProduto.CodCfop = (ehMesmoUF) ? Cfop.DEVOLUCAO_NORMAL_ESTADO : Cfop.DEVOLUCAO_NORMAL_FORA_ESTADO;
                    }
                    else
                    {
                        saidaProduto.CodCfop = (ehMesmoUF) ? Cfop.DEVOUCAO_ST_ESTADO : Cfop.DEVOUCAO_ST_FORA_ESTADO;
                    }
                }
                gerenciadorSaidaProduto.AtualizarCFOP(saidaProduto.CodSaidaProduto, saidaProduto.CodCfop);
            }
        }
        /// <summary>
        /// Calculo do toatal da nota de acordo com a existência de substituição tributária
        /// </summary>
        /// <param name="saida"></param>
        /// <returns></returns>
        public decimal ObterTotalNotaFiscal(Saida saida)
        {
            if (saida.BaseCalculoICMSSubst > 0)
                return saida.TotalAVista + saida.ValorICMSSubst + saida.ValorFrete + saida.ValorSeguro - saida.Desconto + saida.OutrasDespesas + saida.ValorIPI;
            else
                return saida.TotalAVista + saida.ValorICMS + saida.ValorFrete + saida.ValorSeguro - saida.Desconto + saida.OutrasDespesas + saida.ValorIPI;
        }

        /// <summary>
        /// Verifica na saída se produto tem data de vencimento aceitável.
        /// </summary>
        /// <param name="produto"></param>
        /// <param name="dataVencimento"></param>
        /// <returns></returns>
        public Boolean DataVencimentoProdutoAceitavel(ProdutoPesquisa produto, DateTime dataVencimento)
        {
            if ((bool) produto.TemVencimento)
            {
                DateTime dataMaisAntigo = gerenciadorEntradaProduto.GetDataProdutoMaisAntigoEstoque(produto);
                return (dataMaisAntigo >= dataVencimento);
            }
            return true;
        }

        /// <summary>
        /// Regista formas de pagamentos de uma saída
        /// </summary>
        /// <param name="pagamentos"></param>
        /// <param name="saida"></param>
        public void RegistrarPagamentosSaida(List<SaidaPagamento> pagamentos, Saida saida)
        {
            decimal totalRegistrado = 0;

            if (saida.TipoSaida.Equals(Saida.TIPO_PRE_CREDITO))
            {
                // Para cada pagamento é criada uma nova conta
                Conta conta = new Conta();
                conta.CodPessoa = saida.CodCliente;
                conta.CodPlanoConta = PlanoConta.SAIDA_PRODUTOS;
                conta.CodSaida = saida.CodSaida;
                conta.CodEntrada = UtilConfig.Default.ENTRADA_PADRAO; // entrada não válida
                conta.CodPessoa = saida.CodCliente;
                conta.CodPagamento = 0; //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXx
                conta.Desconto = 0;
                conta.FormatoConta = Conta.FORMATO_CONTA_CREDITO;
                conta.NumeroDocumento = "";
                conta.CodSituacao = SituacaoConta.SITUACAO_ABERTA.ToString();
                conta.TipoConta = Conta.CONTA_RECEBER.ToString();
                conta.Valor = (decimal)saida.TotalAVista * (-1);

                conta.DataVencimento = saida.DataSaida;
                conta.Desconto = 0;
                conta.CodConta = gerenciadorConta.Inserir(conta);
            }


            foreach (SaidaPagamento pagamento in pagamentos)
            {

                List<Conta> contas = gerenciadorConta.ObterPorSaidaPagamento(saida.CodSaida, pagamento.CodSaidaPagamento).ToList();

                if (contas.Count > 0)
                {
                    totalRegistrado += pagamento.Valor;
                    continue;
                }
                // Para cada pagamento é criada uma nova conta
                Conta conta = new Conta();
                conta.CodPessoa = saida.CodCliente;
                conta.CodPlanoConta = PlanoConta.SAIDA_PRODUTOS;
                conta.CodSaida = saida.CodSaida;
                conta.CodEntrada = UtilConfig.Default.ENTRADA_PADRAO; // entrada não válida
                conta.CodPessoa = saida.CodCliente;
                conta.CodPagamento = pagamento.CodSaidaPagamento;
                conta.Desconto = 0;
                conta.FormatoConta = Conta.FORMATO_CONTA_FICHA;
                conta.NumeroDocumento = "";

                // Quando o pagamento é realizado em dinheiro a conta já é inserida quitada
                if (pagamento.CodFormaPagamento == FormaPagamento.DINHEIRO || pagamento.CodFormaPagamento == FormaPagamento.DEPOSITO_PIX)
                    conta.CodSituacao = SituacaoConta.SITUACAO_QUITADA.ToString();
                else
                    conta.CodSituacao = SituacaoConta.SITUACAO_ABERTA.ToString();

                if (pagamento.CodFormaPagamento == FormaPagamento.CARTAO)
                {
                    conta.CodPessoa = gerenciadorCartaoCredito.Obter(pagamento.CodCartaoCredito).ElementAt(0).CodPessoa;
                    conta.FormatoConta = Conta.FORMATO_CONTA_CARTAO;
                }

                conta.TipoConta = Conta.CONTA_RECEBER.ToString();

                if (((totalRegistrado + pagamento.Valor) >= saida.TotalAVista) && (pagamento.CodFormaPagamento == FormaPagamento.DINHEIRO))
                {
                    conta.Valor = ((decimal)saida.TotalAVista - totalRegistrado) / pagamento.Parcelas;
                }
                else if (pagamento.CodFormaPagamento == FormaPagamento.CREDIARIO)
                {
                    if (pagamento.Valor == saida.TotalAVista)
                    {
                        conta.Valor = ((decimal)saida.Total / pagamento.Parcelas);
                        conta.Desconto = ((decimal)saida.Total - (decimal)saida.TotalAVista) / pagamento.Parcelas;
                    }
                    else
                    {
                        conta.Valor = ((pagamento.Valor * saida.Total) / saida.TotalAVista) / pagamento.Parcelas;
                        conta.Desconto = (conta.Valor - pagamento.Valor) / pagamento.Parcelas;
                    }
                }
                else if (pagamento.CodFormaPagamento == FormaPagamento.CARTAO)
                {
                    conta.Valor = pagamento.Valor / pagamento.Parcelas;
                }


                for (int i = 0; i < pagamento.Parcelas; i++)
                {
                    if (pagamento.CodFormaPagamento == FormaPagamento.CARTAO)
                    {
                        CartaoCredito cartaoCredito = gerenciadorCartaoCredito.Obter(pagamento.CodCartaoCredito).ElementAt(0);
                        pagamento.Data = pagamento.Data.AddDays((double)cartaoCredito.DiaBase);
                        conta.DataVencimento = pagamento.Data;
                        conta.Desconto = (pagamento.Valor * cartaoCredito.Desconto / 100) / pagamento.Parcelas;

                    }
                    else if (pagamento.CodFormaPagamento == FormaPagamento.CREDIARIO)
                    {
                        conta.DataVencimento = saida.DataSaida.AddDays(pagamento.IntervaloDias);
                    }
                    else
                    {
                        conta.DataVencimento = pagamento.Data;
                    }

                    conta.CodConta = gerenciadorConta.Inserir(conta);
                }

                totalRegistrado += pagamento.Valor;



                if (pagamento.CodFormaPagamento == FormaPagamento.DINHEIRO ||
                    pagamento.CodFormaPagamento == FormaPagamento.DEPOSITO_PIX)
                {
                    MovimentacaoConta movimentacao = new MovimentacaoConta();
                    movimentacao.CodContaBanco = pagamento.CodContaBanco;
                    movimentacao.CodConta = conta.CodConta;
                    movimentacao.CodResponsavel = saida.CodCliente;
                    movimentacao.DataHora = pagamento.Data;
                    if (totalRegistrado > saida.TotalAVista)
                    {
                        movimentacao.Valor = pagamento.Valor - (decimal)saida.Troco;
                    }
                    else
                    {
                        movimentacao.Valor = pagamento.Valor;
                    }

                    movimentacao.CodTipoMovimentacao = (movimentacao.Valor > 0) ? MovimentacaoConta.RECEBIMENTO_CLIENTE : MovimentacaoConta.DEVOLUCAO_CLIENTE;

                    gerenciadorMovimentacaoConta.Inserir(movimentacao);
                }
            }
        }

        /// <summary>
        /// Registra estorno de estoque no caso de devolução ou exclusão da saída
        /// No caso de devolução do consumidor o estoque é incrementado.
        /// </summary>
        /// <param name="saidaProdutos"></param>
        public void RegistrarEstornoEstoque(Saida saida, List<SaidaProduto> saidaProdutos)
        {
            if (saidaProdutos == null)
                saidaProdutos = gerenciadorSaidaProduto.ObterPorSaida(saida.CodSaida);

            foreach (SaidaProduto saidaProduto in saidaProdutos)
            {
                if (saidaProduto.CodCST != Cst.ST_OUTRAS)
                {
                    gerenciadorProdutoLoja.AdicionaQuantidade(saidaProduto.Quantidade, 0, UtilConfig.Default.LOJA_PADRAO, saidaProduto.CodProduto);
                }
                else
                {
                    gerenciadorProdutoLoja.AdicionaQuantidade(0, saidaProduto.Quantidade, UtilConfig.Default.LOJA_PADRAO, saidaProduto.CodProduto);
                }
                saidaProduto.Quantidade *= (-1); // inverte sinal da quantidade para fazer o retorno
                gerenciadorEntradaProduto.BaixarItensVendidosEstoque(saidaProduto);
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Decrementa a quantidade de produtos na loja matriz e atualiza o lote de
        /// entrada determinando que produtos foram vendidos de um determinado lote.
        /// </summary>
        /// <param name="saidaProdutos"></param>
        /// <returns> A soma dos preços de custo dos produtos baixados para determinar o lucro</returns>
        private Decimal RegistrarBaixaEstoque(List<SaidaProduto> saidaProdutos)
        {
            Decimal somaPrecosCusto = 0;
            foreach (SaidaProduto saidaProduto in saidaProdutos)
            {
                Produto produto = gerenciadorProduto.Obter(new ProdutoPesquisa() { CodProduto = saidaProduto.CodProduto });

                // Baixa sempre o estoque da loja matriz
                if (saidaProduto.CodCST != Cst.ST_OUTRAS)
                {
                    gerenciadorProdutoLoja.AdicionaQuantidade(saidaProduto.Quantidade * (-1), 0, UtilConfig.Default.LOJA_PADRAO, saidaProduto.CodProduto);
                }
                else
                {
                    gerenciadorProdutoLoja.AdicionaQuantidade(0, saidaProduto.Quantidade * (-1), UtilConfig.Default.LOJA_PADRAO, saidaProduto.CodProduto);
                }

                decimal custoAtual = produto.PrecoCusto * saidaProduto.Quantidade;
                decimal custoEstoque = gerenciadorEntradaProduto.BaixarItensVendidosEstoque(saidaProduto);
                // Se não houver preço de custo do produto
                if (custoAtual <= 0)
                {
                    custoAtual = Convert.ToDecimal(0.7) * saidaProduto.PrecoVendaVarejo * saidaProduto.Quantidade;
                }
                else if (custoAtual >= (saidaProduto.PrecoVendaVarejo * saidaProduto.Quantidade))
                {
                    custoAtual = saidaProduto.PrecoVendaVarejo * saidaProduto.Quantidade;
                }

                if (custoEstoque <= 0)
                {
                    custoEstoque = Convert.ToDecimal(0.7) * saidaProduto.PrecoVendaVarejo * saidaProduto.Quantidade;
                }
                else if (custoEstoque >= (saidaProduto.PrecoVendaVarejo * saidaProduto.Quantidade))
                {
                    custoEstoque = saidaProduto.PrecoVendaVarejo * saidaProduto.Quantidade;
                }

                if (custoEstoque < custoAtual)
                {
                    somaPrecosCusto += custoEstoque;
                }
                else
                {
                    somaPrecosCusto += custoAtual;
                }
            }
            return somaPrecosCusto;
        }

        /// <summary>
        /// Registra transferência de estoque entre lojas
        /// </summary>
        /// <param name="saidaProdutos"></param>
        /// <param name="lojaOrigem"></param>
        /// <param name="lojaDestino"></param>
        private void RegistrarTransferenciaEstoque(List<SaidaProduto> saidaProdutos, int lojaOrigem, int lojaDestino)
        {
            foreach (SaidaProduto saidaProduto in saidaProdutos)
            {
                ProdutoPesquisa produto = gerenciadorProduto.Obter(saidaProduto.CodProduto).ElementAt(0);

                gerenciadorProdutoLoja.AdicionaQuantidade(saidaProduto.Quantidade * (-1), 0, lojaOrigem, saidaProduto.CodProduto);

                gerenciadorProdutoLoja.AdicionaQuantidade(saidaProduto.Quantidade, 0, lojaDestino, saidaProduto.CodProduto);
            }
        }

        /// <summary>
        /// Receber pagamentos Contas
        /// </summary>
        public void ReceberPagamentosContas(List<ContaSaida> listaContaSaida, List<SaidaPagamento> pagamentos, List<MovimentacaoConta> listaMovimentacaoConta, Saida saida)
        {
            
            try
            {
                context.Database.BeginTransaction();

                RegistrarPagamentosSaida(pagamentos, saida);

                saida.TipoSaida = Saida.TIPO_CREDITO;
                saida.CodSituacaoPagamentos = SituacaoPagamentos.LANCADOS;

                Atualizar(saida);

                var listaCodContas = listaContaSaida.Select(conta => conta.CodConta);
                var queryContas = from conta in context.TbConta
                                  where listaCodContas.Contains(conta.CodConta)
                                  orderby conta.DataVencimento
                                  select conta;
                IEnumerable<TbContum> listaContas = queryContas.ToList();

                // adiciona os créditos de devolução ao valor da movimentação
                decimal totalPagamentos = listaMovimentacaoConta.Sum(m => m.Valor);
                totalPagamentos += Math.Abs(listaContas.Where(c => c.Valor < 0 && c.CodSituacao != SituacaoConta.SITUACAO_QUITADA).Sum(c => (c.Valor - c.Desconto)));


                decimal totalDebitos = listaContas.Where(c => c.Valor >= 0 && c.CodSituacao != SituacaoConta.SITUACAO_QUITADA).Sum(c => (c.Valor - c.Desconto));

                if (totalPagamentos == totalDebitos)
                {
                    foreach (TbContum _conta in listaContas)
                    {
                        _conta.CodSituacao = SituacaoConta.SITUACAO_QUITADA;
                        _conta.Observacao = "SAIDA" + saida.CodSaida;
                    }
                    context.SaveChanges();
                }

                context.Database.CommitTransaction();
            }
            catch (Exception e)
            {
                context.Database.RollbackTransaction();
                throw new DadosException("Saída", e.Message, e);
            }
        }



        public List<SaidaProduto> ExcluirProdutosDevolvidosMesmoPreco(List<SaidaProduto> saidaProdutos)
        {
            List<SaidaProduto> listaSemDevolucoes = new List<SaidaProduto>();
            List<SaidaProduto> listaDevolucoes = new List<SaidaProduto>();
            List<SaidaProduto> listaNaoConseguiuDevolver = new List<SaidaProduto>();

            foreach (SaidaProduto saidaProduto in saidaProdutos)
            {
                if (saidaProduto.Quantidade > 0)
                {
                    listaSemDevolucoes.Add(saidaProduto);
                }
                else
                {
                    listaDevolucoes.Add(saidaProduto);
                }
            }

            if (listaDevolucoes.Count > 0)
            {
                foreach (SaidaProduto devolvido in listaDevolucoes)
                {
                    decimal quantidadeDevolvida = Math.Abs(devolvido.Quantidade);
                    foreach (SaidaProduto naoDevolvido in listaSemDevolucoes)
                    {
                        if ((naoDevolvido.CodProduto == devolvido.CodProduto) && (naoDevolvido.ValorVenda == devolvido.ValorVenda))
                        {
                            if (quantidadeDevolvida < naoDevolvido.Quantidade)
                            {
                                naoDevolvido.Quantidade -= quantidadeDevolvida;
                                quantidadeDevolvida = 0;
                                break;
                            }
                            else
                            {
                                quantidadeDevolvida -= naoDevolvido.Quantidade;
                                devolvido.Quantidade += naoDevolvido.Quantidade;
                                naoDevolvido.Quantidade = 0;
                                //listaSemDevolucoes.Remove(naoDevolvido);
                            }
                        }
                    }
                    if (quantidadeDevolvida > 0)
                    {
                        listaNaoConseguiuDevolver.Add(devolvido);
                    }
                }
                if (listaNaoConseguiuDevolver.Count > 0)
                {
                    listaSemDevolucoes.AddRange(listaNaoConseguiuDevolver);
                }
            }
            return listaSemDevolucoes;
        }


        public bool SolicitaImprimirDAV(List<long> listaCodSaidas, decimal total, decimal totalAVista, decimal desconto, Impressora.Tipo impressora)
        {
            string tipoDocumento = impressora.Equals(Impressora.Tipo.REDUZIDO1) ? Impressora.REDUZIDO1 : Impressora.REDUZIDO2;

            if (gerenciadorImprimirDocumento.ObterPorTipoDocumentoCodDocumento(tipoDocumento, listaCodSaidas.Min()).Count() > 0)
                throw new NegocioException("Documento já foi solicitado para impressão. Verifique se impressora ligada.");


            var documento = new TbImprimirDocumento();
            documento.Desconto = desconto;
            documento.HostSolicitante = SystemInformation.ComputerName;
            documento.TipoDocumento = tipoDocumento;
            documento.Total = total;
            documento.TotalAvista = totalAVista;
            documento.CodDocumento = listaCodSaidas.Min();
            context.Add(documento);
            context.SaveChanges();

            var query = from saida in context.TbSaida
                        where listaCodSaidas.Contains(saida.CodSaida)
                        select saida;

            List<TbSaidum> saidas = query.ToList();
            foreach (TbSaidum saida in saidas)
            {
                documento.CodSaida.Add(saida);
            }
            context.SaveChanges();
            return true;
        }


        public bool ImprimirDAV(Impressora.Tipo impressora, string portaImpressora)
        {
            string tipoDocumento = impressora.Equals(Impressora.Tipo.REDUZIDO1) ? Impressora.REDUZIDO1 : Impressora.REDUZIDO2;

            var query = from documento in context.TbImprimirDocumentos
                        where tipoDocumento.Equals(documento.TipoDocumento)
                        select documento;

            List<TbImprimirDocumento> documentos = query.ToList();
            foreach (TbImprimirDocumento documento in documentos)
            {
                List<long> listaCodSaidas = documento.CodSaida.Select(s => s.CodSaida).ToList();
                context.Remove(documento);
                context.SaveChanges();
                List<SaidaPesquisa> saidas = ObterPorCodSaidas(listaCodSaidas).ToList();
                if (impressora.Equals(Impressora.Tipo.REDUZIDO1))
                    return ImprimirDAVComprimido(saidas, (decimal) documento.Total, (decimal)documento.TotalAvista, (decimal)documento.Desconto, portaImpressora);
                else
                    ImprimirDAVComprimidoVip(saidas, (decimal)documento.Total, (decimal)documento.TotalAvista, (decimal)documento.Desconto, portaImpressora);
            }
            return true;
        }

        private bool ImprimirDAVComprimido(List<SaidaPesquisa> saidas, decimal total, decimal totalAVista, decimal desconto, string portaImpressora)
        {
            try
            {
                ImprimeTexto imp = new ImprimeTexto();
                if (!imp.Inicio(portaImpressora))
                {
                    return false;
                }


                Loja loja = gerenciadorLoja.Obter(UtilConfig.Default.LOJA_PADRAO).ElementAt(0);
                Pessoa pessoaLoja = (Pessoa)gerenciadorPessoa.Obter(loja.CodPessoa).ElementAt(0);

                imp.Imp(imp.Comprimido);
                imp.ImpLF(UtilConfig.Default.LINHA_COMPRIMIDA);
                if (saidas[0].TipoSaida == Saida.TIPO_ORCAMENTO)
                {
                    imp.ImpColLFCentralizado(0, 59, "DOCUMENTO AUXILIAR DE VENDA - ORCAMENTO");
                }
                else
                {
                    imp.ImpColLFCentralizado(0, 59, "DOCUMENTO AUXILIAR DE VENDA - PEDIDO");
                }
                imp.Pula(1);
                imp.ImpColLFCentralizado(0, 59, "NAO E DOCUMENTO FISCAL - NAO E VALIDO COMO RECIBO ");
                imp.ImpColLFCentralizado(0, 59, "E COMO GARANTIA DE MERCADORIA - NAO COMPROVA PAGAMENTO");
                imp.ImpLF(UtilConfig.Default.LINHA_COMPRIMIDA);
                imp.ImpColLFCentralizado(0, 59, imp.NegritoOn + pessoaLoja.Nome + imp.NegritoOff);
                imp.ImpColLFCentralizado(0, 59, pessoaLoja.Endereco + "  Fone: " + pessoaLoja.Fone1);
                imp.ImpLF(UtilConfig.Default.LINHA_COMPRIMIDA);

                Pessoa cliente = (Pessoa)gerenciadorPessoa.Obter(saidas[0].CodCliente).ElementAt(0);
                imp.ImpLF("Cliente: " + cliente.NomeFantasia);
                //imp.ImpColLF(39, "CPF/CNPJ: " + cliente.CpfCnpj);
                if (saidas.Count == 1)
                {
                    imp.Imp("No do Documento: " + saidas[0].CodSaida);
                    imp.ImpColLF(30, "No do Documento Fiscal: " + saidas[0].CupomFiscal);
                    imp.ImpLF("Data: " + saidas[0].DataSaida.ToShortDateString());
                }
                imp.ImpLF(UtilConfig.Default.LINHA_COMPRIMIDA);
                imp.ImpLF("Cod  Produto                                   Qtdade    UN ");
                imp.ImpLF("                                      Preco(R$) Subtotal(R$)");
                foreach (SaidaPesquisa saida in saidas)
                {
                    if (saidas.Count > 1)
                    {
                        imp.ImpLF("==> Documento: " + saida.CodSaida + "    Data: " + saida.DataSaida.ToShortDateString() + "     CF: " + saida.CupomFiscal);
                    }

                    List<SaidaProduto> saidaProdutos = gerenciadorSaidaProduto.ObterPorSaida(saida.CodSaida);
                    foreach (SaidaProduto produto in saidaProdutos)
                    {
                        imp.ImpColDireita(0, 4, produto.CodProduto.ToString());

                        if (produto.Nome.Length > 39)
                        {
                            imp.ImpCol(6, produto.Nome.Substring(1, 39));
                        }
                        else
                        {
                            imp.ImpCol(6, produto.Nome);
                        }

                        imp.ImpColDireita(46, 54, produto.Quantidade.ToString());
                        imp.ImpColLFDireita(57, 58, produto.Unidade);
                        imp.ImpColDireita(38, 46, produto.ValorVenda.ToString("N2"));
                        imp.ImpColLFDireita(48, 59, produto.Subtotal.ToString("N2"));
                    }
                }

                imp.ImpLF(UtilConfig.Default.LINHA_COMPRIMIDA);
                imp.ImpLF("Total Venda: " + total + "     Desconto: " + desconto.ToString("N2") + "%");
                imp.ImpColLFDireita(0, 32, imp.Expandido + imp.NegritoOn + "Total Pagar:" + totalAVista.ToString("N2") + imp.Comprimido + imp.NegritoOff);
                imp.ImpLF(UtilConfig.Default.LINHA_COMPRIMIDA);
                imp.ImpColLFCentralizado(0, 59, "E vedada a autenticacao deste documento");
                if (!saidas[0].CupomFiscal.Equals(""))
                {
                    imp.ImpColLFCentralizado(0, 59, "Documento Válido por 3 (tres) dias");
                }
                imp.ImpLF(UtilConfig.Default.LINHA_COMPRIMIDA);
                if (!saidas[0].CodCliente.Equals(UtilConfig.Default.CLIENTE_PADRAO))
                {
                    imp.Pula(1);
                    imp.ImpColLF(0, "Recebido por:");
                    imp.ImpLF(UtilConfig.Default.LINHA_COMPRIMIDA);
                }



                imp.Pula(8);
                imp.Imp(imp.Normal);
                imp.Fim();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        private void ImprimirDAVComprimidoVip(List<SaidaPesquisa> saidas, decimal total, decimal totalAVista, decimal desconto, string porta)
        {
            var printer = new Printer(porta, PrinterType.Bematech);

            Loja loja = gerenciadorLoja.Obter(UtilConfig.Default.LOJA_PADRAO).ElementAt(0);
            Pessoa pessoaLoja = (Pessoa)gerenciadorPessoa.Obter(loja.CodPessoa).ElementAt(0);

            //chamando a função para impressão do texto
            printer.WriteLine(UtilConfig.Default.LINHA_COMPRIMIDA);
            if (saidas[0].TipoSaida == Saida.TIPO_ORCAMENTO)
                printer.WriteLine(StringUtil.PadBoth("DOCUMENTO AUXILIAR DE VENDA - ORCAMENTO", 42));
            else
                printer.WriteLine(StringUtil.PadBoth("DOCUMENTO AUXILIAR DE VENDA - PEDIDO", 42));
            printer.WriteLine(StringUtil.PadBoth("NAO E DOCUMENTO FISCAL - NAO E VALIDO COMO", 42));
            printer.WriteLine(StringUtil.PadBoth("RECIBO E COMO GARANTIA DE MERCADORIA", 42));
            printer.WriteLine(StringUtil.PadBoth("NAO COMPROVA PAGAMENTO", 42));
            printer.WriteLine(UtilConfig.Default.LINHA_COMPRIMIDA);

            printer.WriteLine(StringUtil.PadBoth(pessoaLoja.Nome, 42));
            printer.WriteLine(StringUtil.PadBoth(pessoaLoja.Endereco + "  Fone: " + pessoaLoja.Fone1, 42));
            printer.WriteLine(UtilConfig.Default.LINHA_COMPRIMIDA);


            Pessoa cliente = (Pessoa)gerenciadorPessoa.Obter(saidas[0].CodCliente).ElementAt(0);

            if (cliente.NomeFantasia.Length > 32)
                printer.WriteLine("Cliente: " + cliente.NomeFantasia.Substring(1, 32));
            else
                printer.WriteLine("Cliente: " + cliente.NomeFantasia);

            if (saidas.Count == 1)
            {
                printer.WriteLine("Pedido: " + saidas[0].CodSaida + "      Data: " + saidas[0].DataSaida.ToShortDateString());
                if (!string.IsNullOrEmpty(saidas[0].CupomFiscal))
                    printer.WriteLine("NFe: " + saidas[0].CupomFiscal);
            }
            printer.WriteLine(UtilConfig.Default.LINHA_COMPRIMIDA);
            printer.WriteLine("Cod    Produto");
            printer.WriteLine("       Qtdade   UN  Preco(R$) Subtotal(R$)");
            printer.WriteLine(UtilConfig.Default.LINHA_COMPRIMIDA);
            foreach (SaidaPesquisa saida in saidas)
            {
                if (saidas.Count > 1)
                {
                    printer.WriteLine("=> Documento: " + saida.CodSaida + " Data: " + saida.DataSaida.ToShortDateString() + " CF:" + saida.CupomFiscal + "\n");
                }

                List<SaidaProduto> saidaProdutos = gerenciadorSaidaProduto.ObterPorSaida(saida.CodSaida);
                foreach (SaidaProduto produto in saidaProdutos)
                {
                    printer.Write(produto.CodProduto.ToString().PadLeft(6));
                    printer.Write(" ");
                    if (produto.Nome.Length > 33)
                        printer.WriteLine(produto.Nome.Substring(1, 33));
                    else
                        printer.WriteLine(produto.Nome.PadRight(33));
                    printer.Write("      ");
                    printer.Write(produto.Quantidade.ToString().PadLeft(9));
                    printer.Write(" ");
                    printer.Write(produto.Unidade);
                    printer.Write(produto.ValorVenda.ToString("N2").PadLeft(12));
                    printer.Write(" ");
                    printer.WriteLine(produto.Subtotal.ToString("N2").PadLeft(11));
                }
            }

            printer.WriteLine(UtilConfig.Default.LINHA_COMPRIMIDA);
            printer.WriteLine("Total Venda: " + total + " Desconto: " + desconto.ToString("N2") + "%");
            printer.WriteLine("Total Pagar: " + totalAVista.ToString("N2"));
            printer.WriteLine(UtilConfig.Default.LINHA_COMPRIMIDA);
            printer.WriteLine(" E vedada a autenticacao deste documento");
            if (!saidas[0].CupomFiscal.Equals(""))
            {
                printer.WriteLine("  Documento Válido por 3 (tres) dias");
            }
            printer.WriteLine(UtilConfig.Default.LINHA_COMPRIMIDA);
            if (!saidas[0].CodCliente.Equals(UtilConfig.Default.CLIENTE_PADRAO))
            {
                printer.WriteLine(" ");
                printer.WriteLine("Recebido por:");
                //printer.WriteLine(UtilConfig.Default.LINHA_COMPRIMIDA);
            }

            try
            {
                // 2 cópias
                printer.WriteLine(" ");
                printer.WriteLine(" ");
                printer.WriteLine(" ");
                printer.WriteLine(" ");
                printer.WriteLine(" ");
                printer.PartialPaperCut();
                printer.PrintDocument(2);

            }
            catch (Exception e)
            {
                throw new NegocioException("Impressora indisponível. Verificar se ela está ligada e conectada.", e);
            }

        }


        public void ImprimirCreditoPagamento(Saida saidaCredito, string portaImpressora)
        {
            var printer = new Printer(portaImpressora, PrinterType.Bematech);
            Loja loja = gerenciadorLoja.Obter(UtilConfig.Default.LOJA_PADRAO).ElementAt(0);
            Pessoa pessoaLoja = (Pessoa)gerenciadorPessoa.Obter(loja.CodPessoa).ElementAt(0);

            printer.WriteLine(UtilConfig.Default.LINHA_COMPRIMIDA);

            printer.WriteLine(StringUtil.PadBoth("DOCUMENTO AUXILIAR DE VENDA - CREDITO", 42));
            printer.WriteLine(StringUtil.PadBoth("NAO E DOCUMENTO FISCAL - NAO E VALIDO COMO", 42));
            printer.WriteLine(StringUtil.PadBoth("RECIBO E COMO GARANTIA DE MERCADORIA", 42));
            printer.WriteLine(UtilConfig.Default.LINHA_COMPRIMIDA);

            printer.WriteLine(StringUtil.PadBoth(pessoaLoja.Nome, 42));
            printer.WriteLine(StringUtil.PadBoth(pessoaLoja.Endereco + "  Fone: " + pessoaLoja.Fone1, 42));
            printer.WriteLine(UtilConfig.Default.LINHA_COMPRIMIDA);
            Pessoa cliente = gerenciadorPessoa.Obter(saidaCredito.CodCliente).ElementAt(0);

            printer.WriteLine("Cliente: " + cliente.NomeFantasia);
            printer.WriteLine("Data/Hora: " + saidaCredito.DataSaida);

            printer.WriteLine(UtilConfig.Default.LINHA_COMPRIMIDA);
            printer.WriteLine(" ");
            printer.WriteLine("Foi creditado na conta do cliente R$ " + saidaCredito.TotalAVista);
            printer.WriteLine(" ");

            printer.WriteLine(" ");
            printer.WriteLine(UtilConfig.Default.LINHA_COMPRIMIDA);
            printer.WriteLine(" ");
            printer.WriteLine("Recebido por:");
            printer.WriteLine(UtilConfig.Default.LINHA_COMPRIMIDA);

            try
            {
                printer.WriteLine(" ");
                printer.WriteLine(" ");
                printer.WriteLine(" ");
                printer.WriteLine(" ");
                printer.PartialPaperCut();
                printer.PrintDocument();

            }
            catch (Exception e)
            {
                throw new NegocioException("Impressora indisponível. Verificar se ela está ligada e conectada.", e);
            }
        }

        /// <summary>
        /// Atribui entidade para entidade persistente
        /// </summary>
        /// <param name="saida"></param>
        /// <param name="_saida"></param>
        private static void Atribuir(Saida saida, TbSaidum _saida)
        {
            _saida.BaseCalculoIcms = saida.BaseCalculoICMS;
            _saida.BaseCalculoIcmssubst = saida.BaseCalculoICMSSubst;
            _saida.CodCliente = saida.CodCliente;
            _saida.CodEmpresaFrete = saida.CodEmpresaFrete;
            _saida.CodProfissional = saida.CodProfissional;
            _saida.CodSituacaoPagamentos = saida.CodSituacaoPagamentos;
            _saida.CodTipoSaida = saida.TipoSaida;
            _saida.CpfCnpj = saida.CpfCnpj;
            _saida.DataSaida = saida.DataSaida;
            _saida.Desconto = saida.Desconto;
            _saida.EntregaRealizada = saida.EntregaRealizada;
            _saida.EspecieVolumes = saida.EspecieVolumes;
            _saida.Marca = saida.Marca;
            _saida.Nfe = saida.Nfe;
            _saida.Numero = saida.Numero;
            _saida.NumeroCartaoVenda = saida.NumeroCartaoVenda;
            _saida.OutrasDespesas = saida.OutrasDespesas;
            _saida.PedidoGerado = saida.CupomFiscal;
            _saida.DataEmissaoDocFiscal = saida.DataEmissaoCupomFiscal;
            _saida.PesoBruto = saida.PesoBruto;
            _saida.PesoLiquido = saida.PesoLiquido;
            _saida.QuantidadeVolumes = saida.QuantidadeVolumes;
            _saida.Total = saida.Total;
            _saida.TotalAvista = saida.TotalAVista;
            _saida.TotalLucro = saida.TotalLucro;
            _saida.TotalNotaFiscal = saida.TotalNotaFiscal;
            _saida.TotalPago = saida.TotalPago;
            _saida.Troco = saida.Troco;
            _saida.ValorFrete = saida.ValorFrete;
            _saida.ValorIcms = saida.ValorICMS;
            _saida.ValorIcmssubst = saida.ValorICMSSubst;
            _saida.ValorIpi = saida.ValorIPI;
            _saida.ValorSeguro = saida.ValorSeguro;
            _saida.Observacao = saida.Observacao;
            _saida.CodEntrada = saida.CodEntrada;
            _saida.CodLojaOrigem = saida.CodLojaOrigem;
            _saida.TipoDocumentoFiscal = saida.TipoDocumentoFiscal;
        }
    }
}