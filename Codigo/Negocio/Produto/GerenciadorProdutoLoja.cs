using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Dados;
using Dominio;

namespace Negocio
{
    public class GerenciadorProdutoLoja 
    {
        private static GerenciadorProdutoLoja gProdutoLoja;
        private static SaceEntities saceContext;
        private static RepositorioGenerico<ProdutoLojaE> repProdutoLoja;
        
        public static GerenciadorProdutoLoja GetInstance(SaceEntities context)
        {
            if (gProdutoLoja == null)
            {
                gProdutoLoja = new GerenciadorProdutoLoja();
            }
            if (context == null)
            {
                repProdutoLoja = new RepositorioGenerico<ProdutoLojaE>();
            }
            else
            {
                repProdutoLoja = new RepositorioGenerico<ProdutoLojaE>(context);
            }
            saceContext = (SaceEntities)repProdutoLoja.ObterContexto();
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
            DbTransaction transaction = null;
            try
            {
                if (saceContext.Connection.State == System.Data.ConnectionState.Closed)
                    saceContext.Connection.Open();
                transaction = saceContext.Connection.BeginTransaction();

                ProdutoLojaE _produtoLojaE = repProdutoLoja.ObterEntidade(pl => pl.codProduto == produtoLoja.CodProduto && pl.codLoja == produtoLoja.CodLoja);
                _produtoLojaE.estoqueMaximo = produtoLoja.EstoqueMaximo;
                _produtoLojaE.localizacao = produtoLoja.Localizacao;
                _produtoLojaE.localizacao2 = produtoLoja.Localizacao2;
                _produtoLojaE.qtdEstoque = produtoLoja.QtdEstoque;
                _produtoLojaE.qtdEstoqueAux = produtoLoja.QtdEstoqueAux;

                repProdutoLoja.SaveChanges();

                AtualizarEstoqueEntradasProduto(produtoLoja.CodProduto);
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new DadosException("Produto", e.Message, e);
            }
            finally
            {
                saceContext.Connection.Close();
            }
        }

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="produtoLojaPK"></param>
        public void Remover(long codProduto, int codLoja)
        {
            DbTransaction transaction = null;
            try
            {
                if (saceContext.Connection.State == System.Data.ConnectionState.Closed)
                    saceContext.Connection.Open();
                transaction = saceContext.Connection.BeginTransaction();

                repProdutoLoja.Remover(pl => pl.codProduto == codProduto && pl.codLoja == codLoja);
                repProdutoLoja.SaveChanges();
                AtualizarEstoqueEntradasProduto(codProduto);
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new DadosException("Produto", e.Message, e);
            }
            finally
            {
                saceContext.Connection.Close();
            }
        }

        /// <summary>
        /// Consulta simples para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<ProdutoLoja> GetQuery()
        {
            var query = from produtoLoja in saceContext.ProdutoLojaSet
                        join produto in saceContext.ProdutoSet on produtoLoja.codProduto equals produto.codProduto
                        join loja in saceContext.tb_loja on produtoLoja.codLoja equals loja.codLoja
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
        /// Obter dados de um produto em várias lojas
        /// </summary>
        /// <param name="codProduto"></param>
        /// <returns></returns>
        public IEnumerable<ProdutoLoja> ObterPorLoja(int codLoja)
        {
            return GetQuery().Where(pl => pl.CodLoja == codLoja).ToList();
        }

        /// <summary>
        /// Obter estoque de todos os produtos da estoque
        /// </summary>
        /// <returns></returns>
        public List<ProdutoLoja> ObterTodos()
        {
            return GetQuery().ToList();
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
            var query = from produtoLoja in saceContext.ProdutoLojaSet
                        where produtoLoja.codLoja == codLoja && produtoLoja.codProduto == codProduto
                        select produtoLoja;

            ProdutoLojaE produtoLojaE = query.FirstOrDefault();
            if (produtoLojaE != null)
            {
                produtoLojaE.qtdEstoque += quantidade;
                produtoLojaE.qtdEstoqueAux += quantidadeAux;
            }
            else
            {
                produtoLojaE = new ProdutoLojaE();
                produtoLojaE.codLoja = codLoja;
                produtoLojaE.codProduto = codProduto;
                produtoLojaE.qtdEstoque = quantidade;
                produtoLojaE.qtdEstoqueAux = quantidadeAux;
                saceContext.AddToProdutoLojaSet(produtoLojaE);
            }
            saceContext.SaveChanges();
        }

        
        public void AtualizarEstoqueEntradasProduto(long codProduto)
        {
            IEnumerable<ProdutoLoja> listaProdutosLoja = ObterPorProduto(codProduto);


            decimal quantidadeEstoquePrincipalLojas = listaProdutosLoja.Sum(pl => pl.QtdEstoque);
            decimal quantidadeEstoqueAuxLojas = listaProdutosLoja.Sum(pl => pl.QtdEstoqueAux);

            List<EntradaProduto> entradasProdutoPrincipal = (List<EntradaProduto>)GerenciadorEntradaProduto.GetInstance(saceContext).ObterPorProdutoTipoEntrada(codProduto, Entrada.TIPO_ENTRADA);
            List<EntradaProduto> entradasProdutoAuxiliar = (List<EntradaProduto>)GerenciadorEntradaProduto.GetInstance(saceContext).ObterPorProdutoTipoEntrada(codProduto, Entrada.TIPO_ENTRADA_AUX);

            decimal quantidadeEstoquePrincipalEntradaProduto = entradasProdutoPrincipal.Sum(ep => ep.QuantidadeDisponivel);
            decimal quantidadeEstoqueAuxEntradaProduto = entradasProdutoAuxiliar.Sum(ep => ep.QuantidadeDisponivel);
            
            // Atualiza as entradas principais com os valores do estoque totais dos produto / loja
            if ((quantidadeEstoquePrincipalLojas > 0) && (quantidadeEstoquePrincipalLojas != quantidadeEstoquePrincipalEntradaProduto))
            {
                var repEntradaProduto = new RepositorioGenerico<EntradaProdutoE>();
                var saceEntities = (SaceEntities)repEntradaProduto.ObterContexto();
                var query = from entradaProdutoE in saceEntities.EntradaProdutoSet
                            where entradaProdutoE.tb_entrada.codTipoEntrada == Entrada.TIPO_ENTRADA && entradaProdutoE.codProduto == codProduto
                            orderby entradaProdutoE.codEntradaProduto
                            select entradaProdutoE;

                List<EntradaProdutoE> entradasProdutoPrincipalE = query.ToList();
                int cont = entradasProdutoPrincipalE.Count;
                
                while (cont > 0)
                {
                    cont--;
                    if (entradasProdutoPrincipalE[cont].codProduto == 11002)
                        Console.Write("");
                    
                    decimal quantidadeEntrada = (decimal) (entradasProdutoPrincipalE[cont].quantidade * entradasProdutoPrincipalE[cont].quantidadeEmbalagem);
                    if (quantidadeEntrada > quantidadeEstoquePrincipalLojas)
                    {
                        entradasProdutoPrincipalE[cont].quantidade_disponivel = quantidadeEstoquePrincipalLojas;
                        quantidadeEstoquePrincipalLojas = 0;
                    }
                    else
                    {
                        entradasProdutoPrincipalE[cont].quantidade_disponivel = quantidadeEntrada;
                        quantidadeEstoquePrincipalLojas -= quantidadeEntrada;
                    }
                }
                saceEntities.SaveChanges();
            }

            // Atualiza as entradas auxiliares com os valores do estoque totais dos produto / loja
            if (quantidadeEstoqueAuxLojas != quantidadeEstoqueAuxEntradaProduto)
            {
                entradasProdutoAuxiliar.OrderByDescending(ep => ep.DataEntrada);
                int cont = entradasProdutoAuxiliar.Count;
                while (cont > 0)
                {
                    cont--;
                    if (entradasProdutoAuxiliar[cont].Quantidade > quantidadeEstoqueAuxLojas)
                    {
                        entradasProdutoAuxiliar[cont].QuantidadeDisponivel = quantidadeEstoqueAuxLojas;
                        quantidadeEstoqueAuxLojas = 0;
                    }
                    else
                    {
                        entradasProdutoAuxiliar[cont].QuantidadeDisponivel = entradasProdutoAuxiliar[cont].Quantidade;
                        quantidadeEstoqueAuxLojas -= entradasProdutoAuxiliar[cont].Quantidade;
                    }
                    GerenciadorEntradaProduto.GetInstance(saceContext).Atualizar(entradasProdutoAuxiliar[cont]);
                }

            }
        }
    }
}