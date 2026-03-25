using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.SalesRequests;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.SalesRequestVMs;
using System.Security.Claims;

namespace MVC.ProductManagement.Presentation.Areas.Sales.Controllers
{
    public class HomeController : SalesBaseController
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if (!await HasSalesPermissionAsync(x => x.CanAccessSalesArea))
            {
                return Forbid();
            }

            var requests = await _context.SalesRequests
                .AsNoTracking()
                .Where(x => x.Status != Status.Deleted && x.RequestSource == SalesRequestSource.Sales)
                .ToListAsync();

            var currentUserName = User.Identity?.Name;
            var currentUserEmail = User.FindFirstValue(ClaimTypes.Email);
            var myRequests = requests.Where(x =>
                    (!string.IsNullOrWhiteSpace(currentUserEmail) && x.RequestedByEmail == currentUserEmail) ||
                    (!string.IsNullOrWhiteSpace(currentUserName) && x.RequestedByName == currentUserName))
                .ToList();

            var vm = BuildDashboardVm(myRequests);
            return View(vm);
        }

        private static SalesDashboardVm BuildDashboardVm(List<SalesRequest> requests)
        {
            return new SalesDashboardVm
            {
                TotalRequestCount = requests.Count,
                OpenRequestCount = requests.Count(IsOpenRequest),
                ClosedRequestCount = requests.Count(x => x.WorkflowStatus == SalesRequestWorkflowStatus.Rejected),
                QuoteSharedCount = requests.Count(x => x.CustomerQuoteStatus == SalesCustomerQuoteStatus.SharedWithCustomer),
                ApprovedCount = requests.Count(x => x.WorkflowStatus == SalesRequestWorkflowStatus.Approved),
                WaitingPricingCount = requests.Count(x => x.WorkflowStatus == SalesRequestWorkflowStatus.Submitted || x.WorkflowStatus == SalesRequestWorkflowStatus.PricingInProgress),
                SalespersonStats = new List<SalespersonRequestStatVm>()
            };
        }

        private static bool IsOpenRequest(SalesRequest request)
        {
            return request.WorkflowStatus != SalesRequestWorkflowStatus.Rejected
                   && request.CustomerQuoteStatus != SalesCustomerQuoteStatus.SharedWithCustomer;
        }
    }
}
