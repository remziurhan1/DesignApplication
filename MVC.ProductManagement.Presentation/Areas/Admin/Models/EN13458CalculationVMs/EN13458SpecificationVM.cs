using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.EN13458CalculationVMs
{
    public class EN13458SpecificationVM
    {
        public Guid Id { get; set; }
        public Guid? SelectedCostAnalysisId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DocumentTitle { get; set; } = string.Empty;
        public string RevisionCode { get; set; } = "Ön İzleme";
        public DateTime GeneratedAtUtc { get; set; }

        public string ProductDescription { get; set; } = string.Empty;
        public string IntendedService { get; set; } = string.Empty;
        public string DesignCodeText { get; set; } = "TS EN 13458";
        public string InsulationText { get; set; } = "Vakum + perlit izolasyon";
        public string OrientationText { get; set; } = string.Empty;
        public string ColdStretchText { get; set; } = string.Empty;

        public double NetVolumeM3 { get; set; }
        public double GrossVolumeM3 { get; set; }
        public double WorkingPressureBar { get; set; }
        public double TestPressureBar { get; set; }
        public double StaticPressureBar { get; set; }
        public double InnerDiameterMm { get; set; }
        public double OuterDiameterMm { get; set; }
        public double ShellLengthMm { get; set; }
        public double TotalLengthMm { get; set; }
        public double LiquidDensity { get; set; }
        public double PerliteWeightKg { get; set; }
        public double InnerTankWeightKg { get; set; }
        public double OuterTankWeightKg { get; set; }
        public double TotalWeldLengthM { get; set; }

        public string InnerShellMaterial { get; set; } = string.Empty;
        public string InnerHeadMaterial { get; set; } = string.Empty;
        public string OuterShellMaterial { get; set; } = string.Empty;
        public string OuterHeadMaterial { get; set; } = string.Empty;
        public string InnerShellForm { get; set; } = string.Empty;
        public string InnerHeadForm { get; set; } = string.Empty;
        public string OuterShellForm { get; set; } = string.Empty;
        public string OuterHeadForm { get; set; } = string.Empty;

        public double InnerShellThicknessMm { get; set; }
        public double InnerHeadThicknessMm { get; set; }
        public double OuterShellThicknessMm { get; set; }
        public double OuterHeadThicknessMm { get; set; }

        public List<EN13458SpecificationItemVM> SummaryItems { get; set; } = new();
        public List<EN13458SpecificationItemVM> MaterialItems { get; set; } = new();
        public List<EN13458SpecificationItemVM> PerformanceItems { get; set; } = new();
        public List<EN13458AccessoryItemVM> AccessoryItems { get; set; } = new();
        public List<string> StandardNotes { get; set; } = new();
        public List<string> ScopeItems { get; set; } = new();
    }

    public class EN13458SpecificationItemVM
    {
        public string Label { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }

    public class EN13458AccessoryItemVM
    {
        public string GroupName { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public string StockCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
    }
