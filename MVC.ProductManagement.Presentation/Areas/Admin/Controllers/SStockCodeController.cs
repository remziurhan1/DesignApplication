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
                vm.ErrorMessage = null;
            }
            catch (InvalidOperationException ex)
            {
                vm.StockCode8 = null;
                vm.Description = null;
                vm.AlreadyExists = null;
                vm.ErrorMessage = ex.Message;
            }

            return View("~/Areas/Admin/Views/StockCodes/Generate.cshtml", vm);
        }

        // ✅ Ajax: Group seçilince Fluid’leri getir
        [HttpGet]
        public async Task<IActionResult> FluidsByGroup(string groupId)
        {
            if (!Guid.TryParse(groupId, out var gid))
                return BadRequest();

            var list = await _service.GetFluidsByGroupAsync(gid);
            return Json(list.Select(x => new { x.Id, x.Code, x.Name }));
        }

        // ✅ Ajax: Group + Fluid seçilince Product’ları getir
        [HttpGet]
        public async Task<IActionResult> ProductsByGroupAndFluid(string groupId, string fluidId)
        {
            if (!Guid.TryParse(groupId, out var gid)) return BadRequest();
            if (!Guid.TryParse(fluidId, out var fid)) return BadRequest();

            var list = await _service.GetSProductsAsync(gid, fid);
            return Json(list.Select(x => new { x.Id, x.Code, x.Name }));
        }

        private async Task FillLookups(SStockCodeGenerateVm vm)
        {
            // 1) Gruplar her zaman dolu
            var groups = await _service.GetSProductGroupsAsync();
            vm.Groups = groups
                .Select(x => new SelectListItem($"{x.Code} - {x.Name}", x.Id.ToString()))
                .ToList();

            // 2) Fluid listesi: sadece Group seçilince dolacak
            vm.Fluids = new List<SelectListItem>();
            if (vm.SProductGroupId != Guid.Empty)
            {
                var fluids = await _service.GetFluidsByGroupAsync(vm.SProductGroupId);
                vm.Fluids = fluids
                    .Select(x => new SelectListItem($"{x.Code} - {x.Name}", x.Id.ToString()))
                    .ToList();
            }

            // 3) Product listesi: Group + Fluid seçilince dolacak
            vm.Products = new List<SelectListItem>();
            if (vm.SProductGroupId != Guid.Empty && vm.FluidId != Guid.Empty)
            {
                var products = await _service.GetSProductsAsync(vm.SProductGroupId, vm.FluidId);
                vm.Products = products
                    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                    .ToList();
            }

            // ❌ PrefixRules dropdown kaldırıldı (prefix kural tablosundan otomatik bulunuyor)
            vm.PrefixRules = new List<SelectListItem>();
        }
    }
}
