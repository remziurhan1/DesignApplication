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

        public async Task<IActionResult> Create(Guid? stockSubCodeGroupId, string? ruleCode, string? description, string? ruleName)
        {
            await LoadSubGroups(stockSubCodeGroupId);
            return View(new StockSubCodeRuleVm
            {
                StockSubCodeGroupId = stockSubCodeGroupId ?? Guid.Empty,
                RuleCode = ruleCode ?? string.Empty,
                Description = description,
                RuleName = ruleName ?? string.Empty,
                IsEnabled = true
            });
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
        public async Task<IActionResult> Generate(Guid? stockSubCodeGroupId)
        {
            await LoadSubGroups(stockSubCodeGroupId);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RulesBySubGroup(Guid subGroupId)
        {
            var rules = await _service.GetAllAsync(subGroupId);
            return Json(rules
                .Where(x => x.IsEnabled)
                .OrderBy(x => x.RuleCode)
                .Select(x => new
                {
                    x.Id,
                    x.RuleCode,
                    x.RuleName,
                    x.Description
                }));
        }

        [HttpGet]
        public async Task<IActionResult> ResolveCode(Guid subGroupId, string? description)
        {
            var existingRule = await _service.FindBySubGroupAndDescriptionAsync(subGroupId, description);
            if (existingRule != null)
            {
                return Json(new
                {
                    code = existingRule.RuleCode,
                    description = existingRule.Description,
                    ruleName = existingRule.RuleName,
                    isExisting = true
                });
            }

            var nextCode = await _service.GetNextStockCodeBySubGroupAsync(subGroupId);
            return Json(new
            {
                code = nextCode,
                description = description?.Trim(),
                ruleName = string.Empty,
                isExisting = false
            });
        }


        [HttpGet]
        public async Task<IActionResult> RulesBySubGroup(Guid subGroupId)
        {
            var rules = await _service.GetAllAsync(subGroupId);
            return Json(rules
                .Where(x => x.IsEnabled)
                .OrderBy(x => x.RuleCode)
                .Select(x => new
                {
                    x.Id,
                    x.RuleCode,
                    x.RuleName,
                    x.Description
                }));
        }

        [HttpGet]
        public async Task<IActionResult> ResolveCode(Guid subGroupId, string? description)
        {
            var existingRule = await _service.FindBySubGroupAndDescriptionAsync(subGroupId, description);
            if (existingRule != null)
            {
                return Json(new
                {
                    code = existingRule.RuleCode,
                    description = existingRule.Description,
                    isExisting = true
                });
            }

            var nextCode = await _service.GetNextStockCodeBySubGroupAsync(subGroupId);
            return Json(new
            {
                code = nextCode,
                description = description?.Trim(),
                isExisting = false
            });
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
