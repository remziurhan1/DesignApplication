using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.SH
{
    public class SHStockCardDetailDto
    {
        public Guid Id { get; set; }
        public string StockCode8 { get; set; } = string.Empty;
        public string Prefix4 { get; set; } = string.Empty;
        public int Serial4 { get; set; }
        public Guid ProductId { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string? FluidCode { get; set; }
        public string? FluidName { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = string.Empty;

        // ✅ Artık SHFeatureSelectionDto kullanıyor
        public List<SHFeatureSelectionDto> FeatureSelections { get; set; } = new();
    }
}