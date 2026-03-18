using Microsoft.AspNetCore.Mvc;
using MVC.ProductManagement.Application.DTOs.StockCodes.Catalog;
using MVC.ProductManagement.Application.Services.StockCodes.Catalog;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.Catalog;
using System.Text.Json;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    public class StockProductGroupController : AdminBaseController
    {
        private readonly IStockProductGroupService _service;
        private readonly IGeneratedStockCodeService _generatedService;

        public StockProductGroupController(IStockProductGroupService service, IGeneratedStockCodeService generatedService)
        {
            _service = service;
            _generatedService = generatedService;
        }

        public async Task<IActionResult> Index()
        {
            var groups = await _service.GetAllAsync();
            var detailedGroups = await Task.WhenAll(groups.Select(x => _service.GetByIdAsync(x.Id)));

            return View(detailedGroups
                .Where(x => x != null)
                .Select(x => x!)
                .OrderBy(x => x.Name)
                .ToList());
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();

            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(await BuildVmAsync(new StockProductGroupVm()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StockProductGroupVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View(await BuildVmAsync(vm));
            }

            await _service.CreateAsync(new StockProductGroupCreateDto
            {
                Name = vm.Name,
                Description = vm.Description,
                Items = ParseItems(vm.ItemsJson)
            });

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();

            return View(await BuildVmAsync(new StockProductGroupVm
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                TotalQuantity = dto.TotalQuantity,
                TotalCost = dto.TotalCost,
                ExistingItems = dto.Items.Select(x => new StockProductGroupItemVm
                {
                    GeneratedStockCodeId = x.GeneratedStockCodeId,
                    GeneratedCode = x.GeneratedCode,
                    Description = x.Description,
                    UnitPrice = x.UnitPrice,
                    Quantity = x.Quantity,
                    TotalCost = x.TotalCost
                }).ToList(),
                ItemsJson = JsonSerializer.Serialize(dto.Items.Select(x => new StockProductGroupItemCreateDto
                {
                    GeneratedStockCodeId = x.GeneratedStockCodeId,
                    Quantity = x.Quantity
                }))
            }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StockProductGroupVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View(await BuildVmAsync(vm));
            }

            await _service.UpdateAsync(new StockProductGroupUpdateDto
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description,
                Items = ParseItems(vm.ItemsJson)
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

        private async Task<StockProductGroupVm> BuildVmAsync(StockProductGroupVm vm)
        {
            vm.AvailableCodes = (await _generatedService.GetAllAsync())
                .OrderBy(x => x.GeneratedCode)
                .ToList();

            return vm;
        }

        private static List<StockProductGroupItemCreateDto> ParseItems(string? itemsJson)
        {
            if (string.IsNullOrWhiteSpace(itemsJson))
            {
                return new List<StockProductGroupItemCreateDto>();
            }

            return JsonSerializer.Deserialize<List<StockProductGroupItemCreateDto>>(itemsJson) ?? new List<StockProductGroupItemCreateDto>();
        }
    }
}
