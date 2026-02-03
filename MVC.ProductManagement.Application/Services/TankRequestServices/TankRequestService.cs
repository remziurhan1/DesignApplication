using MVC.ProductManagement.Application.DTOs.TankRequestDTOs;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Infrastructure.Repositories.DesignStandardRepository;
using MVC.ProductManagement.Infrastructure.Repositories.GasTypeRepositories;
using MVC.ProductManagement.Infrastructure.Repositories.IProductCodeRepositories;
using MVC.ProductManagement.Infrastructure.Repositories.TankRequestRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.TankRequestServices
{
    public class TankRequestService : ITankRequestService
    {
        private readonly ITankRequestRepository _tankRequestRepository;
        private readonly IGasTypeRepository _gasTypeRepository;
        private readonly IDesignStandardRepository _designStandardRepository;
        private readonly IProductCodeRepository _productCodeRepository;

        public TankRequestService(
            ITankRequestRepository tankRequestRepository,
            IGasTypeRepository gasTypeRepository,
            IDesignStandardRepository designStandardRepository,
            IProductCodeRepository productCodeRepository)
        {
            _tankRequestRepository = tankRequestRepository;
            _gasTypeRepository = gasTypeRepository;
            _designStandardRepository = designStandardRepository;
            _productCodeRepository = productCodeRepository;
        }

        public async Task<TankRequestDetailDto> GetByIdAsync(Guid id)
        {
            var entity = await _tankRequestRepository.GetByIdAsync(id);
            if (entity == null) return null;

            var gasType = await _gasTypeRepository.GetByIdAsync(entity.GasTypeId);
            var designStandard = await _designStandardRepository.GetByIdAsync(entity.DesignStandardId);
            var productCode = entity.ProductCodeId.HasValue
                ? await _productCodeRepository.GetByIdAsync(entity.ProductCodeId.Value)
                : null;

            return new TankRequestDetailDto
            {
                Id = entity.Id,
                GasTypeName = gasType?.Name ?? "",
                GasTypeId = entity.GasTypeId,
                DesignStandardId = entity.DesignStandardId,
                ProductCodeId = entity.ProductCodeId,
                DesignStandardName = designStandard?.Name ?? "",
                UsageType = entity.UsageType,
                Orientation = entity.Orientation,
                Placement = entity.Placement,
                TransportType = entity.TransportType,
                CapacityValue = entity.CapacityValue,
                OperatingPressure = entity.OperatingPressure,
                DesignPressure = entity.DesignPressure,
                InnerDiameter = entity.InnerDiameter,
                IsInnerTankStainless = entity.IsInnerTankStainless,
                TankCode = entity.TankCode,
                ProductCode = productCode?.Code,
                Notes = entity.Notes
            };
        }

        public async Task<List<TankRequestDetailDto>> GetAllAsync()
        {
            var entities = await _tankRequestRepository.GetAllAsync();
            var result = new List<TankRequestDetailDto>();

            foreach (var entity in entities)
            {
                var gasType = await _gasTypeRepository.GetByIdAsync(entity.GasTypeId);
                var designStandard = await _designStandardRepository.GetByIdAsync(entity.DesignStandardId);
                var productCode = entity.ProductCodeId.HasValue
                    ? await _productCodeRepository.GetByIdAsync(entity.ProductCodeId.Value)
                    : null;

                result.Add(new TankRequestDetailDto
                {
                    Id = entity.Id,
                    GasTypeName = gasType?.Name ?? "",
                    GasTypeId = entity.GasTypeId,
                    DesignStandardId = entity.DesignStandardId,
                    ProductCodeId = entity.ProductCodeId,
                    DesignStandardName = designStandard?.Name ?? "",
                    UsageType = entity.UsageType,
                    Orientation = entity.Orientation,
                    Placement = entity.Placement,
                    TransportType = entity.TransportType,
                    CapacityValue = entity.CapacityValue,
                    OperatingPressure = entity.OperatingPressure,
                    DesignPressure = entity.DesignPressure,
                    InnerDiameter = entity.InnerDiameter,
                    IsInnerTankStainless = entity.IsInnerTankStainless,
                    TankCode = entity.TankCode,
                    ProductCode = productCode?.Code,
                    Notes = entity.Notes
                });
            }
            return result;
        }

        public async Task<TankRequestDetailDto> CreateAsync(TankRequestCreateDto dto)
        {
            var entity = new TankRequest
            {
                Id = Guid.NewGuid(),
                GasTypeId = dto.GasTypeId,
                DesignStandardId = dto.DesignStandardId,
                UsageType = dto.UsageType,
                Orientation = dto.Orientation,
                Placement = dto.Placement,
                TransportType = dto.TransportType,
                CapacityValue = dto.CapacityValue,
                OperatingPressure = dto.OperatingPressure,
                DesignPressure = dto.DesignPressure,
                InnerDiameter = dto.InnerDiameter,
                IsInnerTankStainless = dto.IsInnerTankStainless,
                TankCode = dto.TankCode,
                ProductCodeId = dto.ProductCodeId,
                Notes = dto.Notes
            };

            await _tankRequestRepository.AddAsync(entity);
            await _tankRequestRepository.SaveChangeAsync();

            return await GetByIdAsync(entity.Id);
        }

        public async Task<TankRequestDetailDto> UpdateAsync(TankRequestUpdateDto dto)
        {
            var entity = await _tankRequestRepository.GetByIdAsync(dto.Id);
            if (entity == null) return null;

            entity.GasTypeId = dto.GasTypeId;
            entity.DesignStandardId = dto.DesignStandardId;
            entity.UsageType = dto.UsageType;
            entity.Orientation = dto.Orientation;
            entity.Placement = dto.Placement;
            entity.TransportType = dto.TransportType;
            entity.CapacityValue = dto.CapacityValue;
            entity.OperatingPressure = dto.OperatingPressure;
            entity.DesignPressure = dto.DesignPressure;
            entity.InnerDiameter = dto.InnerDiameter;
            entity.IsInnerTankStainless = dto.IsInnerTankStainless;
            entity.TankCode = dto.TankCode;
            entity.ProductCodeId = dto.ProductCodeId;
            entity.Notes = dto.Notes;

            await _tankRequestRepository.UpdateAsync(entity);
            await _tankRequestRepository.SaveChangeAsync();

            return await GetByIdAsync(entity.Id);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _tankRequestRepository.GetByIdAsync(id);
            if (entity == null) return false;

            await _tankRequestRepository.DeleteAsync(entity);
            await _tankRequestRepository.SaveChangeAsync();
            return true;
        }
    }
}
