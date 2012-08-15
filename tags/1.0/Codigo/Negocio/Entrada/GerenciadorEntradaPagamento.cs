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
    public class GerenciadorEntradaPagamento : IGerenciadorEntradaPagamento
    {
        private static IGerenciadorEntradaPagamento gEntradaPagamento;
        private static tb_entrada_forma_pagamentoTableAdapter tb_EntradaPagamentoTA;
        
        public static IGerenciadorEntradaPagamento getInstace()
        {
            if (gEntradaPagamento == null)
            {
                gEntradaPagamento = new GerenciadorEntradaPagamento();
                tb_EntradaPagamentoTA = new tb_entrada_forma_pagamentoTableAdapter();
            }
            return gEntradaPagamento;
        }

        
        public Int64 inserir(EntradaPagamento entradaPagamento) {
            throw new NegocioException("O método inserir entradaPagamento não deve ser utilizado. Contactar administrador");
        }

        public Int64 inserir(EntradaPagamento entradaPagamento, Entrada entrada)
        {
            try
            {
                if (entradaPagamento.Valor <= 0)
                {
                    throw new NegocioException("O valor do pagamento deve ser maior que zero e não deve ultrapassar o valor total da entrada.");
                }


                if ((entradaPagamento.CodFormaPagamento == FormaPagamento.BOLETO) && (entradaPagamento.CodDocumentoPagamento == 1))
                {
                    throw new NegocioException("É necessário cadastrar os dados do boleto para utilizar essa forma de pagamento.");
                }

                if ((entradaPagamento.CodFormaPagamento == FormaPagamento.CHEQUE) && (entradaPagamento.CodDocumentoPagamento == 1))
                {
                    throw new NegocioException("É necessário cadastrar os dados do cheque para utilizar essa forma de pagamento.");
                }

                if ((entradaPagamento.CodFormaPagamento == FormaPagamento.CARTAO) || (entradaPagamento.CodFormaPagamento == FormaPagamento.CREDIARIO)
                    || (entradaPagamento.CodFormaPagamento == FormaPagamento.DEPOSITO))
                {
                    entradaPagamento.CodDocumentoPagamento = Global.DOCUMENTO_PADRAO;
                }

                decimal? resultado = tb_EntradaPagamentoTA.TotalPagamentosByCodEntrada(entradaPagamento.CodEntrada);

                decimal totalRegistrado = 0;
                if (resultado != null)
                    totalRegistrado = (decimal)resultado;

                if ( (totalRegistrado + entradaPagamento.Valor) > (entrada.TotalNota + entrada.ValorFrete) ){
                    throw new NegocioException("O valor dos pagamentos não pode ultrapassar o valor da nota mais o valor do frete");
                }


                tb_EntradaPagamentoTA.Insert(entradaPagamento.CodEntrada,
                    entradaPagamento.CodFormaPagamento, entradaPagamento.CodContaBanco, entradaPagamento.CodDocumentoPagamento,
                    entradaPagamento.Valor, entradaPagamento.Data, entradaPagamento.PagamentoDoFrete);
            }
            catch (Exception e)
            {
                throw new DadosException("Pagamentos", e.Message, e);
            }
            return 0;
        }


        public void atualizar(EntradaPagamento entradaPagamento)
        {
            try
            {
                tb_EntradaPagamentoTA.Update(entradaPagamento.CodEntrada,
                    entradaPagamento.CodFormaPagamento, entradaPagamento.CodContaBanco, 
                    entradaPagamento.CodDocumentoPagamento, entradaPagamento.Valor, 
                    entradaPagamento.Data, entradaPagamento.PagamentoDoFrete, 
                    entradaPagamento.CodEntradaFormaPagamento);
            }
            catch (Exception e)
            {
                throw new DadosException("Pagamentos", e.Message, e);
            }
        }

        public void remover(Int64 codEntradaPagamento)
        {
            try
            {
                tb_EntradaPagamentoTA.Delete(codEntradaPagamento);
            }
            catch (Exception e)
            {
                throw new DadosException("Pagamentos", e.Message, e);
            }
        }

        public decimal totalPagamentos(Int64 codEntrada)
        {
            decimal? totalPagamentos =  tb_EntradaPagamentoTA.TotalPagamentosByCodEntrada(codEntrada);
            return (totalPagamentos != null) ? (decimal) totalPagamentos : 0;
        }

        public List<EntradaPagamento> obterEntradaPagamentos(Int64 codEntrada)
        {
            List<EntradaPagamento> pagamentos = new List<EntradaPagamento>();

            saceDataSet.tb_entrada_forma_pagamentoDataTable tbentradaPagamento = tb_EntradaPagamentoTA.GetDataByCodEntrada(codEntrada);
            
            for(int i = 0; i < tbentradaPagamento.Count; i++) {
                EntradaPagamento entradaPagamento = new EntradaPagamento();
                entradaPagamento.CodContaBanco = Convert.ToInt32(tbentradaPagamento.Rows[i]["codContaBanco"].ToString());
                entradaPagamento.CodFormaPagamento = Convert.ToInt32(tbentradaPagamento.Rows[i]["codFormaPagamento"].ToString());
                entradaPagamento.CodEntrada = Convert.ToInt64(tbentradaPagamento.Rows[i]["codEntrada"].ToString());
                entradaPagamento.CodEntradaFormaPagamento = Convert.ToInt64(tbentradaPagamento.Rows[i]["codEntradaFormaPagamento"].ToString());
                entradaPagamento.Data = Convert.ToDateTime(tbentradaPagamento.Rows[i]["data"].ToString());
                entradaPagamento.Valor = Convert.ToDecimal(tbentradaPagamento.Rows[i]["valor"].ToString());
                entradaPagamento.CodDocumentoPagamento = Convert.ToInt64(tbentradaPagamento.Rows[i]["codDocumentoPagamento"].ToString());
                entradaPagamento.PagamentoDoFrete = Convert.ToBoolean(tbentradaPagamento.Rows[i]["pagamentoDoFrete"].ToString());
                pagamentos.Add(entradaPagamento);
            }
            return pagamentos;
        }
    }
}
