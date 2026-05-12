using MVC.ProductManagement.Application.DTOs.EN13458DTOs;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.EN13458CalculationVMs;

namespace MVC.ProductManagement.Presentation.Services.EN13458
{
    public interface IEN13458AdminExportService
    {
        byte[] BuildDetailExcel(EN13458DetailsVM vm, EN13458MaterialCostTableDTO costTable);
    }
}
