using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Presentation.Areas.Design.Models;

namespace MVC.ProductManagement.Presentation.Areas.Design.Controllers
{
    public class SalesRequestController : DesignBaseController
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
            var requests = await _context.SalesRequests
                .AsNoTracking()
                .Include(x => x.Customer)
                .Include(x => x.Items)
                .Where(x => x.Status != Status.Deleted
                            && x.RequestSource == SalesRequestSource.Sales
                            && x.OfferStatus == SalesOfferStatus.S)
                .OrderByDescending(x => x.ModifiedDate ?? x.CreatedDate)
                .Select(x => new DesignSalesRequestListVm
                {
                    Id = x.Id,
                    RequestNo = x.RequestNo,
                    Title = x.Title,
                    CustomerName = x.Customer.CompanyName,
                    RequestedByName = x.RequestedByName,
                    SalesOpenedAt = x.SalesOpenedAt,
                    NeededByDate = x.NeededByDate,
                    DeliveryLeadTime = x.DeliveryLeadTime,
                    ItemCount = x.Items.Count
                })
                .ToListAsync();

            return View(new DesignSalesRequestIndexVm
            {
                TotalCount = requests.Count,
                Requests = requests
            });
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var request = await _context.SalesRequests
                .AsNoTracking()
                .Include(x => x.Customer)
                .Include(x => x.Items)
                    .ThenInclude(i => i.ProductGroup)
                .Include(x => x.Documents)
                .FirstOrDefaultAsync(x => x.Id == id
                                          && x.Status != Status.Deleted
                                          && x.RequestSource == SalesRequestSource.Sales
                                          && x.OfferStatus == SalesOfferStatus.S);
            if (request == null)
            {
                return NotFound();
            }

            var vm = new DesignSalesRequestDetailVm
            {
                Id = request.Id,
                RequestNo = request.RequestNo,
                Title = request.Title,
                CustomerName = request.Customer.CompanyName,
                RequestedByName = request.RequestedByName,
                SalesOpenedAt = request.SalesOpenedAt,
                RequestReceivedAt = request.RequestReceivedAt,
                NeededByDate = request.NeededByDate,
                DeliveryLeadTime = request.DeliveryLeadTime,
                OfferStatus = request.OfferStatus,
                TechnicalItems = request.Items
                    .OrderBy(x => x.DisplayOrder)
                    .Select(x => new DesignSalesRequestItemVm
                    {
                        Id = x.Id,
                        ItemCode = x.ItemCode,
                        ItemTitle = x.ItemTitle,
                        ProductGroupName = x.ProductGroup.Name,
                        CapacityM3 = x.CapacityM3,
                        RequestCategory = x.RequestCategory,
                        DesignStandardCode = x.DesignStandardCode,
                        DesignPressureBar = x.DesignPressureBar,
                        DesignTemperatureMin = x.DesignTemperatureMin,
                        DesignTemperatureMax = x.DesignTemperatureMax,
                        TankType = x.TankType,
                        StorageOption = x.StorageOption,
                        TransportOption = x.TransportOption,
                        StdOpsSelection = x.StdOpsSelection,
                        TankOrientation = x.TankOrientation,
                        PlacementType = x.PlacementType,
                        SpcTechnicalDetails = x.SpcTechnicalDetails,
                        MinimumTechnicalNotes = x.MinimumTechnicalNotes,
                        DesignDetails = x.DesignDetails,
                        WorkflowStatus = x.WorkflowStatus
                    })
                    .ToList(),
                CostInputItems = request.Items
                    .Where(x => x.LinkedCostAnalysisId.HasValue
                                || !string.IsNullOrWhiteSpace(x.LinkedCostAnalysisRevisionCode)
                                || x.LinkedCalculationId.HasValue)
                    .OrderBy(x => x.DisplayOrder)
                    .Select(x => new DesignSalesCostInputItemVm
                    {
                        ItemCode = x.ItemCode,
                        ItemTitle = x.ItemTitle,
                        LinkedCalculationName = x.LinkedCalculationName,
                        LinkedCostAnalysisRevisionCode = x.LinkedCostAnalysisRevisionCode,
                        LinkedCalculationType = x.LinkedCalculationType
                    })
                    .ToList(),
                TechnicalDocuments = request.Documents
                    .Where(x => x.DocumentType == SalesDocumentType.TechnicalSpecification
                                || x.DocumentType == SalesDocumentType.Datasheet
                                || x.DocumentType == SalesDocumentType.GAD
                                || x.DocumentType == SalesDocumentType.PID)
                    .OrderByDescending(x => x.UploadedAt)
                    .Select(x => new DesignSalesDocumentVm
                    {
                        Id = x.Id,
                        DocumentType = x.DocumentType,
                        RevisionCode = x.RevisionCode,
                        OriginalFileName = x.OriginalFileName,
                        UploadedAt = x.UploadedAt,
                        IsCurrent = x.IsCurrent
                    })
                    .ToList()
            };

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> DownloadDocument(Guid requestId, Guid documentId)
        {
            var request = await _context.SalesRequests
                .AsNoTracking()
                .Include(x => x.Documents)
                .FirstOrDefaultAsync(x => x.Id == requestId
                                          && x.Status != Status.Deleted
                                          && x.RequestSource == SalesRequestSource.Sales
                                          && x.OfferStatus == SalesOfferStatus.S);
            if (request == null)
            {
                return NotFound();
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
    }
}
