using MVC.ProductManagement.Domain.Core.BaseEntities;
using MVC.ProductManagement.Domain.Enums;

namespace MVC.ProductManagement.Domain.Entities.StockCodes.Catalog
{
    public class GeneratedStockCodeInventoryMovement : AuditableEntity
    {
        public Guid GeneratedStockCodeId { get; set; }
        public virtual GeneratedStockCode GeneratedStockCode { get; set; } = default!;

        public InventoryMovementType MovementType { get; set; }
        public int Quantity { get; set; }
        public int StockBefore { get; set; }
        public int StockAfter { get; set; }
        public DateTime MovementDate { get; set; }

        public Guid? StockProductGroupId { get; set; }
        public virtual StockProductGroup? StockProductGroup { get; set; }

        public string? ReferenceDocument { get; set; }
        public string? Description { get; set; }
    }
}
