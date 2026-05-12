using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Infrastructure.Repositories.SalesRequestRepositories.DTOs;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Domain.Entities.SalesRequests;
using MVC.ProductManagement.Domain.Enums;
using MVC.ProductManagement.Infrastructure.AppContext;

namespace MVC.ProductManagement.Infrastructure.Repositories.SalesRequestRepositories;

public class SalesRequestRepository : ISalesRequestRepository
{
    private readonly AppDbContext _context;

    public SalesRequestRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<SalesRequest>> GetIndexRequestsAsync()
    {
        return await _context.SalesRequests
            .AsNoTracking()
            .Include(x => x.Customer)
            .Include(x => x.Items)
            .Include(x => x.Attachments)
            .Where(x => x.Status != Status.Deleted)
            .OrderByDescending(x => x.CreatedDate)
            .ToListAsync();
    }

    public async Task<Dictionary<Guid, SalesRequestProductGroup>> GetProductGroupsDictionaryAsync()
    {
        return await _context.SalesRequestProductGroups.AsNoTracking().ToDictionaryAsync(x => x.Id);
    }

    public async Task AddSalesRequestAsync(SalesRequest entity)
    {
        await _context.SalesRequests.AddAsync(entity);
    }

    public async Task<SalesRequest?> GetForEditAsync(Guid id, bool tracking)
    {
        var query = _context.SalesRequests.Include(x => x.Items).Where(x => x.Id == id && x.Status != Status.Deleted);
        if (!tracking)
        {
            query = query.AsNoTracking();
        }
        return await query.FirstOrDefaultAsync();
    }

    public void RemoveItems(IEnumerable<SalesRequestItem> items)
    {
        _context.SalesRequestItems.RemoveRange(items);
    }

    public async Task AddItemAsync(SalesRequestItem item)
    {
        await _context.SalesRequestItems.AddAsync(item);
    }

    public async Task<List<SalesRequestRevision>> GetRevisionsAsync(Guid salesRequestId)
    {
        return await _context.SalesRequestRevisions
            .AsNoTracking()
            .Where(x => x.SalesRequestId == salesRequestId && x.Status != Status.Deleted)
            .OrderByDescending(x => x.RevisionNo)
            .ToListAsync();
    }

    public async Task<SalesRequest?> LoadRequestAsync(Guid id)
    {
        return await _context.SalesRequests
            .AsNoTracking()
            .Include(x => x.Customer)
            .Include(x => x.Attachments)
            .Include(x => x.Items)
                .ThenInclude(x => x.ProductGroup)
            .Include(x => x.Comments)
            .Where(x => x.Id == id && x.Status != Status.Deleted)
            .FirstOrDefaultAsync();
    }

    public async Task<SalesRequest?> GetForPricingAsync(Guid id)
    {
        return await _context.SalesRequests
            .Include(x => x.Items)
            .FirstOrDefaultAsync(x => x.Id == id && x.Status != Status.Deleted);
    }

    public async Task<SalesRequest?> GetWithItemsAsync(Guid id)
    {
        return await _context.SalesRequests
            .Include(x => x.Items)
            .FirstOrDefaultAsync(x => x.Id == id && x.Status != Status.Deleted);
    }

    public async Task<List<Customer>> GetActiveCustomersAsync()
    {
        return await _context.Customers
            .AsNoTracking()
            .Where(x => x.Status != Status.Deleted && x.IsActive)
            .OrderBy(x => x.CompanyName)
            .ToListAsync();
    }

    public async Task<List<SalesRequestProductGroup>> GetActiveProductGroupsAsync()
    {
        return await _context.SalesRequestProductGroups
            .AsNoTracking()
            .Where(x => x.Status != Status.Deleted && x.IsActive)
            .OrderBy(x => x.DisplayOrder)
            .ToListAsync();
    }

    public async Task<EmployeeProfile?> GetEmployeeProfileAsync(string userId)
    {
        return await _context.EmployeeProfiles
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.UserId == userId);
    }

    public async Task<SalesRequest?> GetByIdAsync(Guid id)
    {
        return await _context.SalesRequests.FirstOrDefaultAsync(x => x.Id == id && x.Status != Status.Deleted);
    }

    public async Task AddCommentAsync(SalesRequestComment comment)
    {
        await _context.SalesRequestComments.AddAsync(comment);
    }

    public async Task<List<SalesRequestPricingAnalysisDto>> GetAvailableAnalysesAsync()
    {
        var ad2000Analyses = await _context.AD2000CostAnalyses
            .AsNoTracking()
            .Where(x => x.Status != Status.Deleted && x.AD2000Calculation.Status != Status.Deleted)
            .Select(x => new SalesRequestPricingAnalysisRaw
            {
                CalculationType = SalesRequestCalculationType.AD2000,
                CalculationId = x.AD2000CalculationId,
                CostAnalysisId = x.Id,
                CalculationName = x.AD2000Calculation.Name,
                RevisionCode = x.RevisionCode,
                TotalCost = x.Items.Where(i => i.Status != Status.Deleted).Sum(i => (double?)i.ItemCost) ?? 0d,
                MinimumSalesPrice = x.SalesPrices.Where(s => s.Status != Status.Deleted).Select(s => (double?)s.MinimumSalesPrice).FirstOrDefault(),
                RecommendedSalesPrice = x.SalesPrices.Where(s => s.Status != Status.Deleted).Select(s => (double?)s.SalesPrice).FirstOrDefault()
            })
            .ToListAsync();

        var en13458Analyses = await _context.EN13458CostAnalyses
            .AsNoTracking()
            .Where(x => x.Status != Status.Deleted && x.EN13458Calculation.Status != Status.Deleted)
            .Select(x => new SalesRequestPricingAnalysisRaw
            {
                CalculationType = SalesRequestCalculationType.EN13458,
                CalculationId = x.EN13458CalculationId,
                CostAnalysisId = x.Id,
                CalculationName = x.EN13458Calculation.Name,
                RevisionCode = x.RevisionCode,
                TotalCost = x.Items.Where(i => i.Status != Status.Deleted).Sum(i => (double?)i.ItemCost) ?? 0d,
                MinimumSalesPrice = x.SalesPrices.Where(s => s.Status != Status.Deleted).Select(s => (double?)s.MinimumSalesPrice).FirstOrDefault(),
                RecommendedSalesPrice = x.SalesPrices.Where(s => s.Status != Status.Deleted).Select(s => (double?)s.SalesPrice).FirstOrDefault()
            })
            .ToListAsync();

        return ad2000Analyses.Concat(en13458Analyses)
            .Select(x => new SalesRequestPricingAnalysisDto
            {
                CalculationType = x.CalculationType,
                CalculationId = x.CalculationId,
                CostAnalysisId = x.CostAnalysisId,
                CalculationName = x.CalculationName,
                RevisionCode = x.RevisionCode,
                TotalCost = Convert.ToDecimal(x.TotalCost),
                MinimumSalesPrice = x.MinimumSalesPrice.HasValue ? Convert.ToDecimal(x.MinimumSalesPrice.Value) : null,
                RecommendedSalesPrice = x.RecommendedSalesPrice.HasValue ? Convert.ToDecimal(x.RecommendedSalesPrice.Value) : null
            })
            .ToList();
    }

    public async Task<List<SalesRequest>> GetRequestsForPricingRefreshAsync(Guid? requestId = null)
    {
        var query = _context.SalesRequests
            .Include(x => x.Items)
            .Where(x => x.Status != Status.Deleted);

        if (requestId.HasValue)
        {
            query = query.Where(x => x.Id == requestId.Value);
        }

        return await query.ToListAsync();
    }

    public async Task<LinkedPricingSnapshotDto?> GetLatestLinkedSnapshotAsync(SalesRequestCalculationType calculationType, Guid calculationId)
    {
        SalesRequestPricingAnalysisRaw? snapshot = null;

        if (calculationType == SalesRequestCalculationType.AD2000)
        {
            snapshot = await _context.AD2000CostAnalyses
                .AsNoTracking()
                .Where(x => x.AD2000CalculationId == calculationId && x.Status != Status.Deleted)
                .OrderByDescending(x => x.RevisionNo)
                .Select(x => new SalesRequestPricingAnalysisRaw
                {
                    CalculationName = x.AD2000Calculation.Name,
                    CostAnalysisId = x.Id,
                    RevisionCode = x.RevisionCode,
                    TotalCost = x.Items.Where(i => i.Status != Status.Deleted).Sum(i => (double?)i.ItemCost) ?? 0d,
                    MinimumSalesPrice = x.SalesPrices.Where(s => s.Status != Status.Deleted).Select(s => (double?)s.MinimumSalesPrice).FirstOrDefault(),
                    RecommendedSalesPrice = x.SalesPrices.Where(s => s.Status != Status.Deleted).Select(s => (double?)s.SalesPrice).FirstOrDefault()
                })
                .FirstOrDefaultAsync();
        }
        else if (calculationType == SalesRequestCalculationType.EN13458)
        {
            snapshot = await _context.EN13458CostAnalyses
                .AsNoTracking()
                .Where(x => x.EN13458CalculationId == calculationId && x.Status != Status.Deleted)
                .OrderByDescending(x => x.RevisionNo)
                .Select(x => new SalesRequestPricingAnalysisRaw
                {
                    CalculationName = x.EN13458Calculation.Name,
                    CostAnalysisId = x.Id,
                    RevisionCode = x.RevisionCode,
                    TotalCost = x.Items.Where(i => i.Status != Status.Deleted).Sum(i => (double?)i.ItemCost) ?? 0d,
                    MinimumSalesPrice = x.SalesPrices.Where(s => s.Status != Status.Deleted).Select(s => (double?)s.MinimumSalesPrice).FirstOrDefault(),
                    RecommendedSalesPrice = x.SalesPrices.Where(s => s.Status != Status.Deleted).Select(s => (double?)s.SalesPrice).FirstOrDefault()
                })
                .FirstOrDefaultAsync();
        }

        return snapshot == null
            ? null
            : new LinkedPricingSnapshotDto
            {
                CalculationName = snapshot.CalculationName,
                CostAnalysisId = snapshot.CostAnalysisId,
                RevisionCode = snapshot.RevisionCode,
                TotalCost = Convert.ToDecimal(snapshot.TotalCost),
                MinimumSalesPrice = snapshot.MinimumSalesPrice.HasValue ? Convert.ToDecimal(snapshot.MinimumSalesPrice.Value) : null,
                RecommendedSalesPrice = snapshot.RecommendedSalesPrice.HasValue ? Convert.ToDecimal(snapshot.RecommendedSalesPrice.Value) : null
            };
    }

    public async Task<int> CountByRequestNoPrefixAsync(string prefix)
    {
        return await _context.SalesRequests.CountAsync(x => x.RequestNo.StartsWith(prefix));
    }

    public async Task<SalesRequestProductGroup?> GetProductGroupAsync(Guid id, bool tracking = false)
    {
        var query = _context.SalesRequestProductGroups.Where(x => x.Id == id);
        if (!tracking)
        {
            query = query.AsNoTracking();
        }
        return await query.FirstOrDefaultAsync();
    }

    public async Task AddAttachmentsAsync(SalesRequest request, IEnumerable<SalesRequestAttachment> attachments)
    {
        _context.Entry(request).State = EntityState.Unchanged;
        await _context.SalesRequestAttachments.AddRangeAsync(attachments);
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    private sealed class SalesRequestPricingAnalysisRaw
    {
        public SalesRequestCalculationType CalculationType { get; set; }
        public Guid CalculationId { get; set; }
        public Guid CostAnalysisId { get; set; }
        public string CalculationName { get; set; } = string.Empty;
        public string RevisionCode { get; set; } = string.Empty;
        public double TotalCost { get; set; }
        public double? MinimumSalesPrice { get; set; }
        public double? RecommendedSalesPrice { get; set; }
    }
}
