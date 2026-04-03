using MVC.ProductManagement.Application.DTOs.StockCodes.Catalog;

namespace MVC.ProductManagement.Application.Services.StockCodes.Catalog
{
    public interface IGeneratedStockCodeService
    {
        Task<List<GeneratedStockCodeListDto>> GetAllAsync(Guid? subGroupId = null);
        Task<GeneratedStockCodeDetailDto?> GetByIdAsync(Guid id);
        Task<GeneratedStockCodeListDto> CreateAsync(GeneratedStockCodeCreateDto dto);
        Task<GeneratedStockCodeDetailDto> UpdateAsync(GeneratedStockCodeUpdateDto dto);
        Task<GeneratedStockCodeResolveDto> ResolveCodeAsync(Guid subGroupId, List<Guid>? selectedRuleIds = null);
        Task RefreshDerivedFieldsBySubGroupAsync(Guid subGroupId);
    }
}
