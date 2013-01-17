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

namespace Negocio
{
    public class GerenciadorEntradaPagamento 
    {
        private static GerenciadorEntradaPagamento gEntradaPagamento;
        private static RepositorioGenerico<EntradaFormaPagamentoE, SaceEntities> repEntradaPagamento;
        
        public static GerenciadorEntradaPagamento GetInstance()
        {
            if (gEntradaPagamento == null)
            {
                gEntradaPagamento = new GerenciadorEntradaPagamento();
                repEntradaPagamento = new RepositorioGenerico<EntradaFormaPagamentoE, SaceEntities>("chave");
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
                else if ((entradaPagamento.CodFormaPagamento == FormaPagamento.BOLETO) && (entradaPagamento.CodDocumentoPagamento == 1))
                {
                    throw new NegocioException("É necessário cadastrar os dados do boleto para utilizar essa forma de pagamento.");
                } 
                else if ((entradaPagamento.CodFormaPagamento == FormaPagamento.CHEQUE) && (entradaPagamento.CodDocumentoPagamento == 1))
                {
                    throw new NegocioException("É necessário cadastrar os dados do cheque para utilizar essa forma de pagamento.");
                } 
                else if ((entradaPagamento.CodFormaPagamento == FormaPagamento.CARTAO) || (entradaPagamento.CodFormaPagamento == FormaPagamento.CREDIARIO)
                    || (entradaPagamento.CodFormaPagamento == FormaPagamento.DEPOSITO))
                {
                    entradaPagamento.CodDocumentoPagamento = Global.DOCUMENTO_PADRAO;
                }

                decimal? totalPagamentos = ObterPorEntrada(entradaPagamento.CodEntrada).Sum(ep => ep.Valor);

                Entrada entrada = GerenciadorEntrada.GetInstance().Obter(entradaPagamento.CodEntrada).ElementAt(0);

                decimal totalRegistrado = 0;
                if (totalPagamentos != null)
                    totalRegistrado = (decimal)totalPagamentos;

                if ( (totalRegistrado + entradaPagamento.Valor) > (entrada.TotalNota + entrada.ValorFrete) ){
                    throw new NegocioException("O valor dos pagamentos não pode ultrapassar o valor da nota mais o valor do frete");
                }

                EntradaFormaPagamentoE _entradaFormaPagamentoE = new EntradaFormaPagamentoE();
                Atribuir(entradaPagamento, _entradaFormaPagamentoE);

                repEntradaPagamento.Inserir(_entradaFormaPagamentoE);
                repEntradaPagamento.SaveChanges();

                return _entradaFormaPagamentoE.codEntradaFormaPagamento;
            }
            catch (Exception e)
            {
                throw new DadosException("Pagamentos", e.Message, e);
            }
        }

        private static void Atribuir(EntradaPagamento entradaPagamento, EntradaFormaPagamentoE _entradaFormaPagamentoE)
        {
            _entradaFormaPagamentoE.codContaBanco = entradaPagamento.CodContaBanco;
            _entradaFormaPagamentoE.codDocumentoPagamento = entradaPagamento.CodDocumentoPagamento;
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
            var saceEntities = (SaceEntities)repEntradaPagamento.ObterContexto();
            var query = from entradaFormaPagamento in saceEntities.EntradaFormaPagamentoSet
                        select new EntradaPagamento
                        {
                            CodContaBanco = entradaFormaPagamento.codContaBanco,
                            CodDocumentoPagamento = entradaFormaPagamento.codDocumentoPagamento,
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
