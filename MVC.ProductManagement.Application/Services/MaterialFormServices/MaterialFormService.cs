using MVC.ProductManagement.Application.DTOs.MaterialFormDTOs;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Infrastructure.DataAccess.Interfaces;
using MVC.ProductManagement.Infrastructure.Repositories.MaterialFormRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.MaterialFormServices
{
    public class MaterialFormService : IMaterialFormService
    {
        private readonly IMaterialFormRepository _materialFormRepository;

        public MaterialFormService(IMaterialFormRepository materialFormRepository)
        {
            _materialFormRepository = materialFormRepository;
        }
        public async Task<List<MaterialFormListDto>> GetAllAsync()
        {
            var forms = await _materialFormRepository.GetAllAsync();
            return forms.Select(f => new MaterialFormListDto
            {
                Id = f.Id,
                MaterialId = f.MaterialId,
                FormType = f.FormType,
                ThicknessMin = f.ThicknessMin,
                ThicknessMax = f.ThicknessMax,
                UnitPrice=f.UnitPrice
            }).ToList();
        }
        public async Task<IEnumerable<MaterialForm>> GetAllWithMaterialAsync()
        {
            return await _materialFormRepository.GetAllWithMaterialAsync();
        }

        public async Task<MaterialForm> GetByIdWithMaterialAsync(Guid id)
        {
            return await _materialFormRepository.GetByIdWithMaterialAsync(id);
        }
        public async Task<List<MaterialFormListDto>> GetByMaterialIdAsync(Guid materialId)
        {
            var forms = await _materialFormRepository.GetByMaterialIdAsync(materialId);
            return forms.Select(f => new MaterialFormListDto
            {
                Id = f.Id,
                FormType = f.FormType,
                ThicknessMin = f.ThicknessMin,
                ThicknessMax = f.ThicknessMax
            }).ToList();
        }

        public async Task<List<MaterialFormListDto>> GetByFormTypeAsync(Domain.Enums.MaterialFormType formType)
        {
            var forms = await _materialFormRepository.GetByFormTypeAsync(formType);
            return forms.Select(f => new MaterialFormListDto
            {
                Id = f.Id,
                FormType = f.FormType,
                ThicknessMin = f.ThicknessMin,
                ThicknessMax = f.ThicknessMax
            }).ToList();
        }

        public async Task<MaterialFormDetailDto?> GetByIdAsync(Guid id)
        {
            var form = await _materialFormRepository.GetByIdAsync(id);
            if (form == null) return null;

            return new MaterialFormDetailDto
            {
                Id = form.Id,
                MaterialId = form.MaterialId,
                FormType = form.FormType,
                ThicknessMin = form.ThicknessMin,
                ThicknessMax = form.ThicknessMax,
                ProductStandard = form.ProductStandard,
                WeldingFactor = form.WeldingFactor,
                Notes = form.Notes,
                UnitPrice=form.UnitPrice
            };
        }

        public async Task<MaterialFormDetailDto> CreateAsync(MaterialFormCreateDto dto)
        {
            var entity = new MaterialForm
            {
                Id = Guid.NewGuid(),
                MaterialId = dto.MaterialId,
                FormType = dto.FormType,
                ThicknessMin = dto.ThicknessMin,
                ThicknessMax = dto.ThicknessMax,
                ProductStandard = dto.ProductStandard,
                WeldingFactor = dto.WeldingFactor,
                Notes = dto.Notes,
                UnitPrice = dto.UnitPrice
            };

            await _materialFormRepository.AddAsync(entity);
            await _materialFormRepository.SaveChangeAsync();

            return new MaterialFormDetailDto
            {
                Id = entity.Id,
                MaterialId = entity.MaterialId,
                FormType = entity.FormType,
                ThicknessMin = entity.ThicknessMin,
                ThicknessMax = entity.ThicknessMax,
                ProductStandard = entity.ProductStandard,
                WeldingFactor = entity.WeldingFactor,
                Notes = entity.Notes,
                UnitPrice = dto.UnitPrice
            };
        }

        public async Task<MaterialFormDetailDto> UpdateAsync(MaterialFormUpdateDto dto)
        {
            var entity = await _materialFormRepository.GetByIdAsync(dto.Id);
            if (entity == null) throw new Exception("MaterialForm not found");

            entity.MaterialId = dto.MaterialId;
            entity.FormType = dto.FormType;
            entity.ThicknessMin = dto.ThicknessMin;
            entity.ThicknessMax = dto.ThicknessMax;
            entity.ProductStandard = dto.ProductStandard;
            entity.WeldingFactor = dto.WeldingFactor;
            entity.Notes = dto.Notes;
            entity.UnitPrice = dto.UnitPrice;

            await _materialFormRepository.UpdateAsync(entity);
            await _materialFormRepository.SaveChangeAsync();

            return new MaterialFormDetailDto
            {
                Id = entity.Id,
                MaterialId = entity.MaterialId,
                FormType = entity.FormType,
                ThicknessMin = entity.ThicknessMin,
                ThicknessMax = entity.ThicknessMax,
                ProductStandard = entity.ProductStandard,
                WeldingFactor = entity.WeldingFactor,
                Notes = entity.Notes,
                UnitPrice = dto.UnitPrice

            };
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _materialFormRepository.GetByIdAsync(id);
            if (entity == null) throw new Exception("MaterialForm not found");

            await _materialFormRepository.DeleteAsync(entity);
            await _materialFormRepository.SaveChangeAsync();
        }
    }
}
