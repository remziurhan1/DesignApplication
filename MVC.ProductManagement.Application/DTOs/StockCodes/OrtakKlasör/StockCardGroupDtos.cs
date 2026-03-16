using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör
{
    public class StockCardGroupCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string CurrencyCode { get; set; } = "EUR";
        public List<StockCardGroupCreateItemDto> Items { get; set; } = new();
    }

    public class StockCardGroupCreateItemDto
    {
        public Guid? StockCardId { get; set; }
        public int Quantity { get; set; }
        public bool IsCustomItem { get; set; }
        public string? CustomDescription { get; set; }
        public string? QuantityUnit { get; set; }
        public decimal? UnitPrice { get; set; }
    }

    public class StockCardGroupListItemDto
    {
        public Guid Id { get; set; }
        public string GroupCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string CurrencyCode { get; set; } = string.Empty;
        public int ItemCount { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class StockCardGroupDetailDto
    {
        public Guid Id { get; set; }
        public string GroupCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string CurrencyCode { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public List<StockCardGroupItemDto> Items { get; set; } = new();
    }

    public class StockCardGroupItemDto
    {
        public Guid ItemId { get; set; }
        public Guid? StockCardId { get; set; }
        public bool IsCustomItem { get; set; }
        public string StockCode8 { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string QuantityUnit { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
    }

    public class StockCardLookupDto
    {
        public Guid StockCardId { get; set; }
        public string StockCode8 { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
