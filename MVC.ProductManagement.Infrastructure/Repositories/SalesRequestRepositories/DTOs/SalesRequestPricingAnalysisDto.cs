using MVC.ProductManagement.Domain.Enums;

namespace MVC.ProductManagement.Infrastructure.Repositories.SalesRequestRepositories.DTOs;

public class SalesRequestPricingAnalysisDto
{
    public SalesRequestCalculationType CalculationType { get; set; }
    public Guid CalculationId { get; set; }
    public Guid CostAnalysisId { get; set; }
    public string CalculationName { get; set; } = string.Empty;
    public string RevisionCode { get; set; } = string.Empty;
    public decimal TotalCost { get; set; }
    public decimal? MinimumSalesPrice { get; set; }
    public decimal? RecommendedSalesPrice { get; set; }
}
