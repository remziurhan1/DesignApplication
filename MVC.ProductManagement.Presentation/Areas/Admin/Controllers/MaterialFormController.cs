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
            var vms = dtos.Select(f => new MaterialFormListVm
            {
                Id = f.Id,
                MaterialId = f.MaterialId,
                FormType = f.FormType,
                ThicknessMin = f.ThicknessMin,
                ThicknessMax = f.ThicknessMax,
                UnitPrice=f.UnitPrice,
                MaterialName=f.Material.Name,
            }).ToList();

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
                ThicknessMin = dto.ThicknessMin,
                ThicknessMax = dto.ThicknessMax,
                ProductStandard = dto.ProductStandard,
                WeldingFactor = dto.WeldingFactor,
                Notes = dto.Notes
            };

            return View(vm);
        }

        // 📌 Yeni kayıt GET
        public async Task<IActionResult> Create()
        {
            // Tüm malzemeleri dropdown için getir
            var materials = await _materialService.GetAllAsync();
            ViewBag.Materials = new SelectList(materials, "Id", "Name");

            return View(new MaterialFormCreateVm());
        }

        // 📌 Yeni kayıt POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MaterialFormCreateVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var dto = new MaterialFormCreateDto
            {
                MaterialId = vm.MaterialId,
                FormType = vm.FormType,
                ThicknessMin = vm.ThicknessMin,
                ThicknessMax = vm.ThicknessMax,
                ProductStandard = vm.ProductStandard,
                WeldingFactor = vm.WeldingFactor,
                Notes = vm.Notes
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
                ThicknessMin = dto.ThicknessMin,
                ThicknessMax = dto.ThicknessMax,
                ProductStandard = dto.ProductStandard,
                WeldingFactor = dto.WeldingFactor,
                Notes = dto.Notes,
                UnitPrice=dto.UnitPrice
                
            };

            return View(vm);
        }

        // 📌 Güncelleme POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MaterialFormUpdateVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var dto = new MaterialFormUpdateDto
            {
                Id = vm.Id,
                MaterialId = vm.MaterialId,
                FormType = vm.FormType,
                ThicknessMin = vm.ThicknessMin,
                ThicknessMax = vm.ThicknessMax,
                ProductStandard = vm.ProductStandard,
                WeldingFactor = vm.WeldingFactor,
                Notes = vm.Notes,
                UnitPrice = vm.UnitPrice

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
                ThicknessMin = dto.ThicknessMin,
                ThicknessMax = dto.ThicknessMax,
                ProductStandard = dto.ProductStandard,
                WeldingFactor = dto.WeldingFactor,
                Notes = dto.Notes
            };

            return View(vm);
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
