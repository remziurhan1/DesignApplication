namespace MVC.ProductManagement.Application.DTOs.StockCodes.Catalog
{
    public class StockProductGroupListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalCost { get; set; }
        public decimal AverageUnitCost { get; set; }
        public int ItemCount { get; set; }
    }

    public class StockProductGroupDetailDto : StockProductGroupListDto
    {
        public List<StockProductGroupItemDto> Items { get; set; } = new();
    }

    public class StockProductGroupItemDto
    {
        public Guid GeneratedStockCodeId { get; set; }
        public string GeneratedCode { get; set; } = default!;
        public string Description { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }
        public decimal KgEquivalentPerPrimaryUnit { get; set; }
        public decimal TotalWeightKg { get; set; }
    }

    public class StockProductGroupCreateDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public List<StockProductGroupItemCreateDto> Items { get; set; } = new();
    }

    public class StockProductGroupUpdateDto : StockProductGroupCreateDto
    {
        public Guid Id { get; set; }
    }

    public class StockProductGroupItemCreateDto
    {
        public Guid GeneratedStockCodeId { get; set; }
        public int Quantity { get; set; }
    }
}
