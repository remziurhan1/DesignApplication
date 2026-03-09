using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.Common
{
    public class GenericStockCodeFormDto
    {
        public Guid ProductId { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public List<GenericStockCodeFormFeatureDto> Features { get; set; } = new();
    }

    public class GenericStockCodeFormFeatureDto
    {
        public Guid FeatureId { get; set; }
        public string FeatureCode { get; set; } = string.Empty;
        public string FeatureName { get; set; } = string.Empty;
        public bool IsFixed { get; set; }
        public Guid? FixedValueId { get; set; }
        public string? FixedValueCode { get; set; }
        public string? FixedValueName { get; set; }
        public List<FeatureValueDto> AvailableValues { get; set; } = new();
    }
}
