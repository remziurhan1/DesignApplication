using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs.EN13458DTOs;
using MVC.ProductManagement.Application.Services.EN13458CalculationServices;
using MVC.ProductManagement.Application.Services.MaterialFormServices;
using MVC.ProductManagement.Application.Services.MaterialServices;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.EN13458CalculationVMs;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    public class EN13458CalculationController : AdminBaseController
    {
        private readonly IEN13458CalculationServices _service;
        private readonly IMaterialService _materialService;
        private readonly IMaterialFormService _materialFormService;

        public EN13458CalculationController(
            IEN13458CalculationServices service,
            IMaterialService materialService,
            IMaterialFormService materialFormService)
        {
            _service = service;
            _materialService = materialService;
            _materialFormService = materialFormService;
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

            return View(new EN13458DetailsVM
            {
                Id = dto.Id,
                Name = dto.Name,
                OuterDiameter = dto.OuterDiameter,
                ShellLength = dto.ShellLength,
                Pressure = dto.Pressure,
                LiquidDensity = dto.LiquidDensity,
                SectorWidth = dto.SectorWidth,
                TankOrientation = dto.TankOrientation,
                IsColdStretchApplied = dto.IsColdStretchApplied,
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
                GasNitrogenVolume = dto.GasNitrogenVolume,
                LiquidNitrogenVolume = dto.LiquidNitrogenVolume
            });
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
                LiquidDensity = 808,
                SectorWidth = 2000,
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

            var dto = new EN13458CalculateDTO
            {
                Name = vm.Name,
                OuterDiameter = vm.OuterDiameter,
                ShellLength = vm.ShellLength,
                Pressure = vm.Pressure,
                LiquidDensity = vm.LiquidDensity,
                SectorWidth = vm.SectorWidth,
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
            return View("Result", MapResultVm(result));
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
                LiquidDensity = dto.LiquidDensity,
                SectorWidth = dto.SectorWidth,
                TankOrientation = dto.TankOrientation,
                IsColdStretchApplied = dto.IsColdStretchApplied,
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
                LiquidDensity = vm.LiquidDensity,
                SectorWidth = vm.SectorWidth,
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
                GasNitrogenVolume = vm.GasNitrogenVolume,
                LiquidNitrogenVolume = vm.LiquidNitrogenVolume
            };
        }

        private async Task LoadLookupsAsync()
        {
            var materials = await _materialService.GetAllAsync();
            var forms = await _materialFormService.GetAllAsync();

            ViewBag.Materials = materials
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            ViewBag.MaterialFormsByMaterial = forms
                .GroupBy(x => x.MaterialId)
                .ToDictionary(
                    g => g.Key.ToString(),
                    g => g.Select(x => new SelectListItem($"{x.FormType} [{x.ThicknessMin}-{x.ThicknessMax}]", x.Id.ToString())).ToList());

            ViewBag.MaterialForms = forms
                .Select(x => new SelectListItem($"{x.FormType} [{x.ThicknessMin}-{x.ThicknessMax}]", x.Id.ToString()))
                .ToList();
        }
    }
}
