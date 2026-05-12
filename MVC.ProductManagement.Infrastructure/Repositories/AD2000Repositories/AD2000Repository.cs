using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Domain.Entities.Costing;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Infrastructure.DataAccess.EntityFramework;

namespace MVC.ProductManagement.Infrastructure.Repositories.AD2000Repositories
{
    public class AD2000Repository : EFBaseRepository<AD2000Calculation>, IAD2000Repository
    {
        private readonly AppDbContext _appContext;

        public AD2000Repository(AppDbContext context) : base(context)
        {
            _appContext = context;
        }

        public async Task<bool> DeleteCalculationGraphAsync(Guid calculationId, CancellationToken cancellationToken = default)
        {
            var calculation = await _appContext.AD2000Calculations
                .FirstOrDefaultAsync(x => x.Id == calculationId && x.Status != Status.Deleted, cancellationToken);

            if (calculation == null)
            {
                return false;
            }

            var costAnalyses = await _appContext.AD2000CostAnalyses
                .Where(x => x.AD2000CalculationId == calculationId && x.Status != Status.Deleted)
                .ToListAsync(cancellationToken);

            var costAnalysisIds = costAnalyses.Select(x => x.Id).ToList();
            var costItems = await _appContext.AD2000CostAnalysisItems
                .Where(x => costAnalysisIds.Contains(x.AD2000CostAnalysisId) && x.Status != Status.Deleted)
                .ToListAsync(cancellationToken);

            var salesPrices = await _appContext.Set<AD2000SalesPrice>()
                .Where(x => x.AD2000CalculationId == calculationId && x.Status != Status.Deleted)
                .ToListAsync(cancellationToken);

            _appContext.AD2000CostAnalysisItems.RemoveRange(costItems);
            _appContext.Set<AD2000SalesPrice>().RemoveRange(salesPrices);
            _appContext.AD2000CostAnalyses.RemoveRange(costAnalyses);
            _appContext.AD2000Calculations.Remove(calculation);

            await _appContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
//aaaa