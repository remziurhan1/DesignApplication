using MVC.ProductManagement.Domain.Entities.StockCodes.Catalog;
using MVC.ProductManagement.Infrastructure.DataAccess.Interfaces;

namespace MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Catalog
{
    public interface IStockSubCodeRuleRepository : IAsyncRepository,
        IAsyncFindableRepository<StockSubCodeRule>,
        IAsyncInsertableRepository<StockSubCodeRule>,
        IAsyncQueryableRepository<StockSubCodeRule>,
        IAsyncDeletableRepository<StockSubCodeRule>,
        IAsyncUpdatebleRepository<StockSubCodeRule>
    {
    }
}
