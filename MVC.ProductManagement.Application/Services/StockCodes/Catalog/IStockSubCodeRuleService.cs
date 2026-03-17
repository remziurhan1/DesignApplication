using MVC.ProductManagement.Application.DTOs.StockCodes.Catalog;

namespace MVC.ProductManagement.Application.Services.StockCodes.Catalog
{
    public interface IStockSubCodeRuleService
    {
        Task<List<StockSubCodeRuleListDto>> GetAllAsync(Guid? subGroupId = null);
        Task<StockSubCodeRuleDetailDto?> GetByIdAsync(Guid id);
        Task<StockSubCodeRuleDetailDto?> FindBySubGroupAndDescriptionAsync(Guid subGroupId, string? description);
        Task<StockSubCodeRuleDetailDto> CreateAsync(StockSubCodeRuleCreateDto dto);
        Task<StockSubCodeRuleDetailDto> UpdateAsync(StockSubCodeRuleUpdateDto dto);
        Task<string> GetNextStockCodeBySubGroupAsync(Guid subGroupId);
        Task DeleteAsync(Guid id);
    }
}
