using MVC.ProductManagement.Application.DTOs.MaterialFormDTOs;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Domain.Enums;
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
            return MapListDtos(forms, includeMaterialId: true);
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
            return MapListDtos(forms, includeMaterialId: false);
        }

        public async Task<List<MaterialFormListDto>> GetByFormTypeAsync(Domain.Enums.MaterialFormType formType)
        {
            var forms = await _materialFormRepository.GetByFormTypeAsync(formType);
            return MapListDtos(forms, includeMaterialId: false);
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
                MaterialClass = form.MaterialClass,
                MaterialFamily = form.MaterialFamily,
                Norm = form.Norm,
                SymbolicName = form.SymbolicName,
                StockCode = form.StockCode,
                ThicknessMin = form.ThicknessMin,
                ThicknessMax = form.ThicknessMax,
                ProductStandard = form.ProductStandard,
                WeldingFactor = form.WeldingFactor,
                Notes = form.Notes,
                UnitPrice=form.UnitPrice,
                TargetPrice=form.TargetPrice,
                ColdStretchYieldStrength = form.ColdStretchYieldStrength,
                SectionArea = form.SectionArea,
                MomentOfInertia = form.MomentOfInertia,
                SectionModulus = form.SectionModulus
            };
        }

        public async Task<MaterialFormDetailDto> CreateAsync(MaterialFormCreateDto dto)
        {
            var entity = new MaterialForm
            {
                Id = Guid.NewGuid(),
                MaterialId = dto.MaterialId,
                FormType = dto.FormType,
                MaterialClass = dto.MaterialClass,
                MaterialFamily = ResolveMaterialFamily(dto.MaterialFamily, dto.MaterialClass),
                Norm = dto.Norm,
                SymbolicName = dto.SymbolicName,
                StockCode = dto.StockCode,
                ThicknessMin = dto.ThicknessMin,
                ThicknessMax = dto.ThicknessMax,
                ProductStandard = dto.ProductStandard,
                WeldingFactor = dto.WeldingFactor,
                Notes = dto.Notes,
                UnitPrice = dto.UnitPrice,
                TargetPrice = dto.TargetPrice,
                ColdStretchYieldStrength = dto.ColdStretchYieldStrength,
                SectionArea = dto.SectionArea,
                MomentOfInertia = dto.MomentOfInertia,
                SectionModulus = dto.SectionModulus
            };

            await _materialFormRepository.AddMaterialFormAsync(entity);
            await _materialFormRepository.SaveChangeAsync();

            return new MaterialFormDetailDto
            {
                Id = entity.Id,
                MaterialId = entity.MaterialId,
                FormType = entity.FormType,
                MaterialClass = entity.MaterialClass,
                MaterialFamily = entity.MaterialFamily,
                Norm = entity.Norm,
                SymbolicName = entity.SymbolicName,
                StockCode = entity.StockCode,
                ThicknessMin = entity.ThicknessMin,
                ThicknessMax = entity.ThicknessMax,
                ProductStandard = entity.ProductStandard,
                WeldingFactor = entity.WeldingFactor,
                Notes = entity.Notes,
                UnitPrice = dto.UnitPrice,
                TargetPrice = dto.TargetPrice,
                ColdStretchYieldStrength = dto.ColdStretchYieldStrength,
                SectionArea = dto.SectionArea,
                MomentOfInertia = dto.MomentOfInertia,
                SectionModulus = dto.SectionModulus
            };
        }

        public async Task<MaterialFormDetailDto> UpdateAsync(MaterialFormUpdateDto dto)
        {
            var entity = await _materialFormRepository.GetByIdAsync(dto.Id);
            if (entity == null) throw new Exception("MaterialForm not found");

            entity.MaterialId = dto.MaterialId;
            entity.FormType = dto.FormType;
            entity.MaterialClass = dto.MaterialClass;
            entity.MaterialFamily = ResolveMaterialFamily(dto.MaterialFamily, dto.MaterialClass);
            entity.Norm = dto.Norm;
            entity.SymbolicName = dto.SymbolicName;
            entity.StockCode = dto.StockCode;
            entity.ThicknessMin = dto.ThicknessMin;
            entity.ThicknessMax = dto.ThicknessMax;
            entity.ProductStandard = dto.ProductStandard;
            entity.WeldingFactor = dto.WeldingFactor;
            entity.Notes = dto.Notes;
            entity.UnitPrice = dto.UnitPrice;
            entity.TargetPrice = dto.TargetPrice;
            entity.ColdStretchYieldStrength = dto.ColdStretchYieldStrength;
            entity.SectionArea = dto.SectionArea;
            entity.MomentOfInertia = dto.MomentOfInertia;
            entity.SectionModulus = dto.SectionModulus;

            await _materialFormRepository.UpdateAsync(entity);
            await _materialFormRepository.SaveChangeAsync();

            return new MaterialFormDetailDto
            {
                Id = entity.Id,
                MaterialId = entity.MaterialId,
                FormType = entity.FormType,
                MaterialClass = entity.MaterialClass,
                MaterialFamily = entity.MaterialFamily,
                Norm = entity.Norm,
                SymbolicName = entity.SymbolicName,
                StockCode = entity.StockCode,
                ThicknessMin = entity.ThicknessMin,
                ThicknessMax = entity.ThicknessMax,
                ProductStandard = entity.ProductStandard,
                WeldingFactor = entity.WeldingFactor,
                Notes = entity.Notes,
                UnitPrice = dto.UnitPrice,
                TargetPrice = dto.TargetPrice,
                ColdStretchYieldStrength = dto.ColdStretchYieldStrength,
                SectionArea = dto.SectionArea,
                MomentOfInertia = dto.MomentOfInertia,
                SectionModulus = dto.SectionModulus

            };
        }

        private static MaterialFamily ResolveMaterialFamily(MaterialFamily materialFamily, string materialClass)
        {
            if (materialFamily != MaterialFamily.Unknown) return materialFamily;

            var normalized = (materialClass ?? string.Empty).Trim().ToLowerInvariant();
            if (normalized.Contains("stainless") || normalized.Contains("paslanmaz")) return MaterialFamily.StainlessSteel;
            if (normalized.Contains("carbon") || normalized.Contains("karbon")) return MaterialFamily.CarbonSteel;
            return MaterialFamily.Unknown;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _materialFormRepository.GetByIdAsync(id);
            if (entity == null) throw new Exception("MaterialForm not found");

            await _materialFormRepository.DeleteAsync(entity);
            await _materialFormRepository.SaveChangeAsync();
        }
        private static List<MaterialFormListDto> MapListDtos(IEnumerable<MaterialForm> forms, bool includeMaterialId)
        {
            var result = new List<MaterialFormListDto>();

            foreach (var form in forms)
            {
                var dto = new MaterialFormListDto
                {
                    Id = form.Id,
                    FormType = form.FormType,
                    MaterialClass = form.MaterialClass,
                    MaterialFamily = form.MaterialFamily,
                    Norm = form.Norm,
                    SymbolicName = form.SymbolicName,
                    StockCode = form.StockCode,
                    ThicknessMin = form.ThicknessMin,
                    ThicknessMax = form.ThicknessMax,
                    UnitPrice = form.UnitPrice,
                    TargetPrice = form.TargetPrice,
                    ColdStretchYieldStrength = form.ColdStretchYieldStrength,
                    SectionArea = form.SectionArea,
                    MomentOfInertia = form.MomentOfInertia,
                    SectionModulus = form.SectionModulus
                };

                if (includeMaterialId)
                {
                    dto.MaterialId = form.MaterialId;
                }

                result.Add(dto);
            }

            return result;
        }

    }
}
