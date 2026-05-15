using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using MVC.ProductManagement.Application.DTOs.StockCodes.Catalog;
using MVC.ProductManagement.Application.Services.StockCodes.Catalog;
using MVC.ProductManagement.Presentation.Areas.Design.Models.StockCodes.Catalog;

namespace MVC.ProductManagement.Presentation.Areas.Design.Controllers
{
    public class StockCodeGenerationController : DesignBaseController
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
            if (!await HasDesignPermissionAsync(x => x.CanAccessDesignArea || x.CanCreateStockCodes || x.CanEditStockCodes || x.CanManageStockCodeDefinitions))
            {
                return Forbid();
            }

            await LoadSubGroups(subGroupId);
            return View(await _generatedService.GetAllAsync(subGroupId));
        }

        [HttpGet]
        public async Task<IActionResult> GroupBuilder(Guid? subGroupId)
        {
            if (!await CanManageStockCodeDefinitionsAsync())
            {
                return Forbid();
            }

            return RedirectToAction("Index", "StockSubCodeGroup");
        }

        [HttpGet]
        public async Task<IActionResult> Generate(Guid? stockSubCodeGroupId)
        {
            if (!await HasDesignPermissionAsync(x => x.CanCreateStockCodes))
            {
                return Forbid();
            }

            await LoadSubGroups(stockSubCodeGroupId);
            return View(new GeneratedStockCodeVm { StockSubCodeGroupId = stockSubCodeGroupId ?? Guid.Empty });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Generate(GeneratedStockCodeVm vm)
        {
            if (!await HasDesignPermissionAsync(x => x.CanCreateStockCodes))
            {
                return Forbid();
            }

            if (!ModelState.IsValid)
            {
                await LoadSubGroups(vm.StockSubCodeGroupId);
                return View(vm);
            }

            var attachments = await SaveAttachmentsAsync(vm);
            if (!attachments.HasAny)
            {
                ModelState.AddModelError(string.Empty, "STEP / DXF / Datasheet dosyalarından en az biri zorunludur.");
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
                PrimaryUnitType = vm.PrimaryUnitType,
                KgEquivalentPerPrimaryUnit = vm.KgEquivalentPerPrimaryUnit,
                Step3DFilePath = attachments.Step3DFilePath,
                DxfFilePath1 = attachments.DxfFilePath1,
                DxfFilePath2 = attachments.DxfFilePath2,
                DatasheetFilePath = attachments.DatasheetFilePath
            });

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (!await HasDesignPermissionAsync(x => x.CanEditStockCodes))
            {
                return Forbid();
            }

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
                PrimaryUnitType = dto.PrimaryUnitType,
                KgEquivalentPerPrimaryUnit = dto.KgEquivalentPerPrimaryUnit,
                Step3DFilePath = dto.Step3DFilePath,
                DxfFilePath1 = dto.DxfFilePath1,
                DxfFilePath2 = dto.DxfFilePath2,
                DatasheetFilePath = dto.DatasheetFilePath
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GeneratedStockCodeVm vm)
        {
            if (!await HasDesignPermissionAsync(x => x.CanEditStockCodes))
            {
                return Forbid();
            }

            if (!ModelState.IsValid)
            {
                await LoadSubGroups(vm.StockSubCodeGroupId);
                return View(vm);
            }

            var attachments = await SaveAttachmentsAsync(vm);
            if (!attachments.HasAny)
            {
                ModelState.AddModelError(string.Empty, "STEP / DXF / Datasheet dosyalarından en az biri zorunludur.");
                await LoadSubGroups(vm.StockSubCodeGroupId);
                return View(vm);
            }

            var existing = await _generatedService.GetByIdAsync(vm.Id);
            if (existing == null) return NotFound();

            await _generatedService.UpdateAsync(new GeneratedStockCodeUpdateDto
            {
                Id = vm.Id,
                StockSubCodeRuleId = vm.StockSubCodeRuleId,
                SelectedRuleIds = vm.SelectedRuleIds,
                Description = vm.Description,
                UnitPrice = existing.UnitPrice,
                TargetPrice = existing.TargetPrice,
                PrimaryUnitType = vm.PrimaryUnitType,
                KgEquivalentPerPrimaryUnit = vm.KgEquivalentPerPrimaryUnit,
                Step3DFilePath = attachments.Step3DFilePath,
                DxfFilePath1 = attachments.DxfFilePath1,
                DxfFilePath2 = attachments.DxfFilePath2,
                DatasheetFilePath = attachments.DatasheetFilePath
            });

            return RedirectToAction(nameof(Index), new { subGroupId = vm.StockSubCodeGroupId });
        }

        [HttpGet]
        public async Task<IActionResult> RulesBySubGroup(Guid subGroupId)
        {
            if (!await HasDesignPermissionAsync(x => x.CanCreateStockCodes || x.CanEditStockCodes))
            {
                return Forbid();
            }

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
            if (!await HasDesignPermissionAsync(x => x.CanCreateStockCodes || x.CanEditStockCodes))
            {
                return Forbid();
            }

            var selectedIds = ParseIds(selectedRuleIds);
            var result = await _generatedService.ResolveCodeAsync(subGroupId, selectedIds);
            return Json(new
            {
                code = result.Code,
                description = result.Description,
                isExisting = result.IsExisting
            });
        }

        [HttpGet]
        public async Task<IActionResult> Inventory(Guid id)
        {
            if (!await HasDesignPermissionAsync(x => x.CanAccessDesignArea || x.CanEditStockCodes))
            {
                return Forbid();
            }

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
            if (!await HasDesignPermissionAsync(x => x.CanEditStockCodes))
            {
                return Forbid();
            }

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

        private async Task<(string? Step3DFilePath, string? DxfFilePath1, string? DxfFilePath2, string? DatasheetFilePath, bool HasAny)> SaveAttachmentsAsync(GeneratedStockCodeVm vm)
        {
            var stepPath = await SaveFileIfProvidedAsync(vm.Step3DFile, vm.Step3DFilePath);
            var dxfPath1 = await SaveFileIfProvidedAsync(vm.DxfFile1, vm.DxfFilePath1);
            var dxfPath2 = await SaveFileIfProvidedAsync(vm.DxfFile2, vm.DxfFilePath2);
            var datasheetPath = await SaveFileIfProvidedAsync(vm.DatasheetFile, vm.DatasheetFilePath);

            var hasAny = !string.IsNullOrWhiteSpace(stepPath)
                         || !string.IsNullOrWhiteSpace(dxfPath1)
                         || !string.IsNullOrWhiteSpace(dxfPath2)
                         || !string.IsNullOrWhiteSpace(datasheetPath);

            return (stepPath, dxfPath1, dxfPath2, datasheetPath, hasAny);
        }

        private async Task<string?> SaveFileIfProvidedAsync(IFormFile? file, string? existingPath)
        {
            if (file == null || file.Length == 0)
            {
                return existingPath;
            }

            var uploadsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "stockcode-files");
            if (!Directory.Exists(uploadsDirectory))
            {
                Directory.CreateDirectory(uploadsDirectory);
            }

            var extension = Path.GetExtension(file.FileName);
            var uniqueName = $"{Guid.NewGuid():N}{extension}";
            var fullPath = Path.Combine(uploadsDirectory, uniqueName);

            await using var stream = new FileStream(fullPath, FileMode.Create);
            await file.CopyToAsync(stream);

            return $"/uploads/stockcode-files/{uniqueName}";
        }
    }
}
