using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using MVC.ProductManagement.Application.DTOs.StockCodes.S;
using MVC.ProductManagement.Application.Services.StockCodes.S;

namespace MVC.ProductManagement.Application.Services.StockCodes.S.Handlers
{
    public class SFStockCodeGroupHandler : ISStockCodeGroupHandler
    {
        private readonly IStockCodeService _sfService;

        public SFStockCodeGroupHandler(IStockCodeService sfService)
        {
            _sfService = sfService;
        }

        public string GroupCode => "F";
        public bool RequiresFluid => true;

        public async Task<IReadOnlyList<(Guid Id, string Code, string Name)>> GetFluidsAsync(Guid groupId)
        {
            var fluids = await _sfService.GetFluidsByGroupAsync(groupId);
            return fluids.Select(x => (x.Id, x.Code, x.Name)).ToList();
        }

        public async Task<IReadOnlyList<(Guid Id, string Code, string Name)>> GetProductsAsync(Guid groupId, Guid? fluidId)
        {
            if (fluidId == null || fluidId == Guid.Empty)
                return Array.Empty<(Guid, string, string)>();

            var products = await _sfService.GetSProductsAsync(groupId, fluidId.Value);
            return products.Select(x => (x.Id, x.Code, x.Name)).ToList();
        }

        public async Task<StockCodeGenerateResultDto> GenerateAsync(Guid groupId, Guid? fluidId, Guid productId)
        {
            if (fluidId == null || fluidId == Guid.Empty)
                throw new InvalidOperationException("Akışkan seçiniz.");

            var result = await _sfService.GenerateSAsync(new SStockCodeGenerateRequestDto
            {
                FluidId = fluidId.Value,
                SProductGroupId = groupId,
                SProductId = productId
            });

            return new StockCodeGenerateResultDto
            {
                StockCode8 = result.StockCode8,
                Description = result.Description,
                AlreadyExists = result.AlreadyExists
            };
        }
    }
}
