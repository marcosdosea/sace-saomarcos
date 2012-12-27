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
using MySql.Data.MySqlClient;

namespace Negocio
{
    public class GerenciadorSaidaPagamento {
        
        private static GerenciadorSaidaPagamento gSaidaPagamento;
        private static tb_saida_forma_pagamentoTableAdapter tb_SaidaPagamentoTA;
        
        public static GerenciadorSaidaPagamento getInstace()
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
                if ((saidaPagamento.Valor == 0) && ((saida.TotalAVista-saida.TotalPago) != 0)) 
                {
                    throw new NegocioException("O valor recebido não pode ser igual a zero.");
                }

                if ( (saida.TotalAVista < 0) && (Math.Abs(saidaPagamento.Valor) > Math.Abs(saida.TotalAVista - saida.TotalPago)) )
                {
                    throw new NegocioException("O valor da devolução não pode ser maior que o valor dos produtos.");
                }

                if (Math.Abs(saida.TotalAVista) < Math.Abs(saida.TotalPago))
                {
                    throw new NegocioException("Não é necessário registrar mais outro pagamento.");
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


                //decimal total = totalPagamentos(saida.CodSaida);

                if (Math.Abs(saida.TotalAVista - saida.TotalPago) > 0)
                {

                    tb_SaidaPagamentoTA.Insert(saidaPagamento.CodSaida,
                        saidaPagamento.CodFormaPagamento, saidaPagamento.CodContaBanco, saidaPagamento.CodCartaoCredito,
                        saidaPagamento.Valor, saidaPagamento.Data, saidaPagamento.CodDocumentoPagamento,
                        saidaPagamento.Parcelas, saidaPagamento.IntervaloDias);

                    saida.TotalPago = totalPagamentos(saida.CodSaida);
                    saida.Troco = saida.TotalPago - saida.TotalAVista;
                    saida.Desconto = 100 - ((saida.TotalAVista / saida.Total) * 100);
                    GerenciadorSaida.getInstace().atualizar(saida);


                    if ((saida.TipoSaida == Saida.TIPO_PRE_VENDA) || (saida.TipoSaida == Saida.TIPO_VENDA))
                    {
                        List<SaidaPagamento> saidaPagamentos = GerenciadorSaidaPagamento.getInstace().obterSaidaPagamentos(saida.CodSaida);
                        GerenciadorSaida.getInstace().registrarPagamentosSaida(saidaPagamentos, saida);
                    }
                }
                // quando é necessário apenas atualizar os dados do cliente
                else
                {
                    GerenciadorSaida.getInstace().atualizar(saida);
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

        public void removerPagamentos(Saida saida)
        {
            List<SaidaPagamento> pagamentos = obterSaidaPagamentos(saida.CodSaida);

            foreach (SaidaPagamento pagamento in pagamentos)
            {
                remover(pagamento.CodSaidaPagamento, saida);
            }

        }
        public void remover(Int64 codSaidaPagamento, Saida saida)
        {
            try
            {
                if ((saida.TipoSaida == Saida.TIPO_PRE_VENDA) || (saida.TipoSaida == Saida.TIPO_VENDA))
                {
                    List<Conta> contas = GerenciadorConta.GetInstance().ObterPorSaidaPagamento(saida.CodSaida, codSaidaPagamento).ToList();

                    foreach (Conta conta in contas)
                    {
                        GerenciadorMovimentacaoConta.getInstace().removerMovimentacoesConta(conta);
                        GerenciadorConta.GetInstance().Remover(conta.CodConta);
                    }
               }
               tb_SaidaPagamentoTA.Delete(codSaidaPagamento);

               saida.TotalPago = totalPagamentos(saida.CodSaida);
               saida.Troco = saida.TotalPago - saida.TotalAVista;
               saida.Desconto = 100 - ((saida.TotalAVista / saida.Total) * 100);
               GerenciadorSaida.getInstace().atualizar(saida);
            }
            catch (Exception e)
            {
                throw new DadosException("Pagamentos", e.Message, e);
            }
        }


        public SaidaPagamento obterSaidaPagamento(long codSaidaPagamento)
        {
            List<SaidaPagamento> pagamentos = new List<SaidaPagamento>();

            saceDataSet.tb_saida_forma_pagamentoDataTable tbsaidaPagamento = tb_SaidaPagamentoTA.GetDataByCodSaidaPagamento(codSaidaPagamento);

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
            return pagamentos[0];
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


        public List<SaidaPagamento> obterSaidaPagamentos(List<long> listaCodSaidas)
        {
            StringBuilder comando_sql = new StringBuilder();
            comando_sql.Append("SELECT tb_saida_forma_pagamento.codSaidaFormaPagamento, tb_saida_forma_pagamento.codSaida, tb_saida_forma_pagamento.codFormaPagamento, ");
            comando_sql.Append("tb_saida_forma_pagamento.codContaBanco, tb_saida_forma_pagamento.codCartao, SUM(tb_saida_forma_pagamento.valor) as somaValor, tb_saida_forma_pagamento.data, tb_forma_pagamento.descricao AS descricaoFormaPagamento, tb_conta_banco.descricao AS descricaoContaBanco, tb_cartao_credito.nome AS nomeCartaoCredito, tb_saida_forma_pagamento.codDocumentoPagamento, tb_documento_pagamento.numeroDocumento, tb_saida_forma_pagamento.parcelas, tb_saida_forma_pagamento.intervaloDias, tb_cartao_credito.mapeamento AS mapeamentoCartao, tb_forma_pagamento.mapeamento AS mapeamentoFormaPagamento");
            comando_sql.Append(" FROM            tb_saida_forma_pagamento INNER JOIN ");
            comando_sql.Append(" tb_forma_pagamento ON tb_saida_forma_pagamento.codFormaPagamento = tb_forma_pagamento.codFormaPagamento INNER JOIN");
            comando_sql.Append(" tb_conta_banco ON tb_saida_forma_pagamento.codContaBanco = tb_conta_banco.codContaBanco INNER JOIN");
            comando_sql.Append(" tb_cartao_credito ON tb_saida_forma_pagamento.codCartao = tb_cartao_credito.codCartao INNER JOIN");
            comando_sql.Append(" tb_documento_pagamento ON tb_saida_forma_pagamento.codDocumentoPagamento = tb_documento_pagamento.codDocumentoPagamento");
            comando_sql.Append(" WHERE        (tb_saida_forma_pagamento.codSaida IN (");
            for (int i = 0; i < listaCodSaidas.Count; i++) {
                comando_sql.Append(listaCodSaidas[i]);
                if (i + 1 < listaCodSaidas.Count)
                    comando_sql.Append(",");
            }
            comando_sql.Append(")) GROUP BY codFormaPagamento, codCartao;");

            // cria novo adapter para executar a consulta
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = new MySqlCommand(comando_sql.ToString(), new MySqlConnection(Dados.Properties.Settings.Default.saceConnectionString));

            // preencher data table com os dados da consulta
            saceDataSet.tb_saida_forma_pagamentoDataTable tbsaidaPagamento = new saceDataSet.tb_saida_forma_pagamentoDataTable();
            adapter.Fill(tbsaidaPagamento);
            List<SaidaPagamento> pagamentos = new List<SaidaPagamento>();
            for (int i = 0; i < tbsaidaPagamento.Count; i++)
            {
                SaidaPagamento saidaPagamento = new SaidaPagamento();
                saidaPagamento.CodContaBanco = Convert.ToInt32(tbsaidaPagamento.Rows[i]["codContaBanco"].ToString());
                saidaPagamento.CodCartaoCredito = Convert.ToInt32(tbsaidaPagamento.Rows[i]["codCartao"].ToString());
                saidaPagamento.CodFormaPagamento = Convert.ToInt32(tbsaidaPagamento.Rows[i]["codFormaPagamento"].ToString());
                saidaPagamento.CodSaida = Convert.ToInt64(tbsaidaPagamento.Rows[i]["codSaida"].ToString());
                saidaPagamento.CodSaidaPagamento = Convert.ToInt64(tbsaidaPagamento.Rows[i]["codSaidaFormaPagamento"].ToString());
                saidaPagamento.Data = Convert.ToDateTime(tbsaidaPagamento.Rows[i]["data"].ToString());
                saidaPagamento.Valor = Convert.ToDecimal(tbsaidaPagamento.Rows[i]["somaValor"].ToString());
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
