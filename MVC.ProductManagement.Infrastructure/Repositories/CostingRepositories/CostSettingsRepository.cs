using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities.Costing;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.AppContext;

namespace MVC.ProductManagement.Infrastructure.Repositories.CostingRepositories
{
    public class CostSettingsRepository : ICostSettingsRepository
    {
        private readonly AppDbContext _context;

        public CostSettingsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<LaborRate>> GetActiveLaborRatesAsync(CancellationToken cancellationToken = default)
            => await _context.LaborRates
                .AsNoTracking()
                .Where(x => x.Status != Status.Deleted)
                .OrderBy(x => x.HourlyRate)
                .ThenBy(x => x.Name)
                .ToListAsync(cancellationToken);

        public async Task<IReadOnlyList<GugHourlyRate>> GetActiveGugHourlyRatesAsync(CancellationToken cancellationToken = default)
            => await _context.GugHourlyRates
                .AsNoTracking()
                .Where(x => x.Status != Status.Deleted)
                .OrderBy(x => x.HourlyRate)
                .ThenBy(x => x.Name)
                .ToListAsync(cancellationToken);

        public async Task<IReadOnlyList<BombeLaborRate>> GetActiveBombeLaborRatesAsync(CancellationToken cancellationToken = default)
            => await _context.BombeLaborRates
                .AsNoTracking()
                .Where(x => x.Status != Status.Deleted)
                .OrderBy(x => x.MaterialType)
                .ThenBy(x => x.RatePerKg)
                .ToListAsync(cancellationToken);

        public async Task<IReadOnlyList<OverheadRate>> GetActiveOverheadRatesAsync(CancellationToken cancellationToken = default)
            => await _context.OverheadRates
                .AsNoTracking()
                .Where(x => x.Status != Status.Deleted)
                .OrderBy(x => x.OverheadType)
                .ThenBy(x => x.Percentage)
                .ToListAsync(cancellationToken);

        public async Task AddLaborRateAsync(LaborRate entity, CancellationToken cancellationToken = default)
        {
            _context.LaborRates.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateLaborRateAsync(Guid? id, Action<LaborRate> update, CancellationToken cancellationToken = default)
            => await UpdateAsync(_context.LaborRates, id, update, cancellationToken);

        public async Task DeleteLaborRateAsync(Guid id, CancellationToken cancellationToken = default)
            => await DeleteAsync(_context.LaborRates, id, cancellationToken);

        public async Task AddGugHourlyRateAsync(GugHourlyRate entity, CancellationToken cancellationToken = default)
        {
            _context.GugHourlyRates.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateGugHourlyRateAsync(Guid? id, Action<GugHourlyRate> update, CancellationToken cancellationToken = default)
            => await UpdateAsync(_context.GugHourlyRates, id, update, cancellationToken);

        public async Task DeleteGugHourlyRateAsync(Guid id, CancellationToken cancellationToken = default)
            => await DeleteAsync(_context.GugHourlyRates, id, cancellationToken);

        public async Task AddBombeLaborRateAsync(BombeLaborRate entity, CancellationToken cancellationToken = default)
        {
            _context.BombeLaborRates.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateBombeLaborRateAsync(Guid? id, Action<BombeLaborRate> update, CancellationToken cancellationToken = default)
            => await UpdateAsync(_context.BombeLaborRates, id, update, cancellationToken);

        public async Task DeleteBombeLaborRateAsync(Guid id, CancellationToken cancellationToken = default)
            => await DeleteAsync(_context.BombeLaborRates, id, cancellationToken);

        public async Task AddOverheadRateAsync(OverheadRate entity, CancellationToken cancellationToken = default)
        {
            _context.OverheadRates.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateOverheadRateAsync(Guid? id, Action<OverheadRate> update, CancellationToken cancellationToken = default)
            => await UpdateAsync(_context.OverheadRates, id, update, cancellationToken);

        public async Task DeleteOverheadRateAsync(Guid id, CancellationToken cancellationToken = default)
            => await DeleteAsync(_context.OverheadRates, id, cancellationToken);

        private async Task UpdateAsync<TEntity>(DbSet<TEntity> dbSet, Guid? id, Action<TEntity> update, CancellationToken cancellationToken)
            where TEntity : class
        {
            if (!id.HasValue)
            {
                return;
            }

            var entity = await dbSet.FindAsync(new object[] { id.Value }, cancellationToken);
            if (entity == null)
            {
                return;
            }

            update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task DeleteAsync<TEntity>(DbSet<TEntity> dbSet, Guid id, CancellationToken cancellationToken)
            where TEntity : class
        {
            var entity = await dbSet.FindAsync(new object[] { id }, cancellationToken);
            if (entity == null)
            {
                return;
            }

            dbSet.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
