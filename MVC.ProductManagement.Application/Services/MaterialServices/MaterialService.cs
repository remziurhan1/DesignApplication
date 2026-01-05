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
                Group = m.Group
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
                MaterialNumber = material.MaterialNumber,
                Standard = material.Standard,
                Group = material.Group,
                Density = material.Density,
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
                MaterialNumber = material.MaterialNumber,
                Standard = material.Standard,
                Group = material.Group,
                Density = material.Density,
                Notes = material.Notes
            };
        }

        public async Task<MaterialDetailDto> CreateAsync(MaterialCreateDto dto)
        {
            var entity = new Material
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                MaterialNumber = dto.MaterialNumber,
                Standard = dto.Standard,
                Group = dto.Group,
                Density = dto.Density,
                Notes = dto.Notes
            };

            await _materialRepository.AddAsync(entity);
            await _materialRepository.SaveChangeAsync();

            return new MaterialDetailDto
            {
                Id = entity.Id,
                Name = entity.Name,
                MaterialNumber = entity.MaterialNumber,
                Standard = entity.Standard,
                Group = entity.Group,
                Density = entity.Density,
                Notes = entity.Notes
            };
        }

        public async Task<MaterialDetailDto> UpdateAsync(MaterialUpdateDto dto)
        {
            var entity = await _materialRepository.GetByIdAsync(dto.Id);
            if (entity == null) throw new Exception("Material not found");

            entity.Name = dto.Name;
            entity.MaterialNumber = dto.MaterialNumber;
            entity.Standard = dto.Standard;
            entity.Group = dto.Group;
            entity.Density = dto.Density;
            entity.Notes = dto.Notes;

            await _materialRepository.UpdateAsync(entity);
            await _materialRepository.SaveChangeAsync();

            return new MaterialDetailDto
            {
                Id = entity.Id,
                Name = entity.Name,
                MaterialNumber = entity.MaterialNumber,
                Standard = entity.Standard,
                Group = entity.Group,
                Density = entity.Density,
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
