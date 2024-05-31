﻿// -----------------------------------------------------------------------
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

        /// <summary>
        /// Calcula o valor do imposto de uma lista de produtos que será impressa na nota fiscal ou cupom fiscal
        /// </summary>
        /// <param name="listaSaidaProdutos"></param>
        /// <returns></returns>
        public List<SaidaProduto> CalcularValorImpostoProdutos(List<SaidaProduto> listaSaidaProdutos)
        {
            IEnumerable<Imposto> listaImpostos = ObterTodos(); ;
            foreach (SaidaProduto saidaProduto in listaSaidaProdutos)
            {
                Imposto imposto = listaImpostos.Where(imp => imp.Ncmsh.Equals(saidaProduto.Ncmsh)).ElementAtOrDefault(0);
                if (imposto != null)
                {
                    saidaProduto.ValorImposto = saidaProduto.SubtotalAVista * (decimal)imposto.AliqNac / 100;
                }
                else
                {
                    saidaProduto.ValorImposto = saidaProduto.SubtotalAVista * (decimal)0.35;
                }
            }
            return listaSaidaProdutos;
        }


    }
}
