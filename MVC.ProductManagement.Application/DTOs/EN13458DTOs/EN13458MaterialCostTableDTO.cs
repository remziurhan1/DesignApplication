using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Application.DTOs.EN13458DTOs
{
    public class EN13458MaterialCostTableDTO
    {
        public Guid? CostAnalysisId { get; set; }
        public Guid? EN13458CalculationId { get; set; }
        public int RevisionNo { get; set; }
        public string RevisionCode { get; set; } = string.Empty;
        public string AnalysisName { get; set; } = string.Empty;
        public DateTime? CreatedDate { get; set; }
        public bool IsPreview { get; set; }
        public List<EN13458MaterialCostRowDTO> Items { get; set; } = new();
        public List<EN13458CostGroupSummaryDTO> GroupTotals { get; set; } = new();
        public double TotalMaterialCost { get; set; }
        public double TotalFilmCost { get; set; }
        public double GrandTotalCost { get; set; }
    }
}
