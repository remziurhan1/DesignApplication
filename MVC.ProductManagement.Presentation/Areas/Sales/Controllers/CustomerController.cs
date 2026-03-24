using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.SalesRequestVMs;

namespace MVC.ProductManagement.Presentation.Areas.Sales.Controllers
{
    public class CustomerController : SalesBaseController
    {
        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if (!await HasSalesPermissionAsync(x => x.CanManageSalesCustomers))
            {
                return Forbid();
            }

            var customers = await _context.Customers
                .Where(x => x.Status != Domain.Enums.Status.Deleted)
                .OrderBy(x => x.CompanyName)
                .Select(x => new CustomerListVm
                {
                    Id = x.Id,
                    CompanyName = x.CompanyName,
                    ContactName = x.ContactName,
                    ContactPersons = x.ContactPersons,
                    ContactPhones = x.ContactPhones,
                    ContactEmails = x.ContactEmails,
                    Email = x.Email,
                    Phone = x.Phone,
                    City = x.City,
                    Country = x.Country,
                    Sector = x.Sector,
                    MainDealerCountry = x.MainDealerCountry,
                    Region = x.Region,
                    IsActive = x.IsActive
                })
                .ToListAsync();

            return View("~/Areas/Admin/Views/Customer/Index.cshtml", customers);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            if (!await HasSalesPermissionAsync(x => x.CanManageSalesCustomers))
            {
                return Forbid();
            }

            return View("~/Areas/Admin/Views/Customer/Create.cshtml", new CustomerFormVm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerFormVm vm)
        {
            if (!await HasSalesPermissionAsync(x => x.CanManageSalesCustomers))
            {
                return Forbid();
            }

            if (!ModelState.IsValid)
            {
                return View("~/Areas/Admin/Views/Customer/Create.cshtml", vm);
            }

            var entity = new Domain.Entities.Customer
            {
                CompanyName = vm.CompanyName,
                ContactName = vm.ContactName,
                ContactPersons = vm.ContactPersons,
                ContactPhones = vm.ContactPhones,
                ContactEmails = vm.ContactEmails,
                Email = vm.Email,
                Phone = vm.Phone,
                Address = vm.Address,
                City = vm.City,
                Country = vm.Country,
                Sector = vm.Sector,
                MainDealerCountry = vm.MainDealerCountry,
                Region = vm.Region,
                TaxNumber = vm.TaxNumber,
                TaxOffice = vm.TaxOffice,
                Notes = vm.Notes,
                IsActive = vm.IsActive
            };

            _context.Customers.Add(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
