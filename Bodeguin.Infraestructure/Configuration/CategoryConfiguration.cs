using Bodeguin.Domain.Entity;
using FluentValidation.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Infraestructure.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn()
                .HasColumnName("id")
                .IsRequired();

            builder.Property(c => c.Name)
                .HasMaxLength(100)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(c => c.Description)
                .HasMaxLength(100)
                .HasColumnName("description")
                .IsRequired();

            builder.Property(c => c.UrlImage)
                .HasMaxLength(2500)
                .HasColumnName("url_image")
                .IsRequired();

            builder.Property(t => t.Active)
                .HasColumnName("active")
                .IsRequired();

            builder.Property(t => t.CreateAt)
                .HasColumnName("create_at")
                .IsRequired();

            builder.Property(t => t.ModifiedAt)
                .HasColumnName("modified_at")
                .IsRequired();
        }
    }
}
