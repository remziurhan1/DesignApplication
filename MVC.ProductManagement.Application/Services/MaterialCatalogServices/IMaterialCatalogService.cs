using MVC.ProductManagement.Application.DTOs.MaterialCatalogDTOs;

namespace MVC.ProductManagement.Application.Services.MaterialCatalogServices
{
    public interface IMaterialCatalogService
    {
        Task<IReadOnlyList<MaterialLookupDto>> GetMaterialFamiliesAsync(CancellationToken cancellationToken = default);
        Task<IReadOnlyList<MaterialLookupDto>> GetMaterialFormsByFamilyAsync(Guid materialFamilyId, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<MaterialLookupDto>> GetMaterialStandardsAsync(Guid materialFamilyId, Guid materialFormId, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<MaterialSelectionDto>> GetMaterialsAsync(Guid materialFamilyId, Guid materialFormId, Guid materialStandardId, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<MaterialMechanicalPropertyDto>> GetMechanicalPropertiesByMaterialIdAsync(Guid materialId, CancellationToken cancellationToken = default);
        Task<MaterialStockCardDto?> GetStockCardByMaterialIdAsync(Guid materialId, CancellationToken cancellationToken = default);
        Task<MaterialPriceDto?> GetActivePriceByStockCodeAsync(string stockCode, DateTime? atDate = null, string? currency = null, CancellationToken cancellationToken = default);
        Task<MaterialPriceDto?> GetActivePriceByMaterialIdAsync(Guid materialId, DateTime? atDate = null, string? currency = null, CancellationToken cancellationToken = default);
    }
}
