namespace MVC.ProductManagement.Application.DTOs.StockCodes.SF
{// ===== FORM DTO (GetFormData) =====
    public class StockCodeSfFormDto
    {
        public Guid ProductId { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public List<StockCodeSfFormFeatureDto> Features { get; set; } = new();
    }
}