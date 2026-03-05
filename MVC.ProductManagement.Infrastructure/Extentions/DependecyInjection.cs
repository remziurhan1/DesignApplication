using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVC.ProductManagement.Application.Services.StockCodes.Common;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Infrastructure.Repositories.EN13458Repositories;
using MVC.ProductManagement.Infrastructure.Repositories.IAllowableStressRepository;
using MVC.ProductManagement.Infrastructure.Repositories.MaterialFormRepositories;
using MVC.ProductManagement.Infrastructure.Repositories.MaterialRepositories;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Common;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.S;
using MVC.ProductManagement.Application.Services.StockCodes.SA;
using MVC.ProductManagement.Application.Services.StockCodes.SA.Properties;
using MVC.ProductManagement.Application.Services.StockCodes.SB;
using MVC.ProductManagement.Application.Services.StockCodes.SC;
using MVC.ProductManagement.Application.Services.StockCodes.SD;
using MVC.ProductManagement.Application.Services.StockCodes.SE;
using MVC.ProductManagement.Application.Services.StockCodes.SF;
using MVC.ProductManagement.Application.Services.StockCodes.SG;
using MVC.ProductManagement.Application.Services.StockCodes.SH;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.SA;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.SA.Properties;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.SB;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.SC;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.SD;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.SE;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.SF;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.SG;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.SH;
using MVC.ProductManagement.Infrastructure.Repositories.StorageTypeRepositories;
using MVC.ProductManagement.Infrastructure.Repositories.YieldStrengthRepositories;
using MVC.ProductManagement.Infrastructure.Seeds;
using MVC.ProductManagement.Infrastructure.Services.StockCards;
using MVC.ProductManagement.Infrastructure.Services.StockCodes.S.Features;
using MVC.ProductManagement.Infrastructure.Services.StockCodes.Rules;
using MVC.ProductManagement.Infrastructure.Services.StockCodes.Common;
using MVC.ProductManagement.Application.Services.StockCodes.S.Features;
using MVC.ProductManagement.Application.Services.StockCodes.Rules;
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
            services.AddScoped<IFluidRepositories, FluidRepository>();
            services.AddScoped<ISProductGroupRepositories, SProductGroupRepository>();
            services.AddScoped<ISProductRepositories, SProductRepository>();
            services.AddScoped<ISAssemblyGroupRepositories, SAssemblyGroupRepository>();
            services.AddScoped<IPrefixRuleRepositories, PrefixRuleRepository>();
            services.AddScoped<IStockSequenceRepositories, StockSequenceRepository>();
            services.AddScoped<IStockCardRepositories, StockCardRepository>();
            services.AddScoped<IStockCardGroupRepository, StockCardGroupRepository>();
            services.AddScoped<IStockCodeSaRepository, StockCodeSaRepository>();
            services.AddScoped<IStockCodeSaPropertyRepository, StockCodeSaPropertyRepository>();




            AdminSeed.AdminSeedAsync(configuration).GetAwaiter().GetResult();

            return services;
        }


    }
}
