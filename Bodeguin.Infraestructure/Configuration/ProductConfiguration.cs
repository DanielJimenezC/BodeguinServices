using Bodeguin.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Infraestructure.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn()
                .HasColumnName("id")
                .IsRequired();


            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(100)
                .HasColumnName("description")
                .IsRequired();

            builder.Property(p => p.UrlImage)
                .HasMaxLength(2500)
                .HasColumnName("url_image")
                .IsRequired();

            builder.Property(p => p.CategoryId)
                .HasColumnName("category_id")
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

            builder.HasOne<Category>(p => p.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
