using System;
using System.Collections.Generic;
using MVC.ProductManagement.Application.DTOs.StockCodes.Common;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.SB
{
    public class StockCodeSbFormFeatureDto
    {
        public Guid FeatureId { get; set; }
        public string FeatureCode { get; set; } = string.Empty;
        public string FeatureName { get; set; } = string.Empty;
        public bool IsFixed { get; set; }
        public Guid? FixedValueId { get; set; }
        public string? FixedValueCode { get; set; }
        public string? FixedValueName { get; set; }

        // ✅ Artık SbFeatureValueOptionDto kullanıyor
        public List<SbFeatureValueOptionDto> AvailableValues { get; set; } = new();
    }
}