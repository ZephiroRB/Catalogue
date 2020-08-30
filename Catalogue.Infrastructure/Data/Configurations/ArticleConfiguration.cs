using Catalogue.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogue.Infrastructure.Data.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {


            builder.ToTable("articles");

            builder.HasIndex(e => e.Token)
                .HasName("index_articles_on_token");

            builder.HasIndex(e => e.UserId)
                .HasName("index_articles_on_user_id");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp(6) without time zone");

            builder.Property(e => e.Description).HasColumnName("description");

            builder.Property(e => e.Title)
                .HasColumnName("title")
                .HasColumnType("character varying");

            builder.Property(e => e.Token)
                .HasColumnName("token")
                .HasColumnType("character varying");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("timestamp(6) without time zone");

            builder.Property(e => e.UserId).HasColumnName("user_id");

            builder.HasOne(d => d.User)
                .WithMany(p => p.Article)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rails_3d31dad1cc");

        }
    }
}
