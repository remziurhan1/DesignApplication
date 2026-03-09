using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.SH
{
    public class SHStockCardUpdateDto
    {
        public Guid StockCardId { get; set; }
        public Dictionary<Guid, Guid> FeatureSelections { get; set; } = new();
    }
}