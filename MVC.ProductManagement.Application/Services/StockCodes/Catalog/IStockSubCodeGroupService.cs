using MVC.ProductManagement.Application.DTOs.StockCodes.Catalog;

namespace MVC.ProductManagement.Application.Services.StockCodes.Catalog
{
    public interface IStockSubCodeGroupService
    {
        Task<List<StockSubCodeGroupListDto>> GetAllAsync(Guid? mainGroupId = null);
        Task<StockSubCodeGroupDetailDto?> GetByIdAsync(Guid id);
        Task<StockSubCodeGroupDetailDto> CreateAsync(StockSubCodeGroupCreateDto dto);
        Task<StockSubCodeGroupDetailDto> UpdateAsync(StockSubCodeGroupUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}
