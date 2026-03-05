using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.SA.Properties
{
    public class SaStockCodePropertyVm
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid FeatureId { get; set; }
        public bool IsFixed { get; set; }
        public Guid? FixedValueId { get; set; }

        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string FeatureCode { get; set; }
        public string FeatureName { get; set; }
        public string FixedValueCode { get; set; }
        public string FixedValueName { get; set; }

        public List<SelectListItem> Products { get; set; } = new();
        public List<SelectListItem> Features { get; set; } = new();
        public List<SelectListItem> FeatureValues { get; set; } = new();
    }
}
