using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Infrastructure.Repositories.AD2000Repositories;
using MVC.ProductManagement.Infrastructure.Repositories.EN13458Repositories;
using MVC.ProductManagement.Infrastructure.Repositories.CostingRepositories;
using MVC.ProductManagement.Infrastructure.Repositories.IAllowableStressRepository;
using MVC.ProductManagement.Infrastructure.Repositories.MaterialFormRepositories;
using MVC.ProductManagement.Infrastructure.Repositories.MaterialRepositories;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Common;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Catalog;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.S;
using MVC.ProductManagement.Infrastructure.Repositories.StorageTypeRepositories;
using MVC.ProductManagement.Infrastructure.Repositories.StorageTypePropertiesRepository;
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
            services.AddScoped<IAD2000Repository, AD2000Repository>();
            services.AddScoped<ICostSettingsRepository, CostSettingsRepository>();
            services.AddScoped<IStorageTypeRepositories, StorageTypeRepository>();
            services.AddScoped<IStorageTypePropertiesRepository, StorageTypePropertiesRepository>();
            services.AddScoped<IFluidRepositories, FluidRepository>();
            services.AddScoped<IStockCardRepositories, StockCardRepository>();
            services.AddScoped<ISProductRepositories, SProductRepository>();
            services.AddScoped<ISProductGroupRepositories, SProductGroupRepository>();
            services.AddScoped<IStockMainCodeGroupRepository, StockMainCodeGroupRepository>();
            services.AddScoped<IStockSubCodeGroupRepository, StockSubCodeGroupRepository>();
            services.AddScoped<IStockSubCodeRuleRepository, StockSubCodeRuleRepository>();
            services.AddScoped<IGeneratedStockCodeRepository, GeneratedStockCodeRepository>();
            services.AddScoped<IStockProductGroupRepository, StockProductGroupRepository>();
            services.AddScoped<IStockProductGroupItemRepository, StockProductGroupItemRepository>();




            AdminSeed.AdminSeedAsync(configuration).GetAwaiter().GetResult();

            return services;
        }


    }
}
