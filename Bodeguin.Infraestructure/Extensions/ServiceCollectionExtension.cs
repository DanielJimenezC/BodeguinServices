using Bodeguin.Infraestructure.Context;
using Bodeguin.Infraestructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace Bodeguin.Infraestructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PostgreSqlContext>(options => 
                options.UseNpgsql(configuration.GetConnectionString("defaultConnection"))
            );
            return services;
        }

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PasswordOptions>(options => configuration.GetSection("PasswordOptions").Bind(options));
            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Bodeguin Api v1",
                    Contact = new OpenApiContact()
                    {
                        Name = "Bodeguin",
                        Email = "bodeguin@gmail.com"
                    },
                });
            });
            return services;
        }
    }
}
