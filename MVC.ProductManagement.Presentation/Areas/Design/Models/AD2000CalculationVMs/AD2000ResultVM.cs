using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs.AD2000DTOs;
using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Presentation.Areas.Design.Models.AD2000CalculationVMs
{
    public class AD2000ResultVM : AD2000CalculateVM
    {
        public Guid Id { get; set; }
        public string StorageTypeName { get; set; } = string.Empty;
        public string ShellMaterialName { get; set; } = string.Empty;
        public string ShellMaterialFormName { get; set; } = string.Empty;
        public string HeadMaterialName { get; set; } = string.Empty;
        public string HeadMaterialFormName { get; set; } = string.Empty;
        public double ShellThickness { get; set; }
        public double HeadThickness { get; set; }
        public double RoundedShellThickness { get; set; }
        public double RoundedHeadThickness { get; set; }
        public double TestPressure { get; set; }
        public Guid? SelectedCostAnalysisId { get; set; }
        public List<SelectListItem> AvailableStockGroups { get; set; } = new();
        public List<SelectListItem> AvailableStockCodes { get; set; } = new();
        public List<AD2000CostAnalysisSummaryDTO> CostAnalyses { get; set; } = new();
    }
}
