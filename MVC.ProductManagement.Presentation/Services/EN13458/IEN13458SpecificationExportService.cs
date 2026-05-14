using AdminEN13458SpecificationVM = MVC.ProductManagement.Presentation.Areas.Admin.Models.EN13458CalculationVMs.EN13458SpecificationVM;
using DesignEN13458SpecificationVM = MVC.ProductManagement.Presentation.Areas.Design.Models.EN13458CalculationVMs.EN13458SpecificationVM;

namespace MVC.ProductManagement.Presentation.Services.EN13458
{
    public interface IEN13458SpecificationExportService
    {
        Task<byte[]> BuildWordDocumentAsync(string templatePath, AdminEN13458SpecificationVM specification);
        Task<byte[]> BuildWordDocumentAsync(string templatePath, DesignEN13458SpecificationVM specification);
    }
}
