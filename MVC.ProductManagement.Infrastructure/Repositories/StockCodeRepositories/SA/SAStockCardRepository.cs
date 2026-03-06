using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.AppContext;

namespace MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.SA
{
    public class SAStockCardRepository : ISAStockCardRepository
    {
        private readonly AppDbContext _context;

        public SAStockCardRepository(AppDbContext context)
        {
            _context = context;
        }

        // ========== Feature sorguları ==========

        public async Task<List<SFeature>> GetFeaturesByCodesAsync(IEnumerable<string> codes, CancellationToken cancellationToken = default)
        {
            return await _context.Set<SFeature>()
                .AsNoTracking()
                .Include(f => f.Values)
                .Where(f => codes.Contains(f.Code))
                .OrderBy(f => f.SortOrder)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<SFeatureValue>> GetFeatureValuesByFeatureIdAsync(Guid featureId, CancellationToken cancellationToken = default)
        {
            return await _context.Set<SFeatureValue>()
                .AsNoTracking()
                .Where(fv => fv.SFeatureId == featureId)
                .OrderBy(fv => fv.SortOrder)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<SFeature>> GetFeaturesByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
        {
            var idList = ids.ToList();
            return await _context.Set<SFeature>()
                .AsNoTracking()
                .Where(f => idList.Contains(f.Id))
                .ToListAsync(cancellationToken);
        }

        public async Task<List<SFeatureValue>> GetFeatureValuesByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
        {
            var idList = ids.ToList();
            return await _context.Set<SFeatureValue>()
                .AsNoTracking()
                .Where(v => idList.Contains(v.Id))
                .ToListAsync(cancellationToken);
        }

        public async Task<List<SFeature>> GetAllFeaturesOrderedAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<SFeature>()
                .AsNoTracking()
                .OrderBy(f => f.SortOrder)
                .ToListAsync(cancellationToken);
        }

        // ========== Kural sorguları ==========

        public async Task<List<SProductFeatureRule>> GetProductFeatureRulesAsync(Guid productId, CancellationToken cancellationToken = default)
        {
            return await _context.Set<SProductFeatureRule>()
                .AsNoTracking()
                .Where(r => r.SProductId == productId)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<SProductFeatureRule>> GetFixedProductFeatureRulesAsync(Guid productId, CancellationToken cancellationToken = default)
        {
            return await _context.Set<SProductFeatureRule>()
                .AsNoTracking()
                .Include(r => r.FixedValue)
                .Where(r => r.SProductId == productId)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<SFeatureValueRule>> GetFeatureValueRulesAsync(Guid productId, CancellationToken cancellationToken = default)
        {
            return await _context.Set<SFeatureValueRule>()
                .AsNoTracking()
                .Where(r => r.SProductId == productId)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<SFeatureValueRule>> GetFeatureValueRulesByFeatureAsync(Guid productId, Guid featureId, CancellationToken cancellationToken = default)
        {
            return await _context.Set<SFeatureValueRule>()
                .AsNoTracking()
                .Include(r => r.SFeatureValue)
                .Where(r => r.SProductId == productId && r.SFeatureId == featureId)
                .OrderBy(r => r.SortOrder)
                .ToListAsync(cancellationToken);
        }

        // ========== StockCard sorguları ==========

        public async Task<StockCard?> GetStockCardWithDetailsAsync(Guid stockCardId, CancellationToken cancellationToken = default)
        {
            return await _context.Set<StockCard>()
                .AsNoTracking()
                .Include(sc => sc.SProduct)
                .FirstOrDefaultAsync(sc => sc.Id == stockCardId && !sc.IsDeleted, cancellationToken);
        }

        public async Task<(List<StockCard> Items, int TotalCount)> GetFilteredStockCardsAsync(
            string? searchTerm, Guid? productId, DateTime? startDate, DateTime? endDate,
            int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var query = _context.Set<StockCard>()
                .AsNoTracking()
                .Include(sc => sc.SProduct)
                .Where(sc => !sc.IsDeleted);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var searchLower = searchTerm.ToLower().Trim();
                query = query.Where(sc =>
                    sc.StockCode8.ToLower().Contains(searchLower) ||
                    sc.Description.ToLower().Contains(searchLower) ||
                    sc.Prefix4.ToLower().Contains(searchLower));
            }

            if (productId.HasValue)
                query = query.Where(sc => sc.SProductId == productId.Value);

            if (startDate.HasValue)
                query = query.Where(sc => sc.CreatedDate >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(sc => sc.CreatedDate <= endDate.Value);

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderByDescending(sc => sc.CreatedDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return (items, totalCount);
        }

        // ========== StockCardFeatureSelection sorguları ==========

        public async Task<List<StockCardFeatureSelection>> GetFeatureSelectionsAsync(Guid stockCardId, CancellationToken cancellationToken = default)
        {
            return await _context.Set<StockCardFeatureSelection>()
                .AsNoTracking()
                .Where(sc => sc.StockCardId == stockCardId)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<StockCardFeatureSelection>> GetFeatureSelectionsWithDetailsAsync(Guid stockCardId, CancellationToken cancellationToken = default)
        {
            return await _context.Set<StockCardFeatureSelection>()
                .AsNoTracking()
                .Include(s => s.SFeature)
                .Include(s => s.SFeatureValue)
                .Where(s => s.StockCardId == stockCardId)
                .OrderBy(s => s.SFeature.SortOrder)
                .ToListAsync(cancellationToken);
        }

        // ========== Write işlemleri ==========

        public async Task DeleteFeatureSelectionsAsync(Guid stockCardId, CancellationToken cancellationToken = default)
        {
            await _context.Set<StockCardFeatureSelection>()
                .Where(fs => fs.StockCardId == stockCardId)
                .ExecuteDeleteAsync(cancellationToken);
        }

        public async Task AddFeatureSelectionsAsync(IEnumerable<StockCardFeatureSelection> selections, CancellationToken cancellationToken = default)
        {
            _context.Set<StockCardFeatureSelection>().AddRange(selections);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IDisposable> BeginTransactionAsync(CancellationToken cancellationToken = default)
            => await _context.Database.BeginTransactionAsync(cancellationToken);

        public async Task CommitTransactionAsync(IDisposable transaction, CancellationToken cancellationToken = default)
        {
            if (transaction is IDbContextTransaction tx)
                await tx.CommitAsync(cancellationToken);
        }

        public async Task RollbackTransactionAsync(IDisposable transaction, CancellationToken cancellationToken = default)
        {
            if (transaction is IDbContextTransaction tx)
                await tx.RollbackAsync(cancellationToken);
        }
    }
}
