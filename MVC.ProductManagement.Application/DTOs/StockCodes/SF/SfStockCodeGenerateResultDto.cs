public class SfStockCodeGenerateResultDto
{
    public bool AlreadyExists { get; set; }
    public Guid StockCardId { get; set; }
    public string StockCode8 { get; set; } = string.Empty;
    public string Prefix4 { get; set; } = string.Empty;
    public int Serial4 { get; set; }
    public string Description { get; set; } = string.Empty;
}