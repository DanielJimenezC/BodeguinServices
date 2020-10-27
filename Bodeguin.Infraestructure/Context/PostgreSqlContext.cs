using Bodeguin.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
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
            var date = DateTime.Now;
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            
            builder.Entity<User>().HasData(
                new User { Id = 1, IsActive = true, CreateAt = date, ModifiedAt = date, Name = "Daniel", FirstLastName = "Jimenez", SecondLastName = "Canales", Dni = "72183382", Direction = "Calle Ciro Alegria Mz K Lote 20", Email = "danieljimenezcanales@gmail.com", Password = "g2Ix3bIy9j6NrGf7zJm1Mg==", IsAdmin = false }
                );

            builder.Entity<Category>().HasData(
                new Category { Id = 1, IsActive = true, CreateAt = date, ModifiedAt = date, Name = "Verduras", Description = "Verduras", UrlImage = "https://www.saccosystem.com/public/imgCat2/big/100.jpg" },
                new Category { Id = 2, IsActive = true, CreateAt = date, ModifiedAt = date, Name = "Carnes y Pollos", Description = "Carnes y Pollos", UrlImage = "https://images.jumpseller.com/store/eks-delivery/4918843/carnes-int.jpg" },
                new Category { Id = 3, IsActive = true, CreateAt = date, ModifiedAt = date, Name = "Pescados y Mariscos", Description = "Pescados y Mariscos", UrlImage = "https://c6f2y5q5.rocketcdn.me/wp-content/uploads/2017/08/proveedores-de-pescado-y-marisco-1280x640.jpg" }
                );

            builder.Entity<Product>().HasData(
                new Product { Id = 1, IsActive = true, CreateAt = date, ModifiedAt = date, Name = "Manzana", Description = "Manzana", UrlImage = "https://estaticos.miarevista.es/media/cache/1140x_thumb/uploads/images/article/5e53c4125bafe801dabfb62f/comer-semillas-manzana.jpg", CategoryId = 1 },
                new Product { Id = 2, IsActive = true, CreateAt = date, ModifiedAt = date, Name = "Lechuga", Description = "Lechuga", UrlImage = "https://static3.abc.es/media/bienestar/2020/09/01/lechuga-k7y--1024x512@abc.jpg", CategoryId = 1 },
                new Product { Id = 3, IsActive = true, CreateAt = date, ModifiedAt = date, Name = "Pollo", Description = "Pollo", UrlImage = "https://www.rebanando.com/cache/slideshow/31/72/02/e6/pollo1.jpg/2cb6823c975ee09b0d93e071c71c86d5.jpg", CategoryId = 2 },
                new Product { Id = 4, IsActive = true, CreateAt = date, ModifiedAt = date, Name = "Camarones", Description = "Camarones", UrlImage = "https://img.vixdata.io/pd/jpg-large/es/sites/default/files/imj/elgranchef/C/Camarones-florentinos-3.jpg", CategoryId = 3 }
                );

            builder.Entity<Store>().HasData(
                new Store { Id = 1, IsActive = true, CreateAt = date, ModifiedAt = date, Name = "Bodeguita Martinez", Ruc = "20451798452", Latitude = -12.113699, Longitude = -77.028982, Direction = "Av. Angamos 205", Description = "Bodega Familiar" },
                new Store { Id = 2, IsActive = true, CreateAt = date, ModifiedAt = date, Name = "Don Pedrito", Ruc = "10684751482", Latitude = -12.111534, Longitude = -77.028904, Direction = "Calle Lizardo Montero 299", Description = "Bodega Familiar" }
                );

            builder.Entity<Inventory>().HasData(
                new Inventory { Id = 1, IsActive = true, CreateAt = date, ModifiedAt = date, Quantity = 20, Price = 2.50f, MeasureUnit = 3, ProductId = 1, StoreId = 1 },
                new Inventory { Id = 2, IsActive = true, CreateAt = date, ModifiedAt = date, Quantity = 18, Price = 2.20f, MeasureUnit = 3, ProductId = 1, StoreId = 2 },
                new Inventory { Id = 3, IsActive = true, CreateAt = date, ModifiedAt = date, Quantity = 5, Price = 1.80f, MeasureUnit = 1, ProductId = 2, StoreId = 1 },
                new Inventory { Id = 4, IsActive = true, CreateAt = date, ModifiedAt = date, Quantity = 1, Price = 1.50f, MeasureUnit = 1, ProductId = 2, StoreId = 2 },
                new Inventory { Id = 5, IsActive = true, CreateAt = date, ModifiedAt = date, Quantity = 12, Price = 8.90f, MeasureUnit = 3, ProductId = 3, StoreId = 1 },
                new Inventory { Id = 6, IsActive = true, CreateAt = date, ModifiedAt = date, Quantity = 5, Price = 14.20f, MeasureUnit = 3, ProductId = 4, StoreId = 1 },
                new Inventory { Id = 7, IsActive = true, CreateAt = date, ModifiedAt = date, Quantity = 12, Price = 17.80f, MeasureUnit = 3, ProductId = 4, StoreId = 2 }
                );

            builder.Entity<PaymentType>().HasData(
                new PaymentType { Id = 1, IsActive = true, CreateAt = date, ModifiedAt = date, Name = "Efectivo" },
                new PaymentType { Id = 2, IsActive = true, CreateAt = date, ModifiedAt = date, Name = "Tarjeta de Crédito/Débito" }
                );
        }
    }
}
