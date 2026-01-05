using MVC.ProductManagement.Domain.Enums;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.MaterialFormVms
{
    public class MaterialFormListVm
    {
        public Guid Id { get; set; }
        public Guid MaterialId { get; set; }
        public MaterialFormType FormType { get; set; }
        public double ThicknessMin { get; set; }
        public double ThicknessMax { get; set; }
        public double UnitPrice { get; set; }
        public string MaterialName { get; set; }

    }
}
