using System;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.SA.Properties
{
    public class SaStockCodePropertyListDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public Guid FeatureId { get; set; }
        public string FeatureCode { get; set; }
        public string FeatureName { get; set; }
        public bool IsFixed { get; set; }
        public Guid? FixedValueId { get; set; }
        public string FixedValueCode { get; set; }
        public string FixedValueName { get; set; }
        public int SortOrder { get; set; }
        public bool IsRequired { get; set; }
    }
}
