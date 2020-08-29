using Catalogue.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.Infrastructure.Data.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasIndex(e => e.Token)
                    .HasName("ArticleToken")
                    .IsUnique();

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp(6) without time zone");

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasMaxLength(255);

            builder.Property(e => e.Slug)
                .HasColumnName("slug")
                .HasMaxLength(255);

            builder.Property(e => e.Title)
                .HasColumnName("title")
                .HasMaxLength(255);

            builder.Property(e => e.Token)
                .IsRequired()
                .HasColumnName("token")
                .HasMaxLength(100);

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("timestamp(6) without time zone");

            builder.Property(e => e.UserId).HasColumnName("userId");

            builder.HasOne(d => d.User)
                .WithMany(p => p.Article)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("ArticleUsers");

        }
    }
}
