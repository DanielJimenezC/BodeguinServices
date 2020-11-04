using Bodeguin.Application.Interface;
using Bodeguin.Application.Security.JsonWebToken;
using Bodeguin.Application.Service;
using Bodeguin.Domain.Entity;
using Bodeguin.Domain.Interface;
using Bodeguin.Infraestructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Infraestructure.Extensions
{
    public class DependencyInjection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IJWTFactory, JWTFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IRepository<Category, int>, GenericRepository<Category, int>>();
            services.AddScoped<IRepository<Detail, int>, GenericRepository<Detail, int>>();
            services.AddScoped<IRepository<Inventory, int>, GenericRepository<Inventory, int>>();
            services.AddScoped<IRepository<PaymentType, int>, GenericRepository<PaymentType, int>>();
            services.AddScoped<IRepository<Product, int>, GenericRepository<Product, int>>();
            services.AddScoped<IRepository<Store, int>, GenericRepository<Store, int>>();
            services.AddScoped<IRepository<User, int>, GenericRepository<User, int>>();
            services.AddScoped<IRepository<Voucher, int>, GenericRepository<Voucher, int>>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IDetailRepository, DetailRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IVoucherRepository, VoucherRepository>();

            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IShopService, ShopService>();
        }
    }
}
