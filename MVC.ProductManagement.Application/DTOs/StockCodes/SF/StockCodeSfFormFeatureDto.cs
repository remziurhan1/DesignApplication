using MVC.ProductManagement.Application.DTOs.StockCodes.SF;

public class StockCodeSfFormFeatureDto
{
    public Guid FeatureId { get; set; }
    public string FeatureCode { get; set; } = string.Empty;
    public string FeatureName { get; set; } = string.Empty;
    public string FeatureGroup { get; set; } = "Diğer";
    public bool IsFixed { get; set; }
    public Guid? FixedValueId { get; set; }
    public string? FixedValueCode { get; set; }
    public string? FixedValueName { get; set; }
    public List<SfFeatureValueOptionDto> AvailableValues { get; set; } = new();
}
