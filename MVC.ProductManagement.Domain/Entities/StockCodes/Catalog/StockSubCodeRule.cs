using MVC.ProductManagement.Domain.Core.BaseEntities;

namespace MVC.ProductManagement.Domain.Entities.StockCodes.Catalog
{
    public class StockSubCodeRule : AuditableEntity
    {
        public Guid StockSubCodeGroupId { get; set; }
        public virtual StockSubCodeGroup StockSubCodeGroup { get; set; } = default!;

        public string RuleCode { get; set; } = default!;
        public string RuleName { get; set; } = default!;
        public string? Description { get; set; }
        public int? SortOrder { get; set; }
        public bool IsEnabled { get; set; } = true;

        public virtual ICollection<GeneratedStockCode> GeneratedCodes { get; set; } = new List<GeneratedStockCode>();
    }
}
