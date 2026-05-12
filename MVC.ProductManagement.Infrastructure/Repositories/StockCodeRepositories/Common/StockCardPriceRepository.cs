using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.AppContext;

namespace MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Common;

public class StockCardPriceRepository : IStockCardPriceRepository
{
    private readonly AppDbContext _context;

    public StockCardPriceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<StockCardPrice?> GetActivePriceAsync(Guid stockCardId, string currency, DateTime today, CancellationToken cancellationToken = default)
    {
        return await _context.StockCardPrices
            .AsNoTracking()
            .Include(p => p.StockCard)
            .Where(p => p.StockCardId == stockCardId
                && (p.Currency ?? string.Empty).Trim().ToUpper() == currency
                && p.IsActive
                && p.Status != Status.Deleted
                && p.ValidFrom.Date <= today
                && (p.ValidTo == null || p.ValidTo.Value.Date >= today))
            .OrderByDescending(p => p.ValidFrom)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<StockCardPrice>> GetPriceHistoryAsync(Guid stockCardId, string currency, CancellationToken cancellationToken = default)
    {
        return await _context.StockCardPrices
            .AsNoTracking()
            .Include(p => p.StockCard)
            .Where(p => p.StockCardId == stockCardId
                && p.Status != Status.Deleted
                && (p.Currency ?? string.Empty).Trim().ToUpper() == currency)
            .OrderByDescending(p => p.CreatedDate)
            .ToListAsync(cancellationToken);
    }

    public async Task<StockCard?> GetStockCardAsync(Guid stockCardId, CancellationToken cancellationToken = default)
    {
        return await _context.Set<StockCard>()
            .FirstOrDefaultAsync(sc => sc.Id == stockCardId && sc.Status != Status.Deleted, cancellationToken);
    }

    public async Task<IReadOnlyList<StockCardPrice>> GetActivePricesAsync(Guid stockCardId, string currency, Guid? excludeId = null, CancellationToken cancellationToken = default)
    {
        return await _context.StockCardPrices
            .Where(p => p.StockCardId == stockCardId
                && (p.Currency ?? string.Empty).Trim().ToUpper() == currency
                && p.IsActive
                && (!excludeId.HasValue || p.Id != excludeId.Value)
                && p.Status != Status.Deleted)
            .ToListAsync(cancellationToken);
    }

    public async Task<StockCardPrice?> GetByIdAsync(Guid id, bool includeStockCard = false, bool includeDeleted = false, CancellationToken cancellationToken = default)
    {
        IQueryable<StockCardPrice> query = _context.StockCardPrices;
        if (includeStockCard)
        {
            query = query.Include(p => p.StockCard);
        }

        if (!includeDeleted)
        {
            query = query.Where(p => p.Status != Status.Deleted);
        }

        return await query.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<StockCardPrice?> GetPriceAtDateAsync(Guid stockCardId, string currency, DateTime atDate, CancellationToken cancellationToken = default)
    {
        return await _context.StockCardPrices
            .AsNoTracking()
            .Include(p => p.StockCard)
            .Where(p => p.StockCardId == stockCardId
                && (p.Currency ?? string.Empty).Trim().ToUpper() == currency
                && p.Status != Status.Deleted
                && p.ValidFrom.Date <= atDate
                && (p.ValidTo == null || p.ValidTo.Value.Date >= atDate))
            .OrderByDescending(p => p.ValidFrom)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task AddAsync(StockCardPrice price, CancellationToken cancellationToken = default)
    {
        await _context.StockCardPrices.AddAsync(price, cancellationToken);
    }

    public void Remove(StockCardPrice price)
    {
        _context.StockCardPrices.Remove(price);
    }

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
