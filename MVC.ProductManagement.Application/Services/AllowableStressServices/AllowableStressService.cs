using MVC.ProductManagement.Application.DTOs.AllowableStressDTOs;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Infrastructure.Repositories.IAllowableStressRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.AllowableStressServices
{
    public class AllowableStressService : IAllowableStressService
    {
        private readonly IAllowableStressRepository _allowableStressRepository;

        public AllowableStressService(IAllowableStressRepository allowableStressRepository)
        {
            _allowableStressRepository = allowableStressRepository;
        }

        public async Task<List<AllowableStressListDto>> GetByMaterialFormIdAsync(Guid materialFormId)
        {
            var list = await _allowableStressRepository.GetByMaterialFormIdAsync(materialFormId);
            return list.Select(a => new AllowableStressListDto
            {
                Id = a.Id,
                MaterialFormId = a.MaterialFormId,
                Temperature = a.Temperature,
                Stress = a.Stress
            }).ToList();
        }

        public async Task<AllowableStressDetailDto?> GetByIdAsync(Guid id)
        {
            var entity = await _allowableStressRepository.GetByIdAsync(id);
            if (entity == null) return null;

            return new AllowableStressDetailDto
            {
                Id = entity.Id,
                MaterialFormId = entity.MaterialFormId,
                Temperature = entity.Temperature,
                Stress = entity.Stress
            };
        }

        public async Task<AllowableStressDetailDto?> GetByConditionsAsync(Guid materialFormId, double temperature)
        {
            var exact = await _allowableStressRepository.GetByConditionsAsync(materialFormId, temperature);
            if (exact != null)
            {
                return new AllowableStressDetailDto
                {
                    Id = exact.Id,
                    MaterialFormId = exact.MaterialFormId,
                    Temperature = exact.Temperature,
                    Stress = exact.Stress
                };
            }

            var candidates = await _allowableStressRepository.GetByMaterialFormIdAsync(materialFormId);
            var ordered = candidates.OrderBy(c => c.Temperature).ToList();

            if (ordered.Count < 2) return null;

            var lower = ordered.LastOrDefault(c => c.Temperature < temperature);
            var upper = ordered.FirstOrDefault(c => c.Temperature > temperature);

            if (lower == null || upper == null) return null;

            double stress = lower.Stress + (upper.Stress - lower.Stress) *
                            (temperature - lower.Temperature) / (upper.Temperature - lower.Temperature);

            return new AllowableStressDetailDto
            {
                Id = Guid.Empty,
                MaterialFormId = materialFormId,
                Temperature = temperature,
                Stress = stress
            };
        }


        public async Task<AllowableStressDetailDto> CreateAsync(AllowableStressCreateDto dto)
        {
            var entity = new AllowableStress
            {
                Id = Guid.NewGuid(),
                MaterialFormId = dto.MaterialFormId,
                Temperature = dto.Temperature,
                Stress = dto.Stress
            };

            await _allowableStressRepository.AddAsync(entity);
            await _allowableStressRepository.SaveChangeAsync();

            return new AllowableStressDetailDto
            {
                Id = entity.Id,
                MaterialFormId = entity.MaterialFormId,
                Temperature = entity.Temperature,
                Stress = entity.Stress
            };
        }

        public async Task<AllowableStressDetailDto> UpdateAsync(AllowableStressUpdateDto dto)
        {
            var entity = await _allowableStressRepository.GetByIdAsync(dto.Id);
            if (entity == null) throw new Exception("AllowableStress not found");

            entity.MaterialFormId = dto.MaterialFormId;
            entity.Temperature = dto.Temperature;
            entity.Stress = dto.Stress;

            await _allowableStressRepository.UpdateAsync(entity);
            await _allowableStressRepository.SaveChangeAsync();

            return new AllowableStressDetailDto
            {
                Id = entity.Id,
                MaterialFormId = entity.MaterialFormId,
                Temperature = entity.Temperature,
                Stress = entity.Stress
            };
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _allowableStressRepository.GetByIdAsync(id);
            if (entity == null) throw new Exception("AllowableStress not found");

            await _allowableStressRepository.DeleteAsync(entity);
            await _allowableStressRepository.SaveChangeAsync();
        }
    }
}
