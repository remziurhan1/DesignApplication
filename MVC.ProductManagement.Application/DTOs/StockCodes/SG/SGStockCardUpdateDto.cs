using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.SG
{
    public class SGStockCardUpdateDto
    {
        public Guid StockCardId { get; set; }
        public Dictionary<Guid, Guid> FeatureSelections { get; set; } = new();
    }
}