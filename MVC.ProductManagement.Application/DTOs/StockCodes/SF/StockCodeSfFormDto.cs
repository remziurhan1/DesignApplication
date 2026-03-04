namespace MVC.ProductManagement.Application.DTOs.StockCodes.SF
{
    // ===== FORM DTO (GetFormData) =====
    public class StockCodeSfFormDto
    {
        public Guid ProductId { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string ProductSegment { get; set; } = string.Empty;
        public List<string> SegmentFeatureSummary { get; set; } = new();
        public List<string> FilterHints { get; set; } = new();
        public List<StockCodeSfFormFeatureDto> Features { get; set; } = new();
    }
}
