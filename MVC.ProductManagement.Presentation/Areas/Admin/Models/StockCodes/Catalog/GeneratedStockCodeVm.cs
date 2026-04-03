using System.ComponentModel.DataAnnotations;
using MVC.ProductManagement.Domain.Enums;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.Catalog
{
    public class GeneratedStockCodeVm
    {
        public Guid Id { get; set; }

        [Required]
        public Guid StockSubCodeGroupId { get; set; }

        public Guid? StockSubCodeRuleId { get; set; }

        public List<Guid> SelectedRuleIds { get; set; } = new();

        [StringLength(8, MinimumLength = 8)]
        public string? GeneratedCode { get; set; }

        [MaxLength(250)]
        public string? RuleName { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        [Range(0, 999999999)]
        public decimal? UnitPrice { get; set; }

        [Range(0, 999999999)]
        public decimal? TargetPrice { get; set; }

        [Required]
        public PrimaryUnitType PrimaryUnitType { get; set; } = PrimaryUnitType.Adet;

        [Range(0.0001, 999999999)]
        public decimal KgEquivalentPerPrimaryUnit { get; set; } = 1m;
    }
}
