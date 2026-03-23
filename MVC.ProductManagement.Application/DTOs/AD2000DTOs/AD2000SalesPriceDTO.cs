using System;

namespace MVC.ProductManagement.Application.DTOs.AD2000DTOs
{
    public class AD2000SalesPriceDTO
    {
        public Guid? Id { get; set; }
        public Guid AD2000CalculationId { get; set; }
        public Guid AD2000CostAnalysisId { get; set; }
        public Guid? LaborRateId { get; set; }
        public Guid? GugHourlyRateId { get; set; }
        public Guid? FinanceOverheadRateId { get; set; }
        public Guid? GeneralManagementOverheadRateId { get; set; }
        public double LaborHours { get; set; }
        public double ProfitPercentage { get; set; }
        public double LaborHourlyRate { get; set; }
        public double GugHourlyRateValue { get; set; }
        public double FinancePercentage { get; set; }
        public double GeneralManagementPercentage { get; set; }
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
