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

                var result = await _saService.GenerateSaAsync(new SaStockCodeGenerateRequestDto
                {
                    SProductId = vm.SProductId
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