namespace MVC.ProductManagement.Application.DTOs.MaterialCatalogDTOs
{
    public class MaterialPriceDto
    {
        public Guid? MaterialId { get; set; }
        public string Grade { get; set; } = string.Empty;
        public Guid StockCardId { get; set; }
        public string StockCode { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public decimal? TargetPrice { get; set; }
        public string Currency { get; set; } = string.Empty;
        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
    }
}
