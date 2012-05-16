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

        public Int64 inserir(Produto produto)
        {
            try
            {
                byte temVencimentoByte  = (byte) (produto.TemVencimento?1:0);
                byte exibeNaListagemByte = (byte)(produto.ExibeNaListagem ? 1 : 0);
                tb_produtoTA.Insert(produto.Nome, produto.NomeProdutoFabricante, produto.Unidade, 
                    produto.CodigoBarra, produto.CodCST, produto.Cfop, produto.Ncmsh, 
                    produto.CodFabricante, produto.ReferenciaFabricante, 
                    produto.CodSituacaoProduto, produto.CodGrupo, produto.CodSubgrupo, temVencimentoByte,
                    produto.Icms.ToString(), produto.IcmsSubstituto.ToString(), produto.Simples.ToString(),
                    produto.Ipi.ToString(), produto.Frete.ToString(), produto.UltimaDataAtualizacao,
                    produto.UltimoPrecoCompra.ToString(), produto.LucroPrecoVendaVarejo.ToString(),
                    produto.PrecoVendaVarejo.ToString(), produto.QtdProdutoAtacado.ToString(),
                    produto.LucroPrecoVendaAtacado.ToString(), produto.PrecoVendaAtacado.ToString(), 
                    exibeNaListagemByte, produto.DataUltimoPedido);
               
                return 0;
            }
            catch (Exception e)
            {
                throw new DadosException("Produto", e.Message, e);
            }
        }

        public void atualizar(Produto produto)
        {
            if (produto.CodProduto == 1)
                throw new NegocioException("Esse produto não pode ser alterado ou removido.");
            try
            {
                Produto produtoAtual = obterProduto(produto.CodProduto);
                if ((produto.PrecoVendaVarejo != produtoAtual.PrecoVendaVarejo) || (produto.PrecoVendaAtacado != produtoAtual.PrecoVendaAtacado))
                {
                    produto.UltimaDataAtualizacao = DateTime.Now;
                }


                tb_produtoTA.Update(produto.Nome, produto.NomeProdutoFabricante, produto.Unidade,
                    produto.CodigoBarra, produto.CodCST, produto.Cfop, produto.Ncmsh,
                    produto.CodFabricante, produto.ReferenciaFabricante,
                    produto.CodSituacaoProduto, produto.CodGrupo, produto.CodSubgrupo, produto.TemVencimento,
                    produto.Icms, produto.IcmsSubstituto, produto.Simples,
                    produto.Ipi, produto.Frete, produto.UltimaDataAtualizacao,
                    produto.UltimoPrecoCompra, produto.LucroPrecoVendaVarejo,
                    produto.PrecoVendaVarejo, produto.QtdProdutoAtacado,
                    produto.LucroPrecoVendaAtacado, produto.PrecoVendaAtacado,
                    produto.ExibeNaListagem, produto.DataUltimoPedido, produto.CodProduto);
            }
            catch (Exception e)
            {
                throw new DadosException("Produto", e.Message, e);
            }
        }

        public void remover(Int32 codproduto)
        {
            if (codproduto == 1)
                throw new NegocioException("Esse produto não pode ser alterado ou removido.");
            
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

        public Produto obterProdutoPorCodBarra(String codBarra)
        {
            Dados.saceDataSetTableAdapters.tb_produtoTableAdapter tb_produTA = new tb_produtoTableAdapter();
            Dados.saceDataSet.tb_produtoDataTable produtoDT = tb_produTA.GetDataByCodBarra(Global.ACRESCIMO_PADRAO, codBarra);
            return converterProduto(produtoDT);
        }
        
        public Produto obterProduto(Int32 codProduto)
        {
            Dados.saceDataSetTableAdapters.tb_produtoTableAdapter tb_produTA = new tb_produtoTableAdapter();
            Dados.saceDataSet.tb_produtoDataTable produtoDT = tb_produTA.GetDataByCodProduto(Global.ACRESCIMO_PADRAO, codProduto);
            return converterProduto(produtoDT);
        }

        public Produto obterProdutoNomeIgual(String nomeProduto)
        {
            Dados.saceDataSetTableAdapters.tb_produtoTableAdapter tb_produTA = new tb_produtoTableAdapter();
            Dados.saceDataSet.tb_produtoDataTable produtoDT = tb_produTA.GetDataByExactNome(Global.ACRESCIMO_PADRAO, nomeProduto);
            return converterProduto(produtoDT);
        }

        private Produto converterProduto(Dados.saceDataSet.tb_produtoDataTable produtoDT) {
            
            Produto produto = null;
            if (produtoDT.Count > 0)
            {
                produto = new Produto();
                produto.CodProduto = int.Parse(produtoDT.Rows[0]["codProduto"].ToString());
                produto.Cfop = int.Parse(produtoDT.Rows[0]["cfop"].ToString());
                produto.CodFabricante = int.Parse(produtoDT.Rows[0]["codFabricante"].ToString());
                produto.CodGrupo  = int.Parse(produtoDT.Rows[0]["codGrupo"].ToString());
                produto.CodSubgrupo = int.Parse(produtoDT.Rows[0]["codSubgrupo"].ToString());
                produto.CodigoBarra = produtoDT.Rows[0]["codigoBarra"].ToString();
                produto.ExibeNaListagem = bool.Parse(produtoDT.Rows[0]["exibeNaListagem"].ToString());
                produto.Frete = decimal.Parse(produtoDT.Rows[0]["frete"].ToString());
                produto.Icms = decimal.Parse(produtoDT.Rows[0]["icms"].ToString());
                produto.IcmsSubstituto = decimal.Parse(produtoDT.Rows[0]["icms_substituto"].ToString());
                produto.Ipi = decimal.Parse(produtoDT.Rows[0]["ipi"].ToString());
                produto.LucroPrecoVendaAtacado = decimal.Parse(produtoDT.Rows[0]["lucroPrecoVendaAtacado"].ToString());
                produto.LucroPrecoVendaVarejo = decimal.Parse(produtoDT.Rows[0]["lucroPrecoVendaVarejo"].ToString());
                produto.Nome = produtoDT.Rows[0]["nome"].ToString();
                produto.NomeProdutoFabricante = produtoDT.Rows[0]["nomeProdutoFabricante"].ToString();
                produto.PrecoVendaAtacado = decimal.Parse(produtoDT.Rows[0]["precoVendaAtacado"].ToString());
                produto.PrecoVendaVarejo = decimal.Parse(produtoDT.Rows[0]["precoVendaVarejo"].ToString());
                produto.QtdProdutoAtacado = decimal.Parse(produtoDT.Rows[0]["qtdProdutoAtacado"].ToString());
                produto.Simples = decimal.Parse(produtoDT.Rows[0]["simples"].ToString());
                produto.TemVencimento = bool.Parse(produtoDT.Rows[0]["temVencimento"].ToString());
                produto.UltimaDataAtualizacao = DateTime.Parse(produtoDT.Rows[0]["ultimaDataAtualizacao"].ToString());
                produto.UltimoPrecoCompra = decimal.Parse(produtoDT.Rows[0]["ultimoPrecoCompra"].ToString());
                produto.Unidade = produtoDT.Rows[0]["unidade"].ToString();
                produto.DataUltimoPedido = DateTime.Parse(produtoDT.Rows[0]["dataUltimoPedido"].ToString());
                produto.CodSituacaoProduto = Byte.Parse(produtoDT.Rows[0]["codSituacaoProduto"].ToString());
                produto.ReferenciaFabricante = produtoDT.Rows[0]["referenciaFabricante"].ToString();
                produto.CodCST = produtoDT.Rows[0]["codCST"].ToString();
                produto.Ncmsh = produtoDT.Rows[0]["ncmsh"].ToString();
            }
            return produto;
        }

        public bool ehProdututoTributadoIntegral(String codCST)
        {
            if (codCST != null)
            {
                return !(codCST.Equals(Produto.ST_SUBSTITUICAO) ||
                    codCST.Equals(Produto.ST_SUBSTITUICAO_ICMS_COBRADO) ||
                    codCST.Equals(Produto.ST_SUBSTITUICAO_ICMS_REDUCAO_BC) ||
                    codCST.Equals(Produto.ST_SUBSTITUICAO_ISENTA_NAO_TRIBUTADA));
            }
            return false;
        }
    }
}