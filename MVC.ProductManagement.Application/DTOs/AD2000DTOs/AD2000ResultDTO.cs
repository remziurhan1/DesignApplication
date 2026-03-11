using System;

namespace MVC.ProductManagement.Application.DTOs.AD2000DTOs
{
    public class AD2000ResultDTO : AD2000CalculateDTO
    {
        public double ShellThickness { get; set; }
        public double HeadThickness { get; set; }
        public double RoundedShellThickness { get; set; }
        public double RoundedHeadThickness { get; set; }
        public double TestPressure { get; set; }
    }
}
