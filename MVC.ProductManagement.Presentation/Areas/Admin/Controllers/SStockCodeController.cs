using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs.StockCodes.S;
using MVC.ProductManagement.Application.Services.StockCodes.S;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.S;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    public class SStockCodeController : AdminBaseController
    {
        private readonly IStockCodeService _service;

        public SStockCodeController(IStockCodeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Generate()
        {
            var vm = new SStockCodeGenerateVm();
            await FillLookups(vm);
            return View("~/Areas/Admin/Views/StockCodes/Generate.cshtml", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Generate(SStockCodeGenerateVm vm)
        {
            await FillLookups(vm);

            try
            {
                var result = await _service.GenerateSAsync(new SStockCodeGenerateRequestDto
                {
                    FluidId = vm.FluidId,
                    SProductGroupId = vm.SProductGroupId,
                    SProductId = vm.SProductId
                });

                vm.StockCode8 = result.StockCode8;
                vm.Description = result.Description;
                vm.AlreadyExists = result.AlreadyExists;
            }
            catch (InvalidOperationException ex)
            {
                vm.StockCode8 = null;
                vm.Description = null;
                vm.AlreadyExists = null;

                vm.ErrorMessage = ex.Message; // vm'e string ErrorMessage ekle
            }

            return View("~/Areas/Admin/Views/StockCodes/Generate.cshtml", vm);
        }


        // Ajax: ürün grubu seçilince ürünleri getir
        [HttpGet]
        public async Task<IActionResult> ProductsByGroup(string groupId)
        {
            if (!Guid.TryParse(groupId, out var gid))
                return BadRequest();

            var list = await _service.GetSProductsAsync(gid);
            return Json(list.Select(x => new { x.Id, x.Code, x.Name }));
        }

        private async Task FillLookups(SStockCodeGenerateVm vm)
        {
            // Akışkanlar
            var fluids = await _service.GetFluidsAsync();
            vm.Fluids = fluids
                .Select(x => new SelectListItem($"{x.Code} - {x.Name}", x.Id.ToString()))
                .ToList();

            // S Ürün Grupları
            var groups = await _service.GetSProductGroupsAsync();
            vm.Groups = groups
                .Select(x => new SelectListItem($"{x.Code} - {x.Name}", x.Id.ToString()))
                .ToList();

            // Ürünler
            vm.Products = new List<SelectListItem>();
            if (vm.SProductGroupId != Guid.Empty)
            {
                var products = await _service.GetSProductsAsync(vm.SProductGroupId);
                vm.Products = products
     .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
     .ToList();

            }

            // PREFIX RULE (SFA0, SFC1, ...)
            vm.PrefixRules = new List<SelectListItem>();
            if (vm.FluidId != Guid.Empty &&
                vm.SProductGroupId != Guid.Empty &&
                vm.SProductId != Guid.Empty)
            {
                var rules = await _service.GetPrefixRulesAsync(
                    vm.FluidId,
                    vm.SProductGroupId,
                    vm.SProductId);

                vm.PrefixRules = rules
    .Select(x => new SelectListItem(x.Code, x.Id.ToString()))
    .ToList();

            }
        }
    }
}
