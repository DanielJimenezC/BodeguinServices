using Bodeguin.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Infraestructure.Configuration
{
    public class VoucherConfiguration : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn()
                .HasColumnName("id")
                .IsRequired();

            builder.Property(v => v.PaymentTypeId)
                .HasColumnName("payment_id")
                .IsRequired();

            builder.Property(v => v.UserId)
                .HasColumnName("user_id")
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

            builder.HasOne<PaymentType>(v => v.PaymentType)
                .WithMany(v => v.Vouchers)
                .HasForeignKey(v => v.PaymentTypeId);

            builder.HasOne<User>(v => v.User)
                .WithMany(v => v.Vouchers)
                .HasForeignKey(v => v.UserId);
        }
    }
}
