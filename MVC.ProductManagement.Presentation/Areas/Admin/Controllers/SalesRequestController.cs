using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.SalesRequests;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.SalesRequestVMs;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    public class SalesRequestController : AdminBaseController
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public SalesRequestController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            var requests = await _context.SalesRequests
                .AsNoTracking()
                .Include(x => x.Customer)
                .Include(x => x.Items)
                .Include(x => x.Attachments)
                .Where(x => x.Status != Status.Deleted)
                .OrderByDescending(x => x.CreatedDate)
                .ToListAsync();

            var vm = new SalesRequestIndexVm
            {
                TotalRequestCount = requests.Count,
                WaitingPricingCount = requests.Count(x => x.WorkflowStatus == SalesRequestWorkflowStatus.Submitted || x.WorkflowStatus == SalesRequestWorkflowStatus.PricingInProgress),
                ApprovedCount = requests.Count(x => x.WorkflowStatus == SalesRequestWorkflowStatus.Approved),
                AttachmentCount = requests.Sum(x => x.Attachments.Count),
                Requests = requests.Select(x => new SalesRequestListVm
                {
                    Id = x.Id,
                    RequestNo = x.RequestNo,
                    Title = x.Title,
                    CustomerName = x.Customer.CompanyName,
                    RequestedByName = x.RequestedByName,
                    SalesOpenedAt = x.SalesOpenedAt,
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
            var vm = new SalesRequestCreateVm();
            await PopulateFormAsync(vm);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestFormLimits(MultipartBodyLengthLimit = 50_000_000)]
        public async Task<IActionResult> Create(SalesRequestCreateVm vm)
        {
            vm.Items = vm.Items.Where(x => x.ProductGroupId != Guid.Empty && x.CapacityM3 > 0).ToList();
            if (!vm.Items.Any())
            {
                ModelState.AddModelError(string.Empty, "En az bir talep satırı girmelisiniz.");
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
            return RedirectToAction(nameof(Details), new { id = entity.Id, mode = "sales" });
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id, string mode = "sales")
        {
            var entity = await LoadRequestAsync(id);
            if (entity == null) return NotFound();

            var vm = MapDetailVm(entity, string.Equals(mode, "manager", StringComparison.OrdinalIgnoreCase));
            await PopulateSubItemAsync(vm.NewSubItem, id);
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Pricing(Guid id)
        {
            var entity = await LoadRequestAsync(id);
            if (entity == null) return NotFound();

            var vm = new SalesRequestPricingVm
            {
                SalesRequestId = entity.Id,
                RequestNo = entity.RequestNo,
                Title = entity.Title,
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
                        EstimatedCost = x.EstimatedCost,
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
            var entity = await _context.SalesRequests
                .Include(x => x.Items)
                .FirstOrDefaultAsync(x => x.Id == vm.SalesRequestId && x.Status != Status.Deleted);
            if (entity == null) return NotFound();

            foreach (var itemVm in vm.Items)
            {
                var entityItem = entity.Items.FirstOrDefault(x => x.Id == itemVm.Id);
                if (entityItem == null) continue;

                entityItem.EstimatedCost = itemVm.EstimatedCost;
                entityItem.ApprovedSalesPrice = itemVm.ApprovedSalesPrice;
                entityItem.DesignDetails = itemVm.DesignDetails;
                entityItem.SalesEngineeringNotes = itemVm.SalesEngineeringNotes;
                entityItem.WorkflowStatus = itemVm.WorkflowStatus;
            }

            entity.WorkflowStatus = entity.Items.All(x => x.WorkflowStatus == SalesRequestWorkflowStatus.Approved)
                ? SalesRequestWorkflowStatus.Approved
                : SalesRequestWorkflowStatus.PricingInProgress;
            entity.PricingCompletedAt = DateTime.UtcNow;
            entity.ApprovedAt = entity.WorkflowStatus == SalesRequestWorkflowStatus.Approved ? DateTime.UtcNow : null;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = vm.SalesRequestId, mode = "manager" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSubItem(SalesRequestAddSubItemVm vm)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Details), new { id = vm.SalesRequestId, mode = "manager" });
            }

            var request = await _context.SalesRequests.Include(x => x.Items).FirstOrDefaultAsync(x => x.Id == vm.SalesRequestId && x.Status != Status.Deleted);
            if (request == null) return NotFound();

            var group = await _context.SalesRequestProductGroups.FirstAsync(x => x.Id == vm.ProductGroupId);
            var nextOrder = request.Items.Count + 1;
            request.Items.Add(new SalesRequestItem
            {
                SalesRequestId = request.Id,
                ParentSalesRequestItemId = vm.ParentSalesRequestItemId,
                ProductGroupId = vm.ProductGroupId,
                CapacityM3 = vm.CapacityM3,
                ConsumptionCapacity = vm.ConsumptionCapacity,
                TankOrientation = vm.TankOrientation,
                PlacementType = vm.PlacementType,
                MinimumTechnicalNotes = vm.MinimumTechnicalNotes,
                ItemCode = GenerateItemCode(group.Code, vm, nextOrder),
                ItemTitle = BuildItemTitle(group.ShortCode, vm),
                WorkflowStatus = SalesRequestWorkflowStatus.Submitted,
                DisplayOrder = nextOrder
            });

            request.WorkflowStatus = SalesRequestWorkflowStatus.Submitted;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = vm.SalesRequestId, mode = "manager" });
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

        private async Task PopulateSubItemAsync(SalesRequestAddSubItemVm vm, Guid requestId)
        {
            vm.SalesRequestId = requestId;
            vm.ProductGroups = await _context.SalesRequestProductGroups
                .AsNoTracking()
                .Where(x => x.Status != Status.Deleted && x.IsActive)
                .OrderBy(x => x.DisplayOrder)
                .Select(x => new SelectListItem($"{x.Code} - {x.Name}", x.Id.ToString()))
                .ToListAsync();
        }

        private async Task<SalesRequest?> LoadRequestAsync(Guid id)
        {
            return await _context.SalesRequests
                .AsNoTracking()
                .Include(x => x.Customer)
                .Include(x => x.Attachments)
                .Include(x => x.Items)
                    .ThenInclude(x => x.ProductGroup)
                .Where(x => x.Id == id && x.Status != Status.Deleted)
                .FirstOrDefaultAsync();
        }

        private SalesRequestDetailVm MapDetailVm(SalesRequest entity, bool isManagerView)
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
                        TankOrientation = x.TankOrientation,
                        PlacementType = x.PlacementType,
                        MinimumTechnicalNotes = x.MinimumTechnicalNotes,
                        SalesEngineeringNotes = x.SalesEngineeringNotes,
                        DesignDetails = x.DesignDetails,
                        EstimatedCost = isManagerView ? x.EstimatedCost : null,
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
                RequestNo = entity.RequestNo,
                Title = entity.Title,
                CustomerName = entity.Customer.CompanyName,
                CustomerContact = entity.Customer.ContactName,
                CustomerEmail = entity.Customer.Email,
                CustomerPhone = entity.Customer.Phone,
                RequestedByName = entity.RequestedByName,
                RequestedByEmail = entity.RequestedByEmail,
                RequestedByDepartment = entity.RequestedByDepartment,
                SummaryNotes = entity.SummaryNotes,
                WorkflowStatus = entity.WorkflowStatus,
                IsManagerView = isManagerView,
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

            var root = Path.Combine(_environment.WebRootPath, "uploads", "sales-requests", request.Id.ToString());
            Directory.CreateDirectory(root);

            foreach (var file in validFiles)
            {
                var storedFileName = $"{Guid.NewGuid():N}{Path.GetExtension(file.FileName)}";
                var fullPath = Path.Combine(root, storedFileName);
                await using var stream = System.IO.File.Create(fullPath);
                await file.CopyToAsync(stream);
                request.Attachments.Add(new SalesRequestAttachment
                {
                    SalesRequestId = request.Id,
                    OriginalFileName = Path.GetFileName(file.FileName),
                    StoredFileName = storedFileName,
                    RelativePath = $"/uploads/sales-requests/{request.Id}/{storedFileName}",
                    ContentType = file.ContentType,
                    FileSize = file.Length
                });
            }

            await _context.SaveChangesAsync();
        }
    }
}
