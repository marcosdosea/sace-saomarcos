using System;
using System.Collections.Generic;
using System.Linq;
using Dados;
using Dominio;

namespace Negocio
{
    public class GerenciadorPontaEstoque
    {

        private readonly SaceContext context;

        public GerenciadorPontaEstoque(SaceContext saceContext)
        {
            context = saceContext;
        }

        /// <summary>
        /// Insere dados do pontaEstoque
        /// </summary>
        /// <param name="pontaEstoque"></param>
        /// <returns></returns>
        public Int64 Inserir(PontaEstoque pontaEstoque)
        {
            var repPontaEstoque = new RepositorioGenerico<tb_ponta_estoque>();
            tb_ponta_estoque _pontaEstoqueE = new tb_ponta_estoque();
            try
            {

                Atribuir(pontaEstoque, _pontaEstoqueE);

                repPontaEstoque.Inserir(_pontaEstoqueE);
                repPontaEstoque.SaveChanges();

                return _pontaEstoqueE.codPontaEstoque;
            }
            catch (Exception e)
            {
                throw new DadosException("PontaEstoque", e.Message, e);
            }

        }

        
        /// <summary>
        /// Atualiza dados do pontaEstoque
        /// </summary>
        /// <param name="pontaEstoque"></param>
        public void Atualizar(PontaEstoque pontaEstoque)
        {
            try
            {
                var repPontaEstoque = new RepositorioGenerico<tb_ponta_estoque>();
                tb_ponta_estoque _pontaEstoqueE = repPontaEstoque.ObterEntidade(b => b.codPontaEstoque == pontaEstoque.CodPontaEstoque);
                Atribuir(pontaEstoque, _pontaEstoqueE);

                repPontaEstoque.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("PontaEstoque", e.Message, e);
            }
        }

        /// <summary>
        /// Remove dados do pontaEstoque
        /// </summary>
        /// <param name="codPontaEstoque"></param>
        public void Remover(long codPontaEstoque)
        {
            try
            {
                var repPontaEstoque = new RepositorioGenerico<tb_ponta_estoque>();
                repPontaEstoque.Remover(b => b.codPontaEstoque == codPontaEstoque);
                repPontaEstoque.SaveChanges();
            }
            catch (Exception e)
            {
                throw  e;//DadosException("PontaEstoque", e.Message, e);
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<PontaEstoque> GetQuery()
        {
            var repPontaEstoque = new RepositorioGenerico<tb_ponta_estoque>();
            var saceEntities = (SaceEntities)repPontaEstoque.ObterContexto();
            var query = from pontaEstoque in saceEntities.tb_ponta_estoque
                        select new PontaEstoque
                        {
                            CodPontaEstoque = pontaEstoque.codPontaEstoque,
                            Quantidade = pontaEstoque.quantidade,
                            Caracteristica = pontaEstoque.caracteristica,
                            CodProduto = pontaEstoque.codProduto,
                            NomeProduto = pontaEstoque.tb_produto.nome
                        };
            return query;
        }

        /// <summary>
        /// Obtém todos os pontaEstoque cadastrados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PontaEstoque> ObterTodos()
        {
            return GetQuery().ToList();
        }

        /// <summary>
        /// Obtém pontaEstoque com o código especificiado
        /// </summary>
        /// <param name="codPontaEstoque"></param>
        /// <returns></returns>
        public IEnumerable<PontaEstoque> Obter(long codPontaEstoque)
        {
            return GetQuery().Where(pontaEstoque => pontaEstoque.CodPontaEstoque == codPontaEstoque).ToList();
        }

        /// <summary>
        /// Obtém pontaEstoques que iniciam com o nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public IEnumerable<PontaEstoque> ObterPorProduto(long codProduto)
        {
            return GetQuery().Where(pontaEstoque => pontaEstoque.CodProduto.Equals(codProduto)).ToList();
        }

        private static void Atribuir(PontaEstoque pontaEstoque, tb_ponta_estoque _pontaEstoqueE)
        {
            _pontaEstoqueE.quantidade = pontaEstoque.Quantidade;
            _pontaEstoqueE.caracteristica = pontaEstoque.Caracteristica;
            _pontaEstoqueE.codProduto = pontaEstoque.CodProduto;
        }

    }
}