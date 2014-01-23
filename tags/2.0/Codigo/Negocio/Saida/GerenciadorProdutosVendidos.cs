using System;
using System.Collections.Generic;
using Dados;
using Dados.saceDataSetConsultasTableAdapters;
using Dominio;

namespace Negocio
{
    public class GerenciadorProdutosVendidos
    {
        private static GerenciadorProdutosVendidos gProdutosVendidos;
        private static ProdutosVendidosTableAdapter tb_produtos_vendidosTA;
        
        public static GerenciadorProdutosVendidos getInstace()
        {
            if (gProdutosVendidos == null)
            {
                gProdutosVendidos = new GerenciadorProdutosVendidos();
                tb_produtos_vendidosTA = new ProdutosVendidosTableAdapter();
            }
            return gProdutosVendidos;
        }

        
        public List<ProdutoVendido> obterProdutosVendidos(Int64 codProduto)
        {
            saceDataSetConsultas.ProdutosVendidosDataTable pVendidos = tb_produtos_vendidosTA.GetQuantidadeProdutosVenvidosMesAnoDesc(codProduto);
            
            List<ProdutoVendido> listaProdutosVendidos = new List<ProdutoVendido>();

             for (int i = 0; i < pVendidos.Rows.Count; i++)
             {
                ProdutoVendido produtoVendido = new ProdutoVendido();
                produtoVendido.MesAno = ((saceDataSetConsultas.ProdutosVendidosRow) pVendidos.Rows[i]).mesano;
                produtoVendido.CodProduto = ((saceDataSetConsultas.ProdutosVendidosRow)pVendidos.Rows[i]).codProduto;
                produtoVendido.Nome = ((saceDataSetConsultas.ProdutosVendidosRow)pVendidos.Rows[i]).nome;
                produtoVendido.QuantidadeVendida = ((saceDataSetConsultas.ProdutosVendidosRow)pVendidos.Rows[i]).quantidadeVendida;

                listaProdutosVendidos.Add(produtoVendido);
            }

            return listaProdutosVendidos;
        }

    }
}