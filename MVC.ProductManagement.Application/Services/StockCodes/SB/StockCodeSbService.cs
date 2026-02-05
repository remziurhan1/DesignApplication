// Dosya: Application/Services/StockCodes/SB/StockCodeSbService.cs

using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using MVC.ProductManagement.Application.DTOs.StockCodes.SB;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Common;
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
            ISProductRepositories productRepo,
            IStockSequenceRepositories sequenceRepo,
            IStockCardRepositories stockCardRepo,
            IFluidRepositories fluidRepo,
            ISProductGroupRepositories groupRepo,
            AppDbContext context)
        {
            _productRepo = productRepo;
            _sequenceRepo = sequenceRepo;
            _stockCardRepo = stockCardRepo;
            _fluidRepo = fluidRepo;
            _groupRepo = groupRepo;
            _context = context;
        }

        public async Task<IReadOnlyList<LookupDto>> GetFluidsAsync(CancellationToken cancellationToken = default)
        {
            // SB tüm akışkanları kullanabilir
            var fluids = await _fluidRepo.GetAllAsync(tracking: false);
            return fluids
                .OrderBy(x => x.Code)
                .Select(x => new LookupDto { Id = x.Id, Code = x.Code, Name = x.Name })
                .ToList();
        }

        public async Task<IReadOnlyList<LookupDto>> GetSbProductsAsync(CancellationToken cancellationToken = default)
        {
            var sbGroupId = await GetSbGroupIdAsync();

            var products = await _productRepo.GetAllAsync(
                x => x.SProductGroupId == sbGroupId,
                tracking: false);

            return products
                .OrderBy(x => x.PrefixIndex)
                .ThenBy(x => x.Code)
                .Select(x => new LookupDto { Id = x.Id, Code = x.Code, Name = x.Name })
                .ToList();
        }

        public async Task<SbStockCodeGenerateResultDto> GenerateSbAsync(
            SbStockCodeGenerateRequestDto request,
            CancellationToken cancellationToken = default)
        {
            var sbGroupId = await GetSbGroupIdAsync();

            // 1) Product'tan prefix al (SB prefix'i doğrudan product.Code)
            var product = await _productRepo.GetByIdAsync(request.SProductId, tracking: false);
            if (product == null)
                throw new InvalidOperationException("SB ürünü bulunamadı.");

            var prefix4 = product.Code; // SBA0, SBB3...

            // 2) Duplicate kontrol
            var existing = await _stockCardRepo.GetAsync(x =>
                    x.FluidId == request.FluidId &&
                    x.SProductGroupId == sbGroupId &&
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

            // 3) Lookup
            var fluid = await _fluidRepo.GetByIdAsync(request.FluidId, tracking: false);
            var group = await _groupRepo.GetByIdAsync(sbGroupId, tracking: false);

            if (fluid == null || group == null)
                throw new InvalidOperationException("Fluid/Group bulunamadı.");

            var description = $"{fluid.Name} | {group.Name} | {product.Name}";

            // 4) Transaction
            await using var tx = await _context.Database.BeginTransactionAsync(cancellationToken);

            var seq = await _sequenceRepo.GetAsync(x => x.Prefix4 == prefix4, tracking: true);
            if (seq == null)
                throw new InvalidOperationException($"StockSequence yok: {prefix4}");

            var nextSerial = seq.LastNumber + 1;
            if (nextSerial > 9999)
                throw new InvalidOperationException($"Seri no limiti aşıldı: {prefix4}");

            seq.LastNumber = nextSerial;
            await _sequenceRepo.UpdateAsync(seq);
            await _sequenceRepo.SaveChangeAsync();

            var card = new StockCard
            {
                Id = Guid.NewGuid(),
                FluidId = request.FluidId,
                SProductGroupId = sbGroupId,
                SProductId = request.SProductId,
                Prefix4 = prefix4,
                Serial4 = nextSerial,
                StockCode8 = $"{prefix4}{nextSerial:0000}",
                Description = description,
                StockSequenceId = seq.Id,
                OptionKey = "LEGACY",
                CreatedBy = "SYSTEM",
                CreatedDate = DateTime.UtcNow,
                Status = Domain.Enums.Status.Added
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

        private async Task<Guid> GetSbGroupIdAsync()
        {
            var groups = await _groupRepo.GetAllAsync(tracking: false);
            var sbGroup = groups.FirstOrDefault(x => x.Code == "B");
            if (sbGroup == null)
                throw new InvalidOperationException("SB (B) grubu tanımlı değil.");
            return sbGroup.Id;
        }
    }
}
