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
    }
}
