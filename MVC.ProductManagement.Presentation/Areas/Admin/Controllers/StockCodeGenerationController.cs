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
        private readonly IStockProductGroupService _stockProductGroupService;

        public StockCodeGenerationController(
            IGeneratedStockCodeService generatedService,
            IStockSubCodeRuleService ruleService,
            IStockSubCodeGroupService subGroupService,
            IStockProductGroupService stockProductGroupService)
        {
            _generatedService = generatedService;
            _ruleService = ruleService;
            _subGroupService = subGroupService;
            _stockProductGroupService = stockProductGroupService;
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
                TargetPrice = vm.TargetPrice,
                PrimaryUnitType = vm.PrimaryUnitType,
                KgEquivalentPerPrimaryUnit = vm.KgEquivalentPerPrimaryUnit
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
                SelectedRuleIds = dto.StockSubCodeRuleId.HasValue ? new List<Guid> { dto.StockSubCodeRuleId.Value } : new List<Guid>(),
                GeneratedCode = dto.GeneratedCode,
                RuleName = dto.RuleName,
                Description = dto.Description,
                UnitPrice = dto.UnitPrice,
                TargetPrice = dto.TargetPrice,
                PrimaryUnitType = dto.PrimaryUnitType,
                KgEquivalentPerPrimaryUnit = dto.KgEquivalentPerPrimaryUnit
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
                StockSubCodeRuleId = vm.StockSubCodeRuleId,
                SelectedRuleIds = vm.SelectedRuleIds,
                Description = vm.Description,
                UnitPrice = vm.UnitPrice,
                TargetPrice = vm.TargetPrice,
                PrimaryUnitType = vm.PrimaryUnitType,
                KgEquivalentPerPrimaryUnit = vm.KgEquivalentPerPrimaryUnit
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

        [HttpGet]
        public async Task<IActionResult> Inventory(Guid id)
        {
            var dto = await _generatedService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var groups = await _stockProductGroupService.GetAllAsync();
            var movements = await _generatedService.GetInventoryMovementsAsync(id);

            var vm = new GeneratedStockCodeInventoryVm
            {
                GeneratedStockCodeId = id,
                GeneratedCode = dto.GeneratedCode,
                Description = dto.Description,
                CurrentStock = dto.CurrentStock,
                MovementDate = DateTime.UtcNow,
                Movements = movements.ToList(),
                StockProductGroups = groups.Select(x => new StockProductGroupOptionVm { Id = x.Id, Name = x.Name }).ToList()
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Inventory(GeneratedStockCodeInventoryVm vm)
        {
            if (!ModelState.IsValid)
            {
                var dto = await _generatedService.GetByIdAsync(vm.GeneratedStockCodeId);
                vm.GeneratedCode = dto?.GeneratedCode ?? string.Empty;
                vm.Description = dto?.Description;
                vm.CurrentStock = dto?.CurrentStock ?? 0;
                vm.Movements = (await _generatedService.GetInventoryMovementsAsync(vm.GeneratedStockCodeId)).ToList();
                vm.StockProductGroups = (await _stockProductGroupService.GetAllAsync())
                    .Select(x => new StockProductGroupOptionVm { Id = x.Id, Name = x.Name })
                    .ToList();
                return View(vm);
            }

            await _generatedService.CreateInventoryMovementAsync(new GeneratedStockCodeInventoryMovementCreateDto
            {
                GeneratedStockCodeId = vm.GeneratedStockCodeId,
                MovementType = vm.MovementType,
                Quantity = vm.Quantity,
                MovementDate = vm.MovementDate,
                StockProductGroupId = vm.StockProductGroupId,
                ReferenceDocument = vm.ReferenceDocument,
                Description = vm.MovementDescription
            }, User?.Identity?.Name ?? "System");

            return RedirectToAction(nameof(Inventory), new { id = vm.GeneratedStockCodeId });
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
