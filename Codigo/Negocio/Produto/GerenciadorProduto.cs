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
    public class GerenciadorProduto : IGerenciadorProduto
    {
        private static IGerenciadorProduto gProduto;
        private static IGerenciadorPrecos gPreco;
        private static tb_produtoTableAdapter tb_produtoTA;
        
        public static IGerenciadorProduto getInstace()
        {
            if (gProduto == null)
            {
                gProduto = new GerenciadorProduto();
                tb_produtoTA = new tb_produtoTableAdapter();
                gPreco = GerenciadorPrecos.getInstance();
            }
            return gProduto;
        }

        public void inserir(Produto produto)
        {
            try
            {
                byte temVencimentoByte  = (byte) (produto.TemVencimento?0:1);
                byte exibeNaListagemByte = (byte)(produto.ExibeNaListagem ? 0 : 1);
                tb_produtoTA.Insert(produto.Nome, produto.NomeFabricante, produto.Unidade, produto.CodigoBarra,
                    produto.CodGrupo, produto.CodFabricante, temVencimentoByte, produto.Cfop, produto.Icms.ToString(),
                    produto.IcmsSubstituto.ToString(), produto.Simples.ToString(), produto.Ipi.ToString(),
                    produto.Frete.ToString(), produto.UltimaDataAtualizacao, produto.UltimoPrecoCompra.ToString(), 
                    produto.LucroPrecoVendaVarejo.ToString(), produto.PrecoVendaVarejo.ToString(), produto.QtdProdutoAtacado.ToString(),
                    produto.LucroPrecoVendaAtacado.ToString(), produto.PrecoVendaAtacado.ToString(), exibeNaListagemByte);
            }
            catch (Exception e)
            {
                throw new DadosException("Produto", e.Message, e);
            }
        }

        public void atualizar(Produto produto)
        {
            try
            {
                Produto produtoAtual = obterProduto(produto.CodProduto);
                if ((produto.PrecoVendaVarejo != produtoAtual.PrecoVendaVarejo) || (produto.PrecoVendaAtacado != produtoAtual.PrecoVendaAtacado))
                {
                    produto.UltimaDataAtualizacao = DateTime.Now;
                }
                
                
                tb_produtoTA.Update(produto.Nome, produto.NomeFabricante, produto.Unidade, produto.CodigoBarra,
                    produto.CodGrupo, produto.CodFabricante, produto.TemVencimento, produto.Cfop, produto.Icms,
                    produto.IcmsSubstituto, produto.Simples, produto.Ipi, produto.Frete, produto.UltimaDataAtualizacao, 
                    produto.UltimoPrecoCompra, produto.LucroPrecoVendaVarejo, produto.PrecoVendaVarejo, produto.QtdProdutoAtacado,
                    produto.LucroPrecoVendaAtacado, produto.PrecoVendaAtacado, produto.ExibeNaListagem, produto.CodProduto);
            }
            catch (Exception e)
            {
                throw new DadosException("Produto", e.Message, e);
            }
        }

        public void remover(Int32 codproduto)
        {
            try
            {
                tb_produtoTA.Delete(codproduto);
            }
            catch (Exception e)
            {
                throw new DadosException("Produto", e.Message, e);
            }
        }

        public decimal calculaPrecoCusto(Produto produto) 
        {
            if (produto.Cfop == Global.VENDA_NORMAL)
                return gPreco.calculaPrecoCustoNormal(produto.UltimoPrecoCompra, produto.Icms, 
                    produto.Simples, produto.Ipi, produto.Frete, 0);
            return gPreco.calculaPrecoCustoSubstituicao(produto.UltimoPrecoCompra, produto.IcmsSubstituto,
                produto.Simples, produto.Ipi, produto.Frete, 0);
        }

        public decimal calculaPrecoVenda(decimal precoCusto, decimal lucro)
        {
            return gPreco.calculaPrecoVenda(precoCusto, lucro);
        }
        
        public Produto obterProduto(Int32 codProduto)
        {
            Produto produto = new Produto();
            Dados.saceDataSetTableAdapters.tb_produtoTableAdapter tb_produTA = new tb_produtoTableAdapter();
            Dados.saceDataSet.tb_produtoDataTable produtoDT = tb_produTA.GetDataByCodProduto(codProduto);

            produto.CodProduto = int.Parse(produtoDT.Rows[0]["codProduto"].ToString());
            produto.Cfop = int.Parse(produtoDT.Rows[0]["cfop"].ToString());
            produto.CodFabricante = int.Parse(produtoDT.Rows[0]["codigoFabricante"].ToString());
            produto.CodGrupo = int.Parse(produtoDT.Rows[0]["codGrupo"].ToString());
            produto.CodigoBarra = produtoDT.Rows[0]["codigoBarra"].ToString();
            produto.ExibeNaListagem = bool.Parse(produtoDT.Rows[0]["exibeNaListagem"].ToString());
            produto.Frete = decimal.Parse(produtoDT.Rows[0]["frete"].ToString());
            produto.Icms = decimal.Parse(produtoDT.Rows[0]["icms"].ToString());
            produto.IcmsSubstituto = decimal.Parse(produtoDT.Rows[0]["icms_substituto"].ToString());
            produto.Ipi = decimal.Parse(produtoDT.Rows[0]["ipi"].ToString());
            produto.LucroPrecoVendaAtacado = decimal.Parse(produtoDT.Rows[0]["lucroPrecoVendaAtacado"].ToString());
            produto.LucroPrecoVendaVarejo = decimal.Parse(produtoDT.Rows[0]["lucroPrecoVendaVarejo"].ToString());
            produto.Nome = produtoDT.Rows[0]["nome"].ToString();
            produto.NomeFabricante = produtoDT.Rows[0]["nomeFabricante"].ToString();
            produto.PrecoVendaAtacado = decimal.Parse(produtoDT.Rows[0]["precoVendaAtacado"].ToString());
            produto.PrecoVendaVarejo = decimal.Parse(produtoDT.Rows[0]["precoVendaVarejo"].ToString());
            produto.QtdProdutoAtacado = decimal.Parse(produtoDT.Rows[0]["qtdProdutoAtacado"].ToString());
            produto.Simples = decimal.Parse(produtoDT.Rows[0]["simples"].ToString());
            produto.TemVencimento = bool.Parse(produtoDT.Rows[0]["temVencimento"].ToString());
            produto.UltimaDataAtualizacao = DateTime.Parse(produtoDT.Rows[0]["ultimaDataAtualizacao"].ToString());
            produto.UltimoPrecoCompra = decimal.Parse(produtoDT.Rows[0]["ultimoPrecoCompra"].ToString());
            produto.Unidade = produtoDT.Rows[0]["unidade"].ToString();
            return produto;
        }
    }
}
