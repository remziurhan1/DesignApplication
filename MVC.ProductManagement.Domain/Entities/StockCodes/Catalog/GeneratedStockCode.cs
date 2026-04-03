using MVC.ProductManagement.Domain.Core.BaseEntities;
using MVC.ProductManagement.Domain.Enums;

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
        public PrimaryUnitType PrimaryUnitType { get; set; } = PrimaryUnitType.Adet;
        public decimal KgEquivalentPerPrimaryUnit { get; set; } = 1m;
        public string? Step3DFilePath { get; set; }
        public string? DxfFilePath1 { get; set; }
        public string? DxfFilePath2 { get; set; }
        public string? DatasheetFilePath { get; set; }

        public virtual ICollection<StockProductGroupItem> ProductGroupItems { get; set; } = new List<StockProductGroupItem>();
        public virtual ICollection<GeneratedStockCodeRuleSelection> RuleSelections { get; set; } = new List<GeneratedStockCodeRuleSelection>();
        public virtual ICollection<GeneratedStockCodeInventoryMovement> InventoryMovements { get; set; } = new List<GeneratedStockCodeInventoryMovement>();
    }
}
