using System;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.EN13458.Interfaces
{
    public interface IEN13458MaterialStrengthProvider
    {
        Task<double> ResolveEffectiveYieldStrengthAsync(Guid materialId, Guid materialFormId, bool isColdStretchApplied);
        Task<double> ResolveEffectiveYieldStrengthAsync(Guid materialId, Guid materialFormId, bool isColdStretchApplied, double temperature, double thickness);
        Task<double> ResolveDensityAsync(Guid materialId);
        Task<double> ResolveElasticModulusAsync(Guid materialFormId);
        Task<double> ResolveYieldFactorKAsync(Guid materialFormId);
    }
}
