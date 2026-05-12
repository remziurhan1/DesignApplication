using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;

namespace MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Common;

public interface IStockCardDatasheetRepository
{
    Task<IReadOnlyList<StockCardDatasheet>> GetByStockCardAsync(Guid stockCardId, CancellationToken cancellationToken = default);
    Task<StockCardDatasheet?> GetByIdAsync(Guid id, bool tracking = true, CancellationToken cancellationToken = default);
    Task<StockCard?> GetStockCardAsync(Guid stockCardId, CancellationToken cancellationToken = default);
    Task<int> GetLastVersionAsync(Guid stockCardId, CancellationToken cancellationToken = default);
    Task AddAsync(StockCardDatasheet datasheet, CancellationToken cancellationToken = default);
    Task CommitAsync(CancellationToken cancellationToken = default);
}
