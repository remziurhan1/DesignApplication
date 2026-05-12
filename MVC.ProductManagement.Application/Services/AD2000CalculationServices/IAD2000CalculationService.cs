using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MVC.ProductManagement.Application.DTOs.AD2000DTOs;

namespace MVC.ProductManagement.Application.Services.AD2000CalculationServices
{
    public interface IAD2000CalculationService
    {
        Task<AD2000ResultDTO> CalculateAsync(AD2000CalculateDTO dto);
        Task<AD2000ResultDTO> SaveAsync(AD2000ResultDTO result, string createdBy = "System");
        Task<AD2000ResultDTO?> GetByIdAsync(Guid id);
        Task<List<AD2000ResultDTO>> GetAllAsync();
        Task<bool> DeleteAsync(Guid id);
        Task<AD2000MaterialCostTableDTO> BuildMaterialCostTableAsync(AD2000ResultDTO result);
        Task<List<AD2000CostAnalysisSummaryDTO>> GetCostAnalysesAsync(Guid calculationId);
        Task<AD2000MaterialCostTableDTO?> GetCostAnalysisAsync(Guid calculationId, Guid? costAnalysisId = null);
        Task<AD2000MaterialCostTableDTO> CreateCostAnalysisAsync(Guid calculationId, string analysisName, string notes = "", string createdBy = "System");
        Task<AD2000MaterialCostTableDTO> CreateCostAnalysisRevisionAsync(Guid calculationId, Guid sourceCostAnalysisId, string analysisName, string notes = "", string createdBy = "System");
        Task UpdateCostAnalysisItemAsync(Guid calculationId, Guid costAnalysisId, Guid costAnalysisItemId, Guid? generatedStockCodeId, double? quantity, bool useManualUnitPrice, double? manualUnitPrice, string modifiedBy = "System");
        Task BulkUpdateCostAnalysisItemsAsync(Guid calculationId, Guid costAnalysisId, IReadOnlyCollection<(Guid CostAnalysisItemId, Guid? GeneratedStockCodeId, double? Quantity, bool UseManualUnitPrice, double? ManualUnitPrice)> items, string modifiedBy = "System");
        Task AddManualStockCodeCostAsync(Guid calculationId, Guid costAnalysisId, Guid generatedStockCodeId, double quantity, bool useManualUnitPrice, double? manualUnitPrice, string createdBy = "System");
        Task AddManualStockGroupCostAsync(Guid calculationId, Guid costAnalysisId, Guid stockProductGroupId, double multiplier, string createdBy = "System");
        Task RemoveCostAnalysisItemAsync(Guid calculationId, Guid costAnalysisId, Guid costAnalysisItemId);
        Task UpdateBombeLaborAsync(Guid calculationId, Guid costAnalysisId, Guid? headBombeLaborRateId, string modifiedBy = "System");
        Task<AD2000SalesPriceDTO?> GetSalesPriceAsync(Guid calculationId, Guid costAnalysisId);
        Task<AD2000SalesPriceDTO> UpsertSalesPriceAsync(Guid calculationId, Guid costAnalysisId, Guid laborRateId, double laborHours, Guid gugHourlyRateId, Guid financeOverheadRateId, Guid generalManagementOverheadRateId, double profitPercentage, string modifiedBy = "System");
    }
}
