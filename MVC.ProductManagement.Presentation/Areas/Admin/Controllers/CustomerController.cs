using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.SalesRequestVMs;
using MVC.ProductManagement.Infrastructure.AppContext;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    public class CustomerController : AdminBaseController
    {
        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
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

            return View(customers);
        }

        [HttpGet]
        public IActionResult Create() => View(new CustomerFormVm());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerFormVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var entity = new Customer
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

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var entity = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id && x.Status != Domain.Enums.Status.Deleted);
            if (entity == null) return NotFound();

            return View(new CustomerFormVm
            {
                Id = entity.Id,
                CompanyName = entity.CompanyName,
                ContactName = entity.ContactName,
                ContactPersons = entity.ContactPersons,
                ContactPhones = entity.ContactPhones,
                ContactEmails = entity.ContactEmails,
                Email = entity.Email,
                Phone = entity.Phone,
                Address = entity.Address,
                City = entity.City,
                Country = entity.Country,
                Sector = entity.Sector,
                MainDealerCountry = entity.MainDealerCountry,
                Region = entity.Region,
                TaxNumber = entity.TaxNumber,
                TaxOffice = entity.TaxOffice,
                Notes = entity.Notes,
                IsActive = entity.IsActive
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CustomerFormVm vm)
        {
            if (!ModelState.IsValid) return View(vm);
            if (vm.Id == null) return BadRequest();

            var entity = await _context.Customers.FirstOrDefaultAsync(x => x.Id == vm.Id && x.Status != Domain.Enums.Status.Deleted);
            if (entity == null) return NotFound();

            entity.CompanyName = vm.CompanyName;
            entity.ContactName = vm.ContactName;
            entity.ContactPersons = vm.ContactPersons;
            entity.ContactPhones = vm.ContactPhones;
            entity.ContactEmails = vm.ContactEmails;
            entity.Email = vm.Email;
            entity.Phone = vm.Phone;
            entity.Address = vm.Address;
            entity.City = vm.City;
            entity.Country = vm.Country;
            entity.Sector = vm.Sector;
            entity.MainDealerCountry = vm.MainDealerCountry;
            entity.Region = vm.Region;
            entity.TaxNumber = vm.TaxNumber;
            entity.TaxOffice = vm.TaxOffice;
            entity.Notes = vm.Notes;
            entity.IsActive = vm.IsActive;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id && x.Status != Domain.Enums.Status.Deleted);
            if (entity == null) return NotFound();

            var hasRequest = await _context.SalesRequests.AnyAsync(x => x.CustomerId == id && x.Status != Domain.Enums.Status.Deleted);
            if (hasRequest)
            {
                entity.IsActive = false;
            }
            else
            {
                _context.Customers.Remove(entity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
