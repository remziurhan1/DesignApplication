using MVC.ProductManagement.Application.DTOs.AllowableStressDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.AllowableStressServices
{
    public interface IAllowableStressService
    {
        Task<List<AllowableStressListDto>> GetByMaterialFormIdAsync(Guid materialFormId);
        Task<AllowableStressDetailDto?> GetByIdAsync(Guid id);
        Task<AllowableStressDetailDto?> GetByConditionsAsync(Guid materialFormId, double temperature);
        Task<AllowableStressDetailDto> CreateAsync(AllowableStressCreateDto dto);
        Task<AllowableStressDetailDto> UpdateAsync(AllowableStressUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}
