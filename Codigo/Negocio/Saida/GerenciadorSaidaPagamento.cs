using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Dados;
using Dominio;
using Dominio.Consultas;

namespace Negocio
{
    public class GerenciadorSaidaPagamento
    {

        private static GerenciadorSaidaPagamento gSaidaPagamento;
        private static SaceEntities saceContext;
        private static RepositorioGenerico<SaidaFormaPagamentoE> repSaidaPagamento;
        

        public static GerenciadorSaidaPagamento GetInstance(SaceEntities context)
        {
            if (gSaidaPagamento == null)
            {
                gSaidaPagamento = new GerenciadorSaidaPagamento();
            }
            if (context == null)
            {
                repSaidaPagamento = new RepositorioGenerico<SaidaFormaPagamentoE>();
            }
            else
            {
                repSaidaPagamento = new RepositorioGenerico<SaidaFormaPagamentoE>(context);
            }
            saceContext = (SaceEntities)repSaidaPagamento.ObterContexto();
            return gSaidaPagamento;
        }

        /// <summary>
        /// Insere um novo pagamento na saída
        /// </summary>
        /// <param name="saidaPagamento"></param>
        /// <param name="saida"></param>
        /// <returns></returns>
        public long Inserir(SaidaPagamento saidaPagamento, Saida saida)
        {
            DbTransaction transaction = null;
            try
            {
                if (saceContext.Connection.State == System.Data.ConnectionState.Closed)
                    saceContext.Connection.Open();
                transaction = saceContext.Connection.BeginTransaction();

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
                else if (saida.TipoSaida.Equals(Saida.TIPO_PRE_CREDITO) && (saida.CodCliente == Util.Global.CLIENTE_PADRAO))
                {
                    throw new NegocioException("É necessário informar o cliente que será creditado.");
                }
                else if (saida.TipoSaida.Equals(Saida.TIPO_PRE_CREDITO) && saidaPagamento.CodFormaPagamento.Equals(FormaPagamento.CREDIARIO))
                {
                    throw new NegocioException("Forma de pagamento Crediário não pode ser utilizada para operação de crédito.");
                }
                
                else if ((saidaPagamento.CodFormaPagamento != FormaPagamento.DINHEIRO) && (saidaPagamento.CodFormaPagamento != FormaPagamento.CARTAO)
                    && (saidaPagamento.CodFormaPagamento != FormaPagamento.DEPOSITO_PIX) && (saida.CodCliente == Util.Global.CLIENTE_PADRAO))
                {
                    throw new NegocioException("É necessário informar um cliente para utilizar essa forma de pagamento.");
                }
                else if ((saidaPagamento.CodFormaPagamento == FormaPagamento.CARTAO) && (saidaPagamento.CodCartaoCredito == Util.Global.CARTAO_LOJA))
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
                    SaidaFormaPagamentoE _saidaPagamentoE = new SaidaFormaPagamentoE();
                    _saidaPagamentoE.codCartao = saidaPagamento.CodCartaoCredito;
                    _saidaPagamentoE.codContaBanco = saidaPagamento.CodContaBanco;
                    _saidaPagamentoE.codFormaPagamento = saidaPagamento.CodFormaPagamento;
                    _saidaPagamentoE.codSaida = saidaPagamento.CodSaida;
                    _saidaPagamentoE.data = saidaPagamento.Data;
                    _saidaPagamentoE.intervaloDias = saidaPagamento.IntervaloDias;
                    _saidaPagamentoE.parcelas = saidaPagamento.Parcelas;
                    _saidaPagamentoE.valor = saidaPagamento.Valor;
                    _saidaPagamentoE.numeroControle = String.IsNullOrEmpty(saidaPagamento.NumeroControle) ? "" : saidaPagamento.NumeroControle;


                    repSaidaPagamento.Inserir(_saidaPagamentoE);
                    repSaidaPagamento.SaveChanges();

                    var query = from saidaPagamentoSet in saceContext.SaidaFormaPagamentoSet
                                where saidaPagamentoSet.codSaida == saida.CodSaida
                                select saidaPagamentoSet;


                    saida.TotalPago = query.ToList().Sum(sp => (decimal) sp.valor);
                    saida.Troco = saida.TotalPago - saida.TotalAVista;
                    saida.Desconto = 100 - ((saida.TotalAVista / saida.Total) * 100);

                }
                GerenciadorSaida.GetInstance(saceContext).Atualizar(saida);
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new DadosException("Pagamentos", e.Message, e);
            }
            finally
            {
                saceContext.Connection.Close();
            }

            return 0;
        }

        /// <summary>
        /// Atualiza o número da nota fiscal gerada num determinado codigo saida
        /// </summary>
        /// <param name="nfe"></param>
        /// <param name="pedidoGerado"></param>
        public void AtualizarPorAutorizacaoCartao(long codSaida, int codCartao, string numeroControle)
        {
            try
            {
                var query = from saidaPagamentoE in saceContext.SaidaFormaPagamentoSet
                            where saidaPagamentoE.codSaida == codSaida && saidaPagamentoE.codFormaPagamento == FormaPagamento.CARTAO
                            select saidaPagamentoE;
                foreach (SaidaFormaPagamentoE _saidaPagamentoE in query)
                {
                    _saidaPagamentoE.codCartao = codCartao;
                    _saidaPagamentoE.numeroControle = numeroControle;
                }
                saceContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Saida", e.Message, e);
            }
        }

        /// <summary>
        /// Remove todos os pagamentos de uma Saída
        /// </summary>
        /// <param name="saida"></param>
        public void RemoverPorSaida(Saida saida)
        {
            List<SaidaPagamento> listaSaidaPagamento = ObterPorSaida(saida.CodSaida);
            foreach (SaidaPagamento saidaPagamento in listaSaidaPagamento)
            {
                Remover(saidaPagamento.CodSaidaPagamento, saida);

            }
            //repSaidaPagamento.SaveChanges();
        }

        /// <summary>
        /// Remover um determinado pagamento de uma saída
        /// </summary>
        /// <param name="codSaidaPagamento"></param>
        /// <param name="saida"></param>
        public void Remover(Int64 codSaidaPagamento, Saida saida)
        {
            try
            {
                if ((saida.TipoSaida == Saida.TIPO_PRE_VENDA) || (saida.TipoSaida == Saida.TIPO_VENDA) || (saida.TipoSaida == Saida.TIPO_CREDITO))
                {
                    List<Conta> contas = GerenciadorConta.GetInstance(saceContext).ObterPorSaidaPagamento(saida.CodSaida, codSaidaPagamento).ToList();

                    foreach (Conta conta in contas)
                    {
                        GerenciadorMovimentacaoConta.GetInstance(saceContext).RemoverPorConta(conta.CodConta);
                        GerenciadorConta.GetInstance(saceContext).Remover(conta.CodConta);
                    }
                }
                var query = from saidaPagamentoSet in saceContext.SaidaFormaPagamentoSet
                            where saidaPagamentoSet.codSaidaFormaPagamento == codSaidaPagamento
                            select saidaPagamentoSet;

                foreach (SaidaFormaPagamentoE _saidaPagamentoE in query)
                {
                    repSaidaPagamento.Remover(_saidaPagamentoE);
                }
                repSaidaPagamento.SaveChanges();
                
                saida.TotalPago = ObterPorSaida(saida.CodSaida).Sum(sp => sp.Valor);
                saida.Troco = saida.TotalPago - saida.TotalAVista;
                saida.Desconto = 100 - ((saida.TotalAVista / saida.Total) * 100);
                GerenciadorSaida.GetInstance(saceContext).Atualizar(saida);
            }
            catch (Exception e)
            {
                throw new DadosException("Pagamentos", e.Message, e);
            }
        }


        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<SaidaPagamento> GetQuery()
        {
            var query = from saidaPagamento in saceContext.SaidaFormaPagamentoSet
                        select new SaidaPagamento
                        {
                            CodCartaoCredito = saidaPagamento.codCartao,
                            CodContaBanco = saidaPagamento.codContaBanco,
                            DescricaoContaBanco = saidaPagamento.tb_conta_banco.descricao,
                            CodFormaPagamento = saidaPagamento.codFormaPagamento,
                            CodSaida = saidaPagamento.codSaida,
                            CodSaidaPagamento = saidaPagamento.codSaidaFormaPagamento,
                            Data = (DateTime)saidaPagamento.data,
                            DescricaoFormaPagamento = saidaPagamento.tb_forma_pagamento.descricao,
                            IntervaloDias = (int)saidaPagamento.intervaloDias,
                            MapeamentoCartao = saidaPagamento.tb_cartao_credito.mapeamento,
                            MapeamentoFormaPagamento = saidaPagamento.tb_forma_pagamento.mapeamento,
                            NomeCartaoCredito = saidaPagamento.tb_cartao_credito.nome,
                            Parcelas = (int)saidaPagamento.parcelas,
                            Valor = (decimal)saidaPagamento.valor,
                            NumeroControle = saidaPagamento.numeroControle
                        };
            return query;

        }

        /// <summary>
        /// Obter os dados de um pagamento
        /// </summary>
        /// <param name="codSaidaPagamento"></param>
        /// <returns></returns>
        public List<SaidaPagamento> Obter(long codSaidaPagamento)
        {
            return GetQuery().Where(sp => sp.CodSaidaPagamento == codSaidaPagamento).ToList();
        }

        /// <summary>
        /// Obter os todos os pagamentos de uma saída
        /// </summary>
        /// <param name="codSaidaPagamento"></param>
        /// <returns></returns>
        public List<SaidaPagamento> ObterPorSaida(long codSaida)
        {
            return GetQuery().Where(sp => sp.CodSaida == codSaida).ToList();
        }


        /// <summary>
        /// Obter os todos os pagamentos de uma saída 
        /// </summary>
        /// <param name="codSaidaPagamento"></param>
        /// <returns></returns>
        public List<SaidaPagamento> ObterPorSaidas(List<long> listaCodSaidas)
        {
            return GetQuery().Where(sp => listaCodSaidas.Contains(sp.CodSaida)).ToList();
        }

        /// <summary>
        /// Obter os todos os pagamentos de uma saída de uma mesma forma de pagamento
        /// </summary>
        /// <param name="codSaidaPagamento"></param>
        /// <returns></returns>
        public List<SaidaPagamento> ObterPorSaidaFormaPagamento(long codSaida, int codFormaPagamento)
        {
            return GetQuery().Where(sp => sp.CodSaida == codSaida && sp.CodFormaPagamento == codFormaPagamento).ToList();
        }

        /// <summary>
        /// Obtém totais de movimentação em um dado período
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TotalPagamentoSaida> ObterTotalPagamentoSaida(DateTime dataInicial, DateTime dataFinal)
        {
            var query = from saidaPagamento in saceContext.SaidaFormaPagamentoSet
                        where saidaPagamento.data >= dataInicial && saidaPagamento.data <= dataFinal &&
                            (saidaPagamento.tb_saida.codTipoSaida == Saida.TIPO_VENDA || saidaPagamento.tb_saida.codTipoSaida == Saida.TIPO_PRE_VENDA)
                        group saidaPagamento by saidaPagamento.codFormaPagamento into gsaida

                        select new TotalPagamentoSaida
                        {
                            CodFormaPagamentos = gsaida.Key,
                            DescricaoFormaPagamentos = gsaida.FirstOrDefault().tb_forma_pagamento.descricao,
                            //SomaSaldo = movimentacao.tb_tipo_movimentacao_conta.somaSaldo,
                            TotalPagamento = (decimal)gsaida.Sum(saidaPagamento => saidaPagamento.valor)
                        };
            return query.ToList();
        }

        /// <summary>
        /// Obtém totais de movimentação em um dado período
        /// </summary>
        /// <returns></returns>
        public IEnumerable<VendasCartao> ObterVendasCartao(DateTime dataInicial, DateTime dataFinal)
        {
            var query = from saidaPagamento in saceContext.SaidaFormaPagamentoSet
                        where saidaPagamento.data >= dataInicial && saidaPagamento.data <= dataFinal &&
                            (saidaPagamento.tb_saida.codTipoSaida == Saida.TIPO_VENDA || saidaPagamento.tb_saida.codTipoSaida == Saida.TIPO_PRE_VENDA) &&
                            (saidaPagamento.codFormaPagamento == FormaPagamento.CARTAO)
                        select new VendasCartao
                        {
                            CodCartao = saidaPagamento.codCartao,
                            TipoCartao = saidaPagamento.tb_cartao_credito.tipoCartao,
                            DescricaoCartao = saidaPagamento.tb_cartao_credito.nome,
                            TotalCartao = (decimal) saidaPagamento.valor,
                            Parcelas = (int) saidaPagamento.parcelas,
                            CodSaida = saidaPagamento.codSaida,
                            NumeroControle = saidaPagamento.numeroControle
                        };
            return query.ToList();
        }

        /// <summary>
        /// Obtém totais de movimentação em um dado período
        /// </summary>
        /// <returns></returns>
        public IEnumerable<VendasPixDeposito> ObterVendasPixDeposito(DateTime dataInicial, DateTime dataFinal)
        {
            var query = from saidaPagamento in saceContext.SaidaFormaPagamentoSet
                        where saidaPagamento.data >= dataInicial && saidaPagamento.data <= dataFinal &&
                            (saidaPagamento.tb_saida.codTipoSaida == Saida.TIPO_VENDA || saidaPagamento.tb_saida.codTipoSaida == Saida.TIPO_PRE_VENDA) &&
                            (saidaPagamento.codFormaPagamento == FormaPagamento.DEPOSITO_PIX)
                        select new VendasPixDeposito
                        {
                            CodSaida = saidaPagamento.codSaida,
                            Vendedor = saidaPagamento.tb_saida.tb_pessoa1.nome,
                            DataHora = saidaPagamento.data,
                            Valor = (decimal)saidaPagamento.valor,
                        };
            return query.ToList();
        }

        internal void Atualizar(SaidaPagamento saidaPagamento)
        {
            try
            {
                var query = from saidaPagamentoE in saceContext.SaidaFormaPagamentoSet
                            where saidaPagamentoE.codSaida == saidaPagamento.CodSaida
                            select saidaPagamentoE;
                foreach (SaidaFormaPagamentoE _saidaPagamentoE in query)
                {
                    _saidaPagamentoE.codCartao = saidaPagamento.CodCartaoCredito;
                    _saidaPagamentoE.numeroControle = saidaPagamento.NumeroControle;
                    _saidaPagamentoE.codContaBanco = saidaPagamento.CodContaBanco;
                    _saidaPagamentoE.codFormaPagamento = saidaPagamento.CodFormaPagamento;
                    _saidaPagamentoE.codSaida = saidaPagamento.CodSaida;
                    _saidaPagamentoE.data = saidaPagamento.Data;
                    _saidaPagamentoE.intervaloDias = saidaPagamento.IntervaloDias;
                    _saidaPagamentoE.numeroControle = saidaPagamento.NumeroControle;
                    _saidaPagamentoE.parcelas = saidaPagamento.Parcelas;
                    _saidaPagamentoE.valor = saidaPagamento.Valor;
                }
                saceContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Saida", e.Message, e);
            }
        }
    }
}
