using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.S
{
    public class SStockCodeGenerateVm
    {
        public Guid FluidId { get; set; }
        public Guid SProductGroupId { get; set; }
        public Guid SProductId { get; set; }

        // Legacy (şimdilik kalabilir)
        public Guid PrefixRuleId { get; set; }
        public List<SelectListItem> PrefixRules { get; set; } = new();

        public List<SelectListItem> Fluids { get; set; } = new();
        public List<SelectListItem> Groups { get; set; } = new();
        public List<SelectListItem> Products { get; set; } = new();

        // ✅ Dinamik feature seçimleri (POST ile dolacak)
        // Key = FeatureId, Value = FeatureValueId
        public Dictionary<Guid, Guid> SelectedFeatureValues { get; set; } = new();

        // çıktı
        public string? StockCode8 { get; set; }
        public string? Description { get; set; }
        public bool? AlreadyExists { get; set; }
        public string? ErrorMessage { get; set; }

        // ✅ Prefix4 string olmalı (view input text)
        public string? Prefix4 { get; set; }
    }
}
