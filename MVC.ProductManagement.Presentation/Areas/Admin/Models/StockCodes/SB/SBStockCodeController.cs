using Microsoft.AspNetCore.Mvc;
using MVC.ProductManagement.Application.DTOs.StockCodes.SB;
using MVC.ProductManagement.Application.Services.StockCodes.SB;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.SB;
using Microsoft.AspNetCore.Mvc.Rendering;

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

            try
            {
                if (vm.FluidId == Guid.Empty)
                    throw new InvalidOperationException("Akışkan seçiniz.");

                if (vm.SProductId == Guid.Empty)
                    throw new InvalidOperationException("Ürün seçiniz.");

                var result = await _sbService.GenerateSbAsync(new SbStockCodeGenerateRequestDto
                {
                    FluidId = vm.FluidId,
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

        private async Task FillLookups(SBStockCodeGenerateVm vm)
        {
            var fluids = await _sbService.GetFluidsAsync();
            vm.Fluids = fluids
                .Select(x => new SelectListItem($"{x.Code} - {x.Name}", x.Id.ToString()))
                .ToList();

            var products = await _sbService.GetSbProductsAsync();
            vm.Products = products
                .Select(x => new SelectListItem($"{x.Code} - {x.Name}", x.Id.ToString()))
                .ToList();
        }
    }
}