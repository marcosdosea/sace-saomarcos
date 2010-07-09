using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SACE.Dados.saceDataSetTableAdapters;
using System.Data;
using SACE.Excecoes;
using System.Windows.Forms;

namespace Negocio
{
    public class GerenciadorSeguranca
    {
        private static GerenciadorSeguranca seguranca;

        public static GerenciadorSeguranca GetInstancia()
        {
            if(seguranca == null)
            {
                seguranca = new GerenciadorSeguranca();
            }
            return seguranca;
        }

        public bool verificaPermissao(Form sender, int funcao, int codUsuario)
        {
            tb_perfil_funcionalidadeTableAdapter ta = new tb_perfil_funcionalidadeTableAdapter();
            DataTable dt = ta.ObterPerfilPorFuncionalidade(funcao, codUsuario);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                sender.Close();
                throw new TelaException("Funcionalidade não autorizada!");
            }
        }
    }
}
