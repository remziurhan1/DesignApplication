namespace MVC.ProductManagement.Application.DTOs.StockCodes.Catalog
{
    public class StockSubCodeRuleListDto
    {
        public Guid Id { get; set; }
        public Guid StockSubCodeGroupId { get; set; }
        public string MainGroupCode { get; set; } = default!;
        public string MainGroupName { get; set; } = default!;
        public string SubGroupCode { get; set; } = default!;
        public string SubGroupName { get; set; } = default!;
        public string RuleCode { get; set; } = default!;
        public string RuleName { get; set; } = default!;
        public string? Description { get; set; }
        public bool IsEnabled { get; set; }
    }

    public class StockSubCodeRuleDetailDto : StockSubCodeRuleListDto { }

    public class StockSubCodeRuleCreateDto
    {
        public Guid StockSubCodeGroupId { get; set; }
        public string RuleCode { get; set; } = default!;
        public string RuleName { get; set; } = default!;
        public string? Description { get; set; }
        public bool IsEnabled { get; set; } = true;
    }

    public class StockSubCodeRuleUpdateDto : StockSubCodeRuleCreateDto
    {
        public Guid Id { get; set; }
    }
}
