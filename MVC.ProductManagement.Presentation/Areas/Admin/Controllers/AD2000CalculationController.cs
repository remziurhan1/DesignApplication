using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs.AD2000DTOs;
using MVC.ProductManagement.Application.Services.AD2000CalculationServices;
using MVC.ProductManagement.Application.Services.MaterialFormServices;
using MVC.ProductManagement.Application.Services.MaterialServices;
using MVC.ProductManagement.Application.DTOs.MaterialDTOs;
using MVC.ProductManagement.Application.DTOs.MaterialFormDTOs;
using MVC.ProductManagement.Application.Services.IYieldStrengthServices;
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

        public AD2000CalculationController(
            IAD2000CalculationService calculationService,
            IMaterialService materialService,
            IMaterialFormService materialFormService,
            IYieldStrengthService yieldStrengthService)
        {
            _calculationService = calculationService;
            _materialService = materialService;
            _materialFormService = materialFormService;
            _yieldStrengthService = yieldStrengthService;
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

            return View(MapResultVm(dto));
        }

        [HttpGet]
        public async Task<IActionResult> Calculate()
        {
            await LoadLookupsAsync();
            return View(new AD2000CalculateVM());
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

            vm.AllowableStress = Math.Min(shellYield!.Rp02, headYield!.Rp02);

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
                Beta = vm.Beta,
                ShellMaterialId = vm.ShellMaterialId,
                ShellMaterialFormId = vm.ShellMaterialFormId,
                HeadMaterialId = vm.HeadMaterialId,
                HeadMaterialFormId = vm.HeadMaterialFormId
            });

            return View("Result", MapResultVm(result));
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
                Beta = vm.Beta,
                ShellMaterialId = vm.ShellMaterialId,
                ShellMaterialFormId = vm.ShellMaterialFormId,
                HeadMaterialId = vm.HeadMaterialId,
                HeadMaterialFormId = vm.HeadMaterialFormId,
                ShellThickness = vm.ShellThickness,
                HeadThickness = vm.HeadThickness,
                RoundedShellThickness = vm.RoundedShellThickness,
                RoundedHeadThickness = vm.RoundedHeadThickness,
                TestPressure = vm.TestPressure
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
            Beta = result.Beta,
            ShellMaterialId = result.ShellMaterialId,
            ShellMaterialFormId = result.ShellMaterialFormId,
            HeadMaterialId = result.HeadMaterialId,
            HeadMaterialFormId = result.HeadMaterialFormId,
            ShellThickness = result.ShellThickness,
            HeadThickness = result.HeadThickness,
            RoundedShellThickness = result.RoundedShellThickness,
            RoundedHeadThickness = result.RoundedHeadThickness,
            TestPressure = result.TestPressure
        };

        private async Task LoadLookupsAsync()
        {
            var materials = await _materialService.GetAllAsync() ?? new List<MaterialListDto>();
            var materialForms = await _materialFormService.GetAllAsync() ?? new List<MaterialFormListDto>();

            ViewBag.Materials = new SelectList(materials, "Id", "Name");
            ViewBag.MaterialForms = new SelectList(materialForms, "Id", "FormType");

            ViewBag.MaterialFormsByMaterial = materialForms
                .GroupBy(x => x.MaterialId)
                .ToDictionary(
                    g => g.Key.ToString(),
                    g => g.Select(x => new { value = x.Id, text = x.FormType.ToString() }).ToList());
        }
    }
}
