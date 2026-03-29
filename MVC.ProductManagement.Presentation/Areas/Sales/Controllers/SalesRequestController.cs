using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using MVC.ProductManagement.Domain.Entities.SalesRequests;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.SalesRequestVMs;
using System.Security.Claims;
using System.Text.Json.Nodes;
using System.Text.Json;

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

            var profile = await GetCurrentSalesProfileAsync();
            var currentUserName = User.Identity?.Name;
            var currentUserEmail = User.FindFirstValue(ClaimTypes.Email);
            var isManagerUser = await CanAccessSalesManagerPanelAsync();

            if (!User.IsInRole("Admin") && !isManagerUser)
            {
                requests = requests
                    .Where(x =>
                        (!string.IsNullOrWhiteSpace(profile?.Email) && string.Equals(x.RequestedByEmail, profile.Email, StringComparison.OrdinalIgnoreCase)) ||
                        (!string.IsNullOrWhiteSpace(currentUserEmail) && string.Equals(x.RequestedByEmail, currentUserEmail, StringComparison.OrdinalIgnoreCase)) ||
                        (!string.IsNullOrWhiteSpace(profile?.FullName) && string.Equals(x.RequestedByName, profile.FullName, StringComparison.OrdinalIgnoreCase)) ||
                        (!string.IsNullOrWhiteSpace(currentUserName) && string.Equals(x.RequestedByName, currentUserName, StringComparison.OrdinalIgnoreCase)))
                    .ToList();
            }
            else if (!User.IsInRole("Admin") && !isManagerUser && !string.IsNullOrWhiteSpace(profile?.Location))
            {
                requests = requests
                    .Where(x => string.Equals(x.Customer.Region, profile.Location, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

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
                    RequestReceivedAt = x.RequestReceivedAt,
                    NeededByDate = x.NeededByDate,
                    WorkflowStatus = x.WorkflowStatus,
                    CustomerQuoteStatus = x.CustomerQuoteStatus,
                    OfferStatus = x.OfferStatus,
                    RevisionNo = x.RevisionNo,
                    ItemCount = x.Items.Count,
                    AttachmentCount = x.Attachments.Count,
                    ApprovedSalesPriceTotal = x.Items.Where(i => i.ApprovedSalesPrice.HasValue).Sum(i => i.ApprovedSalesPrice),
                    HasCostAnalysis = x.Items.Any(i => i.LinkedCostAnalysisTotal.HasValue)
                }).ToList()
            };

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> ManagerPanel(string? regionFilter, string? customerFilter, string? salespersonFilter, string? productFilter)
        {
            if (!await CanAccessSalesManagerPanelAsync())
            {
                return Forbid();
            }

            var profile = await GetCurrentSalesProfileAsync();
            var region = profile?.Location;
            var isManagerUser = await CanAccessSalesManagerPanelAsync();

            var requestsQuery = _context.SalesRequests
                .AsNoTracking()
                .Include(x => x.Customer)
                .Include(x => x.Items)
                .Where(x => x.Status != Status.Deleted && x.RequestSource == SalesRequestSource.Sales);

            if (!User.IsInRole("Admin") && !isManagerUser && !string.IsNullOrWhiteSpace(region))
            {
                requestsQuery = requestsQuery.Where(x => x.Customer.Region == region);
            }

            if (!string.IsNullOrWhiteSpace(regionFilter))
            {
                requestsQuery = requestsQuery.Where(x => x.Customer.Region == regionFilter);
            }

            if (!string.IsNullOrWhiteSpace(customerFilter))
            {
                requestsQuery = requestsQuery.Where(x => x.Customer.CompanyName == customerFilter);
            }

            if (!string.IsNullOrWhiteSpace(salespersonFilter))
            {
                requestsQuery = requestsQuery.Where(x => x.RequestedByName == salespersonFilter);
            }

            if (!string.IsNullOrWhiteSpace(productFilter))
            {
                var normalizedProduct = productFilter.Trim();
                requestsQuery = requestsQuery.Where(x => x.Items.Any(i =>
                    (!string.IsNullOrWhiteSpace(i.ProductCode) && i.ProductCode.Contains(normalizedProduct)) ||
                    (!string.IsNullOrWhiteSpace(i.ItemTitle) && i.ItemTitle.Contains(normalizedProduct))));
            }

            var requests = await requestsQuery
                .OrderByDescending(x => x.CreatedDate)
                .ToListAsync();

            var today = DateTime.UtcNow.Date;
            var regionOptions = requests
                .Select(x => x.Customer.Region)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Distinct()
                .OrderBy(x => x)
                .Select(x => new SelectListItem(x!, x!))
                .ToList();

            var salespersonOptions = requests
                .Select(x => x.RequestedByName)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Distinct()
                .OrderBy(x => x)
                .Select(x => new SelectListItem(x, x))
                .ToList();

            var customerOptions = requests
                .Select(x => x.Customer.CompanyName)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Distinct()
                .OrderBy(x => x)
                .Select(x => new SelectListItem(x, x))
                .ToList();

            var vm = new SalesManagerReviewVm
            {
                IncomingCount = requests.Count(x => x.WorkflowStatus == SalesRequestWorkflowStatus.PricingInProgress || x.WorkflowStatus == SalesRequestWorkflowStatus.Submitted),
                ApprovedTodayCount = requests.Count(x => x.WorkflowStatus == SalesRequestWorkflowStatus.Approved && x.ModifiedDate.HasValue && x.ModifiedDate.Value.Date == today),
                RejectedTodayCount = requests.Count(x => x.WorkflowStatus == SalesRequestWorkflowStatus.Rejected && x.ModifiedDate.HasValue && x.ModifiedDate.Value.Date == today),
                RegionFilter = regionFilter,
                CustomerFilter = customerFilter,
                SalespersonFilter = salespersonFilter,
                ProductFilter = productFilter,
                RegionOptions = regionOptions,
                CustomerOptions = customerOptions,
                SalespersonOptions = salespersonOptions,
                Requests = requests.Select(x => new SalesManagerReviewRowVm
                {
                    Id = x.Id,
                    RequestNo = x.RequestNo,
                    Title = x.Title,
                    CustomerName = x.Customer.CompanyName,
                    SalespersonName = x.RequestedByName,
                    Region = x.Customer.Region,
                    RevisionCode = $"R{x.RevisionNo:00}",
                    SalesOpenedAt = x.SalesOpenedAt,
                    ItemCount = x.Items.Count,
                    LinkedCostTotal = x.Items.Where(i => i.LinkedCostAnalysisTotal.HasValue).Sum(i => i.LinkedCostAnalysisTotal),
                    MinimumSalesPriceTotal = x.Items.Where(i => i.MinimumSalesPrice.HasValue).Sum(i => i.MinimumSalesPrice),
                    ApprovedSalesPriceTotal = x.Items.Where(i => i.ApprovedSalesPrice.HasValue).Sum(i => i.ApprovedSalesPrice),
                    CustomerQuoteStatus = x.CustomerQuoteStatus,
                    WorkflowStatus = x.WorkflowStatus
                }).ToList()
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManagerDecision(Guid id, bool approve)
        {
            if (!await CanAccessSalesManagerPanelAsync())
            {
                return Forbid();
            }

            var entity = await _context.SalesRequests
                .Include(x => x.Items)
                .Include(x => x.Customer)
                .FirstOrDefaultAsync(x => x.Id == id && x.Status != Status.Deleted && x.RequestSource == SalesRequestSource.Sales);
            if (entity == null)
            {
                return NotFound();
            }

            var profile = await GetCurrentSalesProfileAsync();
            var isManagerUser = await CanAccessSalesManagerPanelAsync();
            if (!User.IsInRole("Admin") && !isManagerUser && !string.IsNullOrWhiteSpace(profile?.Location)
                && !string.Equals(entity.Customer.Region, profile.Location, StringComparison.OrdinalIgnoreCase))
            {
                return Forbid();
            }

            if (approve)
            {
                entity.WorkflowStatus = SalesRequestWorkflowStatus.Approved;
                entity.ApprovedAt = DateTime.UtcNow;
                foreach (var item in entity.Items.Where(x => x.WorkflowStatus != SalesRequestWorkflowStatus.Rejected))
                {
                    item.WorkflowStatus = SalesRequestWorkflowStatus.Approved;
                }
                TempData["SuccessMessage"] = $"{entity.RequestNo} satış müdürü tarafından onaylandı.";
            }
            else
            {
                entity.WorkflowStatus = SalesRequestWorkflowStatus.Rejected;
                entity.ApprovedAt = null;
                foreach (var item in entity.Items)
                {
                    item.WorkflowStatus = SalesRequestWorkflowStatus.Rejected;
                }
                TempData["SuccessMessage"] = $"{entity.RequestNo} satış müdürü tarafından reddedildi.";
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManagerPanel));
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
                OfferStatus = SalesOfferStatus.F,
                RequestReceivedAt = DateTime.UtcNow.Date,
                Items = new List<SalesRequestItemInputVm> { new() }
            };

            await PopulateRequesterInfoAsync(vm, overwriteExisting: true);
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

            await PopulateRequesterInfoAsync(vm, overwriteExisting: true);
            vm.OfferStatus = SalesOfferStatus.F;
            vm.Items = vm.Items
                .Where(x => x.ProductGroupId != Guid.Empty || !string.IsNullOrWhiteSpace(x.SparePartDetails))
                .ToList();
            if (!vm.Items.Any())
            {
                ModelState.AddModelError(string.Empty, "En az bir talep satırı girmelisiniz.");
            }

            for (var i = 0; i < vm.Items.Count; i++)
            {
                if (vm.Items[i].ProductGroupId == Guid.Empty)
                {
                    ModelState.AddModelError($"Items[{i}].ProductGroupId", "Akışkan grubu seçimi zorunludur.");
                }
            }

            if (vm.Items.Any(x => x.RequestCategory == SalesRequestCategory.SparePart) &&
                (vm.Attachments == null || vm.Attachments.Count == 0))
            {
                ModelState.AddModelError(nameof(vm.Attachments), "Yedek parça talebi için en az bir ek yüklemelisiniz.");
            }

            for (var i = 0; i < vm.Items.Count; i++)
            {
                NormalizeAndValidateItem(vm.Items[i], $"Items[{i}]");
            }

            var salesOpenedAt = DateTime.UtcNow;
            if (vm.RequestReceivedAt.HasValue && vm.RequestReceivedAt.Value.Date > salesOpenedAt.Date)
            {
                ModelState.AddModelError(nameof(vm.RequestReceivedAt), "Talep alma tarihi, talep giriş tarihinden büyük olamaz.");
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
                RequestReceivedAt = vm.RequestReceivedAt?.Date ?? salesOpenedAt.Date,
                NeededByDate = vm.NeededByDate.Date,
                RequestSource = SalesRequestSource.Sales,
                ShipmentCountry = vm.ShipmentCountry,
                InstallationCountry = vm.InstallationCountry,
                IsTransportByCustomer = vm.IsTransportByCustomer,
                SummaryNotes = vm.SummaryNotes,
                WorkflowStatus = SalesRequestWorkflowStatus.Submitted,
                OfferStatus = SalesOfferStatus.F,
                SalesOpenedAt = salesOpenedAt
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
            var revisions = await _context.SalesRequestRevisions
                .AsNoTracking()
                .Where(x => x.SalesRequestId == id && x.Status != Status.Deleted)
                .OrderByDescending(x => x.RevisionNo)
                .ToListAsync();

            var vm = MapDetailVm(entity, revisions, canViewPricing);
            vm.DocumentUpload.SalesRequestId = id;
            vm.NewComment.SalesRequestId = id;
            var isManagerUser = await CanAccessSalesManagerPanelAsync();
            vm.CanUploadPidDocument = isManagerUser;
            vm.CanDownloadDocuments = entity.WorkflowStatus == SalesRequestWorkflowStatus.Approved;
            ViewBag.WaitingManagerApproval = entity.WorkflowStatus != SalesRequestWorkflowStatus.Approved;
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Revise(Guid id)
        {
            if (!await HasSalesPermissionAsync(x => x.CanCreateSalesRequests || x.CanAccessSalesArea))
            {
                return Forbid();
            }

            var entity = await _context.SalesRequests
                .AsNoTracking()
                .Include(x => x.Items)
                .FirstOrDefaultAsync(x => x.Id == id && x.Status != Status.Deleted && x.RequestSource == SalesRequestSource.Sales);
            if (entity == null) return NotFound();

            var vm = new SalesRequestCreateVm
            {
                Id = entity.Id,
                CustomerId = entity.CustomerId,
                RequestedByName = entity.RequestedByName,
                RequestedByEmail = entity.RequestedByEmail,
                RequestedByDepartment = entity.RequestedByDepartment,
                RequestReceivedAt = entity.RequestReceivedAt,
                NeededByDate = entity.NeededByDate,
                RequestSource = entity.RequestSource,
                ShipmentCountry = entity.ShipmentCountry,
                InstallationCountry = entity.InstallationCountry,
                IsTransportByCustomer = entity.IsTransportByCustomer,
                OfferStatus = entity.OfferStatus,
                SummaryNotes = entity.SummaryNotes,
                Items = entity.Items
                    .OrderBy(x => x.DisplayOrder)
                    .Select(x => new SalesRequestItemInputVm
                    {
                        ParentSalesRequestItemId = x.ParentSalesRequestItemId,
                        ProductGroupId = x.ProductGroupId,
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
                        MinimumTechnicalNotes = x.MinimumTechnicalNotes
                    }).ToList()
            };

            await PopulateFormAsync(vm);
            ViewBag.IsEdit = true;
            ViewBag.IsRevision = true;
            return View("~/Areas/Admin/Views/SalesRequest/Create.cshtml", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestFormLimits(MultipartBodyLengthLimit = 50_000_000)]
        public async Task<IActionResult> Revise(Guid id, SalesRequestCreateVm vm)
        {
            if (!await HasSalesPermissionAsync(x => x.CanCreateSalesRequests || x.CanAccessSalesArea))
            {
                return Forbid();
            }

            vm.Id = id;
            await PopulateRequesterInfoAsync(vm, overwriteExisting: true);
            vm.Items = vm.Items.Where(x => x.ProductGroupId != Guid.Empty).ToList();
            if (!vm.Items.Any())
            {
                ModelState.AddModelError(string.Empty, "En az bir talep satırı girmelisiniz.");
            }

            if (string.IsNullOrWhiteSpace(vm.RevisionReason))
            {
                ModelState.AddModelError(nameof(vm.RevisionReason), "Revizyon açıklaması zorunludur.");
            }

            var entity = await _context.SalesRequests
                .Include(x => x.Items)
                .Include(x => x.Documents)
                .Include(x => x.Comments)
                .FirstOrDefaultAsync(x => x.Id == id && x.Status != Status.Deleted && x.RequestSource == SalesRequestSource.Sales);
            if (entity == null) return NotFound();

            if (vm.RequestReceivedAt.HasValue && vm.RequestReceivedAt.Value.Date > entity.SalesOpenedAt.Date)
            {
                ModelState.AddModelError(nameof(vm.RequestReceivedAt), "Talep alma tarihi, talep giriş tarihinden büyük olamaz.");
            }

            if (!ModelState.IsValid)
            {
                await PopulateFormAsync(vm);
                ViewBag.IsEdit = true;
                ViewBag.IsRevision = true;
                return View("~/Areas/Admin/Views/SalesRequest/Create.cshtml", vm);
            }

            await AddRevisionSnapshotAsync(entity, vm.RevisionReason!);

            entity.CustomerId = vm.CustomerId;
            entity.RequestedByName = vm.RequestedByName;
            entity.RequestedByEmail = vm.RequestedByEmail;
            entity.RequestedByDepartment = vm.RequestedByDepartment;
            entity.RequestReceivedAt = vm.RequestReceivedAt?.Date;
            entity.NeededByDate = vm.NeededByDate.Date;
            entity.RequestSource = SalesRequestSource.Sales;
            entity.ShipmentCountry = vm.ShipmentCountry;
            entity.InstallationCountry = vm.InstallationCountry;
            entity.IsTransportByCustomer = vm.IsTransportByCustomer;
            entity.SummaryNotes = vm.SummaryNotes;
            entity.Title = await BuildRequestTitleAsync(vm.Items.First());
            entity.WorkflowStatus = SalesRequestWorkflowStatus.Submitted;
            entity.CustomerQuoteStatus = SalesCustomerQuoteStatus.PreparingSpecification;
            entity.PricingCompletedAt = null;
            entity.ApprovedAt = null;
            entity.RevisionNo += 1;

            var existingItems = entity.Items.ToList();
            _context.SalesRequestItems.RemoveRange(existingItems);

            var groups = await _context.SalesRequestProductGroups.AsNoTracking().ToDictionaryAsync(x => x.Id);
            var itemOrder = 1;
            foreach (var itemVm in vm.Items)
            {
                var group = groups[itemVm.ProductGroupId];
                _context.SalesRequestItems.Add(new SalesRequestItem
                {
                    SalesRequestId = entity.Id,
                    ProductGroupId = itemVm.ProductGroupId,
                    CapacityM3 = itemVm.CapacityM3,
                    ConsumptionCapacity = itemVm.ConsumptionCapacity,
                    RequestCategory = itemVm.RequestCategory,
                    ProductCode = group.ShortCode,
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

            await _context.SaveChangesAsync();
            await SaveAttachmentsAsync(entity, vm.Attachments);

            TempData["SuccessMessage"] = $"Talep revize edildi (R{entity.RevisionNo:00}).";
            return RedirectToAction(nameof(Details), new { id = entity.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCustomerQuoteStatus(Guid id, SalesCustomerQuoteStatus customerQuoteStatus)
        {
            if (!await HasSalesPermissionAsync(x => x.CanAccessSalesArea))
            {
                return Forbid();
            }

            var entity = await _context.SalesRequests
                .Include(x => x.Items)
                .FirstOrDefaultAsync(x => x.Id == id && x.Status != Status.Deleted && x.RequestSource == SalesRequestSource.Sales);
            if (entity == null)
            {
                return NotFound();
            }

            entity.CustomerQuoteStatus = customerQuoteStatus;
            if (customerQuoteStatus == SalesCustomerQuoteStatus.SharedWithCustomer)
            {
                foreach (var item in entity.Items)
                {
                    item.SharedSalesPrice ??= item.ApprovedSalesPrice;
                }
            }
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Müşteri teklif durumu güncellendi.";
            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateOfferStatus(Guid id, SalesOfferStatus offerStatus)
        {
            if (!await HasSalesPermissionAsync(x => x.CanAccessSalesArea))
            {
                return Forbid();
            }

            var entity = await _context.SalesRequests
                .FirstOrDefaultAsync(x => x.Id == id && x.Status != Status.Deleted && x.RequestSource == SalesRequestSource.Sales);
            if (entity == null)
            {
                return NotFound();
            }

            if (entity.CustomerQuoteStatus != SalesCustomerQuoteStatus.SharedWithCustomer)
            {
                TempData["ErrorMessage"] = "Teklif durumu sadece teklif müşteriye iletildikten sonra güncellenebilir.";
                return RedirectToAction(nameof(Details), new { id });
            }

            entity.OfferStatus = offerStatus;
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Teklif durumu güncellendi.";
            return RedirectToAction(nameof(Details), new { id });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(SalesRequestCommentCreateVm vm)
        {
            if (!await HasSalesPermissionAsync(x => x.CanAccessSalesArea))
            {
                return Forbid();
            }

            if (string.IsNullOrWhiteSpace(vm.CommentText))
            {
                TempData["ErrorMessage"] = "Yorum alanı zorunludur.";
                return RedirectToAction(nameof(Details), new { id = vm.SalesRequestId });
            }

            var request = await _context.SalesRequests
                .FirstOrDefaultAsync(x => x.Id == vm.SalesRequestId && x.Status != Status.Deleted && x.RequestSource == SalesRequestSource.Sales);
            if (request == null)
            {
                return NotFound();
            }

            _context.SalesRequestComments.Add(new SalesRequestComment
            {
                SalesRequestId = request.Id,
                CommentText = vm.CommentText.Trim(),
                CommentedBy = User.Identity?.Name ?? "System"
            });

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Yorum kaydedildi.";
            return RedirectToAction(nameof(Details), new { id = vm.SalesRequestId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestFormLimits(MultipartBodyLengthLimit = 50_000_000)]
        public async Task<IActionResult> UploadDocument(SalesRequestDocumentUploadVm vm)
        {
            if (!await CanAccessSalesManagerPanelAsync())
            {
                return Forbid();
            }

            var request = await _context.SalesRequests
                .Include(x => x.Documents)
                .Include(x => x.Comments)
                .FirstOrDefaultAsync(x => x.Id == vm.SalesRequestId && x.Status != Status.Deleted && x.RequestSource == SalesRequestSource.Sales);
            if (request == null)
            {
                return NotFound();
            }

            if (vm.File == null || vm.File.Length == 0 || string.IsNullOrWhiteSpace(vm.RevisionCode))
            {
                TempData["ErrorMessage"] = "Doküman yüklemek için dosya ve revizyon kodu zorunludur.";
                return RedirectToAction(nameof(Details), new { id = vm.SalesRequestId });
            }

            if (vm.DocumentType != SalesDocumentType.PID)
            {
                TempData["ErrorMessage"] = "Bu akışta yalnızca PID dokümanı satış müdürü tarafından yüklenebilir.";
                return RedirectToAction(nameof(Details), new { id = vm.SalesRequestId });
            }

            var uploadsRoot = Path.Combine(_environment.WebRootPath, "uploads", "sales-documents", request.Id.ToString("N"));
            Directory.CreateDirectory(uploadsRoot);
            var fileName = $"{Guid.NewGuid():N}_{Path.GetFileName(vm.File.FileName)}";
            var fullPath = Path.Combine(uploadsRoot, fileName);
            await using (var fs = new FileStream(fullPath, FileMode.Create))
            {
                await vm.File.CopyToAsync(fs);
            }

            foreach (var previous in request.Documents.Where(x => x.DocumentType == vm.DocumentType && x.IsCurrent))
            {
                previous.IsCurrent = false;
            }

            request.Documents.Add(new SalesRequestDocument
            {
                SalesRequestId = request.Id,
                SalesRequestItemId = vm.SalesRequestItemId,
                DocumentType = vm.DocumentType,
                RevisionCode = vm.RevisionCode.Trim().ToUpperInvariant(),
                FilePath = $"/uploads/sales-documents/{request.Id:N}/{fileName}",
                OriginalFileName = vm.File.FileName,
                UploadedBy = User.Identity?.Name ?? "System",
                UploadedAt = DateTime.UtcNow,
                IsCurrent = true,
                LinkedCostAnalysisId = vm.LinkedCostAnalysisId,
                LinkedCostAnalysisRevisionCode = vm.LinkedCostAnalysisRevisionCode,
                Notes = vm.Notes
            });

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Doküman revizyonu yüklendi.";
            return RedirectToAction(nameof(Details), new { id = vm.SalesRequestId });
        }

        [HttpGet]
        public async Task<IActionResult> DownloadDocument(Guid requestId, Guid documentId)
        {
            if (!await HasSalesPermissionAsync(x => x.CanAccessSalesArea))
            {
                return Forbid();
            }

            var request = await _context.SalesRequests
                .AsNoTracking()
                .Include(x => x.Documents)
                .Include(x => x.Comments)
                .FirstOrDefaultAsync(x => x.Id == requestId && x.Status != Status.Deleted && x.RequestSource == SalesRequestSource.Sales);
            if (request == null)
            {
                return NotFound();
            }

            if (request.WorkflowStatus != SalesRequestWorkflowStatus.Approved)
            {
                return Forbid();
            }

            var document = request.Documents.FirstOrDefault(x => x.Id == documentId);
            if (document == null)
            {
                return NotFound();
            }

            var relativePath = document.FilePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar);
            var fullPath = Path.Combine(_environment.WebRootPath, relativePath);
            if (!System.IO.File.Exists(fullPath))
            {
                return NotFound();
            }

            return PhysicalFile(fullPath, "application/octet-stream", document.OriginalFileName);
        }

        [HttpGet]
        public async Task<IActionResult> TechnicalDetails(Guid requestId, Guid itemId)
        {
            if (!await HasSalesPermissionAsync(x => x.CanAccessSalesArea))
            {
                return Forbid();
            }
            var vm = await BuildTechnicalDetailsVmAsync(requestId, itemId);
            if (vm == null)
            {
                return NotFound();
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

            var vm = await BuildTechnicalDetailsVmAsync(requestId, itemId);
            if (vm == null || !vm.HasSpecification)
            {
                return NotFound();
            }
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> DownloadSpecificationWord(Guid requestId, Guid itemId)
        {
            if (!await HasSalesPermissionAsync(x => x.CanAccessSalesArea))
            {
                return Forbid();
            }

            var vm = await BuildTechnicalDetailsVmAsync(requestId, itemId);
            if (vm == null || !vm.HasSpecification)
            {
                return NotFound();
            }

            using var stream = new MemoryStream();
            using (var document = WordprocessingDocument.Create(stream, WordprocessingDocumentType.Document, true))
            {
                var mainPart = document.AddMainDocumentPart();
                mainPart.Document = new Document(new Body());
                var body = mainPart.Document.Body!;

                body.Append(CreateParagraph($"TECHNICAL SPECIFICATION - {vm.ItemCode}", true, JustificationValues.Center));
                body.Append(CreateParagraph($"{vm.CalculationName} / Rev: {vm.RevisionCode ?? "-"}", false, JustificationValues.Center));
                body.Append(CreateParagraph(string.Empty));

                body.Append(CreateParagraph("General", true));
                AppendFieldTable(body, vm.InputFields);

                body.Append(CreateParagraph("Inner Tank", true));
                AppendFieldTable(body, vm.InnerTankFields);

                body.Append(CreateParagraph("Outer Tank", true));
                AppendFieldTable(body, vm.OuterTankFields);

                body.Append(CreateParagraph("Standard Notes", true));
                body.Append(CreateParagraph("• Design and manufacturing according to selected applicable standard."));
                body.Append(CreateParagraph("• Material certificates, pressure test certificate and final inspection report are included."));
                body.Append(CreateParagraph("• Surface preparation, painting, and insulation shall be as standard company practice."));
                body.Append(CreateParagraph("• Warranty and commercial clauses are subject to final quotation terms."));
            }

            var fileName = $"Specification_{vm.ItemCode}_{DateTime.UtcNow:yyyyMMddHHmmss}.docx";
            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", fileName);
        }

        private async Task<SalesRequestTechnicalDetailsVm?> BuildTechnicalDetailsVmAsync(Guid requestId, Guid itemId)
        {
            var request = await LoadRequestAsync(requestId);
            if (request == null)
            {
                return null;
            }

            var item = request.Items.FirstOrDefault(x => x.Id == itemId);
            if (item == null || !item.LinkedCalculationType.HasValue || !item.LinkedCalculationId.HasValue)
            {
                return null;
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
                    .Include(x => x.StorageService)
                    .Include(x => x.InnerShellMaterial)
                    .Include(x => x.InnerShellMaterialForm)
                    .Include(x => x.InnerHeadMaterial)
                    .Include(x => x.InnerHeadMaterialForm)
                    .Include(x => x.OuterShellMaterial)
                    .Include(x => x.OuterShellMaterialForm)
                    .Include(x => x.OuterHeadMaterial)
                    .Include(x => x.OuterHeadMaterialForm)
                    .FirstOrDefaultAsync(x => x.Id == item.LinkedCalculationId.Value && x.Status != Status.Deleted);

                if (calculation == null)
                {
                    return null;
                }

                vm.MAWP = $"{(calculation.DesignPressure > 0 ? calculation.DesignPressure : calculation.Pressure):N2} bar";
                vm.DesignPressure = $"{calculation.DesignPressure:N2} bar";
                vm.TestPressure = $"{calculation.TestPressure:N2} bar";
                vm.RoundedShellThickness = $"İç: {calculation.RoundedInnerShellThickness:N2} mm / Dış: {calculation.RoundedOuterShellThickness:N2} mm";
                vm.RoundedHeadThickness = $"İç: {calculation.RoundedInnerHeadThickness:N2} mm / Dış: {calculation.RoundedOuterHeadThickness:N2} mm";
                vm.InnerTankLength = $"{calculation.InnerTankTotalLength:N2} mm";
                vm.TankDiameter = $"İç: {calculation.OuterDiameter:N2} mm / Dış: {calculation.OuterTankDiameter:N2} mm";

                vm.TankDetailFields = new List<SalesRequestTechnicalFieldVm>
                {
                    new() { Label = "Hesap Adı", Value = calculation.Name },
                    new() { Label = "İç Tank Çapı", Value = $"{calculation.OuterDiameter:N2} mm" },
                    new() { Label = "Dış Tank Çapı", Value = $"{calculation.OuterTankDiameter:N2} mm" },
                    new() { Label = "Silindirik Boy", Value = $"{calculation.ShellLength:N2} mm" },
                    new() { Label = "Design Pressure", Value = $"{calculation.DesignPressure:N2} bar" },
                    new() { Label = "Test Pressure", Value = $"{calculation.TestPressure:N2} bar" },
                    new() { Label = "Static Pressure", Value = $"{calculation.StaticPressure:N2} bar" },
                    new() { Label = "Yuvarlanmış İç Gövde Et", Value = $"{calculation.RoundedInnerShellThickness:N2} mm" },
                    new() { Label = "Yuvarlanmış İç Bombe Et", Value = $"{calculation.RoundedInnerHeadThickness:N2} mm" },
                    new() { Label = "Yuvarlanmış Dış Gövde Et", Value = $"{calculation.RoundedOuterShellThickness:N2} mm" },
                    new() { Label = "Yuvarlanmış Dış Bombe Et", Value = $"{calculation.RoundedOuterHeadThickness:N2} mm" },
                    new() { Label = "İç Tank Toplam Uzunluk", Value = $"{calculation.InnerTankTotalLength:N2} mm" },
                    new() { Label = "Dış Tank Toplam Uzunluk", Value = $"{calculation.OuterTankTotalLength:N2} mm" },
                    new() { Label = "Toplam Kaynak Uzunluğu", Value = $"{calculation.TotalWeldLength:N2} m" }
                };

                vm.InputFields = new List<SalesRequestTechnicalFieldVm>
                {
                    new() { Label = "Ad", Value = calculation.Name },
                    new() { Label = "İç Tank Çapı", Value = $"{calculation.OuterDiameter:N0}" },
                    new() { Label = "Dış Tank Çapı", Value = $"{calculation.OuterTankDiameter:N0}" },
                    new() { Label = "Silindirik Boy", Value = $"{calculation.ShellLength:N0}" },
                    new() { Label = "Basınç", Value = $"{calculation.Pressure:N2}" },
                    new() { Label = "Depolanacak Ürün", Value = calculation.StorageService?.Name ?? "-" },
                    new() { Label = "Sıvı Yoğunluğu", Value = $"{calculation.LiquidDensity:N2}" },
                    new() { Label = "Tank Yönelimi", Value = "Horizontal" },
                    new() { Label = "Kaynak metrajları", Value = $"1500: {calculation.WeldLength1500:N2} m | 2000: {calculation.WeldLength2000:N2} m | 2500: {calculation.WeldLength2500:N2} m | 3000: {calculation.WeldLength3000:N2} m" },
                    new() { Label = "İç Tank Kaynak Metrajı", Value = $"{(calculation.InnerTankHeadWeldLength + calculation.InnerTankCircumferenceWeldLength):N2} m" },
                    new() { Label = "Dış Tank Kaynak Metrajı", Value = $"{(calculation.OuterTankHeadWeldLength + calculation.OuterTankCircumferenceWeldLength):N2} m" },
                    new() { Label = "Toplam Kaynak", Value = $"{calculation.TotalWeldLength:N2} m" }
                };

                vm.InnerTankFields = new List<SalesRequestTechnicalFieldVm>
                {
                    new() { Label = "Gövde Malzemesi", Value = calculation.InnerShellMaterial?.Name ?? "-" },
                    new() { Label = "Gövde Malzeme Formu", Value = calculation.InnerShellMaterialForm?.FormType.ToString() ?? "-" },
                    new() { Label = "Bombe Malzemesi", Value = calculation.InnerHeadMaterial?.Name ?? "-" },
                    new() { Label = "Bombe Malzeme Formu", Value = calculation.InnerHeadMaterialForm?.FormType.ToString() ?? "-" },
                    new() { Label = "Gövde Akma Dayanımı (MPa)", Value = $"{calculation.InnerShellMaterialStrength:N2}" },
                    new() { Label = "Bombe Akma Dayanımı (MPa)", Value = $"{calculation.InnerHeadMaterialStrength:N2}" },
                    new() { Label = "Gövde Kalınlığı", Value = $"{calculation.InnerShellThickness:N2}" },
                    new() { Label = "Bombe Kalınlığı", Value = $"{calculation.InnerHeadThickness:N2}" },
                    new() { Label = "Yuvarlanmış Gövde Kalınlığı", Value = $"{calculation.RoundedInnerShellThickness:N2}" },
                    new() { Label = "Yuvarlanmış Bombe Kalınlığı", Value = $"{calculation.RoundedInnerHeadThickness:N2}" },
                    new() { Label = "Bombe Pulu Çapı", Value = $"{calculation.InnerTankHeadPulDiameter:N2}" },
                    new() { Label = "Toplam Uzunluk", Value = $"{calculation.InnerTankTotalLength:N2}" },
                    new() { Label = "İç Hacim", Value = $"{calculation.InnerVolume:N2}" },
                    new() { Label = "İç Yüzey Alanı", Value = $"{calculation.InnerSurfaceArea:N2}" },
                    new() { Label = "Bombe Ağırlığı", Value = $"{calculation.InnerTankHeadWeight:N2}" },
                    new() { Label = "Tank Ağırlığı", Value = $"{calculation.InnerTankWeight:N2}" }
                };

                vm.OuterTankFields = new List<SalesRequestTechnicalFieldVm>
                {
                    new() { Label = "Gövde Malzemesi", Value = calculation.OuterShellMaterial?.Name ?? "-" },
                    new() { Label = "Gövde Malzeme Formu", Value = calculation.OuterShellMaterialForm?.FormType.ToString() ?? "-" },
                    new() { Label = "Bombe Malzemesi", Value = calculation.OuterHeadMaterial?.Name ?? "-" },
                    new() { Label = "Bombe Malzeme Formu", Value = calculation.OuterHeadMaterialForm?.FormType.ToString() ?? "-" },
                    new() { Label = "Gövde Akma Dayanımı (MPa)", Value = $"{calculation.OuterShellMaterialStrength:N2}" },
                    new() { Label = "Bombe Akma Dayanımı (MPa)", Value = $"{calculation.OuterHeadMaterialStrength:N2}" },
                    new() { Label = "Gövde Kalınlığı", Value = $"{calculation.OuterShellThickness:N2}" },
                    new() { Label = "Bombe Kalınlığı", Value = $"{calculation.OuterHeadThickness:N2}" },
                    new() { Label = "Yuvarlanmış Gövde Kalınlığı", Value = $"{calculation.RoundedOuterShellThickness:N2}" },
                    new() { Label = "Yuvarlanmış Bombe Kalınlığı", Value = $"{calculation.RoundedOuterHeadThickness:N2}" },
                    new() { Label = "Bombe Pulu Çapı", Value = $"{calculation.OuterTankHeadPulDiameter:N2}" },
                    new() { Label = "Toplam Uzunluk", Value = $"{calculation.OuterTankTotalLength:N2}" },
                    new() { Label = "Dış Hacim", Value = $"{calculation.OuterVolume:N2}" },
                    new() { Label = "Dış Yüzey Alanı", Value = $"{calculation.OuterSurfaceArea:N2}" },
                    new() { Label = "Bombe Ağırlığı", Value = $"{calculation.OuterTankHeadWeight:N2}" },
                    new() { Label = "Tank Ağırlığı", Value = $"{calculation.OuterTankWeight:N2}" }
                };
                return vm;
            }

            var adCalculation = await _context.AD2000Calculations
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == item.LinkedCalculationId.Value && x.Status != Status.Deleted);

            if (adCalculation == null)
            {
                return null;
            }

            vm.MAWP = $"{adCalculation.DesignPressure:N2} bar";
            vm.DesignPressure = $"{adCalculation.DesignPressure:N2} bar";
            vm.TestPressure = $"{adCalculation.TestPressure:N2} bar";
            vm.RoundedShellThickness = $"{adCalculation.RoundedShellThickness:N2} mm";
            vm.RoundedHeadThickness = $"{adCalculation.RoundedHeadThickness:N2} mm";
            vm.InnerTankLength = $"{adCalculation.ShellLength:N2} mm";
            vm.TankDiameter = $"{adCalculation.Diameter:N2} mm";
            vm.TankDetailFields = new List<SalesRequestTechnicalFieldVm>
            {
                new() { Label = "Hesap Adı", Value = adCalculation.Name },
                new() { Label = "Çap", Value = $"{adCalculation.Diameter:N2} mm" },
                new() { Label = "Gövde Boyu", Value = $"{adCalculation.ShellLength:N2} mm" },
                new() { Label = "Design Pressure", Value = $"{adCalculation.DesignPressure:N2} bar" },
                new() { Label = "Test Pressure", Value = $"{adCalculation.TestPressure:N2} bar" },
                new() { Label = "Static Pressure", Value = $"{adCalculation.StaticPressure:N3} bar" },
                new() { Label = "Yuvarlanmış Gövde Et", Value = $"{adCalculation.RoundedShellThickness:N2} mm" },
                new() { Label = "Yuvarlanmış Bombe Et", Value = $"{adCalculation.RoundedHeadThickness:N2} mm" },
                new() { Label = "Korozyon Payı", Value = $"{adCalculation.CorrosionAllowance:N2} mm" },
                new() { Label = "Kaynak Faktörü", Value = adCalculation.WeldJointFactor.ToString("N2") },
                new() { Label = "Sıvı Yoğunluğu", Value = $"{adCalculation.LiquidDensity:N2} kg/m³" }
            };

            return vm;
        }

        private static Paragraph CreateParagraph(string text, bool bold = false, JustificationValues? justification = null)
        {
            var runProps = new RunProperties();
            if (bold)
            {
                runProps.Append(new Bold());
            }

            var paragraph = new Paragraph(
                new ParagraphProperties(new Justification { Val = justification ?? JustificationValues.Left }),
                new Run(runProps, new Text(text) { Space = SpaceProcessingModeValues.Preserve }));
            return paragraph;
        }

        private static void AppendFieldTable(Body body, IEnumerable<SalesRequestTechnicalFieldVm> fields)
        {
            var table = new Table(
                new TableProperties(
                    new TableBorders(
                        new TopBorder { Val = BorderValues.Single, Size = 4 },
                        new BottomBorder { Val = BorderValues.Single, Size = 4 },
                        new LeftBorder { Val = BorderValues.Single, Size = 4 },
                        new RightBorder { Val = BorderValues.Single, Size = 4 },
                        new InsideHorizontalBorder { Val = BorderValues.Single, Size = 4 },
                        new InsideVerticalBorder { Val = BorderValues.Single, Size = 4 })));

            foreach (var field in fields)
            {
                table.Append(new TableRow(
                    new TableCell(new Paragraph(new Run(new Text(field.Label)))),
                    new TableCell(new Paragraph(new Run(new Text(field.Value))))));
            }

            body.Append(table);
            body.Append(CreateParagraph(string.Empty));
        }

        private async Task<SalesRequest?> LoadRequestAsync(Guid id)
        {
            return await _context.SalesRequests
                .AsNoTracking()
                .Include(x => x.Customer)
                .Include(x => x.Attachments)
                .Include(x => x.Items)
                    .ThenInclude(x => x.ProductGroup)
                .Include(x => x.Documents)
                .Include(x => x.Comments)
                .FirstOrDefaultAsync(x => x.Id == id && x.Status != Status.Deleted && x.RequestSource == SalesRequestSource.Sales);
        }

        private static SalesRequestDetailVm MapDetailVm(SalesRequest entity, List<SalesRequestRevision> revisions, bool canViewPricing)
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
                RequestReceivedAt = entity.RequestReceivedAt,
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
                CustomerQuoteStatus = entity.CustomerQuoteStatus,
                OfferStatus = entity.OfferStatus,
                RevisionNo = entity.RevisionNo,
                IsManagerView = false,
                RevisionHistory = revisions.Select(x => new SalesRequestRevisionHistoryVm
                {
                    RevisionNo = x.RevisionNo,
                    RevisionReason = x.RevisionReason,
                    RevisedBy = x.RevisedByName,
                    RevisedAt = x.RevisedAt
                }).ToList(),
                RevisionCosts = BuildRevisionCosts(entity, revisions),
                Comments = entity.Comments
                    .Where(x => x.Status != Status.Deleted)
                    .OrderByDescending(x => x.CreatedDate)
                    .Select(x => new SalesRequestCommentVm
                    {
                        Id = x.Id,
                        CommentText = x.CommentText,
                        CommentedBy = x.CommentedBy,
                        CommentedAt = x.CreatedDate
                    }).ToList(),
                Documents = entity.Documents
                    .OrderByDescending(x => x.DocumentType)
                    .ThenByDescending(x => x.UploadedAt)
                    .Select(x => new SalesRequestDocumentVm
                    {
                        Id = x.Id,
                        DocumentTypeCode = x.DocumentType,
                        DocumentType = x.DocumentType.ToString(),
                        RevisionCode = x.RevisionCode,
                        OriginalFileName = x.OriginalFileName,
                        FilePath = x.FilePath,
                        IsCurrent = x.IsCurrent,
                        LinkedCostAnalysisRevisionCode = x.LinkedCostAnalysisRevisionCode,
                        UploadedAt = x.UploadedAt,
                        UploadedBy = x.UploadedBy
                    }).ToList(),
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

        private static List<SalesRequestRevisionCostVm> BuildRevisionCosts(SalesRequest entity, List<SalesRequestRevision> revisions)
        {
            var revisionCosts = new List<SalesRequestRevisionCostVm>();

            foreach (var revision in revisions.OrderByDescending(x => x.RevisionNo))
            {
                var items = ParseSnapshotItems(revision.SnapshotJson);
                revisionCosts.Add(new SalesRequestRevisionCostVm
                {
                    RevisionNo = revision.RevisionNo,
                    RevisionReason = revision.RevisionReason,
                    RevisedBy = revision.RevisedByName,
                    RevisedAt = revision.RevisedAt,
                    Items = items,
                    TotalCost = items.Where(x => x.LinkedCostAnalysisTotal.HasValue).Sum(x => x.LinkedCostAnalysisTotal)
                });
            }

            var currentItems = entity.Items
                .OrderBy(x => x.DisplayOrder)
                .Select(x => new SalesRequestRevisionCostItemVm
                {
                    ItemCode = x.ItemCode,
                    ItemTitle = x.ItemTitle,
                    CapacityM3 = x.CapacityM3,
                    LinkedCostAnalysisRevisionCode = x.LinkedCostAnalysisRevisionCode,
                    LinkedCostAnalysisTotal = x.LinkedCostAnalysisTotal,
                    SharedSalesPrice = x.SharedSalesPrice ?? x.ApprovedSalesPrice,
                    SoldSalesPrice = x.SoldSalesPrice ?? x.ApprovedSalesPrice
                })
                .ToList();

            revisionCosts.Insert(0, new SalesRequestRevisionCostVm
            {
                RevisionNo = entity.RevisionNo,
                RevisionReason = "Aktif revizyon",
                RevisedBy = entity.RequestedByName,
                RevisedAt = entity.ModifiedDate ?? entity.CreatedDate,
                Items = currentItems,
                TotalCost = currentItems.Where(x => x.LinkedCostAnalysisTotal.HasValue).Sum(x => x.LinkedCostAnalysisTotal)
            });

            return revisionCosts
                .GroupBy(x => x.RevisionNo)
                .Select(x => x.First())
                .OrderByDescending(x => x.RevisionNo)
                .ToList();
        }

        private static List<SalesRequestRevisionCostItemVm> ParseSnapshotItems(string snapshotJson)
        {
            var result = new List<SalesRequestRevisionCostItemVm>();

            if (string.IsNullOrWhiteSpace(snapshotJson))
            {
                return result;
            }

            try
            {
                var root = JsonNode.Parse(snapshotJson);
                var items = root?["Items"]?.AsArray();
                if (items == null)
                {
                    return result;
                }

                foreach (var item in items)
                {
                    if (item == null) continue;

                    result.Add(new SalesRequestRevisionCostItemVm
                    {
                        ItemCode = item["ItemCode"]?.GetValue<string?>() ?? "-",
                        ItemTitle = item["ItemTitle"]?.GetValue<string?>() ?? "-",
                        CapacityM3 = item["CapacityM3"]?.GetValue<decimal?>() ?? 0,
                        LinkedCostAnalysisRevisionCode = item["LinkedCostAnalysisRevisionCode"]?.GetValue<string?>(),
                        LinkedCostAnalysisTotal = item["LinkedCostAnalysisTotal"]?.GetValue<decimal?>(),
                        SharedSalesPrice = item["SharedSalesPrice"]?.GetValue<decimal?>() ?? item["MinimumSalesPrice"]?.GetValue<decimal?>(),
                        SoldSalesPrice = item["SoldSalesPrice"]?.GetValue<decimal?>() ?? item["ApprovedSalesPrice"]?.GetValue<decimal?>()
                    });
                }
            }
            catch
            {
                return result;
            }

            return result;
        }

        private async Task AddRevisionSnapshotAsync(SalesRequest entity, string revisionReason)
        {
            var requestorName = User.Identity?.Name ?? entity.RequestedByName;
            var snapshot = new
            {
                entity.CustomerId,
                entity.RequestedByName,
                entity.RequestedByEmail,
                entity.RequestedByDepartment,
                entity.NeededByDate,
                entity.RequestSource,
                entity.ShipmentCountry,
                entity.InstallationCountry,
                entity.IsTransportByCustomer,
                entity.SummaryNotes,
                entity.WorkflowStatus,
                entity.CustomerQuoteStatus,
                entity.RevisionNo,
                Documents = entity.Documents
                    .OrderByDescending(x => x.UploadedAt)
                    .Select(x => new
                    {
                        x.DocumentType,
                        x.RevisionCode,
                        x.FilePath,
                        x.LinkedCostAnalysisRevisionCode,
                        x.IsCurrent
                    }),
                Items = entity.Items
                    .OrderBy(x => x.DisplayOrder)
                    .Select(x => new
                    {
                        x.ProductGroupId,
                        x.CapacityM3,
                        x.ConsumptionCapacity,
                        x.RequestCategory,
                        x.ProductCode,
                        x.DesignStandardCode,
                        x.DesignPressureBar,
                        x.DesignTemperatureMin,
                        x.DesignTemperatureMax,
                        x.TankType,
                        x.StorageOption,
                        x.TransportOption,
                        x.StdOpsSelection,
                        x.SpcTechnicalDetails,
                        x.AmbientTemperatureMin,
                        x.AmbientTemperatureMax,
                        x.FacilityType,
                        x.FacilityInletPressureBar,
                        x.FacilityOutletPressureBar,
                        x.FacilityInletTemperature,
                        x.FacilityOutletTemperature,
                        x.FacilityCapacityNm3h,
                        x.HasPump,
                        x.PumpDetails,
                        x.HasElectricHeater,
                        x.ElectricHeaterDetails,
                        x.HasTankConsumptionCapacity,
                        x.AdditionalQuestionsJson,
                        x.TankOrientation,
                        x.PlacementType,
                        x.MinimumTechnicalNotes,
                        x.ItemCode,
                        x.ItemTitle,
                        x.LinkedCostAnalysisRevisionCode,
                        x.LinkedCostAnalysisTotal,
                        SharedSalesPrice = x.SharedSalesPrice ?? x.ApprovedSalesPrice,
                        SoldSalesPrice = x.SoldSalesPrice ?? x.ApprovedSalesPrice
                    })
            };

            var revision = new SalesRequestRevision
            {
                SalesRequestId = entity.Id,
                RevisionNo = entity.RevisionNo,
                RevisionReason = revisionReason,
                SnapshotJson = JsonSerializer.Serialize(snapshot),
                RevisedByName = requestorName,
                RevisedAt = DateTime.UtcNow
            };

            await _context.SalesRequestRevisions.AddAsync(revision);
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

        private void NormalizeAndValidateItem(SalesRequestItemInputVm item, string keyPrefix)
        {
            if (item.TankType == RequestTankType.Storage)
            {
                item.TransportOption = null;
            }
            else if (item.TankType == RequestTankType.Transport)
            {
                item.StorageOption = null;
            }

            if (item.TankType == RequestTankType.Storage && item.TransportOption.HasValue)
            {
                ModelState.AddModelError($"{keyPrefix}.TransportOption", "Depolama seçiliyse transport seçilemez.");
            }

            if (item.TankType == RequestTankType.Transport && item.StorageOption.HasValue)
            {
                ModelState.AddModelError($"{keyPrefix}.StorageOption", "Transport seçiliyse depolama tipi seçilemez.");
            }

            if (item.StdOpsSelection != RequestStdOpsSelection.SPC)
            {
                item.SpcTechnicalDetails = null;
            }
            else if (string.IsNullOrWhiteSpace(item.SpcTechnicalDetails))
            {
                ModelState.AddModelError($"{keyPrefix}.SpcTechnicalDetails", "SPC seçildiğinde teknik bilgi girilmelidir.");
            }

            if (item.RequestCategory == SalesRequestCategory.Tank)
            {
                if (item.CapacityM3 <= 0)
                {
                    ModelState.AddModelError($"{keyPrefix}.CapacityM3", "Tank talebi için kapasite zorunludur.");
                }

                item.SparePartDetails = null;
                item.FacilityType = null;
                item.FacilityInletPressureBar = null;
                item.FacilityOutletPressureBar = null;
                item.FacilityInletTemperature = null;
                item.FacilityOutletTemperature = null;
                item.FacilityCapacityNm3h = null;
                item.HasPump = false;
                item.PumpDetails = null;
                item.HasElectricHeater = false;
                item.ElectricHeaterDetails = null;
            }
            else if (item.RequestCategory == SalesRequestCategory.Evaporator)
            {
                item.CapacityM3 = 0;
                item.TankOrientation = RequestTankOrientation.Vertical;
                item.PlacementType = PlacementType.Aboveground;
                item.SparePartDetails = null;
                item.TankType = null;
                item.StorageOption = null;
                item.TransportOption = null;
                item.FacilityType = null;
                item.FacilityInletPressureBar = null;
                item.FacilityOutletPressureBar = null;
                item.FacilityInletTemperature = null;
                item.FacilityOutletTemperature = null;
                item.FacilityCapacityNm3h = null;
                item.HasPump = false;
                item.PumpDetails = null;
                item.HasElectricHeater = false;
                item.ElectricHeaterDetails = null;

                if (!item.AmbientTemperatureMin.HasValue)
                {
                    ModelState.AddModelError($"{keyPrefix}.AmbientTemperatureMin", "Evap talebi için ortam min sıcaklığı zorunludur.");
                }

                if (!item.AmbientTemperatureMax.HasValue)
                {
                    ModelState.AddModelError($"{keyPrefix}.AmbientTemperatureMax", "Evap talebi için ortam max sıcaklığı zorunludur.");
                }
            }
            else if (item.RequestCategory == SalesRequestCategory.Facility)
            {
                item.CapacityM3 = 0;
                item.TankOrientation = RequestTankOrientation.Vertical;
                item.PlacementType = PlacementType.Aboveground;
                item.SparePartDetails = null;
                item.TankType = null;
                item.StorageOption = null;
                item.TransportOption = null;
                item.StdOpsSelection = null;
                item.SpcTechnicalDetails = null;

                if (!item.FacilityInletPressureBar.HasValue)
                {
                    ModelState.AddModelError($"{keyPrefix}.FacilityInletPressureBar", "Tesis talebi için giriş basıncı zorunludur.");
                }

                if (!item.FacilityOutletPressureBar.HasValue)
                {
                    ModelState.AddModelError($"{keyPrefix}.FacilityOutletPressureBar", "Tesis talebi için çıkış basıncı zorunludur.");
                }

                if (item.FacilityInletPressureBar.HasValue &&
                    item.FacilityOutletPressureBar.HasValue &&
                    item.FacilityInletPressureBar.Value == item.FacilityOutletPressureBar.Value)
                {
                    ModelState.AddModelError($"{keyPrefix}.FacilityOutletPressureBar", "Tesis giriş/çıkış basınçları aynı olamaz.");
                }

                if (!item.FacilityInletTemperature.HasValue)
                {
                    ModelState.AddModelError($"{keyPrefix}.FacilityInletTemperature", "Tesis talebi için giriş sıcaklığı zorunludur.");
                }

                if (!item.FacilityOutletTemperature.HasValue)
                {
                    ModelState.AddModelError($"{keyPrefix}.FacilityOutletTemperature", "Tesis talebi için çıkış sıcaklığı zorunludur.");
                }

                if (item.FacilityInletTemperature.HasValue &&
                    item.FacilityOutletTemperature.HasValue &&
                    item.FacilityInletTemperature.Value == item.FacilityOutletTemperature.Value)
                {
                    ModelState.AddModelError($"{keyPrefix}.FacilityOutletTemperature", "Tesis giriş/çıkış sıcaklıkları aynı olamaz.");
                }
            }
            else if (item.RequestCategory == SalesRequestCategory.SparePart)
            {
                item.CapacityM3 = 0;
                item.TankOrientation = RequestTankOrientation.Vertical;
                item.PlacementType = PlacementType.Aboveground;
                item.TankType = null;
                item.StorageOption = null;
                item.TransportOption = null;
                item.StdOpsSelection = null;
                item.SpcTechnicalDetails = null;
                item.AmbientTemperatureMin = null;
                item.AmbientTemperatureMax = null;
                item.FacilityType = null;
                item.FacilityInletPressureBar = null;
                item.FacilityOutletPressureBar = null;
                item.FacilityInletTemperature = null;
                item.FacilityOutletTemperature = null;
                item.FacilityCapacityNm3h = null;
                item.HasPump = false;
                item.PumpDetails = null;
                item.HasElectricHeater = false;
                item.ElectricHeaterDetails = null;

                if (string.IsNullOrWhiteSpace(item.SparePartDetails))
                {
                    ModelState.AddModelError($"{keyPrefix}.SparePartDetails", "Yedek parça talebi için açıklama zorunludur.");
                }
            }
        }

        private async Task PopulateRequesterInfoAsync(SalesRequestCreateVm vm, bool overwriteExisting)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrWhiteSpace(userId))
            {
                return;
            }

            var profile = await _context.EmployeeProfiles
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.UserId == userId);

            var requestName = profile?.FullName ?? User.Identity?.Name;
            var requestDepartment = profile?.Department;
            var requestEmail = profile?.Email ?? User.FindFirstValue(ClaimTypes.Email);

            if (overwriteExisting || string.IsNullOrWhiteSpace(vm.RequestedByName))
            {
                vm.RequestedByName = requestName ?? string.Empty;
            }

            if (overwriteExisting || string.IsNullOrWhiteSpace(vm.RequestedByDepartment))
            {
                vm.RequestedByDepartment = requestDepartment;
            }

            if (overwriteExisting || string.IsNullOrWhiteSpace(vm.RequestedByEmail))
            {
                vm.RequestedByEmail = requestEmail;
            }
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
