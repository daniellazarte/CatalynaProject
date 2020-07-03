using Catalyna.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;

namespace Catalyna.Infraestructure.Data.Configuration
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            //En esta seccion se mapean las entidades en el casod e que sean diferentes a sus nombres de tablas.
            //builder.ToTable("Articulo");
            //builder.Property(e => e.ArticleId)
            //      .HasColumnName("idArticulo");
        }
    }
}
