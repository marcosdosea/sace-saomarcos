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

        public void inserir(Conta conta)
        {
            try
            {
                tb_contaTA.Insert(conta.CodEntrada, conta.CodSaida, conta.Documento, conta.CodPlanoConta,
                    conta.CodPessoa, conta.DataVencimento, conta.Valor.ToString(), conta.Situacao.ToString(),
                    conta.Observacao, conta.TipoConta.ToString());
            }
            catch (Exception e)
            {
                throw new DadosException("Conta", e.Message, e);
            }
        }

        public void atualizar(Conta conta)
        {
            try
            {
                tb_contaTA.Update(conta.CodEntrada, conta.CodSaida, conta.Documento, conta.CodPlanoConta,
                    conta.CodPessoa, conta.DataVencimento, conta.Valor, conta.Situacao.ToString(), conta.Observacao,
                    conta.TipoConta.ToString(), conta.CodConta);
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
    }
}
