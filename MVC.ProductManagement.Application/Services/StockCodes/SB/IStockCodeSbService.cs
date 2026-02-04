// Dosya: MVC.ProductManagement.Application/Services/StockCodes/SB/IStockCodeSbService.cs

using MVC.ProductManagement.Application.DTOs.StockCodes.S;
using MVC.ProductManagement.Application.DTOs.StockCodes.SB;
using System.Threading;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.SB
{
    /// <summary>
    /// SB (Somunlar) stok kodu üretimi.
    /// Neden ayrı interface?
    /// - Tek ekranda handler bu servisi çağıracak.
    /// - İleride SB'ye özel "özellik entity'leri" (diş standardı, kaplama vb.) eklenince
    ///   SB'nin Generate akışı bozulmadan genişletilecek.
    /// </summary>
    public interface IStockCodeSbService
    {
        Task<IReadOnlyList<LookupDto>> GetFluidsAsync(CancellationToken cancellationToken = default);

        Task<IReadOnlyList<LookupDto>> GetSbProductsAsync(
            Guid sProductGroupId,
            CancellationToken cancellationToken = default);

        Task<SbStockCodeGenerateResultDto> GenerateSbAsync(
            SbStockCodeGenerateRequestDto request,
            CancellationToken cancellationToken = default);
    }
}
