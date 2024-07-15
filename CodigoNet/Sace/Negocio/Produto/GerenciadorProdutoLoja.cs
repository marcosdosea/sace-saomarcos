using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public static class GerenciadorProdutoLoja
    {
        /// <summary>
        /// Insere um novo produto na loja
        /// </summary>
        /// <param name="produtoLoja"></param>
        /// <returns></returns>
        public static long Inserir(ProdutoLoja produtoLoja)
        {
            try
            {
                var _produtoLoja = new TbProdutoLoja();
                _produtoLoja.CodLoja = produtoLoja.CodLoja;
                _produtoLoja.CodProduto = produtoLoja.CodProduto;
                _produtoLoja.EstoqueMaximo = produtoLoja.EstoqueMaximo;
                _produtoLoja.Localizacao = produtoLoja.Localizacao;
                _produtoLoja.Localizacao2 = produtoLoja.Localizacao2;
                _produtoLoja.QtdEstoque = produtoLoja.QtdEstoque;
                _produtoLoja.QtdEstoqueAux = produtoLoja.QtdEstoqueAux;
                using (var context = new SaceContext())
                {
                    context.Add(_produtoLoja);
                    context.SaveChanges();
                    return produtoLoja.CodProduto;
                }
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
        public static void Atualizar(ProdutoLoja produtoLoja)
        {
            using (var context = new SaceContext())
            {
                var transaction = context.Database.BeginTransaction();

                try
                {
                    var _produtoLoja = context.TbProdutoLojas.FirstOrDefault(p => p.CodLoja == produtoLoja.CodLoja && p.CodProduto == produtoLoja.CodProduto);
                    if (_produtoLoja != null)
                    {
                        _produtoLoja.EstoqueMaximo = produtoLoja.EstoqueMaximo;
                        _produtoLoja.Localizacao = produtoLoja.Localizacao;
                        _produtoLoja.Localizacao2 = produtoLoja.Localizacao2;
                        _produtoLoja.QtdEstoque = produtoLoja.QtdEstoque;
                        _produtoLoja.QtdEstoqueAux = produtoLoja.QtdEstoqueAux;
                        context.Update(_produtoLoja);
                        context.SaveChanges();

                        AtualizarEstoqueEntradasProduto(produtoLoja.CodProduto, context);
                    }
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DadosException("Produto", e.Message, e);
                }
            }
        }

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="produtoLojaPK"></param>
        public static void Remover(long codProduto, int codLoja)
        {
            using (var context = new SaceContext())
            {
                var transaction = context.Database.BeginTransaction();
                try
                {
                    var produtoLoja = new TbProdutoLoja();
                    produtoLoja.CodProduto = codProduto;
                    produtoLoja.CodLoja = codLoja;
                    context.Remove(produtoLoja);
                    context.SaveChanges();
                    AtualizarEstoqueEntradasProduto(codProduto, context);
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DadosException("Produto", e.Message, e);
                }
            }
        }

        /// <summary>
        /// Consulta simples para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private static IQueryable<ProdutoLoja> GetQuery()
        {
            using (var context = new SaceContext())
            {
                var query = from produtoLoja in context.TbProdutoLojas
                            select new ProdutoLoja
                            {
                                CodLoja = produtoLoja.CodLoja,
                                NomeLoja = produtoLoja.CodLojaNavigation.Nome,
                                CodProduto = produtoLoja.CodProduto,
                                EstoqueMaximo = produtoLoja.EstoqueMaximo,
                                Localizacao = produtoLoja.Localizacao,
                                Localizacao2 = produtoLoja.Localizacao2,
                                NomeProduto = produtoLoja.CodProdutoNavigation.Nome,
                                QtdEstoque = produtoLoja.QtdEstoque,
                                QtdEstoqueAux = produtoLoja.QtdEstoqueAux
                            };
                return query.AsNoTracking();
            }
        }

        /// <summary>
        /// Obter produto na loja
        /// </summary>
        /// <param name="codProduto"></param>
        /// <param name="codLoja"></param>
        /// <returns></returns>
        public static IEnumerable<ProdutoLoja> Obter(long codProduto, int codLoja)
        {
            return GetQuery().Where(pl => pl.CodProduto == codProduto && pl.CodLoja == codLoja).ToList();
        }

        /// <summary>
        /// Obter dados de um produto em várias lojas
        /// </summary>
        /// <param name="codProduto"></param>
        /// <returns></returns>
        public static IEnumerable<ProdutoLoja> ObterPorProduto(long codProduto)
        {
            return GetQuery().Where(pl => pl.CodProduto == codProduto).ToList();
        }

        /// <summary>
        /// Obter dados de um produto em várias lojas
        /// </summary>
        /// <param name="codProduto"></param>
        /// <returns></returns>
        public static IEnumerable<ProdutoLoja> ObterPorLoja(int codLoja)
        {
            return GetQuery().Where(pl => pl.CodLoja == codLoja).ToList();
        }

        /// <summary>
        /// Retorna a soma do estoque de todas as lojas
        /// </summary>
        /// <param name="codProduto"></param>
        /// <returns></returns>
        public static decimal ObterEstoque(long codProduto)
        {
            return GetQuery().Where(pl => pl.CodProduto == codProduto).Sum(p => p.QtdEstoque + p.QtdEstoqueAux);
        }
        /// <summary>
        /// Obter estoque de todos os produtos da estoque
        /// </summary>
        /// <returns></returns>
        public static List<ProdutoLoja> ObterTodos()
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
        public static void AdicionaQuantidade(decimal quantidade, decimal quantidadeAux, int codLoja, long codProduto, SaceContext context)
        {
            var query = from produtoLoja in context.TbProdutoLojas
                        where produtoLoja.CodLoja == codLoja && produtoLoja.CodProduto == codProduto
                        select produtoLoja;

            var _produtoLoja = query.FirstOrDefault();
            if (_produtoLoja != null)
            {
                _produtoLoja.QtdEstoque += quantidade;
                _produtoLoja.QtdEstoqueAux += quantidadeAux;
                context.Update(_produtoLoja);
            }
            else
            {
                _produtoLoja = new TbProdutoLoja();
                _produtoLoja.CodLoja = codLoja;
                _produtoLoja.CodProduto = codProduto;
                _produtoLoja.QtdEstoque = quantidade;
                _produtoLoja.QtdEstoqueAux = quantidadeAux;
                context.Add(_produtoLoja);
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Atualiza o estoque do produto após uma entrada
        /// </summary>
        /// <param name="codProduto"></param>
        private static void AtualizarEstoqueEntradasProduto(long codProduto, SaceContext context)
        {
            IEnumerable<ProdutoLoja> listaProdutosLoja = ObterPorProduto(codProduto);
            decimal quantidadeEstoquePrincipalLojas = listaProdutosLoja.Sum(pl => pl.QtdEstoque);
            decimal quantidadeEstoqueAuxLojas = listaProdutosLoja.Sum(pl => pl.QtdEstoqueAux);

            var entradasProdutoPrincipal = context.TbEntradaProdutos
                    .Where(ep => ep.CodProduto == codProduto && ep.CodEntradaNavigation.CodTipoEntrada == Entrada.TIPO_ENTRADA)
                    .OrderByDescending(ep => ep.CodEntradaProduto); ;
            var entradasProdutoAuxiliar = context.TbEntradaProdutos
                    .Where(ep => ep.CodProduto == codProduto && ep.CodEntradaNavigation.CodTipoEntrada == Entrada.TIPO_ENTRADA_AUX)
                    .OrderByDescending(ep => ep.CodEntradaProduto); ;

            decimal quantidadeEstoquePrincipalEntradaProduto = 0;
            entradasProdutoPrincipal?.Sum(ep => ep.QuantidadeDisponivel);
            decimal quantidadeEstoqueAuxEntradaProduto = 0;
            entradasProdutoAuxiliar?.Sum(ep => ep.QuantidadeDisponivel);

            var query = from entradaProdutoE in context.TbEntradaProdutos
                        where entradaProdutoE.CodEntradaNavigation.CodTipoEntrada == Entrada.TIPO_ENTRADA && entradaProdutoE.CodProduto == codProduto
                        orderby entradaProdutoE.CodEntradaProduto descending
                        select entradaProdutoE;
            // Atualiza as entradas principais com os valores do estoque totais dos produto / loja
            if ((quantidadeEstoquePrincipalLojas > 0) && (quantidadeEstoquePrincipalLojas != quantidadeEstoquePrincipalEntradaProduto))
            {
                foreach (var entradaProdutoPrincipalE in query)
                {
                    decimal quantidadeEntrada = (decimal)(entradaProdutoPrincipalE.Quantidade * entradaProdutoPrincipalE.QuantidadeEmbalagem);
                    if (quantidadeEntrada > quantidadeEstoquePrincipalLojas)
                    {
                        entradaProdutoPrincipalE.QuantidadeDisponivel = quantidadeEstoquePrincipalLojas;
                        quantidadeEstoquePrincipalLojas = 0;
                    }
                    else
                    {
                        entradaProdutoPrincipalE.QuantidadeDisponivel = quantidadeEntrada;
                        quantidadeEstoquePrincipalLojas -= quantidadeEntrada;
                    }
                    context.Update(entradaProdutoPrincipalE);
                }
                context.SaveChanges();
            }

            // Atualiza as entradas auxiliares com os valores do estoque totais dos produto / loja
            if (quantidadeEstoqueAuxLojas != quantidadeEstoqueAuxEntradaProduto)
            {
                foreach (var entradaProdutoAuxiliar in query)
                {
                    if (entradaProdutoAuxiliar.Quantidade > quantidadeEstoqueAuxLojas)
                    {
                        entradaProdutoAuxiliar.QuantidadeDisponivel = quantidadeEstoqueAuxLojas;
                        quantidadeEstoqueAuxLojas = 0;
                    }
                    else
                    {
                        entradaProdutoAuxiliar.QuantidadeDisponivel = entradaProdutoAuxiliar.Quantidade;
                        quantidadeEstoqueAuxLojas -= (decimal)entradaProdutoAuxiliar.Quantidade;
                    }
                    context.Update(entradaProdutoAuxiliar);
                }
                context.SaveChanges();
            }
        }
    }
}