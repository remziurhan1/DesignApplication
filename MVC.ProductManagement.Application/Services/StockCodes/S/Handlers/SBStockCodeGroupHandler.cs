using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using MVC.ProductManagement.Application.DTOs.StockCodes.SB;
using MVC.ProductManagement.Application.Services.StockCodes.SB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.S.Handlers
{
    public class SBStockCodeGroupHandler : ISStockCodeGroupHandler
    {
        private readonly IStockCodeSbService _sbService;

        public SBStockCodeGroupHandler(IStockCodeSbService sbService)
        {
            _sbService = sbService;
        }

        public string GroupCode => "B";

        // SB’de akışkan zorunlu (senin mevcut tasarımına göre)
        public bool RequiresFluid => true;

        public async Task<IReadOnlyList<(Guid Id, string Code, string Name)>> GetFluidsAsync(Guid groupId)
        {
            var fluids = await _sbService.GetFluidsAsync();
            return fluids.Select(x => (x.Id, x.Code, x.Name)).ToList();
        }

        public async Task<IReadOnlyList<(Guid Id, string Code, string Name)>> GetProductsAsync(Guid groupId, Guid? fluidId)
        {
            // SB ürünleri akışkandan bağımsızsa fluidId kullanılmayabilir
            var products = await _sbService.GetSbProductsAsync(groupId);
            return products.Select(x => (x.Id, x.Code, x.Name)).ToList();
        }

        public async Task<StockCodeGenerateResultDto> GenerateAsync(
            Guid groupId,
            Guid? fluidId,
            Guid productId,
            Dictionary<Guid, Guid>? selectedFeatureValues = null,
            CancellationToken cancellationToken = default)
        {
            if (fluidId == null || fluidId == Guid.Empty)
                throw new InvalidOperationException("SB grubu için akışkan seçilmelidir.");

            // Not: SB tarafında feature kullanılmıyor; selectedFeatureValues ignore edilir.

            // Eğer GenerateSbAsync cancellationToken almıyorsa 2. parametreyi kaldır.
            var result = await _sbService.GenerateSbAsync(new SbStockCodeGenerateRequestDto
            {
                FluidId = fluidId.Value,
                SProductGroupId = groupId,
                SProductId = productId
            }, cancellationToken);

            return new StockCodeGenerateResultDto
            {
                StockCode8 = result.StockCode8,
                Description = result.Description,
                AlreadyExists = result.AlreadyExists
            };
        }
    }
}
