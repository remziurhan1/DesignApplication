using MVC.ProductManagement.Application.DTOs.EN13458DTOs;
using AdminEN13458DetailsVM = MVC.ProductManagement.Presentation.Areas.Admin.Models.EN13458CalculationVMs.EN13458DetailsVM;

namespace MVC.ProductManagement.Presentation.Services.EN13458
{
    public interface IEN13458AdminExportService
    {
        byte[] BuildDetailExcel(AdminEN13458DetailsVM vm, EN13458MaterialCostTableDTO costTable);
    }
}
