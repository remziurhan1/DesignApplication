using MVC.ProductManagement.Domain.Core.BaseEntities;

namespace MVC.ProductManagement.Domain.Entities.StockCodes.Catalog
{
    public class GeneratedStockCode : AuditableEntity
    {
        public Guid StockSubCodeGroupId { get; set; }
        public virtual StockSubCodeGroup StockSubCodeGroup { get; set; } = default!;

        public Guid? StockSubCodeRuleId { get; set; }
        public virtual StockSubCodeRule? StockSubCodeRule { get; set; }

        public string GeneratedCode { get; set; } = default!;
        public string RuleName { get; set; } = default!;
        public string? Description { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TargetPrice { get; set; }
    }
}
