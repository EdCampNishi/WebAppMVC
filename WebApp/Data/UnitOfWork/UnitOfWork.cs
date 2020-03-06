using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Data.Interfaces;
using WebApp.Data.Repositorio;
using WebApp.Models;

namespace WebApp.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private Contexto contexto = new Contexto();
        private Exception _erro = null;
        private IRepositorio<Produto> produtoRepositorio;
        private IRepositorio<Categoria> categoriaRepositorio;

        public IRepositorio<Produto> ProdutoRepositorio
        {
            get
            {
                if (produtoRepositorio == null)
                {
                    produtoRepositorio = new Repositorio<Produto>(contexto);
                }
                return produtoRepositorio;
            }
        }

        public IRepositorio<Categoria> CategoriaRepositorio
        {
            get
            {
                if (categoriaRepositorio == null)
                {
                    categoriaRepositorio = new Repositorio<Categoria>(contexto);
                }
                return categoriaRepositorio;
            }
        }

        public void Commit()
        {
            try
            {
                contexto.SaveChanges();
            }
            catch(Exception ex)
            {
                _erro = ex;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    contexto.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public string MsgErro()
        {
            return _erro.Message;
        }
    }
}