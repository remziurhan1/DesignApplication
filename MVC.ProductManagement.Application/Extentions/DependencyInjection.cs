using Microsoft.Extensions.DependencyInjection;
using MVC.ProductManagement.Application.Interfaces.Services;
using MVC.ProductManagement.Application.Services.AllowableStressServices;
using MVC.ProductManagement.Application.Services.IYieldStrengthServices;
using MVC.ProductManagement.Application.Services.MaterialFormServices;
using MVC.ProductManagement.Application.Services.MaterialServices;
using MVC.ProductManagement.Application.Services.StorageTypeServices;
using MVC.ProductManagement.Application.Services.TankRequestServices;
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
            services.AddScoped<ITankRequestService, TankRequestService>();


            return services;
        }
    }
}
