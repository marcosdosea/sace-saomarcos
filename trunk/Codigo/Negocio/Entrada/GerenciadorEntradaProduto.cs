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
    public class GerenciadorEntradaProduto : IGerenciadorEntradaProduto
    {
        private static IGerenciadorEntradaProduto gEntradaProduto;
        private static tb_entrada_produtoTableAdapter tb_entrada_produtoTA;
        
        
        public static IGerenciadorEntradaProduto getInstace()
        {
            if (gEntradaProduto == null)
            {
                gEntradaProduto = new GerenciadorEntradaProduto();
                tb_entrada_produtoTA = new tb_entrada_produtoTableAdapter();
            }
            return gEntradaProduto;
        }

        public void inserir(EntradaProduto entradaProduto)
        {
            try
            {
                tb_entrada_produtoTA.Insert(entradaProduto.CodEntrada, entradaProduto.CodProduto,
                    entradaProduto.Quantidade.ToString(), entradaProduto.ValorCompra.ToString(), 
                    entradaProduto.Ipi.ToString(), entradaProduto.Icms.ToString(),
                    entradaProduto.IcmsSubstituto.ToString(), entradaProduto.PrecoCusto.ToString());
            }
            catch (Exception e)
            {
                throw new DadosException("EntradaProduto", e.Message, e);
            }
        }

        public void atualizar(EntradaProduto entradaProduto)
        {
            try
            {
                tb_entrada_produtoTA.Update(entradaProduto.CodEntrada, entradaProduto.CodProduto, 
                    entradaProduto.Quantidade, entradaProduto.ValorCompra, entradaProduto.Ipi,
                    entradaProduto.Icms, entradaProduto.IcmsSubstituto, entradaProduto.PrecoCusto, 
                    entradaProduto.CodEntradaProduto);
            }
            catch (Exception e)
            {
                throw new DadosException("EntradaProduto", e.Message, e);
            }
        }

        public void remover(Int64 codEntradaProduto)
        {
            try
            {
                tb_entrada_produtoTA.Delete(codEntradaProduto);
            }
            catch (Exception e)
            {
                throw new DadosException("EntradaProduto", e.Message, e);
            }
        }
    }
}
