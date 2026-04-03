using MVC.ProductManagement.Domain.Core.BaseEntities;

namespace MVC.ProductManagement.Domain.Entities.StockCodes.Catalog
{
    public class GeneratedStockCodeRuleSelection : AuditableEntity
    {
        public Guid GeneratedStockCodeId { get; set; }
        public virtual GeneratedStockCode GeneratedStockCode { get; set; } = default!;

        public Guid StockSubCodeRuleId { get; set; }
        public virtual StockSubCodeRule StockSubCodeRule { get; set; } = default!;
    }
}
