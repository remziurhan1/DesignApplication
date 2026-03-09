using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.SE
{
    public class SEStockCardUpdateDto
    {
        public Guid StockCardId { get; set; }
        public Dictionary<Guid, Guid> FeatureSelections { get; set; } = new();
    }
}