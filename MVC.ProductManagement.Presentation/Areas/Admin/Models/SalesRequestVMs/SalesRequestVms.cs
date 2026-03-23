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
        public string RequestNo { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string RequestedByName { get; set; } = string.Empty;
        public DateTime SalesOpenedAt { get; set; }
        public SalesRequestWorkflowStatus WorkflowStatus { get; set; }
        public int ItemCount { get; set; }
        public int AttachmentCount { get; set; }
        public decimal? ApprovedSalesPriceTotal { get; set; }
    }

    public class SalesRequestCreateVm
    {
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

        [StringLength(2000)]
        [Display(Name = "Satış özeti")]
        public string? SummaryNotes { get; set; }

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

        [Required]
        [Range(typeof(decimal), "0.1", "100000")]
        [Display(Name = "Kapasite (m³)")]
        public decimal CapacityM3 { get; set; }

        [Display(Name = "Tüketim kapasitesi")]
        [Range(typeof(decimal), "0", "100000")]
        public decimal? ConsumptionCapacity { get; set; }

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
        public string RequestNo { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerContact { get; set; } = string.Empty;
        public string? CustomerEmail { get; set; }
        public string? CustomerPhone { get; set; }
        public string RequestedByName { get; set; } = string.Empty;
        public string? RequestedByEmail { get; set; }
        public string? RequestedByDepartment { get; set; }
        public string? SummaryNotes { get; set; }
        public SalesRequestWorkflowStatus WorkflowStatus { get; set; }
        public bool IsManagerView { get; set; }
        public List<SalesRequestDetailItemVm> Items { get; set; } = new();
        public List<SalesRequestAttachmentVm> Attachments { get; set; } = new();
        public SalesRequestAddSubItemVm NewSubItem { get; set; } = new();
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
        public RequestTankOrientation TankOrientation { get; set; }
        public PlacementType PlacementType { get; set; }
        public string? MinimumTechnicalNotes { get; set; }
        public string? SalesEngineeringNotes { get; set; }
        public string? DesignDetails { get; set; }
        public decimal? EstimatedCost { get; set; }
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
        public List<SalesRequestPricingItemVm> Items { get; set; } = new();
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
        [Display(Name = "Maliyet")]
        public decimal? EstimatedCost { get; set; }
        [Display(Name = "Satış fiyatı")]
        public decimal? ApprovedSalesPrice { get; set; }
        [Display(Name = "Detay mühendisliği")]
        public string? DesignDetails { get; set; }
        [Display(Name = "İç açıklama")]
        public string? SalesEngineeringNotes { get; set; }
        [Display(Name = "Durum")]
        public SalesRequestWorkflowStatus WorkflowStatus { get; set; }
    }
}
