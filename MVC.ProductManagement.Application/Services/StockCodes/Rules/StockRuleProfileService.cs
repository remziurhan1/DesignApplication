using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Application.DTOs.StockCodes.Rules;
using MVC.ProductManagement.Infrastructure.AppContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.Rules
{
    /// <summary>
    /// S* ürün grupları için seed/rule tabanlı kuralları tek bir profile dönüştürür.
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
            if (!IsSupportedGroup(groupCode))
                throw new InvalidOperationException("Desteklenmeyen grup kodu. Geçerli değerler: SA, SB, SC, SD, SE, SF, SG, SH.");

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
                GroupName = GetGroupName(groupCode),
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

        private static bool IsSupportedGroup(string groupCode)
        {
            return groupCode is "SA" or "SB" or "SC" or "SD" or "SE" or "SF" or "SG" or "SH";
        }

        private static string GetGroupName(string groupCode)
        {
            return groupCode switch
            {
                "SA" => "Standart Parçalar - Cıvata/Perçin",
                "SB" => "Standart Parçalar - Somun",
                "SC" => "Standart Parçalar - Rondela/Pul",
                "SD" => "Standart Parçalar - D Grubu",
                "SE" => "Standart Parçalar - E Grubu",
                "SF" => "Standart Parçalar - Aksesuar",
                "SG" => "Standart Parçalar - G Grubu",
                "SH" => "Standart Parçalar - H Grubu",
                _ => "Standart Parçalar"
            };
        }
    }
}
