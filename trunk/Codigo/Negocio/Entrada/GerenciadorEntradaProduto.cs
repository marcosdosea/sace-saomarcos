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

        public Int64 inserir(EntradaProduto entradaProduto)
        {
            try
            {
                if (entradaProduto.Quantidade > 0)
                {
                    tb_entrada_produtoTA.Insert(entradaProduto.CodEntrada, entradaProduto.CodProduto,
                        entradaProduto.Cfop, entradaProduto.UnidadeCompra, entradaProduto.Quantidade,
                        entradaProduto.QuantidadeEmbalagem, entradaProduto.ValorUnitario,
                        entradaProduto.ValorTotal, entradaProduto.BaseCalculoICMS,
                        entradaProduto.BaseCalculoICMSST, entradaProduto.ValorICMS,
                        entradaProduto.ValorICMSST, entradaProduto.ValorIPI,
                        entradaProduto.DataValidade, entradaProduto.PrecoCusto, entradaProduto.QuantidadeDisponivel);

                    // Incrementa o estoque na loja principal
                    tb_produto_lojaTA.atualizarEstoqueProdutoLoja((entradaProduto.Quantidade * entradaProduto.QuantidadeEmbalagem), 0, Global.LOJA_PADRAO, entradaProduto.CodProduto);
                }

                Produto produto = GerenciadorProduto.getInstace().obterProduto(entradaProduto.CodProduto);
                produto.LucroPrecoVendaAtacado = entradaProduto.LucroPrecoVendaAtacado;
                produto.LucroPrecoVendaVarejo = entradaProduto.LucroPrecoVendaVarejo;
                produto.PrecoVendaAtacado = entradaProduto.PrecoVendaAtacado;
                produto.PrecoVendaVarejo = entradaProduto.PrecoVendaVarejo;
                produto.Frete = entradaProduto.Frete;
                produto.Icms = entradaProduto.Icms;
                produto.IcmsSubstituto = entradaProduto.IcmsSubstituto;
                produto.Ipi = entradaProduto.Ipi;
                produto.Ncmsh = entradaProduto.Ncmsh;
                produto.QtdProdutoAtacado = entradaProduto.QtdProdutoAtacado;
                produto.UltimaDataAtualizacao = DateTime.Now;
                produto.UltimoPrecoCompra = entradaProduto.ValorUnitario / entradaProduto.QuantidadeEmbalagem;
                produto.Cfop = entradaProduto.Cfop;
                produto.CodCST = entradaProduto.CodCST;
                
                GerenciadorProduto.getInstace().atualizar(produto);
                return 0;
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
                    entradaProduto.Cfop, entradaProduto.UnidadeCompra, entradaProduto.Quantidade,
                    entradaProduto.QuantidadeEmbalagem, entradaProduto.ValorUnitario, 
                    entradaProduto.ValorTotal, entradaProduto.BaseCalculoICMS,
                    entradaProduto.BaseCalculoICMSST, entradaProduto.ValorICMS,
                    entradaProduto.ValorICMSST, entradaProduto.ValorIPI, 
                    entradaProduto.DataValidade, entradaProduto.PrecoCusto, entradaProduto.QuantidadeDisponivel,
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
                tb_produto_lojaTA.atualizarEstoqueProdutoLoja((entradaProduto.Quantidade *entradaProduto.QuantidadeEmbalagem*(-1)), 0, Global.LOJA_PADRAO, entradaProduto.CodProduto);
            }
            catch (Exception e)
            {
                throw new DadosException("EntradaProduto", e.Message, e);
            }
        }

        public void estornarItensVendidosEstoque(Produto produto, DateTime dataValidade, Decimal quantidadeDevolvida)
        {
            List<EntradaProduto> entradaProdutos = obterDisponiveisPorValidade(produto.CodProduto);

            if (entradaProdutos.Count > 0)
            {
                Decimal quantidadeRetornada = 0;
                foreach (EntradaProduto entradaProduto in entradaProdutos)
                {
                    if ((entradaProduto.DataValidade.Date.Equals(dataValidade.Date)) && (quantidadeRetornada < quantidadeDevolvida))
                    {
                        if (entradaProduto.Quantidade <= (entradaProduto.QuantidadeDisponivel +(quantidadeDevolvida - quantidadeRetornada)))
                        {
                            entradaProduto.QuantidadeDisponivel += quantidadeDevolvida - quantidadeRetornada;
                            quantidadeRetornada += quantidadeDevolvida - quantidadeRetornada;
                        }
                        else
                        {
                            quantidadeRetornada += entradaProduto.Quantidade - entradaProduto.QuantidadeDisponivel;
                            entradaProduto.QuantidadeDisponivel = entradaProduto.Quantidade;
                        }
                        atualizar(entradaProduto);
                    }
                }

                // acontece quando uma data de validade não existe no estoque
                foreach (EntradaProduto entradaProduto in entradaProdutos)
                {
                    if (quantidadeRetornada < quantidadeDevolvida)
                    {
                         if (entradaProduto.Quantidade <= (entradaProduto.QuantidadeDisponivel +(quantidadeDevolvida - quantidadeRetornada)))
                        {
                            entradaProduto.QuantidadeDisponivel += quantidadeDevolvida - quantidadeRetornada;
                            quantidadeRetornada += quantidadeDevolvida - quantidadeRetornada;
                        }
                        else
                        {
                            quantidadeRetornada += entradaProduto.Quantidade - entradaProduto.QuantidadeDisponivel;
                            entradaProduto.QuantidadeDisponivel = entradaProduto.Quantidade;
                        }
                        atualizar(entradaProduto);
                    }
                }
            }
        }

        public Decimal baixaItensVendidosEstoque(Produto produto, DateTime dataValidade, Decimal quantidadeVendida) {
            List<EntradaProduto> entradaProdutos = obterDisponiveisPorValidade(produto.CodProduto);

            Decimal somaPrecosCusto = 0;


            if (entradaProdutos.Count > 0)
            {
                Decimal quantidadeBaixas = 0;
                foreach (EntradaProduto entradaProduto in entradaProdutos)
                {
                    if ( (entradaProduto.DataValidade.Date.Equals(dataValidade.Date)) && (quantidadeBaixas < quantidadeVendida) )
                    {
                        if (entradaProduto.QuantidadeDisponivel >= (quantidadeVendida-quantidadeBaixas) )
                        {
                            entradaProduto.QuantidadeDisponivel -= quantidadeVendida - quantidadeBaixas;
                            somaPrecosCusto += (quantidadeVendida - quantidadeBaixas) * entradaProduto.PrecoCusto;
                            quantidadeBaixas += (quantidadeVendida - quantidadeBaixas);
                        }
                        else
                        {
                            quantidadeBaixas += entradaProduto.QuantidadeDisponivel;
                            somaPrecosCusto += entradaProduto.QuantidadeDisponivel * entradaProduto.PrecoCusto;
                            entradaProduto.QuantidadeDisponivel = 0;
                        }
                        atualizar(entradaProduto);
                    }
                }

                // acontece quando uma data de validade não existe no estoque
                foreach (EntradaProduto entradaProduto in entradaProdutos)
                {
                   if (quantidadeBaixas < quantidadeVendida)
                   {
                       if (entradaProduto.QuantidadeDisponivel >= (quantidadeVendida - quantidadeBaixas))
                       {
                           entradaProduto.QuantidadeDisponivel -= quantidadeVendida - quantidadeBaixas;
                           somaPrecosCusto += (quantidadeVendida - quantidadeBaixas) * entradaProduto.PrecoCusto;
                           quantidadeBaixas += (quantidadeVendida - quantidadeBaixas);
                       }
                       else
                       {
                           quantidadeBaixas += entradaProduto.QuantidadeDisponivel;
                           somaPrecosCusto += entradaProduto.QuantidadeDisponivel * entradaProduto.PrecoCusto;
                           entradaProduto.QuantidadeDisponivel = 0;
                       }
                       atualizar(entradaProduto);
                    }
                }
            }

            return somaPrecosCusto;
        }

        public DateTime getDataProdutoMaisAntigoEstoque(Produto produto)
        {
            List<EntradaProduto> entradaProdutos = obterDisponiveisPorValidade(produto.CodProduto);

            if (entradaProdutos.Count > 0)
            {
                return entradaProdutos[0].DataValidade;
            }
            return DateTime.Now;
            
        }


        public List<EntradaProduto> obterDisponiveisPorValidade(Int64 codProduto)
        {
            List<EntradaProduto> entradaProdutos = new List<EntradaProduto>();

            tb_entrada_produtoTableAdapter tb_entradaProdutoTA = new tb_entrada_produtoTableAdapter();
            Dados.saceDataSet.tb_entrada_produtoDataTable entradaProdutoDT = tb_entradaProdutoTA.GetDataByProdutoOrderByDataValidade(codProduto);

            for (int i = 0; i < entradaProdutoDT.Count; i++)
            {
                EntradaProduto entradaProduto = new EntradaProduto();

                entradaProduto.CodEntradaProduto = long.Parse(entradaProdutoDT.Rows[i]["codEntradaProduto"].ToString());
                entradaProduto.CodEntrada = int.Parse(entradaProdutoDT.Rows[i]["codEntrada"].ToString());
                entradaProduto.CodProduto = int.Parse(entradaProdutoDT.Rows[i]["codProduto"].ToString());
                entradaProduto.DataValidade = DateTime.Parse(entradaProdutoDT.Rows[i]["data_validade"].ToString());
                entradaProduto.PrecoCusto = decimal.Parse(entradaProdutoDT.Rows[i]["preco_custo"].ToString());
                entradaProduto.Quantidade = decimal.Parse(entradaProdutoDT.Rows[i]["quantidade"].ToString());
                entradaProduto.QuantidadeDisponivel = decimal.Parse(entradaProdutoDT.Rows[i]["quantidade_disponivel"].ToString());
                entradaProduto.BaseCalculoICMS  = Convert.ToDecimal(entradaProdutoDT.Rows[i]["baseCalculoICMS"].ToString());
                entradaProduto.BaseCalculoICMSST = Convert.ToDecimal(entradaProdutoDT.Rows[i]["baseCalculoICMSST"].ToString());
                entradaProduto.Cfop = Convert.ToInt32(entradaProdutoDT.Rows[i]["cfop"].ToString());
                entradaProduto.QuantidadeEmbalagem = Convert.ToDecimal(entradaProdutoDT.Rows[i]["quantidadeEmbalagem"].ToString());
                entradaProduto.UnidadeCompra = entradaProdutoDT.Rows[i]["unidadeCompra"].ToString();
                entradaProduto.ValorICMS = Convert.ToDecimal(entradaProdutoDT.Rows[i]["valorICMS"].ToString());
                entradaProduto.ValorICMSST = Convert.ToDecimal(entradaProdutoDT.Rows[i]["valorICMSST"].ToString());
                entradaProduto.ValorIPI = Convert.ToDecimal(entradaProdutoDT.Rows[i]["valorIPI"].ToString());
                entradaProduto.ValorTotal = Convert.ToDecimal(entradaProdutoDT.Rows[i]["valorTotal"].ToString());
                entradaProduto.ValorUnitario = Convert.ToDecimal(entradaProdutoDT.Rows[i]["valorUnitario"].ToString());

                entradaProdutos.Add(entradaProduto);
            }

            return entradaProdutos;
        }

        public EntradaProduto obter(Int64 codEntradaProduto)
        {
            EntradaProduto entradaProduto = new EntradaProduto();

            tb_entrada_produtoTableAdapter tb_entradaProdutoTA = new tb_entrada_produtoTableAdapter();
            Dados.saceDataSet.tb_entrada_produtoDataTable entradaProdutoDT = tb_entradaProdutoTA.GetDataByCodEntradaProduto(codEntradaProduto);
            
            entradaProduto.CodEntradaProduto = long.Parse(entradaProdutoDT.Rows[0]["codEntradaProduto"].ToString());
            entradaProduto.CodEntrada = int.Parse(entradaProdutoDT.Rows[0]["codEntrada"].ToString());
            entradaProduto.CodProduto = int.Parse(entradaProdutoDT.Rows[0]["codProduto"].ToString());
            entradaProduto.DataValidade = DateTime.Parse(entradaProdutoDT.Rows[0]["data_validade"].ToString());
            entradaProduto.PrecoCusto = decimal.Parse(entradaProdutoDT.Rows[0]["preco_custo"].ToString());
            entradaProduto.Quantidade = decimal.Parse(entradaProdutoDT.Rows[0]["quantidade"].ToString());
            entradaProduto.QuantidadeDisponivel = decimal.Parse(entradaProdutoDT.Rows[0]["quantidade_disponivel"].ToString());
            entradaProduto.BaseCalculoICMS = Convert.ToDecimal(entradaProdutoDT.Rows[0]["baseCalculoICMS"].ToString());
            entradaProduto.BaseCalculoICMSST = Convert.ToDecimal(entradaProdutoDT.Rows[0]["baseCalculoICMSST"].ToString());
            entradaProduto.Cfop = Convert.ToInt32(entradaProdutoDT.Rows[0]["cfop"].ToString());
            entradaProduto.QuantidadeEmbalagem = Convert.ToDecimal(entradaProdutoDT.Rows[0]["quantidadeEmbalagem"].ToString());
            entradaProduto.UnidadeCompra = entradaProdutoDT.Rows[0]["unidadeCompra"].ToString();
            entradaProduto.ValorICMS = Convert.ToDecimal(entradaProdutoDT.Rows[0]["valorICMS"].ToString());
            entradaProduto.ValorICMSST = Convert.ToDecimal(entradaProdutoDT.Rows[0]["valorICMSST"].ToString());
            entradaProduto.ValorIPI = Convert.ToDecimal(entradaProdutoDT.Rows[0]["valorIPI"].ToString());
            entradaProduto.ValorTotal = Convert.ToDecimal(entradaProdutoDT.Rows[0]["valorTotal"].ToString());
            entradaProduto.ValorUnitario = Convert.ToDecimal(entradaProdutoDT.Rows[0]["valorUnitario"].ToString());
                      
            return entradaProduto;
        }
    }
}