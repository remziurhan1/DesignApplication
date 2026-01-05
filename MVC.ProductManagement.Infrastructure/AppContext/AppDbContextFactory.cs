using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.AppContext
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // Design-time connection string
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(
                "Data Source=DIZAYN-REMZI\\MSSQLSERVER02;" +
                "Initial Catalog=dap34;" +
                "Integrated Security=True;" +
                "Encrypt=False;" +
                "TrustServerCertificate=True;"
            );

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
