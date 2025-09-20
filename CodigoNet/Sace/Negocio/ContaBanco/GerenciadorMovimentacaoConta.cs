using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Util;

namespace Negocio
{
    public static class GerenciadorMovimentacaoConta
    {
        /// <summary>
        /// Insere uma movimentacao na conta bancária e atualiza os dados da conta associada
        /// </summary>
        /// <param name="movimentacaoConta">movimentacao da conta</param>
        /// <param name="conta">conta associada</param>
        /// <returns></returns>
        public static long Inserir(MovimentacaoConta movimentacaoConta, SaceContext context)
        {
            try
            {
                var _movimentacaoConta = new TbMovimentacaoContum();
                Atribuir(movimentacaoConta, _movimentacaoConta);

                context.Add(_movimentacaoConta);
                context.SaveChanges();

                // Atualiza saldo da conta bancária
                var query = from conta in context.TbConta
                            where conta.CodConta == _movimentacaoConta.CodConta
                            select conta;
                var _conta = query.FirstOrDefault();
                if (_conta != null)
                {
                    AtualizaSituacaoConta(_conta, _movimentacaoConta, false, context);
                    AtualizaSituacaoPagamentosEntrada(_conta, context);
                    AtualizaSituacaoPagamentosSaida(_conta, _movimentacaoConta, false, context);
                }
                return _movimentacaoConta.CodMovimentacao;
            }
            catch (Exception e)
            {
                throw new DadosException("Movimentação de Conta", e.Message, e);
            }
        }

        /// <summary>
        /// Remover movimentacao
        /// </summary>
        /// <param name="codMovimentacaoConta"></param>
        public static void Remover(long codMovimentacaoConta)
        {
            using (var context = new SaceContext())
            {
                var transaction = context.Database.BeginTransaction();
                try
                {
                    var queryMovimentacao = from movimentacaoContaE in context.TbMovimentacaoConta
                                            where movimentacaoContaE.CodMovimentacao == codMovimentacaoConta
                                            select movimentacaoContaE;
                    var _movimentacaoConta = queryMovimentacao.FirstOrDefault();
                    if (_movimentacaoConta != null)
                    {
                        long codConta = (long)_movimentacaoConta.CodConta;
                        // Atualiza status da conta, entrada e saída 
                        var query = from conta in context.TbConta
                                    where conta.CodConta == _movimentacaoConta.CodConta
                                    select conta;
                        var _conta = query.FirstOrDefault();

                        context.Remove(_movimentacaoConta);
                        context.SaveChanges();

                        if (_conta != null)
                        {
                            AtualizaSituacaoConta(_conta, _movimentacaoConta, true, context);
                            AtualizaSituacaoPagamentosEntrada(_conta, context);
                            AtualizaSituacaoPagamentosSaida(_conta, _movimentacaoConta, true, context);
                        }
                    }
                    transaction.Commit();
                }

                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DadosException("Movimentação de Conta", e.Message, e);
                }
            }
        }

        /// <summary>
        /// Remover todas as movimentacoes de uma conta
        /// </summary>
        /// <param name="conta"></param>
        public static void RemoverPorConta(long codConta, SaceContext context)
        {
            try
            {
                var query = from movimentacaoSet in context.TbMovimentacaoConta.Include(m => m.CodContaNavigation)
                            where movimentacaoSet.CodConta == codConta
                            select movimentacaoSet;
                var movimentacoes = query.ToList();
                foreach (TbMovimentacaoContum _movimentacaoConta in movimentacoes)
                {
                    var _conta = _movimentacaoConta.CodContaNavigation;

                    if (_conta != null)
                    {
                        context.Remove(_conta);
                        context.SaveChanges();

                        AtualizaSituacaoConta(_conta, _movimentacaoConta, true, context);
                        AtualizaSituacaoPagamentosEntrada(_conta, context);
                        AtualizaSituacaoPagamentosSaida(_conta, _movimentacaoConta, true, context);
                    }
                }

            }
            catch (Exception e)
            {
                throw new DadosException("Movimentação de Conta", e.Message, e);
            }
        }



        /// <summary>
        /// Query Geral para obter dados das movimentacoes
        /// </summary>
        /// <returns></returns>
        private static IQueryable<MovimentacaoConta> GetQuery(SaceContext context)
        {
            var query = from movimentacao in context.TbMovimentacaoConta
                        select new MovimentacaoConta
                        {
                            CodConta = (long)movimentacao.CodConta,
                            CodContaBanco = movimentacao.CodContaBanco,
                            CodMovimentacao = movimentacao.CodMovimentacao,
                            CodResponsavel = movimentacao.CodResponsavel,
                            NomeResponsavel = movimentacao.CodResponsavelNavigation.Nome,
                            CodTipoMovimentacao = movimentacao.CodTipoMovimentacao,
                            DescricaoTipoMovimentacao = movimentacao.CodTipoMovimentacaoNavigation.Descricao,
                            DataHora = movimentacao.DataHora,
                            SomaSaldo = movimentacao.CodTipoMovimentacaoNavigation.SomaSaldo,
                            Valor = movimentacao.Valor
                        };
            return query.AsNoTracking();
        }

        /// <summary>
        /// Obter movimentacoes
        /// </summary>
        /// <param name="codMovimentacao"></param>
        /// <returns></returns>
        public static IEnumerable<MovimentacaoConta> Obter(long codMovimentacao)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).Where(m => m.CodMovimentacao == codMovimentacao).ToList();
            }
        }
        /// <summary>
        /// Obter movimentacoes por conta
        /// </summary>
        /// <param name="codConta"></param>
        /// <returns></returns>
        public static IEnumerable<MovimentacaoConta> ObterPorConta(long codConta)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).Where(m => m.CodConta == codConta).ToList();
            }
        }

        /// <summary>
        /// Obter todas as contas em aberto da pessoa
        /// </summary>
        /// <param name="codPessoa"> código da pessoa </param>
        /// <returns> Contas </returns>
        public static IEnumerable<MovimentacaoConta> ObterPorContas(List<long> listaCodContas)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).Where(m => listaCodContas.Contains(m.CodConta)).ToList();
            }
        }


        /// <summary>
        /// Obtém totais de movimentação em um dado período
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<TotaisMovimentacaoConta> ObterTotalMovimentacaoContaPeriodo(int codContaBanco, DateTime dataInicial, DateTime dataFinal)
        {
            using (var context = new SaceContext())
            {
                var query = from movimentacao in context.TbMovimentacaoConta
                            where movimentacao.CodContaBanco == codContaBanco &&
                                movimentacao.DataHora >= dataInicial
                                && movimentacao.DataHora <= dataFinal
                            group movimentacao by movimentacao.CodTipoMovimentacao into gmov

                            select new TotaisMovimentacaoConta
                            {
                                CodTipoMovimentacaoConta = gmov.Key,
                                DescricaoMovimentacaoConta = gmov.First().CodTipoMovimentacaoNavigation.Descricao,
                                TotalMovimentacaoConta = gmov.Sum(mov => mov.Valor)
                            };
                return query.ToList();
            }
        }


        /// <summary>
        /// Obtém as movimentações de uma conta bancária em um determinado período
        /// </summary>
        /// <param name="dataInicio"></param>
        /// <param name="dataFim"></param>
        /// <returns></returns>
        public static IQueryable<MovimentacaoPeriodo> ObterMovimentacaoContaPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            DateTime dataBuscaInicio = dataInicio.Date;
            DateTime dataBuscaFim = dataFim.Date.AddDays(1).AddMinutes(-1);

            using (var context = new SaceContext())
            {
                var query = from movimentacaoConta in context.TbMovimentacaoConta
                            where movimentacaoConta.DataHora >= dataBuscaInicio && movimentacaoConta.DataHora <= dataBuscaFim
                            select new MovimentacaoPeriodo
                            {
                                CodSaida = (long)movimentacaoConta.CodContaNavigation.CodSaida,
                                DataSaida = movimentacaoConta.CodContaNavigation.CodSaidaNavigation.DataSaida,
                                DescricaoTipoMovimentacao = movimentacaoConta.CodTipoMovimentacaoNavigation.Descricao,
                                NomeCliente = movimentacaoConta.CodContaNavigation.CodSaidaNavigation.CodClienteNavigation.NomeFantasia,
                                Valor = movimentacaoConta.Valor,
                                DataHora = movimentacaoConta.DataHora
                            };
                return query;
            }
        }




        /// <summary>
        /// Atualiza Situacao dos pagamentos da saída para quitado quando todas as contas estão quitadas
        /// </summary>
        /// <param name="_contaE"></param>
        public static void AtualizaSituacaoPagamentosSaida(TbContum conta, TbMovimentacaoContum movimentacaoConta, bool removeuMovimento, SaceContext context)
        {
            if (!conta.CodSaida.Equals(UtilConfig.Default.SAIDA_PADRAO))
            {
                var query = from saida in context.TbSaida
                            where saida.CodSaida == conta.CodSaida
                            select saida;
                var _saida = query.FirstOrDefault();
                if (_saida != null)
                {
                    if (_saida.TotalAvista == movimentacaoConta.Valor)
                    {
                        if (removeuMovimento)
                            _saida.CodSituacaoPagamentos = SituacaoPagamentos.LANCADOS;
                        else
                            _saida.CodSituacaoPagamentos = SituacaoPagamentos.QUITADA;
                    }
                    else
                    {
                        if (GerenciadorConta.ObterPorSituacaoSaida(SituacaoConta.SITUACAO_ABERTA, (long)conta.CodSaida).ToList().Count == 0)
                        {
                            _saida.CodSituacaoPagamentos = SituacaoPagamentos.QUITADA;
                            IEnumerable<Conta> contas = GerenciadorConta.ObterPorSaida(_saida.CodSaida);
                            List<long> listaCodContas = new List<long>();
                            foreach (Conta c in contas)
                            {
                                listaCodContas.Add(c.CodConta);
                            }
                            decimal somaMovimentacoes = 0;
                            IEnumerable<MovimentacaoConta> listaMovimentacoes = ObterPorContas(listaCodContas);
                            foreach (MovimentacaoConta movimentacao in listaMovimentacoes)
                            {
                                somaMovimentacoes += movimentacao.Valor;
                            }
                            AtualizarTipoPedidoGeradoPorSaida(_saida.CodTipoSaida, _saida.PedidoGerado, _saida.TipoDocumentoFiscal, somaMovimentacoes, _saida.CodSaida, context);
                            //_saidaE.totalAVista = somaMovimentacoes;
                        }
                        else
                        {
                            _saida.CodSituacaoPagamentos = SituacaoPagamentos.LANCADOS;
                        }
                    }
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Atualiza Situacao dos pagamentos da entrada para quitado quando todas as contas estão quitadas
        /// </summary>
        /// <param name="_contaE"></param>
        private static void AtualizaSituacaoPagamentosEntrada(TbContum _conta, SaceContext context)
        {
            if (_conta.CodEntrada != UtilConfig.Default.ENTRADA_PADRAO)
            {
                var query = from entrada in context.TbEntrada
                            where entrada.CodEntrada == _conta.CodEntrada
                            select entrada;
                var _entrada = query.FirstOrDefault();

                if (_entrada != null)
                {
                    var query2 = from conta in context.TbConta
                                 where conta.CodSituacao.Equals(SituacaoConta.SITUACAO_ABERTA) && conta.CodEntrada == _conta.CodEntrada
                                 select conta;

                    if (query2.Count() == 0)
                    {
                        _entrada.CodSituacaoPagamentos = SituacaoPagamentos.QUITADA;
                    }
                    else
                    {
                        _entrada.CodSituacaoPagamentos = SituacaoPagamentos.LANCADOS;
                    }

                }
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Atualiza conta para quitada quando todas a soma de todas as movimentacoes quitam a conta
        /// </summary>
        /// <param name="_contaE"></param>
        private static TbContum AtualizaSituacaoConta(TbContum conta, TbMovimentacaoContum movimentacao, bool removeuMovimento, SaceContext context)
        {
            if (conta != null)
            {
                decimal valorConta = Math.Round(conta.Valor - conta.Desconto, 2);
                if (valorConta == movimentacao.Valor)
                {
                    if (removeuMovimento)
                        conta.CodSituacao = SituacaoConta.SITUACAO_ABERTA;
                    else
                        conta.CodSituacao = SituacaoConta.SITUACAO_QUITADA;
                }
                else
                {
                    decimal totalMovimentacoesConta = ObterPorConta(conta.CodConta).Sum(c => c.Valor);
                    if (valorConta <= totalMovimentacoesConta)
                        conta.CodSituacao = SituacaoConta.SITUACAO_QUITADA;
                    else
                        conta.CodSituacao = SituacaoConta.SITUACAO_ABERTA;
                }
            }
            context.SaveChanges();
            return conta;
        }

        /// <summary>
        /// Atualiza o número da nota fiscal gerada a partir do pedido (cupom fiscal) gerado
        /// </summary>
        /// <param name="nfe"></param>
        /// <param name="pedidoGerado"></param>
        private static void AtualizarTipoPedidoGeradoPorSaida(int codTipoSaida, string pedidoGerado, string tipoDocumentoFiscal, decimal totalAVista, long codSaida, SaceContext context)
        {
            try
            {
                var query = from saida in context.TbSaida
                            where saida.CodSaida == codSaida
                            select saida;
                foreach (TbSaidum _saida in query)
                {
                    // atualiza o lucro na venda de acordo com o que foi pago
                    if (_saida.TotalAvista > totalAVista)
                    {
                        _saida.TotalLucro -= _saida.TotalAvista - totalAVista;
                    }
                    else
                    {
                        _saida.TotalLucro += totalAVista - _saida.TotalAvista;
                    }
                    _saida.CodTipoSaida = codTipoSaida;
                    if (string.IsNullOrEmpty(_saida.PedidoGerado))
                    {
                        _saida.PedidoGerado = pedidoGerado.ToString();
                        _saida.DataEmissaoDocFiscal = DateTime.Now;
                    }
                    _saida.TotalAvista = totalAVista;
                    _saida.TotalPago = totalAVista;
                    _saida.TipoDocumentoFiscal = tipoDocumentoFiscal;
                    if (_saida.Total > 0)
                    {
                        _saida.Desconto = Math.Round(Convert.ToDecimal((1 - (_saida.TotalAvista / _saida.Total)) * 100), 2);
                    }
                    else
                    {
                        _saida.Desconto = 0;
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
        /// Atribui a classe entidade para entidade persistente
        /// </summary>
        /// <param name="movimentacaoConta"></param>
        /// <param name="_movimentacaoE"></param>
        private static void Atribuir(MovimentacaoConta movimentacaoConta, TbMovimentacaoContum _movimentacao)
        {
            _movimentacao.CodConta = movimentacaoConta.CodConta;
            _movimentacao.CodContaBanco = movimentacaoConta.CodContaBanco;
            _movimentacao.CodResponsavel = movimentacaoConta.CodResponsavel;
            _movimentacao.CodTipoMovimentacao = movimentacaoConta.CodTipoMovimentacao;
            _movimentacao.DataHora = movimentacaoConta.DataHora;
            _movimentacao.Valor = movimentacaoConta.Valor;
        }
    }
}
