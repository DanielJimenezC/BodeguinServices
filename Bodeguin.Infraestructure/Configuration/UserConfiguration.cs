using Bodeguin.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Infraestructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn()
                .HasColumnName("id")
                .IsRequired();

            builder.Property(u => u.Name)
                .HasMaxLength(50)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(u => u.FirstLastName)
                .HasMaxLength(50)
                .HasColumnName("first_lastname")
                .IsRequired();

            builder.Property(u => u.SecondLastName)
                .HasMaxLength(50)
                .HasColumnName("second_lastname")
                .IsRequired();

            builder.Property(u => u.Direction)
                .HasMaxLength(200)
                .HasColumnName("direction")
                .IsRequired();

            builder.Property(u => u.Dni)
                .HasMaxLength(100)
                .HasColumnName("dni")
                .IsRequired();

            builder.Property(u => u.Email)
                .HasMaxLength(50)
                .HasColumnName("email")
                .IsRequired();

            builder.Property(u => u.Password)
                .HasMaxLength(200)
                .HasColumnName("password")
                .IsRequired();

            builder.Property(u => u.IsAdmin)
                .HasColumnName("is_admin")
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
