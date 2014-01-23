using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data.Entity;

namespace Dados
{
    public interface IRepositorioGenerico<T>: IDisposable 
        where T: class
    {
        T Inserir(T entidade);
        void Remover(T entidade);
        void Remover(Func<T, Boolean> where);
        void Attach(T entity);
        T ObterPrimeiro(Func<T, Boolean> where);
        T ObterEntidade(Func<T, Boolean> where);
        IEnumerable<T> Obter(Func<T, Boolean> where);
        IEnumerable<T> ObterTodos();
        IQueryable<T> GetQueryable();
        ObjectContext ObterContexto();
        int SaveChanges();
        int SaveChanges(SaveOptions options);
    }
}
