using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs.StockCodes.SE;
using MVC.ProductManagement.Application.Services.StockCodes.SE;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.SE;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SEStockCodeController : Controller
    {
        private readonly IStockCodeSeService _seService;

        public SEStockCodeController(IStockCodeSeService seService)
        {
            _seService = seService;
        }

        [HttpGet]
        public async Task<IActionResult> Generate()
        {
            var vm = new SEStockCodeGenerateVm();
            await FillLookups(vm);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Generate(SEStockCodeGenerateVm vm)
        {
            await FillLookups(vm);

            // Feature'ları yükle (POST'ta validation hatası için)
            if (vm.SProductId != Guid.Empty)
            {
                vm.Features = await _seService.GetFeaturesByProductAsync(vm.SProductId);
            }

            try
            {
                if (vm.SProductId == Guid.Empty)
                    throw new InvalidOperationException("Ürün seçiniz.");

                if (vm.SelectedFeatureValues == null || !vm.SelectedFeatureValues.Any())
                    throw new InvalidOperationException("Tüm özellikleri seçiniz.");

                var result = await _seService.GenerateSeAsync(new SeStockCodeGenerateRequestDto
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

            var features = await _seService.GetFeaturesByProductAsync(pid);
            return Json(features);
        }

        private async Task FillLookups(SEStockCodeGenerateVm vm)
        {
            var products = await _seService.GetSeProductsAsync();
            vm.Products = products
                .Select(x => new SelectListItem($"{x.Code} - {x.Name}", x.Id.ToString()))
                .ToList();
        }
    }
}