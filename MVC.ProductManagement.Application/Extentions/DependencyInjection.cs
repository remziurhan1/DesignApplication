using Microsoft.Extensions.DependencyInjection;
using MVC.ProductManagement.Application.Interfaces.Services;
using MVC.ProductManagement.Application.Services.AllowableStressServices;
using MVC.ProductManagement.Application.Services.IYieldStrengthServices;
using MVC.ProductManagement.Application.Services.MaterialFormServices;
using MVC.ProductManagement.Application.Services.MaterialServices;
using MVC.ProductManagement.Application.Services.StockCodes.S;
using MVC.ProductManagement.Application.Services.StockCodes.S.Handlers;
using MVC.ProductManagement.Application.Services.StockCodes.SA;
using MVC.ProductManagement.Application.Services.StockCodes.SB;
using MVC.ProductManagement.Application.Services.StorageTypeServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Extentions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IMaterialFormService, MaterialFormService>();
            services.AddScoped<IYieldStrengthService, YieldStrengthService>();
            services.AddScoped<IAllowableStressService, AllowableStressService>();
            services.AddScoped<IStorageTypeService, StorageTypeService>();
            services.AddScoped<IStockCodeService, StockCodeService>();
            services.AddScoped<IStockCodeSaService, StockCodeSaService>();
            // Handlers
            services.AddScoped<ISStockCodeGroupHandler, SAStockCodeGroupHandler>();
            services.AddScoped<ISStockCodeGroupHandler, SFStockCodeGroupHandler>();
            services.AddScoped<IStockCodeSbService, StockCodeSbService>();
            services.AddScoped<ISStockCodeGroupHandler, SBStockCodeGroupHandler>();

            services.AddScoped<ISStockCodeGroupHandlerFactory, SStockCodeGroupHandlerFactory>();


            return services;
        }
    }
}
