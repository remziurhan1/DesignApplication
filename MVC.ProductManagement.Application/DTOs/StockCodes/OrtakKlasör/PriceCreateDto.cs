namespace MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör
{
    public class PriceCreateDto
    {
        public Guid StockCardId { get; set; }
        public string Currency { get; set; } = "TRY";
        public decimal UnitPrice { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}
