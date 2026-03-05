using System;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.SA.Properties
{
    public class SaStockCodePropertyUpdateDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid FeatureId { get; set; }
        public bool IsFixed { get; set; }
        public Guid? FixedValueId { get; set; }
    }
}
