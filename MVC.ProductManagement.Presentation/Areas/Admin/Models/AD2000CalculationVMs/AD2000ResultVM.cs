using System;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.AD2000CalculationVMs
{
    public class AD2000ResultVM : AD2000CalculateVM
    {
        public double ShellThickness { get; set; }
        public double HeadThickness { get; set; }
        public double RoundedShellThickness { get; set; }
        public double RoundedHeadThickness { get; set; }
        public double TestPressure { get; set; }
    }
}
