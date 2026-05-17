using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Domain.Entities.MaterialCatalog;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.AppContext;

namespace MVC.ProductManagement.Infrastructure.Repositories.MaterialCatalogRepositories
{
    public class MaterialCatalogRepository : IMaterialCatalogRepository
    {
        private readonly AppDbContext _context;

        public MaterialCatalogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<MaterialFamily>> GetMaterialFamiliesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.MaterialFamilies
                .AsNoTracking()
                .Where(x => x.Status != Status.Deleted && x.IsActive)
                .OrderBy(x => x.Name)
                .ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<MaterialForm>> GetMaterialFormsByFamilyAsync(Guid materialFamilyId, CancellationToken cancellationToken = default)
        {
            var forms = await _context.MaterialStandards
                .AsNoTracking()
                .Include(x => x.MaterialForm)
                .Where(x => x.MaterialFamilyId == materialFamilyId
                    && x.Status != Status.Deleted
                    && x.IsActive
                    && x.MaterialForm.Status != Status.Deleted)
                .Select(x => x.MaterialForm)
                .ToListAsync(cancellationToken);

            return forms
                .GroupBy(x => x.Id)
                .Select(x => x.First())
                .OrderBy(x => x.Name ?? x.FormType.ToString())
                .ToList();
        }

        public async Task<IReadOnlyList<MaterialStandard>> GetMaterialStandardsAsync(Guid materialFamilyId, Guid materialFormId, CancellationToken cancellationToken = default)
        {
            return await _context.MaterialStandards
                .AsNoTracking()
                .Where(x => x.MaterialFamilyId == materialFamilyId
                    && x.MaterialFormId == materialFormId
                    && x.Status != Status.Deleted
                    && x.IsActive)
                .OrderBy(x => x.StandardCode)
                .ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<Material>> GetMaterialsAsync(Guid materialFamilyId, Guid materialFormId, Guid materialStandardId, CancellationToken cancellationToken = default)
        {
            var directMatches = await _context.Materials
                .AsNoTracking()
                .Include(x => x.MaterialFamily)
                .Include(x => x.MaterialForm)
                .Include(x => x.MaterialStandard)
                .Where(x => x.MaterialFamilyId == materialFamilyId
                    && x.MaterialFormId == materialFormId
                    && x.MaterialStandardId == materialStandardId
                    && x.Status != Status.Deleted
                    && x.IsActive)
                .OrderBy(x => x.Grade == string.Empty ? x.Name : x.Grade)
                .ToListAsync(cancellationToken);

            if (directMatches.Count > 0)
            {
                return directMatches;
            }

            // Geçiş dönemi: Mevcut Material kayıtlarında MaterialFormId henüz dolu değilse eski MaterialForms bağlantısından eşleştir.
            return await _context.MaterialForms
                .AsNoTracking()
                .Where(x => x.Id == materialFormId && x.MaterialId != Guid.Empty && x.Status != Status.Deleted)
                .Select(x => x.Material)
                .Where(x => x.Status != Status.Deleted && x.IsActive)
                .OrderBy(x => x.Grade == string.Empty ? x.Name : x.Grade)
                .ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<MaterialMechanicalProperty>> GetMechanicalPropertiesByMaterialIdAsync(Guid materialId, CancellationToken cancellationToken = default)
        {
            return await _context.MaterialMechanicalProperties
                .AsNoTracking()
                .Include(x => x.Material)
                .Where(x => x.MaterialId == materialId && x.Status != Status.Deleted && x.IsActive)
                .OrderBy(x => x.ThicknessMin)
                .ThenBy(x => x.Temperature)
                .ToListAsync(cancellationToken);
        }

        public async Task<StockCard?> GetStockCardByMaterialIdAsync(Guid materialId, CancellationToken cancellationToken = default)
        {
            return await _context.Set<StockCard>()
                .AsNoTracking()
                .Include(x => x.Material)
                .Where(x => x.MaterialId == materialId && x.Status != Status.Deleted && x.IsActive)
                .OrderBy(x => x.StockCode)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<StockCard?> GetStockCardByStockCodeAsync(string stockCode, CancellationToken cancellationToken = default)
        {
            var normalized = stockCode.Trim();
            return await _context.Set<StockCard>()
                .AsNoTracking()
                .Include(x => x.Material)
                .Where(x => x.Status != Status.Deleted
                    && x.IsActive
                    && ((x.StockCode != null && x.StockCode == normalized) || x.StockCode8 == normalized))
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<StockCardPrice?> GetActivePriceByStockCardIdAsync(Guid stockCardId, DateTime atDate, string? currency = null, CancellationToken cancellationToken = default)
        {
            var query = _context.StockCardPrices
                .AsNoTracking()
                .Include(x => x.StockCard)
                .ThenInclude(x => x.Material)
                .Where(x => x.StockCardId == stockCardId
                    && x.Status != Status.Deleted
                    && x.IsActive
                    && x.ValidFrom.Date <= atDate.Date
                    && (x.ValidTo == null || x.ValidTo.Value.Date >= atDate.Date));

            if (!string.IsNullOrWhiteSpace(currency))
            {
                var normalizedCurrency = currency.Trim().ToUpperInvariant();
                query = query.Where(x => (x.Currency ?? string.Empty).Trim().ToUpper() == normalizedCurrency);
            }

            return await query
                .OrderByDescending(x => x.ValidFrom)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
