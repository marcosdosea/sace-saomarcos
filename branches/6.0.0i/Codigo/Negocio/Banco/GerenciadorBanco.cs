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
            try
            {
                tb_bancoTA.Insert(banco.Nome);
            }
            catch (Exception e)
            {
                throw new DadosException("Banco", e.Message, e);
            }
        }

        public void atualizar(Banco banco)
        {
            try
            {
                tb_bancoTA.Update(banco.Nome, banco.CodBanco);
            }
            catch (Exception e)
            {
                throw new DadosException("Banco", e.Message, e);
            }
        }

        public void remover(Int32 codBanco)
        {
            try
            {
                tb_bancoTA.Delete(codBanco);
            }
            catch (Exception e)
            {
                throw new DadosException("Banco", e.Message, e);
            }
        }
    }
}
