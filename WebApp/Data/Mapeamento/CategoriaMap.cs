using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Data.Mapeamento
{
    public class CategoriaMap : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMap()
        {
            ToTable("TB_CATEGORIA");

            HasKey(x => x.Codigo);

            Property(x => x.Codigo).HasColumnName("CAT_CODIGO");
            Property(x => x.Nome).HasColumnName("CAT_NOME");
        }
    }
}