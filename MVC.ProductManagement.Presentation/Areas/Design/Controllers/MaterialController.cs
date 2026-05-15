using Microsoft.AspNetCore.Mvc;
using MVC.ProductManagement.Application.DTOs.MaterialDTOs;
using MVC.ProductManagement.Application.Services.MaterialServices;
using MVC.ProductManagement.Presentation.Areas.Design.Models.MaterialVMs;

namespace MVC.ProductManagement.Presentation.Areas.Design.Controllers
{
    public class MaterialController : DesignBaseController
    {
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
                    MaterialNumber = material.MaterialNumber,
                    Density = material.Density,
                    Notes = material.Notes
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
                return View(vm);
            }

            var dto = new MaterialCreateDto
            {
                Name = vm.Name,
                MaterialNumber = vm.MaterialNumber,
                Density = vm.Density,
                Notes = vm.Notes
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
                Notes = dto.Notes
            };


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
                Notes = vm.Notes
            };

            await _materialService.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
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
