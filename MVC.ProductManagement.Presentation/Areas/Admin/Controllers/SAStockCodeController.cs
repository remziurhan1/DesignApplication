using Microsoft.AspNetCore.Mvc;
using MVC.ProductManagement.Application.DTOs.StockCodes.SA;
using MVC.ProductManagement.Application.Services.StockCodes.SA;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.SA;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SAStockCodeController : Controller
    {
        private readonly IStockCodeSaService _saService;

        public SAStockCodeController(IStockCodeSaService saService)
        {
            _saService = saService;
        }

        [HttpGet]
        public async Task<IActionResult> Generate()
        {
            var vm = new SAStockCodeGenerateVm();
            await FillLookups(vm);

            // ✅ FEATURE'LARI YÜKLE
            var products = await _saService.GetSaProductsAsync();
            if (products != null && products.Any())
            {
                var firstProductId = products.First().Id;
                vm.Features = await _saService.GetFeaturesByProductAsync(firstProductId);

                // ✅ DEBUG
                Console.WriteLine($"[SA GET] Products Count: {products.Count}");
                Console.WriteLine($"[SA GET] Features Count: {vm.Features?.Count ?? 0}");
            }

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Generate(SAStockCodeGenerateVm vm)
        {
            // ✅ DEBUG: Form'dan gelen veri
            Console.WriteLine($"[SA POST] SProductId: {vm.SProductId}");
            Console.WriteLine($"[SA POST] SelectedFeatureValues Count: {vm.SelectedFeatureValues?.Count ?? 0}");

            if (vm.SelectedFeatureValues != null)
            {
                foreach (var kvp in vm.SelectedFeatureValues)
                {
                    Console.WriteLine($"[SA POST] Feature: {kvp.Key} => Value: {kvp.Value}");
                }
            }

            await FillLookups(vm);

            // ✅ POST'ta da feature'ları yükle
            var products = await _saService.GetSaProductsAsync();
            if (products != null && products.Any())
            {
                var firstProductId = products.First().Id;
                vm.Features = await _saService.GetFeaturesByProductAsync(firstProductId);
            }

            try
            {
                if (vm.SProductId == Guid.Empty)
                    throw new InvalidOperationException("Ürün seçiniz.");

                if (vm.SelectedFeatureValues == null || !vm.SelectedFeatureValues.Any())
                    throw new InvalidOperationException("Metrik ve Boy seçimlerini yapınız.");

                var result = await _saService.GenerateSaAsync(new SaStockCodeGenerateRequestDto
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

        private async Task FillLookups(SAStockCodeGenerateVm vm)
        {
            var products = await _saService.GetSaProductsAsync();
            vm.Products = products
                .Select(x => new SelectListItem($"{x.Code} - {x.Name}", x.Id.ToString()))
                .ToList();
        }
    }
}