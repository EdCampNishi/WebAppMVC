using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebApp.Data.Mapeamento;
using WebApp.Models;

namespace WebApp.Data
{
    public class Contexto : DbContext
    {
        public Contexto() : base("Default")
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new ProdutoMap());
            modelBuilder.Configurations.Add(new CategoriaMap());
        }
    }
}