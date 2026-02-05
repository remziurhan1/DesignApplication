using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using MVC.ProductManagement.Application.DTOs.StockCodes.SA;
using MVC.ProductManagement.Application.Services.StockCodes.S;
using MVC.ProductManagement.Application.Services.StockCodes.SA;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MVC.ProductManagement.Application.Services.StockCodes.S.Handlers
{
    public class SAStockCodeGroupHandler : ISStockCodeGroupHandler
    {
        private readonly IStockCodeService _lookupService;
        private readonly IStockCodeSaService _saService;

        public SAStockCodeGroupHandler(IStockCodeService lookupService, IStockCodeSaService saService)
        {
            _lookupService = lookupService;
            _saService = saService;
        }

        public string GroupCode => "A";
        public bool RequiresFluid => false;

        public Task<IReadOnlyList<(Guid Id, string Code, string Name)>> GetFluidsAsync(Guid groupId)
        {
            // ✅ SA için akışkan kullanılmıyor
            return Task.FromResult<IReadOnlyList<(Guid, string, string)>>(Array.Empty<(Guid, string, string)>());
        }

        public async Task<IReadOnlyList<(Guid Id, string Code, string Name)>> GetProductsAsync(Guid groupId, Guid? fluidId)
        {
            var products = await _saService.GetSaProductsAsync(groupId);
            return products.Select(x => (x.Id, x.Code, x.Name)).ToList();
        }

        public async Task<StockCodeGenerateResultDto> GenerateAsync(
            Guid groupId,
            Guid? fluidId,
            Guid productId,
            Dictionary<Guid, Guid>? selectedFeatureValues = null,
            CancellationToken cancellationToken = default)
        {
            // ✅ SA’da kullanıcıdan akışkan seçtirmiyoruz.
            // StockCard zorunlu FluidId olduğundan DB için bir default veriyoruz.
            var defaultFluid = (await _lookupService.GetAllFluidsAsync(cancellationToken)).FirstOrDefault();
            if (defaultFluid == null)
                throw new InvalidOperationException("Sistemde akışkan tanımı yok.");

            var result = await _saService.GenerateSaAsync(new SaStockCodeGenerateRequestDto
            {
                FluidId = defaultFluid.Id,
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
