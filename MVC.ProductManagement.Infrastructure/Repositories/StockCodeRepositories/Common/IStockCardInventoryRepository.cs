using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;

namespace MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Common;

public interface IStockCardInventoryRepository
{
    Task<StockCard?> GetStockCardAsync(Guid stockCardId, bool tracking = true, CancellationToken cancellationToken = default);
    Task<StockCardInventory?> GetLastMovementAsync(Guid stockCardId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<StockCardInventory>> GetLocationBalancesAsync(Guid stockCardId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<StockCardInventory>> GetMovementsAsync(Guid stockCardId, DateTime? startDate = null, DateTime? endDate = null, CancellationToken cancellationToken = default);
    Task AddAsync(StockCardInventory movement, CancellationToken cancellationToken = default);
    Task<bool> HasMovementsAsync(Guid stockCardId, CancellationToken cancellationToken = default);
    Task CommitAsync(CancellationToken cancellationToken = default);
}
