// ===== GENERATE VIEW MODEL =====
using MVC.ProductManagement.Application.DTOs.StockCodes.SF;
namespace MVC.ProductManagement.Application.DTOs.StockCodes.SF
{

    public class SFStockCodeGenerateDto
    {
        public Guid SProductId { get; set; }
        public List<SfProductDto> Products { get; set; } = new();
        public Dictionary<Guid, Guid> SelectedFeatureValues { get; set; } = new();
        public string? StockCode8 { get; set; }
        public string? Description { get; set; }
        public bool? AlreadyExists { get; set; }
        public string? ErrorMessage { get; set; }
    }
}