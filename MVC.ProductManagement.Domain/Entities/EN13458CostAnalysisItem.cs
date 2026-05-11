using MVC.ProductManagement.Domain.Core.BaseEntities;
using System;

namespace MVC.ProductManagement.Domain.Entities
{
    public class EN13458CostAnalysisItem : AuditableEntity
    {
        public Guid EN13458CostAnalysisId { get; set; }
        public virtual EN13458CostAnalysis EN13458CostAnalysis { get; set; } = null!;

        public int SortOrder { get; set; }
        public string ItemKey { get; set; } = string.Empty;
        public string ItemSourceType { get; set; } = string.Empty;
        public string CostGroupCode { get; set; } = string.Empty;
        public string CostGroupName { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;

        public Guid? MaterialId { get; set; }
        public string MaterialName { get; set; } = string.Empty;
        public Guid? MaterialFormId { get; set; }
        public string FormType { get; set; } = string.Empty;

        public string MaterialNumber { get; set; } = string.Empty;
        public string MaterialClass { get; set; } = string.Empty;
        public string MaterialFamily { get; set; } = string.Empty;
        public string Norm { get; set; } = string.Empty;
        public string ProductStandard { get; set; } = string.Empty;
        public string SymbolicName { get; set; } = string.Empty;

        public Guid? GeneratedStockCodeId { get; set; }
        public string StockCode { get; set; } = string.Empty;
        public string StockCodeName { get; set; } = string.Empty;

        public double Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
        public double CalculatedThickness { get; set; }
        public double UsedThickness { get; set; }
        public double Density { get; set; }
        public double TheoreticalWeight { get; set; }

        public double UsedYieldStrength { get; set; }
        public double UsedDesignStress { get; set; }
        public double UsedTemperature { get; set; }
        public double UsedThicknessBandMin { get; set; }
        public double UsedThicknessBandMax { get; set; }
        public string DensitySource { get; set; } = string.Empty;
        public string PriceSource { get; set; } = string.Empty;

        public bool UseManualUnitPrice { get; set; }
        public double? ManualUnitPrice { get; set; }
        public double StockUnitPrice { get; set; }
        public double UnitPrice { get; set; }
        public double ItemCost { get; set; }
    }
}
