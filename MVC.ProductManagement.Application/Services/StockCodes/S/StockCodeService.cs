using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Application.DTOs.StockCodes.S;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.S;

namespace MVC.ProductManagement.Application.Services.StockCodes.S
{
    public class StockCodeService : IStockCodeService
    {
        private readonly IFluidRepositories _fluidRepo;
        private readonly ISProductGroupRepositories _groupRepo;
        private readonly ISProductRepositories _productRepo;
        private readonly IStockSequenceRepositories _sequenceRepo;
        private readonly IStockCardRepositories _stockCardRepo;
        private readonly AppDbContext _context;

        public StockCodeService(
            IFluidRepositories fluidRepo,
            ISProductGroupRepositories groupRepo,
            ISProductRepositories productRepo,
            IStockSequenceRepositories sequenceRepo,
            IStockCardRepositories stockCardRepo,
            AppDbContext context)
        {
            _fluidRepo = fluidRepo;
            _groupRepo = groupRepo;
            _productRepo = productRepo;
            _sequenceRepo = sequenceRepo;
            _stockCardRepo = stockCardRepo;
            _context = context;
        }

        public async Task<IReadOnlyList<LookupDto>> GetSProductGroupsAsync(CancellationToken cancellationToken = default)
        {
            var list = await _groupRepo.GetAllAsync(tracking: false);
            return list
                .OrderBy(x => x.Code)
                .Select(x => new LookupDto { Id = x.Id, Code = x.Code, Name = x.Name })
                .ToList();
        }

        public async Task<IReadOnlyList<LookupDto>> GetFluidsByGroupAsync(Guid sProductGroupId, CancellationToken cancellationToken = default)
        {
            // SPrefixRule üzerinden distinct fluid getiriyoruz
            var fluidIds = await _context.SPrefixRules
                .AsNoTracking()
                .Where(x => x.SProductGroupId == sProductGroupId)
                .Select(x => x.FluidId)
                .Distinct()
                .ToListAsync(cancellationToken);

            var fluids = await _fluidRepo.GetAllAsync(x => fluidIds.Contains(x.Id), tracking: false);

            return fluids
                .OrderBy(x => x.Code)
                .Select(x => new LookupDto { Id = x.Id, Code = x.Code, Name = x.Name })
                .ToList();
        }

        public async Task<IReadOnlyList<LookupDto>> GetSProductsAsync(Guid sProductGroupId, Guid fluidId, CancellationToken cancellationToken = default)
        {
            var productIds = await _context.SPrefixRules
                .AsNoTracking()
                .Where(x => x.SProductGroupId == sProductGroupId && x.FluidId == fluidId)
                .Select(x => x.SProductId)
                .Distinct()
                .ToListAsync(cancellationToken);

            var products = await _productRepo.GetAllAsync(x => productIds.Contains(x.Id), tracking: false);

            return products
                .OrderBy(x => x.PrefixIndex)
                .Select(x => new LookupDto { Id = x.Id, Code = x.Code, Name = x.Name })
                .ToList();
        }

        public async Task<IReadOnlyList<StockCardListItemDto>> ListSStockCardsAsync(int take = 200, CancellationToken cancellationToken = default)
        {
            var list = await _stockCardRepo.GetAllAsync(tracking: false);

            return list
                .OrderByDescending(x => x.CreatedDate)
                .Take(take)
                .Select(x => new StockCardListItemDto
                {
                    Id = x.Id,
                    StockCode8 = x.StockCode8,
                    Description = x.Description,
                    Prefix4 = x.Prefix4,
                    Serial4 = x.Serial4,
                    FluidCode = "",
                    GroupCode = "",
                    ProductCode = "",
                })
                .ToList();
        }

        public async Task<SStockCodeGenerateResultDto> GenerateSAsync(
            SStockCodeGenerateRequestDto request,
            CancellationToken cancellationToken = default)
        {
            // 1) Aynı kombinasyon var mı?
            var existing = await _stockCardRepo.GetAsync(x =>
                x.FluidId == request.FluidId &&
                x.SProductGroupId == request.SProductGroupId &&
                x.SProductId == request.SProductId,
                tracking: false);

            if (existing != null)
            {
                return new SStockCodeGenerateResultDto
                {
                    AlreadyExists = true,
                    StockCardId = existing.Id,
                    StockCode8 = existing.StockCode8,
                    Prefix4 = existing.Prefix4,
                    Serial4 = existing.Serial4,
                    Description = existing.Description
                };
            }

            // 2) SPrefixRule’dan Prefix al
            var rule = await _context.SPrefixRules
                .AsNoTracking()
                .SingleOrDefaultAsync(x =>
                    x.FluidId == request.FluidId &&
                    x.SProductGroupId == request.SProductGroupId &&
                    x.SProductId == request.SProductId,
                    cancellationToken);

            if (rule == null)
                throw new InvalidOperationException("SPrefixRule bulunamadı (Group+Fluid+Product).");

            var prefix4 = rule.Prefix; // ✅ artık hesap yok

            // 3) Lookup (Description için)
            var fluid = await _fluidRepo.GetByIdAsync(request.FluidId, tracking: false);
            var group = await _groupRepo.GetByIdAsync(request.SProductGroupId, tracking: false);
            var product = await _productRepo.GetByIdAsync(request.SProductId, tracking: false);

            if (fluid == null || group == null || product == null)
                throw new InvalidOperationException("Fluid / Group / Product bulunamadı.");

            // 4) Transaction: sequence + card
            await using var tx = await _context.Database.BeginTransactionAsync(cancellationToken);

            var seq = await _sequenceRepo.GetAsync(x => x.Prefix4 == prefix4, tracking: true);
            if (seq == null)
                throw new InvalidOperationException($"StockSequence yok: {prefix4}");

            // ✅ 1000’den başlat
            var nextSerial = (seq.LastNumber == 0) ? seq.StartNumber : (seq.LastNumber + 1);

            if (nextSerial > 9999)
                throw new InvalidOperationException($"Seri no limiti aşıldı: {prefix4}");

            seq.LastNumber = nextSerial;
            await _sequenceRepo.UpdateAsync(seq);
            await _sequenceRepo.SaveChangeAsync();

            var description = $"{fluid.Name} | {group.Name} | {product.Name}";

            var card = new StockCard
            {
                Id = Guid.NewGuid(),

                FluidId = request.FluidId,
                SProductGroupId = request.SProductGroupId,
                SProductId = request.SProductId,

                Prefix4 = prefix4,
                Serial4 = nextSerial,
                StockCode8 = $"{prefix4}{nextSerial:0000}",
                Description = description,

                StockSequenceId = seq.Id
            };

            await _stockCardRepo.AddAsync(card);
            await _stockCardRepo.SaveChangeAsync();

            await tx.CommitAsync(cancellationToken);

            return new SStockCodeGenerateResultDto
            {
                AlreadyExists = false,
                StockCardId = card.Id,
                StockCode8 = card.StockCode8,
                Prefix4 = card.Prefix4,
                Serial4 = card.Serial4,
                Description = card.Description
            };
        }
    }
}
