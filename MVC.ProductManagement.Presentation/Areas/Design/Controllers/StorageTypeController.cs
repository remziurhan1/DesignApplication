
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs.StorageTypeDTOs;
using MVC.ProductManagement.Application.Services.StorageTypeServices;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Presentation.Areas.Design.Models.StorageTypeVMs;

namespace MVC.ProductManagement.Presentation.Areas.Design.Controllers
{
    public class StorageTypeController : DesignBaseController
    {
        private readonly IStorageTypeService _storageTypeService;

        public StorageTypeController(IStorageTypeService storageTypeService)
        {
            _storageTypeService = storageTypeService;
        }

        public async Task<IActionResult> Index()
        {
            if (!await HasDesignPermissionAsync(x => x.CanAccessMaterialGroups || x.CanManageMaterials))
            {
                return Forbid();
            }

            var productTypes = await _storageTypeService.GetAllAsync();

            // DTO'yu ViewModel'e dönüştür
            var productTypeListVMs = productTypes.Data.Adapt<List<StorageTypeVM>>();

            return View(productTypeListVMs);
        }
    

     [HttpGet]
        public async Task<IActionResult> Create()
        {
            if (!await HasDesignPermissionAsync(x => x.CanManageMaterials))
            {
                return Forbid();
            }

            return View(new StorageTypeCreateVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StorageTypeCreateVM model)
        {
            if (!await HasDesignPermissionAsync(x => x.CanManageMaterials))
            {
                return Forbid();
            }

            if (!ModelState.IsValid)
                return View(model);

            var createDto = model.Adapt<StorageTypeCreateDTO>();

            await _storageTypeService.CreateAsync(createDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (!await HasDesignPermissionAsync(x => x.CanManageMaterials))
            {
                return Forbid();
            }

            var productType = await _storageTypeService.GetByIdAsync(id);
            if (productType.Data == null)
                return NotFound();

            var editVM = productType.Data.Adapt<StorageTypeUpdateVM>();

            return View(editVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StorageTypeUpdateVM model)
        {
            if (!await HasDesignPermissionAsync(x => x.CanManageMaterials))
            {
                return Forbid();
            }

            if (!ModelState.IsValid)
                return View(model);

            var updateDTO = model.Adapt<StorageTypeUpdateDTO>();

            await _storageTypeService.UpdateAsync(updateDTO);
            return RedirectToAction("Index");
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!await HasDesignPermissionAsync(x => x.CanManageMaterials))
            {
                return Forbid();
            }

            await _storageTypeService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
            if (!await HasDesignPermissionAsync(x => x.CanAccessMaterialGroups || x.CanManageMaterials))
            {
                return Forbid();
            }

            if (id == Guid.Empty)
            {
                TempData["Error"] = "Geçersiz malzeme seçimi.";
                return RedirectToAction("Index");
            }

            var result = await _storageTypeService.GetByIdAsync(id);
            if (!result.IsSuccess || result.Data == null)
            {
                TempData["Error"] = "Malzeme bulunamadı.";
                return RedirectToAction("Index");
            }

            var vm = result.Data.Adapt<StorageTypeVM>();
            return View(vm);
        }


    }

}