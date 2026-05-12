using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.AppContext;

namespace MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Common;

public class StockCardDatasheetRepository : IStockCardDatasheetRepository
{
    private readonly AppDbContext _context;

    public StockCardDatasheetRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<StockCardDatasheet>> GetByStockCardAsync(Guid stockCardId, CancellationToken cancellationToken = default)
    {
        return await _context.StockCardDatasheets
            .AsNoTracking()
            .Include(d => d.StockCard)
            .Where(d => d.StockCardId == stockCardId && d.Status != Status.Deleted)
            .OrderByDescending(d => d.Version)
            .ThenByDescending(d => d.CreatedDate)
            .ToListAsync(cancellationToken);
    }

    public async Task<StockCardDatasheet?> GetByIdAsync(Guid id, bool tracking = true, CancellationToken cancellationToken = default)
    {
        var query = _context.StockCardDatasheets
            .Include(d => d.StockCard)
            .Where(d => d.Id == id && d.Status != Status.Deleted);

        if (!tracking)
        {
            query = query.AsNoTracking();
        }

        return await query.FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<StockCard?> GetStockCardAsync(Guid stockCardId, CancellationToken cancellationToken = default)
    {
        return await _context.Set<StockCard>()
            .FirstOrDefaultAsync(sc => sc.Id == stockCardId && sc.Status != Status.Deleted, cancellationToken);
    }

    public async Task<int> GetLastVersionAsync(Guid stockCardId, CancellationToken cancellationToken = default)
    {
        return await _context.StockCardDatasheets
            .Where(d => d.StockCardId == stockCardId)
            .MaxAsync(d => (int?)d.Version, cancellationToken) ?? 0;
    }

    public async Task AddAsync(StockCardDatasheet datasheet, CancellationToken cancellationToken = default)
    {
        await _context.StockCardDatasheets.AddAsync(datasheet, cancellationToken);
    }

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
