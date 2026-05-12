using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.AppContext;

namespace MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Common;

public class StockCardInventoryRepository : IStockCardInventoryRepository
{
    private readonly AppDbContext _context;

    public StockCardInventoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<StockCard?> GetStockCardAsync(Guid stockCardId, bool tracking = true, CancellationToken cancellationToken = default)
    {
        var query = _context.Set<StockCard>().Where(sc => sc.Id == stockCardId && sc.Status != Status.Deleted);
        if (!tracking)
        {
            query = query.AsNoTracking();
        }

        return await query.FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<StockCardInventory?> GetLastMovementAsync(Guid stockCardId, CancellationToken cancellationToken = default)
    {
        return await _context.StockCardInventories
            .AsNoTracking()
            .Where(i => i.StockCardId == stockCardId && i.Status != Status.Deleted)
            .OrderByDescending(i => i.MovementDate)
            .ThenByDescending(i => i.CreatedDate)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<StockCardInventory>> GetLocationBalancesAsync(Guid stockCardId, CancellationToken cancellationToken = default)
    {
        return await _context.StockCardInventories
            .AsNoTracking()
            .Where(i => i.StockCardId == stockCardId && i.Status != Status.Deleted)
            .GroupBy(i => i.Location)
            .Select(g => new StockCardInventory
            {
                Location = g.Key,
                StockAfter = g.OrderByDescending(x => x.MovementDate).ThenByDescending(x => x.CreatedDate).Select(x => x.StockAfter).FirstOrDefault(),
                MovementDate = g.OrderByDescending(x => x.MovementDate).ThenByDescending(x => x.CreatedDate).Select(x => x.MovementDate).FirstOrDefault()
            })
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<StockCardInventory>> GetMovementsAsync(Guid stockCardId, DateTime? startDate = null, DateTime? endDate = null, CancellationToken cancellationToken = default)
    {
        var query = _context.StockCardInventories
            .AsNoTracking()
            .Include(i => i.StockCard)
            .Where(i => i.StockCardId == stockCardId && i.Status != Status.Deleted);

        if (startDate.HasValue)
        {
            query = query.Where(i => i.MovementDate >= startDate.Value);
        }

        if (endDate.HasValue)
        {
            query = query.Where(i => i.MovementDate <= endDate.Value);
        }

        return await query
            .OrderByDescending(i => i.MovementDate)
            .ThenByDescending(i => i.CreatedDate)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(StockCardInventory movement, CancellationToken cancellationToken = default)
    {
        await _context.StockCardInventories.AddAsync(movement, cancellationToken);
    }

    public async Task<bool> HasMovementsAsync(Guid stockCardId, CancellationToken cancellationToken = default)
    {
        return await _context.StockCardInventories
            .AnyAsync(i => i.StockCardId == stockCardId && i.Status != Status.Deleted, cancellationToken);
    }

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
