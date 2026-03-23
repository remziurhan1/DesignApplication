using MVC.ProductManagement.Domain.Core.BaseEntities;
using MVC.ProductManagement.Domain.Enums;

namespace MVC.ProductManagement.Domain.Entities.SalesRequests
{
    public class SalesRequestItem : AuditableEntity
    {
        public Guid SalesRequestId { get; set; }
        public Guid? ParentSalesRequestItemId { get; set; }
        public Guid ProductGroupId { get; set; }
        public string ItemCode { get; set; } = string.Empty;
        public string ItemTitle { get; set; } = string.Empty;
        public decimal CapacityM3 { get; set; }
        public decimal? ConsumptionCapacity { get; set; }
        public RequestTankOrientation TankOrientation { get; set; }
        public PlacementType PlacementType { get; set; }
        public string? MinimumTechnicalNotes { get; set; }
        public string? SalesEngineeringNotes { get; set; }
        public string? DesignDetails { get; set; }
        public decimal? EstimatedCost { get; set; }
        public decimal? ApprovedSalesPrice { get; set; }
        public SalesRequestWorkflowStatus WorkflowStatus { get; set; } = SalesRequestWorkflowStatus.Submitted;
        public int DisplayOrder { get; set; }

        public SalesRequest SalesRequest { get; set; } = default!;
        public SalesRequestProductGroup ProductGroup { get; set; } = default!;
        public SalesRequestItem? ParentItem { get; set; }
        public ICollection<SalesRequestItem> ChildItems { get; set; } = new List<SalesRequestItem>();
    }
}
