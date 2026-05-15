using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs.StockCodes.Catalog;
using MVC.ProductManagement.Application.Services.StockCodes.Catalog;
using MVC.ProductManagement.Presentation.Areas.Design.Models.StockCodes.Catalog;

namespace MVC.ProductManagement.Presentation.Areas.Design.Controllers
{
    public class StockSubCodeRuleController : DesignBaseController
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
            if (!await CanManageStockCodeDefinitionsAsync())
            {
                return Forbid();
            }

            await LoadSubGroups(subGroupId);
            return View(await _service.GetAllAsync(subGroupId));
        }

        public async Task<IActionResult> Create(Guid? stockSubCodeGroupId, string? ruleCode, string? description, string? ruleName, decimal? unitPrice, decimal? targetPrice)
        {
            if (!await CanManageStockCodeDefinitionsAsync())
            {
                return Forbid();
            }

            await LoadSubGroups(stockSubCodeGroupId);
            return View(new StockSubCodeRuleVm
            {
                StockSubCodeGroupId = stockSubCodeGroupId ?? Guid.Empty,
                RuleCode = ruleCode ?? string.Empty,
                Description = description,
                RuleName = ruleName ?? string.Empty,
                UnitPrice = unitPrice,
                TargetPrice = targetPrice,
                SortOrder = null,
                IsEnabled = true
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StockSubCodeRuleVm vm)
        {
            if (!await CanManageStockCodeDefinitionsAsync())
            {
                return Forbid();
            }

            if (!ModelState.IsValid)
            {
                await LoadSubGroups(vm.StockSubCodeGroupId);
                return View(vm);
            }

            await _service.CreateAsync(new StockSubCodeRuleCreateDto
            {
                StockSubCodeGroupId = vm.StockSubCodeGroupId,
                RuleCode = vm.RuleCode ?? string.Empty,
                RuleName = vm.RuleName,
                Description = vm.Description,
                SortOrder = vm.SortOrder,
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

            await LoadSubGroups(dto.StockSubCodeGroupId);
            return View(new StockSubCodeRuleVm
            {
                Id = dto.Id,
                StockSubCodeGroupId = dto.StockSubCodeGroupId,
                RuleCode = dto.RuleCode ?? string.Empty,
                RuleName = dto.RuleName,
                Description = dto.Description,
                SortOrder = dto.SortOrder,
                IsEnabled = dto.IsEnabled
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StockSubCodeRuleVm vm)
        {
            if (!await CanManageStockCodeDefinitionsAsync())
            {
                return Forbid();
            }

            if (!ModelState.IsValid)
            {
                await LoadSubGroups(vm.StockSubCodeGroupId);
                return View(vm);
            }

            await _service.UpdateAsync(new StockSubCodeRuleUpdateDto
            {
                Id = vm.Id,
                StockSubCodeGroupId = vm.StockSubCodeGroupId,
                RuleCode = vm.RuleCode ?? string.Empty,
                RuleName = vm.RuleName,
                Description = vm.Description,
                SortOrder = vm.SortOrder,
                IsEnabled = vm.IsEnabled
            });
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ExistingRulesBySubGroup(Guid subGroupId)
        {
            if (!await HasDesignPermissionAsync(x => x.CanCreateStockCodes || x.CanEditStockCodes || x.CanManageStockCodeDefinitions))
            {
                return Forbid();
            }

            var rules = await _service.GetAllAsync(subGroupId);
            return Json(rules.OrderBy(x => x.SortOrder ?? int.MaxValue).ThenBy(x => x.RuleName).ThenBy(x => x.RuleCode).Select(x => new
            {
                x.Id,
                x.RuleCode,
                x.RuleName,
                x.Description,
                x.SortOrder
            }));
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

        private async Task LoadSubGroups(Guid? selectedId)
        {
            var groups = await _subGroupService.GetAllAsync();
            ViewBag.SubGroups = groups
                .Select(x => new SelectListItem($"{x.MainGroupCode}/{x.Code} - {x.Name}", x.Id.ToString(), selectedId == x.Id))
                .ToList();
        }
    }
}
