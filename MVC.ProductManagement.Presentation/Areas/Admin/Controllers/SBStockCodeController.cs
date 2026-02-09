using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs.StockCodes.SB;
using MVC.ProductManagement.Application.Services.StockCodes.SB;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.SB;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SBStockCodeController : Controller
    {
        private readonly IStockCodeSbService _sbService;

        public SBStockCodeController(IStockCodeSbService sbService)
        {
            _sbService = sbService;
        }

        [HttpGet]
        public async Task<IActionResult> Generate()
        {
            var vm = new SBStockCodeGenerateVm();
            await FillLookups(vm);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Generate(SBStockCodeGenerateVm vm)
        {
            await FillLookups(vm);

            // Feature'ları yükle (POST'ta validation hatası için)
            if (vm.SProductId != Guid.Empty)
            {
                vm.Features = await _sbService.GetFeaturesByProductAsync(vm.SProductId);
            }

            try
            {
                if (vm.SProductId == Guid.Empty)
                    throw new InvalidOperationException("Ürün seçiniz.");

                if (vm.SelectedFeatureValues == null || !vm.SelectedFeatureValues.Any())
                    throw new InvalidOperationException("Tüm özellikleri seçiniz.");

                var result = await _sbService.GenerateSbAsync(new SbStockCodeGenerateRequestDto
                {
                    SProductId = vm.SProductId,
                    SelectedFeatureValues = vm.SelectedFeatureValues
                });

                vm.StockCode8 = result.StockCode8;
                vm.Description = result.Description;
                vm.AlreadyExists = result.AlreadyExists;
                vm.ErrorMessage = null;
            }
            catch (Exception ex)
            {
                vm.StockCode8 = null;
                vm.Description = null;
                vm.AlreadyExists = null;
                vm.ErrorMessage = ex.Message;
            }

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> FeaturesByProduct(string productId)
        {
            if (!Guid.TryParse(productId, out var pid))
                return BadRequest();

            var features = await _sbService.GetFeaturesByProductAsync(pid);
            return Json(features);
        }

        private async Task FillLookups(SBStockCodeGenerateVm vm)
        {
            var products = await _sbService.GetSbProductsAsync();
            vm.Products = products
                .Select(x => new SelectListItem($"{x.Code} - {x.Name}", x.Id.ToString()))
                .ToList();
        }
    }
}