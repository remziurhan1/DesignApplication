namespace MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör
{
    public class PriceDto
    {
        public Guid Id { get; set; }
        public Guid StockCardId { get; set; }
        public string StockCode { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
    }
}
