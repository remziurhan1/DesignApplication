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
        public SalesRequestCategory RequestCategory { get; set; } = SalesRequestCategory.Tank;
        public string? ProductCode { get; set; }
        public string? DesignStandardCode { get; set; }
        public decimal? DesignPressureBar { get; set; }
        public decimal? DesignTemperatureMin { get; set; }
        public decimal? DesignTemperatureMax { get; set; }
        public RequestTankType? TankType { get; set; }
        public RequestStorageOption? StorageOption { get; set; }
        public RequestTransportOption? TransportOption { get; set; }
        public RequestStdOpsSelection? StdOpsSelection { get; set; }
        public string? SpcTechnicalDetails { get; set; }
        public decimal? AmbientTemperatureMin { get; set; }
        public decimal? AmbientTemperatureMax { get; set; }
        public string? FacilityType { get; set; }
        public decimal? FacilityInletPressureBar { get; set; }
        public decimal? FacilityOutletPressureBar { get; set; }
        public decimal? FacilityInletTemperature { get; set; }
        public decimal? FacilityOutletTemperature { get; set; }
        public decimal? FacilityCapacityNm3h { get; set; }
        public bool HasPump { get; set; }
        public string? PumpDetails { get; set; }
        public bool HasElectricHeater { get; set; }
        public string? ElectricHeaterDetails { get; set; }
        public bool HasTankConsumptionCapacity { get; set; }
        public string? AdditionalQuestionsJson { get; set; }
        public RequestTankOrientation TankOrientation { get; set; }
        public PlacementType PlacementType { get; set; }
        public string? MinimumTechnicalNotes { get; set; }
        public string? SalesEngineeringNotes { get; set; }
        public string? DesignDetails { get; set; }
        public SalesRequestCalculationType? LinkedCalculationType { get; set; }
        public Guid? LinkedCalculationId { get; set; }
        public Guid? LinkedCostAnalysisId { get; set; }
        public string? LinkedCalculationName { get; set; }
        public string? LinkedCostAnalysisRevisionCode { get; set; }
        public decimal? LinkedCostAnalysisTotal { get; set; }
        public decimal? EstimatedCost { get; set; }
        public decimal? MinimumSalesPrice { get; set; }
        public decimal? ApprovedSalesPrice { get; set; }
        public decimal? SharedSalesPrice { get; set; }
        public decimal? SoldSalesPrice { get; set; }
        public SalesRequestWorkflowStatus WorkflowStatus { get; set; } = SalesRequestWorkflowStatus.Submitted;
        public int DisplayOrder { get; set; }

        public virtual SalesRequest SalesRequest { get; set; } = default!;
        public virtual SalesRequestProductGroup ProductGroup { get; set; } = default!;
        public virtual SalesRequestItem? ParentItem { get; set; }
        public virtual ICollection<SalesRequestItem> ChildItems { get; set; } = new List<SalesRequestItem>();
        public virtual ICollection<SalesRequestDocument> Documents { get; set; } = new List<SalesRequestDocument>();
    }
}
