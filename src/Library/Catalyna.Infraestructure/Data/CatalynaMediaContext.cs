using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Catalyna.Core.Entities;
//using Catalyna.Infraestructure.Data.Configurations;
//using SocialMedia.Infrastructure.Data.Configurations;


namespace Catalyna.Infraestructure.Data
{
    public partial class CatalynaMediaContext : DbContext
    {
        public CatalynaMediaContext() 
        {
            
        }

        public CatalynaMediaContext(DbContextOptions<CatalynaMediaContext> options)
            : base(options)
        {

        }
        
        //Tablas Virtuales
        public virtual DbSet<Article> Article { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Luego quedaria Asi cuando tenemos las configuraciones por clases separadas Fluente API
            //modelBuilder.ApplyConfiguration(new CommentConfiguration());
            //modelBuilder.ApplyConfiguration(new PostConfiguration());
            //modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
