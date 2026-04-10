using Microsoft.AspNetCore.Mvc;
using MVC.ProductManagement.Application.DTOs.MaterialDTOs;
using MVC.ProductManagement.Application.DTOs.MaterialFormDTOs;
using MVC.ProductManagement.Application.Services.MaterialServices;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.MaterialVMs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    public class MaterialController : AdminBaseController
    {
        private static readonly string[] MaterialGroups =
        {
            "Carbon Steel",
            "Alloy Steel",
            "Alluminum Alloy",
            "Carbon Low Alloy",
            "Copper Alloy",
            "Nickel Alloy",
            "Stainless Steel",
            "Titanium - Zirconium"
        };

        private static readonly string[] MaterialOrigins =
        {
            "Plate",
            "Forging",
            "Welded Tube",
            "Seamless Tube",
            "Seamless Pipe",
            "Welded Pipe",
            "Cast Steel",
            "Fitting",
            "Bolting",
            "Bar"
        };

        private static readonly string[] MaterialNorms =
        {
            "ASME II",
            "ASTM",
            "EN10025",
            "EN10028-2",
            "EN10028-3",
            "EN10028-4",
            "EN10028-5",
            "EN10028-6",
            "EN10028-7"
        };

        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        // 📌 Liste
        public async Task<IActionResult> Index()
        {
            if (!await HasDesignPermissionAsync(x => x.CanAccessMaterialGroups || x.CanManageMaterials))
            {
                return Forbid();
            }

            var dtos = await _materialService.GetAllAsync();
            var vms = dtos.Select(m => new MaterialListVm
            {
                Id = m.Id,
                Name = m.Name,
                Standard = m.Standard,
                Group = m.Group,
                ElasticModulus = m.ElasticModulus,
                YieldFactorK = m.YieldFactorK,
            }).ToList();

            return View(vms);
        }

        // 📌 Detay
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            if (!await HasDesignPermissionAsync(x => x.CanAccessMaterialGroups || x.CanManageMaterials))
            {
                return Forbid();
            }

            var dto = await _materialService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var vm = new MaterialDetailVm
            {
                Id = dto.Id,
                Name = dto.Name,
                SymbolicName = dto.SymbolicName,
                MaterialNumber = dto.MaterialNumber,
                Standard = dto.Standard,
                Origin = dto.Origin,
                Group = dto.Group,
                Norm = dto.Norm,
                StockCode = dto.StockCode,
                Density = dto.Density,
                ColdStretchYieldStrength = dto.ColdStretchYieldStrength,
                ElasticModulus = dto.ElasticModulus,
                YieldFactorK = dto.YieldFactorK,
                Notes = dto.Notes
            };

            return View(vm);
        }

        // 📌 Yeni kayıt GET
        public async Task<IActionResult> Create()
        {
            if (!await HasDesignPermissionAsync(x => x.CanManageMaterials))
            {
                return Forbid();
            }

            LoadMaterialSelections();
            return View();
        }

        // 📌 Yeni kayıt POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MaterialCreateVm vm)
        {
            if (!await HasDesignPermissionAsync(x => x.CanManageMaterials))
            {
                return Forbid();
            }

            if (!ModelState.IsValid)
            {
                LoadMaterialSelections();
                return View(vm);
            }

            var dto = new MaterialCreateDto
            {
                Name = vm.Name,
                SymbolicName = vm.SymbolicName,
                MaterialNumber = vm.MaterialNumber,
                Standard = vm.Standard,
                Origin = vm.Origin,
                Group = vm.Group,
                Norm = vm.Norm,
                StockCode = vm.StockCode,
                Density = vm.Density,
                ColdStretchYieldStrength = vm.ColdStretchYieldStrength,
                ElasticModulus = vm.ElasticModulus,
                YieldFactorK = vm.YieldFactorK,
                Notes = vm.Notes,
                Forms = vm.Forms.Select(f => new MaterialFormCreateDto
                {
                    FormType = f.FormType,
                    ThicknessMin = f.ThicknessMin,
                    ThicknessMax = f.ThicknessMax,
                    ProductStandard = f.ProductStandard,
                    WeldingFactor = f.WeldingFactor,
                    Notes = f.Notes
                }).ToList()
            };

            await _materialService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        // 📌 Güncelleme GET
        public async Task<IActionResult> Edit(Guid id)
        {
            if (!await HasDesignPermissionAsync(x => x.CanManageMaterials))
            {
                return Forbid();
            }

            var dto = await _materialService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var vm = new MaterialUpdateVm
            {
                Id = dto.Id,
                Name = dto.Name,
                SymbolicName = dto.SymbolicName,
                MaterialNumber = dto.MaterialNumber,
                Standard = dto.Standard,
                Origin = dto.Origin,
                Group = dto.Group,
                Norm = dto.Norm,
                StockCode = dto.StockCode,
                Density = dto.Density,
                ColdStretchYieldStrength = dto.ColdStretchYieldStrength,
                ElasticModulus = dto.ElasticModulus,
                YieldFactorK = dto.YieldFactorK,
                Notes = dto.Notes
            };

            LoadMaterialSelections();

            return View(vm);
        }

        // 📌 Güncelleme POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MaterialUpdateVm vm)
        {
            if (!await HasDesignPermissionAsync(x => x.CanManageMaterials))
            {
                return Forbid();
            }

            if (!ModelState.IsValid)
            {
                LoadMaterialSelections();
                return View(vm);
            }

            var dto = new MaterialUpdateDto
            {
                Id = vm.Id,
                Name = vm.Name,
                SymbolicName = vm.SymbolicName,
                MaterialNumber = vm.MaterialNumber,
                Standard = vm.Standard,
                Origin = vm.Origin,
                Group = vm.Group,
                Norm = vm.Norm,
                StockCode = vm.StockCode,
                Density = vm.Density,
                ColdStretchYieldStrength = vm.ColdStretchYieldStrength,
                ElasticModulus = vm.ElasticModulus,
                YieldFactorK = vm.YieldFactorK,
                Notes = vm.Notes
            };

            await _materialService.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        private void LoadMaterialSelections()
        {
            ViewBag.MaterialGroups = MaterialGroups
                .Select(group => new SelectListItem(group, group))
                .ToList();

            ViewBag.MaterialOrigins = MaterialOrigins
                .Select(origin => new SelectListItem(origin, origin))
                .ToList();

            ViewBag.MaterialNorms = MaterialNorms
                .Select(norm => new SelectListItem(norm, norm))
                .ToList();
        }

        // 📌 Silme GET
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!await HasDesignPermissionAsync(x => x.CanManageMaterials))
            {
                return Forbid();
            }

            var dto = await _materialService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var vm = new MaterialDetailVm
            {
                Id = dto.Id,
                Name = dto.Name,
                SymbolicName = dto.SymbolicName,
                MaterialNumber = dto.MaterialNumber,
                Standard = dto.Standard,
                Origin = dto.Origin,
                Group = dto.Group,
                Norm = dto.Norm,
                StockCode = dto.StockCode,
                Density = dto.Density,
                ColdStretchYieldStrength = dto.ColdStretchYieldStrength,
                ElasticModulus = dto.ElasticModulus,
                YieldFactorK = dto.YieldFactorK,
                Notes = dto.Notes
            };

            return View(vm);
        }

        // 📌 Silme POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (!await HasDesignPermissionAsync(x => x.CanManageMaterials))
            {
                return Forbid();
            }

            await _materialService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
