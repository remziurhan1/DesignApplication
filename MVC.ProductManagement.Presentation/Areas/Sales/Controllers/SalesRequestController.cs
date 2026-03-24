using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly IWebHostEnvironment _environment;

        public SalesRequestController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (!await HasSalesPermissionAsync(x => x.CanAccessSalesArea))
            {
                return Forbid();
            }

            var requests = await _context.SalesRequests
                .AsNoTracking()
                .Include(x => x.Customer)
                .Include(x => x.Items)
                .Include(x => x.Attachments)
                .Where(x => x.Status != Status.Deleted && x.RequestSource == SalesRequestSource.Sales)
                .OrderByDescending(x => x.CreatedDate)
                .ToListAsync();

            var vm = new SalesRequestIndexVm
            {
                TotalRequestCount = requests.Count,
                WaitingPricingCount = requests.Count(x => x.WorkflowStatus != SalesRequestWorkflowStatus.Approved),
                ApprovedCount = requests.Count(x => x.WorkflowStatus == SalesRequestWorkflowStatus.Approved),
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
        public async Task<IActionResult> Create()
        {
            if (!await HasSalesPermissionAsync(x => x.CanCreateSalesRequests || x.CanAccessSalesArea))
            {
                return Forbid();
            }

            var vm = new SalesRequestCreateVm
            {
                RequestSource = SalesRequestSource.Sales,
                Items = new List<SalesRequestItemInputVm> { new() }
            };

            await PopulateFormAsync(vm);
            return View("~/Areas/Admin/Views/SalesRequest/Create.cshtml", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestFormLimits(MultipartBodyLengthLimit = 50_000_000)]
        public async Task<IActionResult> Create(SalesRequestCreateVm vm)
        {
            if (!await HasSalesPermissionAsync(x => x.CanCreateSalesRequests || x.CanAccessSalesArea))
            {
                return Forbid();
            }

            vm.Items = vm.Items.Where(x => x.ProductGroupId != Guid.Empty && x.CapacityM3 > 0).ToList();
            if (!vm.Items.Any())
            {
                ModelState.AddModelError(string.Empty, "En az bir talep satırı girmelisiniz.");
            }

            if (!ModelState.IsValid)
            {
                await PopulateFormAsync(vm);
                return View("~/Areas/Admin/Views/SalesRequest/Create.cshtml", vm);
            }

            var requestNo = await GenerateRequestNoAsync();
            var title = await BuildRequestTitleAsync(vm.Items.First());

            var entity = new SalesRequest
            {
                RequestNo = requestNo,
                Title = title,
                CustomerId = vm.CustomerId,
                RequestedByName = vm.RequestedByName,
                RequestedByEmail = vm.RequestedByEmail,
                RequestedByDepartment = vm.RequestedByDepartment,
                NeededByDate = vm.NeededByDate.Date,
                RequestSource = SalesRequestSource.Sales,
                ShipmentCountry = vm.ShipmentCountry,
                InstallationCountry = vm.InstallationCountry,
                IsTransportByCustomer = vm.IsTransportByCustomer,
                SummaryNotes = vm.SummaryNotes,
                WorkflowStatus = SalesRequestWorkflowStatus.Submitted,
                SalesOpenedAt = DateTime.UtcNow
            };

            var groups = await _context.SalesRequestProductGroups.AsNoTracking().ToDictionaryAsync(x => x.Id);
            var itemOrder = 1;
            foreach (var itemVm in vm.Items)
            {
                var group = groups[itemVm.ProductGroupId];
                entity.Items.Add(new SalesRequestItem
                {
                    ProductGroupId = itemVm.ProductGroupId,
                    CapacityM3 = itemVm.CapacityM3,
                    ConsumptionCapacity = itemVm.ConsumptionCapacity,
                    RequestCategory = itemVm.RequestCategory,
                    ProductCode = itemVm.ProductCode,
                    DesignStandardCode = itemVm.DesignStandardCode,
                    DesignPressureBar = itemVm.DesignPressureBar,
                    DesignTemperatureMin = itemVm.DesignTemperatureMin,
                    DesignTemperatureMax = itemVm.DesignTemperatureMax,
                    TankType = itemVm.TankType,
                    StorageOption = itemVm.StorageOption,
                    TransportOption = itemVm.TransportOption,
                    StdOpsSelection = itemVm.StdOpsSelection,
                    SpcTechnicalDetails = itemVm.SpcTechnicalDetails,
                    AmbientTemperatureMin = itemVm.AmbientTemperatureMin,
                    AmbientTemperatureMax = itemVm.AmbientTemperatureMax,
                    FacilityType = itemVm.FacilityType,
                    FacilityInletPressureBar = itemVm.FacilityInletPressureBar,
                    FacilityOutletPressureBar = itemVm.FacilityOutletPressureBar,
                    FacilityInletTemperature = itemVm.FacilityInletTemperature,
                    FacilityOutletTemperature = itemVm.FacilityOutletTemperature,
                    FacilityCapacityNm3h = itemVm.FacilityCapacityNm3h,
                    HasPump = itemVm.HasPump,
                    PumpDetails = itemVm.PumpDetails,
                    HasElectricHeater = itemVm.HasElectricHeater,
                    ElectricHeaterDetails = itemVm.ElectricHeaterDetails,
                    HasTankConsumptionCapacity = itemVm.HasTankConsumptionCapacity,
                    AdditionalQuestionsJson = itemVm.AdditionalQuestionsJson,
                    TankOrientation = itemVm.TankOrientation,
                    PlacementType = itemVm.PlacementType,
                    MinimumTechnicalNotes = itemVm.MinimumTechnicalNotes,
                    ItemCode = GenerateItemCode(group.Code, itemVm, itemOrder),
                    ItemTitle = BuildItemTitle(group.ShortCode, itemVm),
                    WorkflowStatus = SalesRequestWorkflowStatus.Submitted,
                    DisplayOrder = itemOrder++
                });
            }

            _context.SalesRequests.Add(entity);
            await _context.SaveChangesAsync();
            await SaveAttachmentsAsync(entity, vm.Attachments);

            TempData["SuccessMessage"] = "Talep oluşturuldu. Talep artık admin tarafında fiyatlandırma/onay sürecine girebilir.";
            return RedirectToAction(nameof(Details), new { id = entity.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            if (!await HasSalesPermissionAsync(x => x.CanAccessSalesArea))
            {
                return Forbid();
            }

            var entity = await LoadRequestAsync(id);
            if (entity == null) return NotFound();

            var canViewPricing = await HasSalesPermissionAsync(x => x.CanViewSalesPricing);
            var vm = MapDetailVm(entity, canViewPricing);
            ViewBag.WaitingManagerApproval = entity.WorkflowStatus != SalesRequestWorkflowStatus.Approved;
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> TechnicalDetails(Guid requestId, Guid itemId)
        {
            if (!await HasSalesPermissionAsync(x => x.CanAccessSalesArea))
            {
                return Forbid();
            }

            var request = await LoadRequestAsync(requestId);
            if (request == null)
            {
                return NotFound();
            }

            var item = request.Items.FirstOrDefault(x => x.Id == itemId);
            if (item == null || !item.LinkedCalculationType.HasValue || !item.LinkedCalculationId.HasValue)
            {
                return NotFound();
            }

            var vm = new SalesRequestTechnicalDetailsVm
            {
                RequestId = request.Id,
                RequestNo = request.RequestNo,
                ItemId = item.Id,
                ItemCode = item.ItemCode,
                ItemTitle = item.ItemTitle,
                CalculationName = item.LinkedCalculationName ?? "-",
                CalculationType = item.LinkedCalculationType.Value.ToString(),
                RevisionCode = item.LinkedCostAnalysisRevisionCode,
                DesignDetails = item.DesignDetails,
                HasSpecification = item.LinkedCalculationType == SalesRequestCalculationType.EN13458
            };

            if (item.LinkedCalculationType == SalesRequestCalculationType.EN13458)
            {
                var calculation = await _context.EN13458Calculations
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == item.LinkedCalculationId.Value && x.Status != Status.Deleted);

                if (calculation == null)
                {
                    return NotFound();
                }

                vm.MAWP = $"{(calculation.DesignPressure > 0 ? calculation.DesignPressure : calculation.Pressure):N2} bar";
                vm.DesignPressure = $"{calculation.DesignPressure:N2} bar";
                vm.TestPressure = $"{calculation.TestPressure:N2} bar";
                vm.RoundedShellThickness = $"İç: {calculation.RoundedInnerShellThickness:N2} mm / Dış: {calculation.RoundedOuterShellThickness:N2} mm";
                vm.RoundedHeadThickness = $"İç: {calculation.RoundedInnerHeadThickness:N2} mm / Dış: {calculation.RoundedOuterHeadThickness:N2} mm";
                vm.InnerTankLength = $"{calculation.InnerTankTotalLength:N2} mm";
                vm.TankDiameter = $"İç: {calculation.OuterDiameter:N2} mm / Dış: {calculation.OuterTankDiameter:N2} mm";
            }
            else
            {
                var calculation = await _context.AD2000Calculations
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == item.LinkedCalculationId.Value && x.Status != Status.Deleted);

                if (calculation == null)
                {
                    return NotFound();
                }

                vm.MAWP = $"{calculation.DesignPressure:N2} bar";
                vm.DesignPressure = $"{calculation.DesignPressure:N2} bar";
                vm.TestPressure = $"{calculation.TestPressure:N2} bar";
                vm.RoundedShellThickness = $"{calculation.RoundedShellThickness:N2} mm";
                vm.RoundedHeadThickness = $"{calculation.RoundedHeadThickness:N2} mm";
                vm.InnerTankLength = $"{calculation.ShellLength:N2} mm";
                vm.TankDiameter = $"{calculation.Diameter:N2} mm";
            }

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Specification(Guid requestId, Guid itemId)
        {
            if (!await HasSalesPermissionAsync(x => x.CanAccessSalesArea))
            {
                return Forbid();
            }

            var request = await LoadRequestAsync(requestId);
            if (request == null)
            {
                return NotFound();
            }

            var item = request.Items.FirstOrDefault(x => x.Id == itemId);
            if (item == null || item.LinkedCalculationType != SalesRequestCalculationType.EN13458 || !item.LinkedCalculationId.HasValue)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(TechnicalDetails), new { requestId, itemId });
        }

        private async Task<SalesRequest?> LoadRequestAsync(Guid id)
        {
            return await _context.SalesRequests
                .AsNoTracking()
                .Include(x => x.Customer)
                .Include(x => x.Attachments)
                .Include(x => x.Items)
                    .ThenInclude(x => x.ProductGroup)
                .FirstOrDefaultAsync(x => x.Id == id && x.Status != Status.Deleted && x.RequestSource == SalesRequestSource.Sales);
        }

        private static SalesRequestDetailVm MapDetailVm(SalesRequest entity, bool canViewPricing)
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
                        MinimumSalesPrice = canViewPricing ? x.MinimumSalesPrice : null,
                        ApprovedSalesPrice = canViewPricing ? x.ApprovedSalesPrice : null,
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

        private async Task PopulateFormAsync(SalesRequestCreateVm vm)
        {
            vm.Customers = await _context.Customers
                .AsNoTracking()
                .Where(x => x.Status != Status.Deleted && x.IsActive)
                .OrderBy(x => x.CompanyName)
                .Select(x => new SelectListItem(x.CompanyName, x.Id.ToString()))
                .ToListAsync();

            vm.ProductGroups = await _context.SalesRequestProductGroups
                .AsNoTracking()
                .Where(x => x.Status != Status.Deleted && x.IsActive)
                .OrderBy(x => x.DisplayOrder)
                .Select(x => new SelectListItem($"{x.Code} - {x.Name}", x.Id.ToString()))
                .ToListAsync();
        }

        private async Task<string> GenerateRequestNoAsync()
        {
            var prefix = $"TR-{DateTime.UtcNow:yyyyMMdd}";
            var todayCount = await _context.SalesRequests.CountAsync(x => x.RequestNo.StartsWith(prefix));
            return $"{prefix}-{todayCount + 1:000}";
        }

        private async Task<string> BuildRequestTitleAsync(SalesRequestItemInputVm item)
        {
            var group = await _context.SalesRequestProductGroups.AsNoTracking().FirstAsync(x => x.Id == item.ProductGroupId);
            return BuildItemTitle(group.ShortCode, item);
        }

        private static string BuildItemTitle(string shortCode, SalesRequestItemInputVm item)
        {
            var orientation = item.TankOrientation == RequestTankOrientation.Vertical ? "DİK" : "YATAY";
            var placement = item.PlacementType == PlacementType.Aboveground ? "YER ÜSTÜ" : "YER ALTI";
            var consumption = item.ConsumptionCapacity.HasValue ? $"-{item.ConsumptionCapacity:0.##}Nm³/h" : string.Empty;
            return $"{item.CapacityM3:0.##}m3-{shortCode}-{orientation}-DEPOLAMA-{placement}{consumption}";
        }

        private static string GenerateItemCode(string groupCode, SalesRequestItemInputVm item, int order)
        {
            var orientation = item.TankOrientation == RequestTankOrientation.Vertical ? "D" : "Y";
            var placement = item.PlacementType == PlacementType.Aboveground ? "A" : "U";
            var capacity = item.CapacityM3.ToString("0.##").Replace(",", string.Empty).Replace(".", string.Empty);
            var consumption = item.ConsumptionCapacity.HasValue ? $"-{item.ConsumptionCapacity:0.##}".Replace(",", string.Empty).Replace(".", string.Empty) : string.Empty;
            return $"CVS-{groupCode}{orientation}{placement}-{capacity}{consumption}-{order:000}";
        }

        private async Task SaveAttachmentsAsync(SalesRequest request, IEnumerable<IFormFile> files)
        {
            var validFiles = files?.Where(x => x.Length > 0).ToList() ?? new List<IFormFile>();
            if (!validFiles.Any()) return;

            _context.Entry(request).State = EntityState.Unchanged;

            var root = Path.Combine(_environment.WebRootPath, "uploads", "sales-requests", request.Id.ToString());
            Directory.CreateDirectory(root);

            var attachments = new List<SalesRequestAttachment>();
            foreach (var file in validFiles)
            {
                var storedFileName = $"{Guid.NewGuid():N}{Path.GetExtension(file.FileName)}";
                var fullPath = Path.Combine(root, storedFileName);
                await using var stream = System.IO.File.Create(fullPath);
                await file.CopyToAsync(stream);
                attachments.Add(new SalesRequestAttachment
                {
                    SalesRequestId = request.Id,
                    OriginalFileName = Path.GetFileName(file.FileName),
                    StoredFileName = storedFileName,
                    RelativePath = $"/uploads/sales-requests/{request.Id}/{storedFileName}",
                    ContentType = file.ContentType,
                    FileSize = file.Length
                });
            }

            await _context.SalesRequestAttachments.AddRangeAsync(attachments);
            await _context.SaveChangesAsync();
        }
    }
}
