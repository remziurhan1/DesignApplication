using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Domain.Entities.SalesRequests;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Application.Services.SalesRequestServices;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.SalesRequestVMs;
using System.Security.Claims;
using System.Text.Json.Nodes;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SalesRequestController : AdminBaseController
    {
        private readonly ISalesRequestAdminService _salesRequestService;
        private readonly IWebHostEnvironment _environment;

        public SalesRequestController(ISalesRequestAdminService salesRequestService, IWebHostEnvironment environment)
        {
            _salesRequestService = salesRequestService;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            await _salesRequestService.RefreshLinkedPricingAsync();

            var requests = await _salesRequestService.GetIndexRequestsAsync();

            var vm = new SalesRequestIndexVm
            {
                TotalRequestCount = requests.Count,
                WaitingPricingCount = requests.Count(x => x.WorkflowStatus == SalesRequestWorkflowStatus.Submitted || x.WorkflowStatus == SalesRequestWorkflowStatus.PricingInProgress),
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
                    RevisionNo = x.RevisionNo,
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
            var vm = new SalesRequestCreateVm
            {
                OfferStatus = SalesOfferStatus.F,
                RequestReceivedAt = DateTime.UtcNow.Date
            };
            await PopulateRequesterInfoAsync(vm, overwriteExisting: true);
            await PopulateFormAsync(vm);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestFormLimits(MultipartBodyLengthLimit = 50_000_000)]
        public async Task<IActionResult> Create(SalesRequestCreateVm vm)
        {
            await PopulateRequesterInfoAsync(vm, overwriteExisting: true);
            vm.Items = vm.Items
                .Where(x => x.ProductGroupId != Guid.Empty || !string.IsNullOrWhiteSpace(x.SparePartDetails))
                .ToList();
            ClearItemModelStateEntries();
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
                return View(vm);
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
                RequestSource = vm.RequestSource,
                ShipmentCountry = vm.ShipmentCountry,
                InstallationCountry = vm.InstallationCountry,
                IsTransportByCustomer = vm.IsTransportByCustomer,
                SummaryNotes = vm.SummaryNotes,
                WorkflowStatus = SalesRequestWorkflowStatus.Submitted,
                OfferStatus = vm.OfferStatus,
                SalesOpenedAt = salesOpenedAt
            };

            var groups = await _salesRequestService.GetProductGroupsDictionaryAsync();
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

            await _salesRequestService.CreateAsync(entity);
            await SaveAttachmentsAsync(entity, vm.Attachments);
            return RedirectToAction(nameof(Details), new { id = entity.Id, mode = "manager" });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var entity = await _salesRequestService.GetForEditAsync(id, tracking: false);
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
                OfferStatus = entity.OfferStatus,
                ShipmentCountry = entity.ShipmentCountry,
                InstallationCountry = entity.InstallationCountry,
                IsTransportByCustomer = entity.IsTransportByCustomer,
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
            return View("Create", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestFormLimits(MultipartBodyLengthLimit = 50_000_000)]
        public async Task<IActionResult> Edit(Guid id, SalesRequestCreateVm vm)
        {
            vm.Id = id;
            vm.Items = vm.Items
                .Where(x => x.ProductGroupId != Guid.Empty || !string.IsNullOrWhiteSpace(x.SparePartDetails))
                .ToList();
            ClearItemModelStateEntries();
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

            for (var i = 0; i < vm.Items.Count; i++)
            {
                NormalizeAndValidateItem(vm.Items[i], $"Items[{i}]");
            }

            var entity = await _salesRequestService.GetForEditAsync(id, tracking: true);
            if (entity == null) return NotFound();

            if (vm.RequestReceivedAt.HasValue && vm.RequestReceivedAt.Value.Date > entity.SalesOpenedAt.Date)
            {
                ModelState.AddModelError(nameof(vm.RequestReceivedAt), "Talep alma tarihi, talep giriş tarihinden büyük olamaz.");
            }

            if (!ModelState.IsValid)
            {
                await PopulateFormAsync(vm);
                ViewBag.IsEdit = true;
                return View("Create", vm);
            }

            entity.CustomerId = vm.CustomerId;
            entity.RequestedByName = vm.RequestedByName;
            entity.RequestedByEmail = vm.RequestedByEmail;
            entity.RequestedByDepartment = vm.RequestedByDepartment;
            entity.RequestReceivedAt = vm.RequestReceivedAt?.Date;
            entity.NeededByDate = vm.NeededByDate.Date;
            entity.RequestSource = vm.RequestSource;
            entity.ShipmentCountry = vm.ShipmentCountry;
            entity.InstallationCountry = vm.InstallationCountry;
            entity.IsTransportByCustomer = vm.IsTransportByCustomer;
            entity.SummaryNotes = vm.SummaryNotes;
            entity.Title = await BuildRequestTitleAsync(vm.Items.First());
            entity.WorkflowStatus = SalesRequestWorkflowStatus.Submitted;
            entity.CustomerQuoteStatus = SalesCustomerQuoteStatus.PreparingSpecification;
            entity.OfferStatus = vm.OfferStatus;
            entity.PricingCompletedAt = null;
            entity.ApprovedAt = null;

            var existingItems = entity.Items.ToList();
            if (existingItems.Count > 0)
            {
                _salesRequestService.RemoveItems(existingItems);
            }

            var groups = await _salesRequestService.GetProductGroupsDictionaryAsync();
            var itemOrder = 1;
            foreach (var itemVm in vm.Items)
            {
                var group = groups[itemVm.ProductGroupId];
                await _salesRequestService.AddItemAsync(new SalesRequestItem
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

            await _salesRequestService.CommitAsync();
            await SaveAttachmentsAsync(entity, vm.Attachments);
            TempData["SuccessMessage"] = "Talep başarıyla güncellendi.";
            return RedirectToAction(nameof(Details), new { id = entity.Id, mode = "manager" });
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id, string mode = "sales")
        {
            await _salesRequestService.RefreshLinkedPricingAsync(id);

            var entity = await _salesRequestService.LoadRequestAsync(id);
            if (entity == null) return NotFound();

            var revisions = await _salesRequestService.GetRevisionsAsync(id);

            var vm = MapDetailVm(entity, revisions, string.Equals(mode, "manager", StringComparison.OrdinalIgnoreCase));
            vm.NewComment.SalesRequestId = id;
            await PopulateSubItemAsync(vm.NewSubItem, id);
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Revision(Guid id, int revisionNo, string mode = "manager")
        {
            await _salesRequestService.RefreshLinkedPricingAsync(id);

            var entity = await _salesRequestService.LoadRequestAsync(id);
            if (entity == null) return NotFound();

            var revisions = await _salesRequestService.GetRevisionsAsync(id);

            var detailVm = MapDetailVm(entity, revisions, string.Equals(mode, "manager", StringComparison.OrdinalIgnoreCase));
            var selectedRevision = detailVm.RevisionCosts
                .OrderByDescending(x => x.RevisionNo)
                .FirstOrDefault(x => x.RevisionNo == revisionNo);

            if (selectedRevision == null)
            {
                return RedirectToAction(nameof(Details), new { id, mode });
            }

            var vm = new SalesRequestRevisionScreenVm
            {
                SalesRequestId = entity.Id,
                RequestNo = entity.RequestNo,
                Title = entity.Title,
                IsManagerView = detailVm.IsManagerView,
                WorkflowStatus = detailVm.WorkflowStatus,
                Revisions = detailVm.RevisionCosts.OrderByDescending(x => x.RevisionNo).ToList(),
                SelectedRevision = selectedRevision
            };

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Pricing(Guid id)
        {
            await _salesRequestService.RefreshLinkedPricingAsync(id);

            var entity = await _salesRequestService.LoadRequestAsync(id);
            if (entity == null) return NotFound();

            var availableAnalyses = await GetAvailableAnalysesAsync();
            var vm = new SalesRequestPricingVm
            {
                SalesRequestId = entity.Id,
                RequestNo = entity.RequestNo,
                Title = entity.Title,
                AvailableAnalyses = availableAnalyses,
                Items = entity.Items
                    .OrderBy(x => x.DisplayOrder)
                    .Select(x => new SalesRequestPricingItemVm
                    {
                        Id = x.Id,
                        ParentSalesRequestItemId = x.ParentSalesRequestItemId,
                        ItemCode = x.ItemCode,
                        ItemTitle = x.ItemTitle,
                        ProductGroupName = x.ProductGroup.Name,
                        CapacityM3 = x.CapacityM3,
                        ConsumptionCapacity = x.ConsumptionCapacity,
                        TankOrientation = x.TankOrientation,
                        PlacementType = x.PlacementType,
                        MinimumTechnicalNotes = x.MinimumTechnicalNotes,
                        LinkedAnalysisKey = BuildAnalysisKey(x.LinkedCalculationType, x.LinkedCalculationId, x.LinkedCostAnalysisId),
                        LinkedCalculationType = x.LinkedCalculationType,
                        LinkedCalculationId = x.LinkedCalculationId,
                        LinkedCostAnalysisId = x.LinkedCostAnalysisId,
                        LinkedCalculationName = x.LinkedCalculationName,
                        LinkedCostAnalysisRevisionCode = x.LinkedCostAnalysisRevisionCode,
                        LinkedCostAnalysisTotal = x.LinkedCostAnalysisTotal,
                        EstimatedCost = x.EstimatedCost,
                        MinimumSalesPrice = x.MinimumSalesPrice,
                        ApprovedSalesPrice = x.ApprovedSalesPrice,
                        DesignDetails = x.DesignDetails,
                        SalesEngineeringNotes = x.SalesEngineeringNotes,
                        WorkflowStatus = x.WorkflowStatus
                    }).ToList()
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Pricing(SalesRequestPricingVm vm)
        {
            vm.AvailableAnalyses = await GetAvailableAnalysesAsync();

            var entity = await _salesRequestService.GetForPricingAsync(vm.SalesRequestId);
            if (entity == null) return NotFound();

            var analysisMap = vm.AvailableAnalyses.ToDictionary(x => x.Key, StringComparer.OrdinalIgnoreCase);

            foreach (var itemVm in vm.Items)
            {
                var entityItem = entity.Items.FirstOrDefault(x => x.Id == itemVm.Id);
                if (entityItem == null) continue;

                if (!string.IsNullOrWhiteSpace(itemVm.LinkedAnalysisKey) && analysisMap.TryGetValue(itemVm.LinkedAnalysisKey, out var analysis))
                {
                    entityItem.LinkedCalculationType = analysis.CalculationType;
                    entityItem.LinkedCalculationId = analysis.CalculationId;
                    entityItem.LinkedCostAnalysisId = analysis.CostAnalysisId;
                    entityItem.LinkedCalculationName = analysis.CalculationName;
                    entityItem.LinkedCostAnalysisRevisionCode = analysis.RevisionCode;
                    entityItem.LinkedCostAnalysisTotal = analysis.TotalCost;
                    entityItem.EstimatedCost = analysis.TotalCost;
                    entityItem.MinimumSalesPrice = analysis.MinimumSalesPrice ?? analysis.TotalCost;
                    entityItem.ApprovedSalesPrice = analysis.RecommendedSalesPrice ?? analysis.MinimumSalesPrice ?? analysis.TotalCost;
                    entityItem.SharedSalesPrice = entityItem.ApprovedSalesPrice;
                    entityItem.SoldSalesPrice = entityItem.ApprovedSalesPrice;

                    itemVm.LinkedCalculationType = analysis.CalculationType;
                    itemVm.LinkedCalculationId = analysis.CalculationId;
                    itemVm.LinkedCostAnalysisId = analysis.CostAnalysisId;
                    itemVm.LinkedCalculationName = analysis.CalculationName;
                    itemVm.LinkedCostAnalysisRevisionCode = analysis.RevisionCode;
                    itemVm.LinkedCostAnalysisTotal = analysis.TotalCost;
                    itemVm.EstimatedCost = entityItem.EstimatedCost;
                    itemVm.MinimumSalesPrice = entityItem.MinimumSalesPrice;
                    itemVm.ApprovedSalesPrice = entityItem.ApprovedSalesPrice;
                }
                else
                {
                    entityItem.LinkedCalculationType = null;
                    entityItem.LinkedCalculationId = null;
                    entityItem.LinkedCostAnalysisId = null;
                    entityItem.LinkedCalculationName = null;
                    entityItem.LinkedCostAnalysisRevisionCode = null;
                    entityItem.LinkedCostAnalysisTotal = null;
                    entityItem.EstimatedCost = itemVm.EstimatedCost;
                    entityItem.MinimumSalesPrice = itemVm.MinimumSalesPrice;
                    entityItem.ApprovedSalesPrice = itemVm.ApprovedSalesPrice;
                    entityItem.SharedSalesPrice = itemVm.ApprovedSalesPrice;
                    entityItem.SoldSalesPrice = itemVm.ApprovedSalesPrice;
                }

                entityItem.DesignDetails = itemVm.DesignDetails;
                entityItem.SalesEngineeringNotes = itemVm.SalesEngineeringNotes;
                entityItem.WorkflowStatus = itemVm.WorkflowStatus;
            }

            entity.WorkflowStatus = entity.Items.All(x => x.WorkflowStatus == SalesRequestWorkflowStatus.Approved)
                ? SalesRequestWorkflowStatus.Approved
                : SalesRequestWorkflowStatus.PricingInProgress;
            entity.PricingCompletedAt = DateTime.UtcNow;
            entity.ApprovedAt = entity.WorkflowStatus == SalesRequestWorkflowStatus.Approved ? DateTime.UtcNow : null;

            await _salesRequestService.CommitAsync();
            TempData["SuccessMessage"] = "Talep kalemleri güncellendi. Satış yöneticisi onayı sonrası satış sorumlusu ekranına gönderildi.";

            if (entity.WorkflowStatus == SalesRequestWorkflowStatus.Approved)
            {
                return RedirectToAction("Details", "SalesRequest", new { area = "Sales", id = vm.SalesRequestId });
            }

            return RedirectToAction(nameof(Details), new { id = vm.SalesRequestId, mode = "manager" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSubItem([Bind(Prefix = "NewSubItem")] SalesRequestAddSubItemVm vm)
        {
            if (vm.ProductGroupId == Guid.Empty)
            {
                ModelState.AddModelError(nameof(vm.ProductGroupId), "Akışkan grubu seçimi zorunludur.");
            }

            NormalizeAndValidateItem(vm, nameof(vm));
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Details), new { id = vm.SalesRequestId, mode = "manager" });
            }

            var request = await _salesRequestService.GetWithItemsAsync(vm.SalesRequestId);
            if (request == null) return NotFound();

            var group = await _salesRequestService.GetProductGroupAsync(vm.ProductGroupId, tracking: true) ?? throw new InvalidOperationException("Ürün grubu bulunamadı.");
            var nextOrder = request.Items.Count + 1;
            request.Items.Add(new SalesRequestItem
            {
                SalesRequestId = request.Id,
                ParentSalesRequestItemId = vm.ParentSalesRequestItemId,
                ProductGroupId = vm.ProductGroupId,
                CapacityM3 = vm.CapacityM3,
                ConsumptionCapacity = vm.ConsumptionCapacity,
                RequestCategory = vm.RequestCategory,
                ProductCode = vm.ProductCode,
                DesignStandardCode = vm.DesignStandardCode,
                DesignPressureBar = vm.DesignPressureBar,
                DesignTemperatureMin = vm.DesignTemperatureMin,
                DesignTemperatureMax = vm.DesignTemperatureMax,
                TankType = vm.TankType,
                StorageOption = vm.StorageOption,
                TransportOption = vm.TransportOption,
                StdOpsSelection = vm.StdOpsSelection,
                SpcTechnicalDetails = vm.SpcTechnicalDetails,
                AmbientTemperatureMin = vm.AmbientTemperatureMin,
                AmbientTemperatureMax = vm.AmbientTemperatureMax,
                FacilityType = vm.FacilityType,
                FacilityInletPressureBar = vm.FacilityInletPressureBar,
                FacilityOutletPressureBar = vm.FacilityOutletPressureBar,
                FacilityInletTemperature = vm.FacilityInletTemperature,
                FacilityOutletTemperature = vm.FacilityOutletTemperature,
                FacilityCapacityNm3h = vm.FacilityCapacityNm3h,
                HasPump = vm.HasPump,
                PumpDetails = vm.PumpDetails,
                HasElectricHeater = vm.HasElectricHeater,
                ElectricHeaterDetails = vm.ElectricHeaterDetails,
                HasTankConsumptionCapacity = vm.HasTankConsumptionCapacity,
                AdditionalQuestionsJson = vm.AdditionalQuestionsJson,
                TankOrientation = vm.TankOrientation,
                PlacementType = vm.PlacementType,
                MinimumTechnicalNotes = vm.MinimumTechnicalNotes,
                ItemCode = GenerateItemCode(group.Code, vm, nextOrder),
                ItemTitle = BuildItemTitle(group.ShortCode, vm),
                WorkflowStatus = SalesRequestWorkflowStatus.Submitted,
                DisplayOrder = nextOrder
            });

            request.WorkflowStatus = SalesRequestWorkflowStatus.Submitted;
            await _salesRequestService.CommitAsync();
            return RedirectToAction(nameof(Details), new { id = vm.SalesRequestId, mode = "manager" });
        }

        private async Task PopulateFormAsync(SalesRequestCreateVm vm)
        {
            vm.Customers = (await _salesRequestService.GetActiveCustomersAsync())
                .Select(x => new SelectListItem(x.CompanyName, x.Id.ToString()))
                .ToList();

            vm.ProductGroups = (await _salesRequestService.GetActiveProductGroupsAsync())
                .Select(x => new SelectListItem($"{x.Code} - {x.Name}", x.Id.ToString()))
                .ToList();
        }

        private async Task PopulateRequesterInfoAsync(SalesRequestCreateVm vm, bool overwriteExisting)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrWhiteSpace(userId))
            {
                return;
            }

            var profile = await _salesRequestService.GetEmployeeProfileAsync(userId);

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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(SalesRequestCommentCreateVm vm)
        {
            if (string.IsNullOrWhiteSpace(vm.CommentText))
            {
                TempData["ErrorMessage"] = "Yorum alanı zorunludur.";
                return RedirectToAction(nameof(Details), new { id = vm.SalesRequestId, mode = "manager" });
            }

            var request = await _salesRequestService.GetByIdAsync(vm.SalesRequestId);
            if (request == null)
            {
                return NotFound();
            }

            await _salesRequestService.AddCommentAsync(new SalesRequestComment
            {
                SalesRequestId = request.Id,
                CommentText = vm.CommentText.Trim(),
                CommentedBy = User.Identity?.Name ?? "System"
            });
            TempData["SuccessMessage"] = "Yorum kaydedildi.";
            return RedirectToAction(nameof(Details), new { id = vm.SalesRequestId, mode = "manager" });
        }

        private async Task PopulateSubItemAsync(SalesRequestAddSubItemVm vm, Guid requestId)
        {
            vm.SalesRequestId = requestId;
            vm.ProductGroups = (await _salesRequestService.GetActiveProductGroupsAsync())
                .Select(x => new SelectListItem($"{x.Code} - {x.Name}", x.Id.ToString()))
                .ToList();
        }


        private SalesRequestDetailVm MapDetailVm(SalesRequest entity, List<SalesRequestRevision> revisions, bool isManagerView)
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
                        SalesEngineeringNotes = x.SalesEngineeringNotes,
                        DesignDetails = x.DesignDetails,
                        LinkedCalculationType = x.LinkedCalculationType,
                        LinkedCalculationId = x.LinkedCalculationId,
                        LinkedCostAnalysisId = x.LinkedCostAnalysisId,
                        LinkedCalculationName = x.LinkedCalculationName,
                        LinkedCostAnalysisRevisionCode = x.LinkedCostAnalysisRevisionCode,
                        LinkedCostAnalysisTotal = isManagerView ? x.LinkedCostAnalysisTotal : null,
                        EstimatedCost = isManagerView ? x.EstimatedCost : null,
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
                CustomerSector = entity.Customer.Sector,
                CustomerMainDealerCountry = entity.Customer.MainDealerCountry,
                CustomerRegion = entity.Customer.Region,
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
                SummaryNotes = entity.SummaryNotes,
                WorkflowStatus = entity.WorkflowStatus,
                CustomerQuoteStatus = entity.CustomerQuoteStatus,
                OfferStatus = entity.OfferStatus,
                RevisionNo = entity.RevisionNo,
                IsManagerView = isManagerView,
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
                Items = roots,
                Attachments = entity.Attachments.Select(x => new SalesRequestAttachmentVm
                {
                    OriginalFileName = x.OriginalFileName,
                    RelativePath = x.RelativePath,
                    FileSize = x.FileSize
                }).ToList(),
                NewSubItem = new SalesRequestAddSubItemVm { SalesRequestId = entity.Id }
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

        private async Task<List<SalesRequestPricingAnalysisOptionVm>> GetAvailableAnalysesAsync()
        {
            var analyses = await _salesRequestService.GetAvailableAnalysesAsync();

            return analyses
                .OrderByDescending(x => x.RevisionCode)
                .ThenBy(x => x.CalculationName)
                .Select(x =>
                {
                    var minimumSalesPrice = x.MinimumSalesPrice;
                    var recommendedSalesPrice = x.RecommendedSalesPrice;
                    return new SalesRequestPricingAnalysisOptionVm
                    {
                        Key = BuildAnalysisKey(x.CalculationType, x.CalculationId, x.CostAnalysisId) ?? string.Empty,
                        Label = recommendedSalesPrice.HasValue
                            ? $"{x.CalculationType} · {x.CalculationName} · {x.RevisionCode} · Min {minimumSalesPrice.GetValueOrDefault(x.TotalCost):N2} ₺ / Tavsiye {recommendedSalesPrice.Value:N2} ₺"
                            : $"{x.CalculationType} · {x.CalculationName} · {x.RevisionCode} · Min {minimumSalesPrice.GetValueOrDefault(x.TotalCost):N2} ₺ / Tavsiye hesaplanmadı",
                        CalculationType = x.CalculationType,
                        CalculationId = x.CalculationId,
                        CostAnalysisId = x.CostAnalysisId,
                        CalculationName = x.CalculationName,
                        RevisionCode = x.RevisionCode,
                        TotalCost = x.TotalCost,
                        MinimumSalesPrice = minimumSalesPrice,
                        RecommendedSalesPrice = recommendedSalesPrice
                    };
                })
                .ToList();
        }

        private async Task<string> GenerateRequestNoAsync()
        {
            return await _salesRequestService.GenerateRequestNoAsync();
        }

        private async Task<string> BuildRequestTitleAsync(SalesRequestItemInputVm item)
        {
            var group = await _salesRequestService.GetProductGroupAsync(item.ProductGroupId) ?? throw new InvalidOperationException("Ürün grubu bulunamadı.");
            return BuildItemTitle(group.ShortCode, item);
        }

        private static string BuildItemTitle(string shortCode, SalesRequestItemInputVm item)
        {
            if (item.RequestCategory != SalesRequestCategory.Tank)
            {
                var fallbackPlacement = item.PlacementType == PlacementType.Aboveground ? "YER ÜSTÜ" : "YER ALTI";
                return $"{item.CapacityM3:0.##}m3-{shortCode}-{fallbackPlacement}";
            }

            var fluid = shortCode.ToUpperInvariant();
            var tankType = item.TankType == RequestTankType.Transport ? "Transport" : "Depolama";
            var placement = item.PlacementType == PlacementType.Aboveground ? "Yer Üstü" : "Yer Altı";
            var pressure = item.DesignPressureBar.HasValue ? $"{item.DesignPressureBar:0.##} Bar" : "-";
            var stdOps = item.StdOpsSelection?.ToString()?.ToUpperInvariant() ?? "-";

            return $"{item.CapacityM3:0.##}m3-{fluid}-{tankType}-{placement} - {pressure} - {stdOps}";
        }

        private static string GenerateItemCode(string groupCode, SalesRequestItemInputVm item, int order)
        {
            var orientation = item.TankOrientation == RequestTankOrientation.Vertical ? "D" : "Y";
            var placement = item.PlacementType == PlacementType.Aboveground ? "A" : "U";
            var capacity = item.CapacityM3.ToString("0.##").Replace(",", string.Empty).Replace(".", string.Empty);
            return $"CVS-{groupCode}{orientation}{placement}-{capacity}-{order:000}";
        }

        private static string? BuildAnalysisKey(SalesRequestCalculationType? type, Guid? calculationId, Guid? costAnalysisId)
        {
            if (!type.HasValue || !calculationId.HasValue || !costAnalysisId.HasValue)
            {
                return null;
            }

            return $"{(int)type.Value}|{calculationId.Value:D}|{costAnalysisId.Value:D}";
        }

        private async Task SaveAttachmentsAsync(SalesRequest request, IEnumerable<IFormFile> files)
        {
            var validFiles = files?.Where(x => x.Length > 0).ToList() ?? new List<IFormFile>();
            if (!validFiles.Any()) return;

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

            await _salesRequestService.AddAttachmentsAsync(request, attachments);
        }


        private void ClearItemModelStateEntries()
        {
            foreach (var key in ModelState.Keys.Where(x => x.StartsWith("Items[", StringComparison.OrdinalIgnoreCase)).ToList())
            {
                ModelState.Remove(key);
            }
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

                if (!item.HasTankConsumptionCapacity)
                {
                    item.ConsumptionCapacity = null;
                }
                else if (!item.ConsumptionCapacity.HasValue || item.ConsumptionCapacity <= 0)
                {
                    ModelState.AddModelError($"{keyPrefix}.ConsumptionCapacity", "Tüketim kapasitesi aktifse pozitif bir değer girmelisiniz.");
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
                item.ConsumptionCapacity = null;
                item.HasTankConsumptionCapacity = false;
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
                item.ConsumptionCapacity = null;
                item.HasTankConsumptionCapacity = false;
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
                item.ConsumptionCapacity = null;
                item.HasTankConsumptionCapacity = false;
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
    }
}
