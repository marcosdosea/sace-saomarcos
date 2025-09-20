using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Util;

namespace Negocio
{
    public static class GerenciadorSaidaPagamento
    {

        /// <summary>
        /// Insere um novo pagamento na saída
        /// </summary>
        /// <param name="saidaPagamento"></param>
        /// <param name="saida"></param>
        /// <returns></returns>
        public static long Inserir(SaidaPagamento saidaPagamento, Saida saida)
        {
            using (var context = new SaceContext())
            {
                try
                {
                    context.Database.BeginTransaction();

                    if ((saidaPagamento.Valor == 0) && ((saida.TotalAVista - saida.TotalPago) != 0))
                    {
                        throw new NegocioException("O valor recebido não pode ser igual a zero.");
                    }
                    else if ((saida.TotalAVista < 0) && (Math.Abs(saidaPagamento.Valor) > Math.Abs(saida.TotalAVista - saida.TotalPago)))
                    {
                        throw new NegocioException("O valor da devolução não pode ser maior que o valor dos produtos.");
                    }
                    else if (Math.Abs(saida.TotalAVista) < Math.Abs(saida.TotalPago))
                    {
                        throw new NegocioException("Não é necessário registrar mais outro pagamento.");
                    }
                    else if (saida.TipoSaida.Equals(Saida.TIPO_PRE_CREDITO) && (saida.CodCliente == Util.UtilConfig.Default.CLIENTE_PADRAO))
                    {
                        throw new NegocioException("É necessário informar o cliente que será creditado.");
                    }
                    else if (saida.TipoSaida.Equals(Saida.TIPO_PRE_CREDITO) && saidaPagamento.CodFormaPagamento.Equals(FormaPagamento.CREDIARIO))
                    {
                        throw new NegocioException("Forma de pagamento Crediário não pode ser utilizada para operação de crédito.");
                    }

                    else if ((saidaPagamento.CodFormaPagamento != FormaPagamento.DINHEIRO) && (saidaPagamento.CodFormaPagamento != FormaPagamento.CARTAO)
                        && (saidaPagamento.CodFormaPagamento != FormaPagamento.DEPOSITO_PIX) && (saida.CodCliente == Util.UtilConfig.Default.CLIENTE_PADRAO))
                    {
                        throw new NegocioException("É necessário informar um cliente para utilizar essa forma de pagamento.");
                    }
                    else if ((saidaPagamento.CodFormaPagamento == FormaPagamento.CARTAO) && (saidaPagamento.CodCartaoCredito == UtilConfig.Default.CARTAO_LOJA))
                    {
                        throw new NegocioException("Esse cartão de crédito não pode ser utilizado como forma de pagamento. Favor selecionar um novo cartão.");
                    }
                    else if ((saidaPagamento.CodFormaPagamento == FormaPagamento.BOLETO))
                    {
                        throw new NegocioException("Boletos não podem ser usados como forma de pagamento. Favor selecionar um nova forma de pagamento.");
                    }


                    //decimal total = totalPagamentos(saida.CodSaida);

                    if (Math.Abs(saida.TotalAVista - saida.TotalPago) > 0)
                    {
                        var _saidaPagamento = new TbSaidaFormaPagamento();
                        _saidaPagamento.CodCartao = saidaPagamento.CodCartaoCredito;
                        _saidaPagamento.CodContaBanco = saidaPagamento.CodContaBanco;
                        _saidaPagamento.CodFormaPagamento = saidaPagamento.CodFormaPagamento;
                        _saidaPagamento.CodSaida = saidaPagamento.CodSaida;
                        _saidaPagamento.Data = saidaPagamento.Data;
                        _saidaPagamento.IntervaloDias = saidaPagamento.IntervaloDias;
                        _saidaPagamento.Parcelas = (int)saidaPagamento.Parcelas;
                        _saidaPagamento.Valor = saidaPagamento.Valor;
                        _saidaPagamento.NumeroControle = String.IsNullOrEmpty(saidaPagamento.NumeroControle) ? "" : saidaPagamento.NumeroControle;


                        context.Add(_saidaPagamento);
                        context.SaveChanges();

                        var query = from saidaFormaPagamento in context.TbSaidaFormaPagamentos
                                    where saidaFormaPagamento.CodSaida == saida.CodSaida
                                    select saidaFormaPagamento;


                        saida.TotalPago = query.Sum(sp => (decimal)sp.Valor);
                        saida.Troco = saida.TotalPago - saida.TotalAVista;
                        saida.Desconto = 100 - ((saida.TotalAVista / saida.Total) * 100);

                    }
                    GerenciadorSaida.Atualizar(saida, context);
                    context.Database.CommitTransaction();
                }
                catch (Exception e)
                {
                    context.Database.RollbackTransaction();
                    throw new DadosException("Pagamentos", e.Message, e);
                }
                return 0;
            }
        }

        /// <summary>
        /// Remove todos os pagamentos de uma Saída
        /// </summary>
        /// <param name="saida"></param>
        public static void RemoverPorSaida(Saida saida)
        {
            using (var context = new SaceContext())
            {
                List<SaidaPagamento> listaSaidaPagamento = ObterPorSaida(saida.CodSaida);
                try
                {
                    context.Database.BeginTransaction();
                    foreach (SaidaPagamento saidaPagamento in listaSaidaPagamento)
                    {
                        if ((saida.TipoSaida == Saida.TIPO_PRE_VENDA) || (saida.TipoSaida == Saida.TIPO_VENDA) || (saida.TipoSaida == Saida.TIPO_CREDITO))
                        {
                            List<Conta> contas = GerenciadorConta.ObterPorSaidaPagamento(saida.CodSaida, saidaPagamento.CodSaidaPagamento).ToList();

                            foreach (Conta conta in contas)
                            {
                                GerenciadorMovimentacaoConta.RemoverPorConta(conta.CodConta, context);
                                context.Remove(new TbContum() { CodConta = conta.CodConta });
                            }
                        }
                        var query = from saidaPagamentoSet in context.TbSaidaFormaPagamentos
                                    where saidaPagamentoSet.CodSaidaFormaPagamento == saidaPagamento.CodSaidaPagamento
                                    select saidaPagamentoSet;

                        foreach (TbSaidaFormaPagamento _saidaPagamentoE in query)
                        {
                            context.Remove(_saidaPagamentoE);
                        }
                        context.SaveChanges();

                        saida.TotalPago = listaSaidaPagamento.Sum(sp => sp.Valor);
                        saida.Troco = saida.TotalPago - saida.TotalAVista;
                        saida.Desconto = 100 - ((saida.TotalAVista / saida.Total) * 100);
                        GerenciadorSaida.Atualizar(saida, context);
                    }
                    context.Database.CommitTransaction();
                }
                catch (Exception e)
                {
                    throw new DadosException("Problemas na exclusão de vários pagamentos.", e);
                }
            }
        }


        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private static IQueryable<SaidaPagamento> GetQuery(SaceContext context)
        {
            var query = from saidaPagamento in context.TbSaidaFormaPagamentos
                        select new SaidaPagamento
                        {
                            CodCartaoCredito = saidaPagamento.CodCartao,
                            CodContaBanco = saidaPagamento.CodContaBanco,
                            DescricaoContaBanco = saidaPagamento.CodContaBancoNavigation.Descricao,
                            CodFormaPagamento = saidaPagamento.CodFormaPagamento,
                            CodSaida = saidaPagamento.CodSaida,
                            CodSaidaPagamento = saidaPagamento.CodSaidaFormaPagamento,
                            Data = (DateTime)saidaPagamento.Data,
                            DescricaoFormaPagamento = saidaPagamento.CodFormaPagamentoNavigation.Descricao,
                            IntervaloDias = (int)saidaPagamento.IntervaloDias,
                            MapeamentoCartao = saidaPagamento.CodCartaoNavigation.Mapeamento,
                            MapeamentoFormaPagamento = saidaPagamento.CodFormaPagamentoNavigation.Mapeamento,
                            NomeCartaoCredito = saidaPagamento.CodCartaoNavigation.Nome,
                            Parcelas = (int)saidaPagamento.Parcelas,
                            Valor = (decimal)saidaPagamento.Valor,
                            NumeroControle = saidaPagamento.NumeroControle
                        };
            return query.AsNoTracking();
        }

        /// <summary>
        /// Obter os dados de um pagamento
        /// </summary>
        /// <param name="codSaidaPagamento"></param>
        /// <returns></returns>
        public static List<SaidaPagamento> Obter(long codSaidaPagamento)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).Where(sp => sp.CodSaidaPagamento == codSaidaPagamento).ToList();
            }
        }

        /// <summary>
        /// Obter os todos os pagamentos de uma saída
        /// </summary>
        /// <param name="codSaidaPagamento"></param>
        /// <returns></returns>
        public static List<SaidaPagamento> ObterPorSaida(long codSaida)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).Where(sp => sp.CodSaida == codSaida).ToList();
            }
        }


        /// <summary>
        /// Obter os todos os pagamentos de uma saída 
        /// </summary>
        /// <param name="codSaidaPagamento"></param>
        /// <returns></returns>
        public static List<SaidaPagamento> ObterPorSaidas(List<long> listaCodSaidas)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).Where(sp => listaCodSaidas.Contains(sp.CodSaida)).ToList();
            }
        }

        /// <summary>
        /// Obter os todos os pagamentos de uma saída de uma mesma forma de pagamento
        /// </summary>
        /// <param name="codSaidaPagamento"></param>
        /// <returns></returns>
        public static List<SaidaPagamento> ObterPorSaidaFormaPagamento(long codSaida, int codFormaPagamento)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).Where(sp => sp.CodSaida == codSaida && sp.CodFormaPagamento == codFormaPagamento).ToList();
            }
        }

        /// <summary>
        /// Obtém totais de pagamentos referentes ao período
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<TotalPagamentoSaida> ObterTotalPagamento(DateTime dataInicial, DateTime dataFinal)
        {
            using (var context = new SaceContext())
            {
                var query = from saidaPagamento in context.TbSaidaFormaPagamentos
                            where saidaPagamento.Data >= dataInicial && saidaPagamento.Data <= dataFinal &&
                                (saidaPagamento.CodSaidaNavigation.CodTipoSaida == Saida.TIPO_VENDA || saidaPagamento.CodSaidaNavigation.CodTipoSaida == Saida.TIPO_PRE_VENDA ||
                                saidaPagamento.CodSaidaNavigation.CodTipoSaida == Saida.TIPO_CREDITO) && (saidaPagamento.CodSaidaFormaPagamento != FormaPagamento.CREDIARIO)
                            group saidaPagamento by saidaPagamento.CodFormaPagamento into gsaida

                            select new TotalPagamentoSaida
                            {
                                CodFormaPagamentos = gsaida.Key,
                                DescricaoFormaPagamentos = gsaida.FirstOrDefault().CodFormaPagamentoNavigation.Descricao,
                                //SomaSaldo = movimentacao.tb_tipo_movimentacao_conta.somaSaldo,
                                TotalPagamento = (decimal)gsaida.Sum(saidaPagamento => saidaPagamento.Valor)
                            };
                return query.ToList();
            }
        }

        /// <summary>
        /// Obtém totais de pagamentos referentes apenas as saídas do período
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<TotalPagamentoSaida> ObterTotalPagamentoSaida(DateTime dataInicial, DateTime dataFinal)
        {
            using (var context = new SaceContext())
            {
                var query = from saidaPagamento in context.TbSaidaFormaPagamentos
                            where saidaPagamento.Data >= dataInicial && saidaPagamento.Data <= dataFinal &&
                                (saidaPagamento.CodSaidaNavigation.CodTipoSaida == Saida.TIPO_VENDA || saidaPagamento.CodSaidaNavigation.CodTipoSaida == Saida.TIPO_PRE_VENDA)
                            group saidaPagamento by saidaPagamento.CodFormaPagamento into gsaida

                            select new TotalPagamentoSaida
                            {
                                CodFormaPagamentos = gsaida.Key,
                                DescricaoFormaPagamentos = gsaida.FirstOrDefault().CodFormaPagamentoNavigation.Descricao,
                                //SomaSaldo = movimentacao.tb_tipo_movimentacao_conta.somaSaldo,
                                TotalPagamento = (decimal)gsaida.Sum(saidaPagamento => saidaPagamento.Valor)
                            };
                return query.ToList();
            }
        }

        /// <summary>
        /// Obtém totais de movimentação em um dado período
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<VendasCartao> ObterVendasCartao(DateTime dataInicial, DateTime dataFinal)
        {
            using (var context = new SaceContext())
            {
                var query = from saidaPagamento in context.TbSaidaFormaPagamentos
                            where saidaPagamento.Data >= dataInicial && saidaPagamento.Data <= dataFinal &&
                                (saidaPagamento.CodSaidaNavigation.CodTipoSaida == Saida.TIPO_VENDA ||
                                saidaPagamento.CodSaidaNavigation.CodTipoSaida == Saida.TIPO_PRE_VENDA ||
                                saidaPagamento.CodSaidaNavigation.CodTipoSaida == Saida.TIPO_CREDITO) &&
                                (saidaPagamento.CodFormaPagamento == FormaPagamento.CARTAO)
                            select new VendasCartao
                            {
                                CodCartao = saidaPagamento.CodCartao,
                                TipoCartao = saidaPagamento.CodCartaoNavigation.TipoCartao,
                                DescricaoCartao = saidaPagamento.CodCartaoNavigation.Nome,
                                TotalCartao = (decimal)saidaPagamento.Valor,
                                Parcelas = (int)saidaPagamento.Parcelas,
                                CodSaida = saidaPagamento.CodSaida,
                                NumeroControle = saidaPagamento.NumeroControle
                            };
                return query.ToList();
            }
        }

        /// <summary>
        /// Obtém totais de movimentação em um dado período
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<VendasPixDeposito> ObterVendasPixDeposito(DateTime dataInicial, DateTime dataFinal)
        {
            using (var context = new SaceContext())
            {
                var query = from saidaPagamento in context.TbSaidaFormaPagamentos
                            where saidaPagamento.Data >= dataInicial && saidaPagamento.Data <= dataFinal &&
                                (saidaPagamento.CodSaidaNavigation.CodTipoSaida == Saida.TIPO_VENDA ||
                                saidaPagamento.CodSaidaNavigation.CodTipoSaida == Saida.TIPO_PRE_VENDA ||
                                saidaPagamento.CodSaidaNavigation.CodTipoSaida == Saida.TIPO_CREDITO) &&
                                (saidaPagamento.CodFormaPagamento == FormaPagamento.DEPOSITO_PIX)
                            select new VendasPixDeposito
                            {
                                CodSaida = saidaPagamento.CodSaida,
                                Vendedor = saidaPagamento.CodSaidaNavigation.CodProfissionalNavigation.Nome,
                                DataHora = saidaPagamento.Data,
                                Valor = (decimal)saidaPagamento.Valor,
                            };
                return query.ToList();
            }
        }

        internal static void Atualizar(SaidaPagamento saidaPagamento)
        {
            using (var context = new SaceContext())
            {
                try
                {
                    var query = from saidaPagamentoE in context.TbSaidaFormaPagamentos
                                where saidaPagamentoE.CodSaida == saidaPagamento.CodSaida
                                select saidaPagamentoE;
                    foreach (TbSaidaFormaPagamento _saidaPagamentoE in query)
                    {
                        _saidaPagamentoE.CodCartao = saidaPagamento.CodCartaoCredito;
                        _saidaPagamentoE.NumeroControle = saidaPagamento.NumeroControle;
                        _saidaPagamentoE.CodContaBanco = saidaPagamento.CodContaBanco;
                        _saidaPagamentoE.CodFormaPagamento = saidaPagamento.CodFormaPagamento;
                        _saidaPagamentoE.CodSaida = saidaPagamento.CodSaida;
                        _saidaPagamentoE.Data = saidaPagamento.Data;
                        _saidaPagamentoE.IntervaloDias = saidaPagamento.IntervaloDias;
                        _saidaPagamentoE.NumeroControle = saidaPagamento.NumeroControle;
                        _saidaPagamentoE.Parcelas = (int)saidaPagamento.Parcelas;
                        _saidaPagamentoE.Valor = saidaPagamento.Valor;
                    }
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new DadosException("Saida", e.Message, e);
                }
            }
        }
    }
}
