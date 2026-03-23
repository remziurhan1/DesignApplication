using System;

namespace MVC.ProductManagement.Application.DTOs.AD2000DTOs
{
    public class AD2000MaterialCostRowDTO
    {
        public Guid? CostAnalysisItemId { get; set; }
        public Guid? CostAnalysisId { get; set; }
        public int SortOrder { get; set; }
        public string ItemKey { get; set; } = string.Empty;
        public string ItemSourceType { get; set; } = string.Empty;
        public string CostGroupCode { get; set; } = string.Empty;
        public string CostGroupName { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public string StockCode { get; set; } = string.Empty;
        public string StockCodeName { get; set; } = string.Empty;
        public Guid? GeneratedStockCodeId { get; set; }
        public Guid? MaterialId { get; set; }
        public string MaterialName { get; set; } = string.Empty;
        public Guid? MaterialFormId { get; set; }
        public string FormType { get; set; } = string.Empty;
        public double Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
        public double CalculatedThickness { get; set; }
        public double UsedThickness { get; set; }
        public double Density { get; set; }
        public double StockUnitPrice { get; set; }
        public bool UseManualUnitPrice { get; set; }
        public double? ManualUnitPrice { get; set; }
        public double UnitPrice { get; set; }
        public double TheoreticalWeight { get; set; }
        public double ItemCost { get; set; }
        public bool IsCalculated => string.Equals(ItemSourceType, "Calculated", StringComparison.OrdinalIgnoreCase);
        public bool IsManual => string.Equals(ItemSourceType, "Manual", StringComparison.OrdinalIgnoreCase) || string.Equals(ItemSourceType, "ManualGroup", StringComparison.OrdinalIgnoreCase);
        public bool IsBombeLabor => ItemKey.StartsWith("BOMBE-LABOR-", StringComparison.OrdinalIgnoreCase);
    }
}
