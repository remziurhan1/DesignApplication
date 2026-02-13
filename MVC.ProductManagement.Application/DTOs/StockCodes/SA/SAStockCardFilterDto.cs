using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.SA
{
    /// <summary>
    /// SA Stok Kartı Filtreleme DTO
    /// </summary>
    public class SAStockCardFilterDto
    {
        /// <summary>
        /// Ürün ID (SAA0, SAB1, vs.)
        /// </summary>
        public Guid? ProductId { get; set; }

        /// <summary>
        /// Stok kodu ile arama (kısmi arama)
        /// </summary>
        public string? StockCode { get; set; }

        /// <summary>
        /// Feature filtresi: { FeatureId: ValueId }
        /// </summary>
        public Dictionary<Guid, Guid>? FeatureFilters { get; set; }

        /// <summary>
        /// Sayfa numarası
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// Sayfa başına kayıt
        /// </summary>
        public int PageSize { get; set; } = 50;
    }
}