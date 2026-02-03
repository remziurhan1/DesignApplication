using MVC.ProductManagement.Application.DTOs.TankRequestDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.TankRequestServices
{
    public interface ITankRequestService
    {
        Task<TankRequestDetailDto> GetByIdAsync(Guid id);
        Task<List<TankRequestDetailDto>> GetAllAsync();
        Task<TankRequestDetailDto> CreateAsync(TankRequestCreateDto dto);
        Task<TankRequestDetailDto> UpdateAsync(TankRequestUpdateDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
