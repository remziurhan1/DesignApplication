using MVC.ProductManagement.Domain.Entities.StockCodes.Catalog;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Infrastructure.DataAccess.EntityFramework;

namespace MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Catalog
{
    public class GeneratedStockCodeRepository : EFBaseRepository<GeneratedStockCode>, IGeneratedStockCodeRepository
    {
        public GeneratedStockCodeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
