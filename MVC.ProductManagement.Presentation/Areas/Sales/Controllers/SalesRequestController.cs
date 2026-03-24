using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.SalesRequests;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.SalesRequestVMs;

namespace MVC.ProductManagement.Presentation.Areas.Sales.Controllers
{
    public class SalesRequestController : SalesBaseController
    {
        private readonly AppDbContext _context;

        public SalesRequestController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var requests = await _context.SalesRequests
                .AsNoTracking()
                .Include(x => x.Customer)
                .Include(x => x.Items)
                .Include(x => x.Attachments)
                .Where(x => x.Status != Status.Deleted && x.WorkflowStatus == SalesRequestWorkflowStatus.Approved)
                .OrderByDescending(x => x.ApprovedAt ?? x.CreatedDate)
                .ToListAsync();

            var vm = new SalesRequestIndexVm
            {
                TotalRequestCount = requests.Count,
                WaitingPricingCount = 0,
                ApprovedCount = requests.Count,
                AttachmentCount = requests.Sum(x => x.Attachments.Count),
                Requests = requests.Select(x => new SalesRequestListVm
                {
                    Id = x.Id,
                    CustomerId = x.CustomerId,
                    RequestNo = x.RequestNo,
                    Title = x.Title,
                    CustomerName = x.Customer.CompanyName,
                    RequestedByName = x.RequestedByName,
                    SalesOpenedAt = x.SalesOpenedAt,
                    NeededByDate = x.NeededByDate,
                    WorkflowStatus = x.WorkflowStatus,
                    ItemCount = x.Items.Count,
                    AttachmentCount = x.Attachments.Count,
                    ApprovedSalesPriceTotal = x.Items.Where(i => i.ApprovedSalesPrice.HasValue).Sum(i => i.ApprovedSalesPrice)
                }).ToList()
            };

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var entity = await LoadRequestAsync(id);
            if (entity == null) return NotFound();

            if (entity.WorkflowStatus != SalesRequestWorkflowStatus.Approved)
            {
                TempData["ErrorMessage"] = "Bu talep henüz satış yöneticisi tarafından onaylanmamış.";
                return RedirectToAction(nameof(Index));
            }

            var vm = MapDetailVm(entity);
            return View(vm);
        }

        private async Task<SalesRequest?> LoadRequestAsync(Guid id)
        {
            return await _context.SalesRequests
                .AsNoTracking()
                .Include(x => x.Customer)
                .Include(x => x.Attachments)
                .Include(x => x.Items)
                    .ThenInclude(x => x.ProductGroup)
                .FirstOrDefaultAsync(x => x.Id == id && x.Status != Status.Deleted);
        }

        private static SalesRequestDetailVm MapDetailVm(SalesRequest entity)
        {
            var itemMap = entity.Items
                .OrderBy(x => x.DisplayOrder)
                .ToDictionary(
                    x => x.Id,
                    x => new SalesRequestDetailItemVm
                    {
                        Id = x.Id,
                        ParentSalesRequestItemId = x.ParentSalesRequestItemId,
                        ItemCode = x.ItemCode,
                        ItemTitle = x.ItemTitle,
                        ProductGroupName = x.ProductGroup.Name,
                        CapacityM3 = x.CapacityM3,
                        ConsumptionCapacity = x.ConsumptionCapacity,
                        RequestCategory = x.RequestCategory,
                        ProductCode = x.ProductCode,
                        DesignStandardCode = x.DesignStandardCode,
                        DesignPressureBar = x.DesignPressureBar,
                        DesignTemperatureMin = x.DesignTemperatureMin,
                        DesignTemperatureMax = x.DesignTemperatureMax,
                        TankType = x.TankType,
                        StorageOption = x.StorageOption,
                        TransportOption = x.TransportOption,
                        StdOpsSelection = x.StdOpsSelection,
                        SpcTechnicalDetails = x.SpcTechnicalDetails,
                        AmbientTemperatureMin = x.AmbientTemperatureMin,
                        AmbientTemperatureMax = x.AmbientTemperatureMax,
                        FacilityType = x.FacilityType,
                        FacilityInletPressureBar = x.FacilityInletPressureBar,
                        FacilityOutletPressureBar = x.FacilityOutletPressureBar,
                        FacilityInletTemperature = x.FacilityInletTemperature,
                        FacilityOutletTemperature = x.FacilityOutletTemperature,
                        FacilityCapacityNm3h = x.FacilityCapacityNm3h,
                        HasPump = x.HasPump,
                        PumpDetails = x.PumpDetails,
                        HasElectricHeater = x.HasElectricHeater,
                        ElectricHeaterDetails = x.ElectricHeaterDetails,
                        HasTankConsumptionCapacity = x.HasTankConsumptionCapacity,
                        AdditionalQuestionsJson = x.AdditionalQuestionsJson,
                        TankOrientation = x.TankOrientation,
                        PlacementType = x.PlacementType,
                        MinimumTechnicalNotes = x.MinimumTechnicalNotes,
                        DesignDetails = x.DesignDetails,
                        LinkedCalculationType = x.LinkedCalculationType,
                        LinkedCalculationId = x.LinkedCalculationId,
                        LinkedCostAnalysisId = x.LinkedCostAnalysisId,
                        LinkedCalculationName = x.LinkedCalculationName,
                        LinkedCostAnalysisRevisionCode = x.LinkedCostAnalysisRevisionCode,
                        MinimumSalesPrice = x.MinimumSalesPrice,
                        ApprovedSalesPrice = x.ApprovedSalesPrice,
                        WorkflowStatus = x.WorkflowStatus
                    });

            var roots = new List<SalesRequestDetailItemVm>();
            foreach (var item in itemMap.Values)
            {
                if (item.ParentSalesRequestItemId.HasValue && itemMap.TryGetValue(item.ParentSalesRequestItemId.Value, out var parent))
                {
                    parent.Children.Add(item);
                }
                else
                {
                    roots.Add(item);
                }
            }

            return new SalesRequestDetailVm
            {
                Id = entity.Id,
                CustomerId = entity.CustomerId,
                RequestNo = entity.RequestNo,
                Title = entity.Title,
                CustomerName = entity.Customer.CompanyName,
                CustomerContact = entity.Customer.ContactName,
                CustomerEmail = entity.Customer.Email,
                CustomerPhone = entity.Customer.Phone,
                RequestedByName = entity.RequestedByName,
                RequestedByEmail = entity.RequestedByEmail,
                RequestedByDepartment = entity.RequestedByDepartment,
                SalesOpenedAt = entity.SalesOpenedAt,
                NeededByDate = entity.NeededByDate,
                RequestSource = entity.RequestSource,
                ShipmentCountry = entity.ShipmentCountry,
                InstallationCountry = entity.InstallationCountry,
                IsTransportByCustomer = entity.IsTransportByCustomer,
                CustomerSector = entity.Customer.Sector,
                CustomerMainDealerCountry = entity.Customer.MainDealerCountry,
                CustomerRegion = entity.Customer.Region,
                SummaryNotes = entity.SummaryNotes,
                WorkflowStatus = entity.WorkflowStatus,
                IsManagerView = false,
                Items = roots,
                Attachments = entity.Attachments
                    .Select(a => new SalesRequestAttachmentVm
                    {
                        OriginalFileName = a.OriginalFileName,
                        RelativePath = a.RelativePath,
                        FileSize = a.FileSize
                    })
                    .ToList()
            };
        }
    }
}
