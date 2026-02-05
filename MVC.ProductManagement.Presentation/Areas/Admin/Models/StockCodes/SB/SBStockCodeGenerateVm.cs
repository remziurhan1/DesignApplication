using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.SB
{
    public class SBStockCodeGenerateVm
    {
        public Guid FluidId { get; set; }
        public Guid SProductId { get; set; }

        public List<SelectListItem> Fluids { get; set; } = new();
        public List<SelectListItem> Products { get; set; } = new();

        // Sonuç
        public string? StockCode8 { get; set; }
        public string? Description { get; set; }
        public bool? AlreadyExists { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
