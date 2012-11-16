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
    public class GerenciadorCfop 
    {
        private static GerenciadorCfop gCfop;
        private static tb_cfopTableAdapter tb_cfopTA;


        public static GerenciadorCfop getInstace()
        {
            if (gCfop == null)
            {
                gCfop = new GerenciadorCfop();
                tb_cfopTA = new tb_cfopTableAdapter();
            }
            return gCfop;
        }

        public Int64 inserir(Cfop cfop)
        {
            try
            {
                tb_cfopTA.Insert(cfop.CodCfop, cfop.Descricao, cfop.Icms.ToString("N2"));
                return cfop.CodCfop;
            }
            catch (Exception e)
            {
                throw new DadosException("Cfop", e.Message, e);
            }
        }

        public void atualizar(Cfop cfop)
        {
            try
            {
                tb_cfopTA.Update(cfop.Descricao, cfop.Icms, cfop.CodCfop);
            }
            catch (Exception e)
            {
                throw new DadosException("Cfop", e.Message, e);
            }
        }

        public void remover(Int32 codCfop)
        {
            try
            {
                tb_cfopTA.Delete(codCfop);
            }
            catch (Exception e)
            {
                throw new DadosException("Cfop", e.Message, e);
            }
        }
    }
}