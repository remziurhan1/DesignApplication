using Microsoft.AspNetCore.Mvc;
using MVC.ProductManagement.Application.DTOs.StockCodes.SF;
using MVC.ProductManagement.Application.Services.StockCodes.SF;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.SF;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs.StockCodes.S;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SFStockCodeController : Controller
    {
        private readonly IStockCodeSfService _sfService;

        public SFStockCodeController(IStockCodeSfService sfService)
        {
            _sfService = sfService;
        }

        [HttpGet]
        public async Task<IActionResult> Generate()
        {
            var vm = new SFStockCodeGenerateVm();
            await FillLookups(vm);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Generate(SFStockCodeGenerateVm vm)
        {
            await FillLookups(vm);

            try
            {
                if (vm.FluidId == Guid.Empty)
                    throw new InvalidOperationException("Akışkan seçiniz.");

                if (vm.SProductId == Guid.Empty)
                    throw new InvalidOperationException("Ürün seçiniz.");

                if (vm.SelectedFeatureValues == null || !vm.SelectedFeatureValues.Any())
                    throw new InvalidOperationException("PN/DN seçimlerini yapınız.");

                var result = await _sfService.GenerateSfAsync(new SfStockCodeGenerateRequestDto
                {
                    FluidId = vm.FluidId,
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

        // ========== AJAX ENDPOINTS ==========

        [HttpGet]
        public async Task<IActionResult> ProductsByFluid(string fluidId)
        {
            if (!Guid.TryParse(fluidId, out var fid))
                return BadRequest();

            var products = await _sfService.GetSfProductsAsync(fid);
            return Json(products.Select(x => new { x.Id, x.Code, x.Name }));
        }

        [HttpGet]
        public async Task<IActionResult> FeaturesByProduct(string productId)
        {
            if (!Guid.TryParse(productId, out var pid))
                return BadRequest();

            var features = await _sfService.GetFeaturesByProductAsync(pid);
            return Json(features);
        }

        // ========== PRIVATE METHODS ==========

        private async Task FillLookups(SFStockCodeGenerateVm vm)
        {
            var fluids = await _sfService.GetFluidsAsync();
            vm.Fluids = fluids
                .Select(x => new SelectListItem($"{x.Code} - {x.Name}", x.Id.ToString()))
                .ToList();

            vm.Products = new List<SelectListItem>();
        }
    }
}