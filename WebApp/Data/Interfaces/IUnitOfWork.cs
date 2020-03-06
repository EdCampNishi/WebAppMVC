using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
        IRepositorio<Produto> ProdutoRepositorio { get; }
        IRepositorio<Categoria> CategoriaRepositorio { get; }
        void Dispose();
        string MsgErro();
    }
}