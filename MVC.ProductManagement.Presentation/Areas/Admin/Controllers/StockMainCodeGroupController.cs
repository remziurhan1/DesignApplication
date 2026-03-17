using Microsoft.AspNetCore.Mvc;
using MVC.ProductManagement.Application.DTOs.StockCodes.Catalog;
using MVC.ProductManagement.Application.Services.StockCodes.Catalog;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.Catalog;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    public class StockMainCodeGroupController : AdminBaseController
    {
        private readonly IStockMainCodeGroupService _service;

        public StockMainCodeGroupController(IStockMainCodeGroupService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index() => View(await _service.GetAllAsync());

        public IActionResult Create() => View(new StockMainCodeGroupVm());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StockMainCodeGroupVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            await _service.CreateAsync(new StockMainCodeGroupCreateDto
            {
                Code = vm.Code,
                Name = vm.Name,
                IsEnabled = vm.IsEnabled
            });
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();
            return View(new StockMainCodeGroupVm { Id = dto.Id, Code = dto.Code, Name = dto.Name, IsEnabled = dto.IsEnabled });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StockMainCodeGroupVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            await _service.UpdateAsync(new StockMainCodeGroupUpdateDto
            {
                Id = vm.Id,
                Code = vm.Code,
                Name = vm.Name,
                IsEnabled = vm.IsEnabled
            });
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
