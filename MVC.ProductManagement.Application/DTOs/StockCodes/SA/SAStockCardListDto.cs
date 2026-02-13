using System;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.SA
{
    /// <summary>
    /// SA Stok Kartı Listeleme DTO
    /// </summary>
    public class SAStockCardListDto
    {
        public Guid Id { get; set; }
        public string StockCode8 { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
    }
}