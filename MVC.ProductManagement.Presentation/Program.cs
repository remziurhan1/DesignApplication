using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Infrastructure.Extentions;
using MVC.ProductManagement.Application.Extentions;
using MVC.ProductManagement.Application.Services.StockCodes.Rules;
using MVC.ProductManagement.Presentation.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddPresentationServices();
var app = builder.Build();

// Uygulama açılışında bekleyen migration'ları uygula
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await dbContext.Database.MigrateAsync();
}

// SA kural kataloğunu runtime'da senkronize et (HasData migration şişmesini azaltmak için)
using (var scope = app.Services.CreateScope())
{
    var saCatalogSync = scope.ServiceProvider.GetRequiredService<ISaRuleCatalogSyncService>();
    await saCatalogSync.SyncAsync();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapDefaultControllerRoute();

app.Run();
