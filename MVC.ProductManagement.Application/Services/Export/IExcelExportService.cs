using MVC.ProductManagement.Application.DTOs.StockCodes.SA;
using MVC.ProductManagement.Application.DTOs.StockCodes.SB;
using MVC.ProductManagement.Application.DTOs.StockCodes.SC;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.Export
{
    public interface IExcelExportService
    {
        Task<byte[]> ExportSAStockCardsAsync(List<SAStockCardListDto> stockCards);
        Task<byte[]> ExportSAStockCardDetailAsync(SAStockCardDetailDto detail);
        Task<byte[]> ExportSBStockCardsAsync(List<SBStockCardListDto> stockCards);
        Task<byte[]> ExportSBStockCardDetailAsync(SBStockCardDetailDto detail);
        Task<byte[]> ExportSCStockCardsAsync(List<SCStockCardListDto> stockCards);
        Task<byte[]> ExportSCStockCardDetailAsync(SCStockCardDetailDto detail);
    }
}