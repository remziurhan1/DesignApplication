using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using MVC.ProductManagement.Application.DTOs.AD2000DTOs;
using MVC.ProductManagement.Application.Services.AD2000CalculationServices;
using MVC.ProductManagement.Application.Services.MaterialFormServices;
using MVC.ProductManagement.Application.Services.MaterialServices;
using MVC.ProductManagement.Application.DTOs.MaterialDTOs;
using MVC.ProductManagement.Application.DTOs.MaterialFormDTOs;
using MVC.ProductManagement.Application.Services.IYieldStrengthServices;
using MVC.ProductManagement.Application.Services.StorageTypeServices;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.AD2000CalculationVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    public class AD2000CalculationController : AdminBaseController
    {
        private readonly IAD2000CalculationService _calculationService;
        private readonly IMaterialService _materialService;
        private readonly IMaterialFormService _materialFormService;
        private readonly IYieldStrengthService _yieldStrengthService;
        private readonly IStorageTypeService _storageTypeService;

        public AD2000CalculationController(
            IAD2000CalculationService calculationService,
            IMaterialService materialService,
            IMaterialFormService materialFormService,
            IYieldStrengthService yieldStrengthService,
            IStorageTypeService storageTypeService)
        {
            _calculationService = calculationService;
            _materialService = materialService;
            _materialFormService = materialFormService;
            _yieldStrengthService = yieldStrengthService;
            _storageTypeService = storageTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await _calculationService.GetAllAsync() ?? new List<AD2000ResultDTO>();
            var vm = list.Select(x => new AD2000ListVM
            {
                Id = x.Id,
                Name = x.Name,
                DesignPressure = x.DesignPressure,
                RoundedShellThickness = x.RoundedShellThickness,
                RoundedHeadThickness = x.RoundedHeadThickness
            }).ToList();

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var dto = await _calculationService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var vm = MapResultVm(dto);
            await PopulateDisplayNamesAsync(vm);
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Cost(Guid id)
        {
            var dto = await _calculationService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var vm = MapResultVm(dto);
            await PopulateDisplayNamesAsync(vm);
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Calculate()
        {
            await LoadLookupsAsync();
            return View(new AD2000CalculateVM
            {
                TankOrientation = TankOrientation.Horizontal,
                IsManualDensity = false
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Calculate(AD2000CalculateVM vm)
        {
            if (!ModelState.IsValid)
            {
                await LoadLookupsAsync();
                return View(vm);
            }

            if (vm.IsManualDensity)
            {
                if (vm.LiquidDensity <= 0)
                {
                    ModelState.AddModelError(nameof(vm.LiquidDensity), "Yoğunluk değeri 0'dan büyük olmalıdır.");
                }
            }
            else
            {
                if (!vm.StorageTypeId.HasValue || vm.StorageTypeId.Value == Guid.Empty)
                {
                    ModelState.AddModelError(nameof(vm.StorageTypeId), "Tanımlı sıvı seçiniz veya manuel yoğunluk seçeneğini işaretleyiniz.");
                }
                else
                {
                    try
                    {
                        vm.LiquidDensity = await ResolveLiquidDensityAsync(vm.StorageTypeId.Value);
                    }
                    catch (InvalidOperationException ex)
                    {
                        ModelState.AddModelError(nameof(vm.StorageTypeId), ex.Message);
                    }
                }
            }

            var shellYield = await _yieldStrengthService.GetByConditionsAsync(
                vm.ShellMaterialFormId,
                vm.DesignTemperatureMax,
                vm.EstimatedShellThickness);

            var headYield = await _yieldStrengthService.GetByConditionsAsync(
                vm.HeadMaterialFormId,
                vm.DesignTemperatureMax,
                vm.EstimatedHeadThickness);

            if (shellYield == null)
            {
                ModelState.AddModelError(nameof(vm.EstimatedShellThickness), "Gövde için girilen sıcaklık/kalınlıkta akma dayanımı bulunamadı.");
            }

            if (headYield == null)
            {
                ModelState.AddModelError(nameof(vm.EstimatedHeadThickness), "Bombe için girilen sıcaklık/kalınlıkta akma dayanımı bulunamadı.");
            }

            if (!ModelState.IsValid)
            {
                await LoadLookupsAsync();
                return View(vm);
            }

            vm.ShellAllowableStress = shellYield!.Rp02;
            vm.HeadAllowableStress = headYield!.Rp02;
            vm.AllowableStress = vm.ShellAllowableStress;

            var result = await _calculationService.CalculateAsync(new AD2000CalculateDTO
            {
                Name = vm.Name,
                Diameter = vm.Diameter,
                ShellLength = vm.ShellLength,
                DesignPressure = vm.DesignPressure,
                DesignTemperatureMin = vm.DesignTemperatureMin,
                DesignTemperatureMax = vm.DesignTemperatureMax,
                CorrosionAllowance = vm.CorrosionAllowance,
                WeldJointFactor = vm.WeldJointFactor,
                AllowableStress = vm.AllowableStress,
                ShellAllowableStress = vm.ShellAllowableStress,
                HeadAllowableStress = vm.HeadAllowableStress,
                EstimatedShellThickness = vm.EstimatedShellThickness,
                EstimatedHeadThickness = vm.EstimatedHeadThickness,
                Beta = vm.Beta,
                TankOrientation = vm.TankOrientation,
                StorageTypeId = vm.StorageTypeId,
                IsManualDensity = vm.IsManualDensity,
                LiquidDensity = vm.LiquidDensity,
                StaticPressure = vm.StaticPressure,
                ShellMaterialId = vm.ShellMaterialId,
                ShellMaterialFormId = vm.ShellMaterialFormId,
                HeadMaterialId = vm.HeadMaterialId,
                HeadMaterialFormId = vm.HeadMaterialFormId,
                WeldLength1500 = vm.WeldLength1500,
                WeldLength2000 = vm.WeldLength2000,
                WeldLength3000 = vm.WeldLength3000,
                WeldLength4000 = vm.WeldLength4000,
                SurfaceArea = vm.SurfaceArea
            });

            var resultVm = MapResultVm(result);
            await PopulateDisplayNamesAsync(resultVm);
            return View("Result", resultVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(AD2000ResultVM vm)
        {
            var dto = new AD2000ResultDTO
            {
                Id = vm.Id,
                Name = vm.Name,
                Diameter = vm.Diameter,
                ShellLength = vm.ShellLength,
                DesignPressure = vm.DesignPressure,
                DesignTemperatureMin = vm.DesignTemperatureMin,
                DesignTemperatureMax = vm.DesignTemperatureMax,
                CorrosionAllowance = vm.CorrosionAllowance,
                WeldJointFactor = vm.WeldJointFactor,
                AllowableStress = vm.AllowableStress,
                ShellAllowableStress = vm.ShellAllowableStress,
                HeadAllowableStress = vm.HeadAllowableStress,
                EstimatedShellThickness = vm.EstimatedShellThickness,
                EstimatedHeadThickness = vm.EstimatedHeadThickness,
                Beta = vm.Beta,
                TankOrientation = vm.TankOrientation,
                StorageTypeId = vm.StorageTypeId,
                IsManualDensity = vm.IsManualDensity,
                LiquidDensity = vm.LiquidDensity,
                StaticPressure = vm.StaticPressure,
                ShellMaterialId = vm.ShellMaterialId,
                ShellMaterialFormId = vm.ShellMaterialFormId,
                HeadMaterialId = vm.HeadMaterialId,
                HeadMaterialFormId = vm.HeadMaterialFormId,
                ShellThickness = vm.ShellThickness,
                HeadThickness = vm.HeadThickness,
                RoundedShellThickness = vm.RoundedShellThickness,
                RoundedHeadThickness = vm.RoundedHeadThickness,
                TestPressure = vm.TestPressure,
                WeldLength1500 = vm.WeldLength1500,
                WeldLength2000 = vm.WeldLength2000,
                WeldLength3000 = vm.WeldLength3000,
                WeldLength4000 = vm.WeldLength4000,
                SurfaceArea = vm.SurfaceArea
            };

            var saved = await _calculationService.SaveAsync(dto, User?.Identity?.Name ?? "AdminUser");
            return RedirectToAction(nameof(Details), new { id = saved.Id });
        }

        private static AD2000ResultVM MapResultVm(AD2000ResultDTO result) => new AD2000ResultVM
        {
            Id = result.Id,
            Name = result.Name,
            Diameter = result.Diameter,
            ShellLength = result.ShellLength,
            DesignPressure = result.DesignPressure,
            DesignTemperatureMin = result.DesignTemperatureMin,
            DesignTemperatureMax = result.DesignTemperatureMax,
            CorrosionAllowance = result.CorrosionAllowance,
            WeldJointFactor = result.WeldJointFactor,
            AllowableStress = result.AllowableStress,
            ShellAllowableStress = result.ShellAllowableStress,
            HeadAllowableStress = result.HeadAllowableStress,
            EstimatedShellThickness = result.EstimatedShellThickness,
            EstimatedHeadThickness = result.EstimatedHeadThickness,
            Beta = result.Beta,
            TankOrientation = result.TankOrientation,
            StorageTypeId = result.StorageTypeId,
            IsManualDensity = result.IsManualDensity,
            LiquidDensity = result.LiquidDensity,
            StaticPressure = result.StaticPressure,
            ShellMaterialId = result.ShellMaterialId,
            ShellMaterialFormId = result.ShellMaterialFormId,
            HeadMaterialId = result.HeadMaterialId,
            HeadMaterialFormId = result.HeadMaterialFormId,
            ShellThickness = result.ShellThickness,
            HeadThickness = result.HeadThickness,
            RoundedShellThickness = result.RoundedShellThickness,
            RoundedHeadThickness = result.RoundedHeadThickness,
            TestPressure = result.TestPressure,
            WeldLength1500 = result.WeldLength1500,
            WeldLength2000 = result.WeldLength2000,
            WeldLength3000 = result.WeldLength3000,
            WeldLength4000 = result.WeldLength4000,
            SurfaceArea = result.SurfaceArea
        };

        private async Task PopulateDisplayNamesAsync(AD2000ResultVM vm)
        {
            var materials = await _materialService.GetAllAsync() ?? new List<MaterialListDto>();
            var materialForms = await _materialFormService.GetAllAsync() ?? new List<MaterialFormListDto>();
            var storageTypes = await _storageTypeService.GetAllAsync();
            var storageTypeList = storageTypes.Data ?? new List<MVC.ProductManagement.Application.DTOs.StorageTypeDTOs.StorageTypeListDTO>();

            vm.StorageTypeName = vm.StorageTypeId.HasValue
                ? storageTypeList.FirstOrDefault(x => x.Id == vm.StorageTypeId.Value)?.Name ?? string.Empty
                : string.Empty;

            vm.ShellMaterialName = materials.FirstOrDefault(x => x.Id == vm.ShellMaterialId)?.Name ?? string.Empty;
            vm.HeadMaterialName = materials.FirstOrDefault(x => x.Id == vm.HeadMaterialId)?.Name ?? string.Empty;
            vm.ShellMaterialFormName = materialForms.FirstOrDefault(x => x.Id == vm.ShellMaterialFormId)?.FormType.ToString() ?? string.Empty;
            vm.HeadMaterialFormName = materialForms.FirstOrDefault(x => x.Id == vm.HeadMaterialFormId)?.FormType.ToString() ?? string.Empty;
        }

        private async Task<double> ResolveLiquidDensityAsync(Guid storageTypeId)
        {
            var storageType = await _storageTypeService.GetByIdAsync(storageTypeId);

            if (storageType?.Data == null || storageType.Data.Density <= 0)
            {
                throw new InvalidOperationException("Seçilen sıvı için geçerli yoğunluk değeri bulunamadı.");
            }

            return storageType.Data.Density;
        }

        private async Task LoadLookupsAsync()
        {
            var materials = await _materialService.GetAllAsync() ?? new List<MaterialListDto>();
            var materialForms = await _materialFormService.GetAllAsync() ?? new List<MaterialFormListDto>();
            var storageTypes = await _storageTypeService.GetAllAsync();

            ViewBag.Materials = new SelectList(materials, "Id", "Name");
            ViewBag.MaterialGroups = materials
                .Select(x => (x.Group ?? string.Empty).Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(x => x)
                .Select(x => new SelectListItem(x, x))
                .ToList();

            ViewBag.MaterialsByGroup = materials
                .Where(x => !string.IsNullOrWhiteSpace(x.Group))
                .GroupBy(x => x.Group.Trim(), StringComparer.OrdinalIgnoreCase)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(x => new { value = x.Id.ToString(), text = x.Name }).ToList(),
                    StringComparer.OrdinalIgnoreCase);

            ViewBag.MaterialForms = new SelectList(materialForms, "Id", "FormType");
            ViewBag.MaterialFormsByMaterial = materialForms
                .GroupBy(x => x.MaterialId)
                .ToDictionary(
                    g => g.Key.ToString(),
                    g => g.Select(x => new { value = x.Id.ToString(), text = $"{x.FormType} [{x.ThicknessMin.ToString("0.###", CultureInfo.InvariantCulture)}-{x.ThicknessMax.ToString("0.###", CultureInfo.InvariantCulture)}]", formType = x.FormType.ToString() }).ToList());

            ViewBag.MaterialFormTypesByMaterial = materialForms
                .GroupBy(x => x.MaterialId)
                .ToDictionary(
                    g => g.Key.ToString(),
                    g => g.Select(x => x.FormType.ToString()).Distinct().OrderBy(x => x).ToList());

            var storageTypeList = storageTypes.Data ?? new List<MVC.ProductManagement.Application.DTOs.StorageTypeDTOs.StorageTypeListDTO>();
            ViewBag.StorageTypes = storageTypeList
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            ViewBag.StorageTypeDensities = storageTypeList
                .ToDictionary(x => x.Id.ToString(), x => x.Density);
        }
    }
}
