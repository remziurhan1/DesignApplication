using MVC.ProductManagement.Domain.Core.BaseEntities;

namespace MVC.ProductManagement.Domain.Entities.StockCodes.Catalog
{
    public class StockProductGroupItem : AuditableEntity
    {
        public Guid StockProductGroupId { get; set; }
        public virtual StockProductGroup StockProductGroup { get; set; } = default!;

        public Guid GeneratedStockCodeId { get; set; }
        public virtual GeneratedStockCode GeneratedStockCode { get; set; } = default!;

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalCost { get; set; }
    }
}
