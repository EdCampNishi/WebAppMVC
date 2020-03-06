using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Data.Interfaces;

namespace WebApp.Data.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private Contexto _contexto;
        private Exception _erro = null;
        public Repositorio(Contexto contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<T> GetAll(Func<T, bool> predicate)
        {
            try
            {
                return _contexto.Set<T>().Where(predicate);
            }
            catch (Exception ex)
            {
                _erro = ex;
                return null;
            }
        }

        public T GetById(object id)
        {
            try
            {
                return _contexto.Set<T>().Find(id);
            }
            catch (Exception ex)
            {
                _erro = ex;
                return null;
            }
        }

        public void Adicionar(T entity)
        {
            try
            {
                _contexto.Set<T>().Add(entity);
            }
            catch(Exception ex)
            {
                _erro = ex;
            }
        }

        public void Editar(T entity)
        {
            try
            {
                _contexto.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
            catch(Exception ex)
            {
                _erro = ex;
            }
        }

        public void Remover(int id, T entity)
        {
            try
            {
                _contexto.Set<T>().Remove(_contexto.Set<T>().Find(id));
            }
            catch(Exception ex)
            {
                _erro = ex;
            }
        }
    }
}