namespace MVC.ProductManagement.Application.DTOs.EN13458DTOs
{
    public class EN13458CostGroupSummaryDTO
    {
        public string CostGroupCode { get; set; } = string.Empty;
        public string CostGroupName { get; set; } = string.Empty;
        public double TotalCost { get; set; }
    }
}
