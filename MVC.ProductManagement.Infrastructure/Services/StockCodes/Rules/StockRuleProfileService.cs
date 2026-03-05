using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Application.DTOs.StockCodes.Rules;
using MVC.ProductManagement.Infrastructure.AppContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MVC.ProductManagement.Application.Services.StockCodes.Rules;

namespace MVC.ProductManagement.Infrastructure.Services.StockCodes.Rules
{
    /// <summary>
    /// SA / SF gibi ürün grupları için seed tabanlı kuralları tek bir profile dönüştürür.
    /// Bu servis ileride Admin CRUD ekranları için "okuma modeli" olarak kullanılabilir.
    /// </summary>
    public class StockRuleProfileService : IStockRuleProfileService
    {
        private readonly AppDbContext _db;

        public StockRuleProfileService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<StockRuleProfileDto> GetProfileAsync(string groupCode, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(groupCode))
                throw new InvalidOperationException("groupCode boş olamaz.");

            groupCode = groupCode.Trim().ToUpperInvariant();
            if (groupCode != "SA" && groupCode != "SF")
                throw new InvalidOperationException("Bu profil servisi şimdilik sadece SA ve SF destekler.");

            var products = await _db.SProducts
                .AsNoTracking()
                .Where(p => p.Code.StartsWith(groupCode))
                .OrderBy(p => p.PrefixIndex)
                .ThenBy(p => p.Code)
                .Select(p => new { p.Id, p.Code, p.Name })
                .ToListAsync(cancellationToken);

            var productIds = products.Select(x => x.Id).ToList();

            var featureRules = await _db.SProductFeatureRules
                .AsNoTracking()
                .Include(x => x.SFeature)
                .Include(x => x.FixedValue)
                .Where(x => productIds.Contains(x.SProductId))
                .ToListAsync(cancellationToken);

            var valueRules = await _db.SFeatureValueRules
                .AsNoTracking()
                .Include(x => x.SFeatureValue)
                .Where(x => productIds.Contains(x.SProductId))
                .OrderBy(x => x.SortOrder)
                .ToListAsync(cancellationToken);

            var profile = new StockRuleProfileDto
            {
                GroupCode = groupCode,
                GroupName = groupCode == "SA" ? "Standart Parçalar - Cıvata/Perçin" : "Standart Parçalar - Aksesuar",
                Products = new List<StockRuleProductDto>()
            };

            foreach (var p in products)
            {
                var productFeatureRules = featureRules
                    .Where(r => r.SProductId == p.Id)
                    .OrderBy(r => r.SFeature.SortOrder)
                    .ToList();

                var featureDtos = new List<StockRuleFeatureDto>();
                foreach (var fr in productFeatureRules)
                {
                    var allowedValues = valueRules
                        .Where(v => v.SProductId == p.Id && v.SFeatureId == fr.SFeatureId)
                        .Select(v => new StockRuleValueDto
                        {
                            ValueId = v.SFeatureValueId,
                            ValueCode = v.SFeatureValue.Code,
                            ValueName = v.SFeatureValue.Name,
                            SortOrder = v.SortOrder
                        })
                        .ToList();

                    featureDtos.Add(new StockRuleFeatureDto
                    {
                        FeatureId = fr.SFeatureId,
                        FeatureCode = fr.SFeature.Code,
                        FeatureName = fr.SFeature.Name,
                        IsFixed = fr.IsFixed,
                        FixedValueId = fr.FixedValueId,
                        FixedValueCode = fr.FixedValue?.Code,
                        FixedValueName = fr.FixedValue?.Name,
                        AllowedValues = allowedValues
                    });
                }

                profile.Products.Add(new StockRuleProductDto
                {
                    ProductId = p.Id,
                    ProductCode = p.Code,
                    ProductName = p.Name,
                    Features = featureDtos
                });
            }

            return profile;
        }
    }
}
