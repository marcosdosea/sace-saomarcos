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
                    conta.Valor, conta.Observacao, conta.CodPagamento);

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
                    conta.Valor, conta.Observacao, conta.CodConta, conta.CodPagamento);
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

        public saceDataSetConsultas.ContasPessoaDataTable obterContasPorPessoaSituacaoDataTable(Int64 codPessoa)
        {

            //Dados.saceDataSetConsultasTableAdapters.ContasPessoaTableAdapter adapter = new Dados.saceDataSetConsultasTableAdapters.ContasPessoaTableAdapter();
            //adapter.
            StringBuilder comando_sql = new StringBuilder();
            comando_sql.Append("SELECT tb_conta.codConta, tb_conta.codSaida, tb_conta.dataVencimento, tb_conta.codSituacao, tb_situacao_conta.descricaoSituacao, tb_conta.valor, tb_saida.pedidoGerado AS CF, tb_conta.codPessoa ");
            comando_sql.Append("FROM tb_conta INNER JOIN  tb_situacao_conta ON tb_conta.codSituacao = tb_situacao_conta.codSituacao INNER JOIN tb_saida ON tb_conta.codSaida = tb_saida.codSaida ");
            comando_sql.Append("WHERE tb_conta.codPessoa = " + codPessoa.ToString()); 
            
            
            // create a new data adapter based on the specified query.
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            adapter.SelectCommand = new MySqlCommand(comando_sql.ToString(), new MySqlConnection(Dados.Properties.Settings.Default.saceConnectionString));

            
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
                conta.CodConta = Convert.ToInt64(contaDT.Rows[0]["codConta"].ToString());
                conta.CodDocumento = Convert.ToInt64(contaDT.Rows[0]["codDocumentoPagamento"].ToString());
                conta.CodEntrada = Convert.ToInt64(contaDT.Rows[0]["codEntrada"].ToString());
                conta.CodPessoa = Convert.ToInt64(contaDT.Rows[0]["codPessoa"].ToString());
                conta.CodPlanoConta = Convert.ToInt32(contaDT.Rows[0]["codPlanoConta"].ToString());
                conta.CodSaida = Convert.ToInt64(contaDT.Rows[0]["codSaida"].ToString());
                conta.CodSituacao = Convert.ToChar(contaDT.Rows[0]["codSituacao"].ToString());
                conta.DataVencimento = Convert.ToDateTime(contaDT.Rows[0]["dataVencimento"].ToString());
                conta.Observacao = contaDT.Rows[0]["observacao"].ToString();
                conta.Valor = Convert.ToDecimal(contaDT.Rows[0]["valor"].ToString());
                contas.Add(conta);
            }

            return contas;
        }
    }
}