using MVC.ProductManagement.Domain.Core.BaseEntities;

namespace MVC.ProductManagement.Domain.Entities.SalesRequests
{
    public class SalesRequestAttachment : AuditableEntity
    {
        public Guid SalesRequestId { get; set; }
        public string OriginalFileName { get; set; } = string.Empty;
        public string StoredFileName { get; set; } = string.Empty;
        public string RelativePath { get; set; } = string.Empty;
        public string? ContentType { get; set; }
        public long FileSize { get; set; }

        public virtual SalesRequest SalesRequest { get; set; } = default!;
    }
}
