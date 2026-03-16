namespace MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör
{
    public class PriceUpdateDto
    {
        public Guid Id { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? TargetPrice { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}
