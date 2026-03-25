using MVC.ProductManagement.Domain.Core.BaseEntities;
using MVC.ProductManagement.Domain.Enums;

namespace MVC.ProductManagement.Domain.Entities.SalesRequests
{
    public class SalesRequestDocument : AuditableEntity
    {
        public Guid SalesRequestId { get; set; }
        public Guid? SalesRequestItemId { get; set; }
        public SalesDocumentType DocumentType { get; set; }
        public string RevisionCode { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public string OriginalFileName { get; set; } = string.Empty;
        public string UploadedBy { get; set; } = string.Empty;
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
        public bool IsCurrent { get; set; } = true;
        public Guid? LinkedCostAnalysisId { get; set; }
        public string? LinkedCostAnalysisRevisionCode { get; set; }
        public string? Notes { get; set; }

        public virtual SalesRequest SalesRequest { get; set; } = default!;
        public virtual SalesRequestItem? SalesRequestItem { get; set; }
    }
}
