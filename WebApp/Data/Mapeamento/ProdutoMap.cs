using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Data.Mapeamento
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            ToTable("TB_PRODUTO");

            HasKey(x => x.Codigo);

            Property(x => x.Codigo).HasColumnName("PRD_CODIGO");
            Property(x => x.Nome).HasColumnName("PRD_NOME");
            Property(x => x.Descricao).HasColumnName("PRD_DESCRICAO");
            Property(x => x.Valor).HasColumnName("PRD_VALOR");
            Property(x => x.Categoria_Codigo).HasColumnName("PRD_CATEGORIA_CODIGO");

            HasRequired(x => x.Categoria)
                .WithMany(y => y.Produtos)
                .HasForeignKey(x => x.Categoria_Codigo);

        }
    }
}