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
    public class GerenciadorSubgrupo 
    {
        private static GerenciadorSubgrupo gSubgrupo;
        private static tb_subgrupoTableAdapter tb_subgrupoTA;
        
        
        public static GerenciadorSubgrupo getInstace()
        {
            if (gSubgrupo == null)
            {
                gSubgrupo = new GerenciadorSubgrupo();
                tb_subgrupoTA = new tb_subgrupoTableAdapter();
            }
            return gSubgrupo;
        }

        public Int64 inserir(Subgrupo subgrupo)
        {
            try
            {
                tb_subgrupoTA.Insert(subgrupo.Descricao, subgrupo.CodGrupo);
                return 0;
            }
            catch (Exception e)
            {
                throw new DadosException("Subgrupo", e.Message, e);
            }
        }

        public void atualizar(Subgrupo subgrupo)
        {
            try
            {
                tb_subgrupoTA.Update(subgrupo.Descricao, subgrupo.CodGrupo, subgrupo.CodSubgrupo);
            }
            catch (Exception e)
            {
                throw new DadosException("Subgrupo", e.Message, e);
            }
        }

        public void remover(Int32 codSubgrupo)
        {
            if (codSubgrupo == 1)
                throw new NegocioException("Esse subgrupo não pode ser excluído para manter a consistência da base de dados");
                 
            
            try
            {
                tb_subgrupoTA.Delete(codSubgrupo);
            }
            catch (Exception e)
            {
                throw new DadosException("Subgrupo", e.Message, e);
            }
        }
    }
}