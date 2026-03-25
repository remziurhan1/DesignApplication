using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.SalesRequestVMs
{
    public class SalesRequestIndexVm
    {
        public int TotalRequestCount { get; set; }
        public int WaitingPricingCount { get; set; }
        public int ApprovedCount { get; set; }
        public int AttachmentCount { get; set; }
        public List<SalesRequestListVm> Requests { get; set; } = new();
    }

    public class SalesRequestListVm
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string RequestNo { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string RequestedByName { get; set; } = string.Empty;
        public DateTime SalesOpenedAt { get; set; }
        public DateTime NeededByDate { get; set; }
        public SalesRequestWorkflowStatus WorkflowStatus { get; set; }
        public SalesCustomerQuoteStatus CustomerQuoteStatus { get; set; }
        public SalesOfferStatus OfferStatus { get; set; }
        public int RevisionNo { get; set; }
        public string RevisionCode => $"R{RevisionNo:00}";
        public int ItemCount { get; set; }
        public int AttachmentCount { get; set; }
        public decimal? ApprovedSalesPriceTotal { get; set; }
        public bool HasCostAnalysis { get; set; }
    }

    public class SalesRequestCreateVm
    {
        public Guid? Id { get; set; }

        [Required]
        [Display(Name = "Müşteri")]
        public Guid CustomerId { get; set; }

        [Required, StringLength(150)]
        [Display(Name = "Talebi açan satışçı")]
        public string RequestedByName { get; set; } = string.Empty;

        [EmailAddress, StringLength(150)]
        [Display(Name = "E-posta")]
        public string? RequestedByEmail { get; set; }

        [StringLength(100)]
        [Display(Name = "Departman")]
        public string? RequestedByDepartment { get; set; }

        [Display(Name = "Teklif ihtiyaç tarihi")]
        [DataType(DataType.Date)]
        public DateTime NeededByDate { get; set; } = DateTime.UtcNow.Date.AddDays(7);

        [Display(Name = "Talep kaynağı")]
        public SalesRequestSource RequestSource { get; set; } = SalesRequestSource.Sales;

        [Display(Name = "Teklif durumu")]
        public SalesOfferStatus OfferStatus { get; set; } = SalesOfferStatus.F;

        [Display(Name = "Sevk edilecek ülke")]
        [StringLength(100)]
        public string? ShipmentCountry { get; set; }

        [Display(Name = "Kurulum ülkesi")]
        [StringLength(100)]
        public string? InstallationCountry { get; set; }

        [Display(Name = "Nakliye müşteride mi?")]
        public bool IsTransportByCustomer { get; set; }

        [StringLength(2000)]
        [Display(Name = "Satış özeti")]
        public string? SummaryNotes { get; set; }

        [StringLength(1000)]
        [Display(Name = "Revizyon açıklaması")]
        public string? RevisionReason { get; set; }

        [Display(Name = "Ek dokümanlar")]
        public List<IFormFile> Attachments { get; set; } = new();

        public List<SalesRequestItemInputVm> Items { get; set; } = new() { new() };
        public List<SelectListItem> Customers { get; set; } = new();
        public List<SelectListItem> ProductGroups { get; set; } = new();
    }

    public class SalesRequestItemInputVm
    {
        public Guid? ParentSalesRequestItemId { get; set; }

        [Required]
        [Display(Name = "Akışkan grubu")]
        public Guid ProductGroupId { get; set; }

        [Display(Name = "Kapasite (m³)")]
        public decimal CapacityM3 { get; set; }

        [Display(Name = "Tüketim kapasitesi")]
        [Range(0d, 100000d)]
        public decimal? ConsumptionCapacity { get; set; }

        [Display(Name = "Talep grubu")]
        public SalesRequestCategory RequestCategory { get; set; } = SalesRequestCategory.Tank;

        [Display(Name = "Ürün")]
        [StringLength(40)]
        public string? ProductCode { get; set; }

        [Display(Name = "Dizayn standardı")]
        [StringLength(40)]
        public string? DesignStandardCode { get; set; }

        [Display(Name = "Dizayn basıncı (bar)")]
        public decimal? DesignPressureBar { get; set; }

        [Display(Name = "Dizayn sıcaklığı min (°C)")]
        public decimal? DesignTemperatureMin { get; set; }

        [Display(Name = "Dizayn sıcaklığı max (°C)")]
        public decimal? DesignTemperatureMax { get; set; }

        [Display(Name = "Tank tipi")]
        public RequestTankType? TankType { get; set; }

        [Display(Name = "Depolama tipi")]
        public RequestStorageOption? StorageOption { get; set; }

        [Display(Name = "Transport tipi")]
        public RequestTransportOption? TransportOption { get; set; }

        [Display(Name = "STD/OPS/SPC")]
        public RequestStdOpsSelection? StdOpsSelection { get; set; }

        [Display(Name = "SPC teknik bilgileri")]
        public string? SpcTechnicalDetails { get; set; }

        [Display(Name = "Ortam sıcaklığı min (°C)")]
        public decimal? AmbientTemperatureMin { get; set; }

        [Display(Name = "Ortam sıcaklığı max (°C)")]
        public decimal? AmbientTemperatureMax { get; set; }

        [Display(Name = "Tesis tipi")]
        public string? FacilityType { get; set; }

        [Display(Name = "Giriş basıncı (bar)")]
        public decimal? FacilityInletPressureBar { get; set; }

        [Display(Name = "Çıkış basıncı (bar)")]
        public decimal? FacilityOutletPressureBar { get; set; }

        [Display(Name = "Giriş sıcaklığı (°C)")]
        public decimal? FacilityInletTemperature { get; set; }

        [Display(Name = "Çıkış sıcaklığı (°C)")]
        public decimal? FacilityOutletTemperature { get; set; }

        [Display(Name = "Tesis kapasitesi (Nm3/h)")]
        public decimal? FacilityCapacityNm3h { get; set; }

        [Display(Name = "Pompa var mı?")]
        public bool HasPump { get; set; }
        public string? PumpDetails { get; set; }

        [Display(Name = "Elektrikli ısıtıcı var mı?")]
        public bool HasElectricHeater { get; set; }
        public string? ElectricHeaterDetails { get; set; }

        [Display(Name = "Tank tüketim kapasitesi aktif")]
        public bool HasTankConsumptionCapacity { get; set; }

        [Display(Name = "Yedek parça bilgisi")]
        public string? SparePartDetails { get; set; }

        [Display(Name = "Ek sorular / cevaplar (JSON)")]
        public string? AdditionalQuestionsJson { get; set; }

        [Display(Name = "Tank tipi")]
        public RequestTankOrientation TankOrientation { get; set; } = RequestTankOrientation.Vertical;

        [Display(Name = "Kurulum")]
        public PlacementType PlacementType { get; set; } = PlacementType.Aboveground;

        [StringLength(2000)]
        [Display(Name = "Minimum teknik bilgiler")]
        public string? MinimumTechnicalNotes { get; set; }
    }

    public class SalesRequestDetailVm
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string RequestNo { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerContact { get; set; } = string.Empty;
        public string? CustomerEmail { get; set; }
        public string? CustomerPhone { get; set; }
        public string RequestedByName { get; set; } = string.Empty;
        public string? RequestedByEmail { get; set; }
        public string? RequestedByDepartment { get; set; }
        public DateTime SalesOpenedAt { get; set; }
        public DateTime NeededByDate { get; set; }
        public SalesRequestSource RequestSource { get; set; }
        public string? ShipmentCountry { get; set; }
        public string? InstallationCountry { get; set; }
        public bool IsTransportByCustomer { get; set; }
        public string? CustomerSector { get; set; }
        public string? CustomerMainDealerCountry { get; set; }
        public string? CustomerRegion { get; set; }
        public string? SummaryNotes { get; set; }
        public SalesRequestWorkflowStatus WorkflowStatus { get; set; }
        public SalesCustomerQuoteStatus CustomerQuoteStatus { get; set; }
        public SalesOfferStatus OfferStatus { get; set; }
        public int RevisionNo { get; set; }
        public string RevisionCode => $"R{RevisionNo:00}";
        public bool IsManagerView { get; set; }
        public List<SalesRequestRevisionHistoryVm> RevisionHistory { get; set; } = new();
        public List<SalesRequestRevisionCostVm> RevisionCosts { get; set; } = new();
        public List<SalesRequestDocumentVm> Documents { get; set; } = new();
        public List<SalesRequestDetailItemVm> Items { get; set; } = new();
        public List<SalesRequestAttachmentVm> Attachments { get; set; } = new();
        public SalesRequestDocumentUploadVm DocumentUpload { get; set; } = new();
        public SalesRequestAddSubItemVm NewSubItem { get; set; } = new();
        public bool CanUploadPidDocument { get; set; }
        public bool CanDownloadDocuments { get; set; }
    }

    public class SalesRequestRevisionHistoryVm
    {
        public int RevisionNo { get; set; }
        public string RevisionCode => $"R{RevisionNo:00}";
        public string RevisionReason { get; set; } = string.Empty;
        public string RevisedBy { get; set; } = string.Empty;
        public DateTime RevisedAt { get; set; }
    }

    public class SalesRequestRevisionCostVm
    {
        public int RevisionNo { get; set; }
        public string RevisionCode => $"R{RevisionNo:00}";
        public string RevisionReason { get; set; } = string.Empty;
        public string RevisedBy { get; set; } = string.Empty;
        public DateTime RevisedAt { get; set; }
        public decimal? TotalCost { get; set; }
        public List<SalesRequestRevisionCostItemVm> Items { get; set; } = new();
    }

    public class SalesRequestRevisionCostItemVm
    {
        public string ItemCode { get; set; } = string.Empty;
        public string ItemTitle { get; set; } = string.Empty;
        public decimal CapacityM3 { get; set; }
        public string? LinkedCostAnalysisRevisionCode { get; set; }
        public decimal? LinkedCostAnalysisTotal { get; set; }
    }

    public class SalesDashboardVm
    {
        public bool IsManagerView { get; set; }
        public bool CanAccessManagerPanel { get; set; }
        public string? CurrentRegion { get; set; }
        public int TotalRequestCount { get; set; }
        public int OpenRequestCount { get; set; }
        public int ClosedRequestCount { get; set; }
        public int QuoteSharedCount { get; set; }
        public int ApprovedCount { get; set; }
        public int WaitingPricingCount { get; set; }
        public List<SalespersonRequestStatVm> SalespersonStats { get; set; } = new();
        public List<SalesDashboardRequestVm> MyRequests { get; set; } = new();
    }

    public class SalesDashboardRequestVm
    {
        public Guid Id { get; set; }
        public string RequestNo { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public DateTime SalesOpenedAt { get; set; }
        public SalesRequestWorkflowStatus WorkflowStatus { get; set; }
        public SalesCustomerQuoteStatus CustomerQuoteStatus { get; set; }
    }

    public class SalespersonRequestStatVm
    {
        public string SalespersonName { get; set; } = string.Empty;
        public string? Region { get; set; }
        public int TotalRequestCount { get; set; }
        public int OpenRequestCount { get; set; }
        public int ClosedRequestCount { get; set; }
        public int QuoteSharedCount { get; set; }
        public int ApprovedCount { get; set; }
    }

    public class SalesManagerReviewVm
    {
        public int IncomingCount { get; set; }
        public int ApprovedTodayCount { get; set; }
        public int RejectedTodayCount { get; set; }
        public List<SalesManagerReviewRowVm> Requests { get; set; } = new();
    }

    public class SalesManagerReviewRowVm
    {
        public Guid Id { get; set; }
        public string RequestNo { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string SalespersonName { get; set; } = string.Empty;
        public string? Region { get; set; }
        public string RevisionCode { get; set; } = string.Empty;
        public DateTime SalesOpenedAt { get; set; }
        public int ItemCount { get; set; }
        public decimal? LinkedCostTotal { get; set; }
        public SalesRequestWorkflowStatus WorkflowStatus { get; set; }
    }

    public class SalesRequestDetailItemVm
    {
        public Guid Id { get; set; }
        public Guid? ParentSalesRequestItemId { get; set; }
        public string ItemCode { get; set; } = string.Empty;
        public string ItemTitle { get; set; } = string.Empty;
        public string ProductGroupName { get; set; } = string.Empty;
        public decimal CapacityM3 { get; set; }
        public decimal? ConsumptionCapacity { get; set; }
        public SalesRequestCategory RequestCategory { get; set; }
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
        public SalesRequestWorkflowStatus WorkflowStatus { get; set; }
        public List<SalesRequestDetailItemVm> Children { get; set; } = new();
    }

    public class SalesRequestAttachmentVm
    {
        public string OriginalFileName { get; set; } = string.Empty;
        public string RelativePath { get; set; } = string.Empty;
        public long FileSize { get; set; }
    }

    public class SalesRequestDocumentVm
    {
        public Guid Id { get; set; }
        public SalesDocumentType DocumentTypeCode { get; set; }
        public string DocumentType { get; set; } = string.Empty;
        public string RevisionCode { get; set; } = string.Empty;
        public string OriginalFileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public bool IsCurrent { get; set; }
        public string? LinkedCostAnalysisRevisionCode { get; set; }
        public DateTime UploadedAt { get; set; }
        public string UploadedBy { get; set; } = string.Empty;
    }

    public class SalesRequestDocumentUploadVm
    {
        public Guid SalesRequestId { get; set; }
        public SalesDocumentType DocumentType { get; set; }
        public string RevisionCode { get; set; } = string.Empty;
        public Guid? SalesRequestItemId { get; set; }
        public Guid? LinkedCostAnalysisId { get; set; }
        public string? LinkedCostAnalysisRevisionCode { get; set; }
        public string? Notes { get; set; }
        public IFormFile? File { get; set; }
    }

    public class SalesRequestTechnicalDetailsVm
    {
        public Guid RequestId { get; set; }
        public Guid ItemId { get; set; }
        public string RequestNo { get; set; } = string.Empty;
        public string ItemCode { get; set; } = string.Empty;
        public string ItemTitle { get; set; } = string.Empty;
        public string CalculationName { get; set; } = string.Empty;
        public string CalculationType { get; set; } = string.Empty;
        public string? RevisionCode { get; set; }
        public string MAWP { get; set; } = "-";
        public string DesignPressure { get; set; } = "-";
        public string TestPressure { get; set; } = "-";
        public string RoundedShellThickness { get; set; } = "-";
        public string RoundedHeadThickness { get; set; } = "-";
        public string InnerTankLength { get; set; } = "-";
        public string TankDiameter { get; set; } = "-";
        public string? DesignDetails { get; set; }
        public bool HasSpecification { get; set; }
        public List<SalesRequestTechnicalFieldVm> TankDetailFields { get; set; } = new();
        public List<SalesRequestTechnicalFieldVm> InputFields { get; set; } = new();
        public List<SalesRequestTechnicalFieldVm> InnerTankFields { get; set; } = new();
        public List<SalesRequestTechnicalFieldVm> OuterTankFields { get; set; } = new();
    }

    public class SalesRequestTechnicalFieldVm
    {
        public string Label { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }

    public class SalesRequestAddSubItemVm : SalesRequestItemInputVm
    {
        public Guid SalesRequestId { get; set; }
        public List<SelectListItem> ProductGroups { get; set; } = new();
    }

    public class SalesRequestPricingVm
    {
        public Guid SalesRequestId { get; set; }
        public string RequestNo { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public List<SalesRequestPricingAnalysisOptionVm> AvailableAnalyses { get; set; } = new();
        public List<SalesRequestPricingItemVm> Items { get; set; } = new();
    }

    public class SalesRequestPricingAnalysisOptionVm
    {
        public string Key { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public SalesRequestCalculationType CalculationType { get; set; }
        public Guid CalculationId { get; set; }
        public Guid CostAnalysisId { get; set; }
        public string CalculationName { get; set; } = string.Empty;
        public string RevisionCode { get; set; } = string.Empty;
        public decimal TotalCost { get; set; }
        public decimal? MinimumSalesPrice { get; set; }
        public decimal? RecommendedSalesPrice { get; set; }
    }

    public class SalesRequestPricingItemVm
    {
        public Guid Id { get; set; }
        public Guid? ParentSalesRequestItemId { get; set; }
        public string ItemCode { get; set; } = string.Empty;
        public string ItemTitle { get; set; } = string.Empty;
        public string ProductGroupName { get; set; } = string.Empty;
        public decimal CapacityM3 { get; set; }
        public decimal? ConsumptionCapacity { get; set; }
        public RequestTankOrientation TankOrientation { get; set; }
        public PlacementType PlacementType { get; set; }
        public string? MinimumTechnicalNotes { get; set; }
        [Display(Name = "Bağlı maliyet analizi")]
        public string? LinkedAnalysisKey { get; set; }
        public SalesRequestCalculationType? LinkedCalculationType { get; set; }
        public Guid? LinkedCalculationId { get; set; }
        public Guid? LinkedCostAnalysisId { get; set; }
        public string? LinkedCalculationName { get; set; }
        public string? LinkedCostAnalysisRevisionCode { get; set; }
        public decimal? LinkedCostAnalysisTotal { get; set; }
        [Display(Name = "Maliyet")]
        public decimal? EstimatedCost { get; set; }
        [Display(Name = "Minimum satış fiyatı")]
        public decimal? MinimumSalesPrice { get; set; }
        [Display(Name = "Tavsiye edilen satış fiyatı")]
        public decimal? ApprovedSalesPrice { get; set; }
        [Display(Name = "Detay mühendisliği")]
        public string? DesignDetails { get; set; }
        [Display(Name = "İç açıklama")]
        public string? SalesEngineeringNotes { get; set; }
        [Display(Name = "Durum")]
        public SalesRequestWorkflowStatus WorkflowStatus { get; set; }
    }
}
