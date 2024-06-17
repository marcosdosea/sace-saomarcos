using System;
using System.Collections.Generic;
using Dados;
using Dados.saceDataSetConsultasTableAdapters;
using Dominio;

namespace Negocio
{
    public class GerenciadorProdutosVendidos
    {
        private readonly SaceContext context;

        public GerenciadorProdutosVendidos(SaceContext saceContext)
        {
            context = saceContext;
        }


        public List<ProdutoVendido> ObterProdutosVendidosDezoitoMeses(Int64 codProduto)
        {
            saceDataSetConsultas.ProdutosVendidosDataTable pVendidos = tb_produtos_vendidosTA.GetQuantidadeProdutosVenvidosMesAnoDesc(codProduto);

            List<ProdutoVendido> listaProdutosVendidos = new List<ProdutoVendido>();

            for (int i = 0; i < pVendidos.Rows.Count; i++)
            {
                ProdutoVendido produtoVendido = new ProdutoVendido();
                produtoVendido.MesAno = ((saceDataSetConsultas.ProdutosVendidosRow)pVendidos.Rows[i]).mesano;
                produtoVendido.CodProduto = ((saceDataSetConsultas.ProdutosVendidosRow)pVendidos.Rows[i]).codProduto;
                produtoVendido.Nome = ((saceDataSetConsultas.ProdutosVendidosRow)pVendidos.Rows[i]).nome;
                produtoVendido.QuantidadeVendida = ((saceDataSetConsultas.ProdutosVendidosRow)pVendidos.Rows[i]).quantidadeVendida;
                produtoVendido.Ano = (int)((saceDataSetConsultas.ProdutosVendidosRow)pVendidos.Rows[i]).ano;
                produtoVendido.Mes = (int)((saceDataSetConsultas.ProdutosVendidosRow)pVendidos.Rows[i]).mes;
                listaProdutosVendidos.Add(produtoVendido);
            }

            // Insere zero nos meses sem vendas do produto
            DateTime dataAtual = DateTime.Now;
            for (int i = 0; i < 18 && i < listaProdutosVendidos.Count; i++)
            {
                ProdutoVendido produtoVendido = listaProdutosVendidos[i];
                if (produtoVendido.Mes != dataAtual.Month || produtoVendido.Ano != dataAtual.Year)
                {
                    ProdutoVendido _produtoVendido = new ProdutoVendido();
                    _produtoVendido.Ano = dataAtual.Year;
                    _produtoVendido.Mes = dataAtual.Month;
                    _produtoVendido.MesAno = dataAtual.Month + "/" + dataAtual.Year;
                    _produtoVendido.Nome = produtoVendido.Nome;
                    _produtoVendido.QuantidadeVendida = 0;
                    listaProdutosVendidos.Insert(i, _produtoVendido);
                }
                dataAtual = dataAtual.AddMonths(-1);
            }
            return listaProdutosVendidos;
        }

    }
}