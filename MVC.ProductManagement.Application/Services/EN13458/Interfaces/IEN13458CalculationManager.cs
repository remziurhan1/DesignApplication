using MVC.ProductManagement.Application.DTOs.EN13458DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.EN13458.Interfaces
{
    public interface IEN13458CalculationManager
    {
        Task<EN13458ResultDTO> CalculateAsync(EN13458CalculateDTO input);
        Task<EN13458ResultDTO> SaveAsync(EN13458ResultDTO result, string createdBy = "System");
        Task<EN13458ResultDTO?> GetByIdAsync(Guid id);
        Task<List<EN13458ResultDTO>> GetAllAsync();
    }
}
