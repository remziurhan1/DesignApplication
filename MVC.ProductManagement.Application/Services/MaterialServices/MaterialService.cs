using MVC.ProductManagement.Application.DTOs.MaterialDTOs;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Infrastructure.Repositories.MaterialRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.MaterialServices
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;

        public MaterialService(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public async Task<List<MaterialListDto>> GetAllAsync()
        {
            var materials = await _materialRepository.GetAllAsync();
            return materials.Select(m => new MaterialListDto
            {
                Id = m.Id,
                Name = m.Name,
                Standard = m.Standard,
                Group = m.Group,
                ColdStretchYieldStrength = m.ColdStretchYieldStrength,
                ElasticModulus = m.ElasticModulus,
                YieldFactorK = m.YieldFactorK,
            }).ToList();
        }

        public async Task<MaterialDetailDto?> GetByIdAsync(Guid id)
        {
            var material = await _materialRepository.GetByIdAsync(id);
            if (material == null) return null;

            return new MaterialDetailDto
            {
                Id = material.Id,
                Name = material.Name,
                SymbolicName = material.SymbolicName,
                MaterialNumber = material.MaterialNumber,
                Standard = material.Standard,
                Origin = material.Origin,
                Group = material.Group,
                Norm = material.Norm,
                StockCode = material.StockCode,
                Density = material.Density,
                ColdStretchYieldStrength = material.ColdStretchYieldStrength,
                ElasticModulus = material.ElasticModulus,
                YieldFactorK = material.YieldFactorK,
                Notes = material.Notes
            };
        }

        public async Task<MaterialDetailDto?> GetByNameAsync(string name)
        {
            var material = await _materialRepository.GetByNameAsync(name);
            if (material == null) return null;

            return new MaterialDetailDto
            {
                Id = material.Id,
                Name = material.Name,
                SymbolicName = material.SymbolicName,
                MaterialNumber = material.MaterialNumber,
                Standard = material.Standard,
                Origin = material.Origin,
                Group = material.Group,
                Norm = material.Norm,
                StockCode = material.StockCode,
                Density = material.Density,
                ColdStretchYieldStrength = material.ColdStretchYieldStrength,
                ElasticModulus = material.ElasticModulus,
                YieldFactorK = material.YieldFactorK,
                Notes = material.Notes
            };
        }

        public async Task<MaterialDetailDto> CreateAsync(MaterialCreateDto dto)
        {
            var entity = new Material
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                SymbolicName = dto.SymbolicName,
                MaterialNumber = dto.MaterialNumber,
                Standard = dto.Standard,
                Origin = dto.Origin,
                Group = dto.Group,
                Norm = dto.Norm,
                StockCode = dto.StockCode,
                Density = dto.Density,
                ColdStretchYieldStrength = dto.ColdStretchYieldStrength,
                ElasticModulus = dto.ElasticModulus,
                YieldFactorK = dto.YieldFactorK,
                Notes = dto.Notes
            };

            await _materialRepository.AddAsync(entity);
            await _materialRepository.SaveChangeAsync();

            return new MaterialDetailDto
            {
                Id = entity.Id,
                Name = entity.Name,
                SymbolicName = entity.SymbolicName,
                MaterialNumber = entity.MaterialNumber,
                Standard = entity.Standard,
                Origin = entity.Origin,
                Group = entity.Group,
                Norm = entity.Norm,
                StockCode = entity.StockCode,
                Density = entity.Density,
                ColdStretchYieldStrength = entity.ColdStretchYieldStrength,
                ElasticModulus = entity.ElasticModulus,
                YieldFactorK = entity.YieldFactorK,
                Notes = entity.Notes
            };
        }

        public async Task<MaterialDetailDto> UpdateAsync(MaterialUpdateDto dto)
        {
            var entity = await _materialRepository.GetByIdAsync(dto.Id);
            if (entity == null) throw new Exception("Material not found");

            entity.Name = dto.Name;
            entity.SymbolicName = dto.SymbolicName;
            entity.MaterialNumber = dto.MaterialNumber;
            entity.Standard = dto.Standard;
            entity.Origin = dto.Origin;
            entity.Group = dto.Group;
            entity.Norm = dto.Norm;
            entity.StockCode = dto.StockCode;
            entity.Density = dto.Density;
            entity.ColdStretchYieldStrength = dto.ColdStretchYieldStrength;
            entity.ElasticModulus = dto.ElasticModulus;
            entity.YieldFactorK = dto.YieldFactorK;
            entity.Notes = dto.Notes;

            await _materialRepository.UpdateAsync(entity);
            await _materialRepository.SaveChangeAsync();

            return new MaterialDetailDto
            {
                Id = entity.Id,
                Name = entity.Name,
                SymbolicName = entity.SymbolicName,
                MaterialNumber = entity.MaterialNumber,
                Standard = entity.Standard,
                Origin = entity.Origin,
                Group = entity.Group,
                Norm = entity.Norm,
                StockCode = entity.StockCode,
                Density = entity.Density,
                ColdStretchYieldStrength = entity.ColdStretchYieldStrength,
                ElasticModulus = entity.ElasticModulus,
                YieldFactorK = entity.YieldFactorK,
                Notes = entity.Notes
            };
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _materialRepository.GetByIdAsync(id);
            if (entity == null) throw new Exception("Material not found");

            await _materialRepository.DeleteAsync(entity);
            await _materialRepository.SaveChangeAsync();
        }
    }
}
