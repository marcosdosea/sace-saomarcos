using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SACE.Dados.saceDataSetTableAdapters;
using System.Data;
using SACE.Excecoes;

namespace Telas
{
    class Autenticacao
    {
        int codUsuario;
        string login;

        public int CodUsuario
        {
            get { return codUsuario; }
            set { codUsuario = value; }
        }

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public bool verificaPermissao(int funcao)
        {
            tb_perfil_funcionalidadeTableAdapter ta = new tb_perfil_funcionalidadeTableAdapter();
            DataTable dt = ta.ObterPerfilPorFuncionalidade(funcao, codUsuario);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                throw new SystemException("Funcionalidade não autorizada!");
            }
        }
    }
}
