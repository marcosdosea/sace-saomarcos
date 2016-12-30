using System;
using System.Collections.Generic;
using System.Linq;
using Dados;
using Dominio;

namespace Negocio
{
    public class GerenciadorEntradaPagamento 
    {
        private static GerenciadorEntradaPagamento gEntradaPagamento;
                
        public static GerenciadorEntradaPagamento GetInstance()
        {
            if (gEntradaPagamento == null)
            {
                gEntradaPagamento = new GerenciadorEntradaPagamento();
            }
            return gEntradaPagamento;
        }

        /// <summary>
        /// Insere um novo pagamento numa entrada
        /// </summary>
        /// <param name="entradaPagamento"></param>
        /// <param name="entrada"></param>
        /// <returns></returns>
        public long Inserir(EntradaPagamento entradaPagamento)
        {
            try
            {
                if (entradaPagamento.Valor <= 0)
                {
                    throw new NegocioException("O valor do pagamento deve ser maior que zero e não deve ultrapassar o valor total da entrada.");
                } 
                
                decimal? totalPagamentos = ObterPorEntrada(entradaPagamento.CodEntrada).Sum(ep => ep.Valor);

                Entrada entrada = GerenciadorEntrada.GetInstance().Obter(entradaPagamento.CodEntrada).ElementAt(0);

                decimal totalRegistrado = 0;
                if (totalPagamentos != null)
                    totalRegistrado = (decimal)totalPagamentos;

                if ( (totalRegistrado + entradaPagamento.Valor) > (entrada.TotalNota + entrada.ValorFrete) ){
                    throw new NegocioException("O valor dos pagamentos não pode ultrapassar o valor da nota mais o valor do frete");
                }

                tb_entrada_forma_pagamento _entradaFormaPagamentoE = new tb_entrada_forma_pagamento();
                Atribuir(entradaPagamento, _entradaFormaPagamentoE);

                var repEntradaPagamento = new RepositorioGenerico<tb_entrada_forma_pagamento>();

                repEntradaPagamento.Inserir(_entradaFormaPagamentoE);
                repEntradaPagamento.SaveChanges();

                return _entradaFormaPagamentoE.codEntradaFormaPagamento;
            }
            catch (Exception e)
            {
                throw new DadosException("Pagamentos", e.Message, e);
            }
        }

        private static void Atribuir(EntradaPagamento entradaPagamento, tb_entrada_forma_pagamento _entradaFormaPagamentoE)
        {
            _entradaFormaPagamentoE.codContaBanco = entradaPagamento.CodContaBanco;
            _entradaFormaPagamentoE.codEntrada = entradaPagamento.CodEntrada;
            _entradaFormaPagamentoE.codFormaPagamento = entradaPagamento.CodFormaPagamento;
            _entradaFormaPagamentoE.data = entradaPagamento.Data;
            _entradaFormaPagamentoE.pagamentoDoFrete = entradaPagamento.PagamentoDoFrete;
            _entradaFormaPagamentoE.valor = entradaPagamento.Valor;
        }

        /// <summary>
        /// REmover uma determinada entrada pagamento
        /// </summary>
        /// <param name="codEntradaPagamento"></param>
        public void Remover(Int64 codEntradaPagamento)
        {
            try
            {
                var repEntradaPagamento = new RepositorioGenerico<tb_entrada_forma_pagamento>();
                repEntradaPagamento.Remover(ep => ep.codEntradaFormaPagamento == codEntradaPagamento);
                repEntradaPagamento.SaveChanges();
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
        private IQueryable<EntradaPagamento> GetQuery()
        {
            var repEntradaPagamento = new RepositorioGenerico<tb_entrada_forma_pagamento>();
            var saceEntities = (SaceEntities)repEntradaPagamento.ObterContexto();
            var query = from entradaFormaPagamento in saceEntities.tb_entrada_forma_pagamento
                        select new EntradaPagamento
                        {
                            CodContaBanco = entradaFormaPagamento.codContaBanco,
                            CodEntrada = entradaFormaPagamento.codEntrada,
                            CodEntradaFormaPagamento = entradaFormaPagamento.codEntradaFormaPagamento,
                            CodFormaPagamento = entradaFormaPagamento.codFormaPagamento,
                            Data = (DateTime) entradaFormaPagamento.data,
                            PagamentoDoFrete = (bool) entradaFormaPagamento.pagamentoDoFrete,
                            Valor = (decimal) entradaFormaPagamento.valor
                        };
            return query;
        }

        /// <summary>
        /// Obter pagamentos de uma determinada entrada
        /// </summary>
        /// <param name="codEntrada"></param>
        /// <returns></returns>
        public IEnumerable<EntradaPagamento> ObterPorEntrada(long codEntrada)
        {
            return GetQuery().Where(ep => ep.CodEntrada == codEntrada).ToList();
        }

    }
}
