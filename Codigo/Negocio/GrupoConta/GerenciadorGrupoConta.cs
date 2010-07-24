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
    public class GerenciadorGrupoConta : IGerenciadorGrupoConta
    {
        private static IGerenciadorGrupoConta gGrupoConta;
        private static tb_grupo_contaTableAdapter tb_grupo_contaTA;
        
        public static IGerenciadorGrupoConta getInstace()
        {
            if (gGrupoConta == null)
            {
                gGrupoConta = new GerenciadorGrupoConta();
                tb_grupo_contaTA = new tb_grupo_contaTableAdapter();
            }
            return gGrupoConta;
        }

        public void inserir(GrupoConta grupoConta)
        {
            try
            {
                tb_grupo_contaTA.Insert(grupoConta.Descricao);
            }
            catch (Exception e)
            {
                throw new DadosException("Grupo de Contas", e.Message, e);
            }
        }

        public void atualizar(GrupoConta grupoConta)
        {
            try
            {
                tb_grupo_contaTA.Update(grupoConta.Descricao, grupoConta.CodGrupoConta);
            }
            catch (Exception e)
            {
                throw new DadosException("Grupo de Contas", e.Message, e);
            }
        }

        public void remover(Int32 codGrupoConta)
        {
            try
            {
                tb_grupo_contaTA.Delete(codGrupoConta);
            }
            catch (Exception e)
            {
                throw new DadosException("Grupo de Contas", e.Message, e);
            }
        }
    }
}
