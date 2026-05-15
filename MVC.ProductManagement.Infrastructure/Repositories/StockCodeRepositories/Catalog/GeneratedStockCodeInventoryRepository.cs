using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.StockCodes.Catalog;
using MVC.ProductManagement.Infrastructure.AppContext;

namespace MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Catalog;

public class GeneratedStockCodeInventoryRepository : IGeneratedStockCodeInventoryRepository
{
    private readonly AppDbContext _context;

    public GeneratedStockCodeInventoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IDictionary<Guid, int>> GetCurrentStocksAsync(IEnumerable<Guid> generatedStockCodeIds)
    {
        var ids = generatedStockCodeIds.Distinct().ToList();
        return await _context.GeneratedStockCodeInventoryMovements
            .AsNoTracking()
            .Where(x => ids.Contains(x.GeneratedStockCodeId))
            .GroupBy(x => x.GeneratedStockCodeId)
            .Select(g => new
            {
                GeneratedStockCodeId = g.Key,
                CurrentStock = g.OrderByDescending(x => x.MovementDate).ThenByDescending(x => x.CreatedDate).Select(x => x.StockAfter).FirstOrDefault()
            })
            .ToDictionaryAsync(x => x.GeneratedStockCodeId, x => x.CurrentStock);
    }

    public async Task<IReadOnlyList<Guid>> GetSelectedRuleIdsAsync(Guid generatedStockCodeId)
    {
        return await _context.GeneratedStockCodeRuleSelections
            .AsNoTracking()
            .Where(x => x.GeneratedStockCodeId == generatedStockCodeId)
            .Select(x => x.StockSubCodeRuleId)
            .ToListAsync();
    }

    public async Task ReplaceRuleSelectionsAsync(Guid generatedStockCodeId, IEnumerable<Guid> selectedRuleIds)
    {
        var selectedRuleIdSet = selectedRuleIds
            .Where(x => x != Guid.Empty)
            .ToHashSet();

        var existing = await _context.GeneratedStockCodeRuleSelections
            .Where(x => x.GeneratedStockCodeId == generatedStockCodeId)
            .ToListAsync();

        var obsoleteRows = existing
            .Where(x => !selectedRuleIdSet.Contains(x.StockSubCodeRuleId))
            .ToList();

        if (obsoleteRows.Any())
        {
            _context.GeneratedStockCodeRuleSelections.RemoveRange(obsoleteRows);
        }

        var existingRuleIdSet = existing
            .Select(x => x.StockSubCodeRuleId)
            .ToHashSet();

        var rows = selectedRuleIdSet
            .Where(ruleId => !existingRuleIdSet.Contains(ruleId))
            .Select(ruleId => new GeneratedStockCodeRuleSelection
            {
                GeneratedStockCodeId = generatedStockCodeId,
                StockSubCodeRuleId = ruleId
            })
            .ToList();

        if (rows.Any())
        {
            await _context.GeneratedStockCodeRuleSelections.AddRangeAsync(rows);
        }
    }

    public async Task<IReadOnlyList<GeneratedStockCodeInventoryMovement>> GetMovementsAsync(Guid generatedStockCodeId)
    {
        return await _context.GeneratedStockCodeInventoryMovements
            .AsNoTracking()
            .Include(x => x.StockProductGroup)
            .Where(x => x.GeneratedStockCodeId == generatedStockCodeId)
            .OrderByDescending(x => x.MovementDate)
            .ThenByDescending(x => x.CreatedDate)
            .ToListAsync();
    }

    public async Task<int> GetLastStockAsync(Guid generatedStockCodeId)
    {
        return await _context.GeneratedStockCodeInventoryMovements
            .AsNoTracking()
            .Where(x => x.GeneratedStockCodeId == generatedStockCodeId)
            .OrderByDescending(x => x.MovementDate)
            .ThenByDescending(x => x.CreatedDate)
            .Select(x => x.StockAfter)
            .FirstOrDefaultAsync();
    }

    public async Task AddMovementAsync(GeneratedStockCodeInventoryMovement movement)
    {
        await _context.GeneratedStockCodeInventoryMovements.AddAsync(movement);
    }

    public async Task<string?> GetStockProductGroupNameAsync(Guid stockProductGroupId)
    {
        return await _context.StockProductGroups
            .AsNoTracking()
            .Where(x => x.Id == stockProductGroupId)
            .Select(x => x.Name)
            .FirstOrDefaultAsync();
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}
