using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Data.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        IEnumerable<T> GetAll(Func<T, bool> predicate);
        T GetById(object id);
        void Adicionar(T entity);
        void Editar(T entity);
        void Remover(int id, T entity);
    }
}