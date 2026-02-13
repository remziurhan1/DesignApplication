using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs.StockCodes.SA;
using MVC.ProductManagement.Application.Services.StockCodes.SA;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.SA;

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

        /// <summary>
        /// ✅ Liste sayfası
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index(SAStockCardFilterDto filter)
        {
            var result = await _saService.GetStockCardsAsync(filter, CancellationToken.None);

            // Ürün dropdown için
            var products = await _saService.GetSaProductsAsync();
            ViewBag.Products = products
                .Select(x => new SelectListItem($"{x.Code} - {x.Name}", x.Id.ToString()))
                .ToList();

            return View(result);
        }

        /// <summary>
        /// ✅ Detay sayfası
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Detail(Guid id)
        {
            try
            {
                var detail = await _saService.GetStockCardDetailAsync(id, CancellationToken.None);
                return View(detail);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Generate()
        {
            var vm = new SAStockCodeGenerateVm();
            await FillLookups(vm);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Generate(SAStockCodeGenerateVm vm)
        {
            await FillLookups(vm);

            try
            {
                if (vm.SProductId == Guid.Empty)
                    throw new InvalidOperationException("Ürün seçiniz.");

                if (vm.SelectedFeatureValues == null || !vm.SelectedFeatureValues.Any())
                    throw new InvalidOperationException("Tüm özellikleri seçiniz.");

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

        /// <summary>
        /// ✅ YENİ: Rule-based form data (sabit değerler + dropdown'lar + bağımlılıklar)
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetFormData(Guid productId)
        {
            try
            {
                var formData = await _saService.GetFormDataAsync(productId, CancellationToken.None);
                return Json(formData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
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