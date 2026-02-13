using MVC.ProductManagement.Application.DTOs.StockCodes.SA;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.Export
{
    /// <summary>
    /// Excel export service interface
    /// </summary>
    public interface IExcelExportService
    {
        /// <summary>
        /// SA Stok kodlarını Excel'e export et
        /// </summary>
        Task<byte[]> ExportSAStockCardsAsync(List<SAStockCardListDto> stockCards);

        /// <summary>
        /// SA Stok kodu detayını Excel'e export et
        /// </summary>
        Task<byte[]> ExportSAStockCardDetailAsync(SAStockCardDetailDto detail);
    }
}