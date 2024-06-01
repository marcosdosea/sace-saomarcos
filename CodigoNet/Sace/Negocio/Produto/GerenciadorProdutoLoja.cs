using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public class GerenciadorProdutoLoja 
    {
        private readonly SaceContext context;
        private readonly GerenciadorEntradaProduto gerenciadorEntradaProduto;

        public GerenciadorProdutoLoja(SaceContext saceContext)
        {
            context = saceContext;
            gerenciadorEntradaProduto = new GerenciadorEntradaProduto(saceContext);
        }

        /// <summary>
        /// Insere um novo produto na loja
        /// </summary>
        /// <param name="produtoLoja"></param>
        /// <returns></returns>
        public long Inserir(ProdutoLoja produtoLoja)
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

                context.Add(_produtoLoja);
                context.SaveChanges();
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
            var transaction = context.Database.BeginTransaction();

            try
            {
                var _produtoLoja = new TbProdutoLoja();
                _produtoLoja.CodProduto = produtoLoja.CodProduto;
                _produtoLoja.CodLoja = produtoLoja.CodLoja;
                    
                _produtoLoja = context.TbProdutoLojas.Find(produtoLoja);
                if (_produtoLoja != null)
                {
                    _produtoLoja.EstoqueMaximo = produtoLoja.EstoqueMaximo;
                    _produtoLoja.Localizacao = produtoLoja.Localizacao;
                    _produtoLoja.Localizacao2 = produtoLoja.Localizacao2;
                    _produtoLoja.QtdEstoque = produtoLoja.QtdEstoque;
                    _produtoLoja.QtdEstoqueAux = produtoLoja.QtdEstoqueAux;

                    context.Update(_produtoLoja);
                    context.SaveChanges();
                    
                    AtualizarEstoqueEntradasProduto(produtoLoja.CodProduto);
                }
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new DadosException("Produto", e.Message, e);
            }
        }

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="produtoLojaPK"></param>
        public void Remover(long codProduto, int codLoja)
        {
            var transaction = context.Database.BeginTransaction();
            try
            {
                var produtoLoja = new TbProdutoLoja();
                produtoLoja.CodProduto = codProduto;
                produtoLoja.CodLoja = codLoja;
                context.Remove(produtoLoja);
                context.SaveChanges();
                AtualizarEstoqueEntradasProduto(codProduto);
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new DadosException("Produto", e.Message, e);
            }
        }

        /// <summary>
        /// Consulta simples para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<ProdutoLoja> GetQuery()
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
        /// Retorna a soma do estoque de todas as lojas
        /// </summary>
        /// <param name="codProduto"></param>
        /// <returns></returns>
        public decimal ObterEstoque(long codProduto)
        {
            return GetQuery().Where(pl => pl.CodProduto == codProduto).Sum(p => p.QtdEstoque + p.QtdEstoqueAux);
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
            var query = from produtoLoja in context.TbProdutoLojas
                        where produtoLoja.CodLoja == codLoja && produtoLoja.CodProduto == codProduto
                        select produtoLoja;

            var _produtoLoja = query.FirstOrDefault();
            if (_produtoLoja != null)
            {
                _produtoLoja.QtdEstoque += quantidade;
                _produtoLoja.QtdEstoqueAux += quantidadeAux;
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

        
        public void AtualizarEstoqueEntradasProduto(long codProduto)
        {
            IEnumerable<ProdutoLoja> listaProdutosLoja = ObterPorProduto(codProduto);


            decimal quantidadeEstoquePrincipalLojas = listaProdutosLoja.Sum(pl => pl.QtdEstoque);
            decimal quantidadeEstoqueAuxLojas = listaProdutosLoja.Sum(pl => pl.QtdEstoqueAux);

            List<EntradaProduto> entradasProdutoPrincipal = (List<EntradaProduto>)gerenciadorEntradaProduto.ObterPorProdutoTipoEntrada(codProduto, Entrada.TIPO_ENTRADA);
            List<EntradaProduto> entradasProdutoAuxiliar = (List<EntradaProduto>)gerenciadorEntradaProduto.ObterPorProdutoTipoEntrada(codProduto, Entrada.TIPO_ENTRADA_AUX);

            decimal quantidadeEstoquePrincipalEntradaProduto = entradasProdutoPrincipal.Sum(ep => ep.QuantidadeDisponivel);
            decimal quantidadeEstoqueAuxEntradaProduto = entradasProdutoAuxiliar.Sum(ep => ep.QuantidadeDisponivel);
            
            // Atualiza as entradas principais com os valores do estoque totais dos produto / loja
            if ((quantidadeEstoquePrincipalLojas > 0) && (quantidadeEstoquePrincipalLojas != quantidadeEstoquePrincipalEntradaProduto))
            {
                var query = from entradaProdutoE in context.TbEntradaProdutos
                            where entradaProdutoE.CodEntradaNavigation.CodTipoEntrada == Entrada.TIPO_ENTRADA && entradaProdutoE.CodProduto == codProduto
                            orderby entradaProdutoE.CodEntradaProduto
                            select entradaProdutoE;

                List<TbEntradaProduto> entradasProdutoPrincipalE = query.ToList();
                int cont = entradasProdutoPrincipalE.Count;
                
                while (cont > 0)
                {
                    cont--;
                    
                    decimal quantidadeEntrada = (decimal) (entradasProdutoPrincipalE[cont].Quantidade * entradasProdutoPrincipalE[cont].QuantidadeEmbalagem);
                    if (quantidadeEntrada > quantidadeEstoquePrincipalLojas)
                    {
                        entradasProdutoPrincipalE[cont].QuantidadeDisponivel = quantidadeEstoquePrincipalLojas;
                        quantidadeEstoquePrincipalLojas = 0;
                    }
                    else
                    {
                        entradasProdutoPrincipalE[cont].QuantidadeDisponivel = quantidadeEntrada;
                        quantidadeEstoquePrincipalLojas -= quantidadeEntrada;
                    }
                }
                context.SaveChanges();
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
                    gerenciadorEntradaProduto.Atualizar(entradasProdutoAuxiliar[cont]);
                }

            }
        }
    }
}