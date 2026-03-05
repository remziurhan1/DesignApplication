using Microsoft.Extensions.DependencyInjection;
using MVC.ProductManagement.Application.Interfaces.Services;
using MVC.ProductManagement.Application.Services.AllowableStressServices;
using MVC.ProductManagement.Application.Services.Export;
using MVC.ProductManagement.Application.Services.IYieldStrengthServices;
using MVC.ProductManagement.Application.Services.MaterialFormServices;
using MVC.ProductManagement.Application.Services.MaterialServices;
using MVC.ProductManagement.Application.Services.StockCodes.Common;
using MVC.ProductManagement.Application.Services.StockCodes.S;
using MVC.ProductManagement.Application.Services.StockCodes.S.Features;
using MVC.ProductManagement.Application.Services.StockCodes.SA;
using MVC.ProductManagement.Application.Services.StockCodes.SB;
using MVC.ProductManagement.Application.Services.StockCodes.SC;
using MVC.ProductManagement.Application.Services.StockCodes.SD;
using MVC.ProductManagement.Application.Services.StockCodes.SE;
using MVC.ProductManagement.Application.Services.StockCodes.SF;
using MVC.ProductManagement.Application.Services.StockCodes.SG;
using MVC.ProductManagement.Application.Services.StockCodes.SH;
using MVC.ProductManagement.Application.Services.StockCodes.Rules;
using MVC.ProductManagement.Application.Services.StorageTypeServices;

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
            services.AddScoped<IStockCodeSaService, StockCodeSaService>();
            services.AddScoped<IStockCodeSbService, StockCodeSbService>();
            services.AddScoped<IStockCodeScService, StockCodeScService>();
            services.AddScoped<IStockCodeSdService, StockCodeSdService>();
            services.AddScoped<IStockCodeSeService, StockCodeSeService>();
            services.AddScoped<IStockCodeSfService, StockCodeSfService>();
            services.AddScoped<IStockCodeSgService, StockCodeSgService>();
            services.AddScoped<IStockCodeShService, StockCodeShService>();
            services.AddScoped<ISFeatureQueryService, SFeatureQueryService>();
            services.AddScoped<IStockCodeLookupService, StockCodeLookupService>();// ========== STOK KART MODÜL SERVİSLERİ ==========
            services.AddScoped<IStockRuleProfileService, StockRuleProfileService>();
            services.AddScoped<ISaRuleCatalogSyncService, SaRuleCatalogSyncService>();
            services.AddScoped<IStockCardDatasheetService, StockCardDatasheetService>();
            services.AddScoped<IStockCardPriceService, StockCardPriceService>();
            services.AddScoped<IStockCardInventoryService, StockCardInventoryService>();
            services.AddScoped<IStockCardGroupService, StockCardGroupService>();

            services.AddScoped<IExcelExportService, ExcelExportService>();



            


            return services;
        }
    }
}
