using MVC.ProductManagement.Application.DTOs.MaterialDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.MaterialServices
{
    public interface IMaterialService
    {
        Task<List<MaterialListDto>> GetAllAsync();
        Task<MaterialDetailDto?> GetByIdAsync(Guid id);
        Task<MaterialDetailDto?> GetByNameAsync(string name);
        Task<MaterialDetailDto> CreateAsync(MaterialCreateDto dto);
        Task<MaterialDetailDto> UpdateAsync(MaterialUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}
