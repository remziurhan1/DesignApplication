using System;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.AD2000CalculationVMs
{
    public class AD2000ListVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double DesignPressure { get; set; }
        public double RoundedShellThickness { get; set; }
        public double RoundedHeadThickness { get; set; }
    }
}
