using Microsoft.AspNetCore.Mvc;
using MVC.ProductManagement.Application.DTOs.StockCodes.Catalog;
using MVC.ProductManagement.Application.Services.StockCodes.Catalog;
using MVC.ProductManagement.Presentation.Areas.Design.Models.StockCodes.Catalog;

namespace MVC.ProductManagement.Presentation.Areas.Design.Controllers
{
    public class StockMainCodeGroupController : DesignBaseController
    {
        private readonly IStockMainCodeGroupService _service;

        public StockMainCodeGroupController(IStockMainCodeGroupService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            if (!await CanManageStockCodeDefinitionsAsync())
            {
                return Forbid();
            }

            return View(await _service.GetAllAsync());
        }

        public async Task<IActionResult> Create()
        {
            if (!await CanManageStockCodeDefinitionsAsync())
            {
                return Forbid();
            }

            return View(new StockMainCodeGroupVm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StockMainCodeGroupVm vm)
        {
            if (!await CanManageStockCodeDefinitionsAsync())
            {
                return Forbid();
            }

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
            if (!await CanManageStockCodeDefinitionsAsync())
            {
                return Forbid();
            }

            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();
            return View(new StockMainCodeGroupVm { Id = dto.Id, Code = dto.Code, Name = dto.Name, IsEnabled = dto.IsEnabled });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StockMainCodeGroupVm vm)
        {
            if (!await CanManageStockCodeDefinitionsAsync())
            {
                return Forbid();
            }

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
            if (!await CanManageStockCodeDefinitionsAsync())
            {
                return Forbid();
            }

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
