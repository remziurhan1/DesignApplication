using MVC.ProductManagement.Domain.Core.BaseEntities;

namespace MVC.ProductManagement.Domain.Entities.StockCodes.Catalog
{
    public class StockSubCodeGroup : AuditableEntity
    {
        public Guid StockMainCodeGroupId { get; set; }
        public virtual StockMainCodeGroup StockMainCodeGroup { get; set; } = default!;

        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public bool IsEnabled { get; set; } = true;

        public virtual ICollection<StockSubCodeRule> Rules { get; set; } = new List<StockSubCodeRule>();
        public virtual ICollection<GeneratedStockCode> GeneratedCodes { get; set; } = new List<GeneratedStockCode>();
    }
}
