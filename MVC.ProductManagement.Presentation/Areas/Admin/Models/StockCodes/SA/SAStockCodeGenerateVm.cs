using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs.StockCodes.SF;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.SA
{
    public class SAStockCodeGenerateVm
    {
        public Guid SProductId { get; set; }

        public List<SelectListItem> Products { get; set; } = new();
        // ✅ YENİ: Feature seçimleri (Metrik + Boy)
        // ✅ YENİ: Feature'lar (Metrik, Boy)
        public IReadOnlyList<FeatureDto> Features { get; set; } = new List<FeatureDto>();

        public Dictionary<Guid, Guid> SelectedFeatureValues { get; set; } = new();

        // Sonuç
        public string? StockCode8 { get; set; }
        public string? Description { get; set; }
        public bool? AlreadyExists { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
