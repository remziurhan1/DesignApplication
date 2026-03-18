using MVC.ProductManagement.Application.DTOs.EN13458DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.EN13458CalculationServices
{
    public interface IEN13458CalculationServices
    {
        Task<EN13458ResultDTO> CalculateAsync(EN13458CalculateDTO dto);
        Task<EN13458ResultDTO> SaveAsync(EN13458ResultDTO result, string createdBy = "System");
        Task<EN13458ResultDTO?> GetByIdAsync(Guid id);
        Task<List<EN13458ResultDTO>> GetAllAsync();
        Task<EN13458MaterialCostTableDTO> BuildMaterialCostTableAsync(EN13458ResultDTO result);
        Task<List<EN13458CostAnalysisSummaryDTO>> GetCostAnalysesAsync(Guid calculationId);
        Task<EN13458MaterialCostTableDTO?> GetCostAnalysisAsync(Guid calculationId, Guid? costAnalysisId = null);
        Task<EN13458MaterialCostTableDTO> CreateCostAnalysisAsync(Guid calculationId, string analysisName, string notes = "", string createdBy = "System");
        Task<EN13458MaterialCostTableDTO> CreateCostAnalysisRevisionAsync(Guid calculationId, Guid sourceCostAnalysisId, string analysisName, string notes = "", string createdBy = "System");
        Task UpdateCostAnalysisItemAsync(Guid calculationId, Guid costAnalysisId, Guid costAnalysisItemId, Guid? generatedStockCodeId, bool useManualUnitPrice, double? manualUnitPrice, string modifiedBy = "System");
        Task BulkUpdateCostAnalysisItemsAsync(Guid calculationId, Guid costAnalysisId, IReadOnlyCollection<(Guid CostAnalysisItemId, Guid? GeneratedStockCodeId, bool UseManualUnitPrice, double? ManualUnitPrice)> items, string modifiedBy = "System");
        Task AddManualStockCodeCostAsync(Guid calculationId, Guid costAnalysisId, Guid generatedStockCodeId, double quantity, bool useManualUnitPrice, double? manualUnitPrice, string createdBy = "System");
        Task AddManualStockGroupCostAsync(Guid calculationId, Guid costAnalysisId, Guid stockProductGroupId, double multiplier, string createdBy = "System");
        Task RemoveCostAnalysisItemAsync(Guid calculationId, Guid costAnalysisId, Guid costAnalysisItemId);
    }
}
