using MVC.ProductManagement.Application.DTOs.StockCodes.S;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.S;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.S
{
    public class StockCodeService : IStockCodeService
    {

        private readonly IFluidRepositories _fluidRepo;
        private readonly ISProductGroupRepositories _groupRepo;
        private readonly ISProductRepositories _productRepo;
        private readonly ISAssemblyGroupRepositories _assemblyRepo;
        private readonly IPrefixRuleRepositories _prefixRuleRepo;
        private readonly IStockSequenceRepositories _sequenceRepo;
        private readonly IStockCardRepositories _stockCardRepo;
        private readonly AppDbContext _context;

        public StockCodeService(
            IFluidRepositories fluidRepo,
            ISProductGroupRepositories groupRepo,
            ISProductRepositories productRepo,
            ISAssemblyGroupRepositories assemblyRepo,
            IPrefixRuleRepositories prefixRuleRepo,
            IStockSequenceRepositories sequenceRepo,
            IStockCardRepositories stockCardRepo,
            AppDbContext context)
        {
            _fluidRepo = fluidRepo;
            _groupRepo = groupRepo;
            _productRepo = productRepo;
            _assemblyRepo = assemblyRepo;
            _prefixRuleRepo = prefixRuleRepo;
            _sequenceRepo = sequenceRepo;
            _stockCardRepo = stockCardRepo;
            _context = context;
        }

        public async Task<IReadOnlyList<LookupDto>> GetFluidsAsync(CancellationToken cancellationToken = default)
        {
            var list = await _fluidRepo.GetAllAsync(tracking: false);
            return list
                .OrderBy(x => x.Code)
                .Select(x => new LookupDto { Id = x.Id, Code = x.Code, Name = x.Name })
                .ToList();
        }

        public async Task<IReadOnlyList<LookupDto>> GetSProductGroupsAsync(CancellationToken cancellationToken = default)
        {
            var list = await _groupRepo.GetAllAsync(tracking: false);
            return list
                .OrderBy(x => x.Code)
                .Select(x => new LookupDto { Id = x.Id, Code = x.Code, Name = x.Name })
                .ToList();
        }

        public async Task<IReadOnlyList<LookupDto>> GetSProductsAsync(Guid sProductGroupId, CancellationToken cancellationToken = default)
        {
            var list = await _productRepo.GetAllAsync(x => x.SProductGroupId == sProductGroupId, tracking: false);
            return list
                .OrderBy(x => x.Code)
                .Select(x => new LookupDto { Id = x.Id, Code = x.Code, Name = x.Name })
                .ToList();
        }

        public async Task<IReadOnlyList<LookupDto>> GetSAssemblyGroupsAsync(Guid? sProductGroupId = null, CancellationToken cancellationToken = default)
        {
            IEnumerable<SAssemblyGroup> list;

            if (sProductGroupId.HasValue)
                list = await _assemblyRepo.GetAllAsync(x => x.SProductGroupId == sProductGroupId.Value, tracking: false);
            else
                list = await _assemblyRepo.GetAllAsync(tracking: false);

            return list
                .OrderBy(x => x.Step3Letter)
                .ThenBy(x => x.Step4Digit)
                .Select(x => new LookupDto
                {
                    Id = x.Id,
                    Code = $"{x.Step3Letter}{x.Step4Digit}",
                    Name = x.Name
                })
                .ToList();
        }

        public async Task<IReadOnlyList<StockCardListItemDto>> ListSStockCardsAsync(int take = 200, CancellationToken cancellationToken = default)
        {
            // Base repo Include desteklemiyor; minimum liste dönüyoruz.
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

                    // Bu alanlar entity içinde string olarak yoksa boş bırakabilirsin
                    FluidCode = "",
                    GroupCode = "",
                    ProductCode = "",
                })
                .ToList();
        }
        public async Task<IReadOnlyList<LookupDto>> GetPrefixRulesAsync(
    Guid fluidId,
    Guid sProductGroupId,
    Guid sProductId,
    CancellationToken cancellationToken = default)
        {
            var list = await _prefixRuleRepo.GetAllAsync(
                x => x.FluidId == fluidId
                  && x.SProductGroupId == sProductGroupId
                  && x.SProductId == sProductId,
                tracking: false);

            return list
                .OrderBy(x => x.Prefix4)
                .Select(x => new LookupDto
                {
                    Id = x.Id,
                    Code = x.Prefix4,
                    Name = x.Prefix4
                })
                .ToList();
        }

        public async Task<SStockCodeGenerateResultDto> GenerateSAsync(
    SStockCodeGenerateRequestDto request,
    CancellationToken cancellationToken = default)
        {
            // 1️⃣ PrefixRule BUL (Akışkan + Ürün Grubu)
            var rule = await _prefixRuleRepo.GetAsync(x =>
                x.FluidId == request.FluidId &&
                x.SProductGroupId == request.SProductGroupId,
                tracking: false);

            if (rule == null)
                throw new InvalidOperationException("PrefixRule bulunamadı.");

            // 2️⃣ Aynı kod daha önce üretilmiş mi?
            var existing = await _stockCardRepo.GetAsync(x =>
                x.FluidId == request.FluidId &&
                x.SProductGroupId == request.SProductGroupId &&
                x.SProductId == request.SProductId &&
                x.Prefix4 == rule.Prefix4,
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

            // 3️⃣ Sequence artır
            await using var tx = await _context.Database.BeginTransactionAsync(cancellationToken);

            var seq = await _sequenceRepo.GetAsync(x => x.Prefix4 == rule.Prefix4, tracking: true);
            if (seq == null)
                throw new InvalidOperationException($"StockSequence yok: {rule.Prefix4}");

            var nextSerial = seq.LastNumber < seq.StartNumber
                ? seq.StartNumber
                : seq.LastNumber + 1;

            if (nextSerial > 9999)
                throw new InvalidOperationException($"Seri no limiti aşıldı: {rule.Prefix4}");

            seq.LastNumber = nextSerial;
            await _sequenceRepo.UpdateAsync(seq);
            await _sequenceRepo.SaveChangeAsync();

            // 4️⃣ Açıklama
            var fluid = await _fluidRepo.GetByIdAsync(request.FluidId, tracking: false);
            var group = await _groupRepo.GetByIdAsync(request.SProductGroupId, tracking: false);
            var product = await _productRepo.GetByIdAsync(request.SProductId, tracking: false);

            if (fluid == null || group == null || product == null)
                throw new InvalidOperationException("Fluid / Group / Product bulunamadı.");

            var description = $"{fluid.Code} | {group.Name} | {product.Name}";

            // 5️⃣ Kart oluştur
            var card = new StockCard
            {
                Id = Guid.NewGuid(),
                FluidId = request.FluidId,
                SProductGroupId = request.SProductGroupId,
                SProductId = request.SProductId,

                Prefix4 = rule.Prefix4,
                Serial4 = nextSerial,
                StockCode8 = $"{rule.Prefix4}{nextSerial:0000}",
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

