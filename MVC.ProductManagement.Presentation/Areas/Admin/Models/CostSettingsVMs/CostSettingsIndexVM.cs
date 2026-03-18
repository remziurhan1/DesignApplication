using MVC.ProductManagement.Domain.Entities.Costing;
using System.ComponentModel.DataAnnotations;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.CostSettingsVMs
{
    public class CostSettingsIndexVM
    {
        public List<LaborRate> LaborRates { get; set; } = new();
        public List<GugHourlyRate> GugHourlyRates { get; set; } = new();
        public List<BombeLaborRate> BombeLaborRates { get; set; } = new();
        public List<OverheadRate> OverheadRates { get; set; } = new();

        public LaborRateInputVM NewLaborRate { get; set; } = new();
        public GugHourlyRateInputVM NewGugHourlyRate { get; set; } = new();
        public BombeLaborRateInputVM NewBombeLaborRate { get; set; } = new();
        public OverheadRateInputVM NewOverheadRate { get; set; } = new();
    }

    public class LaborRateInputVM
    {
        public Guid? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Range(0, double.MaxValue)] public double HourlyRate { get; set; }
        public string Notes { get; set; } = string.Empty;
    }

    public class GugHourlyRateInputVM
    {
        public Guid? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Range(0, double.MaxValue)] public double HourlyRate { get; set; }
        public string Notes { get; set; } = string.Empty;
    }

    public class BombeLaborRateInputVM
    {
        public Guid? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Required] public string MaterialType { get; set; } = string.Empty;
        [Range(0, double.MaxValue)] public double RatePerKg { get; set; }
        public string Notes { get; set; } = string.Empty;
    }

    public class OverheadRateInputVM
    {
        public Guid? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Required] public string OverheadType { get; set; } = string.Empty;
        [Range(0, double.MaxValue)] public double Percentage { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}
