using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;

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
        public long Inserir(PontaEstoque pontaEstoque)
        {
            var _pontaEstoque = new TbPontaEstoque();
            try
            {
                Atribuir(pontaEstoque, _pontaEstoque);

                context.Add(_pontaEstoque);
                context.SaveChanges();

                return _pontaEstoque.CodPontaEstoque;
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
                var _pontaEstoque = context.TbPontaEstoques.Find(pontaEstoque.CodPontaEstoque);
                if (_pontaEstoque != null)
                {
                    Atribuir(pontaEstoque, _pontaEstoque);
                    context.SaveChanges();
                }
                else
                {
                    throw new NegocioException("Ponta de estoque não encontrada para atualização.");
                }
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
                var pontaEstoque = new TbPontaEstoque();
                pontaEstoque.CodPontaEstoque = codPontaEstoque;

                context.Remove(pontaEstoque);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("PontaEstoque", e.Message, e);
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<PontaEstoque> GetQuery()
        {
            var query = from pontaEstoque in context.TbPontaEstoques
                        select new PontaEstoque
                        {
                            CodPontaEstoque = pontaEstoque.CodPontaEstoque,
                            Quantidade = pontaEstoque.Quantidade,
                            Caracteristica = pontaEstoque.Caracteristica,
                            CodProduto = pontaEstoque.CodProduto,
                            NomeProduto = pontaEstoque.CodProdutoNavigation.Nome
                        };
            return query.AsNoTracking();
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

        private static void Atribuir(PontaEstoque pontaEstoque, TbPontaEstoque _pontaEstoque)
        {
            _pontaEstoque.Quantidade = pontaEstoque.Quantidade;
            _pontaEstoque.Caracteristica = pontaEstoque.Caracteristica;
            _pontaEstoque.CodProduto = pontaEstoque.CodProduto;
        }

    }
}