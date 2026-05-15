using MVC.ProductManagement.Application.DTOs.StockCodes.Catalog;
using System.ComponentModel.DataAnnotations;

namespace MVC.ProductManagement.Presentation.Areas.Design.Models.StockCodes.Catalog
{
    public class StockProductGroupVm
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = default!;

        [MaxLength(1000)]
        public string? Description { get; set; }

        public int TotalQuantity { get; set; }
        public decimal TotalCost { get; set; }
        public string ItemsJson { get; set; } = "[]";

        public List<GeneratedStockCodeListDto> AvailableCodes { get; set; } = new();
        public List<StockProductGroupItemVm> ExistingItems { get; set; } = new();
    }

    public class StockProductGroupItemVm
    {
        public Guid GeneratedStockCodeId { get; set; }
        public string GeneratedCode { get; set; } = default!;
        public string Description { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }
    }
}
