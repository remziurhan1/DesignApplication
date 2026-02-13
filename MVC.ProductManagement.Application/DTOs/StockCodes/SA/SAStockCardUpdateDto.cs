using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.SA
{
    /// <summary>
    /// SA Stok Kartı Güncelleme DTO
    /// </summary>
    public class SAStockCardUpdateDto
    {
        public Guid StockCardId { get; set; }

        /// <summary>
        /// Feature seçimleri: { FeatureId: ValueId }
        /// </summary>
        public Dictionary<Guid, Guid> FeatureSelections { get; set; } = new();
    }
}