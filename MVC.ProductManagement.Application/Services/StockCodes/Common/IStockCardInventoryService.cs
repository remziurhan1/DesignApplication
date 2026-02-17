using MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.Common
{
    public interface IStockCardInventoryService
    {
        /// <summary>
        /// Mevcut stok miktarını getir
        /// </summary>
        Task<CurrentInventoryDto> GetCurrentInventoryAsync(
            Guid stockCardId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Stok hareketlerini getir
        /// </summary>
        Task<IReadOnlyList<InventoryDto>> GetInventoryMovementsAsync(
            Guid stockCardId,
            DateTime? startDate = null,
            DateTime? endDate = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Stok hareketi oluştur (giriş/çıkış)
        /// </summary>
        Task<InventoryDto> CreateMovementAsync(
            InventoryMovementCreateDto createDto,
            string userName,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// İlk stok girişi
        /// </summary>
        Task<InventoryDto> InitialStockAsync(
            Guid stockCardId,
            int quantity,
            string location,
            string userName,
            CancellationToken cancellationToken = default);
    }
}
