// Dosya: Application/Services/StockCodes/SB/StockCodeSbService.cs

using MVC.ProductManagement.Application.DTOs.StockCodes.S;
using MVC.ProductManagement.Application.DTOs.StockCodes.SB;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.S;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.SB
{
    public class StockCodeSbService : IStockCodeSbService
    {
        private readonly ISProductRepositories _productRepo;
        private readonly IStockSequenceRepositories _sequenceRepo;
        private readonly IStockCardRepositories _stockCardRepo;
        private readonly IFluidRepositories _fluidRepo;
        private readonly ISProductGroupRepositories _groupRepo;
        private readonly AppDbContext _context;

        public StockCodeSbService(
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

        public async Task<IReadOnlyList<LookupDto>> GetFluidsAsync(CancellationToken cancellationToken = default)
        {
            var fluids = await _fluidRepo.GetAllAsync(tracking: false);
            return fluids
                .OrderBy(x => x.Code)
                .Select(x => new LookupDto { Id = x.Id, Code = x.Code, Name = x.Name })
                .ToList();
        }

        public async Task<IReadOnlyList<LookupDto>> GetSbProductsAsync(
            Guid sProductGroupId,
            CancellationToken cancellationToken = default)
        {
            var products = await _productRepo.GetAllAsync(
                x => x.SProductGroupId == sProductGroupId,
                tracking: false);

            // SA'da PrefixIndex'e göre sıralıyordun.
            // SB'de de aynı devam edelim (SBSeed içinde PrefixIndex dolduruyorsan düzgün sıralanır).
            return products
                .OrderBy(x => x.PrefixIndex)
                .Select(x => new LookupDto { Id = x.Id, Code = x.Code, Name = x.Name })
                .ToList();
        }

        public async Task<SbStockCodeGenerateResultDto> GenerateSbAsync(
            SbStockCodeGenerateRequestDto request,
            CancellationToken cancellationToken = default)
        {
            // 0) Aynı kombinasyon var mı? (unique index bunu zorluyor)
            var existing = await _stockCardRepo.GetAsync(x =>
                x.FluidId == request.FluidId &&
                x.SProductGroupId == request.SProductGroupId &&
                x.SProductId == request.SProductId,
                tracking: false);

            if (existing != null)
            {
                return new SbStockCodeGenerateResultDto
                {
                    AlreadyExists = true,
                    StockCardId = existing.Id,
                    StockCode8 = existing.StockCode8,
                    Prefix4 = existing.Prefix4,
                    Serial4 = existing.Serial4,
                    Description = existing.Description
                };
            }

            // 1) Lookup: Product + Fluid + Group
            var product = await _productRepo.GetByIdAsync(request.SProductId, tracking: false);
            if (product == null)
                throw new InvalidOperationException("SProduct bulunamadı.");

            var fluid = await _fluidRepo.GetByIdAsync(request.FluidId, tracking: false);
            if (fluid == null)
                throw new InvalidOperationException("Fluid bulunamadı.");

            var group = await _groupRepo.GetByIdAsync(request.SProductGroupId, tracking: false);
            if (group == null)
                throw new InvalidOperationException("SProductGroup bulunamadı.");

            // SB prefix: doğrudan product.Code (SBA0, SBB3...)
            var prefix4 = product.Code;

            // 2) Transaction: sequence + card
            await using var tx = await _context.Database.BeginTransactionAsync(cancellationToken);

            var seq = await _sequenceRepo.GetAsync(x => x.Prefix4 == prefix4, tracking: true);
            if (seq == null)
                throw new InvalidOperationException($"StockSequence yok: {prefix4}");

            // ✅ 1000’den başlat (SA ile aynı)
            var nextSerial = seq.LastNumber + 1;

            if (nextSerial > 9999)
                throw new InvalidOperationException($"Seri no limiti aşıldı: {prefix4}");

            seq.LastNumber = nextSerial;
            await _sequenceRepo.UpdateAsync(seq);
            await _sequenceRepo.SaveChangeAsync();

            // Şimdilik SA ile aynı açıklama kuralı:
            // İleride SB'ye özel özellikler gelince bunu builder'a böleceğiz.
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

            return new SbStockCodeGenerateResultDto
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
