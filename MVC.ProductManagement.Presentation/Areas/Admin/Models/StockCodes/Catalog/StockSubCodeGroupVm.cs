using System.ComponentModel.DataAnnotations;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.Catalog
{
    public class StockSubCodeGroupVm
    {
        public Guid Id { get; set; }

        [Required]
        public Guid StockMainCodeGroupId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Code { get; set; } = default!;

        [Required]
        [MaxLength(250)]
        public string Name { get; set; } = default!;

        public bool IsEnabled { get; set; } = true;
    }
}
