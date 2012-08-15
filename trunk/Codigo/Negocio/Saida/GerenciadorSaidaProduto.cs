using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dominio;
using Dados.saceDataSetTableAdapters;
using Dados.saceDataSetConsultasTableAdapters;
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
            if (saidaProduto.Quantidade == 0)
                throw new NegocioException("A quantidade do produto não pode ser igual a zero.");

            if (saidaProduto.ValorVendaAVista <= 0)
                throw new NegocioException("O preço de venda do produto deve ser maior que zero.");

            if (saida.TipoSaida == Saida.TIPO_VENDA)
                throw new NegocioException("Não é possível inserir produtos de uma Venda cujo Comprovante Fiscal já foi emitido.");

            if ((saida.TipoSaida == Saida.TIPO_SAIDA_DEPOSITO) && (saida.Nfe != null) && (!saida.Nfe.Equals("")))
                throw new NegocioException("Não é possível inserir produtos numa transferência para depósito cuja nota fiscal já foi emitida.");

            if ((saida.TipoSaida == Saida.TIPO_DEVOLUCAO_FRONECEDOR) && (saida.Nfe != null) && (!saida.Nfe.Equals("")))
                throw new NegocioException("Não é possível inserir produtos numa devolução para fornecedor cuja nota fiscal já foi emitida.");
            
            try
            {
                tb_SaidaProdutoTA.Insert(saidaProduto.CodProduto, saidaProduto.CodSaida, 
                    saidaProduto.Quantidade, saidaProduto.ValorVenda, 
                    saidaProduto.Desconto, saidaProduto.Subtotal, 
                    saidaProduto.SubtotalAVista, saidaProduto.DataValidade, saidaProduto.BaseCalculoICMS,
                    saidaProduto.ValorICMS, saidaProduto.BaseCalculoICMSSubst, saidaProduto.ValorICMSSubst,
                    saidaProduto.ValorIPI);
                atualizaTotaisSaida(saida);
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
                else if ((saida.TipoSaida == Saida.TIPO_SAIDA_DEPOSITO) && (saida.Nfe != null) && (!saida.Nfe.Equals("")))
                {
                    throw new NegocioException("Não é possível remover produtos de uma Saída para Deposito com Nota Fiscal já emitida.");
                }
                else if ((saida.TipoSaida == Saida.TIPO_DEVOLUCAO_FRONECEDOR) && (saida.Nfe != null) && (!saida.Nfe.Equals("")))
                {
                    throw new NegocioException("Não é possível remover produtos de uma Devolução para Fornecedor com Nota Fiscal já emitida.");
                }

                tb_SaidaProdutoTA.Delete(saidaProduto.CodSaidaProduto);
                atualizaTotaisSaida(saida);
            }
            catch (Exception e)
            {
                throw new DadosException("Saída de Produtos", e.Message, e);
            }
        }

        private void atualizaTotaisSaida(Saida saida)
        {
            SumSaidaProdutoTableAdapter sumSaidaTA = new SumSaidaProdutoTableAdapter();
            saceDataSetConsultas.SumSaidaProdutoDataTable sumSaidaProdutoDT = sumSaidaTA.GetSumTotaisByCodSaida(saida.CodSaida);

            saida.Total = Convert.ToDecimal(sumSaidaProdutoDT.Rows[0]["sumSubtotal"].ToString());
            saida.TotalAVista = Convert.ToDecimal(sumSaidaProdutoDT.Rows[0]["sumSubtotalAVista"].ToString());
            saida.BaseCalculoICMS = Convert.ToDecimal(sumSaidaProdutoDT.Rows[0]["sumBaseCalculoICMS"].ToString());
            saida.ValorICMS = Convert.ToDecimal(sumSaidaProdutoDT.Rows[0]["sumValorICMS"].ToString());
            saida.BaseCalculoICMSSubst = Convert.ToDecimal(sumSaidaProdutoDT.Rows[0]["sumBaseCalculoICMSSubst"].ToString());
            saida.ValorICMSSubst = Convert.ToDecimal(sumSaidaProdutoDT.Rows[0]["sumValorICMSSubst"].ToString());
            saida.ValorIPI = Convert.ToDecimal(sumSaidaProdutoDT.Rows[0]["sumvalorIPI"].ToString());

            GerenciadorSaida.getInstace().atualizar(saida);
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