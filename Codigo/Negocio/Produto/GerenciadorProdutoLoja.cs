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
    public class GerenciadorProdutoLoja 
    {
        private static GerenciadorProdutoLoja gProdutoLoja;
        private static tb_produto_lojaTableAdapter tb_produto_lojaTA;
        
        public static GerenciadorProdutoLoja getInstace()
        {
            if (gProdutoLoja == null)
            {
                gProdutoLoja = new GerenciadorProdutoLoja();
                tb_produto_lojaTA = new tb_produto_lojaTableAdapter();
            }
            return gProdutoLoja;
        }

        public Int64 inserir(ProdutoLoja produtoLoja)
        {
            try
            {
                tb_produto_lojaTA.Insert(produtoLoja.CodLoja, produtoLoja.CodProduto,
                    produtoLoja.QtdEstoque, produtoLoja.QtdEstoqueAux, produtoLoja.Localizacao, produtoLoja.Localizacao2, produtoLoja.EstoqueMaximo);
                ajustarEstoqueEntradasProduto(produtoLoja.CodProduto);
                return 0;
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
                    produtoLoja.Localizacao, produtoLoja.Localizacao2, produtoLoja.EstoqueMaximo, produtoLoja.CodLoja, produtoLoja.CodProduto);
                ajustarEstoqueEntradasProduto(produtoLoja.CodProduto);
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
                ajustarEstoqueEntradasProduto(produtoLojaPK.CodProduto);
            }
            catch (Exception e)
            {
                throw new DadosException("Produto", e.Message, e);
            }
        }

        public ProdutoLoja obterProdutoLoja(ProdutoLojaPK produtoLojaPK)
        {
            ProdutoLoja produtoLoja = null;
            Dados.saceDataSetTableAdapters.tb_produto_lojaTableAdapter tb_pLojaTA = new tb_produto_lojaTableAdapter();
            Dados.saceDataSet.tb_produto_lojaDataTable produtoLojaDT = tb_pLojaTA.GetDataByCodProdutoCodLoja(produtoLojaPK.CodLoja, produtoLojaPK.CodProduto);

            if (produtoLojaDT.Count > 0)
            {
                produtoLoja = new ProdutoLoja();
                produtoLoja.CodProduto = int.Parse(produtoLojaDT.Rows[0]["codProduto"].ToString());
                produtoLoja.CodLoja = int.Parse(produtoLojaDT.Rows[0]["codLoja"].ToString());
                produtoLoja.Localizacao = produtoLojaDT.Rows[0]["localizacao"].ToString();
                produtoLoja.QtdEstoque = decimal.Parse(produtoLojaDT.Rows[0]["qtdEstoque"].ToString());
                produtoLoja.QtdEstoqueAux = decimal.Parse(produtoLojaDT.Rows[0]["qtdEstoqueAux"].ToString());
            }
            return produtoLoja;
        }

        public void adicionaQuantidade(decimal quantidade, decimal quantidadeAux, Int32 codLoja, Int32 codProduto)
        {
            ProdutoLojaPK chave = new ProdutoLojaPK();
            chave.CodLoja = codLoja;
            chave.CodProduto = codProduto;

            ProdutoLoja produtoLoja = obterProdutoLoja(chave);
            if (produtoLoja != null)
            {
                tb_produto_lojaTA.AdicionaQuantidade(quantidade, quantidadeAux, codLoja, codProduto);
            }
            else
            {
                tb_produto_lojaTA.Insert(codLoja, codProduto, quantidade, quantidadeAux, "", "", 0);
            }
        }

        private decimal obterEstoquePrincipal(long codProduto)
        {
            Dados.saceDataSetTableAdapters.tb_produto_lojaTableAdapter tb_pLojaTA = new tb_produto_lojaTableAdapter();
            decimal? estoque = tb_pLojaTA.ObterEstoqueProdutoPrincipal(codProduto);
            return (estoque == null) ? 0 : (decimal)estoque;
        }

        private decimal obterEstoqueAux(long codProduto)
        {
            Dados.saceDataSetTableAdapters.tb_produto_lojaTableAdapter tb_pLojaTA = new tb_produto_lojaTableAdapter();
            decimal? estoque = tb_pLojaTA.ObterEstoqueProdutoAux(codProduto);
            return (estoque == null) ? 0 : (decimal)estoque;
        }

        private void ajustarEstoqueEntradasProduto(long codProduto)
        {
            decimal quantidadeEstoquePrincipalLojas = obterEstoquePrincipal(codProduto);
            decimal quantidadeEstoqueAuxLojas = obterEstoqueAux(codProduto);
            
            decimal quantidadeEstoquePrincipalEntradaProduto = GerenciadorEntradaProduto.getInstace().ObterEstoquePrincipalDisponivel(codProduto);
            decimal quantidadeEstoqueAuxEntradaProduto = GerenciadorEntradaProduto.getInstace().ObterEstoqueAuxDisponivel(codProduto);
            
            // Atualiza as entradas principais com os valores do estoque totais dos produto / loja
            if (quantidadeEstoquePrincipalLojas != quantidadeEstoquePrincipalEntradaProduto)
            {
                List<EntradaProduto> entradasProduto = GerenciadorEntradaProduto.getInstace().ObterEntradasPrincipais(codProduto);

                for (int i = 0; (entradasProduto != null) && (i < entradasProduto.Count); i++)
                {
                    // Vai decremetar o contador até organizar a quantidade disponível dos lotes de entrada
                    if (quantidadeEstoquePrincipalLojas > 0)
                    {
                        if (entradasProduto[i].Quantidade < quantidadeEstoquePrincipalLojas)
                        {
                            entradasProduto[i].QuantidadeDisponivel = entradasProduto[i].Quantidade;
                            quantidadeEstoquePrincipalLojas -= entradasProduto[i].Quantidade;
                        }
                        else
                        {
                            entradasProduto[i].QuantidadeDisponivel = quantidadeEstoquePrincipalLojas;
                            quantidadeEstoquePrincipalLojas = 0;
                        }
                    }
                    else
                    {
                        entradasProduto[i].QuantidadeDisponivel = 0;
                    }
                    GerenciadorEntradaProduto.getInstace().atualizar(entradasProduto[i]);
                }

            }


            // Atualiza as entradas auxiliares com os valores do estoque totais dos produto / loja
            if (quantidadeEstoqueAuxLojas != quantidadeEstoqueAuxEntradaProduto)
            {
                List<EntradaProduto> entradasProduto = GerenciadorEntradaProduto.getInstace().ObterEntradasAuxiliar(codProduto);

                for (int i = 0; (entradasProduto != null) && (i < entradasProduto.Count); i++)
                {
                    // Vai decremetar o contador até organizar a quantidade disponível dos lotes de entrada
                    if (quantidadeEstoqueAuxLojas > 0)
                    {
                        if (entradasProduto[i].Quantidade < quantidadeEstoqueAuxLojas)
                        {
                            entradasProduto[i].QuantidadeDisponivel = entradasProduto[i].Quantidade;
                            quantidadeEstoqueAuxLojas -= entradasProduto[i].Quantidade;
                        }
                        else
                        {
                            entradasProduto[i].QuantidadeDisponivel = quantidadeEstoqueAuxLojas;
                            quantidadeEstoqueAuxLojas = 0;
                        }
                    }
                    else
                    {
                        entradasProduto[i].QuantidadeDisponivel = 0;
                    }
                    GerenciadorEntradaProduto.getInstace().atualizar(entradasProduto[i]);
                }

            }
        }
    }
}