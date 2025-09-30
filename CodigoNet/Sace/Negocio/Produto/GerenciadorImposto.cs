using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public static class GerenciadorImposto
    {

        private static IEnumerable<Imposto> listaImpostos;

        /// <summary>
        /// Obtém todos os grupos cadastrados
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Imposto> ObterTodos()
        {
            if (listaImpostos == null)
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
                    listaImpostos = query.AsNoTracking().ToList();
                }
            }
            return listaImpostos;
        }

    }
}