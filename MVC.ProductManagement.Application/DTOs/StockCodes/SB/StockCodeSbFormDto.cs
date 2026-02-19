using MVC.ProductManagement.Application.DTOs.StockCodes.SA;
using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.SB
{
    public class StockCodeSbFormDto
    {
        public Guid ProductId { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public List<StockCodeSbFormFeatureDto> Features { get; set; } = new();
    }
}