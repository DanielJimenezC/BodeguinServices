using Bodeguin.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Infraestructure.Configuration
{
    public class PaymentTypeConfiguration : IEntityTypeConfiguration<PaymentType>
    {
        public void Configure(EntityTypeBuilder<PaymentType> builder)
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
