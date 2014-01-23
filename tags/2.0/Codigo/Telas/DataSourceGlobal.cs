using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace Telas
{
    public static class DataSourceGlobal
    {

        static BindingSource produtoBindingSouce = null;
        //static BindingSource pessoaBindingSouce = null;

        public static BindingSource GetProdutoBindingSource() {
            if (produtoBindingSouce == null)
            {
                produtoBindingSouce = new BindingSource();
                produtoBindingSouce.DataSource = GerenciadorProduto.GetInstance().ObterTodosExibiveis();
            }
            return produtoBindingSouce;
        }

        public static BindingSource UpdateProdutoBindingSource()
        {
            if (produtoBindingSouce == null)
            {
                produtoBindingSouce = new BindingSource();
                produtoBindingSouce.DataSource = GerenciadorProduto.GetInstance().ObterTodosExibiveis();
            }
            else
            {
                produtoBindingSouce.DataSource = GerenciadorProduto.GetInstance().ObterTodosExibiveis();
            }
            return produtoBindingSouce;
        }

    }
}
