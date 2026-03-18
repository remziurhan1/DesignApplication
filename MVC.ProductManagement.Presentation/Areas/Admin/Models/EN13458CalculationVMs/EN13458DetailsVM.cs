using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs.EN13458DTOs;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.EN13458CalculationVMs
{
    public class EN13458DetailsVM : EN13458ResultVM
    {
        public Guid? SelectedCostAnalysisId { get; set; }
        public List<SelectListItem> AvailableStockGroups { get; set; } = new();
        public List<SelectListItem> AvailableStockCodes { get; set; } = new();
        public List<EN13458CostAnalysisSummaryDTO> CostAnalyses { get; set; } = new();
    }
}
