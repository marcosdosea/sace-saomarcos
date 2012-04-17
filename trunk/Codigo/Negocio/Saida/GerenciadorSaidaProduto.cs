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
        private static tb_saidaTableAdapter tb_SaidaTA;
        
        public static IGerenciadorSaidaProduto getInstace()
        {
            if (gSaidaProduto == null)
            {
                gSaidaProduto = new GerenciadorSaidaProduto();
                tb_SaidaProdutoTA = new tb_saida_produtoTableAdapter();
                tb_SaidaTA = new tb_saidaTableAdapter();
            }
            return gSaidaProduto;
        }

        public Int64 inserir(SaidaProduto saidaProduto, Saida saida)
        {
            try
            {
                if (saida.TipoSaida == Saida.TIPO_VENDA)
                {
                    throw new NegocioException("Não é possível inserir produtos de uma Venda cujo Comprovante Fiscal já foi emitido.");
                }

                tb_SaidaProdutoTA.Insert(saidaProduto.CodProduto, saidaProduto.CodSaida, 
                    saidaProduto.Quantidade.ToString(), saidaProduto.ValorVenda.ToString(), 
                    saidaProduto.Desconto.ToString(), saidaProduto.Subtotal.ToString(), 
                    saidaProduto.SubtotalAVista.ToString(), saidaProduto.DataValidade);
                tb_SaidaTA.UpdateTotais(saidaProduto.CodSaida);
                return 0;
                
            }
            catch (Exception e)
            {
                throw new DadosException("Saída de Produtos", e.Message, e);
            }
        }

        
        public void remover(SaidaProduto saidaProduto, Saida saida)
        {
            try
            {
                if (saida.TipoSaida == Saida.TIPO_VENDA)
                {
                    throw new NegocioException("Não é possível remover produtos de uma Venda cujo Comprovante Fiscal já foi emitido.");
                }
                tb_SaidaProdutoTA.Delete(saidaProduto.CodSaidaProduto);
                tb_SaidaTA.UpdateTotais(saidaProduto.CodSaida);
            }
            catch (Exception e)
            {
                throw new DadosException("Saída de Produtos", e.Message, e);
            }
        }

        public List<SaidaProduto> obterSaidaProdutosSemCST(Int64 codSaida, String codCST)
        {
            List<SaidaProduto> saidaProdutos = new List<SaidaProduto>();

            saceDataSet.tb_saida_produtoDataTable tbsaidaProduto = tb_SaidaProdutoTA.GetDataByCodSaidaSemCodCST(codSaida, codCST);

            for (int i = 0; i < tbsaidaProduto.Count; i++)
            {
                SaidaProduto saidaProduto = new SaidaProduto();
                saidaProduto.CodProduto = Convert.ToInt32(tbsaidaProduto.Rows[i]["codProduto"].ToString());
                saidaProduto.CodSaida = Convert.ToInt64(tbsaidaProduto.Rows[i]["codSaida"].ToString());
                saidaProduto.CodSaidaProduto = Convert.ToInt32(tbsaidaProduto.Rows[i]["codSaidaProduto"].ToString());
                saidaProduto.DataValidade = Convert.ToDateTime(tbsaidaProduto.Rows[i]["data_validade"].ToString());
                saidaProduto.Desconto = Convert.ToDecimal(tbsaidaProduto.Rows[i]["desconto"].ToString());
                saidaProduto.Quantidade = Convert.ToDecimal(tbsaidaProduto.Rows[i]["quantidade"].ToString());
                saidaProduto.ValorVenda = Convert.ToDecimal(tbsaidaProduto.Rows[i]["valorVenda"].ToString());
                saidaProduto.Nome = tbsaidaProduto.Rows[i]["nome"].ToString();
                saidaProduto.CodCST = tbsaidaProduto.Rows[i]["codCST"].ToString();
                saidaProduto.Unidade = tbsaidaProduto.Rows[i]["unidade"].ToString();
                saidaProdutos.Add(saidaProduto);
            }
            return saidaProdutos;
        }

        public List<SaidaProduto> obterSaidaProdutos(Int64 codSaida)
        {
            List<SaidaProduto> saidaProdutos = new List<SaidaProduto>();

            saceDataSet.tb_saida_produtoDataTable tbsaidaProduto = tb_SaidaProdutoTA.GetDataByCodSaida(codSaida);

            for (int i = 0; i < tbsaidaProduto.Count; i++)
            {
                SaidaProduto saidaProduto = new SaidaProduto();
                saidaProduto.CodProduto = Convert.ToInt32(tbsaidaProduto.Rows[i]["codProduto"].ToString());
                saidaProduto.CodSaida = Convert.ToInt64(tbsaidaProduto.Rows[i]["codSaida"].ToString());
                saidaProduto.CodSaidaProduto = Convert.ToInt32(tbsaidaProduto.Rows[i]["codSaidaProduto"].ToString());
                saidaProduto.DataValidade = Convert.ToDateTime(tbsaidaProduto.Rows[i]["data_validade"].ToString());
                saidaProduto.Desconto = Convert.ToDecimal(tbsaidaProduto.Rows[i]["desconto"].ToString());
                saidaProduto.Quantidade = Convert.ToDecimal(tbsaidaProduto.Rows[i]["quantidade"].ToString());
                saidaProduto.ValorVenda = Convert.ToDecimal(tbsaidaProduto.Rows[i]["valorVenda"].ToString());
                saidaProduto.Nome = tbsaidaProduto.Rows[i]["nome"].ToString();
                saidaProduto.CodCST = tbsaidaProduto.Rows[i]["codCST"].ToString();
                saidaProduto.Unidade = tbsaidaProduto.Rows[i]["unidade"].ToString();
                saidaProdutos.Add(saidaProduto);
            }
            return saidaProdutos;
        }

    }
}