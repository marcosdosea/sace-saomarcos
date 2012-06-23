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

            if (entradaProduto.Quantidade == 0)
                throw new NegocioException("A quantidade do produto não pode ser igual a zero.");

            if (entradaProduto.PrecoVendaVarejo <= 0)
                throw new NegocioException("O preço de venda deve ser maior que zero.");

            if (entradaProduto.QuantidadeEmbalagem <= 0)
                throw new NegocioException("A quantidade de produtos em cada embalagem deve ser maior que zero.");

            try
            {
                tb_entrada_produtoTA.Insert(entradaProduto.CodEntrada, entradaProduto.CodProduto,
                    entradaProduto.Cfop, entradaProduto.UnidadeCompra, entradaProduto.Quantidade,
                    entradaProduto.QuantidadeEmbalagem, entradaProduto.ValorUnitario,
                    entradaProduto.ValorTotal, entradaProduto.BaseCalculoICMS,
                    entradaProduto.BaseCalculoICMSST, entradaProduto.ValorICMS,
                    entradaProduto.ValorICMSST, entradaProduto.ValorIPI,
                    entradaProduto.DataValidade, entradaProduto.PrecoCusto, entradaProduto.QuantidadeDisponivel, entradaProduto.ValorDesconto, entradaProduto.CodCST);

                if ((entradaProduto.CodTipoEntrada == Entrada.TIPO_ENTRADA) || (entradaProduto.CodTipoEntrada == Entrada.TIPO_ENTRADA_AUX))
                {
                    // Incrementa o estoque na loja principal
                    tb_produto_lojaTA.AdicionaQuantidade((entradaProduto.Quantidade * entradaProduto.QuantidadeEmbalagem), 0, Global.LOJA_PADRAO, entradaProduto.CodProduto);

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
                    produto.DataUltimoPedido = entradaProduto.DataEntrada;
                    produto.UltimoPrecoCompra = entradaProduto.ValorUnitario / entradaProduto.QuantidadeEmbalagem;
                    produto.Cfop = entradaProduto.Cfop;
                    produto.CodCST = entradaProduto.CodCST;
                    produto.Desconto = entradaProduto.Desconto;

                    if (entradaProduto.FornecedorEhFabricante)
                        produto.CodFabricante = entradaProduto.CodFornecedor;

                    GerenciadorProduto.getInstace().atualizar(produto);
                }
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
                    entradaProduto.ValorDesconto, entradaProduto.CodCST, entradaProduto.CodEntradaProduto);
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

                Entrada entrada = GerenciadorEntrada.getInstace().obterEntrada(entradaProduto.CodEntrada);

                if ((entrada.CodTipoEntrada == Entrada.TIPO_ENTRADA) || (entrada.CodTipoEntrada == Entrada.TIPO_ENTRADA_AUX))
                {
                    // Decrementa o estoque na loja principal
                    tb_produto_lojaTA.AdicionaQuantidade((entradaProduto.Quantidade * entradaProduto.QuantidadeEmbalagem * (-1)), 0, Global.LOJA_PADRAO, entradaProduto.CodProduto);
                }
            }
            catch (Exception e)
            {
                throw new DadosException("EntradaProduto", e.Message, e);
            }
        }
        

        private void estornarItensVendidosEstoque(Produto produto, DateTime dataValidade, Decimal quantidadeDevolvida)
        {
            List<EntradaProduto> entradaProdutos = obterVendidosOrdenadoPorValidade(produto.CodProduto);
            Decimal quantidadeRetornada = 0;

            if (entradaProdutos != null)
            {
                if (produto.TemVencimento)
                {
                    foreach (EntradaProduto entradaProduto in entradaProdutos)
                    {
                        if ((entradaProduto.DataValidade.Date.Equals(dataValidade.Date)) && (quantidadeRetornada < quantidadeDevolvida))
                        {
                            if (entradaProduto.Quantidade <= (entradaProduto.QuantidadeDisponivel + (quantidadeDevolvida - quantidadeRetornada)))
                            {
                                entradaProduto.QuantidadeDisponivel += quantidadeDevolvida - quantidadeRetornada;
                                quantidadeRetornada += quantidadeDevolvida - quantidadeRetornada;
                                atualizar(entradaProduto);
                            }
                        }
                        if (quantidadeDevolvida == quantidadeRetornada)
                            break;
                    }
                }

                // acontece quando uma data de validade não existe no estoque
                if (quantidadeRetornada < quantidadeDevolvida)
                {

                    foreach (EntradaProduto entradaProduto in entradaProdutos)
                    {
                        if (entradaProduto.Quantidade >= (entradaProduto.QuantidadeDisponivel + (quantidadeDevolvida - quantidadeRetornada)))
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
                        if (quantidadeDevolvida == quantidadeRetornada)
                            break;
                    }
                }
            }
            
            // acontece quando uma data de validade não existe no estoque
            if (quantidadeRetornada < quantidadeDevolvida)
            {
                baixaItensVendidosEstoqueEntradaPadrao(produto, ((-1) * (quantidadeDevolvida-quantidadeRetornada)));
            }
        }
        

        public Decimal baixaItensVendidosEstoque(Produto produto, DateTime dataValidade, Decimal quantidadeVendida) {
            List<EntradaProduto> entradaProdutos = obterDisponiveisOrdenadoPorValidade(produto.CodProduto);

            decimal somaPrecosCusto = 0;
            decimal quantidadeBaixas = 0;

            if (quantidadeVendida < 0)
            {
                estornarItensVendidosEstoque(produto, dataValidade, Math.Abs(quantidadeVendida));
            } 
            else if (entradaProdutos != null)
            {
                // reduz a quantidade de itens disponíveis nos lotes de entrada
                foreach (EntradaProduto entradaProduto in entradaProdutos)
                {
                    if (quantidadeVendida == quantidadeBaixas)
                        break;
                    if (produto.TemVencimento)
                    {
                        // quando produto tem vencimento
                        if ((entradaProduto.DataValidade.Date.Equals(dataValidade.Date)) && (quantidadeBaixas < quantidadeVendida))
                        {
                            if (entradaProduto.QuantidadeDisponivel >= (quantidadeVendida - quantidadeBaixas))
                            {
                                entradaProduto.QuantidadeDisponivel -= quantidadeVendida - quantidadeBaixas;
                                somaPrecosCusto += (quantidadeVendida - quantidadeBaixas) * entradaProduto.PrecoCusto;
                                quantidadeBaixas += (quantidadeVendida - quantidadeBaixas);
                            }
                        }
                    }
                    else
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
                        }
                    }
                    atualizar(entradaProduto);
                }
            }

            if (quantidadeBaixas < quantidadeVendida)
            {
                somaPrecosCusto += baixaItensVendidosEstoqueEntradaPadrao(produto, (quantidadeVendida - quantidadeBaixas));
            }

            return somaPrecosCusto;
        }

        private decimal baixaItensVendidosEstoqueEntradaPadrao(Produto produto, decimal quantidade) {
            EntradaProduto entradaProduto = obter(Global.ENTRADA_PADRAO, produto.CodProduto);

            if (entradaProduto != null)
            {
                entradaProduto.QuantidadeDisponivel -= quantidade;
                atualizar(entradaProduto);
            }
            else
            {
                entradaProduto = new EntradaProduto();
                entradaProduto.CodEntrada = Global.ENTRADA_PADRAO;
                entradaProduto.CodProduto = produto.CodProduto; 

                entradaProduto.Cfop = produto.Cfop;
                entradaProduto.UnidadeCompra = produto.Unidade;
                entradaProduto.Quantidade = (produto.TemVencimento) ? quantidade : 10000;
                entradaProduto.QuantidadeEmbalagem = 1;
                entradaProduto.ValorUnitario = produto.UltimoPrecoCompra;
                entradaProduto.ValorTotal = 0;
                entradaProduto.BaseCalculoICMS = 0;
                entradaProduto.BaseCalculoICMSST = 0;
                entradaProduto.ValorICMS = 0;
                entradaProduto.ValorICMSST = 0;
                entradaProduto.ValorIPI = 0;
                entradaProduto.DataValidade = DateTime.Now;
                // para não perder os dados do produto
                entradaProduto.LucroPrecoVendaAtacado = produto.LucroPrecoVendaAtacado;
                entradaProduto.LucroPrecoVendaVarejo = produto.LucroPrecoVendaVarejo;
                entradaProduto.PrecoVendaAtacado = produto.PrecoVendaAtacado;
                entradaProduto.PrecoVendaVarejo = produto.PrecoVendaVarejo;
                entradaProduto.Frete = produto.Frete;
                entradaProduto.Icms = produto.Icms;
                entradaProduto.IcmsSubstituto = produto.IcmsSubstituto;
                entradaProduto.Ipi = produto.Ipi;
                entradaProduto.Ncmsh = produto.Ncmsh;
                entradaProduto.QtdProdutoAtacado = produto.QtdProdutoAtacado;
                entradaProduto.DataEntrada = produto.DataUltimoPedido;
                entradaProduto.Desconto = produto.Desconto;

                if (GerenciadorProduto.getInstace().ehProdututoTributadoIntegral(produto.CodCST))
                {
                    entradaProduto.PrecoCusto = GerenciadorPrecos.getInstance().calculaPrecoCustoNormal(produto.UltimoPrecoCompra, produto.Icms, produto.Simples, produto.Ipi, produto.Frete, Global.CUSTO_MANUTENCAO_LOJA, produto.Desconto);
                }
                else
                {
                    entradaProduto.PrecoCusto = GerenciadorPrecos.getInstance().calculaPrecoCustoSubstituicao(produto.UltimoPrecoCompra, produto.IcmsSubstituto, produto.Simples, produto.Ipi, produto.Frete, Global.CUSTO_MANUTENCAO_LOJA, produto.Desconto);
                }
                entradaProduto.QuantidadeDisponivel = (produto.TemVencimento) ? 0 : 10000 - quantidade; 
                entradaProduto.ValorDesconto = 0;
                entradaProduto.CodCST = produto.CodCST;

                inserir(entradaProduto);
            }
            
            return 0;
        }

        public DateTime getDataProdutoMaisAntigoEstoque(Produto produto)
        {
            List<EntradaProduto> entradaProdutos = obterDisponiveisOrdenadoPorValidade(produto.CodProduto);

            if (entradaProdutos.Count > 0)
            {
                return entradaProdutos[0].DataValidade;
            }
            return DateTime.Now;
            
        }

        public decimal ObterEstoquePrincipalDisponivel(long codProduto)
        {

            tb_entrada_produtoTableAdapter tb_entradaProdutoTA = new tb_entrada_produtoTableAdapter();
            decimal? estoque = (decimal?) tb_entradaProdutoTA.GetEstoquePrincipalDisponivel(codProduto);

            return (estoque == null) ? 0 : (decimal)estoque;
        }

        public decimal ObterEstoqueAuxDisponivel(long codProduto)
        {

            tb_entrada_produtoTableAdapter tb_entradaProdutoTA = new tb_entrada_produtoTableAdapter();
            decimal? estoque = tb_entradaProdutoTA.GetEstoqueAuxDisponivel(codProduto);

            return (estoque == null) ? 0 : (decimal)estoque;
        }

        private List<EntradaProduto> obterDisponiveisOrdenadoPorValidade(long codProduto)
        {
            
            tb_entrada_produtoTableAdapter tb_entradaProdutoTA = new tb_entrada_produtoTableAdapter();
            Dados.saceDataSet.tb_entrada_produtoDataTable entradaProdutoDT = tb_entradaProdutoTA.GetEntradaProdutosDisponiveisOrderByDataValidade(codProduto);

            return converterEntradaProduto(entradaProdutoDT);
        }

        public List<EntradaProduto> ObterEntradasPrincipais(long codProduto)
        {
            tb_entrada_produtoTableAdapter tb_entradaProdutoTA = new tb_entrada_produtoTableAdapter();
            Dados.saceDataSet.tb_entrada_produtoDataTable entradaProdutoDT = tb_entradaProdutoTA.GetEntradaProdutosPrincipais(codProduto);

            return converterEntradaProduto(entradaProdutoDT);
        }

        public List<EntradaProduto> ObterEntradasAuxiliar(long codProduto)
        {
            tb_entrada_produtoTableAdapter tb_entradaProdutoTA = new tb_entrada_produtoTableAdapter();
            Dados.saceDataSet.tb_entrada_produtoDataTable entradaProdutoDT = tb_entradaProdutoTA.GetEntradaProdutosAux(codProduto);

            return converterEntradaProduto(entradaProdutoDT);
        }

        private List<EntradaProduto> obterVendidosOrdenadoPorValidade(long codProduto)
        {

            tb_entrada_produtoTableAdapter tb_entradaProdutoTA = new tb_entrada_produtoTableAdapter();
            Dados.saceDataSet.tb_entrada_produtoDataTable entradaProdutoDT = tb_entradaProdutoTA.GetEntradaProdutosVendidosOrderByDataValidade(codProduto);

            return converterEntradaProduto(entradaProdutoDT);
        }

        private EntradaProduto obter(long codEntrada, long codProduto)
        {

            tb_entrada_produtoTableAdapter tb_entradaProdutoTA = new tb_entrada_produtoTableAdapter();
            Dados.saceDataSet.tb_entrada_produtoDataTable entradaProdutoDT = tb_entradaProdutoTA.GetDataByCodEntradaCodProduto(codEntrada, codProduto);
            
            List<EntradaProduto> entradaProdutos = converterEntradaProduto(entradaProdutoDT);
            return (entradaProdutos != null) ? entradaProdutos[0] : null;
        }

        public EntradaProduto obter(long codEntradaProduto)
        {
            tb_entrada_produtoTableAdapter tb_entradaProdutoTA = new tb_entrada_produtoTableAdapter();
            Dados.saceDataSet.tb_entrada_produtoDataTable entradaProdutoDT = tb_entradaProdutoTA.GetDataByCodEntradaProduto(codEntradaProduto);

            List<EntradaProduto> entradaProdutos = converterEntradaProduto(entradaProdutoDT); 
            return (entradaProdutos != null) ? entradaProdutos[0] : null;
        }


        private List<EntradaProduto> converterEntradaProduto(Dados.saceDataSet.tb_entrada_produtoDataTable entradaProdutoDT)
        {

            List<EntradaProduto> entradaProdutos = new List<EntradaProduto>();

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
                entradaProduto.BaseCalculoICMS = Convert.ToDecimal(entradaProdutoDT.Rows[i]["baseCalculoICMS"].ToString());
                entradaProduto.BaseCalculoICMSST = Convert.ToDecimal(entradaProdutoDT.Rows[i]["baseCalculoICMSST"].ToString());
                entradaProduto.Cfop = Convert.ToInt32(entradaProdutoDT.Rows[i]["cfop"].ToString());
                entradaProduto.QuantidadeEmbalagem = Convert.ToDecimal(entradaProdutoDT.Rows[i]["quantidadeEmbalagem"].ToString());
                entradaProduto.UnidadeCompra = entradaProdutoDT.Rows[i]["unidadeCompra"].ToString();
                entradaProduto.ValorICMS = Convert.ToDecimal(entradaProdutoDT.Rows[i]["valorICMS"].ToString());
                entradaProduto.ValorICMSST = Convert.ToDecimal(entradaProdutoDT.Rows[i]["valorICMSST"].ToString());
                entradaProduto.ValorIPI = Convert.ToDecimal(entradaProdutoDT.Rows[i]["valorIPI"].ToString());
                entradaProduto.ValorTotal = Convert.ToDecimal(entradaProdutoDT.Rows[i]["valorTotal"].ToString());
                entradaProduto.ValorUnitario = Convert.ToDecimal(entradaProdutoDT.Rows[i]["valorUnitario"].ToString());
                entradaProduto.CodCST = entradaProdutoDT.Rows[0]["codCST"].ToString();

                entradaProdutos.Add(entradaProduto);
            }

            return entradaProdutos.Count > 0 ? entradaProdutos : null;
        }
    }
}