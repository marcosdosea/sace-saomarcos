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
    public class GerenciadorConta : IGerenciadorConta
    {
        private static IGerenciadorConta gConta;
        private static tb_contaTableAdapter tb_contaTA;
        
        public static IGerenciadorConta getInstace()
        {
            if (gConta == null)
            {
                gConta = new GerenciadorConta();
                tb_contaTA = new tb_contaTableAdapter();
            }
            return gConta;
        }

        public Int64 inserir(Conta conta)
        {
            try
            {
                tb_contaTA.Insert(conta.CodPlanoConta, conta.CodPessoa, conta.CodSituacao.ToString(), 
                    conta.CodDocumento, conta.CodEntrada, conta.CodSaida,  conta.DataVencimento,
                    conta.Valor, conta.Observacao, conta.Desconto, conta.CodPagamento);

                return (Int64) tb_contaTA.getMaxCodConta();
            }
            catch (Exception e)
            {
                throw new DadosException("Conta", e.Message, e);
            }
        }

        public void atualizar(Conta conta)
        {
            if ( (conta.CodEntrada != 1) || (conta.CodSaida != 1) )
                throw new NegocioException("Essa conta não pode ser alterada por estar associada a uma entrada / saída.");

            try
            {
                tb_contaTA.Update(conta.CodPlanoConta, conta.CodPessoa, conta.CodSituacao.ToString(),
                    conta.CodDocumento, conta.CodEntrada, conta.CodSaida, conta.DataVencimento,
                    conta.Valor, conta.Observacao, conta.Desconto, conta.CodPagamento, conta.CodConta);
            }
            catch (Exception e)
            {
                throw new DadosException("Conta", e.Message, e);
            }
        }

        public void remover(Int64 codconta)
        {
            try
            {
                tb_contaTA.Delete(codconta);
            }
            catch (Exception e)
            {
                throw new DadosException("Conta", e.Message, e);
            }
        }

        public List<Conta> obterContasPorEntada(Int64 codEntrada)
        {
            Dados.saceDataSetTableAdapters.tb_contaTableAdapter tb_contaTA = new tb_contaTableAdapter();
            Dados.saceDataSet.tb_contaDataTable contaDT = tb_contaTA.GetDataByCodEntrada(codEntrada);

            return converterListaConta(contaDT);
        }

        /// <summary>
        /// Obter todas as contas em aberto da pessoa
        /// </summary>
        /// <param name="codPessoa"> código da pessoa </param>
        /// <returns> Datatable com todas as contas </returns>
        public Dados.saceDataSetConsultas.ContasPessoaDataTable ObterContasPorPessoaAberta(Int64 codPessoa)
        {
            StringBuilder comando_sql = new StringBuilder();
            comando_sql.Append("SELECT tb_conta.codConta, tb_conta.codSaida, tb_conta.dataVencimento, tb_conta.codSituacao, tb_situacao_conta.descricaoSituacao, tb_conta.valor, tb_saida.pedidoGerado AS CF, tb_conta.codPessoa, tb_conta.desconto, (tb_conta.valor - tb_conta.desconto) AS valorPagar ");
            comando_sql.Append("FROM tb_conta INNER JOIN  tb_situacao_conta ON tb_conta.codSituacao = tb_situacao_conta.codSituacao INNER JOIN tb_saida ON tb_conta.codSaida = tb_saida.codSaida ");
            comando_sql.Append("WHERE tb_conta.codPessoa = " + codPessoa.ToString());
            comando_sql.Append(" ORDER BY tb_conta.dataVencimento, tb_conta.codSaida");
            
            // cria novo adapter para executar a consulta
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = new MySqlCommand(comando_sql.ToString(), new MySqlConnection(Dados.Properties.Settings.Default.saceConnectionString));

            // preencher data table com os dados da consulta
            saceDataSetConsultas.ContasPessoaDataTable contaDT = new saceDataSetConsultas.ContasPessoaDataTable();
            adapter.Fill(contaDT);
            return contaDT;
        }

        public Dados.saceDataSetConsultas.ContasPessoaDataTable ObterContasPorPessoaSituacaoPeriodo(Int64 codPessoa, List<char> situacoes, DateTime dataInicial, DateTime dataFinal)
        {
            StringBuilder comando_sql = new StringBuilder();
            comando_sql.Append("SELECT tb_conta.codConta, tb_conta.codSaida, tb_conta.dataVencimento, tb_conta.codSituacao, tb_situacao_conta.descricaoSituacao, tb_conta.valor, tb_saida.pedidoGerado AS CF, tb_conta.codPessoa, tb_conta.desconto, (tb_conta.valor - tb_conta.desconto) AS valorPagar  ");
            comando_sql.Append("FROM tb_conta INNER JOIN  tb_situacao_conta ON tb_conta.codSituacao = tb_situacao_conta.codSituacao INNER JOIN tb_saida ON tb_conta.codSaida = tb_saida.codSaida ");
            comando_sql.Append("WHERE tb_conta.codPessoa = " + codPessoa.ToString());
            if (situacoes.Count > 0)
            {
                comando_sql.Append(" AND (");
                for (int i = 0; i < situacoes.Count; i++)
                {
                    comando_sql.Append("tb_conta.codSituacao = '" + situacoes[i] + "'");
                    if (i + 1 < situacoes.Count)
                    {
                        comando_sql.Append(" OR ");
                    }
                }
                comando_sql.Append(")");
            }


            comando_sql.Append(" AND tb_conta.dataVencimento >= STR_TO_DATE('" + dataInicial.ToShortDateString() + "' , '%d/%m/%Y')");
            comando_sql.Append(" AND tb_conta.dataVencimento <= STR_TO_DATE('" + dataFinal.ToShortDateString() + "' , '%d/%m/%Y')");

            comando_sql.Append(" ORDER BY tb_conta.dataVencimento, tb_conta.codSaida");

            // cria novo adapter para executar a consulta
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = new MySqlCommand(comando_sql.ToString(), new MySqlConnection(Dados.Properties.Settings.Default.saceConnectionString));

            // preencher data table com os dados da consulta
            saceDataSetConsultas.ContasPessoaDataTable contaDT = new saceDataSetConsultas.ContasPessoaDataTable();
            adapter.Fill(contaDT);
            return contaDT;
        }
        

        public List<Conta> obterContasPorSaida(Int64 codSaida)
        {
            Dados.saceDataSetTableAdapters.tb_contaTableAdapter tb_contaTA = new tb_contaTableAdapter();
            Dados.saceDataSet.tb_contaDataTable contaDT = tb_contaTA.GetDataByCodSaida(codSaida);

            return converterListaConta(contaDT);
        }

        public List<Conta> obterContasEntradaPorCodPagamento(Int64 codEntrada, Int64 codPagamento)
        {
            Dados.saceDataSetTableAdapters.tb_contaTableAdapter tb_contaTA = new tb_contaTableAdapter();
            Dados.saceDataSet.tb_contaDataTable contaDT = tb_contaTA.GetDataByCodEntradaCodPagamento(codEntrada, codPagamento);

            return converterListaConta(contaDT);
        }
        public List<Conta> obterContasSaidaPorCodPagamento(Int64 codSaida, Int64 codPagamento)
        {
            Dados.saceDataSetTableAdapters.tb_contaTableAdapter tb_contaTA = new tb_contaTableAdapter();
            Dados.saceDataSet.tb_contaDataTable contaDT = tb_contaTA.GetDataByCodSaidaCodPagamento(codSaida, codPagamento);

            return converterListaConta(contaDT);
        }

        private List<Conta> converterListaConta(Dados.saceDataSet.tb_contaDataTable contaDT)
        {
            List<Conta> contas = new List<Conta>();
            for (int i = 0; i < contaDT.Rows.Count; i++)
            {
                Conta conta = new Conta();
                conta.CodConta = Convert.ToInt64(contaDT.Rows[i]["codConta"].ToString());
                conta.CodDocumento = Convert.ToInt64(contaDT.Rows[i]["codDocumentoPagamento"].ToString());
                conta.CodEntrada = Convert.ToInt64(contaDT.Rows[i]["codEntrada"].ToString());
                conta.CodPessoa = Convert.ToInt64(contaDT.Rows[i]["codPessoa"].ToString());
                conta.CodPlanoConta = Convert.ToInt32(contaDT.Rows[i]["codPlanoConta"].ToString());
                conta.CodSaida = Convert.ToInt64(contaDT.Rows[i]["codSaida"].ToString());
                conta.CodSituacao = Convert.ToChar(contaDT.Rows[i]["codSituacao"].ToString());
                conta.DataVencimento = Convert.ToDateTime(contaDT.Rows[i]["dataVencimento"].ToString());
                conta.Observacao = contaDT.Rows[i]["observacao"].ToString();
                conta.Valor = Convert.ToDecimal(contaDT.Rows[i]["valor"].ToString());
                conta.CodPagamento = Convert.ToInt64(contaDT.Rows[i]["codPagamento"].ToString());
                conta.Desconto = Convert.ToDecimal(contaDT.Rows[i]["desconto"].ToString());
                contas.Add(conta);
            }

            return contas;
        }
    }
}