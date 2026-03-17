using MVC.ProductManagement.Domain.Entities.StockCodes.Catalog;
using MVC.ProductManagement.Infrastructure.DataAccess.Interfaces;

namespace MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Catalog
{
    public interface IStockMainCodeGroupRepository : IAsyncRepository,
        IAsyncFindableRepository<StockMainCodeGroup>,
        IAsyncInsertableRepository<StockMainCodeGroup>,
        IAsyncQueryableRepository<StockMainCodeGroup>,
        IAsyncDeletableRepository<StockMainCodeGroup>,
        IAsyncUpdatebleRepository<StockMainCodeGroup>
    {
    }
}
