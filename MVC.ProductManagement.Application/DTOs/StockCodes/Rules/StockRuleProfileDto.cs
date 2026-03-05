using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.Rules
{
    public class StockRuleProfileDto
    {
        public string GroupCode { get; set; } = default!; // SA, SF
        public string GroupName { get; set; } = default!;
        public List<StockRuleProductDto> Products { get; set; } = new();
    }

    public class StockRuleProductDto
    {
        public Guid ProductId { get; set; }
        public string ProductCode { get; set; } = default!;
        public string ProductName { get; set; } = default!;
        public List<StockRuleFeatureDto> Features { get; set; } = new();
    }

    public class StockRuleFeatureDto
    {
        public Guid FeatureId { get; set; }
        public string FeatureCode { get; set; } = default!;
        public string FeatureName { get; set; } = default!;
        public bool IsFixed { get; set; }
        public Guid? FixedValueId { get; set; }
        public string? FixedValueCode { get; set; }
        public string? FixedValueName { get; set; }
        public List<StockRuleValueDto> AllowedValues { get; set; } = new();
    }

    public class StockRuleValueDto
    {
        public Guid ValueId { get; set; }
        public string ValueCode { get; set; } = default!;
        public string ValueName { get; set; } = default!;
        public int SortOrder { get; set; }
    }
}
