using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.SalesRequests;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.SalesRequestVMs;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var requests = await _context.SalesRequests
                .AsNoTracking()
                .Where(x => x.Status != Status.Deleted && x.RequestSource == SalesRequestSource.Sales)
                .ToListAsync();

            var vm = new SalesDashboardVm
            {
                TotalRequestCount = requests.Count,
                OpenRequestCount = requests.Count(IsOpenRequest),
                ClosedRequestCount = requests.Count(x => x.WorkflowStatus == SalesRequestWorkflowStatus.Rejected),
                QuoteSharedCount = requests.Count(x => x.CustomerQuoteStatus == SalesCustomerQuoteStatus.SharedWithCustomer),
                ApprovedCount = requests.Count(x => x.WorkflowStatus == SalesRequestWorkflowStatus.Approved),
                WaitingPricingCount = requests.Count(x => x.WorkflowStatus == SalesRequestWorkflowStatus.Submitted || x.WorkflowStatus == SalesRequestWorkflowStatus.PricingInProgress),
                SalespersonStats = requests
                    .GroupBy(x => string.IsNullOrWhiteSpace(x.RequestedByName) ? "Belirtilmemiş" : x.RequestedByName)
                    .Select(g => new SalespersonRequestStatVm
                    {
                        SalespersonName = g.Key,
                        TotalRequestCount = g.Count(),
                        OpenRequestCount = g.Count(IsOpenRequest),
                        ClosedRequestCount = g.Count(x => x.WorkflowStatus == SalesRequestWorkflowStatus.Rejected),
                        QuoteSharedCount = g.Count(x => x.CustomerQuoteStatus == SalesCustomerQuoteStatus.SharedWithCustomer),
                        ApprovedCount = g.Count(x => x.WorkflowStatus == SalesRequestWorkflowStatus.Approved)
                    })
                    .OrderByDescending(x => x.TotalRequestCount)
                    .ThenBy(x => x.SalespersonName)
                    .ToList()
            };

            return View(vm);
        }

        private static bool IsOpenRequest(SalesRequest request)
        {
            return request.WorkflowStatus != SalesRequestWorkflowStatus.Rejected
                   && request.CustomerQuoteStatus != SalesCustomerQuoteStatus.SharedWithCustomer;
        }
    }
}
