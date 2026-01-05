using MVC.ProductManagement.Application.DTOs.YieldStrengthDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.IYieldStrengthServices
{
    public interface IYieldStrengthService
    {
        Task<List<YieldStrengthListDto>> GetByMaterialFormIdAsync(Guid materialFormId);
        Task<YieldStrengthDetailDto?> GetByIdAsync(Guid id);
        Task<YieldStrengthDetailDto?> GetByConditionsAsync(Guid materialFormId, double temperature, double thickness);
        // 🔹 Yeni: Çift kalınlık için interpolasyon
        Task<(YieldStrengthDetailDto? Shell, YieldStrengthDetailDto? Head)>
            GetByConditionsDualAsync(Guid materialFormId, double temperature, double thicknessShell, double thicknessHead);

        Task<YieldStrengthDetailDto> CreateAsync(YieldStrengthCreateDto dto);
        Task<YieldStrengthDetailDto> UpdateAsync(YieldStrengthUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}
