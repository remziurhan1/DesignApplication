using MVC.ProductManagement.Application.DTOs.StockCodes.Catalog;
using MVC.ProductManagement.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MVC.ProductManagement.Presentation.Areas.Design.Models.StockCodes.Catalog
{
    public class GeneratedStockCodeInventoryVm
    {
        public Guid GeneratedStockCodeId { get; set; }
        public string GeneratedCode { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int CurrentStock { get; set; }
        public List<GeneratedStockCodeInventoryMovementDto> Movements { get; set; } = new();
        public List<StockProductGroupOptionVm> StockProductGroups { get; set; } = new();

        [Required]
        public InventoryMovementType MovementType { get; set; } = InventoryMovementType.In;

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        public DateTime MovementDate { get; set; } = DateTime.UtcNow;

        public Guid? StockProductGroupId { get; set; }

        [MaxLength(200)]
        public string? ReferenceDocument { get; set; }

        [MaxLength(1000)]
        public string? MovementDescription { get; set; }
    }

    public class StockProductGroupOptionVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
