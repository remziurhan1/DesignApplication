using Microsoft.AspNetCore.Mvc;
using MVC.ProductManagement.Application.DTOs.MaterialFormDTOs;
using MVC.ProductManagement.Application.DTOs.MaterialDTOs;
using MVC.ProductManagement.Application.Services.MaterialServices;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.MaterialVMs;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.MaterialFormVms;
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
            var vms = new List<MaterialListVm>();

            foreach (var material in dtos)
            {
                vms.Add(new MaterialListVm
                {
                    Id = material.Id,
                    Name = material.Name,
                    ElasticModulus = material.ElasticModulus,
                    YieldFactorK = material.YieldFactorK,
                });
            }

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
                MaterialNumber = dto.MaterialNumber,
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
                MaterialNumber = vm.MaterialNumber,
                Density = vm.Density,
                ColdStretchYieldStrength = vm.ColdStretchYieldStrength,
                ElasticModulus = vm.ElasticModulus,
                YieldFactorK = vm.YieldFactorK,
                Notes = vm.Notes,
                Forms = BuildMaterialFormCreateDtos(vm.Forms)
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
                MaterialNumber = dto.MaterialNumber,
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

            var existing = await _materialService.GetByIdAsync(vm.Id);
            if (existing == null) return NotFound();

            var dto = new MaterialUpdateDto
            {
                Id = vm.Id,
                Name = vm.Name,
                MaterialNumber = vm.MaterialNumber,
                Density = vm.Density,
                ColdStretchYieldStrength = vm.ColdStretchYieldStrength,
                ElasticModulus = vm.ElasticModulus,
                YieldFactorK = vm.YieldFactorK,
                Notes = vm.Notes
            };

            await _materialService.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }


        private static List<MaterialFormCreateDto> BuildMaterialFormCreateDtos(IEnumerable<MaterialFormCreateVm> forms)
        {
            var result = new List<MaterialFormCreateDto>();

            foreach (var form in forms)
            {
                result.Add(new MaterialFormCreateDto
                {
                    FormType = form.FormType,
                    MaterialClass = form.MaterialClass,
                    Norm = form.Norm,
                    SymbolicName = form.SymbolicName,
                    StockCode = form.StockCode,
                    ThicknessMin = form.ThicknessMin,
                    ThicknessMax = form.ThicknessMax,
                    ProductStandard = form.ProductStandard,
                    WeldingFactor = form.WeldingFactor,
                    Notes = form.Notes
                });
            }

            return result;
        }

        private void LoadMaterialSelections()
        {
            var materialGroups = new List<SelectListItem>();
            foreach (var group in MaterialGroups)
            {
                materialGroups.Add(new SelectListItem(group, group));
            }

            var materialNorms = new List<SelectListItem>();
            foreach (var norm in MaterialNorms)
            {
                materialNorms.Add(new SelectListItem(norm, norm));
            }

            ViewBag.MaterialGroups = materialGroups;
            ViewBag.MaterialNorms = materialNorms;

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
                MaterialNumber = dto.MaterialNumber,
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
