using System;

namespace MVC.ProductManagement.Application.DTOs.EN13458DTOs
{
    public class EN13458CostAnalysisSummaryDTO
    {
        public Guid Id { get; set; }
        public Guid EN13458CalculationId { get; set; }
        public int RevisionNo { get; set; }
        public string RevisionCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public double GrandTotalCost { get; set; }
        public double? MinimumSalesPrice { get; set; }
        public double? RecommendedSalesPrice { get; set; }
    }
}
