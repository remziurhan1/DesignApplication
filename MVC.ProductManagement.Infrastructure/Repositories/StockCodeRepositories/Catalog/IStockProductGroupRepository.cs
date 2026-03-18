using MVC.ProductManagement.Domain.Entities.StockCodes.Catalog;
using MVC.ProductManagement.Infrastructure.DataAccess.Interfaces;

namespace MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Catalog
{
    public interface IStockProductGroupRepository : IAsyncRepository,
        IAsyncFindableRepository<StockProductGroup>,
        IAsyncInsertableRepository<StockProductGroup>,
        IAsyncQueryableRepository<StockProductGroup>,
        IAsyncDeletableRepository<StockProductGroup>,
        IAsyncUpdatebleRepository<StockProductGroup>
    {
    }
}
