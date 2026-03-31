using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.EmployeeVMs;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    public class EmployeeController : AdminBaseController
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EmployeeController(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var vm = await _context.EmployeeProfiles
                .AsNoTracking()
                .Where(x => x.Status != Status.Deleted)
                .OrderBy(x => x.Department)
                .ThenBy(x => x.FullName)
                .Select(x => new EmployeeListVm
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    Department = x.Department,
                    DepartmentRole = x.DepartmentRole,
                    Title = x.Title,
                    Number = x.Number,
                    Email = x.Email,
                    Location = x.Location,
                    CanAccessSalesArea = x.CanAccessSalesArea
                })
                .ToListAsync();

            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new EmployeeCreateVm
            {
                CanAccessSalesArea = true,
                CanManageSalesCustomers = true,
                CanCreateSalesRequests = true,
                CanViewSalesPricing = true
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var existingUser = await _userManager.FindByEmailAsync(vm.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError(nameof(vm.Email), "Bu mail ile kayıtlı bir kullanıcı zaten var.");
                return View(vm);
            }

            var user = new IdentityUser
            {
                UserName = vm.Email,
                Email = vm.Email,
                PhoneNumber = vm.Number
            };

            var createResult = await _userManager.CreateAsync(user, vm.Password);
            if (!createResult.Succeeded)
            {
                foreach (var error in createResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(vm);
            }

            var roleName = vm.Department.Equals("Satış", StringComparison.OrdinalIgnoreCase)
                ? Roles.Sales.ToString()
                : vm.Department.Equals("Dizayn", StringComparison.OrdinalIgnoreCase)
                    ? (vm.DepartmentRole.Contains("Müdür", StringComparison.OrdinalIgnoreCase)
                        ? Roles.DesignManager.ToString()
                        : Roles.DesignEngineer.ToString())
                    : Roles.Admin.ToString();

            await _userManager.AddToRoleAsync(user, roleName);

            _context.EmployeeProfiles.Add(new EmployeeProfile
            {
                UserId = user.Id,
                FullName = vm.FullName,
                Department = vm.Department,
                DepartmentRole = vm.DepartmentRole,
                Title = vm.Title,
                Number = vm.Number,
                Email = vm.Email,
                Location = vm.Location,
                CanAccessSalesArea = vm.CanAccessSalesArea,
                CanManageSalesCustomers = vm.CanManageSalesCustomers,
                CanCreateSalesRequests = vm.CanCreateSalesRequests,
                CanViewSalesPricing = vm.CanViewSalesPricing
            });

            await _context.SaveChangesAsync();
            SuccesNotyf("Çalışan hesabı oluşturuldu.");

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var profile = await _context.EmployeeProfiles
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id && x.Status != Status.Deleted);
            if (profile == null)
            {
                return NotFound();
            }

            var vm = new EmployeeUpdateVm
            {
                Id = profile.Id,
                FullName = profile.FullName,
                Department = profile.Department,
                DepartmentRole = profile.DepartmentRole,
                Title = profile.Title,
                Number = profile.Number,
                Email = profile.Email,
                Location = profile.Location,
                CanAccessSalesArea = profile.CanAccessSalesArea,
                CanManageSalesCustomers = profile.CanManageSalesCustomers,
                CanCreateSalesRequests = profile.CanCreateSalesRequests,
                CanViewSalesPricing = profile.CanViewSalesPricing
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeUpdateVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var profile = await _context.EmployeeProfiles.FirstOrDefaultAsync(x => x.Id == vm.Id && x.Status != Status.Deleted);
            if (profile == null)
            {
                return NotFound();
            }

            profile.FullName = vm.FullName;
            profile.Department = vm.Department;
            profile.DepartmentRole = vm.DepartmentRole;
            profile.Title = vm.Title;
            profile.Number = vm.Number;
            profile.Email = vm.Email;
            profile.Location = vm.Location;
            profile.CanAccessSalesArea = vm.CanAccessSalesArea;
            profile.CanManageSalesCustomers = vm.CanManageSalesCustomers;
            profile.CanCreateSalesRequests = vm.CanCreateSalesRequests;
            profile.CanViewSalesPricing = vm.CanViewSalesPricing;

            await _context.SaveChangesAsync();
            SuccesNotyf("Satışçı bilgileri güncellendi.");
            return RedirectToAction(nameof(Index));
        }
    }
}
