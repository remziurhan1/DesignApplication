using MVC.ProductManagement.Application.DTOs.StockCodes.Catalog;

namespace MVC.ProductManagement.Application.Services.StockCodes.Catalog
{
    public interface IGeneratedStockCodeService
    {
        Task<List<GeneratedStockCodeListDto>> GetAllAsync(Guid? subGroupId = null);
        Task<List<GeneratedStockCodeListDto>> GetFilteredAsync(GeneratedStockCodeFilterDto filter);
        Task<GeneratedStockCodeDetailDto?> GetByIdAsync(Guid id);
        Task<GeneratedStockCodeListDto> CreateAsync(GeneratedStockCodeCreateDto dto);
        Task<GeneratedStockCodeDetailDto> UpdateAsync(GeneratedStockCodeUpdateDto dto);
        Task<GeneratedStockCodeResolveDto> ResolveCodeAsync(Guid subGroupId, List<Guid>? selectedRuleIds = null);
        Task RefreshDerivedFieldsBySubGroupAsync(Guid subGroupId);
        Task<IReadOnlyList<GeneratedStockCodeInventoryMovementDto>> GetInventoryMovementsAsync(Guid generatedStockCodeId);
        Task<GeneratedStockCodeInventoryMovementDto> CreateInventoryMovementAsync(GeneratedStockCodeInventoryMovementCreateDto dto, string userName = "System");
    }
}
