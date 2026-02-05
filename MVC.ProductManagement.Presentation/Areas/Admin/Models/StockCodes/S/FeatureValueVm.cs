namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.S
{
    public class FeatureValueVm
    {
        public Guid ValueId { get; set; }
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
    }
}
