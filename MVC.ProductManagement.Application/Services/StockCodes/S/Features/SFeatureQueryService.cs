using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.AppContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.S.Features
{
    public class SFeatureQueryService : ISFeatureQueryService
    {
        private readonly AppDbContext _db; // kendi DbContext tipinle değiştir

        public SFeatureQueryService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<FeatureWithValuesDto>> GetProductFeaturesAsync(
            Guid sProductId,
            CancellationToken cancellationToken = default)
        {
            // 1) Ürünün istediği feature listesi
            var productFeatures = await _db.Set<SProductFeature>()
                .AsNoTracking()
                .Where(x => x.SProductId == sProductId)
                .Select(x => new
                {
                    x.SFeatureId,
                    x.IsRequired,
                    x.SortOrder
                })
                .ToListAsync(cancellationToken);

            if (productFeatures.Count == 0)
                return new List<FeatureWithValuesDto>();

            var featureIds = productFeatures.Select(x => x.SFeatureId).Distinct().ToList();

            // 2) Feature + values çek
            var features = await _db.Set<SFeature>()
                .AsNoTracking()
                .Where(f => featureIds.Contains(f.Id))
                .Select(f => new
                {
                    f.Id,
                    f.Code,
                    f.Name,
                    f.SortOrder,
                    Values = f.Values
                        .OrderBy(v => v.SortOrder)
                        .Select(v => new FeatureValueDto
                        {
                            ValueId = v.Id,
                            Code = v.Code,
                            Name = v.Name,
                            SortOrder = v.SortOrder
                        })
                        .ToList()
                })
                .ToListAsync(cancellationToken);

            // 3) Ürün bazlı SortOrder override + IsRequired birleştir
            var pfMap = productFeatures.ToDictionary(x => x.SFeatureId);

            var result = features
                .Select(f => new FeatureWithValuesDto
                {
                    FeatureId = f.Id,
                    Code = f.Code,
                    Name = f.Name,
                    IsRequired = pfMap[f.Id].IsRequired,
                    SortOrder = pfMap[f.Id].SortOrder ?? f.SortOrder,
                    Values = f.Values
                })
                .OrderBy(x => x.SortOrder)
                .ToList();

            return result;
        }
    }
}
