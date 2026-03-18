using MVC.ProductManagement.Domain.Core.BaseEntities;

namespace MVC.ProductManagement.Domain.Entities.StockCodes.Catalog
{
    public class StockProductGroup : AuditableEntity
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalCost { get; set; }

        public virtual ICollection<StockProductGroupItem> Items { get; set; } = new List<StockProductGroupItem>();
    }
}
