using System.ComponentModel.DataAnnotations;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.Catalog
{
    public class StockMainCodeGroupVm
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Code { get; set; } = default!;

        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = default!;

        public bool IsEnabled { get; set; } = true;
    }
}
