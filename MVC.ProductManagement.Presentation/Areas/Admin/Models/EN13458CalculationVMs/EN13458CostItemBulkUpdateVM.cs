using System;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.EN13458CalculationVMs
{
    public class EN13458CostItemBulkUpdateVM
    {
        public Guid CostAnalysisItemId { get; set; }
        public Guid? GeneratedStockCodeId { get; set; }
        public double? Quantity { get; set; }
        public bool UseManualUnitPrice { get; set; }
        public double? ManualUnitPrice { get; set; }
    }
}
