using MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.Common
{
    public interface IStockCardDatasheetService
    {
        /// <summary>
        /// Stok kartına ait t��m datasheet'leri getir
        /// </summary>
        Task<IReadOnlyList<DatasheetDto>> GetDatasheetsByStockCardAsync(
            Guid stockCardId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Datasheet detayını getir
        /// </summary>
        Task<DatasheetDto> GetDatasheetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Datasheet yükle
        /// </summary>
        Task<DatasheetDto> UploadDatasheetAsync(
            DatasheetUploadDto uploadDto,
            string userName,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Datasheet sil (fiziksel dosya + DB kaydı)
        /// </summary>
        Task<bool> DeleteDatasheetAsync(
            Guid id,
            string userName,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Dosya içeriğini indir
        /// </summary>
        Task<(byte[] Content, string FileName, string ContentType)> DownloadDatasheetAsync(
            Guid id,
            CancellationToken cancellationToken = default);
    }
}
