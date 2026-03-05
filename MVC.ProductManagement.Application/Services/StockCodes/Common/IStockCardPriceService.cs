using MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.Common
{
    public interface IStockCardPriceService
    {
        /// <summary>
        /// Stok kartına ait aktif fiyatı getir
        /// </summary>
        Task<ActivePriceDto> GetActivePriceAsync(
            Guid stockCardId,
            string currency = "EUR",
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Stok kartına ait fiyat geçmişini getir
        /// </summary>
        Task<IReadOnlyList<PriceDto>> GetPriceHistoryAsync(
            Guid stockCardId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Yeni fiyat ekle
        /// </summary>
        Task<PriceDto> CreatePriceAsync(
            PriceCreateDto createDto,
            string userName,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Fiyat güncelle
        /// </summary>
        Task<PriceDto> UpdatePriceAsync(
            PriceUpdateDto updateDto,
            string userName,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Fiyatı pasifleştir
        /// </summary>
        Task<bool> DeactivatePriceAsync(
            Guid id,
            string userName,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Belirli tarihteki fiyatı getir
        /// </summary>
        Task<PriceDto> GetPriceAtDateAsync(
            Guid stockCardId,
            DateTime date,
            string currency = "EUR",
            CancellationToken cancellationToken = default);

        // ✅ Soft Delete
        Task<bool> DeletePriceAsync(
            Guid id,
            string userName,
            CancellationToken cancellationToken = default);
        Task<bool> ReactivatePriceAsync(Guid id, string userName, CancellationToken cancellationToken = default);

    }
}
