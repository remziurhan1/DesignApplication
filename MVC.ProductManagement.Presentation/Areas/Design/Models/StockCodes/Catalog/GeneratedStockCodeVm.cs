using System.ComponentModel.DataAnnotations;
using MVC.ProductManagement.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace MVC.ProductManagement.Presentation.Areas.Design.Models.StockCodes.Catalog
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

        public string? Step3DFilePath { get; set; }
        public string? DxfFilePath1 { get; set; }
        public string? DxfFilePath2 { get; set; }
        public string? DatasheetFilePath { get; set; }

        public IFormFile? Step3DFile { get; set; }
        public IFormFile? DxfFile1 { get; set; }
        public IFormFile? DxfFile2 { get; set; }
        public IFormFile? DatasheetFile { get; set; }
    }
}
