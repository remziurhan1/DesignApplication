using MVC.ProductManagement.Domain.Entities.StockCodes.Catalog;
using MVC.ProductManagement.Infrastructure.DataAccess.Interfaces;

namespace MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Catalog
{
    public interface IStockSubCodeGroupRepository : IAsyncRepository,
        IAsyncFindableRepository<StockSubCodeGroup>,
        IAsyncInsertableRepository<StockSubCodeGroup>,
        IAsyncQueryableRepository<StockSubCodeGroup>,
        IAsyncDeletableRepository<StockSubCodeGroup>,
        IAsyncUpdatebleRepository<StockSubCodeGroup>
    {
    }
}
