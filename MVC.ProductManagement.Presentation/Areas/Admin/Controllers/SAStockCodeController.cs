using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs.StockCodes.SA;
using MVC.ProductManagement.Application.Services.StockCodes.S;
using MVC.ProductManagement.Application.Services.StockCodes.SA;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.SA;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    public class SAStockCodeController : AdminBaseController
    {
        private readonly IStockCodeSaService _saService;
        private readonly IStockCodeService _lookupService;

        public SAStockCodeController(
            IStockCodeSaService saService,
            IStockCodeService lookupService)
        {
            _saService = saService;
            _lookupService = lookupService;
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
                var result = await _saService.GenerateSaAsync(new SaStockCodeGenerateRequestDto
                {
                    FluidId = vm.FluidId,
                    SProductGroupId = vm.SProductGroupId,
                    SProductId = vm.SProductId
                });

                vm.StockCode8 = result.StockCode8;
                vm.Description = result.Description;
                vm.AlreadyExists = result.AlreadyExists;
                vm.ErrorMessage = null;
            }
            catch (InvalidOperationException ex)
            {
                vm.StockCode8 = null;
                vm.Description = null;
                vm.AlreadyExists = null;
                vm.ErrorMessage = ex.Message;
            }

            return View(vm);

        }

        // ✅ Ajax: Group seçilince Product’ları getir (SA: fluid'e bağlı değil)
        [HttpGet]
        public async Task<IActionResult> ProductsByGroup(string groupId)
        {
            if (!Guid.TryParse(groupId, out var gid))
                return BadRequest();

            var list = await _saService.GetSaProductsAsync(gid);
            return Json(list.Select(x => new { x.Id, x.Code, x.Name }));
        }

        private async Task FillLookups(SAStockCodeGenerateVm vm)
        {
            // 1) Gruplar (lookup servisten)
            var groups = await _lookupService.GetSProductGroupsAsync();
            vm.Groups = groups
                .Select(x => new SelectListItem($"{x.Code} - {x.Name}", x.Id.ToString()))
                .ToList();

            // 2) Fluids (SA: kuraldan bağımsız hepsi -> lookup servisten)
            var fluids = await _lookupService.GetAllFluidsAsync();
            vm.Fluids = fluids
                .Select(x => new SelectListItem($"{x.Code} - {x.Name}", x.Id.ToString()))
                .ToList();

            // 3) Products (SA: sadece group seçilince -> SA servisten)
            vm.Products = new List<SelectListItem>();
            if (vm.SProductGroupId != Guid.Empty)
            {
                var products = await _saService.GetSaProductsAsync(vm.SProductGroupId);
                vm.Products = products
                    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                    .ToList();
            }
        }
    }
}
