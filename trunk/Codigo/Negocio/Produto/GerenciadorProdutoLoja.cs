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
    public class GerenciadorProdutoLoja 
    {
        private static GerenciadorProdutoLoja gProdutoLoja;
        
        public static GerenciadorProdutoLoja GetInstance()
        {
            if (gProdutoLoja == null)
            {
                gProdutoLoja = new GerenciadorProdutoLoja();
            }
            return gProdutoLoja;
        }

        /// <summary>
        /// Insere um novo produto na loja
        /// </summary>
        /// <param name="produtoLoja"></param>
        /// <returns></returns>
        public Int64 Inserir(ProdutoLoja produtoLoja)
        {
            try
            {
                var repProdutoLoja = new RepositorioGenerico<ProdutoLojaE>();

                ProdutoLojaE _produtoLojaE = new ProdutoLojaE();
                _produtoLojaE.codLoja = produtoLoja.CodLoja;
                _produtoLojaE.codProduto = produtoLoja.CodProduto;
                _produtoLojaE.estoqueMaximo = produtoLoja.EstoqueMaximo;
                _produtoLojaE.localizacao = produtoLoja.Localizacao;
                _produtoLojaE.localizacao2 = produtoLoja.Localizacao2;
                _produtoLojaE.qtdEstoque = produtoLoja.QtdEstoque;
                _produtoLojaE.qtdEstoqueAux = produtoLoja.QtdEstoqueAux;

                repProdutoLoja.Inserir(_produtoLojaE);
                repProdutoLoja.SaveChanges();
                return produtoLoja.CodProduto;
            }
            catch (Exception e)
            {
                throw new DadosException("Produto Loja", e.Message, e);
            }
        }

        /// <summary>
        /// Atualiza os dados de um produto na loja
        /// </summary>
        /// <param name="produtoLoja"></param>
        public void Atualizar(ProdutoLoja produtoLoja)
        {
            try
            {
                var repProdutoLoja = new RepositorioGenerico<ProdutoLojaE>();

                ProdutoLojaE _produtoLojaE = repProdutoLoja.ObterEntidade(pl => pl.codProduto == produtoLoja.CodProduto && pl.codLoja == produtoLoja.CodLoja);
                _produtoLojaE.estoqueMaximo = produtoLoja.EstoqueMaximo;
                _produtoLojaE.localizacao = produtoLoja.Localizacao;
                _produtoLojaE.localizacao2 = produtoLoja.Localizacao2;
                _produtoLojaE.qtdEstoque = produtoLoja.QtdEstoque;
                _produtoLojaE.qtdEstoqueAux = produtoLoja.QtdEstoqueAux;

                repProdutoLoja.SaveChanges();
                
                AtualizarEstoqueEntradasProduto(produtoLoja.CodProduto);
            }
            catch (Exception e)
            {
                throw new DadosException("Produto", e.Message, e);
            }
        }

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="produtoLojaPK"></param>
        public void Remover(long codProduto, int codLoja)
        {
            try
            {
                var repProdutoLoja = new RepositorioGenerico<ProdutoLojaE>();

                repProdutoLoja.Remover(pl => pl.codProduto == codProduto && pl.codLoja == codLoja);
                repProdutoLoja.SaveChanges();
                AtualizarEstoqueEntradasProduto(codProduto);
            }
            catch (Exception e)
            {
                throw new DadosException("Produto", e.Message, e);
            }
        }

        /// <summary>
        /// Consulta simples para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<ProdutoLoja> GetQuery()
        {
            var repProdutoLoja = new RepositorioGenerico<ProdutoLojaE>();

            var saceEntities = (SaceEntities)repProdutoLoja.ObterContexto();
            var query = from produtoLoja in saceEntities.ProdutoLojaSet
                        join produto in saceEntities.ProdutoSet on produtoLoja.codProduto equals produto.codProduto
                        join loja in saceEntities.LojaSet on produtoLoja.codLoja equals loja.codLoja
                        select new ProdutoLoja
                        {
                            CodLoja = produtoLoja.codLoja,
                            NomeLoja = loja.nome,
                            CodProduto = produtoLoja.codProduto,
                            EstoqueMaximo = produtoLoja.estoqueMaximo,
                            Localizacao = produtoLoja.localizacao,
                            Localizacao2 = produtoLoja.localizacao2,
                            NomeProduto = produto.nome,
                            QtdEstoque = produtoLoja.qtdEstoque,
                            QtdEstoqueAux = produtoLoja.qtdEstoqueAux
                        };
            return query;
        }

        /// <summary>
        /// Obter produto na loja
        /// </summary>
        /// <param name="codProduto"></param>
        /// <param name="codLoja"></param>
        /// <returns></returns>
        public IEnumerable<ProdutoLoja> Obter(long codProduto, int codLoja)
        {
            return GetQuery().Where(pl => pl.CodProduto == codProduto && pl.CodLoja == codLoja).ToList();
        }

        /// <summary>
        /// Obter dados de um produto em várias lojas
        /// </summary>
        /// <param name="codProduto"></param>
        /// <returns></returns>
        public IEnumerable<ProdutoLoja> ObterPorProduto(long codProduto)
        {
            return GetQuery().Where(pl => pl.CodProduto == codProduto).ToList();
        }

       
        /// <summary>
        /// Adiciona quantida e quantidadeAux ao produto loja
        /// </summary>
        /// <param name="quantidade"></param>
        /// <param name="quantidadeAux"></param>
        /// <param name="codLoja"></param>
        /// <param name="codProduto"></param>
        public void AdicionaQuantidade(decimal quantidade, decimal quantidadeAux, Int32 codLoja, long codProduto)
        {
            var repProdutoLoja = new RepositorioGenerico<ProdutoLojaE>();
            
            var saceEntities = (SaceEntities)repProdutoLoja.ObterContexto();
            var query = from produtoLoja in saceEntities.ProdutoLojaSet
                        where produtoLoja.codLoja == codLoja && produtoLoja.codProduto == codProduto
                        select produtoLoja;
            int numeroRegistros = query.Count();
            if (numeroRegistros > 0)
            {
                foreach (ProdutoLojaE _produtoLojaE in query)
                {
                    if (_produtoLojaE != null)
                    {
                        _produtoLojaE.qtdEstoque += quantidade;
                        _produtoLojaE.qtdEstoqueAux += quantidadeAux;
                    }
                }
            }
            else
            {
                ProdutoLojaE _produtoLojaE = new ProdutoLojaE();
                _produtoLojaE.codLoja = codLoja;
                _produtoLojaE.codProduto = codProduto;
                _produtoLojaE.qtdEstoque = quantidade;
                _produtoLojaE.qtdEstoqueAux = quantidadeAux;
                repProdutoLoja.Inserir(_produtoLojaE);
            }
            
            repProdutoLoja.SaveChanges();
        }

        
        private void AtualizarEstoqueEntradasProduto(long codProduto)
        {
            IEnumerable<ProdutoLoja> listaProdutosLoja = ObterPorProduto(codProduto);


            decimal quantidadeEstoquePrincipalLojas = listaProdutosLoja.Sum(pl => pl.QtdEstoque);
            decimal quantidadeEstoqueAuxLojas = listaProdutosLoja.Sum(pl => pl.QtdEstoqueAux);

            List<EntradaProduto> entradasProdutoPrincipal = (List<EntradaProduto>)GerenciadorEntradaProduto.GetInstance().ObterPorProdutoTipoEntrada(codProduto, Entrada.TIPO_ENTRADA);
            List<EntradaProduto> entradasProdutoAuxiliar = (List<EntradaProduto>)GerenciadorEntradaProduto.GetInstance().ObterPorProdutoTipoEntrada(codProduto, Entrada.TIPO_ENTRADA_AUX);

            decimal quantidadeEstoquePrincipalEntradaProduto = entradasProdutoPrincipal.Sum(ep => ep.QuantidadeDisponivel);
            decimal quantidadeEstoqueAuxEntradaProduto = entradasProdutoAuxiliar.Sum(ep => ep.QuantidadeDisponivel);
            
            // Atualiza as entradas principais com os valores do estoque totais dos produto / loja
            if (quantidadeEstoquePrincipalLojas != quantidadeEstoquePrincipalEntradaProduto)
            {

                for (int i = 0; (entradasProdutoPrincipal != null) && (i < entradasProdutoPrincipal.Count); i++)
                {
                    // Vai decremetar o contador até organizar a quantidade disponível dos lotes de entrada
                    if (quantidadeEstoquePrincipalLojas > 0)
                    {
                        if (entradasProdutoPrincipal[i].Quantidade < quantidadeEstoquePrincipalLojas)
                        {
                            entradasProdutoPrincipal[i].QuantidadeDisponivel = entradasProdutoPrincipal[i].Quantidade;
                            quantidadeEstoquePrincipalLojas -= entradasProdutoPrincipal[i].Quantidade;
                        }
                        else
                        {
                            entradasProdutoPrincipal[i].QuantidadeDisponivel = quantidadeEstoquePrincipalLojas;
                            quantidadeEstoquePrincipalLojas = 0;
                        }
                    }
                    else
                    {
                        entradasProdutoPrincipal[i].QuantidadeDisponivel = 0;
                    }
                    GerenciadorEntradaProduto.GetInstance().Atualizar(entradasProdutoPrincipal[i]);
                }

            }


            // Atualiza as entradas auxiliares com os valores do estoque totais dos produto / loja
            if (quantidadeEstoqueAuxLojas != quantidadeEstoqueAuxEntradaProduto)
            {
                for (int i = 0; (entradasProdutoAuxiliar != null) && (i < entradasProdutoAuxiliar.Count); i++)
                {
                    // Vai decremetar o contador até organizar a quantidade disponível dos lotes de entrada
                    if (quantidadeEstoqueAuxLojas > 0)
                    {
                        if (entradasProdutoAuxiliar[i].Quantidade < quantidadeEstoqueAuxLojas)
                        {
                            entradasProdutoAuxiliar[i].QuantidadeDisponivel = entradasProdutoAuxiliar[i].Quantidade;
                            quantidadeEstoqueAuxLojas -= entradasProdutoAuxiliar[i].Quantidade;
                        }
                        else
                        {
                            entradasProdutoAuxiliar[i].QuantidadeDisponivel = quantidadeEstoqueAuxLojas;
                            quantidadeEstoqueAuxLojas = 0;
                        }
                    }
                    else
                    {
                        entradasProdutoAuxiliar[i].QuantidadeDisponivel = 0;
                    }
                    GerenciadorEntradaProduto.GetInstance().Atualizar(entradasProdutoAuxiliar[i]);
                }

            }
        }
    }
}