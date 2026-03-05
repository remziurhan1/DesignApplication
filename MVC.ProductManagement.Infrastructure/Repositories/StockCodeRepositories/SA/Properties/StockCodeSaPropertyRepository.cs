using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Application.DTOs.StockCodes.SA.Properties;
using MVC.ProductManagement.Application.Services.StockCodes.SA.Properties;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.AppContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.SA.Properties
{
    public class StockCodeSaPropertyRepository : IStockCodeSaPropertyRepository
    {
        private readonly AppDbContext _context;

        public StockCodeSaPropertyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<SaStockCodePropertyListDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await BuildQuery().ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<SaStockCodePropertyListDto>> GetByProductAsync(Guid productId, CancellationToken cancellationToken = default)
        {
            return await BuildQuery()
                .Where(x => x.ProductId == productId)
                .ToListAsync(cancellationToken);
        }

        public async Task<SaStockCodePropertyUpdateDto> GetForEditAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<SProductFeatureRule>()
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new SaStockCodePropertyUpdateDto
                {
                    Id = x.Id,
                    ProductId = x.SProductId,
                    FeatureId = x.SFeatureId,
                    IsFixed = x.IsFixed,
                    FixedValueId = x.FixedValueId
                })
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Guid> AddAsync(SaStockCodePropertyCreateDto dto, CancellationToken cancellationToken = default)
        {
            var exists = await _context.Set<SProductFeatureRule>()
                .AnyAsync(x => x.SProductId == dto.ProductId && x.SFeatureId == dto.FeatureId, cancellationToken);

            if (exists)
                throw new InvalidOperationException("Bu ürün-feature için kural zaten mevcut.");

            var entity = new SProductFeatureRule
            {
                Id = Guid.NewGuid(),
                SProductId = dto.ProductId,
                SFeatureId = dto.FeatureId,
                IsFixed = dto.IsFixed,
                FixedValueId = dto.IsFixed ? dto.FixedValueId : null
            };

            _context.Set<SProductFeatureRule>().Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public async Task<bool> UpdateAsync(SaStockCodePropertyUpdateDto dto, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Set<SProductFeatureRule>()
                .FirstOrDefaultAsync(x => x.Id == dto.Id, cancellationToken);

            if (entity == null)
                return false;

            entity.SProductId = dto.ProductId;
            entity.SFeatureId = dto.FeatureId;
            entity.IsFixed = dto.IsFixed;
            entity.FixedValueId = dto.IsFixed ? dto.FixedValueId : null;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Set<SProductFeatureRule>()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (entity == null)
                return false;

            _context.Set<SProductFeatureRule>().Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        private IQueryable<SaStockCodePropertyListDto> BuildQuery()
        {
            return _context.Set<SProductFeatureRule>()
                .AsNoTracking()
                .Select(x => new SaStockCodePropertyListDto
                {
                    Id = x.Id,
                    ProductId = x.SProductId,
                    ProductCode = x.SProduct.Code,
                    ProductName = x.SProduct.Name,
                    FeatureId = x.SFeatureId,
                    FeatureCode = x.SFeature.Code,
                    FeatureName = x.SFeature.Name,
                    IsFixed = x.IsFixed,
                    FixedValueId = x.FixedValueId,
                    FixedValueCode = x.FixedValue != null ? x.FixedValue.Code : null,
                    FixedValueName = x.FixedValue != null ? x.FixedValue.Name : null,
                    SortOrder = x.SFeature.SortOrder,
                    IsRequired = true
                })
                .OrderBy(x => x.ProductCode)
                .ThenBy(x => x.SortOrder);
        }
    }
}
