using MVC.ProductManagement.Domain.Entities.StockCodes.Catalog;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Infrastructure.DataAccess.EntityFramework;

namespace MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Catalog
{
    public class StockMainCodeGroupRepository : EFBaseRepository<StockMainCodeGroup>, IStockMainCodeGroupRepository
    {
        public StockMainCodeGroupRepository(AppDbContext context) : base(context)
        {
        }
    }
}
