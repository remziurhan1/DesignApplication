namespace MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör
{
    public class ActivePriceDto
    {
        public Guid Id { get; set; }
        public Guid StockCardId { get; set; }
        public string StockCode { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public decimal? TargetPrice { get; set; }
        public DateTime PriceDate { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public Guid? SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}
