namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.S
{
    public class FeatureVm
    {
        public Guid FeatureId { get; set; }
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public bool IsRequired { get; set; }
        public int SortOrder { get; set; }

        public List<FeatureValueVm> Values { get; set; } = new();
    }
}
