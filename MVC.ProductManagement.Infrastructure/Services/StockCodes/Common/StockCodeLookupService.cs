using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using MVC.ProductManagement.Application.Services.StockCodes.Common;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Common;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.S;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Services.StockCodes.Common
{
    public class StockCodeLookupService : IStockCodeLookupService
    {
        private readonly IFluidRepositories _fluidRepo;
        private readonly ISProductGroupRepositories _groupRepo;

        public StockCodeLookupService(
            IFluidRepositories fluidRepo,
            ISProductGroupRepositories groupRepo)
        {
            _fluidRepo = fluidRepo;
            _groupRepo = groupRepo;
        }

        public async Task<IReadOnlyList<LookupDto>> GetAllFluidsAsync(CancellationToken cancellationToken = default)
        {
            var fluids = await _fluidRepo.GetAllAsync(tracking: false);
            return fluids
                .OrderBy(x => x.Code)
                .Select(x => new LookupDto { Id = x.Id, Code = x.Code, Name = x.Name })
                .ToList();
        }

        public async Task<IReadOnlyList<LookupDto>> GetSProductGroupsAsync(CancellationToken cancellationToken = default)
        {
            var groups = await _groupRepo.GetAllAsync(tracking: false);
            return groups
                .OrderBy(x => x.Code)
                .Select(x => new LookupDto { Id = x.Id, Code = x.Code, Name = x.Name })
                .ToList();
        }
    }
}
