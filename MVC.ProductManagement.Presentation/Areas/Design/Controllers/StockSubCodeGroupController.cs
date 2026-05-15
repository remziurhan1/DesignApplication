using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs.StockCodes.Catalog;
using MVC.ProductManagement.Application.Services.StockCodes.Catalog;
using MVC.ProductManagement.Presentation.Areas.Design.Models.StockCodes.Catalog;

namespace MVC.ProductManagement.Presentation.Areas.Design.Controllers
{
    public class StockSubCodeGroupController : DesignBaseController
    {
        private readonly IStockSubCodeGroupService _service;
        private readonly IStockMainCodeGroupService _mainCodeGroupService;

        public StockSubCodeGroupController(IStockSubCodeGroupService service, IStockMainCodeGroupService mainCodeGroupService)
        {
            _service = service;
            _mainCodeGroupService = mainCodeGroupService;
        }

        public async Task<IActionResult> Index(Guid? mainGroupId)
        {
            if (!await CanManageStockCodeDefinitionsAsync())
            {
                return Forbid();
            }

            await LoadMainGroups(mainGroupId);
            return View(await _service.GetAllAsync(mainGroupId));
        }

        public async Task<IActionResult> Create()
        {
            if (!await CanManageStockCodeDefinitionsAsync())
            {
                return Forbid();
            }

            await LoadMainGroups(null);
            return View(new StockSubCodeGroupVm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StockSubCodeGroupVm vm)
        {
            if (!await CanManageStockCodeDefinitionsAsync())
            {
                return Forbid();
            }

            if (!ModelState.IsValid)
            {
                await LoadMainGroups(vm.StockMainCodeGroupId);
                return View(vm);
            }

            await _service.CreateAsync(new StockSubCodeGroupCreateDto
            {
                StockMainCodeGroupId = vm.StockMainCodeGroupId,
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

            await LoadMainGroups(dto.StockMainCodeGroupId);
            return View(new StockSubCodeGroupVm
            {
                Id = dto.Id,
                StockMainCodeGroupId = dto.StockMainCodeGroupId,
                Code = dto.Code,
                Name = dto.Name,
                IsEnabled = dto.IsEnabled
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StockSubCodeGroupVm vm)
        {
            if (!await CanManageStockCodeDefinitionsAsync())
            {
                return Forbid();
            }

            if (!ModelState.IsValid)
            {
                await LoadMainGroups(vm.StockMainCodeGroupId);
                return View(vm);
            }

            await _service.UpdateAsync(new StockSubCodeGroupUpdateDto
            {
                Id = vm.Id,
                StockMainCodeGroupId = vm.StockMainCodeGroupId,
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

        private async Task LoadMainGroups(Guid? selectedId)
        {
            var groups = await _mainCodeGroupService.GetAllAsync();
            ViewBag.MainGroups = groups.Select(x => new SelectListItem($"{x.Code} - {x.Name}", x.Id.ToString(), selectedId == x.Id)).ToList();
        }
    }
}
