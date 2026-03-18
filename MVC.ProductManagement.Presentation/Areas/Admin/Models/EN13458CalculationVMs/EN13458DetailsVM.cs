using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.EN13458CalculationVMs
{
    public class EN13458DetailsVM : EN13458ResultVM
    {
        public List<SelectListItem> AvailableStockGroups { get; set; } = new();
        public List<SelectListItem> AvailableStockCodes { get; set; } = new();
    }
}
