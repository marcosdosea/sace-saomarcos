using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public static class GerenciadorImposto
    {

        private static List<Imposto> listaImpostos;

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private static IQueryable<Imposto> GetQuery()
        {
            using (var context = new SaceContext())
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
        }

        /// <summary>
        /// Obtém todos os grupos cadastrados
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Imposto> ObterTodos()
        {
            if (listaImpostos == null)
                listaImpostos = GetQuery().ToList();
            return listaImpostos;
        }

    }
}