using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.Common
{
    public class GenericStockCardDetailDto
    {
        public Guid Id { get; set; }
        public string StockCode8 { get; set; } = string.Empty;
        public string Prefix4 { get; set; } = string.Empty;
        public int Serial4 { get; set; }
        public Guid ProductId { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public Guid? FluidId { get; set; }
        public string? FluidCode { get; set; }
        public string? FluidName { get; set; }
        public string Description { get; set; } = string.Empty;
        public string OptionKey { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public List<GenericFeatureSelectionDto> FeatureSelections { get; set; } = new();
    }

    public class GenericFeatureSelectionDto
    {
        public Guid FeatureId { get; set; }
        public string FeatureName { get; set; } = string.Empty;
        public Guid ValueId { get; set; }
        public string ValueCode { get; set; } = string.Empty;
        public string ValueName { get; set; } = string.Empty;
        public int SortOrder { get; set; }
    }
}
