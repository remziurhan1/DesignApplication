using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Domain.Entities.MaterialCatalog;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;

namespace MVC.ProductManagement.Infrastructure.Repositories.MaterialCatalogRepositories
{
    public interface IMaterialCatalogRepository
    {
        Task<IReadOnlyList<MaterialFamily>> GetMaterialFamiliesAsync(CancellationToken cancellationToken = default);
        Task<IReadOnlyList<MaterialForm>> GetMaterialFormsByFamilyAsync(Guid materialFamilyId, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<MaterialStandard>> GetMaterialStandardsAsync(Guid materialFamilyId, Guid materialFormId, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<Material>> GetMaterialsAsync(Guid materialFamilyId, Guid materialFormId, Guid materialStandardId, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<MaterialMechanicalProperty>> GetMechanicalPropertiesByMaterialIdAsync(Guid materialId, CancellationToken cancellationToken = default);
        Task<StockCard?> GetStockCardByMaterialIdAsync(Guid materialId, CancellationToken cancellationToken = default);
        Task<StockCard?> GetStockCardByStockCodeAsync(string stockCode, CancellationToken cancellationToken = default);
        Task<StockCardPrice?> GetActivePriceByStockCardIdAsync(Guid stockCardId, DateTime atDate, string? currency = null, CancellationToken cancellationToken = default);
    }
}
