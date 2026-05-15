using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs.EN13458DTOs;
using MVC.ProductManagement.Application.DTOs.MaterialDTOs;
using MVC.ProductManagement.Application.DTOs.MaterialFormDTOs;
using MVC.ProductManagement.Application.Services.EN13458CalculationServices;
using MVC.ProductManagement.Application.Services.MaterialFormServices;
using MVC.ProductManagement.Application.Services.MaterialServices;
using MVC.ProductManagement.Application.Services.StorageTypeServices;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Presentation.Areas.Design.Mappers;
using MVC.ProductManagement.Presentation.Areas.Design.Models.EN13458CalculationVMs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Presentation.Areas.Design.Controllers
{
    public class EN13458CalculationController : DesignBaseController
    {
        private readonly IEN13458CalculationServices _service;
        private readonly IMaterialService _materialService;
        private readonly IMaterialFormService _materialFormService;
        private readonly IStorageTypeService _storageTypeService;

        public EN13458CalculationController(
            IEN13458CalculationServices service,
            IMaterialService materialService,
            IMaterialFormService materialFormService,
            IStorageTypeService storageTypeService)
        {
            _service = service;
            _materialService = materialService;
            _materialFormService = materialFormService;
            _storageTypeService = storageTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await _service.GetAllAsync();
            var vm = list.Select(x => new EN13458ListVM
            {
                Id = x.Id,
                Name = x.Name,
                OuterDiameter = x.OuterDiameter,
                OuterTankDiameter = x.OuterTankDiameter,
                ShellLength = x.ShellLength,
                Pressure = x.Pressure,
                RoundedInnerShellThickness = x.RoundedInnerShellThickness,
                RoundedOuterShellThickness = x.RoundedOuterShellThickness
            }).ToList();

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id, string mode = "manager")
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var vm = EN13458CalculationVmMapper.MapDetailsVm(dto);
            await PopulateResultDisplayNamesAsync(vm);
            ViewBag.IsSalesView = string.Equals(mode, "sales", StringComparison.OrdinalIgnoreCase);

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();

            await LoadLookupsAsync();
            return View("Calculate", EN13458CalculationVmMapper.MapCalculateVm(dto));
        }

        [HttpGet]
        public async Task<IActionResult> Calculate()
        {
            await LoadLookupsAsync();

            return View(new EN13458CalculateVM
            {
                Name = "EN13458 Hesabı",
                OuterDiameter = 2000,
                OuterTankDiameter = 2500,
                ShellLength = 6000,
                Pressure = 16,
                StorageTypeId = Guid.Empty,
                LiquidDensity = 808,
                TankOrientation = TankOrientation.Horizontal,
                IsColdStretchApplied = false,
                StiffenerSpacing = 750
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public Task<IActionResult> Calculate(EN13458CalculateVM vm) => ProcessCalculationAsync(vm, isEditMode: false);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public Task<IActionResult> Update(EN13458CalculateVM vm) => ProcessCalculationAsync(vm, isEditMode: true);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(EN13458ResultVM vm)
        {
            var dto = EN13458CalculationVmMapper.MapResultDto(vm);
            var saved = await _service.SaveAsync(dto, User?.Identity?.Name ?? "DesignUser");
            TempData["SuccessMessage"] = vm.IsEditMode ? "Tank hesabı güncellendi." : "Tank hesabı kaydedildi.";
            return RedirectToAction(nameof(Details), new { id = saved.Id });
        }

        private async Task<IActionResult> ProcessCalculationAsync(EN13458CalculateVM vm, bool isEditMode)
        {
            if (!ModelState.IsValid)
            {
                await LoadLookupsAsync();
                return View("Calculate", vm);
            }

            if (vm.StorageTypeId == Guid.Empty)
            {
                ModelState.AddModelError(nameof(vm.StorageTypeId), "Lütfen bir depolama tipi seçin.");
                await LoadLookupsAsync();
                return View("Calculate", vm);
            }

            double liquidDensity;
            try
            {
                liquidDensity = await ResolveLiquidDensityAsync(vm.StorageTypeId);
                vm.LiquidDensity = liquidDensity;
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(nameof(vm.StorageTypeId), ex.Message);
                await LoadLookupsAsync();
                return View("Calculate", vm);
            }

            var dto = new EN13458CalculateDTO
            {
                Name = vm.Name,
                OuterDiameter = vm.OuterDiameter,
                OuterTankDiameter = vm.OuterTankDiameter,
                ShellLength = vm.ShellLength,
                Pressure = vm.Pressure,
                StorageTypeId = vm.StorageTypeId,
                LiquidDensity = liquidDensity,
                TankOrientation = vm.TankOrientation,
                IsColdStretchApplied = vm.IsColdStretchApplied,
                InnerShellMaterialId = vm.InnerShellMaterialId,
                InnerShellMaterialFormId = vm.InnerShellMaterialFormId,
                InnerHeadMaterialId = vm.InnerHeadMaterialId,
                InnerHeadMaterialFormId = vm.InnerHeadMaterialFormId,
                OuterShellMaterialId = vm.OuterShellMaterialId,
                OuterShellMaterialFormId = vm.OuterShellMaterialFormId,
                OuterHeadMaterialId = vm.OuterHeadMaterialId,
                OuterHeadMaterialFormId = vm.OuterHeadMaterialFormId,
                StiffenerSpacing = vm.StiffenerSpacing,
                StiffenerArea = vm.StiffenerArea,
                StiffenerInertia = vm.StiffenerInertia,
                StiffenerSectionModulus = vm.StiffenerSectionModulus
            };

            try
            {
                var result = await _service.CalculateAsync(dto);
                result.Id = vm.Id;
                var resultVm = EN13458CalculationVmMapper.MapResultVm(result);
                resultVm.IsEditMode = isEditMode;
                await PopulateResultDisplayNamesAsync(resultVm);
                return View("Result", resultVm);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                await LoadLookupsAsync();
                return View("Calculate", vm);
            }
        }

        private async Task PopulateResultDisplayNamesAsync(EN13458ResultVM vm)
        {
            var materials = await _materialService.GetAllAsync();
            var forms = await _materialFormService.GetAllAsync();
            var storageTypes = await _storageTypeService.GetAllAsync();

            var materialMap = materials.ToDictionary(x => x.Id, x => x.Name);
            var formMap = forms.ToDictionary(x => x.Id, x => $"{x.FormType} [{x.ThicknessMin}-{x.ThicknessMax}]");
            var storageTypeMap = (storageTypes.Data ?? new List<MVC.ProductManagement.Application.DTOs.StorageTypeDTOs.StorageTypeListDTO>())
                .ToDictionary(x => x.Id, x => x.Name);

            vm.StorageTypeName = storageTypeMap.GetValueOrDefault(vm.StorageTypeId, "-");
            vm.InnerShellMaterialName = materialMap.GetValueOrDefault(vm.InnerShellMaterialId, "-");
            vm.InnerShellMaterialFormName = formMap.GetValueOrDefault(vm.InnerShellMaterialFormId, "-");
            vm.InnerHeadMaterialName = materialMap.GetValueOrDefault(vm.InnerHeadMaterialId, "-");
            vm.InnerHeadMaterialFormName = formMap.GetValueOrDefault(vm.InnerHeadMaterialFormId, "-");
            vm.OuterShellMaterialName = materialMap.GetValueOrDefault(vm.OuterShellMaterialId, "-");
            vm.OuterShellMaterialFormName = formMap.GetValueOrDefault(vm.OuterShellMaterialFormId, "-");
            vm.OuterHeadMaterialName = materialMap.GetValueOrDefault(vm.OuterHeadMaterialId, "-");
            vm.OuterHeadMaterialFormName = formMap.GetValueOrDefault(vm.OuterHeadMaterialFormId, "-");
        }

        private async Task<double> ResolveLiquidDensityAsync(Guid storageTypeId)
        {
            var storageType = await _storageTypeService.GetByIdAsync(storageTypeId);
            if (storageType?.Data == null || storageType.Data.Density <= 0)
            {
                throw new InvalidOperationException("Seçilen depolama tipi için geçerli yoğunluk verisi bulunamadı.");
            }

            return storageType.Data.Density;
        }

        private async Task LoadLookupsAsync()
        {
            var materials = await _materialService.GetAllAsync();
            var forms = await _materialFormService.GetAllAsync();
            var storageTypes = await _storageTypeService.GetAllAsync();

            static string BuildMaterialDisplay(MaterialListDto material, IEnumerable<MaterialFormListDto> materialForms, string? materialClass = null)
            {
                var scopedForms = materialForms
                    .Where(x => string.IsNullOrWhiteSpace(materialClass)
                        || string.Equals((x.MaterialClass ?? string.Empty).Trim(), materialClass.Trim(), StringComparison.OrdinalIgnoreCase));

                var details = scopedForms
                    .Select(x => string.Join(" / ", new[] { x.SymbolicName, x.Norm, x.FormType.ToString() }
                        .Where(v => !string.IsNullOrWhiteSpace(v))
                        .Select(v => v!.Trim())))
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .Take(2)
                    .ToList();

                return details.Count == 0 ? material.Name : $"{material.Name} ({string.Join(" | ", details)})";
            }

            var formsByMaterialId = forms
                .GroupBy(x => x.MaterialId)
                .ToDictionary(g => g.Key, g => g.ToList());

            ViewBag.Materials = materials
                .Select(x => new SelectListItem(
                    BuildMaterialDisplay(x, formsByMaterialId.GetValueOrDefault(x.Id) ?? new List<MaterialFormListDto>()),
                    x.Id.ToString()))
                .ToList();
            var materialClasses = forms
                .Select(x => (x.MaterialClass ?? string.Empty).Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(x => x)
                .ToList();

            ViewBag.MaterialGroups = materialClasses
                .Select(x => new SelectListItem(x, x))
                .ToList();

            ViewBag.MaterialsByGroup = materialClasses.ToDictionary(
                group => group,
                group => materials
                    .Where(m => (formsByMaterialId.GetValueOrDefault(m.Id) ?? new List<MaterialFormListDto>())
                        .Any(f => string.Equals((f.MaterialClass ?? string.Empty).Trim(), group, StringComparison.OrdinalIgnoreCase)))
                    .Select(m => new
                    {
                        value = m.Id.ToString(),
                        text = BuildMaterialDisplay(m, formsByMaterialId.GetValueOrDefault(m.Id) ?? new List<MaterialFormListDto>(), group)
                    })
                    .ToList(),
                StringComparer.OrdinalIgnoreCase);

            ViewBag.MaterialForms = forms
                .Select(x => new SelectListItem($"{x.FormType} [{x.ThicknessMin}-{x.ThicknessMax}]", x.Id.ToString()))
                .ToList();

            ViewBag.MaterialFormsByMaterial = forms
                .GroupBy(x => x.MaterialId)
                .ToDictionary(
                    g => g.Key.ToString(),
                    g => g.Select(x => new
                    {
                        value = x.Id.ToString(),
                        text = $"{x.FormType} [{x.ThicknessMin}-{x.ThicknessMax}]",
                        formType = x.FormType.ToString(),
                        materialClass = x.MaterialClass,
                        norm = x.Norm,
                        symbolicName = x.SymbolicName,
                        momentOfInertia = x.MomentOfInertia,
                        sectionArea = x.SectionArea,
                        sectionModulus = x.SectionModulus
                    }).ToList());

            ViewBag.MaterialFormTypesByMaterial = forms
                .GroupBy(x => x.MaterialId)
                .ToDictionary(g => g.Key.ToString(), g => g.Select(x => x.FormType.ToString()).Distinct().OrderBy(x => x).ToList());

            ViewBag.StorageTypes = (storageTypes.Data ?? new List<MVC.ProductManagement.Application.DTOs.StorageTypeDTOs.StorageTypeListDTO>())
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            ViewBag.StorageTypeDensities = (storageTypes.Data ?? new List<MVC.ProductManagement.Application.DTOs.StorageTypeDTOs.StorageTypeListDTO>())
                .ToDictionary(x => x.Id.ToString(), x => x.Density);

            ViewBag.MaterialExternalProperties = forms.ToDictionary(x => x.Id.ToString(), x => new { elasticModulus = x.ElasticModulus, yieldFactorK = x.YieldFactorK });
        }

    }
}
