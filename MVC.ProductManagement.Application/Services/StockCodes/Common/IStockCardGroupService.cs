using MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör;

namespace MVC.ProductManagement.Application.Services.StockCodes.Common
{
    public interface IStockCardGroupService
    {
        Task<Guid> CreateGroupAsync(StockCardGroupCreateDto dto, string userName, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<StockCardGroupListItemDto>> GetGroupsAsync(CancellationToken cancellationToken = default);
        Task<StockCardGroupDetailDto?> GetGroupDetailAsync(Guid groupId, CancellationToken cancellationToken = default);
        Task AddItemAsync(Guid groupId, Guid stockCardId, int quantity, string userName, CancellationToken cancellationToken = default);
        Task UpdateItemQuantityAsync(Guid groupItemId, int quantity, string userName, CancellationToken cancellationToken = default);
        Task RemoveItemAsync(Guid groupItemId, string userName, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<StockCardLookupDto>> SearchStockCardsAsync(string? term, int take = 50, CancellationToken cancellationToken = default);
    }
}
