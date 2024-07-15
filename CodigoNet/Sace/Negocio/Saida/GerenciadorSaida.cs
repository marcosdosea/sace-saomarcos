using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Util;
using Vip.Printer;
using Vip.Printer.Enums;

namespace Negocio
{
    public static class GerenciadorSaida
    {
        /// <summary>
        /// Insere dados de uma saída (orçamento/pré-venda/venda/saída depósito)
        /// </summary>
        /// <param name="saida"></param>
        /// <returns></returns>
        public static long Inserir(Saida saida)
        {
            try
            {
                var _saida = new TbSaidum();
                Atribuir(saida, _saida);
                using (var context = new SaceContext())
                {
                    context.Add(_saida);
                    context.SaveChanges();
                }
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
        public static void Atualizar(Saida saida)
        {
            try
            {
                using (var context = new SaceContext())
                {
                    var _saida = context.TbSaida.FirstOrDefault(s => s.CodSaida == saida.CodSaida);

                    if (_saida != null)
                    {
                        Atribuir(saida, _saida);
                        context.Update(saida);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new NegocioException("Não foi possível atualizar a saída");
                    }
                }
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
        public static void Atualizar(Saida saida, SaceContext context)
        {
            try
            {
                var _saida = context.TbSaida.FirstOrDefault(s => s.CodSaida == saida.CodSaida);

                if (_saida != null)
                {
                    Atribuir(saida, _saida);
                    context.Update(saida);
                    context.SaveChanges();
                }
                else
                {
                    throw new NegocioException("Não foi possível atualizar a saída");
                }

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
        public static void AtualizarSituacaoPagamentoPorSaida(int codSituacaoPagamentos, long codSaida)
        {
            try
            {
                using (var context = new SaceContext())
                {
                    var query = from saidaE in context.TbSaida
                                where saidaE.CodSaida == codSaida
                                select saidaE;

                    foreach (TbSaidum _saida in query)
                    {
                        _saida.CodSituacaoPagamentos = codSituacaoPagamentos;
                        context.Update(_saida);
                    }

                    context.SaveChanges();
                }
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
        public static void AtualizarPorPedido(string nfe, string observacao, long codCliente, string pedidoGerado)
        {
            try
            {
                using (var context = new SaceContext())
                {
                    var query = from saidaE in context.TbSaida
                                where saidaE.PedidoGerado.Equals(pedidoGerado)
                                select saidaE;
                    foreach (TbSaidum _saida in query)
                    {
                        _saida.Nfe = nfe;
                        _saida.Observacao = observacao;
                        _saida.CodCliente = codCliente;
                        context.Update(_saida);
                    }
                    context.SaveChanges();
                }
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
        public static void AtualizarTipoDocumentoFiscal(long codSaida, string tipoDocumento)
        {
            try
            {
                using (var context = new SaceContext())
                {
                    var query = from saidaE in context.TbSaida
                                where saidaE.CodSaida.Equals(codSaida)
                                select saidaE;
                    foreach (TbSaidum _saida in query)
                    {
                        _saida.TipoDocumentoFiscal = tipoDocumento;
                        context.Update(_saida);
                    }
                    context.SaveChanges();
                }
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
        public static void AtualizarSaidasPorNfeSituacao(NfeControle nfeControle)
        {
            try
            {
                using (var context = new SaceContext())
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
                            context.Update(saida);
                        }
                    }
                    context.SaveChanges();
                }
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
        public static void AtualizarNfePorCodSaida(string nfe, string observacao, long codSaida)
        {
            try
            {
                using (var context = new SaceContext())
                {
                    var query = from saidaE in context.TbSaida
                                where saidaE.CodSaida == codSaida
                                select saidaE;
                    foreach (TbSaidum _saida in query)
                    {
                        _saida.Nfe = nfe;
                        _saida.Observacao = observacao;
                        context.Update(_saida);
                    }
                    context.SaveChanges();
                }
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
        public static void Remover(Saida saida)
        {
            using (var context = new SaceContext())
            {
                try
                {
                    context.Database.BeginTransaction();

                    List<NfeControle> listaNfeControle = GerenciadorNFe.ObterPorSaida(saida.CodSaida).ToList();
                    if (listaNfeControle.Where(nfe => nfe.SituacaoNfe.Equals(NfeControle.SITUACAO_AUTORIZADA)).Count() > 0)
                        throw new NegocioException("Não é possível remover saídas / devoluções com NF-e AUTORIZADAS pelo sistema");

                    if ((listaNfeControle.Count() > 0) && (saida.TipoSaida.Equals(Saida.TIPO_ORCAMENTO)))
                        throw new NegocioException("Não é possível remover pedidos com NF-e associadas");


                    GerenciadorSaidaPagamento.RemoverPorSaida(saida);

                    if (saida.TipoSaida.Equals(Saida.TIPO_CREDITO))
                    {
                        List<Conta> listaContas = GerenciadorConta.ObterPorSaida(saida.CodSaida).ToList();
                        GerenciadorSolicitacaoDocumento.Remover(saida.CodSaida);
                        foreach (Conta conta in listaContas)
                        {
                            GerenciadorConta.Remover(conta.CodConta);
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
                        RegistrarEstornoEstoque(saida, null, context);
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
                        List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.ObterPorSaida(saida.CodSaida);
                        RegistrarBaixaEstoque(saidaProdutos, context);
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
                        GerenciadorSolicitacaoDocumento.Remover(saida.CodSaida);
                        RegistrarEstornoEstoque(saida, null, context);
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
        }



        /// <summary>
        /// Verifica se é possível editar um saída e caso possível tranforma-a em um orçamento
        /// </summary>
        /// <param name="saida"></param>
        public static void PrepararEdicaoSaida(Saida saida)
        {
            using (var context = new SaceContext())
            {
                context.Database.BeginTransaction();
                try
                {
                    if (saida.TipoSaida == Saida.TIPO_CREDITO)
                        throw new NegocioException("Não é possível editar créditos. Se necessário, exclua o crédito e lançe um novo.");

                    if (saida.TipoSaida == Saida.TIPO_VENDA)
                        throw new NegocioException("Não é possível editar uma saída cujo Comprovante Fiscal já foi emitido.");


                    bool possuiNfeAutorizada = GerenciadorNFe.ObterPorSaida(saida.CodSaida).Where(nfe => nfe.SituacaoNfe.Equals(NfeControle.SITUACAO_AUTORIZADA)).Count() > 0;
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
                        IEnumerable<SaidaPagamento> pagamentos = GerenciadorSaidaPagamento.ObterPorSaida(saida.CodSaida);
                        // houve pagamento não realizado em dinheiro
                        if (pagamentos.Where(p => p.CodFormaPagamento.Equals(FormaPagamento.DINHEIRO)).Count() != pagamentos.Count())
                        {
                            IEnumerable<Conta> contas = GerenciadorConta.ObterPorSaida(saida.CodSaida);
                            foreach (Conta conta in contas)
                            {
                                bool possuiMovimentacaoFinanceira = GerenciadorMovimentacaoConta.ObterPorConta(conta.CodConta).Count() > 0;
                                if (possuiMovimentacaoFinanceira)
                                    throw new NegocioException("Não é possível editar pedidos que já possuem PAGAMENTOS REALIZADOS.");
                            }
                        }
                    }
                    // Se houver documento fiscal aguardando impressão
                    if (saida.TipoSaida == Saida.TIPO_PRE_VENDA)
                    {
                        GerenciadorSolicitacaoDocumento.Remover(saida.CodSaida);
                    }

                    GerenciadorSaidaPagamento.RemoverPorSaida(saida);
                    if (saida.TipoSaida.Equals(Saida.TIPO_PRE_VENDA) || saida.TipoSaida.Equals(Saida.TIPO_REMESSA_DEPOSITO) ||
                        saida.TipoSaida.Equals(Saida.TIPO_RETORNO_DEPOSITO) || saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_FORNECEDOR) ||
                        saida.TipoSaida.Equals(Saida.TIPO_BAIXA_ESTOQUE_PERDA) || saida.TipoSaida.Equals(Saida.TIPO_USO_INTERNO) ||
                        saida.TipoSaida.Equals(Saida.TIPO_RETORNO_FORNECEDOR))
                    {
                        RegistrarEstornoEstoque(saida, null, context);
                    }
                    if (saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_CONSUMIDOR))
                    {
                        List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.ObterPorSaida(saida.CodSaida);
                        RegistrarBaixaEstoque(saidaProdutos, context);
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
                    context.Database.CommitTransaction();
                }
                catch (Exception e)
                {
                    context.Database.RollbackTransaction();
                    throw new DadosException("Saída", e.Message, e);
                }
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private static IQueryable<Saida> GetQuery()
        {
            using (var context = new SaceContext())
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
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private static IQueryable<SaidaPesquisa> GetQueryPesquisa()
        {
            using (var context = new SaceContext())
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
        }

        /// <summary>
        /// Obtme todos os dados de uma saída
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public static Saida Obter(long codSaida)
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
        public static List<Saida> ObterPorTipoSaida(List<int> listaTiposSaida)
        {
            return GetQuery().Where(saida => listaTiposSaida.Contains(saida.TipoSaida)).OrderBy(s => s.CodSaida).ToList();
        }

        /// <summary>
        /// Obtem saidas pela data do pedido informada
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static object ObterPorDataPedido(string data)
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
        public static List<SaidaPesquisa> ObterPorCupomFiscal(String cupomFiscal)
        {
            using (var context = new SaceContext())
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
        }

        public static List<SaidaPesquisa> ObterSaidaPorNfe(int codNfe)
        {
            using (var context = new SaceContext())
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
        }

        /// <summary>
        /// Obtme todos os dados de uma saída
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public static List<Saida> ObterSaidaConsumidor(long codSaidaInicial)
        {
            List<int> listaCodSaidasExibir = new List<int>();
            listaCodSaidasExibir.AddRange(Saida.LISTA_TIPOS_VENDA);
            listaCodSaidasExibir.Add(Saida.TIPO_BAIXA_ESTOQUE_PERDA);
            listaCodSaidasExibir.Add(Saida.TIPO_USO_INTERNO);
            using (var context = new SaceContext())
            {
                var query = (from saida in context.TbSaida
                             where (listaCodSaidasExibir.Contains(saida.CodTipoSaida) && (saida.CodSaida >= codSaidaInicial))
                             orderby saida.CodSaida descending
                             select saida.CodSaida).Take(20);
                List<long> listaSaidas = query.ToList();

                return GetQuery().Where(saida => listaCodSaidasExibir.Contains(saida.TipoSaida) && (saida.CodSaida >= listaSaidas.Min() || saida.CodSaida == codSaidaInicial)).OrderBy(s => s.CodSaida).ToList();
            }
        }


        /// <summary>
        /// Obtme todos os dados de uma saída
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public static List<Saida> ObterSaidaPorAno(int ano)
        {
            return GetQuery().Where(saida => saida.DataSaida.Year == 2017).OrderBy(s => s.CodSaida).ToList();

        }
        /// <summary>
        /// Obter Troco por Período para todos os pagamentos
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public static decimal ObterTrocoPagamentos(DateTime dataInicial, DateTime dataFinal)
        {
            using (var context = new SaceContext())
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
        }

        /// <summary>
        /// Obter Troco por Período apenas para Saidas
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public static decimal ObterTrocoSaidas(DateTime dataInicial, DateTime dataFinal)
        {
            using (var context = new SaceContext())
            {
                var query = (from saida in context.TbSaida
                             where (saida.CodTipoSaida == Saida.TIPO_PRE_VENDA || saida.CodTipoSaida == Saida.TIPO_VENDA)
                                   && saida.DataSaida >= dataInicial
                                   && saida.DataSaida <= dataFinal
                             select saida.Troco);

                return query.Count() > 0 ? (decimal)query.Sum() : 0;
            }
        }

        /// <summary>
        /// Obtem todos as pré-vendas cujo cupom fiscal não foi emitido
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public static List<SaidaPesquisa> ObterPorPedido(string pedidoGerado)
        {
            using (var context = new SaceContext())
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
        }

        /// <summary>
        /// Obtme todos as pré-vendas cujo cupom fiscal não foi emitido
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public static List<SaidaPesquisa> ObterPorCodSaidas(List<long> listaCodSaidas)
        {
            using (var context = new SaceContext())
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
        }


        /// <summary>
        /// Obtme todos as pré-vendas cujo cupom fiscal não foi emitido
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public static List<SaidaPesquisa> ObterPorSolicitacaoSaida(List<SolicitacaoSaida> listaSolicitacaoSaida)
        {
            List<long> listaCodSaida = listaSolicitacaoSaida.Select(s => s.CodSaida).ToList();
            using (var context = new SaceContext())
            {
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
        }


        /// <summary>
        /// Obtme todos as pré-vendas cujo cupom fiscal não foi emitido
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public static List<SaidaPesquisa> ObterPorNomeCliente(string nomeCliente)
        {
            return GetQueryPesquisa().Where(saida => saida.NomeCliente.StartsWith(nomeCliente)).OrderBy(s => s.CodSaida).ToList();
        }

        /// <summary>
        /// Obtme todos as pré-vendas cujo cupom fiscal não foi emitido
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public static List<SaidaPesquisa> ObterPreVendasPendentes()
        {
            return GetQueryPesquisa().Where(saida => saida.TipoSaida == Saida.TIPO_PRE_VENDA &&
                saida.CupomFiscal.Trim().Equals("") && saida.CodSituacaoPagamentos == SituacaoPagamentos.QUITADA && saida.CodCliente == UtilConfig.Default.CLIENTE_PADRAO).OrderBy(s => s.CodSaida).ToList();
        }


        /// <summary>
        /// Obtme todos as pré-vendas cujo cupom fiscal não foi emitido
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public static List<Saida> ObterVendasParticipacaoLucros(DateTime dataInicial, DateTime dataFinal, decimal valorVenda)
        {
            return GetQuery().Where(saida => (saida.TipoSaida == Saida.TIPO_PRE_VENDA || saida.TipoSaida == Saida.TIPO_VENDA || saida.TipoSaida == Saida.TIPO_BAIXA_ESTOQUE_PERDA || saida.TipoSaida == Saida.TIPO_USO_INTERNO) &&
                saida.CodCliente != 1324 &&
                saida.DataSaida >= dataInicial &&
                saida.DataSaida <= dataFinal &&
                saida.TotalAVista >= valorVenda).ToList();
        }

        public static NumerosPeriodo ObterVendasMensalComparandoAnoAnterior()
        {
            DateTime dataAtual = DateTime.Now.AddDays(-1);
            using (var context = new SaceContext())
            {
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
        }



        /// <summary>
        /// Obter cfop padrão de um determinado tipo de saída do sistema
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int ObterCfopTipoSaida(int codTipoSaida)
        {
            using (var context = new SaceContext())
            {
                var query = from tipoSaida in context.TbTipoSaida
                            where tipoSaida.CodTipoSaida == codTipoSaida
                            select tipoSaida.Cfop;
                return query.ToList().FirstOrDefault();
            }
        }

        /// <summary>
        /// Obtém somatório de vendas por grupo de produtos em um dado período de tempo
        /// </summary>
        /// <param name="codGrupo"></param>
        /// <param name="dataInicial"></param>
        /// <param name="dataFinal"></param>
        /// <returns></returns>
        public static List<VendasGrupoProduto> ObterVendasPorGrupo(int codGrupo, DateTime dataInicial, DateTime dataFinal)
        {
            using (var context = new SaceContext())
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
        }

        public static List<VendasVendedor> ObterVendasPorVendedor(DateTime dataInicial, DateTime dataFinal)
        {
            dataInicial = dataInicial.Date;
            dataFinal = dataFinal.Date.AddDays(1);
            using (var context = new SaceContext())
            {
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
        }




        /// <summary>
        /// Encerra uma saída fazendo movimentações de estoque e lançamentos no contas a pagar/receber
        /// </summary>
        /// <param name="saida"></param>
        /// <param name="tipo_encerramento"></param>
        public static void Encerrar(Saida saida, int tipo_encerramento, List<SaidaPagamento> saidaPagamentos, Pessoa cliente)
        {
            using (var context = new SaceContext())
            {
                context.Database.BeginTransaction();
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

                        List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.ObterPorSaida(saida.CodSaida);
                        Decimal somaPrecosCusto = RegistrarBaixaEstoque(saidaProdutos, context);

                        saida.TotalLucro = saida.TotalAVista - somaPrecosCusto;
                        Atualizar(saida);

                        RegistrarPagamentosSaida(saidaPagamentos, saida, context);
                    }
                    else if (tipo_encerramento.Equals(Saida.TIPO_BAIXA_ESTOQUE_PERDA) || tipo_encerramento.Equals(Saida.TIPO_USO_INTERNO))
                    {
                        saida.TipoSaida = tipo_encerramento;
                        saida.CodSituacaoPagamentos = SituacaoPagamentos.QUITADA;

                        List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.ObterPorSaida(saida.CodSaida);
                        Decimal somaPrecosCusto = RegistrarBaixaEstoque(saidaProdutos, context);
                        saida.TotalLucro = 0;
                        saida.TotalLucro -= somaPrecosCusto;
                        Atualizar(saida);
                    }
                    else if (tipo_encerramento.Equals(Saida.TIPO_REMESSA_DEPOSITO))
                    {
                        saida.TipoSaida = Saida.TIPO_REMESSA_DEPOSITO;

                        Loja lojaDestino = GerenciadorLoja.ObterPorPessoa(saida.CodCliente).ElementAt(0);
                        if (lojaDestino.CodLoja.Equals(saida.CodLojaOrigem))
                        {
                            throw new NegocioException("Não pode ser feita transferência de produtos para a mesma loja.");
                        }

                        List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.ObterPorSaida(saida.CodSaida);
                        Atualizar(saida);
                        RegistrarTransferenciaEstoque(saidaProdutos, UtilConfig.Default.LOJA_PADRAO, lojaDestino.CodLoja, context);
                    }
                    else if (tipo_encerramento.Equals(Saida.TIPO_RETORNO_DEPOSITO))
                    {
                        saida.TipoSaida = Saida.TIPO_RETORNO_DEPOSITO;
                        if (saida.CodLojaOrigem.Equals(UtilConfig.Default.LOJA_PADRAO))
                        {
                            throw new NegocioException("Não pode ser feita transferência de produtos para a mesma loja.");
                        }
                        Atualizar(saida);
                        List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.ObterPorSaida(saida.CodSaida);
                        RegistrarTransferenciaEstoque(saidaProdutos, saida.CodLojaOrigem, UtilConfig.Default.LOJA_PADRAO, context);
                    }
                    else if (tipo_encerramento.Equals(Saida.TIPO_DEVOLUCAO_FORNECEDOR))
                    {
                        saida.TipoSaida = Saida.TIPO_DEVOLUCAO_FORNECEDOR;
                        Atualizar(saida);
                        List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.ObterPorSaida(saida.CodSaida);
                        RegistrarBaixaEstoque(saidaProdutos, context);
                        AtualizarCfopProdutosDevolucao(saidaProdutos, saida, context);
                    }
                    else if (tipo_encerramento.Equals(Saida.TIPO_REMESSA_CONSERTO))
                    {
                        saida.TipoSaida = Saida.TIPO_REMESSA_CONSERTO;
                        Atualizar(saida);
                        List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.ObterPorSaida(saida.CodSaida);
                        RegistrarBaixaEstoque(saidaProdutos, context);
                        //AtualizarCfopProdutosDevolucao(saidaProdutos, saida);
                    }
                    context.Database.CommitTransaction();
                }
                catch (NegocioException ne)
                {
                    context.Database.RollbackTransaction();
                    throw ne;
                }
                catch (DadosException de)
                {
                    context.Database.RollbackTransaction();
                    throw de;
                }
                catch (Exception e)
                {
                    context.Database.RollbackTransaction();
                    throw new DadosException("Problemas no encerramento da saída. Favor contactar o administrador.", e);
                }

            }
        }

        /// <summary>
        /// Faz o encerramento de um devolução de produtos pelo consumidor
        /// </summary>
        /// <param name="saida"></param>
        /// <param name="consumidor"></param>
        public static void EncerrarDevolucaoConsumidor(Saida saida)
        {
            using (var context = new SaceContext())
            {
                context.Database.BeginTransaction();
                try
                {
                    saida.TipoSaida = Saida.TIPO_DEVOLUCAO_CONSUMIDOR;
                    //saida.CodCliente = consumidor.CodPessoa;
                    Atualizar(saida);
                    List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.ObterPorSaida(saida.CodSaida);
                    RegistrarEstornoEstoque(saida, saidaProdutos, context);
                    AtualizarCfopProdutosDevolucao(saidaProdutos, saida, context);
                    context.Database.CommitTransaction();
                }
                catch (NegocioException ne)
                {
                    context.Database.RollbackTransaction();
                    throw ne;
                }
                catch (DadosException de)
                {
                    context.Database.RollbackTransaction();
                    throw de;
                }
                catch (Exception e)
                {
                    context.Database.RollbackTransaction();
                    throw new DadosException("Problemas no encerramento da saída. Favor contactar o administrador.", e);
                }

            }
        }

        /// <summary>
        /// Faz o encerramento de um retorno de mercadorias que o fornecedor não aceitou a devolução
        /// </summary>
        /// <param name="saida"></param>
        /// <param name="consumidor"></param>
        public static void EncerrarRetornoFornecedor(Saida saida)
        {
            using (var context = new SaceContext())
            {
                try
                {
                    context.Database.BeginTransaction();
                    saida.TipoSaida = Saida.TIPO_RETORNO_FORNECEDOR;
                    Atualizar(saida);
                    List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.ObterPorSaida(saida.CodSaida);
                    RegistrarEstornoEstoque(saida, saidaProdutos, context);
                    AtualizarCfopProdutosDevolucao(saidaProdutos, saida, context);
                    context.Database.CommitTransaction();
                }
                catch (NegocioException ne)
                {
                    context.Database.RollbackTransaction();
                    throw ne;
                }
                catch (DadosException de)
                {
                    context.Database.RollbackTransaction();
                    throw de;
                }
                catch (Exception e)
                {
                    context.Database.RollbackTransaction();
                    throw new DadosException("Problemas no encerramento da saída. Favor contactar o administrador.", e);
                }
            }

        }

        /// <summary>
        /// Atualiza os cfops de produtos de acordo com os dados de devolução na NF-e
        /// </summary>
        /// <param name="saidaProdutos"></param>
        /// <param name="_saida"></param>
        private static void AtualizarCfopProdutosDevolucao(List<SaidaProduto> saidaProdutos, Saida saida, SaceContext context)
        {
            Pessoa fornecedor = GerenciadorPessoa.Obter(saida.CodCliente).ElementAtOrDefault(0);
            Loja loja = GerenciadorLoja.Obter(UtilConfig.Default.LOJA_PADRAO).ElementAtOrDefault(0);
            Pessoa pessoaLoja = GerenciadorPessoa.Obter(loja.CodPessoa).ElementAtOrDefault(0);

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
                var _saidaProduto = context.TbSaidaProdutos.FirstOrDefault(sp => sp.CodSaidaProduto == saidaProduto.CodSaidaProduto);
                if (_saidaProduto != null)
                {
                    _saidaProduto.Cfop = saidaProduto.CodCfop;
                    context.SaveChanges();
                }
            }
        }
        /// <summary>
        /// Calculo do toatal da nota de acordo com a existência de substituição tributária
        /// </summary>
        /// <param name="saida"></param>
        /// <returns></returns>
        public static decimal ObterTotalNotaFiscal(Saida saida)
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
        public static bool DataVencimentoProdutoAceitavel(ProdutoPesquisa produto, DateTime dataVencimento)
        {
            if ((bool)produto.TemVencimento)
            {
                DateTime dataMaisAntigo = GerenciadorEntradaProduto.GetDataProdutoMaisAntigoEstoque(produto);
                return (dataMaisAntigo >= dataVencimento);
            }
            return true;
        }

        /// <summary>
        /// Regista formas de pagamentos de uma saída
        /// </summary>
        /// <param name="pagamentos"></param>
        /// <param name="saida"></param>
        public static void RegistrarPagamentosSaida(List<SaidaPagamento> pagamentos, Saida saida, SaceContext context)
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
                conta.CodConta = GerenciadorConta.Inserir(conta, context);
            }


            foreach (SaidaPagamento pagamento in pagamentos)
            {

                List<Conta> contas = GerenciadorConta.ObterPorSaidaPagamento(saida.CodSaida, pagamento.CodSaidaPagamento).ToList();

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
                    conta.CodPessoa = GerenciadorCartaoCredito.Obter(pagamento.CodCartaoCredito).ElementAt(0).CodPessoa;
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
                        CartaoCredito cartaoCredito = GerenciadorCartaoCredito.Obter(pagamento.CodCartaoCredito).ElementAt(0);
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

                    conta.CodConta = GerenciadorConta.Inserir(conta, context);
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

                    GerenciadorMovimentacaoConta.Inserir(movimentacao, context);
                }
            }
        }

        /// <summary>
        /// Registra estorno de estoque no caso de devolução ou exclusão da saída
        /// No caso de devolução do consumidor o estoque é incrementado.
        /// </summary>
        /// <param name="saidaProdutos"></param>
        public static void RegistrarEstornoEstoque(Saida saida, List<SaidaProduto> saidaProdutos, SaceContext context)
        {
            if (saidaProdutos == null)
                saidaProdutos = GerenciadorSaidaProduto.ObterPorSaida(saida.CodSaida);
            foreach (SaidaProduto saidaProduto in saidaProdutos)
            {
                if (saidaProduto.CodCST != Cst.ST_OUTRAS)
                {
                    GerenciadorProdutoLoja.AdicionaQuantidade(saidaProduto.Quantidade, 0, UtilConfig.Default.LOJA_PADRAO, saidaProduto.CodProduto, context);
                }
                else
                {
                    GerenciadorProdutoLoja.AdicionaQuantidade(0, saidaProduto.Quantidade, UtilConfig.Default.LOJA_PADRAO, saidaProduto.CodProduto, context);
                }
                saidaProduto.Quantidade *= (-1); // inverte sinal da quantidade para fazer o retorno
                GerenciadorEntradaProduto.BaixarItensVendidosEstoque(saidaProduto, context);
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Decrementa a quantidade de produtos na loja matriz e atualiza o lote de
        /// entrada determinando que produtos foram vendidos de um determinado lote.
        /// </summary>
        /// <param name="saidaProdutos"></param>
        /// <returns> A soma dos preços de custo dos produtos baixados para determinar o lucro</returns>
        private static decimal RegistrarBaixaEstoque(List<SaidaProduto> saidaProdutos, SaceContext context)
        {
            decimal somaPrecosCusto = 0;
            foreach (SaidaProduto saidaProduto in saidaProdutos)
            {
                var produto = GerenciadorProduto.Obter(new ProdutoPesquisa() { CodProduto = saidaProduto.CodProduto });

                // Baixa sempre o estoque da loja matriz
                if (saidaProduto.CodCST != Cst.ST_OUTRAS)
                {
                    GerenciadorProdutoLoja.AdicionaQuantidade(saidaProduto.Quantidade * (-1), 0, UtilConfig.Default.LOJA_PADRAO, saidaProduto.CodProduto, context);
                }
                else
                {
                    GerenciadorProdutoLoja.AdicionaQuantidade(0, saidaProduto.Quantidade * (-1), UtilConfig.Default.LOJA_PADRAO, saidaProduto.CodProduto, context);
                }

                decimal custoAtual = produto.PrecoCusto * saidaProduto.Quantidade;
                decimal custoEstoque = GerenciadorEntradaProduto.BaixarItensVendidosEstoque(saidaProduto, context);
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
        private static void RegistrarTransferenciaEstoque(List<SaidaProduto> saidaProdutos, int lojaOrigem, int lojaDestino, SaceContext context)
        {
            foreach (SaidaProduto saidaProduto in saidaProdutos)
            {
                GerenciadorProdutoLoja.AdicionaQuantidade(saidaProduto.Quantidade * (-1), 0, lojaOrigem, saidaProduto.CodProduto, context);
                GerenciadorProdutoLoja.AdicionaQuantidade(saidaProduto.Quantidade, 0, lojaDestino, saidaProduto.CodProduto, context);
            }
        }

        /// <summary>
        /// Receber pagamentos Contas
        /// </summary>
        public static void ReceberPagamentosContas(List<ContaSaida> listaContaSaida, List<SaidaPagamento> pagamentos, List<MovimentacaoConta> listaMovimentacaoConta, Saida saida)
        {
            using (var context = new SaceContext())
            {
                try
                {
                    context.Database.BeginTransaction();

                    RegistrarPagamentosSaida(pagamentos, saida, context);

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
        }



        public static List<SaidaProduto> ExcluirProdutosDevolvidosMesmoPreco(List<SaidaProduto> saidaProdutos)
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


        public static bool SolicitaImprimirDAV(List<long> listaCodSaidas, decimal total, decimal totalAVista, decimal desconto, Impressora.Tipo impressora)
        {
            using (var context = new SaceContext())
            {
                string tipoDocumento = impressora.Equals(Impressora.Tipo.REDUZIDO1) ? Impressora.REDUZIDO1 : Impressora.REDUZIDO2;

                if (GerenciadorImprimirDocumento.ObterPorTipoDocumentoCodDocumento(tipoDocumento, listaCodSaidas.Min()).Count() > 0)
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
        }


        public static bool ImprimirDAV(Impressora.Tipo impressora, string portaImpressora)
        {
            using (var context = new SaceContext())
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
                        return ImprimirDAVComprimido(saidas, (decimal)documento.Total, (decimal)documento.TotalAvista, (decimal)documento.Desconto, portaImpressora);
                    else
                        ImprimirDAVComprimidoVip(saidas, (decimal)documento.Total, (decimal)documento.TotalAvista, (decimal)documento.Desconto, portaImpressora);
                }
                return true;
            }
        }

        private static bool ImprimirDAVComprimido(List<SaidaPesquisa> saidas, decimal total, decimal totalAVista, decimal desconto, string portaImpressora)
        {
            using (var context = new SaceContext())
            {
                try
                {
                    ImprimeTexto imp = new ImprimeTexto();
                    if (!imp.Inicio(portaImpressora))
                    {
                        return false;
                    }


                    Loja loja = GerenciadorLoja.Obter(UtilConfig.Default.LOJA_PADRAO).ElementAt(0);
                    Pessoa pessoaLoja = (Pessoa) GerenciadorPessoa.Obter(loja.CodPessoa).ElementAt(0);

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

                    Pessoa cliente = (Pessoa) GerenciadorPessoa.Obter(saidas[0].CodCliente).ElementAt(0);
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

                        List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.ObterPorSaida(saida.CodSaida);
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
        }


        private static void ImprimirDAVComprimidoVip(List<SaidaPesquisa> saidas, decimal total, decimal totalAVista, decimal desconto, string porta)
        {
            using (var context = new SaceContext())
            {
                var printer = new Printer(porta, PrinterType.Bematech);

                Loja loja = GerenciadorLoja.Obter(UtilConfig.Default.LOJA_PADRAO).ElementAt(0);
                Pessoa pessoaLoja = (Pessoa)GerenciadorPessoa.Obter(loja.CodPessoa).ElementAt(0);

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


                Pessoa cliente = (Pessoa)GerenciadorPessoa.Obter(saidas[0].CodCliente).ElementAt(0);

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

                    List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.ObterPorSaida(saida.CodSaida);
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
        }


        public static void ImprimirCreditoPagamento(Saida saidaCredito, string portaImpressora)
        {
            var printer = new Printer(portaImpressora, PrinterType.Bematech);
            Loja loja = GerenciadorLoja.Obter(UtilConfig.Default.LOJA_PADRAO).ElementAt(0);
            Pessoa pessoaLoja = (Pessoa) GerenciadorPessoa.Obter(loja.CodPessoa).ElementAt(0);

            printer.WriteLine(UtilConfig.Default.LINHA_COMPRIMIDA);

            printer.WriteLine(StringUtil.PadBoth("DOCUMENTO AUXILIAR DE VENDA - CREDITO", 42));
            printer.WriteLine(StringUtil.PadBoth("NAO E DOCUMENTO FISCAL - NAO E VALIDO COMO", 42));
            printer.WriteLine(StringUtil.PadBoth("RECIBO E COMO GARANTIA DE MERCADORIA", 42));
            printer.WriteLine(UtilConfig.Default.LINHA_COMPRIMIDA);

            printer.WriteLine(StringUtil.PadBoth(pessoaLoja.Nome, 42));
            printer.WriteLine(StringUtil.PadBoth(pessoaLoja.Endereco + "  Fone: " + pessoaLoja.Fone1, 42));
            printer.WriteLine(UtilConfig.Default.LINHA_COMPRIMIDA);
            Pessoa cliente = GerenciadorPessoa.Obter(saidaCredito.CodCliente).ElementAt(0);

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