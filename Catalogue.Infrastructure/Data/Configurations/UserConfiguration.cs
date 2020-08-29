using Catalogue.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(e => e.Token)
                    .HasName("UserToken")
                    .IsUnique();

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp(6) without time zone");

            builder.Property(e => e.Email)
                .HasColumnName("email")
                .HasMaxLength(255);

            builder.Property(e => e.Password)
                .HasColumnName("password")
                .HasMaxLength(255);

            builder.Property(e => e.Slug)
                .HasColumnName("slug")
                .HasMaxLength(255);

            builder.Property(e => e.Token)
                .IsRequired()
                .HasColumnName("token")
                .HasMaxLength(100);

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("timestamp(6) without time zone");

            builder.Property(e => e.Username)
                .HasColumnName("username")
                .HasMaxLength(255);
        }
    }
}
