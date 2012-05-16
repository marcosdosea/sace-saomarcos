using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;


namespace Negocio
{
    public interface IGerenciadorBanco: IGerenciadorNegocio<Dados.BancoE, Int32>
    {
        IEnumerable<Dados.BancoE> obterTodos();
        IQueryable<Dados.BancoE> GetDataSource();
    }
}
