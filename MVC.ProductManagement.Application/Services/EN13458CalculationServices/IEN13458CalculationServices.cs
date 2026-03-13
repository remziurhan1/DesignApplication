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
        Task<EN13458MaterialCostTableDTO?> GetSavedMaterialCostTableAsync(Guid calculationId);
    }
}
