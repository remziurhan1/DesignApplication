using MVC.ProductManagement.Domain.Entities.StockCodes.Catalog;
using MVC.ProductManagement.Infrastructure.DataAccess.Interfaces;

namespace MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Catalog
{
    public interface IStockProductGroupItemRepository : IAsyncRepository,
        IAsyncFindableRepository<StockProductGroupItem>,
        IAsyncInsertableRepository<StockProductGroupItem>,
        IAsyncQueryableRepository<StockProductGroupItem>,
        IAsyncDeletableRepository<StockProductGroupItem>,
        IAsyncUpdatebleRepository<StockProductGroupItem>
    {
    }
}
