using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;

namespace MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.SA
{
    public interface ISAStockCardRepository
    {
        // Feature sorguları
        Task<List<SFeature>> GetFeaturesByCodesAsync(IEnumerable<string> codes, CancellationToken cancellationToken = default);
        Task<List<SFeatureValue>> GetFeatureValuesByFeatureIdAsync(Guid featureId, CancellationToken cancellationToken = default);
        Task<List<SFeature>> GetFeaturesByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
        Task<List<SFeatureValue>> GetFeatureValuesByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
        Task<List<SFeature>> GetAllFeaturesOrderedAsync(CancellationToken cancellationToken = default);

        // Kural sorguları
        Task<List<SProductFeatureRule>> GetProductFeatureRulesAsync(Guid productId, CancellationToken cancellationToken = default);
        Task<List<SProductFeatureRule>> GetFixedProductFeatureRulesAsync(Guid productId, CancellationToken cancellationToken = default);
        Task<List<SFeatureValueRule>> GetFeatureValueRulesAsync(Guid productId, CancellationToken cancellationToken = default);
        Task<List<SFeatureValueRule>> GetFeatureValueRulesByFeatureAsync(Guid productId, Guid featureId, CancellationToken cancellationToken = default);

        // StockCard sorguları
        Task<StockCard?> GetStockCardWithDetailsAsync(Guid stockCardId, CancellationToken cancellationToken = default);
        Task<(List<StockCard> Items, int TotalCount)> GetFilteredStockCardsAsync(
            string? searchTerm, Guid? productId, DateTime? startDate, DateTime? endDate,
            int pageNumber, int pageSize, CancellationToken cancellationToken = default);

        // StockCardFeatureSelection sorguları
        Task<List<StockCardFeatureSelection>> GetFeatureSelectionsAsync(Guid stockCardId, CancellationToken cancellationToken = default);
        Task<List<StockCardFeatureSelection>> GetFeatureSelectionsWithDetailsAsync(Guid stockCardId, CancellationToken cancellationToken = default);

        // Write işlemleri
        Task DeleteFeatureSelectionsAsync(Guid stockCardId, CancellationToken cancellationToken = default);
        Task AddFeatureSelectionsAsync(IEnumerable<StockCardFeatureSelection> selections, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<IDisposable> BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(IDisposable transaction, CancellationToken cancellationToken = default);
        Task RollbackTransactionAsync(IDisposable transaction, CancellationToken cancellationToken = default);
    }
}
