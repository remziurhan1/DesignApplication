namespace MVC.ProductManagement.Infrastructure.Repositories.SalesRequestRepositories.DTOs;

public class LinkedPricingSnapshotDto
{
    public string CalculationName { get; set; } = string.Empty;
    public Guid CostAnalysisId { get; set; }
    public string RevisionCode { get; set; } = string.Empty;
    public decimal TotalCost { get; set; }
    public decimal? MinimumSalesPrice { get; set; }
    public decimal? RecommendedSalesPrice { get; set; }
}
