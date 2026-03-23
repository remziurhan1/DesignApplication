using System;
using MVC.ProductManagement.Domain.Core.BaseEntities;
using MVC.ProductManagement.Domain.Entities;

namespace MVC.ProductManagement.Domain.Entities.Costing
{
    public class AD2000SalesPrice : AuditableEntity
    {
        public Guid AD2000CalculationId { get; set; }
        public virtual AD2000Calculation AD2000Calculation { get; set; } = null!;

        public Guid AD2000CostAnalysisId { get; set; }
        public virtual AD2000CostAnalysis AD2000CostAnalysis { get; set; } = null!;

        public Guid LaborRateId { get; set; }
        public virtual LaborRate LaborRate { get; set; } = null!;

        public Guid GugHourlyRateId { get; set; }
        public virtual GugHourlyRate GugHourlyRate { get; set; } = null!;

        public Guid FinanceOverheadRateId { get; set; }
        public virtual OverheadRate FinanceOverheadRate { get; set; } = null!;

        public Guid GeneralManagementOverheadRateId { get; set; }
        public virtual OverheadRate GeneralManagementOverheadRate { get; set; } = null!;

        public double LaborHours { get; set; }
        public double ProfitPercentage { get; set; }
        public double LaborCost { get; set; }
        public double GugCost { get; set; }
        public double ImmCost { get; set; }
        public double AraToplam1 { get; set; }
        public double FinanceCost { get; set; }
        public double GeneralManagementCost { get; set; }
        public double AraToplam2 { get; set; }
        public double MinimumSalesPrice { get; set; }
        public double SalesPrice { get; set; }
    }
}
