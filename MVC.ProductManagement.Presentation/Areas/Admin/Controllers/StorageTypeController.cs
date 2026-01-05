
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs.StorageTypeDTOs;
using MVC.ProductManagement.Application.Services.StorageTypeServices;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.StorageTypeVMs;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    public class StorageTypeController : AdminBaseController
    {
        private readonly IStorageTypeService _storageTypeService;

        public StorageTypeController(IStorageTypeService storageTypeService)
        {
            _storageTypeService = storageTypeService;
        }

        public async Task<IActionResult> Index()
        {

            var productTypes = await _storageTypeService.GetAllAsync();

            // DTO'yu ViewModel'e dönüştür
            var productTypeListVMs = productTypes.Data.Adapt<List<StorageTypeVM>>();

            return View(productTypeListVMs);
        }
    

     [HttpGet]
        public IActionResult Create()
        {
            return View(new StorageTypeCreateVM());
        }

        [HttpPost]
        public async Task<IActionResult> Create(StorageTypeCreateVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var createDto = model.Adapt<StorageTypeCreateDTO>();

            await _storageTypeService.AddAsync(createDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var productType = await _storageTypeService.GetByIdAsync(id);
            if (productType.Data == null)
                return NotFound();

            var editVM = productType.Data.Adapt<StorageTypeUpdateVM>();

            return View(editVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StorageTypeVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var updateDTO = model.Adapt<StorageTypeUpdateDTO>();

            await _storageTypeService.UpdateAsync(updateDTO);
            return RedirectToAction("Index");
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _storageTypeService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
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