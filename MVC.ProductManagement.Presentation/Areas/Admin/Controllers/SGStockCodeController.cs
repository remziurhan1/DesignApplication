using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs.StockCodes.SG;
using MVC.ProductManagement.Application.Services.StockCodes.SG;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.SG;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SGStockCodeController : Controller
    {
        private readonly IStockCodeSgService _sgService;

        public SGStockCodeController(IStockCodeSgService sgService)
        {
            _sgService = sgService;
        }

        [HttpGet]
        public async Task<IActionResult> Generate()
        {
            var vm = new SGStockCodeGenerateVm();
            await FillLookups(vm);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Generate(SGStockCodeGenerateVm vm)
        {
            await FillLookups(vm);

            // Feature'ları yükle (POST'ta validation hatası için)
            if (vm.SProductId != Guid.Empty)
            {
                vm.Features = await _sgService.GetFeaturesByProductAsync(vm.SProductId);
            }

            try
            {
                if (vm.SProductId == Guid.Empty)
                    throw new InvalidOperationException("Ürün seçiniz.");

                if (vm.SelectedFeatureValues == null || !vm.SelectedFeatureValues.Any())
                    throw new InvalidOperationException("Tüm özellikleri seçiniz.");

                var result = await _sgService.GenerateSgAsync(new SgStockCodeGenerateRequestDto
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
                return BadRequest("Geçersiz ürün ID");

            try
            {
                var features = await _sgService.GetFeaturesByProductAsync(pid);
                return Json(features);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        private async Task FillLookups(SGStockCodeGenerateVm vm)
        {
            var products = await _sgService.GetSgProductsAsync();
            vm.Products = products
                .Select(x => new SelectListItem($"{x.Code} - {x.Name}", x.Id.ToString()))
                .ToList();
        }
    }
}