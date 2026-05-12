using MVC.ProductManagement.Domain.Entities.StockCodes.Catalog;

namespace MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Catalog;

public interface IGeneratedStockCodeInventoryRepository
{
    Task<IDictionary<Guid, int>> GetCurrentStocksAsync(IEnumerable<Guid> generatedStockCodeIds);
    Task<IReadOnlyList<Guid>> GetSelectedRuleIdsAsync(Guid generatedStockCodeId);
    Task ReplaceRuleSelectionsAsync(Guid generatedStockCodeId, IEnumerable<Guid> selectedRuleIds);
    Task<IReadOnlyList<GeneratedStockCodeInventoryMovement>> GetMovementsAsync(Guid generatedStockCodeId);
    Task<int> GetLastStockAsync(Guid generatedStockCodeId);
    Task AddMovementAsync(GeneratedStockCodeInventoryMovement movement);
    Task<string?> GetStockProductGroupNameAsync(Guid stockProductGroupId);
    Task CommitAsync();
}
