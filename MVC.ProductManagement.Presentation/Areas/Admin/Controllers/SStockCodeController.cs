using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.Services.StockCodes.S;
using MVC.ProductManagement.Application.Services.StockCodes.S.Handlers;
using MVC.ProductManagement.Application.Services.StockCodes.S.Features;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.S;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    public class SStockCodeController : AdminBaseController
    {
        private readonly IStockCodeService _lookupService;
        private readonly ISStockCodeGroupHandlerFactory _handlerFactory;
        private readonly ISFeatureQueryService _featureQueryService;

        public SStockCodeController(
            IStockCodeService lookupService,
            ISStockCodeGroupHandlerFactory handlerFactory,
            ISFeatureQueryService featureQueryService)
        {
            _lookupService = lookupService;
            _handlerFactory = handlerFactory;
            _featureQueryService = featureQueryService;
        }

        [HttpGet]
        public async Task<IActionResult> Generate()
        {
            var vm = new SStockCodeGenerateVm();
            await FillLookups(vm);
            return View("~/Areas/Admin/Views/StockCodes/Generate.cshtml", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Generate(SStockCodeGenerateVm vm, CancellationToken cancellationToken)
        {
            await FillLookups(vm);

            try
            {
                if (vm.SProductGroupId == Guid.Empty)
                    throw new InvalidOperationException("Ürün grubu seçiniz.");

                if (vm.SProductId == Guid.Empty)
                    throw new InvalidOperationException("Ürün seçiniz.");

                var groups = await _lookupService.GetSProductGroupsAsync();
                var group = groups.FirstOrDefault(x => x.Id == vm.SProductGroupId);
                if (group == null)
                    throw new InvalidOperationException("Seçilen ürün grubu bulunamadı.");

                var handler = _handlerFactory.GetByGroupCode(group.Code);

                if (handler.RequiresFluid && vm.FluidId == Guid.Empty)
                    throw new InvalidOperationException("Akışkan seçiniz.");

                Guid? fluidId = handler.RequiresFluid ? vm.FluidId : null;
                var debugCount = vm.SelectedFeatureValues?.Count ?? 0;


                var result = await handler.GenerateAsync(
    vm.SProductGroupId,
    fluidId,
    vm.SProductId,
    vm.SelectedFeatureValues,
    cancellationToken);

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

            var groups = await _lookupService.GetSProductGroupsAsync();
            var group = groups.FirstOrDefault(x => x.Id == gid);
            if (group == null)
                return Json(Array.Empty<object>());

            var handler = _handlerFactory.GetByGroupCode(group.Code);

            if (!handler.RequiresFluid)
                return Json(Array.Empty<object>());

            var fluids = await handler.GetFluidsAsync(gid);

            return Json(fluids.Select(x => new { id = x.Id, code = x.Code, name = x.Name }));
        }

        // ✅ Ajax: Group + Fluid (opsiyonel) seçilince Product’ları getir
        [HttpGet]
        public async Task<IActionResult> ProductsByGroupAndFluid(string groupId, string? fluidId)
        {
            if (!Guid.TryParse(groupId, out var gid)) return BadRequest();

            Guid? fid = null;
            if (!string.IsNullOrWhiteSpace(fluidId) && Guid.TryParse(fluidId, out var parsed))
                fid = parsed;

            var groups = await _lookupService.GetSProductGroupsAsync();
            var group = groups.FirstOrDefault(x => x.Id == gid);
            if (group == null)
                return Json(Array.Empty<object>());

            var handler = _handlerFactory.GetByGroupCode(group.Code);

            // fluid zorunlu değilse fid null kalabilir
            var products = await handler.GetProductsAsync(gid, fid);

            return Json(products.Select(x => new { id = x.Id, code = x.Code, name = x.Name }));
        }

        // ✅ Ajax: Product seçilince Feature + Values getir
        [HttpGet]
        public async Task<IActionResult> FeaturesByProduct(string sProductId, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(sProductId, out var pid))
                return BadRequest();

            var data = await _featureQueryService.GetProductFeaturesAsync(pid, cancellationToken);

            return Json(data.Select(f => new
            {
                featureId = f.FeatureId,
                code = f.Code,
                name = f.Name,
                isRequired = f.IsRequired,
                sortOrder = f.SortOrder,
                values = f.Values.Select(v => new
                {
                    valueId = v.ValueId,
                    code = v.Code,
                    name = v.Name,
                    sortOrder = v.SortOrder
                })
            }));
        }

        private async Task FillLookups(SStockCodeGenerateVm vm)
        {
            var groups = await _lookupService.GetSProductGroupsAsync();
            vm.Groups = groups
                .Select(x => new SelectListItem($"{x.Code} - {x.Name}", x.Id.ToString()))
                .ToList();

            vm.Fluids = new System.Collections.Generic.List<SelectListItem>();
            vm.Products = new System.Collections.Generic.List<SelectListItem>();

            if (vm.SProductGroupId == Guid.Empty)
            {
                vm.PrefixRules = new System.Collections.Generic.List<SelectListItem>();
                return;
            }

            var group = groups.FirstOrDefault(x => x.Id == vm.SProductGroupId);
            if (group == null)
            {
                vm.PrefixRules = new System.Collections.Generic.List<SelectListItem>();
                return;
            }

            var handler = _handlerFactory.GetByGroupCode(group.Code);

            // Fluids: sadece gerekiyorsa doldur
            if (handler.RequiresFluid)
            {
                var fluids = await handler.GetFluidsAsync(vm.SProductGroupId);
                vm.Fluids = fluids
                    .Select(x => new SelectListItem($"{x.Code} - {x.Name}", x.Id.ToString()))
                    .ToList();
            }

            // Products: fluid zorunlu değilse null gönder
            Guid? fluidId = handler.RequiresFluid
                ? (vm.FluidId == Guid.Empty ? null : vm.FluidId)
                : null;

            var products = await handler.GetProductsAsync(vm.SProductGroupId, fluidId);
            vm.Products = products
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            vm.PrefixRules = new System.Collections.Generic.List<SelectListItem>();
        }
    }
}
