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
    public class GerenciadorSaidaProduto : IGerenciadorSaidaProduto
    {
        private static IGerenciadorSaidaProduto gSaidaProduto;
        private static tb_saida_produtoTableAdapter tb_SaidaProdutoTA;
        
        public static IGerenciadorSaidaProduto getInstace()
        {
            if (gSaidaProduto == null)
            {
                gSaidaProduto = new GerenciadorSaidaProduto();
                tb_SaidaProdutoTA = new tb_saida_produtoTableAdapter();
            }
            return gSaidaProduto;
        }

        public void inserir(SaidaProduto saidaProduto)
        {
            try
            {
                tb_SaidaProdutoTA.Insert(saidaProduto.CodProduto, saidaProduto.CodSaida, 
                    saidaProduto.Quantidade.ToString(), saidaProduto.ValorVenda.ToString(), 
                    saidaProduto.Desconto.ToString(), saidaProduto.Subtotal.ToString());
            }
            catch (Exception e)
            {
                throw new DadosException("Saída de Produtos", e.Message, e);
            }
        }

        public void atualizar(SaidaProduto saidaProduto)
        {
            try
            {
                tb_SaidaProdutoTA.Update(saidaProduto.CodProduto, saidaProduto.CodSaida,
                    saidaProduto.Quantidade, saidaProduto.ValorVenda, saidaProduto.Desconto,
                    saidaProduto.Subtotal, saidaProduto.CodSaidaProduto);
            }
            catch (Exception e)
            {
                throw new DadosException("Saída de Produtos", e.Message, e);
            }
        }

        public void remover(Int64 codSaidaProduto)
        {
            try
            {
                tb_SaidaProdutoTA.Delete(codSaidaProduto);
            }
            catch (Exception e)
            {
                throw new DadosException("Saída de Produtos", e.Message, e);
            }
        }
    }
}
