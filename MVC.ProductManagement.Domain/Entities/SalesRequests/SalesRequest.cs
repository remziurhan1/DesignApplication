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
        public DateTime? RequestReceivedAt { get; set; }
        public DateTime NeededByDate { get; set; }
        public SalesRequestSource RequestSource { get; set; } = SalesRequestSource.Sales;
        public string? ShipmentCountry { get; set; }
        public string? InstallationCountry { get; set; }
        public bool IsTransportByCustomer { get; set; }
        public string? SummaryNotes { get; set; }
        public string? InternalNotes { get; set; }
        public SalesRequestWorkflowStatus WorkflowStatus { get; set; } = SalesRequestWorkflowStatus.Submitted;
        public SalesCustomerQuoteStatus CustomerQuoteStatus { get; set; } = SalesCustomerQuoteStatus.NotShared;
        public SalesOfferStatus OfferStatus { get; set; } = SalesOfferStatus.F;
        public int RevisionNo { get; set; } = 1;
        public DateTime SalesOpenedAt { get; set; } = DateTime.UtcNow;
        public DateTime? PricingCompletedAt { get; set; }
        public DateTime? ApprovedAt { get; set; }

        public virtual Customer Customer { get; set; } = default!;
        public virtual ICollection<SalesRequestItem> Items { get; set; } = new List<SalesRequestItem>();
        public virtual ICollection<SalesRequestAttachment> Attachments { get; set; } = new List<SalesRequestAttachment>();
        public virtual ICollection<SalesRequestRevision> Revisions { get; set; } = new List<SalesRequestRevision>();
        public virtual ICollection<SalesRequestDocument> Documents { get; set; } = new List<SalesRequestDocument>();
    }
}
