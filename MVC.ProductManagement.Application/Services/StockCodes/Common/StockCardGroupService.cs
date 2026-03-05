using MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör;

namespace MVC.ProductManagement.Application.Services.StockCodes.Common
{
    public class StockCardGroupService : IStockCardGroupService
    {
        private readonly IStockCardGroupRepository _repository;

        public StockCardGroupService(IStockCardGroupRepository repository)
        {
            _repository = repository;
        }

        public Task<Guid> CreateGroupAsync(StockCardGroupCreateDto dto, string userName, CancellationToken cancellationToken = default)
            => _repository.CreateGroupAsync(dto, userName, cancellationToken);

        public Task<IReadOnlyList<StockCardGroupListItemDto>> GetGroupsAsync(CancellationToken cancellationToken = default)
            => _repository.GetGroupsAsync(cancellationToken);

        public Task<StockCardGroupDetailDto?> GetGroupDetailAsync(Guid groupId, CancellationToken cancellationToken = default)
            => _repository.GetGroupDetailAsync(groupId, cancellationToken);

        public Task AddItemAsync(Guid groupId, Guid stockCardId, int quantity, string userName, CancellationToken cancellationToken = default)
            => _repository.AddItemAsync(groupId, stockCardId, quantity, userName, cancellationToken);

        public Task UpdateItemQuantityAsync(Guid groupItemId, int quantity, string userName, CancellationToken cancellationToken = default)
            => _repository.UpdateItemQuantityAsync(groupItemId, quantity, userName, cancellationToken);

        public Task RemoveItemAsync(Guid groupItemId, string userName, CancellationToken cancellationToken = default)
            => _repository.RemoveItemAsync(groupItemId, userName, cancellationToken);

        public Task<IReadOnlyList<StockCardLookupDto>> SearchStockCardsAsync(string? term, int take = 50, CancellationToken cancellationToken = default)
            => _repository.SearchStockCardsAsync(term, take, cancellationToken);
    }
}
