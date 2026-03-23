using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Application.DTOs.AD2000DTOs
{
    public class AD2000MaterialCostTableDTO
    {
        public Guid? CostAnalysisId { get; set; }
        public Guid? AD2000CalculationId { get; set; }
        public int RevisionNo { get; set; }
        public string RevisionCode { get; set; } = string.Empty;
        public string AnalysisName { get; set; } = string.Empty;
        public DateTime? CreatedDate { get; set; }
        public bool IsPreview { get; set; }
        public Guid? HeadBombeLaborRateId { get; set; }
        public List<AD2000MaterialCostRowDTO> Items { get; set; } = new();
        public List<AD2000CostGroupSummaryDTO> GroupTotals { get; set; } = new();
        public double TotalMaterialCost { get; set; }
        public double GrandTotalCost { get; set; }
        public AD2000SalesPriceDTO? SalesPrice { get; set; }
    }
}
