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
    public class GerenciadorSaidaPagamento : IGerenciadorSaidaPagamento
    {
        private static IGerenciadorSaidaPagamento gSaidaPagamento;
        private static tb_saida_forma_pagamentoTableAdapter tb_SaidaPagamentoTA;
        
        public static IGerenciadorSaidaPagamento getInstace()
        {
            if (gSaidaPagamento == null)
            {
                gSaidaPagamento = new GerenciadorSaidaPagamento();
                tb_SaidaPagamentoTA = new tb_saida_forma_pagamentoTableAdapter();
            }
            return gSaidaPagamento;
        }

        public Int64 inserir(SaidaPagamento saidaPagamento, Saida saida)
        {
            try
            {
                if (saidaPagamento.Valor <= 0)
                {
                    throw new NegocioException("O valor recebido deve ser maior que zero e não deve ultrapassar o valor da venda.");
                }


                if ((saidaPagamento.CodFormaPagamento != FormaPagamento.DINHEIRO) && (saidaPagamento.CodFormaPagamento != FormaPagamento.CARTAO)
                    && (saidaPagamento.CodPessoaResponsavel == Util.Global.CLIENTE_PADRAO))
                {
                    throw new NegocioException("É necessário informar um cliente para utilizar essa forma de pagamento.");
                }

                if ((saidaPagamento.CodFormaPagamento == FormaPagamento.BOLETO) && (saidaPagamento.CodDocumentoPagamento == 1))
                {
                    throw new NegocioException("É necessário cadastrar os dados do boleto para utilizar essa forma de pagamento.");
                }

                if ((saidaPagamento.CodFormaPagamento == FormaPagamento.CHEQUE) && (saidaPagamento.CodDocumentoPagamento == 1))
                {
                    throw new NegocioException("É necessário cadastrar os dados do cheque para utilizar essa forma de pagamento.");
                }
                if ((saidaPagamento.CodFormaPagamento == FormaPagamento.CARTAO) || (saidaPagamento.CodFormaPagamento == FormaPagamento.CREDIARIO)
                    || (saidaPagamento.CodFormaPagamento == FormaPagamento.DEPOSITO))
                {
                    saidaPagamento.CodDocumentoPagamento = Global.DOCUMENTO_PADRAO;
                }

                tb_SaidaPagamentoTA.Insert(saidaPagamento.CodSaida,
                    saidaPagamento.CodFormaPagamento, saidaPagamento.CodContaBanco, saidaPagamento.CodCartaoCredito,
                    saidaPagamento.Valor, saidaPagamento.Data, saidaPagamento.CodDocumentoPagamento, 
                    saidaPagamento.Parcelas, saidaPagamento.IntervaloDias);

                if ((saida.TipoSaida == Saida.TIPO_PRE_VENDA) || (saida.TipoSaida == Saida.TIPO_VENDA))
                {
                    GerenciadorSaida.getInstace().encerrar(saida);
                }

            }
            catch (Exception e)
            {
                throw new DadosException("Pagamentos", e.Message, e);
            }
            return 0;
        }

        public void atualizar(SaidaPagamento saidaPagamento)
        {
            try
            {
                tb_SaidaPagamentoTA.Update(saidaPagamento.CodSaida, saidaPagamento.CodFormaPagamento,
                    saidaPagamento.CodContaBanco, saidaPagamento.CodCartaoCredito, saidaPagamento.Valor,
                    saidaPagamento.Data, saidaPagamento.CodDocumentoPagamento,
                    saidaPagamento.Parcelas, saidaPagamento.IntervaloDias, saidaPagamento.CodSaidaPagamento);
            }
            catch (Exception e)
            {
                throw new DadosException("Pagamentos", e.Message, e);
            }
        }

        public void remover(Int64 codSaidaPagamento, Saida saida)
        {
            try
            {
                if ((saida.TipoSaida == Saida.TIPO_PRE_VENDA) || (saida.TipoSaida == Saida.TIPO_VENDA))
                {
                    List<Conta> contas = GerenciadorConta.getInstace().obterContasSaidaPorCodPagamento(saida.CodSaida, codSaidaPagamento);

                    foreach (Conta conta in contas)
                    {
                        GerenciadorMovimentacaoConta.getInstace().removerMovimentacoesConta(conta);
                        GerenciadorConta.getInstace().remover(conta.CodConta);
                    }
               }
               tb_SaidaPagamentoTA.Delete(codSaidaPagamento); 
            }
            catch (Exception e)
            {
                throw new DadosException("Pagamentos", e.Message, e);
            }
        }

        public List<SaidaPagamento> obterSaidaPagamentosPorFormaPagamento(Int64 codSaida, Int32 codFormaPagamento)
        {
            List<SaidaPagamento> pagamentos = new List<SaidaPagamento>();

            saceDataSet.tb_saida_forma_pagamentoDataTable tbsaidaPagamento = tb_SaidaPagamentoTA.GetDataByCodSaidaFormaPagamento(codSaida, codFormaPagamento);

            for (int i = 0; i < tbsaidaPagamento.Count; i++)
            {
                SaidaPagamento saidaPagamento = new SaidaPagamento();
                saidaPagamento.CodContaBanco = Convert.ToInt32(tbsaidaPagamento.Rows[i]["codContaBanco"].ToString());
                saidaPagamento.CodCartaoCredito = Convert.ToInt32(tbsaidaPagamento.Rows[i]["codCartao"].ToString());
                saidaPagamento.CodFormaPagamento = Convert.ToInt32(tbsaidaPagamento.Rows[i]["codFormaPagamento"].ToString());
                saidaPagamento.CodSaida = Convert.ToInt64(tbsaidaPagamento.Rows[i]["codSaida"].ToString());
                saidaPagamento.CodSaidaPagamento = Convert.ToInt64(tbsaidaPagamento.Rows[i]["codSaidaFormaPagamento"].ToString());
                saidaPagamento.Data = Convert.ToDateTime(tbsaidaPagamento.Rows[i]["data"].ToString());
                saidaPagamento.Valor = Convert.ToDecimal(tbsaidaPagamento.Rows[i]["valor"].ToString());
                saidaPagamento.CodDocumentoPagamento = Convert.ToInt64(tbsaidaPagamento.Rows[i]["codDocumentoPagamento"].ToString());
                saidaPagamento.IntervaloDias = Convert.ToInt32(tbsaidaPagamento.Rows[i]["intervaloDias"].ToString());
                saidaPagamento.Parcelas = Convert.ToInt32(tbsaidaPagamento.Rows[i]["parcelas"].ToString());
                saidaPagamento.MapeamentoFormaPagamento = tbsaidaPagamento.Rows[i]["mapeamentoFormaPagamento"].ToString();
                saidaPagamento.MapeamentoCartao = tbsaidaPagamento.Rows[i]["mapeamentoCartao"].ToString();
                saidaPagamento.DescricaoFormaPagamento = tbsaidaPagamento.Rows[i]["descricaoFormaPagamento"].ToString();
                saidaPagamento.NomeCartaoCredito = tbsaidaPagamento.Rows[i]["nomeCartaoCredito"].ToString();

                pagamentos.Add(saidaPagamento);
            }
            return pagamentos;
        }


        public decimal totalPagamentos(Int64 codSaida)
        {
            decimal? totalPagamentos =  tb_SaidaPagamentoTA.TotalPagamentosByCodSaida(codSaida);
            return (totalPagamentos != null) ? (decimal) totalPagamentos : 0;
        }

        public List<SaidaPagamento> obterSaidaPagamentos(Int64 codSaida)
        {
            List<SaidaPagamento> pagamentos = new List<SaidaPagamento>();

            saceDataSet.tb_saida_forma_pagamentoDataTable tbsaidaPagamento = tb_SaidaPagamentoTA.GetDataByCodSaida(codSaida);
            
            for(int i = 0; i < tbsaidaPagamento.Count; i++) {
                SaidaPagamento saidaPagamento = new SaidaPagamento();
                saidaPagamento.CodContaBanco = Convert.ToInt32(tbsaidaPagamento.Rows[i]["codContaBanco"].ToString());
                saidaPagamento.CodCartaoCredito = Convert.ToInt32(tbsaidaPagamento.Rows[i]["codCartao"].ToString());
                saidaPagamento.CodFormaPagamento = Convert.ToInt32(tbsaidaPagamento.Rows[i]["codFormaPagamento"].ToString());
                saidaPagamento.CodSaida = Convert.ToInt64(tbsaidaPagamento.Rows[i]["codSaida"].ToString());
                saidaPagamento.CodSaidaPagamento = Convert.ToInt64(tbsaidaPagamento.Rows[i]["codSaidaFormaPagamento"].ToString());
                saidaPagamento.Data = Convert.ToDateTime(tbsaidaPagamento.Rows[i]["data"].ToString());
                saidaPagamento.Valor = Convert.ToDecimal(tbsaidaPagamento.Rows[i]["valor"].ToString());
                saidaPagamento.CodDocumentoPagamento = Convert.ToInt64(tbsaidaPagamento.Rows[i]["codDocumentoPagamento"].ToString());
                saidaPagamento.IntervaloDias = Convert.ToInt32(tbsaidaPagamento.Rows[i]["intervaloDias"].ToString());
                saidaPagamento.Parcelas = Convert.ToInt32(tbsaidaPagamento.Rows[i]["parcelas"].ToString());
                saidaPagamento.MapeamentoFormaPagamento = tbsaidaPagamento.Rows[i]["mapeamentoFormaPagamento"].ToString();
                saidaPagamento.MapeamentoCartao = tbsaidaPagamento.Rows[i]["mapeamentoCartao"].ToString();
                saidaPagamento.DescricaoFormaPagamento = tbsaidaPagamento.Rows[i]["descricaoFormaPagamento"].ToString();
                saidaPagamento.NomeCartaoCredito = tbsaidaPagamento.Rows[i]["nomeCartaoCredito"].ToString();

                pagamentos.Add(saidaPagamento);
            }
            return pagamentos;
        }
    }
}
