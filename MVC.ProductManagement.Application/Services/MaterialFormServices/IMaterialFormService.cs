using MVC.ProductManagement.Application.DTOs.MaterialFormDTOs;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.MaterialFormServices
{
    public interface IMaterialFormService
    {
        Task<List<MaterialFormListDto>> GetByMaterialIdAsync(Guid materialId);
        Task<List<MaterialFormListDto>> GetByFormTypeAsync(MaterialFormType formType);
        Task<List<MaterialFormListDto>> GetAllAsync();

        Task<MaterialFormDetailDto?> GetByIdAsync(Guid id);
        Task<MaterialFormDetailDto> CreateAsync(MaterialFormCreateDto dto);
        Task<MaterialFormDetailDto> UpdateAsync(MaterialFormUpdateDto dto);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<MaterialForm>> GetAllWithMaterialAsync();
        Task<MaterialForm> GetByIdWithMaterialAsync(Guid id);
    }
}
