using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs.EN13458DTOs;
using MVC.ProductManagement.Application.Services.EN13458CalculationServices;
using MVC.ProductManagement.Application.Services.MaterialFormServices;
using MVC.ProductManagement.Application.Services.MaterialServices;
using MVC.ProductManagement.Application.Services.StorageTypeServices;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.EN13458CalculationVMs;
using MVC.ProductManagement.Infrastructure.Repositories.StorageTypePropertiesRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    public class EN13458CalculationController : AdminBaseController
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
                ShellLength = x.ShellLength,
                Pressure = x.Pressure,
                RoundedInnerShellThickness = x.RoundedInnerShellThickness,
                RoundedOuterShellThickness = x.RoundedOuterShellThickness
            }).ToList();

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var vm = new EN13458DetailsVM
            {
                Id = dto.Id,
                Name = dto.Name,
                OuterDiameter = dto.OuterDiameter,
                ShellLength = dto.ShellLength,
                Pressure = dto.Pressure,
                StorageTypeId = dto.StorageTypeId,
                LiquidDensity = dto.LiquidDensity,
                TankOrientation = dto.TankOrientation,
                IsColdStretchApplied = dto.IsColdStretchApplied,
                WeldLength1500 = dto.WeldLength1500,
                WeldLength2000 = dto.WeldLength2000,
                WeldLength2500 = dto.WeldLength2500,
                WeldLength3000 = dto.WeldLength3000,
                InnerShellMaterialId = dto.InnerShellMaterialId,
                InnerShellMaterialFormId = dto.InnerShellMaterialFormId,
                InnerHeadMaterialId = dto.InnerHeadMaterialId,
                InnerHeadMaterialFormId = dto.InnerHeadMaterialFormId,
                OuterShellMaterialId = dto.OuterShellMaterialId,
                OuterShellMaterialFormId = dto.OuterShellMaterialFormId,
                OuterHeadMaterialId = dto.OuterHeadMaterialId,
                OuterHeadMaterialFormId = dto.OuterHeadMaterialFormId,
                InnerShellMaterialStrength = dto.InnerShellMaterialStrength,
                InnerHeadMaterialStrength = dto.InnerHeadMaterialStrength,
                OuterShellMaterialStrength = dto.OuterShellMaterialStrength,
                OuterHeadMaterialStrength = dto.OuterHeadMaterialStrength,
                InnerShellThickness = dto.InnerShellThickness,
                InnerHeadThickness = dto.InnerHeadThickness,
                OuterShellThickness = dto.OuterShellThickness,
                OuterHeadThickness = dto.OuterHeadThickness,
                RoundedInnerShellThickness = dto.RoundedInnerShellThickness,
                RoundedInnerHeadThickness = dto.RoundedInnerHeadThickness,
                RoundedOuterShellThickness = dto.RoundedOuterShellThickness,
                RoundedOuterHeadThickness = dto.RoundedOuterHeadThickness,
                DesignPressure = dto.DesignPressure,
                TestPressure = dto.TestPressure,
                StaticPressure = dto.StaticPressure,
                InnerTankHeadPulDiameter = dto.InnerTankHeadPulDiameter,
                OuterTankHeadPulDiameter = dto.OuterTankHeadPulDiameter,
                InnerTankHeadWeight = dto.InnerTankHeadWeight,
                OuterTankHeadWeight = dto.OuterTankHeadWeight,
                InnerTankHeadWeldLength = dto.InnerTankHeadWeldLength,
                InnerTankCircumferenceWeldLength = dto.InnerTankCircumferenceWeldLength,
                OuterTankHeadWeldLength = dto.OuterTankHeadWeldLength,
                OuterTankCircumferenceWeldLength = dto.OuterTankCircumferenceWeldLength,
                TotalWeldLength = dto.TotalWeldLength,
                TotalFilmCost = dto.TotalFilmCost,
                InnerTankTotalLength = dto.InnerTankTotalLength,
                OuterTankTotalLength = dto.OuterTankTotalLength,
                InnerVolume = dto.InnerVolume,
                OuterVolume = dto.OuterVolume,
                InnerSurfaceArea = dto.InnerSurfaceArea,
                OuterSurfaceArea = dto.OuterSurfaceArea,
                InnerTankWeight = dto.InnerTankWeight,
                OuterTankWeight = dto.OuterTankWeight,
                PerliteVolume = dto.PerliteVolume,
                PerliteWeight = dto.PerliteWeight,
                GasNitrogenVolume = dto.GasNitrogenVolume,
                LiquidNitrogenVolume = dto.LiquidNitrogenVolume
            };

            await PopulateResultDisplayNamesAsync(vm);

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Calculate()
        {
            await LoadLookupsAsync();

            return View(new EN13458CalculateVM
            {
                Name = "EN13458 Hesabı",
                OuterDiameter = 2000,
                ShellLength = 6000,
                Pressure = 16,
                StorageTypeId = Guid.Empty,
                LiquidDensity = 808,
                TankOrientation = TankOrientation.Horizontal,
                IsColdStretchApplied = false
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Calculate(EN13458CalculateVM vm)
        {
            if (!ModelState.IsValid)
            {
                await LoadLookupsAsync();
                return View(vm);
            }

            if (vm.StorageTypeId == Guid.Empty)
            {
                ModelState.AddModelError(nameof(vm.StorageTypeId), "Lütfen bir depolama tipi seçin.");
                await LoadLookupsAsync();
                return View(vm);
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
                return View(vm);
            }

            var dto = new EN13458CalculateDTO
            {
                Name = vm.Name,
                OuterDiameter = vm.OuterDiameter,
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
                OuterHeadMaterialFormId = vm.OuterHeadMaterialFormId
            };

            var result = await _service.CalculateAsync(dto);
            var resultVm = MapResultVm(result);
            await PopulateResultDisplayNamesAsync(resultVm);

            return View("Result", resultVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(EN13458ResultVM vm)
        {
            var dto = MapResultDto(vm);
            var saved = await _service.SaveAsync(dto, User?.Identity?.Name ?? "AdminUser");
            return RedirectToAction(nameof(Details), new { id = saved.Id });
        }

        private EN13458ResultVM MapResultVm(EN13458ResultDTO dto)
        {
            return new EN13458ResultVM
            {
                Id = dto.Id,
                Name = dto.Name,
                OuterDiameter = dto.OuterDiameter,
                ShellLength = dto.ShellLength,
                Pressure = dto.Pressure,
                StorageTypeId = dto.StorageTypeId,
                LiquidDensity = dto.LiquidDensity,
                TankOrientation = dto.TankOrientation,
                IsColdStretchApplied = dto.IsColdStretchApplied,
                WeldLength1500 = dto.WeldLength1500,
                WeldLength2000 = dto.WeldLength2000,
                WeldLength2500 = dto.WeldLength2500,
                WeldLength3000 = dto.WeldLength3000,
                InnerShellMaterialId = dto.InnerShellMaterialId,
                InnerShellMaterialFormId = dto.InnerShellMaterialFormId,
                InnerHeadMaterialId = dto.InnerHeadMaterialId,
                InnerHeadMaterialFormId = dto.InnerHeadMaterialFormId,
                OuterShellMaterialId = dto.OuterShellMaterialId,
                OuterShellMaterialFormId = dto.OuterShellMaterialFormId,
                OuterHeadMaterialId = dto.OuterHeadMaterialId,
                OuterHeadMaterialFormId = dto.OuterHeadMaterialFormId,
                InnerShellMaterialStrength = dto.InnerShellMaterialStrength,
                InnerHeadMaterialStrength = dto.InnerHeadMaterialStrength,
                OuterShellMaterialStrength = dto.OuterShellMaterialStrength,
                OuterHeadMaterialStrength = dto.OuterHeadMaterialStrength,
                InnerShellThickness = dto.InnerShellThickness,
                InnerHeadThickness = dto.InnerHeadThickness,
                OuterShellThickness = dto.OuterShellThickness,
                OuterHeadThickness = dto.OuterHeadThickness,
                RoundedInnerShellThickness = dto.RoundedInnerShellThickness,
                RoundedInnerHeadThickness = dto.RoundedInnerHeadThickness,
                RoundedOuterShellThickness = dto.RoundedOuterShellThickness,
                RoundedOuterHeadThickness = dto.RoundedOuterHeadThickness,
                DesignPressure = dto.DesignPressure,
                TestPressure = dto.TestPressure,
                StaticPressure = dto.StaticPressure,
                InnerTankHeadPulDiameter = dto.InnerTankHeadPulDiameter,
                OuterTankHeadPulDiameter = dto.OuterTankHeadPulDiameter,
                InnerTankHeadWeight = dto.InnerTankHeadWeight,
                OuterTankHeadWeight = dto.OuterTankHeadWeight,
                InnerTankHeadWeldLength = dto.InnerTankHeadWeldLength,
                InnerTankCircumferenceWeldLength = dto.InnerTankCircumferenceWeldLength,
                OuterTankHeadWeldLength = dto.OuterTankHeadWeldLength,
                OuterTankCircumferenceWeldLength = dto.OuterTankCircumferenceWeldLength,
                TotalWeldLength = dto.TotalWeldLength,
                TotalFilmCost = dto.TotalFilmCost,
                InnerTankTotalLength = dto.InnerTankTotalLength,
                OuterTankTotalLength = dto.OuterTankTotalLength,
                InnerVolume = dto.InnerVolume,
                OuterVolume = dto.OuterVolume,
                InnerSurfaceArea = dto.InnerSurfaceArea,
                OuterSurfaceArea = dto.OuterSurfaceArea,
                InnerTankWeight = dto.InnerTankWeight,
                OuterTankWeight = dto.OuterTankWeight,
                PerliteVolume = dto.PerliteVolume,
                PerliteWeight = dto.PerliteWeight,
                GasNitrogenVolume = dto.GasNitrogenVolume,
                LiquidNitrogenVolume = dto.LiquidNitrogenVolume
            };
        }

        private static EN13458ResultDTO MapResultDto(EN13458ResultVM vm)
        {
            return new EN13458ResultDTO
            {
                Id = vm.Id,
                Name = vm.Name,
                OuterDiameter = vm.OuterDiameter,
                ShellLength = vm.ShellLength,
                Pressure = vm.Pressure,
                StorageTypeId = vm.StorageTypeId,
                LiquidDensity = vm.LiquidDensity,
                TankOrientation = vm.TankOrientation,
                IsColdStretchApplied = vm.IsColdStretchApplied,
                WeldLength1500 = vm.WeldLength1500,
                WeldLength2000 = vm.WeldLength2000,
                WeldLength2500 = vm.WeldLength2500,
                WeldLength3000 = vm.WeldLength3000,
                InnerShellMaterialId = vm.InnerShellMaterialId,
                InnerShellMaterialFormId = vm.InnerShellMaterialFormId,
                InnerHeadMaterialId = vm.InnerHeadMaterialId,
                InnerHeadMaterialFormId = vm.InnerHeadMaterialFormId,
                OuterShellMaterialId = vm.OuterShellMaterialId,
                OuterShellMaterialFormId = vm.OuterShellMaterialFormId,
                OuterHeadMaterialId = vm.OuterHeadMaterialId,
                OuterHeadMaterialFormId = vm.OuterHeadMaterialFormId,
                InnerShellMaterialStrength = vm.InnerShellMaterialStrength,
                InnerHeadMaterialStrength = vm.InnerHeadMaterialStrength,
                OuterShellMaterialStrength = vm.OuterShellMaterialStrength,
                OuterHeadMaterialStrength = vm.OuterHeadMaterialStrength,
                InnerShellThickness = vm.InnerShellThickness,
                InnerHeadThickness = vm.InnerHeadThickness,
                OuterShellThickness = vm.OuterShellThickness,
                OuterHeadThickness = vm.OuterHeadThickness,
                RoundedInnerShellThickness = vm.RoundedInnerShellThickness,
                RoundedInnerHeadThickness = vm.RoundedInnerHeadThickness,
                RoundedOuterShellThickness = vm.RoundedOuterShellThickness,
                RoundedOuterHeadThickness = vm.RoundedOuterHeadThickness,
                DesignPressure = vm.DesignPressure,
                TestPressure = vm.TestPressure,
                StaticPressure = vm.StaticPressure,
                InnerTankHeadPulDiameter = vm.InnerTankHeadPulDiameter,
                OuterTankHeadPulDiameter = vm.OuterTankHeadPulDiameter,
                InnerTankHeadWeight = vm.InnerTankHeadWeight,
                OuterTankHeadWeight = vm.OuterTankHeadWeight,
                InnerTankHeadWeldLength = vm.InnerTankHeadWeldLength,
                InnerTankCircumferenceWeldLength = vm.InnerTankCircumferenceWeldLength,
                OuterTankHeadWeldLength = vm.OuterTankHeadWeldLength,
                OuterTankCircumferenceWeldLength = vm.OuterTankCircumferenceWeldLength,
                TotalWeldLength = vm.TotalWeldLength,
                TotalFilmCost = vm.TotalFilmCost,
                InnerTankTotalLength = vm.InnerTankTotalLength,
                OuterTankTotalLength = vm.OuterTankTotalLength,
                InnerVolume = vm.InnerVolume,
                OuterVolume = vm.OuterVolume,
                InnerSurfaceArea = vm.InnerSurfaceArea,
                OuterSurfaceArea = vm.OuterSurfaceArea,
                InnerTankWeight = vm.InnerTankWeight,
                OuterTankWeight = vm.OuterTankWeight,
                PerliteVolume = vm.PerliteVolume,
                PerliteWeight = vm.PerliteWeight,
                GasNitrogenVolume = vm.GasNitrogenVolume,
                LiquidNitrogenVolume = vm.LiquidNitrogenVolume
            };
        }



        private async Task PopulateResultDisplayNamesAsync(EN13458ResultVM vm)
        {
            var materials = await _materialService.GetAllAsync();
            var forms = await _materialFormService.GetAllAsync();
            var storageTypes = await _storageTypeService.GetAllAsync();

            var materialMap = materials.ToDictionary(x => x.Id, x => x.Name);
            var formMap = forms.ToDictionary(
                x => x.Id,
                x => $"{x.FormType} [{x.ThicknessMin}-{x.ThicknessMax}]");
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

            ViewBag.Materials = materials
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            ViewBag.MaterialFormsByMaterial = forms
                .GroupBy(x => x.MaterialId)
                .ToDictionary(
                    g => g.Key.ToString(),
                    g => g.Select(x => new
                    {
                        value = x.Id.ToString(),
                        text = $"{x.FormType} [{x.ThicknessMin}-{x.ThicknessMax}]"
                    }).ToList());

            ViewBag.MaterialForms = forms
                .Select(x => new SelectListItem($"{x.FormType} [{x.ThicknessMin}-{x.ThicknessMax}]", x.Id.ToString()))
                .ToList();

            var storageTypeList = storageTypes.Data ?? new System.Collections.Generic.List<MVC.ProductManagement.Application.DTOs.StorageTypeDTOs.StorageTypeListDTO>();

            ViewBag.StorageTypes = storageTypeList
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            ViewBag.StorageTypeDensities = storageTypeList
                .ToDictionary(x => x.Id.ToString(), x => x.Density);
        }
    }
}
