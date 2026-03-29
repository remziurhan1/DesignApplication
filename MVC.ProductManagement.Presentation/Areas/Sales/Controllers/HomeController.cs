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

            var canAccessManagerPanel = await CanAccessSalesManagerPanelAsync();
            if (canAccessManagerPanel)
            {
                return RedirectToAction("ManagerPanel", "SalesRequest");
            }

            var allRequests = await _context.SalesRequests
                .AsNoTracking()
                .Include(x => x.Customer)
                .Where(x => x.Status != Status.Deleted && x.RequestSource == SalesRequestSource.Sales)
                .ToListAsync();

            var profile = await GetCurrentSalesProfileAsync();
            var region = profile?.Location;

            var currentUserName = User.Identity?.Name;
            var currentUserEmail = User.FindFirstValue(ClaimTypes.Email);
            var myRequests = allRequests.Where(x =>
                    (!string.IsNullOrWhiteSpace(profile?.Email) && string.Equals(x.RequestedByEmail, profile.Email, StringComparison.OrdinalIgnoreCase)) ||
                    (!string.IsNullOrWhiteSpace(currentUserEmail) && string.Equals(x.RequestedByEmail, currentUserEmail, StringComparison.OrdinalIgnoreCase)) ||
                    (!string.IsNullOrWhiteSpace(profile?.FullName) && string.Equals(x.RequestedByName, profile.FullName, StringComparison.OrdinalIgnoreCase)) ||
                    (!string.IsNullOrWhiteSpace(currentUserName) && string.Equals(x.RequestedByName, currentUserName, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            var canViewTeamDashboard = canAccessManagerPanel;
            var managerRequests = allRequests;
            if (!User.IsInRole("Admin") && !string.IsNullOrWhiteSpace(region))
            {
                managerRequests = allRequests.Where(x => x.Customer.Region == region).ToList();
            }

            var vm = BuildDashboardVm(
                canViewTeamDashboard ? managerRequests : myRequests,
                canViewTeamDashboard,
                canAccessManagerPanel,
                region,
                myRequests,
                profile?.FullName ?? currentUserName ?? "Satış Sorumlusu",
                profile?.Email ?? currentUserEmail ?? "-");
            return View(vm);
        }

        private static SalesDashboardVm BuildDashboardVm(
            List<SalesRequest> requests,
            bool isManagerView,
            bool canAccessManagerPanel,
            string? region,
            List<SalesRequest> myRequests,
            string salespersonName,
            string salespersonEmail)
        {
            return new SalesDashboardVm
            {
                IsManagerView = isManagerView,
                CanAccessManagerPanel = canAccessManagerPanel,
                CurrentRegion = region,
                SalespersonName = salespersonName,
                SalespersonEmail = salespersonEmail,
                TotalRequestCount = requests.Count,
                OpenRequestCount = requests.Count(IsOpenRequest),
                ClosedRequestCount = requests.Count(x => x.WorkflowStatus == SalesRequestWorkflowStatus.Rejected),
                QuoteSharedCount = requests.Count(x => x.CustomerQuoteStatus == SalesCustomerQuoteStatus.SharedWithCustomer),
                ApprovedCount = requests.Count(x => x.WorkflowStatus == SalesRequestWorkflowStatus.Approved),
                WaitingPricingCount = requests.Count(x => x.WorkflowStatus == SalesRequestWorkflowStatus.Submitted || x.WorkflowStatus == SalesRequestWorkflowStatus.PricingInProgress),
                SalespersonStats = isManagerView
                    ? requests.GroupBy(x => x.RequestedByName)
                        .Select(g => new SalespersonRequestStatVm
                        {
                            SalespersonName = string.IsNullOrWhiteSpace(g.Key) ? "Belirtilmemiş" : g.Key,
                            TotalRequestCount = g.Count(),
                            OpenRequestCount = g.Count(IsOpenRequest),
                            ClosedRequestCount = g.Count(x => x.WorkflowStatus == SalesRequestWorkflowStatus.Rejected),
                            QuoteSharedCount = g.Count(x => x.CustomerQuoteStatus == SalesCustomerQuoteStatus.SharedWithCustomer),
                            ApprovedCount = g.Count(x => x.WorkflowStatus == SalesRequestWorkflowStatus.Approved)
                        })
                        .OrderByDescending(x => x.TotalRequestCount)
                        .ToList()
                    : new List<SalespersonRequestStatVm>(),
                MyRequests = myRequests
                    .OrderByDescending(x => x.SalesOpenedAt)
                    .Take(10)
                    .Select(x => new SalesDashboardRequestVm
                    {
                        Id = x.Id,
                        RequestNo = x.RequestNo,
                        Title = x.Title,
                        CustomerName = x.Customer.CompanyName,
                        SalesOpenedAt = x.SalesOpenedAt,
                        WorkflowStatus = x.WorkflowStatus,
                        CustomerQuoteStatus = x.CustomerQuoteStatus
                    })
                    .ToList()
            };
        }

        private static bool IsOpenRequest(SalesRequest request)
        {
            return request.WorkflowStatus != SalesRequestWorkflowStatus.Rejected
                   && request.CustomerQuoteStatus != SalesCustomerQuoteStatus.SharedWithCustomer;
        }
    }
}
