namespace MVC.ProductManagement.Application.DTOs.MaterialCatalogDTOs
{
    public class MaterialStockCardDto
    {
        public Guid Id { get; set; }
        public Guid? MaterialId { get; set; }
        public string StockCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Unit { get; set; }
        public bool IsActive { get; set; }
    }
}
