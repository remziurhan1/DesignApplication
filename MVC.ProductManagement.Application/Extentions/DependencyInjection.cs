using Microsoft.Extensions.DependencyInjection;
using MVC.ProductManagement.Application.Interfaces.Services;
using MVC.ProductManagement.Application.Services.AD2000CalculationServices;
using MVC.ProductManagement.Application.Services.AllowableStressServices;
using MVC.ProductManagement.Application.Services.EN13458CalculationServices;
using MVC.ProductManagement.Application.Services.EN13458.CalculationSteps;
using MVC.ProductManagement.Application.Services.EN13458.Engines;
using MVC.ProductManagement.Application.Services.EN13458.Interfaces;
using MVC.ProductManagement.Application.Services.EN13458.Managers;
using MVC.ProductManagement.Application.Services.EN13458.MaterialAdapter;
using MVC.ProductManagement.Application.Services.Export;
using MVC.ProductManagement.Application.Services.IYieldStrengthServices;
using MVC.ProductManagement.Application.Services.MaterialFormServices;
using MVC.ProductManagement.Application.Services.MaterialServices;
using MVC.ProductManagement.Application.Services.StockCodes.Common;
using MVC.ProductManagement.Application.Services.StockCodes.Catalog;
using MVC.ProductManagement.Application.Services.StorageTypeServices;
using MVC.ProductManagement.Infrastructure.Services.StockCards;
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
            services.AddScoped<IAD2000CalculationService, AD2000CalculationService>();
            services.AddScoped<IEN13458CalculationServices, EN13458CalculationServices>();
            services.AddScoped<IEN13458MaterialStrengthProvider, EN13458MaterialStrengthProvider>();
            services.AddScoped<IEN13458CalculationManager, EN13458CalculationManager>();
            services.AddScoped<ICryogenicsCalculationEngine, EN13458CalculationEngine>();
            services.AddScoped<IEN13458CalculationStep, PressureStep>();
            services.AddScoped<IEN13458CalculationStep, ShellThicknessStep>();
            services.AddScoped<IEN13458CalculationStep, HeadThicknessStep>();
            services.AddScoped<IEN13458CalculationStep, VolumeStep>();
            services.AddScoped<IEN13458CalculationStep, SurfaceAreaStep>();
            services.AddScoped<IEN13458CalculationStep, WeightStep>();
            services.AddScoped<IEN13458CalculationStep, WeldFilmPerliteStep>();
            services.AddScoped<IEN13458CalculationStep, ExternalBucklingStep>();
            services.AddScoped<IEN13458CalculationStep, GasAndLiquidNitrogenStep>();
            services.AddScoped<IEN13458CalculationStep, TankLengthStep>();
            services.AddScoped<IStockCodeLookupService, StockCodeLookupService>();// ========== STOK KART MODÜL SERVİSLERİ ==========
            services.AddScoped<IStockCardDatasheetService, StockCardDatasheetService>();
            services.AddScoped<IStockCardPriceService, StockCardPriceService>();
            services.AddScoped<IStockCardInventoryService, StockCardInventoryService>();
            services.AddScoped<IStockMainCodeGroupService, StockMainCodeGroupService>();
            services.AddScoped<IStockSubCodeGroupService, StockSubCodeGroupService>();
            services.AddScoped<IStockSubCodeRuleService, StockSubCodeRuleService>();
            services.AddScoped<IGeneratedStockCodeService, GeneratedStockCodeService>();

            //services.AddScoped<IExcelExportService, ExcelExportService>();



            return services;
        }
    }
}
