using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public class GerenciadorImposto
    {

        private static List<Imposto> listaImpostos;

        private readonly SaceContext context;

        public GerenciadorImposto(SaceContext saceContext)
        {
            context = saceContext;
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<Imposto> GetQuery()
        {
            var query = from imposto in context.TbImpostos
                        select new Imposto
                        {
                            Ncmsh = imposto.Ncmsh,
                            AliqNac = imposto.AliqNac,
                            AliqImp = imposto.AliqImp
                        };
            return query.AsNoTracking();
        }

        /// <summary>
        /// Obtém todos os grupos cadastrados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Imposto> ObterTodos()
        {
            if (listaImpostos == null)
                listaImpostos = GetQuery().ToList();
            return listaImpostos;
        }

    }
}