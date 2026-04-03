namespace MVC.ProductManagement.Application.DTOs.StockCodes.Catalog
{
    using MVC.ProductManagement.Domain.Enums;

    public class GeneratedStockCodeListDto
    {
        public Guid Id { get; set; }
        public Guid StockSubCodeGroupId { get; set; }
        public Guid? StockSubCodeRuleId { get; set; }
        public string MainGroupCode { get; set; } = default!;
        public string SubGroupCode { get; set; } = default!;
        public string SubGroupName { get; set; } = default!;
        public string GeneratedCode { get; set; } = default!;
        public string RuleName { get; set; } = default!;
        public string? Description { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TargetPrice { get; set; }
        public PrimaryUnitType PrimaryUnitType { get; set; }
        public decimal KgEquivalentPerPrimaryUnit { get; set; }
    }

    public class GeneratedStockCodeDetailDto : GeneratedStockCodeListDto { }

    public class GeneratedStockCodeCreateDto
    {
        public Guid StockSubCodeGroupId { get; set; }
        public Guid? StockSubCodeRuleId { get; set; }
        public List<Guid> SelectedRuleIds { get; set; } = new();
        public string? GeneratedCode { get; set; }
        public string RuleName { get; set; } = default!;
        public string? Description { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TargetPrice { get; set; }
        public PrimaryUnitType PrimaryUnitType { get; set; } = PrimaryUnitType.Adet;
        public decimal KgEquivalentPerPrimaryUnit { get; set; } = 1m;
    }

    public class GeneratedStockCodeUpdateDto
    {
        public Guid Id { get; set; }
        public Guid? StockSubCodeRuleId { get; set; }
        public List<Guid> SelectedRuleIds { get; set; } = new();
        public string? Description { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TargetPrice { get; set; }
        public PrimaryUnitType PrimaryUnitType { get; set; } = PrimaryUnitType.Adet;
        public decimal KgEquivalentPerPrimaryUnit { get; set; } = 1m;
    }

    public class GeneratedStockCodeResolveDto
    {
        public string Code { get; set; } = default!;
        public string RuleName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TargetPrice { get; set; }
        public bool IsExisting { get; set; }
    }
}
