using System;

namespace MVC.ProductManagement.Application.DTOs.EN13458DTOs
{
    public class EN13458MaterialCostRowDTO
    {
        public Guid? CostDetailId { get; set; }
        public string CostGroupCode { get; set; } = string.Empty;
        public string CostGroupName { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public string StockCode { get; set; } = string.Empty;
        public Guid? MaterialId { get; set; }
        public string MaterialName { get; set; } = string.Empty;
        public Guid? MaterialFormId { get; set; }
        public string FormType { get; set; } = string.Empty;

        public double Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;

        public double CalculatedThickness { get; set; }
        public double UsedThickness { get; set; }
        public double Density { get; set; }
        public double UnitPrice { get; set; }

        public double TheoreticalWeight { get; set; }
        public double ItemCost { get; set; }
    }
}
