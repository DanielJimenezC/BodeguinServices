using Bodeguin.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Infraestructure.Configuration
{
    public class DetailConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn()
                .HasColumnName("id")
                .IsRequired();

            builder.Property(d => d.Discount)
                .HasColumnName("discount")
                .IsRequired();

            builder.Property(d => d.Price)
                .HasColumnName("price")
                .IsRequired();

            builder.Property(d => d.Quantity)
                .HasColumnName("quantity")
                .IsRequired();

            builder.Property(d => d.ProductId)
                .HasColumnName("producto_id")
                .IsRequired();

            builder.Property(d => d.VoucherId)
                .HasColumnName("voucher_id")
                .IsRequired();

            builder.HasOne<Product>(d => d.Product)
                .WithMany(d => d.Details)
                .HasForeignKey(d => d.ProductId);

            builder.HasOne<Voucher>(d => d.Voucher)
                .WithMany(d => d.Details)
                .HasForeignKey(d => d.VoucherId);
        }
    }
}
