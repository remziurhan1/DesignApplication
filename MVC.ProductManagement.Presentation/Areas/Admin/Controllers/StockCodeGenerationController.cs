using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs.StockCodes.Catalog;
using MVC.ProductManagement.Application.Services.StockCodes.Catalog;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.Catalog;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    public class StockCodeGenerationController : AdminBaseController
    {
        private readonly IGeneratedStockCodeService _generatedService;
        private readonly IStockSubCodeRuleService _ruleService;
        private readonly IStockSubCodeGroupService _subGroupService;

        public StockCodeGenerationController(
            IGeneratedStockCodeService generatedService,
            IStockSubCodeRuleService ruleService,
            IStockSubCodeGroupService subGroupService)
        {
            _generatedService = generatedService;
            _ruleService = ruleService;
            _subGroupService = subGroupService;
        }

        public async Task<IActionResult> Index(Guid? subGroupId)
        {
            await LoadSubGroups(subGroupId);
            return View(await _generatedService.GetAllAsync(subGroupId));
        }

        [HttpGet]
        public async Task<IActionResult> GroupBuilder(Guid? subGroupId)
        {
            return RedirectToAction("Create", "StockProductGroup");
        }

        [HttpGet]
        public async Task<IActionResult> Generate(Guid? stockSubCodeGroupId)
        {
            await LoadSubGroups(stockSubCodeGroupId);
            return View(new GeneratedStockCodeVm { StockSubCodeGroupId = stockSubCodeGroupId ?? Guid.Empty });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Generate(GeneratedStockCodeVm vm)
        {
            if (!ModelState.IsValid)
            {
                await LoadSubGroups(vm.StockSubCodeGroupId);
                return View(vm);
            }

            await _generatedService.CreateAsync(new GeneratedStockCodeCreateDto
            {
                StockSubCodeGroupId = vm.StockSubCodeGroupId,
                StockSubCodeRuleId = vm.StockSubCodeRuleId,
                SelectedRuleIds = vm.SelectedRuleIds,
                GeneratedCode = vm.GeneratedCode,
                RuleName = vm.RuleName ?? string.Empty,
                Description = vm.Description,
                UnitPrice = vm.UnitPrice,
                TargetPrice = vm.TargetPrice
            });

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var dto = await _generatedService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            await LoadSubGroups(dto.StockSubCodeGroupId);
            return View(new GeneratedStockCodeVm
            {
                Id = dto.Id,
                StockSubCodeGroupId = dto.StockSubCodeGroupId,
                StockSubCodeRuleId = dto.StockSubCodeRuleId,
                GeneratedCode = dto.GeneratedCode,
                RuleName = dto.RuleName,
                Description = dto.Description,
                UnitPrice = dto.UnitPrice,
                TargetPrice = dto.TargetPrice
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GeneratedStockCodeVm vm)
        {
            if (!ModelState.IsValid)
            {
                await LoadSubGroups(vm.StockSubCodeGroupId);
                return View(vm);
            }

            await _generatedService.UpdateAsync(new GeneratedStockCodeUpdateDto
            {
                Id = vm.Id,
                Description = vm.Description,
                UnitPrice = vm.UnitPrice,
                TargetPrice = vm.TargetPrice
            });

            return RedirectToAction(nameof(Index), new { subGroupId = vm.StockSubCodeGroupId });
        }

        [HttpGet]
        public async Task<IActionResult> RulesBySubGroup(Guid subGroupId)
        {
            var rules = await _ruleService.GetAllAsync(subGroupId);
            return Json(rules.OrderBy(x => x.SortOrder ?? int.MaxValue).ThenBy(x => x.RuleCode).Select(x => new
            {
                x.Id,
                x.RuleCode,
                x.RuleName,
                x.Description,
                x.SortOrder
            }));
        }

        [HttpGet]
        public async Task<IActionResult> ResolveCode(Guid subGroupId, string? selectedRuleIds)
        {
            var selectedIds = ParseIds(selectedRuleIds);
            var result = await _generatedService.ResolveCodeAsync(subGroupId, selectedIds);
            return Json(new
            {
                code = result.Code,
                description = result.Description,
                unitPrice = result.UnitPrice,
                targetPrice = result.TargetPrice,
                isExisting = result.IsExisting
            });
        }

        private static List<Guid> ParseIds(string? csv)
        {
            if (string.IsNullOrWhiteSpace(csv)) return new List<Guid>();

            return csv.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => Guid.TryParse(x, out var id) ? id : Guid.Empty)
                .Where(x => x != Guid.Empty)
                .Distinct()
                .ToList();
        }

        private async Task LoadSubGroups(Guid? selectedId)
        {
            var groups = await _subGroupService.GetAllAsync();
            ViewBag.SubGroups = groups.Select(x => new SelectListItem($"{x.MainGroupCode}/{x.Code} - {x.Name}", x.Id.ToString(), selectedId == x.Id)).ToList();
        }
    }
}
