using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using MVC.ProductManagement.Application.DTOs.StockCodes.SB;
using MVC.ProductManagement.Application.Services.StockCodes.SB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        // 🔹 Factory buradan "B" seçildiğini anlar
        public string GroupCode => "B";

        // 🔹 SB'de akışkan zorunlu
        public bool RequiresFluid => true;

        // 🔹 Tek ekranda akışkan dropdown'u buradan doluyor
        public async Task<IReadOnlyList<(Guid Id, string Code, string Name)>> GetFluidsAsync(Guid groupId)
        {
            var fluids = await _sbService.GetFluidsAsync();
            return fluids.Select(x => (x.Id, x.Code, x.Name)).ToList();
        }

        // 🔹 SB ürünleri (SBA0, SBB0...) buradan gelir
        public async Task<IReadOnlyList<(Guid Id, string Code, string Name)>> GetProductsAsync(Guid groupId, Guid? fluidId)
        {
            var products = await _sbService.GetSbProductsAsync(groupId);
            return products.Select(x => (x.Id, x.Code, x.Name)).ToList();
        }

        // 🔹 Generate butonuna basılınca burası çalışır
        public async Task<StockCodeGenerateResultDto> GenerateAsync(
            Guid groupId,
            Guid? fluidId,
            Guid productId)
        {
            if (fluidId == null || fluidId == Guid.Empty)
                throw new InvalidOperationException("SB grubu için akışkan seçilmelidir.");

            var result = await _sbService.GenerateSbAsync(new SbStockCodeGenerateRequestDto
            {
                FluidId = fluidId.Value,
                SProductGroupId = groupId,
                SProductId = productId
            });

            // 🔹 Tek ekran ortak DTO'ya dönüyoruz
            return new StockCodeGenerateResultDto
            {
                StockCode8 = result.StockCode8,
                Description = result.Description,
                AlreadyExists = result.AlreadyExists
            };
        }
    }
}
