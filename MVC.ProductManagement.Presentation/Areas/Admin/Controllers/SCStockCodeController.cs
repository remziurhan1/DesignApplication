using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs.StockCodes.SC;
using MVC.ProductManagement.Application.Services.StockCodes.SC;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.SC;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SCStockCodeController : Controller
    {
        private readonly IStockCodeScService _scService;

        public SCStockCodeController(IStockCodeScService scService)
        {
            _scService = scService;
        }

        [HttpGet]
        public async Task<IActionResult> Generate()
        {
            var vm = new SCStockCodeGenerateVm();
            await FillLookups(vm);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Generate(SCStockCodeGenerateVm vm)
        {
            await FillLookups(vm);

            // Feature'ları yükle (POST'ta validation hatası için)
            if (vm.SProductId != Guid.Empty)
            {
                vm.Features = await _scService.GetFeaturesByProductAsync(vm.SProductId);
            }

            try
            {
                if (vm.SProductId == Guid.Empty)
                    throw new InvalidOperationException("Ürün seçiniz.");

                if (vm.SelectedFeatureValues == null || !vm.SelectedFeatureValues.Any())
                    throw new InvalidOperationException("Tüm özellikleri seçiniz.");

                var result = await _scService.GenerateScAsync(new ScStockCodeGenerateRequestDto
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

            var features = await _scService.GetFeaturesByProductAsync(pid);
            return Json(features);
        }

        private async Task FillLookups(SCStockCodeGenerateVm vm)
        {
            var products = await _scService.GetScProductsAsync();
            vm.Products = products
                .Select(x => new SelectListItem($"{x.Code} - {x.Name}", x.Id.ToString()))
                .ToList();
        }
    }
}