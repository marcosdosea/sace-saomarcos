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
                    conta.Valor.ToString(), conta.Observacao);

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
                    conta.Valor, conta.Observacao, conta.CodConta);
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
        public List<Conta> obterContasPorSaida(Int64 codSaida)
        {
            Dados.saceDataSetTableAdapters.tb_contaTableAdapter tb_contaTA = new tb_contaTableAdapter();
            Dados.saceDataSet.tb_contaDataTable contaDT = tb_contaTA.GetDataByCodSaida(codSaida);

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