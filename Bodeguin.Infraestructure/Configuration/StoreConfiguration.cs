using Bodeguin.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bodeguin.Infraestructure.Configuration
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn()
                .HasColumnName("id")
                .IsRequired();

            builder.Property(s => s.Name)
                .HasMaxLength(100)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(s => s.Ruc)
                .HasMaxLength(11)
                .HasColumnName("ruc")
                .IsRequired();

            builder.Property(s => s.Latitude)
                .HasColumnName("latitude")
                .IsRequired();

            builder.Property(s => s.Longitude)
                .HasColumnName("longitude")
                .IsRequired();

            builder.Property(s => s.Direction)
                .HasMaxLength(100)
                .HasColumnName("direction")
                .IsRequired();

            builder.Property(s => s.Description)
                .HasMaxLength(100)
                .HasColumnName("description")
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
