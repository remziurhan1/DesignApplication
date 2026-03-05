using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs.StockCodes.SA.Properties;
using MVC.ProductManagement.Application.Services.StockCodes.SA;
using MVC.ProductManagement.Application.Services.StockCodes.SA.Properties;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.SA.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SAStockCodePropertyController : Controller
    {
        private readonly IStockCodeSaPropertyAppService _propertyAppService;
        private readonly IStockCodeSaAppService _saAppService;

        public SAStockCodePropertyController(
            IStockCodeSaPropertyAppService propertyAppService,
            IStockCodeSaAppService saAppService)
        {
            _propertyAppService = propertyAppService;
            _saAppService = saAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(Guid? productId)
        {
            var list = productId.HasValue && productId.Value != Guid.Empty
                ? await _propertyAppService.GetByProductAsync(productId.Value)
                : await _propertyAppService.GetAllAsync();

            var vm = list.Adapt<List<SaStockCodePropertyListVm>>();
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var vm = new SaStockCodePropertyVm();
            await FillLookupsAsync(vm);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaStockCodePropertyVm vm)
        {
            try
            {
                await _propertyAppService.AddAsync(new SaStockCodePropertyCreateDto
                {
                    ProductId = vm.ProductId,
                    FeatureId = vm.FeatureId,
                    IsFixed = vm.IsFixed,
                    FixedValueId = vm.FixedValueId
                });

                TempData["SuccessMessage"] = "SA property kuralı eklendi.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                await FillLookupsAsync(vm);
                return View(vm);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var dto = await _propertyAppService.GetForEditAsync(id);
            if (dto == null)
                return RedirectToAction(nameof(Index));

            var vm = dto.Adapt<SaStockCodePropertyVm>();
            await FillLookupsAsync(vm);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, SaStockCodePropertyVm vm)
        {
            try
            {
                await _propertyAppService.UpdateAsync(new SaStockCodePropertyUpdateDto
                {
                    Id = id,
                    ProductId = vm.ProductId,
                    FeatureId = vm.FeatureId,
                    IsFixed = vm.IsFixed,
                    FixedValueId = vm.FixedValueId
                });

                TempData["SuccessMessage"] = "SA property kuralı güncellendi.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                await FillLookupsAsync(vm);
                return View(vm);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _propertyAppService.DeleteAsync(id);
            TempData["SuccessMessage"] = "SA property kuralı silindi.";
            return RedirectToAction(nameof(Index));
        }

        private async Task FillLookupsAsync(SaStockCodePropertyVm vm)
        {
            var products = await _saAppService.GetSaProductsAsync();
            vm.Products = products
                .Select(x => new SelectListItem($"{x.Code} - {x.Name}", x.Id.ToString(), x.Id == vm.ProductId))
                .ToList();

            var features = await _saAppService.GetAllFeaturesAsync();
            vm.Features = features
                .Select(x => new SelectListItem($"{x.Code} - {x.Name}", x.Id.ToString(), x.Id == vm.FeatureId))
                .ToList();

            if (vm.FeatureId != Guid.Empty)
            {
                var values = await _saAppService.GetFeatureValuesAsync(vm.FeatureId);
                vm.FeatureValues = values
                    .Select(x => new SelectListItem($"{x.Code} - {x.Name}", x.Id.ToString(), vm.FixedValueId == x.Id))
                    .ToList();
            }
            else
            {
                vm.FeatureValues = new List<SelectListItem>();
            }
        }
    }
}
