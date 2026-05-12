using MVC.ProductManagement.Infrastructure.Repositories.CostingRepositories;
using MVC.ProductManagement.Domain.Entities.Costing;

namespace MVC.ProductManagement.Application.Services.Costing
{
    public class CostSettingsService : ICostSettingsService
    {
        private readonly ICostSettingsRepository _costSettingsRepository;

        public CostSettingsService(ICostSettingsRepository costSettingsRepository)
        {
            _costSettingsRepository = costSettingsRepository;
        }

        public Task<IReadOnlyList<LaborRate>> GetActiveLaborRatesAsync(CancellationToken cancellationToken = default)
            => _costSettingsRepository.GetActiveLaborRatesAsync(cancellationToken);

        public Task<IReadOnlyList<GugHourlyRate>> GetActiveGugHourlyRatesAsync(CancellationToken cancellationToken = default)
            => _costSettingsRepository.GetActiveGugHourlyRatesAsync(cancellationToken);

        public Task<IReadOnlyList<BombeLaborRate>> GetActiveBombeLaborRatesAsync(CancellationToken cancellationToken = default)
            => _costSettingsRepository.GetActiveBombeLaborRatesAsync(cancellationToken);

        public Task<IReadOnlyList<OverheadRate>> GetActiveOverheadRatesAsync(CancellationToken cancellationToken = default)
            => _costSettingsRepository.GetActiveOverheadRatesAsync(cancellationToken);

        public Task AddLaborRateAsync(LaborRate entity, CancellationToken cancellationToken = default)
            => _costSettingsRepository.AddLaborRateAsync(entity, cancellationToken);

        public Task UpdateLaborRateAsync(Guid? id, Action<LaborRate> update, CancellationToken cancellationToken = default)
            => _costSettingsRepository.UpdateLaborRateAsync(id, update, cancellationToken);

        public Task DeleteLaborRateAsync(Guid id, CancellationToken cancellationToken = default)
            => _costSettingsRepository.DeleteLaborRateAsync(id, cancellationToken);

        public Task AddGugHourlyRateAsync(GugHourlyRate entity, CancellationToken cancellationToken = default)
            => _costSettingsRepository.AddGugHourlyRateAsync(entity, cancellationToken);

        public Task UpdateGugHourlyRateAsync(Guid? id, Action<GugHourlyRate> update, CancellationToken cancellationToken = default)
            => _costSettingsRepository.UpdateGugHourlyRateAsync(id, update, cancellationToken);

        public Task DeleteGugHourlyRateAsync(Guid id, CancellationToken cancellationToken = default)
            => _costSettingsRepository.DeleteGugHourlyRateAsync(id, cancellationToken);

        public Task AddBombeLaborRateAsync(BombeLaborRate entity, CancellationToken cancellationToken = default)
            => _costSettingsRepository.AddBombeLaborRateAsync(entity, cancellationToken);

        public Task UpdateBombeLaborRateAsync(Guid? id, Action<BombeLaborRate> update, CancellationToken cancellationToken = default)
            => _costSettingsRepository.UpdateBombeLaborRateAsync(id, update, cancellationToken);

        public Task DeleteBombeLaborRateAsync(Guid id, CancellationToken cancellationToken = default)
            => _costSettingsRepository.DeleteBombeLaborRateAsync(id, cancellationToken);

        public Task AddOverheadRateAsync(OverheadRate entity, CancellationToken cancellationToken = default)
            => _costSettingsRepository.AddOverheadRateAsync(entity, cancellationToken);

        public Task UpdateOverheadRateAsync(Guid? id, Action<OverheadRate> update, CancellationToken cancellationToken = default)
            => _costSettingsRepository.UpdateOverheadRateAsync(id, update, cancellationToken);

        public Task DeleteOverheadRateAsync(Guid id, CancellationToken cancellationToken = default)
            => _costSettingsRepository.DeleteOverheadRateAsync(id, cancellationToken);
    }
}
