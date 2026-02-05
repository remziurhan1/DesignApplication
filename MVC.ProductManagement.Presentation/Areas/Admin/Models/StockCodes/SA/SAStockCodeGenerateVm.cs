using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.SA
{
    public class SAStockCodeGenerateVm
    {
        public Guid SProductId { get; set; }

        public List<SelectListItem> Products { get; set; } = new();

        // Sonuç
        public string? StockCode8 { get; set; }
        public string? Description { get; set; }
        public bool? AlreadyExists { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
