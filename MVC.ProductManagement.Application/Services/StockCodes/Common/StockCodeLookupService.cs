using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Common;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.S;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.Common
{
    public class StockCodeLookupService : IStockCodeLookupService
    {
        private readonly ISProductGroupRepositories _groupRepo;

        public StockCodeLookupService(
            ISProductGroupRepositories groupRepo)
        {
            _groupRepo = groupRepo;
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
