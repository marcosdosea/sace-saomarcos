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
        private static tb_produto_lojaTableAdapter tb_produto_lojaTA;
        private static tb_produtoTableAdapter tb_produtoTA;
        
        
        public static IGerenciadorEntradaProduto getInstace()
        {
            if (gEntradaProduto == null)
            {
                gEntradaProduto = new GerenciadorEntradaProduto();
                tb_entrada_produtoTA = new tb_entrada_produtoTableAdapter();
                tb_produto_lojaTA = new tb_produto_lojaTableAdapter();
                tb_produtoTA = new tb_produtoTableAdapter();
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
                    entradaProduto.IcmsSubstituto.ToString(), entradaProduto.PrecoCusto.ToString(),
                    entradaProduto.DataValidade, entradaProduto.QuantidadeVendidos.ToString());

                // Incrementa o estoque na loja principal
                tb_produto_lojaTA.atualizarEstoqueProdutoLoja(entradaProduto.Quantidade, 0, entradaProduto.PrecoCusto, 
                    Global.LOJA_PADRAO, entradaProduto.CodProduto);

                Produto produto = GerenciadorProduto.getInstace().obterProduto(entradaProduto.CodProduto);
                produto.Frete = entradaProduto.Frete;
                produto.Icms = entradaProduto.Icms;
                produto.IcmsSubstituto = entradaProduto.IcmsSubstituto;
                produto.Ipi = entradaProduto.Ipi;
                produto.Simples = entradaProduto.Simples;
                produto.LucroPrecoVendaAtacado = entradaProduto.LucroPrecoVendaAtacado;
                produto.LucroPrecoVendaVarejo = entradaProduto.LucroPrecoVendaVarejo;
                produto.PrecoVendaAtacado = entradaProduto.PrecoVendaAtacado;
                produto.PrecoVendaVarejo = entradaProduto.PrecoVendaVarejo;
                produto.UltimoPrecoCompra = entradaProduto.ValorCompra;

                GerenciadorProduto.getInstace().atualizar(produto);
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
                    entradaProduto.DataValidade, entradaProduto.QuantidadeVendidos, 
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
                EntradaProduto entradaProduto = obter(codEntradaProduto);
                tb_entrada_produtoTA.Delete(codEntradaProduto);
                
                // Decrementa o estoque na loja principal
                tb_produto_lojaTA.atualizarEstoqueProdutoLoja((entradaProduto.Quantidade*(-1)), 0, entradaProduto.PrecoCusto,
                    Global.LOJA_PADRAO, entradaProduto.CodProduto);
            }
            catch (Exception e)
            {
                throw new DadosException("EntradaProduto", e.Message, e);
            }
        }

        public EntradaProduto obter(Int64 codEntradaProduto)
        {
            EntradaProduto entradaProduto = new EntradaProduto();

            tb_entrada_produtoTableAdapter tb_entradaProdutoTA = new tb_entrada_produtoTableAdapter();
            Dados.saceDataSet.tb_entrada_produtoDataTable entradaProdutoDT = tb_entradaProdutoTA.GetDataByCodEntradaProduto(codEntradaProduto);
            
            entradaProduto.CodEntrada = int.Parse(entradaProdutoDT.Rows[0]["codEntrada"].ToString());
            entradaProduto.CodEntradaProduto = long.Parse(entradaProdutoDT.Rows[0]["codEntradaProduto"].ToString());
            entradaProduto.CodProduto = int.Parse(entradaProdutoDT.Rows[0]["codProduto"].ToString());
            entradaProduto.DataValidade = DateTime.Parse(entradaProdutoDT.Rows[0]["data_validade"].ToString());
            entradaProduto.Icms = decimal.Parse(entradaProdutoDT.Rows[0]["icms"].ToString());
            entradaProduto.IcmsSubstituto = decimal.Parse(entradaProdutoDT.Rows[0]["icms_substituto"].ToString());
            entradaProduto.Ipi = decimal.Parse(entradaProdutoDT.Rows[0]["ipi"].ToString());
            entradaProduto.PrecoCusto = decimal.Parse(entradaProdutoDT.Rows[0]["preco_custo"].ToString());
            entradaProduto.Quantidade = decimal.Parse(entradaProdutoDT.Rows[0]["quantidade"].ToString());
            entradaProduto.QuantidadeVendidos = decimal.Parse(entradaProdutoDT.Rows[0]["quantidade_vendidos"].ToString());
            entradaProduto.ValorCompra = decimal.Parse(entradaProdutoDT.Rows[0]["valor_compra"].ToString());
                      
            return entradaProduto;
        }
    }
}
