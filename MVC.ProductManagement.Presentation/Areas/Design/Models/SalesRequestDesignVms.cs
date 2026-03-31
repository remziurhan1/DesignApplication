using MVC.ProductManagement.Domain.Enums;

namespace MVC.ProductManagement.Presentation.Areas.Design.Models
{
    public class DesignSalesRequestIndexVm
    {
        public int TotalCount { get; set; }
        public List<DesignSalesRequestListVm> Requests { get; set; } = new();
    }

    public class DesignSalesRequestListVm
    {
        public Guid Id { get; set; }
        public string RequestNo { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string RequestedByName { get; set; } = string.Empty;
        public DateTime SalesOpenedAt { get; set; }
        public DateTime NeededByDate { get; set; }
        public string? DeliveryLeadTime { get; set; }
        public int ItemCount { get; set; }
    }

    public class DesignSalesRequestDetailVm
    {
        public Guid Id { get; set; }
        public string RequestNo { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string RequestedByName { get; set; } = string.Empty;
        public DateTime SalesOpenedAt { get; set; }
        public DateTime? RequestReceivedAt { get; set; }
        public DateTime NeededByDate { get; set; }
        public string? DeliveryLeadTime { get; set; }
        public SalesOfferStatus OfferStatus { get; set; }
        public List<DesignSalesRequestItemVm> TechnicalItems { get; set; } = new();
        public List<DesignSalesCostInputItemVm> CostInputItems { get; set; } = new();
        public List<DesignSalesDocumentVm> TechnicalDocuments { get; set; } = new();
    }

    public class DesignSalesRequestItemVm
    {
        public Guid Id { get; set; }
        public string ItemCode { get; set; } = string.Empty;
        public string ItemTitle { get; set; } = string.Empty;
        public string ProductGroupName { get; set; } = string.Empty;
        public decimal CapacityM3 { get; set; }
        public SalesRequestCategory RequestCategory { get; set; }
        public string? DesignStandardCode { get; set; }
        public decimal? DesignPressureBar { get; set; }
        public decimal? DesignTemperatureMin { get; set; }
        public decimal? DesignTemperatureMax { get; set; }
        public RequestTankType? TankType { get; set; }
        public RequestStorageOption? StorageOption { get; set; }
        public RequestTransportOption? TransportOption { get; set; }
        public RequestStdOpsSelection? StdOpsSelection { get; set; }
        public RequestTankOrientation TankOrientation { get; set; }
        public PlacementType PlacementType { get; set; }
        public string? SpcTechnicalDetails { get; set; }
        public string? MinimumTechnicalNotes { get; set; }
        public string? DesignDetails { get; set; }
        public SalesRequestWorkflowStatus WorkflowStatus { get; set; }
    }

    public class DesignSalesCostInputItemVm
    {
        public string ItemCode { get; set; } = string.Empty;
        public string ItemTitle { get; set; } = string.Empty;
        public string? LinkedCalculationName { get; set; }
        public string? LinkedCostAnalysisRevisionCode { get; set; }
        public SalesRequestCalculationType? LinkedCalculationType { get; set; }
    }

    public class DesignSalesDocumentVm
    {
        public Guid Id { get; set; }
        public SalesDocumentType DocumentType { get; set; }
        public string RevisionCode { get; set; } = string.Empty;
        public string OriginalFileName { get; set; } = string.Empty;
        public DateTime UploadedAt { get; set; }
        public bool IsCurrent { get; set; }
    }
}
