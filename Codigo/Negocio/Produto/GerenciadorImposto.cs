// -----------------------------------------------------------------------
// <copyright file="GerenciadorImpostos.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Negocio
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Dominio;
    using Dados;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class GerenciadorImposto
    {
        private static GerenciadorImposto gImpostos;
        private static List<Imposto> listaImpostos;


        public static GerenciadorImposto GetInstance()
        {
            if (gImpostos == null)
            {
                gImpostos = new GerenciadorImposto();
            }
            return gImpostos;
        }

        
        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<Imposto> GetQuery()
        {
            var repImposto = new RepositorioGenerico<tb_imposto>();
            var saceEntities = (SaceEntities)repImposto.ObterContexto();
            var query = from imposto in saceEntities.tb_imposto
                        select new Imposto
                        {
                            Ncmsh = imposto.NCMSH,
                            AliqNac = (decimal) imposto.aliqNac,
                            AliqImp = (decimal) imposto.aliqImp
                        };
            return query;
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
