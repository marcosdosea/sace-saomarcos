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
    public class GerenciadorPlanoConta : IGerenciadorPlanoConta
    {
        private static IGerenciadorPlanoConta gPlanoConta;
        private static tb_plano_contaTableAdapter tb_plano_contaTA;
        
        public static IGerenciadorPlanoConta getInstace()
        {
            if (gPlanoConta == null)
            {
                gPlanoConta = new GerenciadorPlanoConta();
                tb_plano_contaTA = new tb_plano_contaTableAdapter();
            }
            return gPlanoConta;
        }

        public void inserir(PlanoConta planoConta)
        {
            try
            {
                tb_plano_contaTA.Insert(planoConta.CodGrupoConta, planoConta.Descricao,
                    planoConta.TipoConta.ToString(), planoConta.DiaBase);
            }
            catch (Exception e)
            {
                throw new DadosException("Plano de Contas", e.Message, e);
            }
        }

        public void atualizar(PlanoConta planoConta)
        {
            try
            {
                tb_plano_contaTA.Update(planoConta.CodGrupoConta, planoConta.Descricao,
                    planoConta.TipoConta.ToString(), planoConta.DiaBase, planoConta.CodPlanoConta);
            }
            catch (Exception e)
            {
                throw new DadosException("Plano de Contas", e.Message, e);
            }
        }

        public void remover(Int64 codplanoConta)
        {
            try
            {
                tb_plano_contaTA.Delete(codplanoConta);
            }
            catch (Exception e)
            {
                throw new DadosException("Plano de Contas", e.Message, e);
            }
        }
    }
}
