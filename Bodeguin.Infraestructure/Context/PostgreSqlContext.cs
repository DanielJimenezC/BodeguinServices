using Bodeguin.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Bodeguin.Infraestructure.Context
{
    public partial class PostgreSqlContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<Detail> Details { get; set; }

        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            /*builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new StoreConfiguration());
            builder.ApplyConfiguration(new PaymentTypeConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new InventoryConfiguration());
            builder.ApplyConfiguration(new VoucherConfiguration());
            builder.ApplyConfiguration(new DetailConfiguration());*/
        }
    }
}
