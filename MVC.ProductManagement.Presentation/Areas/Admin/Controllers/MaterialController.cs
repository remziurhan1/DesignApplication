using Microsoft.AspNetCore.Mvc;
using MVC.ProductManagement.Application.DTOs.MaterialDTOs;
using MVC.ProductManagement.Application.DTOs.MaterialFormDTOs;
using MVC.ProductManagement.Application.Services.MaterialServices;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.MaterialVMs;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    public class MaterialController : AdminBaseController
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        // 📌 Liste
        public async Task<IActionResult> Index()
        {
            var dtos = await _materialService.GetAllAsync();
            var vms = dtos.Select(m => new MaterialListVm
            {
                Id = m.Id,
                Name = m.Name,
                Standard = m.Standard,
                Group = m.Group
            }).ToList();

            return View(vms);
        }

        // 📌 Detay
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var dto = await _materialService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var vm = new MaterialDetailVm
            {
                Id = dto.Id,
                Name = dto.Name,
                MaterialNumber = dto.MaterialNumber,
                Standard = dto.Standard,
                Group = dto.Group,
                Density = dto.Density,
                Notes = dto.Notes
            };

            return View(vm);
        }

        // 📌 Yeni kayıt GET
        public IActionResult Create() => View();

        // 📌 Yeni kayıt POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MaterialCreateVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var dto = new MaterialCreateDto
            {
                Name = vm.Name,
                MaterialNumber = vm.MaterialNumber,
                Standard = vm.Standard,
                Group = vm.Group,
                Density = vm.Density,
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
            var dto = await _materialService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var vm = new MaterialUpdateVm
            {
                Id = dto.Id,
                Name = dto.Name,
                MaterialNumber = dto.MaterialNumber,
                Standard = dto.Standard,
                Group = dto.Group,
                Density = dto.Density,
                Notes = dto.Notes
            };

            return View(vm);
        }

        // 📌 Güncelleme POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MaterialUpdateVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var dto = new MaterialUpdateDto
            {
                Id = vm.Id,
                Name = vm.Name,
                MaterialNumber = vm.MaterialNumber,
                Standard = vm.Standard,
                Group = vm.Group,
                Density = vm.Density,
                Notes = vm.Notes
            };

            await _materialService.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        // 📌 Silme GET
        public async Task<IActionResult> Delete(Guid id)
        {
            var dto = await _materialService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var vm = new MaterialDetailVm
            {
                Id = dto.Id,
                Name = dto.Name,
                MaterialNumber = dto.MaterialNumber,
                Standard = dto.Standard,
                Group = dto.Group,
                Density = dto.Density,
                Notes = dto.Notes
            };

            return View(vm);
        }

        // 📌 Silme POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _materialService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
