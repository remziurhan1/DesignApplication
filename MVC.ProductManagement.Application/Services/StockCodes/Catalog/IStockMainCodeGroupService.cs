using MVC.ProductManagement.Application.DTOs.StockCodes.Catalog;

namespace MVC.ProductManagement.Application.Services.StockCodes.Catalog
{
    public interface IStockMainCodeGroupService
    {
        Task<List<StockMainCodeGroupListDto>> GetAllAsync();
        Task<StockMainCodeGroupDetailDto?> GetByIdAsync(Guid id);
        Task<StockMainCodeGroupDetailDto> CreateAsync(StockMainCodeGroupCreateDto dto);
        Task<StockMainCodeGroupDetailDto> UpdateAsync(StockMainCodeGroupUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}
