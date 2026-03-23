namespace MVC.ProductManagement.Application.DTOs.AD2000DTOs
{
    public class AD2000CostGroupSummaryDTO
    {
        public string CostGroupCode { get; set; } = string.Empty;
        public string CostGroupName { get; set; } = string.Empty;
        public double TotalCost { get; set; }
    }
}
