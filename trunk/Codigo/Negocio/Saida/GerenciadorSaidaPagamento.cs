using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dominio;
using Dados.saceDataSetTableAdapters;
using Dados;
using Util;
using System.Data.Common;
using System.Data.Objects;

namespace Negocio
{
    public class GerenciadorSaidaPagamento
    {

        private static GerenciadorSaidaPagamento gSaidaPagamento;

        public static GerenciadorSaidaPagamento GetInstance()
        {
            if (gSaidaPagamento == null)
            {
                gSaidaPagamento = new GerenciadorSaidaPagamento();
            }
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
            try
            {
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
                else if ((saidaPagamento.CodFormaPagamento != FormaPagamento.DINHEIRO) && (saidaPagamento.CodFormaPagamento != FormaPagamento.CARTAO)
                    && (saida.CodCliente == Util.Global.CLIENTE_PADRAO))
                {
                    throw new NegocioException("É necessário informar um cliente para utilizar essa forma de pagamento.");
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

                    var repSaidaPagamento = new RepositorioGenerico<SaidaFormaPagamentoE>();
                    repSaidaPagamento.Inserir(_saidaPagamentoE);
                    repSaidaPagamento.SaveChanges();

                    saida.TotalPago = ObterPorSaida(saida.CodSaida).Sum(sp => sp.Valor);
                    saida.Troco = saida.TotalPago - saida.TotalAVista;
                    saida.Desconto = 100 - ((saida.TotalAVista / saida.Total) * 100);

                }
                GerenciadorSaida.GetInstance().Atualizar(saida);

            }
            catch (Exception e)
            {
                throw new DadosException("Pagamentos", e.Message, e);
            }
            return 0;
        }

        /// <summary>
        /// Remove todos os pagamentos de uma Saída
        /// </summary>
        /// <param name="saida"></param>
        public void RemoverPorSaida(Saida saida)
        {
            List<SaidaPagamento> pagamentos = (List<SaidaPagamento>) ObterPorSaida(saida.CodSaida);

            foreach (SaidaPagamento pagamento in pagamentos)
            {
                Remover(pagamento.CodSaidaPagamento, saida);
            }

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
                if ((saida.TipoSaida == Saida.TIPO_PRE_VENDA) || (saida.TipoSaida == Saida.TIPO_VENDA))
                {
                    List<Conta> contas = GerenciadorConta.GetInstance().ObterPorSaidaPagamento(saida.CodSaida, codSaidaPagamento).ToList();

                    foreach (Conta conta in contas)
                    {
                        GerenciadorMovimentacaoConta.getInstace().RemoverPorConta(conta.CodConta);
                        GerenciadorConta.GetInstance().Remover(conta.CodConta);
                    }
                }
                var repSaidaPagamento = new RepositorioGenerico<SaidaFormaPagamentoE>();
                var saceEntities = (SaceEntities)repSaidaPagamento.ObterContexto();
                var query = from saidaPagamentoSet in saceEntities.SaidaFormaPagamentoSet
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
                GerenciadorSaida.GetInstance().Atualizar(saida);
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
            var repSaidaPagamento = new RepositorioGenerico<SaidaFormaPagamentoE>();

            var saceEntities = (SaceEntities)repSaidaPagamento.ObterContexto();
            var query = from saidaPagamento in saceEntities.SaidaFormaPagamentoSet
                        join formaPagamento in saceEntities.FormaPagamentoSet on saidaPagamento.codFormaPagamento equals formaPagamento.codFormaPagamento
                        join cartaoCredito in saceEntities.CartaoCreditoSet on saidaPagamento.codCartao equals cartaoCredito.codCartao
                        join contaBanco in saceEntities.ContaBancoSet on saidaPagamento.codContaBanco equals contaBanco.codContaBanco
                        select new SaidaPagamento
                        {
                            CodCartaoCredito = saidaPagamento.codCartao,
                            CodContaBanco = saidaPagamento.codContaBanco,
                            DescricaoContaBanco = contaBanco.descricao,
                            CodFormaPagamento = saidaPagamento.codFormaPagamento,
                            CodSaida = saidaPagamento.codSaida,
                            CodSaidaPagamento = saidaPagamento.codSaidaFormaPagamento,
                            Data = (DateTime)saidaPagamento.data,
                            DescricaoFormaPagamento = formaPagamento.descricao,
                            IntervaloDias = (int)saidaPagamento.intervaloDias,
                            MapeamentoCartao = cartaoCredito.mapeamento,
                            MapeamentoFormaPagamento = formaPagamento.mapeamento,
                            NomeCartaoCredito = cartaoCredito.nome,
                            Parcelas = (int)saidaPagamento.parcelas,
                            Valor = (decimal)saidaPagamento.valor

                        };
            return query;

        }

        /// <summary>
        /// Obter os dados de um pagamento
        /// </summary>
        /// <param name="codSaidaPagamento"></param>
        /// <returns></returns>
        public IEnumerable<SaidaPagamento> Obter(long codSaidaPagamento)
        {
            return GetQuery().Where(sp => sp.CodSaidaPagamento == codSaidaPagamento).ToList();
        }

        /// <summary>
        /// Obter os todos os pagamentos de uma saída
        /// </summary>
        /// <param name="codSaidaPagamento"></param>
        /// <returns></returns>
        public IEnumerable<SaidaPagamento> ObterPorSaida(long codSaida)
        {
            return GetQuery().Where(sp => sp.CodSaida == codSaida).ToList();
        }


        /// <summary>
        /// Obter os todos os pagamentos de uma saída
        /// </summary>
        /// <param name="codSaidaPagamento"></param>
        /// <returns></returns>
        public IEnumerable<SaidaPagamento> ObterPorSaidas(List<long> listaCodSaidas)
        {
            return GetQuery().Where(sp => listaCodSaidas.Contains(sp.CodSaida)).ToList();
        }
        
        /// <summary>
        /// Obter os todos os pagamentos de uma saída de uma mesma forma de pagamento
        /// </summary>
        /// <param name="codSaidaPagamento"></param>
        /// <returns></returns>
        public IEnumerable<SaidaPagamento> ObterPorSaidaFormaPagamento(long codSaida, int codFormaPagamento)
        {
            return GetQuery().Where(sp => sp.CodSaida == codSaida && sp.CodFormaPagamento == codFormaPagamento).ToList();
        }
     }
}
