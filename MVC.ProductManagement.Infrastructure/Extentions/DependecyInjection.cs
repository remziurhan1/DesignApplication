using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Infrastructure.Repositories.DesignStandardRepository;
using MVC.ProductManagement.Infrastructure.Repositories.EN13458Repositories;
using MVC.ProductManagement.Infrastructure.Repositories.GasTypeRepositories;
using MVC.ProductManagement.Infrastructure.Repositories.IAllowableStressRepository;
using MVC.ProductManagement.Infrastructure.Repositories.IProductCodeRepositories;
using MVC.ProductManagement.Infrastructure.Repositories.MaterialFormRepositories;
using MVC.ProductManagement.Infrastructure.Repositories.MaterialRepositories;
using MVC.ProductManagement.Infrastructure.Repositories.StorageTypeRepositories;
using MVC.ProductManagement.Infrastructure.Repositories.TankRequestRepositories;
using MVC.ProductManagement.Infrastructure.Repositories.YieldStrengthRepositories;
using MVC.ProductManagement.Infrastructure.Seeds;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Extentions
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseLazyLoadingProxies();
                opt.UseSqlServer(configuration.GetConnectionString("AppConnectionString"));
            });

            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<IMaterialFormRepository, MaterialFormRepository>();
            services.AddScoped<IYieldStrengthRepository, YieldStrengthRepository>();
            services.AddScoped<IAllowableStressRepository, AllowableStressRepository>();
            services.AddScoped<IEN13458Repository, EN13458Repository>();
            services.AddScoped<IStorageTypeRepositories, StorageTypeRepository>();
            services.AddScoped<ITankRequestRepository, TankRequestRepository>();
            services.AddScoped<IGasTypeRepository, GasTypeRepository>();
            services.AddScoped<IDesignStandardRepository, DesignStandardRepository>();
            services.AddScoped<IProductCodeRepository, ProductCodeRepository>();




            AdminSeed.AdminSeedAsync(configuration).GetAwaiter().GetResult();

            return services;
        }


    }
}
