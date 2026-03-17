using System.ComponentModel.DataAnnotations;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.Catalog
{
    public class StockSubCodeRuleVm
    {
        public Guid Id { get; set; }

        [Required]
        public Guid StockSubCodeGroupId { get; set; }

        [Required]
        [MaxLength(50)]
        public string RuleCode { get; set; } = default!;

        [Required]
        [MaxLength(250)]
        public string RuleName { get; set; } = default!;

        [MaxLength(1000)]
        public string? Description { get; set; }

        [Range(0, 999999999)]
        public decimal UnitPrice { get; set; }

        [Range(0, 999999999)]
        public decimal TargetPrice { get; set; }

        public bool IsEnabled { get; set; } = true;
    }
}
