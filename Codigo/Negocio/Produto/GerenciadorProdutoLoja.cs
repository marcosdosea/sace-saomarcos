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
    public class GerenciadorProdutoLoja : IGerenciadorProdutoLoja
    {
        private static IGerenciadorProdutoLoja gProdutoLoja;
        private static tb_produto_lojaTableAdapter tb_produto_lojaTA;
        
        public static IGerenciadorProdutoLoja getInstace()
        {
            if (gProdutoLoja == null)
            {
                gProdutoLoja = new GerenciadorProdutoLoja();
                tb_produto_lojaTA = new tb_produto_lojaTableAdapter();
            }
            return gProdutoLoja;
        }

        public void inserir(ProdutoLoja produtoLoja)
        {
            try
            {
                tb_produto_lojaTA.Insert(produtoLoja.CodLoja, produtoLoja.CodProduto,
                    produtoLoja.QtdEstoque, produtoLoja.QtdEstoqueAux, 
                    produtoLoja.PrecoCusto, produtoLoja.Localizacao);
            }
            catch (Exception e)
            {
                throw new DadosException("Produto Loja", e.Message, e);
            }
        }

        public void atualizar(ProdutoLoja produtoLoja)
        {
            try
            {
                tb_produto_lojaTA.Update(produtoLoja.QtdEstoque, produtoLoja.QtdEstoqueAux,
                    produtoLoja.PrecoCusto, produtoLoja.Localizacao, produtoLoja.CodLoja,
                    produtoLoja.CodProduto);
            }
            catch (Exception e)
            {
                throw new DadosException("Produto", e.Message, e);
            }
        }

        public void remover(ProdutoLojaPK produtoLojaPK)
        {
            try
            {
                tb_produto_lojaTA.Delete(produtoLojaPK.CodLoja, produtoLojaPK.CodProduto);
            }
            catch (Exception e)
            {
                throw new DadosException("Produto", e.Message, e);
            }
        }

        public ProdutoLoja obterProdutoLoja(ProdutoLojaPK produtoLojaPK)
        {
            ProdutoLoja produtoLoja = new ProdutoLoja();
            Dados.saceDataSetTableAdapters.tb_produto_lojaTableAdapter tb_pLojaTA = new tb_produto_lojaTableAdapter();
            Dados.saceDataSet.tb_produto_lojaDataTable produtoLojaDT = tb_pLojaTA.GetDataByCodProdutoCodLoja(produtoLojaPK.CodLoja, produtoLojaPK.CodProduto);

            produtoLoja.CodProduto = int.Parse(produtoLojaDT.Rows[0]["codProduto"].ToString());
            produtoLoja.CodLoja = int.Parse(produtoLojaDT.Rows[0]["codLoja"].ToString());
            produtoLoja.Localizacao = produtoLojaDT.Rows[0]["localizacao"].ToString();
            produtoLoja.PrecoCusto = decimal.Parse(produtoLojaDT.Rows[0]["precoCusto"].ToString());
            produtoLoja.QtdEstoque = decimal.Parse(produtoLojaDT.Rows[0]["qtdEstoque"].ToString());
            produtoLoja.QtdEstoqueAux = decimal.Parse(produtoLojaDT.Rows[0]["qtdEstoqueAux"].ToString());
            
            return produtoLoja;
        }
    }
}
