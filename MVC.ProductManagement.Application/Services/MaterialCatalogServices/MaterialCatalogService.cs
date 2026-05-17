using MVC.ProductManagement.Application.DTOs.MaterialCatalogDTOs;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Domain.Entities.MaterialCatalog;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using MVC.ProductManagement.Infrastructure.Repositories.MaterialCatalogRepositories;

namespace MVC.ProductManagement.Application.Services.MaterialCatalogServices
{
    public class MaterialCatalogService : IMaterialCatalogService
    {
        private readonly IMaterialCatalogRepository _repository;

        public MaterialCatalogService(IMaterialCatalogRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<MaterialLookupDto>> GetMaterialFamiliesAsync(CancellationToken cancellationToken = default)
        {
            var families = await _repository.GetMaterialFamiliesAsync(cancellationToken);
            return families.Select(x => new MaterialLookupDto
            {
                Id = x.Id,
                Code = x.Name,
                Name = x.Name,
                Description = x.Description
            }).ToList();
        }

        public async Task<IReadOnlyList<MaterialLookupDto>> GetMaterialFormsByFamilyAsync(Guid materialFamilyId, CancellationToken cancellationToken = default)
        {
            var forms = await _repository.GetMaterialFormsByFamilyAsync(materialFamilyId, cancellationToken);
            return forms.Select(x => new MaterialLookupDto
            {
                Id = x.Id,
                Code = x.Code ?? x.FormType.ToString(),
                Name = x.Name ?? x.FormType.ToString(),
                Description = x.Description ?? x.ProductStandard
            }).ToList();
        }

        public async Task<IReadOnlyList<MaterialLookupDto>> GetMaterialStandardsAsync(Guid materialFamilyId, Guid materialFormId, CancellationToken cancellationToken = default)
        {
            var standards = await _repository.GetMaterialStandardsAsync(materialFamilyId, materialFormId, cancellationToken);
            return standards.Select(x => new MaterialLookupDto
            {
                Id = x.Id,
                Code = x.StandardCode,
                Name = x.StandardCode,
                Description = x.Description
            }).ToList();
        }

        public async Task<IReadOnlyList<MaterialSelectionDto>> GetMaterialsAsync(Guid materialFamilyId, Guid materialFormId, Guid materialStandardId, CancellationToken cancellationToken = default)
        {
            var materials = await _repository.GetMaterialsAsync(materialFamilyId, materialFormId, materialStandardId, cancellationToken);
            return materials.Select(MapMaterialSelection).ToList();
        }

        public async Task<IReadOnlyList<MaterialMechanicalPropertyDto>> GetMechanicalPropertiesByMaterialIdAsync(Guid materialId, CancellationToken cancellationToken = default)
        {
            var properties = await _repository.GetMechanicalPropertiesByMaterialIdAsync(materialId, cancellationToken);
            return properties.Select(x => new MaterialMechanicalPropertyDto
            {
                Id = x.Id,
                MaterialId = x.MaterialId,
                Grade = GetGrade(x.Material),
                ThicknessMin = x.ThicknessMin,
                ThicknessMax = x.ThicknessMax,
                Temperature = x.Temperature,
                YieldStrength = x.YieldStrength,
                TensileStrengthMin = x.TensileStrengthMin,
                TensileStrengthMax = x.TensileStrengthMax,
                Elongation = x.Elongation,
                AllowableStress = x.AllowableStress,
                SourceNote = x.SourceNote
            }).ToList();
        }

        public async Task<MaterialStockCardDto?> GetStockCardByMaterialIdAsync(Guid materialId, CancellationToken cancellationToken = default)
        {
            var stockCard = await _repository.GetStockCardByMaterialIdAsync(materialId, cancellationToken);
            return stockCard == null ? null : MapStockCard(stockCard);
        }

        public async Task<MaterialPriceDto?> GetActivePriceByStockCodeAsync(string stockCode, DateTime? atDate = null, string? currency = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(stockCode)) return null;

            var stockCard = await _repository.GetStockCardByStockCodeAsync(stockCode, cancellationToken);
            if (stockCard == null) return null;

            var price = await _repository.GetActivePriceByStockCardIdAsync(stockCard.Id, atDate ?? DateTime.UtcNow.Date, currency, cancellationToken);
            return price == null ? null : MapPrice(price);
        }

        public async Task<MaterialPriceDto?> GetActivePriceByMaterialIdAsync(Guid materialId, DateTime? atDate = null, string? currency = null, CancellationToken cancellationToken = default)
        {
            var stockCard = await _repository.GetStockCardByMaterialIdAsync(materialId, cancellationToken);
            if (stockCard == null) return null;

            var price = await _repository.GetActivePriceByStockCardIdAsync(stockCard.Id, atDate ?? DateTime.UtcNow.Date, currency, cancellationToken);
            return price == null ? null : MapPrice(price);
        }

        private static MaterialSelectionDto MapMaterialSelection(Material material) => new()
        {
            MaterialFamilyId = material.MaterialFamilyId,
            MaterialFamilyName = material.MaterialFamily?.Name ?? string.Empty,
            MaterialFormId = material.MaterialFormId,
            MaterialFormName = material.MaterialForm?.Name ?? material.MaterialForm?.FormType.ToString() ?? string.Empty,
            MaterialStandardId = material.MaterialStandardId,
            StandardCode = material.MaterialStandard?.StandardCode ?? string.Empty,
            MaterialId = material.Id,
            Grade = GetGrade(material),
            MaterialNumber = material.MaterialNumber
        };

        private static MaterialStockCardDto MapStockCard(StockCard stockCard) => new()
        {
            Id = stockCard.Id,
            MaterialId = stockCard.MaterialId,
            StockCode = stockCard.StockCode ?? stockCard.StockCode8,
            Description = stockCard.Description,
            Unit = stockCard.Unit,
            IsActive = stockCard.IsActive
        };

        private static MaterialPriceDto MapPrice(StockCardPrice price) => new()
        {
            MaterialId = price.StockCard?.MaterialId,
            Grade = price.StockCard?.Material == null ? string.Empty : GetGrade(price.StockCard.Material),
            StockCardId = price.StockCardId,
            StockCode = price.StockCard?.StockCode ?? price.StockCard?.StockCode8 ?? string.Empty,
            UnitPrice = price.UnitPrice,
            TargetPrice = price.TargetPrice,
            Currency = price.Currency,
            ValidFrom = price.ValidFrom,
            ValidTo = price.ValidTo
        };

        private static string GetGrade(Material material) => string.IsNullOrWhiteSpace(material.Grade) ? material.Name : material.Grade;
    }
}
