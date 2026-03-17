using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs.StockCodes.Catalog;
using MVC.ProductManagement.Application.Services.StockCodes.Catalog;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.Catalog;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    public class StockSubCodeRuleController : AdminBaseController
    {
        private readonly IStockSubCodeRuleService _service;
        private readonly IStockSubCodeGroupService _subGroupService;

        public StockSubCodeRuleController(IStockSubCodeRuleService service, IStockSubCodeGroupService subGroupService)
        {
            _service = service;
            _subGroupService = subGroupService;
        }

        public async Task<IActionResult> Index(Guid? subGroupId)
        {
            await LoadSubGroups(subGroupId);
            return View(await _service.GetAllAsync(subGroupId));
        }

        public async Task<IActionResult> Create()
        {
            await LoadSubGroups(null);
            return View(new StockSubCodeRuleVm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StockSubCodeRuleVm vm)
        {
            if (!ModelState.IsValid)
            {
                await LoadSubGroups(vm.StockSubCodeGroupId);
                return View(vm);
            }

            await _service.CreateAsync(new StockSubCodeRuleCreateDto
            {
                StockSubCodeGroupId = vm.StockSubCodeGroupId,
                RuleCode = vm.RuleCode,
                RuleName = vm.RuleName,
                Description = vm.Description,
                IsEnabled = vm.IsEnabled
            });
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();

            await LoadSubGroups(dto.StockSubCodeGroupId);
            return View(new StockSubCodeRuleVm
            {
                Id = dto.Id,
                StockSubCodeGroupId = dto.StockSubCodeGroupId,
                RuleCode = dto.RuleCode,
                RuleName = dto.RuleName,
                Description = dto.Description,
                IsEnabled = dto.IsEnabled
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StockSubCodeRuleVm vm)
        {
            if (!ModelState.IsValid)
            {
                await LoadSubGroups(vm.StockSubCodeGroupId);
                return View(vm);
            }

            await _service.UpdateAsync(new StockSubCodeRuleUpdateDto
            {
                Id = vm.Id,
                StockSubCodeGroupId = vm.StockSubCodeGroupId,
                RuleCode = vm.RuleCode,
                RuleName = vm.RuleName,
                Description = vm.Description,
                IsEnabled = vm.IsEnabled
            });
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> NextCode(Guid subGroupId)
        {
            var nextCode = await _service.GetNextStockCodeBySubGroupAsync(subGroupId);
            return Json(new { nextCode });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task LoadSubGroups(Guid? selectedId)
        {
            var groups = await _subGroupService.GetAllAsync();
            ViewBag.SubGroups = groups
                .Select(x => new SelectListItem($"{x.MainGroupCode}/{x.Code} - {x.Name}", x.Id.ToString(), selectedId == x.Id))
                .ToList();
        }
    }
}
