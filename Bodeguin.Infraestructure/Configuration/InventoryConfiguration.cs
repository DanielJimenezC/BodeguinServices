using Bodeguin.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Infraestructure.Configuration
{
    public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn()
                .HasColumnName("id")
                .IsRequired();

            builder.Property(i => i.Quantity)
                .HasColumnName("quantity")
                .IsRequired();

            builder.Property(i => i.Price)
                .HasColumnName("price")
                .IsRequired();

            builder.Property(i => i.MeasureUnit)
                .HasColumnName("measure_unit")
                .IsRequired();

            builder.Property(i => i.ProductId)
                .HasColumnName("product_id")
                .IsRequired();

            builder.Property(i => i.StoreId)
                .HasColumnName("store_id")
                .IsRequired();

            builder.Property(t => t.IsActive)
                .HasColumnName("is_active")
                .IsRequired();

            builder.Property(t => t.CreateAt)
                .HasColumnName("create_at")
                .IsRequired();

            builder.Property(t => t.ModifiedAt)
                .HasColumnName("modified_at")
                .IsRequired();

            builder.HasOne<Product>(i => i.Product)
                .WithMany(i => i.Inventories)
                .HasForeignKey(i => i.ProductId);

            builder.HasOne<Store>(i => i.Store)
                .WithMany(i => i.Inventories)
                .HasForeignKey(i => i.StoreId);
        }
    }
}
