using AspNetCoreHero.ToastNotification;
using Microsoft.AspNetCore.Identity;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Presentation.Services.EN13458;

namespace MVC.ProductManagement.Presentation.Extentions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services)
        {
            services.AddNotyf(config =>
            {
                config.HasRippleEffect = true;
                config.DurationInSeconds = 3;
                config.Position = NotyfPosition.BottomRight;
                config.IsDismissable = true;
            });


            services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            services.AddScoped<IEN13458AdminExportService, EN13458AdminExportService>();
            services.AddScoped<IEN13458SpecificationExportService, EN13458SpecificationExportService>();

            return services;
        }
    }
}
