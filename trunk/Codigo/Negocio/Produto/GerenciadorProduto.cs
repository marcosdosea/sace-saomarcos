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
                    produto.Frete.ToString(), produto.CustoVenda.ToString(), produto.UltimoPrecoCompra.ToString(),
                    produto.UltimaDataAtualizacao, produto.UltimoPrecoCusto.ToString(), produto.UltimoPrecoMedio.ToString(),
                    produto.LucroPrecoVendaVarejo.ToString(), produto.PrecoVendaVarejo.ToString(), produto.QtdProdutoAtacado.ToString(),
                    produto.LucroPrecoVendaAtacado.ToString(), produto.PrecoVendaAtacado.ToString(), produto.QtdProdutoSuperAtacado.ToString(),
                    produto.LucroPrecoVendaSuperAtacado.ToString(), produto.PrecoVendaSuperAtacado.ToString(),
                    exibeNaListagemByte);
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
                tb_produtoTA.Update(produto.Nome, produto.NomeFabricante, produto.Unidade, produto.CodigoBarra,
                    produto.CodGrupo, produto.CodFabricante, produto.TemVencimento, produto.Cfop, produto.Icms,
                    produto.IcmsSubstituto, produto.Simples, produto.Ipi, produto.Frete, produto.CustoVenda, produto.UltimoPrecoCompra,
                    produto.UltimaDataAtualizacao, produto.UltimoPrecoCusto, produto.UltimoPrecoMedio,
                    produto.LucroPrecoVendaVarejo, produto.PrecoVendaVarejo, produto.QtdProdutoAtacado,
                    produto.LucroPrecoVendaAtacado, produto.PrecoVendaAtacado, produto.QtdProdutoSuperAtacado,
                    produto.LucroPrecoVendaSuperAtacado, produto.PrecoVendaSuperAtacado,
                    produto.ExibeNaListagem, produto.CodProduto);
            }
            catch (Exception e)
            {
                throw new DadosException("Produto", e.Message, e);
            }
        }

        public void atualizarPrecos(Produto produto)
        {
            try
            {
                tb_produtoTA.UpdatePrecos(produto.Icms, produto.IcmsSubstituto, produto.Simples,
                    produto.Ipi, produto.Frete, produto.CustoVenda, produto.UltimaDataAtualizacao,
                    produto.LucroPrecoVendaVarejo, produto.PrecoVendaVarejo,
                    produto.LucroPrecoVendaAtacado, produto.PrecoVendaAtacado, produto.LucroPrecoVendaSuperAtacado,
                    produto.PrecoVendaSuperAtacado, produto.CodProduto);
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

        public decimal calculaPrecoCustoNormal(decimal precoCompra, decimal diferencialICMS, decimal simples, decimal ipi, decimal frete, decimal manutencao)
        {
            return gPreco.calculaPrecoCustoNormal(precoCompra, diferencialICMS, simples, ipi, frete, manutencao);
        }

        public decimal calculaPrecoCustoSubstituicao(decimal precoCompra, decimal ICMSSubstituicao, decimal simples, decimal ipi, decimal frete, decimal manutencao)
        {
            return gPreco.calculaPrecoCustoSubstituicao(precoCompra, ICMSSubstituicao, simples, ipi, frete, manutencao);
        }

        public decimal calculaPrecoVenda(decimal precoCusto, decimal lucro)
        {
            return gPreco.calculaPrecoVenda(precoCusto, lucro);
        }
    }
}
