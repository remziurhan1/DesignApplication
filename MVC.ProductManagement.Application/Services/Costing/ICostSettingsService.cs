using MVC.ProductManagement.Domain.Entities.Costing;

namespace MVC.ProductManagement.Application.Services.Costing
{
    public interface ICostSettingsService
    {
        Task<IReadOnlyList<LaborRate>> GetActiveLaborRatesAsync(CancellationToken cancellationToken = default);
        Task<IReadOnlyList<GugHourlyRate>> GetActiveGugHourlyRatesAsync(CancellationToken cancellationToken = default);
        Task<IReadOnlyList<BombeLaborRate>> GetActiveBombeLaborRatesAsync(CancellationToken cancellationToken = default);
        Task<IReadOnlyList<OverheadRate>> GetActiveOverheadRatesAsync(CancellationToken cancellationToken = default);

        Task AddLaborRateAsync(LaborRate entity, CancellationToken cancellationToken = default);
        Task UpdateLaborRateAsync(Guid? id, Action<LaborRate> update, CancellationToken cancellationToken = default);
        Task DeleteLaborRateAsync(Guid id, CancellationToken cancellationToken = default);

        Task AddGugHourlyRateAsync(GugHourlyRate entity, CancellationToken cancellationToken = default);
        Task UpdateGugHourlyRateAsync(Guid? id, Action<GugHourlyRate> update, CancellationToken cancellationToken = default);
        Task DeleteGugHourlyRateAsync(Guid id, CancellationToken cancellationToken = default);

        Task AddBombeLaborRateAsync(BombeLaborRate entity, CancellationToken cancellationToken = default);
        Task UpdateBombeLaborRateAsync(Guid? id, Action<BombeLaborRate> update, CancellationToken cancellationToken = default);
        Task DeleteBombeLaborRateAsync(Guid id, CancellationToken cancellationToken = default);

        Task AddOverheadRateAsync(OverheadRate entity, CancellationToken cancellationToken = default);
        Task UpdateOverheadRateAsync(Guid? id, Action<OverheadRate> update, CancellationToken cancellationToken = default);
        Task DeleteOverheadRateAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
