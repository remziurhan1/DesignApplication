using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.SA
{
    public class SAStockCodeGenerateVm
    {
        // ===== Seçimler =====
        public Guid FluidId { get; set; }
        public Guid SProductGroupId { get; set; }   // SA için A gelecek
        public Guid SProductId { get; set; }

        // ===== Dropdownlar =====
        public List<SelectListItem> Fluids { get; set; } = new();
        public List<SelectListItem> Groups { get; set; } = new();
        public List<SelectListItem> Products { get; set; } = new();

        // ===== Sonuç =====
        public string? StockCode8 { get; set; }
        public string? Description { get; set; }
        public bool? AlreadyExists { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
