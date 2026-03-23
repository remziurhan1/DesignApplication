using System;

namespace MVC.ProductManagement.Application.DTOs.AD2000DTOs
{
    public class AD2000CostAnalysisSummaryDTO
    {
        public Guid Id { get; set; }
        public Guid AD2000CalculationId { get; set; }
        public int RevisionNo { get; set; }
        public string RevisionCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public double GrandTotalCost { get; set; }
    }
}
