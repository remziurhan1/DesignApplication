using MVC.ProductManagement.Infrastructure.Repositories.SalesRequestRepositories.DTOs;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Domain.Entities.SalesRequests;
using MVC.ProductManagement.Domain.Enums;

namespace MVC.ProductManagement.Application.Services.SalesRequestServices;

public interface ISalesRequestAdminService
{
    Task RefreshLinkedPricingAsync(Guid? requestId = null);
    Task<List<SalesRequest>> GetIndexRequestsAsync();
    Task<Dictionary<Guid, SalesRequestProductGroup>> GetProductGroupsDictionaryAsync();
    Task CreateAsync(SalesRequest entity);
    Task<SalesRequest?> GetForEditAsync(Guid id, bool tracking);
    void RemoveItems(IEnumerable<SalesRequestItem> items);
    Task AddItemAsync(SalesRequestItem item);
    Task<List<SalesRequestRevision>> GetRevisionsAsync(Guid salesRequestId);
    Task<SalesRequest?> LoadRequestAsync(Guid id);
    Task<SalesRequest?> GetForPricingAsync(Guid id);
    Task<SalesRequest?> GetWithItemsAsync(Guid id);
    Task<List<Customer>> GetActiveCustomersAsync();
    Task<List<SalesRequestProductGroup>> GetActiveProductGroupsAsync();
    Task<EmployeeProfile?> GetEmployeeProfileAsync(string userId);
    Task<SalesRequest?> GetByIdAsync(Guid id);
    Task AddCommentAsync(SalesRequestComment comment);
    Task<List<SalesRequestPricingAnalysisDto>> GetAvailableAnalysesAsync();
    Task<string> GenerateRequestNoAsync();
    Task<SalesRequestProductGroup?> GetProductGroupAsync(Guid id, bool tracking = false);
    Task AddAttachmentsAsync(SalesRequest request, IEnumerable<SalesRequestAttachment> attachments);
    Task CommitAsync();
}
