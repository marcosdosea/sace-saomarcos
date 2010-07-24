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
    public class GerenciadorGrupo : IGerenciadorGrupo
    {
        private static IGerenciadorGrupo gGrupo;
        private static tb_grupoTableAdapter tb_grupoTA;
        
        
        public static IGerenciadorGrupo getInstace()
        {
            if (gGrupo == null)
            {
                gGrupo = new GerenciadorGrupo();
                tb_grupoTA = new tb_grupoTableAdapter();
            }
            return gGrupo;
        }

        public void inserir(Grupo grupo)
        {
            try
            {
                tb_grupoTA.Insert(grupo.Descricao);
            }
            catch (Exception e)
            {
                throw new DadosException("Grupo", e.Message, e);
            }
        }

        public void atualizar(Grupo grupo)
        {
            try
            {
                tb_grupoTA.Update(grupo.Descricao, grupo.CodGrupo);
            }
            catch (Exception e)
            {
                throw new DadosException("Grupo", e.Message, e);
            }
        }

        public void remover(Int32 codGrupo)
        {
            try
            {
                tb_grupoTA.Delete(codGrupo);
            }
            catch (Exception e)
            {
                throw new DadosException("Grupo", e.Message, e);
            }
        }
    }
}
