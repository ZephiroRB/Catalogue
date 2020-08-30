using System;
using Catalogue.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Catalogue.Core.Entities;

namespace Catalogue.Infrastructure.Data
{
    public partial class CatalogueContext : DbContext
    {
        public CatalogueContext()
        {
        }

        public CatalogueContext(DbContextOptions<CatalogueContext> options)
            : base(options)
        {
        }
   
        public virtual DbSet<Article> Article { get; set; }
       
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
