using MVC.ProductManagement.Domain.Core.BaseEntities;

namespace MVC.ProductManagement.Domain.Entities.SalesRequests
{
    public class SalesRequestRevision : AuditableEntity
    {
        public Guid SalesRequestId { get; set; }
        public int RevisionNo { get; set; }
        public string RevisionReason { get; set; } = string.Empty;
        public string SnapshotJson { get; set; } = string.Empty;
        public string RevisedByName { get; set; } = string.Empty;
        public DateTime RevisedAt { get; set; } = DateTime.UtcNow;

        public virtual SalesRequest SalesRequest { get; set; } = default!;
    }
}
