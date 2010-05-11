using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SACE.Dominio;
using SACE.Dados.saceDataSetTableAdapters;
using SACE.Dados;

namespace SACE.Negocio
{
    public class GerenciadorBanco : IGerenciadorBanco
    {
        private static IGerenciadorBanco gBanco;
        private static tb_bancoTableAdapter tb_bancoTA;

        public static IGerenciadorBanco getInstace()
        {
            if (gBanco == null)
            {
                gBanco = new GerenciadorBanco();
                tb_bancoTA = new tb_bancoTableAdapter();
            }
            return gBanco;
        }

        public void inserir(Banco banco)
        {
            tb_bancoTA.Insert(banco.Nome);
        }

        public void atualizar(Banco banco)
        {
            tb_bancoTA.Update(banco.Nome, banco.CodBanco);
        }

        public void remover(Int32 codBanco)
        {
            tb_bancoTA.Delete(codBanco);
        }
    }
}
