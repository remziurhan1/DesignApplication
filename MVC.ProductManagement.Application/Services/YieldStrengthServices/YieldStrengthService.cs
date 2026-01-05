using MVC.ProductManagement.Application.DTOs.YieldStrengthDTOs;
using MVC.ProductManagement.Application.Services.IYieldStrengthServices;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Infrastructure.Repositories.YieldStrengthRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Interfaces.Services
{
    public class YieldStrengthService : IYieldStrengthService
    {
        private readonly IYieldStrengthRepository _yieldStrengthRepository;

        public YieldStrengthService(IYieldStrengthRepository yieldStrengthRepository)
        {
            _yieldStrengthRepository = yieldStrengthRepository;
        }

        public async Task<List<YieldStrengthListDto>> GetByMaterialFormIdAsync(Guid materialFormId)
        {
            var list = await _yieldStrengthRepository.GetByMaterialFormIdAsync(materialFormId);
            return list.Select(y => new YieldStrengthListDto
            {
                Id = y.Id,
                MaterialFormId = y.MaterialFormId,
                Temperature = y.Temperature,
                ThicknessMin = y.ThicknessMin,
                ThicknessMax = y.ThicknessMax,
                Rp02 = y.Rp02,
                Rm = y.Rm,
                MaterialName=y.MaterialForm.Material.Name,
                MaterialFormName = $"{y.MaterialForm.FormType} "
            }).ToList();
        }

        public async Task<YieldStrengthDetailDto?> GetByIdAsync(Guid id)
        {
            var entity = await _yieldStrengthRepository.GetByIdAsync(id);
            if (entity == null) return null;

            return new YieldStrengthDetailDto
            {
                Id = entity.Id,
                MaterialFormId = entity.MaterialFormId,
                Temperature = entity.Temperature,
                ThicknessMin = entity.ThicknessMin,
                ThicknessMax = entity.ThicknessMax,
                Rp02 = entity.Rp02,
                Rm = entity.Rm
            };
        }

        public async Task<(YieldStrengthDetailDto? Shell, YieldStrengthDetailDto? Head)>
    GetByConditionsDualAsync(Guid materialFormId, double temperature, double thicknessShell, double thicknessHead)
        {
            // Gövde için interpolasyon
            var shell = await GetByConditionsAsync(materialFormId, temperature, thicknessShell);

            // Bombe için interpolasyon
            var head = await GetByConditionsAsync(materialFormId, temperature, thicknessHead);

            return (shell, head);
        }


        public async Task<YieldStrengthDetailDto?> GetByConditionsAsync(Guid materialFormId, double temperature, double thickness)
        {
            const double EPS = 1e-9;

            // 1) Aynı sıcaklık + kalınlıkta doğrudan kayıt varsa onu dön
            var exact = await _yieldStrengthRepository.GetByConditionsAsync(materialFormId, temperature, thickness);
            if (exact != null)
            {
                return new YieldStrengthDetailDto
                {
                    Id = exact.Id,
                    MaterialFormId = exact.MaterialFormId,
                    Temperature = exact.Temperature,
                    ThicknessMin = exact.ThicknessMin,
                    ThicknessMax = exact.ThicknessMax,
                    Rp02 = exact.Rp02,
                    Rm = exact.Rm
                };
            }

            // 2) Seçilen formun tüm noktalarını çek
            var candidates = await _yieldStrengthRepository.GetByMaterialFormIdAsync(materialFormId);
            if (candidates == null || !candidates.Any()) return null;

            // 3) Kalınlık bandını belirle (yarı-açık: [min, max), yalnızca EN BÜYÜK max için <=)
            var globalMax = candidates.Max(c => c.ThicknessMax);

            var band = candidates
                .Where(c =>
                    // [min, max)
                    (c.ThicknessMin - EPS <= thickness && thickness < c.ThicknessMax - EPS)
                    // son bandın üst sınırında eşitse dahil et
                    || (Math.Abs(thickness - c.ThicknessMax) < EPS && Math.Abs(c.ThicknessMax - globalMax) < EPS)
                )
                .OrderBy(c => c.Temperature)
                .ToList();

            if (band.Count == 0) return null; // girilen kalınlık hiçbir banda düşmedi

            // 4) Aynı band içinde alt/üst sıcaklık komşularını bul (eşitlikleri kapsa)
            var lower = band.LastOrDefault(c => c.Temperature <= temperature);
            var upper = band.FirstOrDefault(c => c.Temperature >= temperature);

            if (lower == null || upper == null) return null; // sıcaklık bandın aralığı dışında

            // 5) Tam eşleşme (üst=alt) ise direkt dön
            if (Math.Abs(upper.Temperature - lower.Temperature) < EPS)
            {
                return new YieldStrengthDetailDto
                {
                    Id = Guid.Empty,
                    MaterialFormId = materialFormId,
                    Temperature = temperature,
                    ThicknessMin = lower.ThicknessMin,
                    ThicknessMax = lower.ThicknessMax,
                    Rp02 = lower.Rp02,
                    Rm = lower.Rm
                };
            }

            // 6) Lineer interpolasyon
            double t0 = lower.Temperature;
            double t1 = upper.Temperature;
            double alpha = (temperature - t0) / (t1 - t0);

            double rp02 = lower.Rp02 + (upper.Rp02 - lower.Rp02) * alpha;
            double rm = lower.Rm + (upper.Rm - lower.Rm) * alpha;

            return new YieldStrengthDetailDto
            {
                Id = Guid.Empty, // DB kaydı değil, hesap sonucu
                MaterialFormId = materialFormId,
                Temperature = temperature,
                ThicknessMin = lower.ThicknessMin, // band bilgisi
                ThicknessMax = lower.ThicknessMax,
                Rp02 = rp02,
                Rm = rm
            };
        }




        public async Task<YieldStrengthDetailDto> CreateAsync(YieldStrengthCreateDto dto)
        {
            var entity = new YieldStrength
            {
                Id = Guid.NewGuid(),
                MaterialFormId = dto.MaterialFormId,
                Temperature = dto.Temperature,
                ThicknessMin = dto.ThicknessMin,
                ThicknessMax = dto.ThicknessMax,
                Rp02 = dto.Rp02,
                Rm = dto.Rm
            };

            await _yieldStrengthRepository.AddAsync(entity);
            await _yieldStrengthRepository.SaveChangeAsync();

            return new YieldStrengthDetailDto
            {
                Id = entity.Id,
                MaterialFormId = entity.MaterialFormId,
                Temperature = entity.Temperature,
                ThicknessMin = entity.ThicknessMin,
                ThicknessMax = entity.ThicknessMax,
                Rp02 = entity.Rp02,
                Rm = entity.Rm
            };
        }

        public async Task<YieldStrengthDetailDto> UpdateAsync(YieldStrengthUpdateDto dto)
        {
            var entity = await _yieldStrengthRepository.GetByIdAsync(dto.Id);
            if (entity == null) throw new Exception("YieldStrength not found");

            entity.MaterialFormId = dto.MaterialFormId;
            entity.Temperature = dto.Temperature;
            entity.ThicknessMin = dto.ThicknessMin;
            entity.ThicknessMax = dto.ThicknessMax;
            entity.Rp02 = dto.Rp02;
            entity.Rm = dto.Rm;

            await _yieldStrengthRepository.UpdateAsync(entity);
            await _yieldStrengthRepository.SaveChangeAsync();

            return new YieldStrengthDetailDto
            {
                Id = entity.Id,
                MaterialFormId = entity.MaterialFormId,
                Temperature = entity.Temperature,
                ThicknessMin = entity.ThicknessMin,
                ThicknessMax = entity.ThicknessMax,
                Rp02 = entity.Rp02,
                Rm = entity.Rm
            };
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _yieldStrengthRepository.GetByIdAsync(id);
            if (entity == null) throw new Exception("YieldStrength not found");

            await _yieldStrengthRepository.DeleteAsync(entity);
            await _yieldStrengthRepository.SaveChangeAsync();
        }
    }
}
