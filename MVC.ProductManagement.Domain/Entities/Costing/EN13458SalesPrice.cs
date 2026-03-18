using MVC.ProductManagement.Domain.Core.BaseEntities;

namespace MVC.ProductManagement.Domain.Entities.Costing
{
    public class EN13458SalesPrice : AuditableEntity
    {
        public Guid EN13458CalculationId { get; set; }
        public virtual EN13458Calculation EN13458Calculation { get; set; } = null!;

        public Guid EN13458CostAnalysisId { get; set; }
        public virtual EN13458CostAnalysis EN13458CostAnalysis { get; set; } = null!;

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
        public double SalesPrice { get; set; }
    }
}
