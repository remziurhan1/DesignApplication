using System;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.EN13458.Interfaces
{
    public interface IEN13458MaterialStrengthProvider
    {
        Task<double> ResolveEffectiveYieldStrengthAsync(Guid materialId, Guid materialFormId);
    }
}
