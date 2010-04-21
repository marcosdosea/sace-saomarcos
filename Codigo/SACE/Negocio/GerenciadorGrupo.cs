using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SACE.Model;
using SACE.Dados.saceDataSetTableAdapters;
using System.Data;

namespace SACE.Negocio
{
    public class GerenciadorGrupo
    {
        private static GerenciadorGrupo gerenciadorGrupo = null;
        private tb_grupoTableAdapter grupoTA;
        
        private GerenciadorGrupo()
        {
            grupoTA = new tb_grupoTableAdapter();
        }

        public static GerenciadorGrupo getInstance()
        {
            if (gerenciadorGrupo == null)
                gerenciadorGrupo = new GerenciadorGrupo();
            return gerenciadorGrupo;

        }

        public void Inserir(Grupo grupo)
        {
            grupoTA.Insert(grupo.Descricao);
        }

        public void Alterar(Grupo grupo) 
        {
            grupoTA.Update(grupo.Descricao, grupo.CodGrupo);
        }

        public void Excluir(long codGrupo)
        {
            grupoTA.Delete(codGrupo);
        }

        public List<Grupo> BuscarTodos()
        {
            return transformarParaLista(grupoTA.GetData());

        }

        private List<Grupo> transformarParaLista(DataTable dtt)
        {
            List<Grupo> lista = new List<Grupo>();
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                Grupo grupo = new Grupo();
                grupo.CodGrupo = int.Parse(dtt.Rows[i]["CODGRUPO"].ToString());
                grupo.Descricao = dtt.Rows[i]["DESCRICAO"].ToString();
                lista.Add(grupo);
            }
            return lista;
        }

        
    }
}
