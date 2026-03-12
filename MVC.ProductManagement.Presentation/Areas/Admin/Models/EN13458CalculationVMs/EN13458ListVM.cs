using System;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.EN13458CalculationVMs
{
    public class EN13458ListVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double OuterDiameter { get; set; }
        public double OuterTankDiameter { get; set; }
        public double ShellLength { get; set; }
        public double Pressure { get; set; }
        public double RoundedInnerShellThickness { get; set; }
        public double RoundedOuterShellThickness { get; set; }
    }
}
