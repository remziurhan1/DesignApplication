using MVC.ProductManagement.Domain.Entities.StockCodes.Catalog;
using MVC.ProductManagement.Infrastructure.DataAccess.Interfaces;

namespace MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Catalog
{
    public interface IGeneratedStockCodeRepository : IAsyncRepository,
        IAsyncFindableRepository<GeneratedStockCode>,
        IAsyncInsertableRepository<GeneratedStockCode>,
        IAsyncQueryableRepository<GeneratedStockCode>,
        IAsyncDeletableRepository<GeneratedStockCode>,
        IAsyncUpdatebleRepository<GeneratedStockCode>
    {
    }
}
