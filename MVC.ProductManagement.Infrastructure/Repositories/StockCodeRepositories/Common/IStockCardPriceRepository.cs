using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;

namespace MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Common;

public interface IStockCardPriceRepository
{
    Task<StockCardPrice?> GetActivePriceAsync(Guid stockCardId, string currency, DateTime today, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<StockCardPrice>> GetPriceHistoryAsync(Guid stockCardId, string currency, CancellationToken cancellationToken = default);
    Task<StockCard?> GetStockCardAsync(Guid stockCardId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<StockCardPrice>> GetActivePricesAsync(Guid stockCardId, string currency, Guid? excludeId = null, CancellationToken cancellationToken = default);
    Task<StockCardPrice?> GetByIdAsync(Guid id, bool includeStockCard = false, bool includeDeleted = false, CancellationToken cancellationToken = default);
    Task<StockCardPrice?> GetPriceAtDateAsync(Guid stockCardId, string currency, DateTime atDate, CancellationToken cancellationToken = default);
    Task AddAsync(StockCardPrice price, CancellationToken cancellationToken = default);
    void Remove(StockCardPrice price);
    Task CommitAsync(CancellationToken cancellationToken = default);
}
