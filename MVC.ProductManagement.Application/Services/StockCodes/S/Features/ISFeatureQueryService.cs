using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.S.Features
{
    public interface ISFeatureQueryService
    {
        Task<List<FeatureWithValuesDto>> GetProductFeaturesAsync(
            Guid sProductId,
            CancellationToken cancellationToken = default);
    }
}
