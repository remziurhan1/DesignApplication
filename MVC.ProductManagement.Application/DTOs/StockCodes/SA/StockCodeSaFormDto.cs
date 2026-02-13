using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.SA
{
    /// <summary>
    /// Prefix seçildiğinde dönen form verileri
    /// (sabit feature'lar otomatik doldurulmuş + izinli değerler)
    /// </summary>
    public class StockCodeSaFormDto
    {
        /// <summary>
        /// Seçilen ürün ID
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Seçilen ürün kodu (SAA0, SAB1, vs.)
        /// </summary>
        public string ProductCode { get; set; } = string.Empty;

        /// <summary>
        /// Seçilen ürün adı
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Form'da gösterilecek feature'lar
        /// (sabit olanlar IsFixed=true, değişken olanlar dropdown)
        /// </summary>
        public List<StockCodeSaFormFeatureDto> Features { get; set; } = new();
    }
}