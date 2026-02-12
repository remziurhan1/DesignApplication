
public class SfStockCodeGenerateRequestDto
{
    public Guid SProductId { get; set; }
    public Dictionary<Guid, Guid> SelectedFeatureValues { get; set; } = new();
}