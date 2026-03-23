using MVC.ProductManagement.Domain.Core.BaseEntities;

namespace MVC.ProductManagement.Domain.Entities.SalesRequests
{
    public class SalesRequestProductGroup : AuditableEntity
    {
        public string Code { get; set; } = string.Empty;
        public string ShortCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ICollection<SalesRequestItem> RequestItems { get; set; } = new List<SalesRequestItem>();
    }
}
