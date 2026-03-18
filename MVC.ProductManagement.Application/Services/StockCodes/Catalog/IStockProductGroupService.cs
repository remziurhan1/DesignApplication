using MVC.ProductManagement.Application.DTOs.StockCodes.Catalog;

namespace MVC.ProductManagement.Application.Services.StockCodes.Catalog
{
    public interface IStockProductGroupService
    {
        Task<List<StockProductGroupListDto>> GetAllAsync();
        Task<StockProductGroupDetailDto?> GetByIdAsync(Guid id);
        Task<StockProductGroupDetailDto> CreateAsync(StockProductGroupCreateDto dto);
        Task<StockProductGroupDetailDto> UpdateAsync(StockProductGroupUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}
