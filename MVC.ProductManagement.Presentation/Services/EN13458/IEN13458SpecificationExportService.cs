using MVC.ProductManagement.Presentation.Areas.Admin.Models.EN13458CalculationVMs;

namespace MVC.ProductManagement.Presentation.Services.EN13458
{
    public interface IEN13458SpecificationExportService
    {
        Task<byte[]> BuildWordDocumentAsync(string templatePath, EN13458SpecificationVM specification);
    }
}
