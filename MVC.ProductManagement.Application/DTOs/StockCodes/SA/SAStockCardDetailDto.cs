using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.SA
{
    /// <summary>
    /// SA Stok Kartı Detay DTO
    /// </summary>
    public class SAStockCardDetailDto
    {
        public Guid Id { get; set; }
        public string StockCode8 { get; set; } = string.Empty;
        public string Prefix4 { get; set; } = string.Empty;
        public int Serial4 { get; set; }

        public Guid ProductId { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;

        public Guid FluidId { get; set; }
        public string FluidCode { get; set; } = string.Empty;
        public string FluidName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public string OptionKey { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = string.Empty;

        /// <summary>
        /// Feature seçimleri
        /// </summary>
        public List<FeatureSelectionDto> FeatureSelections { get; set; } = new();
    }

    /// <summary>
    /// Feature seçimi bilgisi
    /// </summary>
    public class FeatureSelectionDto
    {
        public Guid FeatureId { get; set; }
        public string FeatureName { get; set; } = string.Empty;
        public Guid ValueId { get; set; }
        public string ValueCode { get; set; } = string.Empty;
        public string ValueName { get; set; } = string.Empty;
        public int SortOrder { get; set; }
    }
}