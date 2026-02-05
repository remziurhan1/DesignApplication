using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using MVC.ProductManagement.Application.DTOs.StockCodes.SA;
using MVC.ProductManagement.Domain.Entities.StockCodes;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Common;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.S;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.SA
{
    public class StockCodeSaService : IStockCodeSaService
    {
        private readonly ISProductRepositories _productRepo;
        private readonly IStockSequenceRepositories _sequenceRepo;
        private readonly IStockCardRepositories _stockCardRepo;
        private readonly IFluidRepositories _fluidRepo;
        private readonly ISProductGroupRepositories _groupRepo;
        private readonly AppDbContext _context;

        public StockCodeSaService(
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

        public async Task<IReadOnlyList<LookupDto>> GetSaProductsAsync(CancellationToken cancellationToken = default)
        {
            var saGroupId = await GetSaGroupIdAsync();

            var products = await _productRepo.GetAllAsync(
                x => x.SProductGroupId == saGroupId,
                tracking: false);

            return products
                .OrderBy(x => x.PrefixIndex)
                .ThenBy(x => x.Code)
                .Select(x => new LookupDto { Id = x.Id, Code = x.Code, Name = x.Name })
                .ToList();
        }

        public async Task<SaStockCodeGenerateResultDto> GenerateSaAsync(
            SaStockCodeGenerateRequestDto request,
            CancellationToken cancellationToken = default)
        {
            var saGroupId = await GetSaGroupIdAsync();

            // 1) Product'tan prefix al (SA prefix'i doğrudan product.Code)
            var product = await _productRepo.GetByIdAsync(request.SProductId, tracking: false);
            if (product == null)
                throw new InvalidOperationException("SA ürünü bulunamadı.");

            var prefix4 = product.Code; // SAA0, SAB1...

            // 2) Default fluid (SA akışkan seçmez, DB için zorunlu)
            var allFluids = await _fluidRepo.GetAllAsync(tracking: false);
            var defaultFluid = allFluids.FirstOrDefault(x => x.Code == "A") ?? allFluids.First();

            // 3) Duplicate kontrol
            var existing = await _stockCardRepo.GetAsync(x =>
                    x.FluidId == defaultFluid.Id &&
                    x.SProductGroupId == saGroupId &&
                    x.SProductId == request.SProductId,
                tracking: false);

            if (existing != null)
            {
                return new SaStockCodeGenerateResultDto
                {
                    AlreadyExists = true,
                    StockCardId = existing.Id,
                    StockCode8 = existing.StockCode8,
                    Prefix4 = existing.Prefix4,
                    Serial4 = existing.Serial4,
                    Description = existing.Description
                };
            }

            // 4) Lookup
            var group = await _groupRepo.GetByIdAsync(saGroupId, tracking: false);
            if (group == null)
                throw new InvalidOperationException("SA grubu bulunamadı.");

            var description = $"{defaultFluid.Name} | {group.Name} | {product.Name}";

            // 5) Transaction
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
                FluidId = defaultFluid.Id,
                SProductGroupId = saGroupId,
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

            return new SaStockCodeGenerateResultDto
            {
                AlreadyExists = false,
                StockCardId = card.Id,
                StockCode8 = card.StockCode8,
                Prefix4 = card.Prefix4,
                Serial4 = card.Serial4,
                Description = card.Description
            };
        }

        private async Task<Guid> GetSaGroupIdAsync()
        {
            var groups = await _groupRepo.GetAllAsync(tracking: false);
            var saGroup = groups.FirstOrDefault(x => x.Code == "A");
            if (saGroup == null)
                throw new InvalidOperationException("SA (A) grubu tanımlı değil.");
            return saGroup.Id;
        }
    }
}
