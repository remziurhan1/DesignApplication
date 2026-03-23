using MVC.ProductManagement.Domain.Core.BaseEntities;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Domain.Enums;

namespace MVC.ProductManagement.Domain.Entities.SalesRequests
{
    public class SalesRequest : AuditableEntity
    {
        public string RequestNo { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public Guid CustomerId { get; set; }
        public string RequestedByName { get; set; } = string.Empty;
        public string? RequestedByEmail { get; set; }
        public string? RequestedByDepartment { get; set; }
        public string? SummaryNotes { get; set; }
        public string? InternalNotes { get; set; }
        public SalesRequestWorkflowStatus WorkflowStatus { get; set; } = SalesRequestWorkflowStatus.Submitted;
        public DateTime SalesOpenedAt { get; set; } = DateTime.UtcNow;
        public DateTime? PricingCompletedAt { get; set; }
        public DateTime? ApprovedAt { get; set; }

        public Customer Customer { get; set; } = default!;
        public ICollection<SalesRequestItem> Items { get; set; } = new List<SalesRequestItem>();
        public ICollection<SalesRequestAttachment> Attachments { get; set; } = new List<SalesRequestAttachment>();
    }
}
