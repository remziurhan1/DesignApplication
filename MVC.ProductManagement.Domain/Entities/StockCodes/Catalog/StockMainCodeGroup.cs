using MVC.ProductManagement.Domain.Core.BaseEntities;

namespace MVC.ProductManagement.Domain.Entities.StockCodes.Catalog
{
    public class StockMainCodeGroup : AuditableEntity
    {
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public bool IsEnabled { get; set; } = true;

        public virtual ICollection<StockSubCodeGroup> SubGroups { get; set; } = new List<StockSubCodeGroup>();
    }
}
