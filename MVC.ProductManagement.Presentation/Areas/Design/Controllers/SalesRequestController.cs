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

            var linkedItems = request.Items
                .Where(x => x.LinkedCalculationId.HasValue && x.LinkedCalculationType.HasValue)
                .OrderBy(x => x.DisplayOrder)
                .ToList();

            foreach (var item in linkedItems)
            {
                if (item.LinkedCalculationType == SalesRequestCalculationType.EN13458)
                {
                    var calc = await _context.EN13458Calculations
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == item.LinkedCalculationId!.Value && x.Status != Status.Deleted);
                    if (calc != null)
                    {
                        vm.CalculationDetails.Add(new DesignCalculationDetailVm
                        {
                            ItemCode = item.ItemCode,
                            ItemTitle = item.ItemTitle,
                            CalculationName = calc.Name,
                            CalculationType = SalesRequestCalculationType.EN13458,
                            Fields = new List<DesignCalculationFieldVm>
                            {
                                new() { Label = "Design Pressure", Value = $"{calc.DesignPressure:N2} bar" },
                                new() { Label = "Test Pressure", Value = $"{calc.TestPressure:N2} bar" },
                                new() { Label = "Static Pressure", Value = $"{calc.StaticPressure:N2} bar" },
                                new() { Label = "İç Çap", Value = $"{calc.OuterDiameter:N2} mm" },
                                new() { Label = "Dış Çap", Value = $"{calc.OuterTankDiameter:N2} mm" },
                                new() { Label = "Silindirik Boy", Value = $"{calc.ShellLength:N2} mm" },
                                new() { Label = "Yuvarlanmış İç Gövde Et", Value = $"{calc.RoundedInnerShellThickness:N2} mm" },
                                new() { Label = "Yuvarlanmış İç Bombe Et", Value = $"{calc.RoundedInnerHeadThickness:N2} mm" },
                                new() { Label = "Yuvarlanmış Dış Gövde Et", Value = $"{calc.RoundedOuterShellThickness:N2} mm" },
                                new() { Label = "Yuvarlanmış Dış Bombe Et", Value = $"{calc.RoundedOuterHeadThickness:N2} mm" }
                            }
                        });
                    }
                }
                else if (item.LinkedCalculationType == SalesRequestCalculationType.AD2000)
                {
                    var calc = await _context.AD2000Calculations
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == item.LinkedCalculationId!.Value && x.Status != Status.Deleted);
                    if (calc != null)
                    {
                        vm.CalculationDetails.Add(new DesignCalculationDetailVm
                        {
                            ItemCode = item.ItemCode,
                            ItemTitle = item.ItemTitle,
                            CalculationName = calc.Name,
                            CalculationType = SalesRequestCalculationType.AD2000,
                            Fields = new List<DesignCalculationFieldVm>
                            {
                                new() { Label = "Design Pressure", Value = $"{calc.DesignPressure:N2} bar" },
                                new() { Label = "Test Pressure", Value = $"{calc.TestPressure:N2} bar" },
                                new() { Label = "Static Pressure", Value = $"{calc.StaticPressure:N2} bar" },
                                new() { Label = "Çap", Value = $"{calc.Diameter:N2} mm" },
                                new() { Label = "Silindirik Boy", Value = $"{calc.ShellLength:N2} mm" },
                                new() { Label = "Yuvarlanmış Gövde Et", Value = $"{calc.RoundedShellThickness:N2} mm" },
                                new() { Label = "Yuvarlanmış Bombe Et", Value = $"{calc.RoundedHeadThickness:N2} mm" },
                                new() { Label = "Tank Oryantasyonu", Value = calc.TankOrientation.ToString() }
                            }
                        });
                    }
                }
            }

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
