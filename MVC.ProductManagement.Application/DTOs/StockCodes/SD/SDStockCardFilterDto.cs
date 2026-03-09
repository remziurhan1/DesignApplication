using System;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.SD
{
    public class SDStockCardFilterDto
    {
        public string? SearchTerm { get; set; }
        public Guid? ProductId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}