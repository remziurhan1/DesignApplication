using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs.MaterialFormDTOs;
using MVC.ProductManagement.Application.Services.MaterialFormServices;
using MVC.ProductManagement.Application.Services.MaterialServices;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.MaterialFormVms;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    public class MaterialFormController : AdminBaseController
    {
        private static readonly string[] MaterialClasses =
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

        private readonly IMaterialFormService _materialFormService;
        private readonly IMaterialService _materialService;

        public MaterialFormController(IMaterialFormService materialFormService, IMaterialService materialService)
        {
            _materialFormService = materialFormService;
            _materialService = materialService;
        }

        // 📌 Liste
        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var dtos = await _materialFormService.GetAllWithMaterialAsync(); // ✅ Servis tüm formları getirecek
            var vms = new List<MaterialFormListVm>();

            foreach (var form in dtos)
            {
                vms.Add(new MaterialFormListVm
                {
                    Id = form.Id,
                    MaterialId = form.MaterialId,
                    FormType = form.FormType,
                    MaterialClass = form.MaterialClass,
                    Norm = form.Norm,
                    SymbolicName = form.SymbolicName,
                    StockCode = form.StockCode,
                    ThicknessMin = form.ThicknessMin,
                    ThicknessMax = form.ThicknessMax,
                    UnitPrice = form.UnitPrice,
                    TargetPrice = form.TargetPrice,
                    ColdStretchYieldStrength = form.ColdStretchYieldStrength,
                    ElasticModulus = form.ElasticModulus,
                    YieldFactorK = form.YieldFactorK,
                    MaterialName = form.MaterialName,
                });
            }

            return View(vms);
        }


        // 📌 Detay
        [HttpGet]

        public async Task<IActionResult> Details(Guid id)
        {
            var dto = await _materialFormService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var vm = new MaterialFormDetailVm
            {
                Id = dto.Id,
                MaterialId = dto.MaterialId,
                FormType = dto.FormType,
                MaterialClass = dto.MaterialClass,
                Norm = dto.Norm,
                SymbolicName = dto.SymbolicName,
                StockCode = dto.StockCode,
                ThicknessMin = dto.ThicknessMin,
                ThicknessMax = dto.ThicknessMax,
                ProductStandard = dto.ProductStandard,
                WeldingFactor = dto.WeldingFactor,
                Notes = dto.Notes,
                UnitPrice = dto.UnitPrice,
                TargetPrice = dto.TargetPrice,
                ColdStretchYieldStrength = dto.ColdStretchYieldStrength,
                ElasticModulus = dto.ElasticModulus,
                YieldFactorK = dto.YieldFactorK
            };

            return View(vm);
        }

        // 📌 Yeni kayıt GET
        public async Task<IActionResult> Create()
        {
            // Tüm malzemeleri dropdown için getir
            var materials = await _materialService.GetAllAsync();
            ViewBag.Materials = new SelectList(materials, "Id", "Name");
            LoadMaterialFormSelections();

            return View(new MaterialFormCreateVm());
        }

        // 📌 Yeni kayıt POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MaterialFormCreateVm vm)
        {
            if (!ModelState.IsValid)
            {
                var materials = await _materialService.GetAllAsync();
                ViewBag.Materials = new SelectList(materials, "Id", "Name", vm.MaterialId);
                LoadMaterialFormSelections();
                return View(vm);
            }

            var dto = new MaterialFormCreateDto
            {
                MaterialId = vm.MaterialId,
                FormType = vm.FormType,
                MaterialClass = vm.MaterialClass,
                Norm = vm.Norm,
                SymbolicName = vm.SymbolicName,
                StockCode = vm.StockCode,
                ThicknessMin = vm.ThicknessMin,
                ThicknessMax = vm.ThicknessMax,
                ProductStandard = vm.ProductStandard,
                WeldingFactor = vm.WeldingFactor,
                Notes = vm.Notes,
                UnitPrice = vm.UnitPrice,
                TargetPrice = vm.TargetPrice,
                ColdStretchYieldStrength = vm.ColdStretchYieldStrength,
                ElasticModulus = vm.ElasticModulus,
                YieldFactorK = vm.YieldFactorK
            };

            await _materialFormService.CreateAsync(dto);
            return RedirectToAction(nameof(Index), new { materialId = vm.MaterialId });
        }

        // 📌 Güncelleme GET
        

        public async Task<IActionResult> Edit(Guid id)
        {
            var dto = await _materialFormService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var vm = new MaterialFormUpdateVm
            {
                Id = dto.Id,
                MaterialId = dto.MaterialId,
                FormType = dto.FormType,
                MaterialClass = dto.MaterialClass,
                Norm = dto.Norm,
                SymbolicName = dto.SymbolicName,
                StockCode = dto.StockCode,
                ThicknessMin = dto.ThicknessMin,
                ThicknessMax = dto.ThicknessMax,
                ProductStandard = dto.ProductStandard,
                WeldingFactor = dto.WeldingFactor,
                Notes = dto.Notes,
                UnitPrice=dto.UnitPrice,
                TargetPrice=dto.TargetPrice,
                ColdStretchYieldStrength = dto.ColdStretchYieldStrength,
                ElasticModulus = dto.ElasticModulus,
                YieldFactorK = dto.YieldFactorK
                
            };

            var materials = await _materialService.GetAllAsync();
            ViewBag.Materials = new SelectList(materials, "Id", "Name", vm.MaterialId);
            LoadMaterialFormSelections();
            return View(vm);
        }

        // 📌 Güncelleme POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MaterialFormUpdateVm vm)
        {
            if (!ModelState.IsValid)
            {
                var materials = await _materialService.GetAllAsync();
                ViewBag.Materials = new SelectList(materials, "Id", "Name", vm.MaterialId);
                LoadMaterialFormSelections();
                return View(vm);
            }

            var dto = new MaterialFormUpdateDto
            {
                Id = vm.Id,
                MaterialId = vm.MaterialId,
                FormType = vm.FormType,
                MaterialClass = vm.MaterialClass,
                Norm = vm.Norm,
                SymbolicName = vm.SymbolicName,
                StockCode = vm.StockCode,
                ThicknessMin = vm.ThicknessMin,
                ThicknessMax = vm.ThicknessMax,
                ProductStandard = vm.ProductStandard,
                WeldingFactor = vm.WeldingFactor,
                Notes = vm.Notes,
                UnitPrice = vm.UnitPrice,
                TargetPrice = vm.TargetPrice,
                ColdStretchYieldStrength = vm.ColdStretchYieldStrength,
                ElasticModulus = vm.ElasticModulus,
                YieldFactorK = vm.YieldFactorK

            };

            await _materialFormService.UpdateAsync(dto);
            return RedirectToAction(nameof(Index), new { materialId = vm.MaterialId });
        }

        // 📌 Silme GET
        public async Task<IActionResult> Delete(Guid id)
        {
            var dto = await _materialFormService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var vm = new MaterialFormDetailVm
            {
                Id = dto.Id,
                MaterialId = dto.MaterialId,
                FormType = dto.FormType,
                MaterialClass = dto.MaterialClass,
                Norm = dto.Norm,
                SymbolicName = dto.SymbolicName,
                StockCode = dto.StockCode,
                ThicknessMin = dto.ThicknessMin,
                ThicknessMax = dto.ThicknessMax,
                ProductStandard = dto.ProductStandard,
                WeldingFactor = dto.WeldingFactor,
                Notes = dto.Notes,
                UnitPrice = dto.UnitPrice,
                TargetPrice = dto.TargetPrice,
                ColdStretchYieldStrength = dto.ColdStretchYieldStrength,
                ElasticModulus = dto.ElasticModulus,
                YieldFactorK = dto.YieldFactorK
            };

            return View(vm);
        }

        private void LoadMaterialFormSelections()
        {
            var materialClasses = new List<SelectListItem>();
            foreach (var materialClass in MaterialClasses)
            {
                materialClasses.Add(new SelectListItem(materialClass, materialClass));
            }

            var materialNorms = new List<SelectListItem>();
            foreach (var norm in MaterialNorms)
            {
                materialNorms.Add(new SelectListItem(norm, norm));
            }

            ViewBag.MaterialClasses = materialClasses;
            ViewBag.MaterialNorms = materialNorms;
        }

        // 📌 Silme POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, Guid materialId)
        {
            await _materialFormService.DeleteAsync(id);
            return RedirectToAction(nameof(Index), new { materialId });
        }
    }
}
