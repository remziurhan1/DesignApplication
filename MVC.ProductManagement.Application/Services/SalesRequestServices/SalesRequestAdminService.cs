using MVC.ProductManagement.Infrastructure.Repositories.SalesRequestRepositories.DTOs;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Domain.Entities.SalesRequests;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.Repositories.SalesRequestRepositories;

namespace MVC.ProductManagement.Application.Services.SalesRequestServices;

public class SalesRequestAdminService : ISalesRequestAdminService
{
    private readonly ISalesRequestRepository _repository;

    public SalesRequestAdminService(ISalesRequestRepository repository)
    {
        _repository = repository;
    }

    public async Task RefreshLinkedPricingAsync(Guid? requestId = null)
    {
        var requests = await _repository.GetRequestsForPricingRefreshAsync(requestId);
        var hasChanges = false;

        foreach (var request in requests)
        {
            foreach (var item in request.Items.Where(x => x.LinkedCalculationType.HasValue && x.LinkedCalculationId.HasValue))
            {
                var snapshot = await _repository.GetLatestLinkedSnapshotAsync(item.LinkedCalculationType.Value, item.LinkedCalculationId.Value);
                if (snapshot == null)
                {
                    continue;
                }

                var minimumSalesPrice = snapshot.MinimumSalesPrice ?? snapshot.TotalCost;
                var recommendedSalesPrice = snapshot.RecommendedSalesPrice ?? minimumSalesPrice;

                if (item.LinkedCostAnalysisId == snapshot.CostAnalysisId
                    && item.LinkedCostAnalysisRevisionCode == snapshot.RevisionCode
                    && item.LinkedCalculationName == snapshot.CalculationName
                    && item.LinkedCostAnalysisTotal == snapshot.TotalCost
                    && item.EstimatedCost == snapshot.TotalCost
                    && item.MinimumSalesPrice == minimumSalesPrice
                    && item.ApprovedSalesPrice == recommendedSalesPrice)
                {
                    continue;
                }

                item.LinkedCostAnalysisId = snapshot.CostAnalysisId;
                item.LinkedCalculationName = snapshot.CalculationName;
                item.LinkedCostAnalysisRevisionCode = snapshot.RevisionCode;
                item.LinkedCostAnalysisTotal = snapshot.TotalCost;
                item.EstimatedCost = snapshot.TotalCost;
                item.MinimumSalesPrice = minimumSalesPrice;
                item.ApprovedSalesPrice = recommendedSalesPrice;
                hasChanges = true;
            }
        }

        if (hasChanges)
        {
            await _repository.CommitAsync();
        }
    }

    public Task<List<SalesRequest>> GetIndexRequestsAsync() => _repository.GetIndexRequestsAsync();
    public Task<Dictionary<Guid, SalesRequestProductGroup>> GetProductGroupsDictionaryAsync() => _repository.GetProductGroupsDictionaryAsync();
    public async Task CreateAsync(SalesRequest entity)
    {
        await _repository.AddSalesRequestAsync(entity);
        await _repository.CommitAsync();
    }
    public Task<SalesRequest?> GetForEditAsync(Guid id, bool tracking) => _repository.GetForEditAsync(id, tracking);
    public void RemoveItems(IEnumerable<SalesRequestItem> items) => _repository.RemoveItems(items);
    public Task AddItemAsync(SalesRequestItem item) => _repository.AddItemAsync(item);
    public Task<List<SalesRequestRevision>> GetRevisionsAsync(Guid salesRequestId) => _repository.GetRevisionsAsync(salesRequestId);
    public Task<SalesRequest?> LoadRequestAsync(Guid id) => _repository.LoadRequestAsync(id);
    public Task<SalesRequest?> GetForPricingAsync(Guid id) => _repository.GetForPricingAsync(id);
    public Task<SalesRequest?> GetWithItemsAsync(Guid id) => _repository.GetWithItemsAsync(id);
    public Task<List<Customer>> GetActiveCustomersAsync() => _repository.GetActiveCustomersAsync();
    public Task<List<SalesRequestProductGroup>> GetActiveProductGroupsAsync() => _repository.GetActiveProductGroupsAsync();
    public Task<EmployeeProfile?> GetEmployeeProfileAsync(string userId) => _repository.GetEmployeeProfileAsync(userId);
    public Task<SalesRequest?> GetByIdAsync(Guid id) => _repository.GetByIdAsync(id);
    public async Task AddCommentAsync(SalesRequestComment comment)
    {
        await _repository.AddCommentAsync(comment);
        await _repository.CommitAsync();
    }
    public Task<List<SalesRequestPricingAnalysisDto>> GetAvailableAnalysesAsync() => _repository.GetAvailableAnalysesAsync();
    public async Task<string> GenerateRequestNoAsync()
    {
        var prefix = $"TR-{DateTime.UtcNow:yyyyMMdd}";
        var todayCount = await _repository.CountByRequestNoPrefixAsync(prefix);
        return $"{prefix}-{todayCount + 1:000}";
    }
    public Task<SalesRequestProductGroup?> GetProductGroupAsync(Guid id, bool tracking = false) => _repository.GetProductGroupAsync(id, tracking);
    public async Task AddAttachmentsAsync(SalesRequest request, IEnumerable<SalesRequestAttachment> attachments)
    {
        await _repository.AddAttachmentsAsync(request, attachments);
        await _repository.CommitAsync();
    }
    public Task CommitAsync() => _repository.CommitAsync();
}
