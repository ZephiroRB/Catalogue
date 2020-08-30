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
            builder.ToTable("users");

            builder.HasIndex(e => e.Token)
                .HasName("index_users_on_token");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp(6) without time zone");

            builder.Property(e => e.Password)
                .HasColumnName("password")
                .HasColumnType("character varying");

            builder.Property(e => e.Token)
                .HasColumnName("token")
                .HasColumnType("character varying");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("timestamp(6) without time zone");

            builder.Property(e => e.Username)
                .HasColumnName("username")
                .HasColumnType("character varying");
        }
    }
}
