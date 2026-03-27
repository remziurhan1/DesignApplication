using MVC.ProductManagement.Domain.Core.BaseEntities;

namespace MVC.ProductManagement.Domain.Entities.SalesRequests
{
    public class SalesRequestComment : AuditableEntity
    {
        public Guid SalesRequestId { get; set; }
        public string CommentText { get; set; } = string.Empty;
        public string CommentedBy { get; set; } = string.Empty;

        public virtual SalesRequest SalesRequest { get; set; } = default!;
    }
}
