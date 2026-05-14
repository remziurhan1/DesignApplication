using System;

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
    }
}
