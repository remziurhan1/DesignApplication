using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs.TankRequestDTOs;
using MVC.ProductManagement.Application.Services.TankRequestServices;
using MVC.ProductManagement.Infrastructure.Repositories.DesignStandardRepository;
using MVC.ProductManagement.Infrastructure.Repositories.GasTypeRepositories;
using MVC.ProductManagement.Infrastructure.Repositories.IProductCodeRepositories;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.TankRequestVMs;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    public class TankRequestController : AdminBaseController
    {
        private readonly ITankRequestService _tankRequestService;
        private readonly IGasTypeRepository _gasTypeRepository;
        private readonly IDesignStandardRepository _designStandardRepository;
        private readonly IProductCodeRepository _productCodeRepository;

        public TankRequestController(
            ITankRequestService tankRequestService,
            IGasTypeRepository gasTypeRepository,
            IDesignStandardRepository designStandardRepository,
            IProductCodeRepository productCodeRepository)
        {
            _tankRequestService = tankRequestService;
            _gasTypeRepository = gasTypeRepository;
            _designStandardRepository = designStandardRepository;
            _productCodeRepository = productCodeRepository;
        }

        // Listeleme
        public async Task<IActionResult> Index()
        {
            var dtos = await _tankRequestService.GetAllAsync();
            var vms = dtos.Select(x => new TankRequestListViewModel
            {
                Id = x.Id,
                GasTypeName = x.GasTypeName,
                DesignStandardName = x.DesignStandardName,
                UsageType = x.UsageType.ToString(),
                Orientation = x.Orientation.ToString(),
                Placement = x.Placement.ToString(),
                CapacityValue = x.CapacityValue,
                OperatingPressure = x.OperatingPressure,
                TankCode = x.TankCode
            }).ToList();

            return View(vms);
        }

        // Detay
        public async Task<IActionResult> Details(Guid id)
        {
            var dto = await _tankRequestService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var vm = new TankRequestDetailViewModel
            {
                Id = dto.Id,
                GasTypeName = dto.GasTypeName,
                DesignStandardName = dto.DesignStandardName,
                UsageType = dto.UsageType.ToString(),
                Orientation = dto.Orientation.ToString(),
                Placement = dto.Placement.ToString(),
                TransportType = dto.TransportType,
                CapacityValue = dto.CapacityValue,
                OperatingPressure = dto.OperatingPressure,
                DesignPressure = dto.DesignPressure,
                InnerDiameter = dto.InnerDiameter,
                IsInnerTankStainless = dto.IsInnerTankStainless,
                TankCode = dto.TankCode,
                ProductCode = dto.ProductCode,
                Notes = dto.Notes
            };

            return View(vm);
        }

        // Yeni kayıt GET
        public async Task<IActionResult> Create()
        {
            var vm = new TankRequestCreateViewModel
            {
                GasTypes = (await _gasTypeRepository.GetAllAsync())
                    .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList(),
                DesignStandards = (await _designStandardRepository.GetAllAsync())
                    .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList(),
                ProductCodes = (await _productCodeRepository.GetAllAsync())
                    .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Code }).ToList()
            };
            return View(vm);
        }

        // Yeni kayıt POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TankRequestCreateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                // DropDown'ları tekrar doldur
                vm.GasTypes = (await _gasTypeRepository.GetAllAsync())
                    .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList();
                vm.DesignStandards = (await _designStandardRepository.GetAllAsync())
                    .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList();
                vm.ProductCodes = (await _productCodeRepository.GetAllAsync())
                    .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Code }).ToList();
                return View(vm);
            }

            // DTO'ya map et
            var dto = new TankRequestCreateDto
            {
                GasTypeId = vm.GasTypeId,
                DesignStandardId = vm.DesignStandardId,
                UsageType = vm.UsageType,
                Orientation = vm.Orientation,
                Placement = vm.Placement,
                TransportType = vm.TransportType,
                CapacityValue = vm.CapacityValue,
                OperatingPressure = vm.OperatingPressure,
                DesignPressure = vm.DesignPressure,
                InnerDiameter = vm.InnerDiameter,
                IsInnerTankStainless = vm.IsInnerTankStainless,
                TankCode = vm.TankCode,
                ProductCodeId = vm.ProductCodeId,
                Notes = vm.Notes
            };

            await _tankRequestService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        // Düzenleme GET
        public async Task<IActionResult> Edit(Guid id)
        {
            var dto = await _tankRequestService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var vm = new TankRequestEditViewModel
            {
                Id = dto.Id,
                GasTypeId = dto.GasTypeId,
                DesignStandardId = dto.DesignStandardId,
                UsageType = dto.UsageType,
                Orientation = dto.Orientation,
                Placement = dto.Placement,
                TransportType = dto.TransportType,
                CapacityValue = dto.CapacityValue,
                OperatingPressure = dto.OperatingPressure,
                DesignPressure = dto.DesignPressure,
                InnerDiameter = dto.InnerDiameter,
                IsInnerTankStainless = dto.IsInnerTankStainless,
                TankCode = dto.TankCode,
                ProductCodeId = dto.ProductCodeId,
                Notes = dto.Notes,
                GasTypes = (await _gasTypeRepository.GetAllAsync())
                    .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList(),
                DesignStandards = (await _designStandardRepository.GetAllAsync())
                    .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList(),
                ProductCodes = (await _productCodeRepository.GetAllAsync())
                    .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Code }).ToList()
            };

            return View(vm);
        }

        // Düzenleme POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TankRequestEditViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.GasTypes = (await _gasTypeRepository.GetAllAsync())
                    .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList();
                vm.DesignStandards = (await _designStandardRepository.GetAllAsync())
                    .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList();
                vm.ProductCodes = (await _productCodeRepository.GetAllAsync())
                    .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Code }).ToList();
                return View(vm);
            }

            var dto = new TankRequestUpdateDto
            {
                Id = vm.Id,
                GasTypeId = vm.GasTypeId,
                DesignStandardId = vm.DesignStandardId,
                UsageType = vm.UsageType,
                Orientation = vm.Orientation,
                Placement = vm.Placement,
                TransportType = vm.TransportType,
                CapacityValue = vm.CapacityValue,
                OperatingPressure = vm.OperatingPressure,
                DesignPressure = vm.DesignPressure,
                InnerDiameter = vm.InnerDiameter,
                IsInnerTankStainless = vm.IsInnerTankStainless,
                TankCode = vm.TankCode,
                ProductCodeId = vm.ProductCodeId,
                Notes = vm.Notes
            };

            await _tankRequestService.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        // Silme
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _tankRequestService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
