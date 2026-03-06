using MVC.ProductManagement.Application.DTOs.Common;
using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using MVC.ProductManagement.Application.DTOs.StockCodes.SA;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.Common;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.S;
using MVC.ProductManagement.Infrastructure.Repositories.StockCodeRepositories.SA;
using MVC.ProductManagement.Application.Services.StockCodes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        private readonly ISAStockCardRepository _saRepo;

        public StockCodeSaService(
            ISProductRepositories productRepo,
            IStockSequenceRepositories sequenceRepo,
            IStockCardRepositories stockCardRepo,
            IFluidRepositories fluidRepo,
            ISProductGroupRepositories groupRepo,
            ISAStockCardRepository saRepo)
        {
            _productRepo = productRepo;
            _sequenceRepo = sequenceRepo;
            _stockCardRepo = stockCardRepo;
            _fluidRepo = fluidRepo;
            _groupRepo = groupRepo;
            _saRepo = saRepo;
        }
        /// <summary>
        /// ✅ 10. SA grubuna ait feature'ları getir
        /// </summary>
        public async Task<IReadOnlyList<FeatureDto>> GetAllFeaturesAsync(CancellationToken cancellationToken = default)
        {
            var saFeatureCodes = new[]
            {
                "STANDARD",
                "THREAD_SYSTEM",
                "METRIC",
                "LENGTH",
                "MATERIAL",
                "STRENGTH",
                "COATING",
                "HEAD_TYPE"
            };

            var features = await _saRepo.GetFeaturesByCodesAsync(saFeatureCodes, cancellationToken);

            return features.Select(f => new FeatureDto
            {
                Id = f.Id,
                Code = f.Code,
                Name = f.Name,
                IsRequired = true,
                SortOrder = f.SortOrder,
                Values = f.Values
                    .OrderBy(v => v.SortOrder)
                    .Select(v => new FeatureValueDto
                    {
                        Id = v.Id,
                        Code = v.Code,
                        Name = v.Name,
                        SortOrder = v.SortOrder
                    }).ToList()
            }).ToList();
        }
        /// <summary>
        /// ✅ 1. SA Ürün listesi
        /// </summary>
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

        public async Task<IReadOnlyList<FeatureDto>> GetFeaturesByProductAsync(
            Guid productId,
            CancellationToken cancellationToken = default)
        {
            // SA grubuna ait feature'lar ürün fark etmeksizin aynıdır — GetAllFeaturesAsync'i yeniden kullan
            return await GetAllFeaturesAsync(cancellationToken);
        }

        /// <summary>
        /// ✅ 3. Kod üretimi
        /// </summary>
        public async Task<SaStockCodeGenerateResultDto> GenerateSaAsync(
            SaStockCodeGenerateRequestDto request,
            CancellationToken cancellationToken = default)
        {
            var saGroupId = await GetSaGroupIdAsync();

            // 1) Product
            var product = await _productRepo.GetByIdAsync(request.SProductId, tracking: false);
            if (product == null)
                throw new InvalidOperationException("SA ürünü bulunamadı.");

            var prefix4 = product.Code;

            // 2) Default fluid
            var allFluids = await _fluidRepo.GetAllAsync(tracking: false);
            var defaultFluid = allFluids.FirstOrDefault(x => x.Code == "A") ?? allFluids.First();

            // 3) Kural tabanlı seçimleri doğrula + sabit değerlerle birleştir
            var allSelections = await BuildValidatedSelectionsForProductAsync(
                request.SProductId,
                request.SelectedFeatureValues,
                cancellationToken);

            // 4) OptionKey oluştur
            var optionKey = await BuildOptionKeyAsync(allSelections, cancellationToken);

            // 5) Duplicate kontrol
            var existing = await _stockCardRepo.GetAsync(x =>
                    x.FluidId == defaultFluid.Id &&
                    x.SProductGroupId == saGroupId &&
                    x.SProductId == request.SProductId &&
                    x.OptionKey == optionKey,
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

            // 6) Description
            var description = await BuildFeatureDescriptionAsync(allSelections, cancellationToken);

            // 7) Transaction
            var tx = await _saRepo.BeginTransactionAsync(cancellationToken);
            try
            {
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
                    OptionKey = optionKey,
                    CreatedBy = "SYSTEM",
                    CreatedDate = DateTime.UtcNow,
                    Status = Domain.Enums.Status.Added
                };

                await _stockCardRepo.AddAsync(card);
                await _stockCardRepo.SaveChangeAsync();

                // 8) Feature seçimlerini kaydet
                if (allSelections.Any())
                {
                    var selections = allSelections.Select(kvp => new StockCardFeatureSelection
                    {
                        Id = Guid.NewGuid(),
                        StockCardId = card.Id,
                        SFeatureId = kvp.Key,
                        SFeatureValueId = kvp.Value,
                        CreatedBy = "SYSTEM",
                        CreatedDate = DateTime.UtcNow,
                        Status = Domain.Enums.Status.Added
                    }).ToList();

                    await _saRepo.AddFeatureSelectionsAsync(selections, cancellationToken);
                }

                await _saRepo.CommitTransactionAsync(tx, cancellationToken);

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
            catch
            {
                await _saRepo.RollbackTransactionAsync(tx, cancellationToken);
                throw;
            }
            finally
            {
                tx.Dispose();
            }
        }

        private async Task<Dictionary<Guid, Guid>> BuildValidatedSelectionsForProductAsync(
            Guid productId,
            Dictionary<Guid, Guid> requestSelections,
            CancellationToken cancellationToken)
        {
            requestSelections ??= new Dictionary<Guid, Guid>();

            var rules = await _saRepo.GetProductFeatureRulesAsync(productId, cancellationToken);

            if (!rules.Any())
                throw new InvalidOperationException("Bu ürün için feature kuralı bulunamadı.");

            var valueRules = await _saRepo.GetFeatureValueRulesAsync(productId, cancellationToken);

            var result = new Dictionary<Guid, Guid>();

            // sabit değerleri otomatik ekle
            foreach (var rule in rules.Where(r => r.IsFixed))
            {
                if (!rule.FixedValueId.HasValue)
                    throw new InvalidOperationException("Sabit kuralda FixedValueId boş olamaz.");

                result[rule.SFeatureId] = rule.FixedValueId.Value;
            }

            // dinamik seçimleri doğrula
            foreach (var rule in rules.Where(r => !r.IsFixed))
            {
                if (!requestSelections.TryGetValue(rule.SFeatureId, out var selectedValueId))
                    throw new InvalidOperationException($"Zorunlu özellik seçilmedi. FeatureId: {rule.SFeatureId}");

                var isAllowed = valueRules.Any(v =>
                    v.SFeatureId == rule.SFeatureId &&
                    v.SFeatureValueId == selectedValueId);

                if (!isAllowed)
                    throw new InvalidOperationException($"Seçilen değer bu ürün için izinli değil. FeatureId: {rule.SFeatureId}");

                result[rule.SFeatureId] = selectedValueId;
            }

            // kural dışında feature gönderildiyse reddet
            var allowedFeatureIds = rules.Select(r => r.SFeatureId).ToHashSet();
            var unexpectedFeature = requestSelections.Keys.FirstOrDefault(f => !allowedFeatureIds.Contains(f));
            if (unexpectedFeature != Guid.Empty)
                throw new InvalidOperationException($"Bu ürün için tanımsız feature gönderildi. FeatureId: {unexpectedFeature}");

            return result;
        }

        /// <summary>
        /// ✅ 4. Liste (filtreleme + pagination)
        /// </summary>
        public async Task<SAStockCardListResultDto> GetStockCardsAsync(
            SAStockCardFilterDto filter,
            CancellationToken cancellationToken = default)
        {
            var (stockCards, totalCount) = await _saRepo.GetFilteredStockCardsAsync(
                filter.SearchTerm,
                filter.ProductId,
                filter.StartDate,
                filter.EndDate,
                filter.PageNumber,
                filter.PageSize,
                cancellationToken);

            var items = stockCards.Select(sc => new SAStockCardListItemDto
            {
                Id = sc.Id,
                StockCode8 = sc.StockCode8,
                Prefix4 = sc.Prefix4,
                Serial4 = sc.Serial4,
                ProductCode = sc.SProduct.Code,
                ProductName = sc.SProduct.Name,
                FluidCode = sc.Fluid.Code,
                FluidName = sc.Fluid.Name,
                Description = sc.Description,
                CreatedDate = sc.CreatedDate,
                CreatedBy = sc.CreatedBy
            }).ToList();

            return new SAStockCardListResultDto
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize
            };
        }

        /// <summary>
        /// ✅ 5. Detay görüntüleme
        /// </summary>
        public async Task<SAStockCardDetailDto> GetStockCardDetailAsync(
            Guid stockCardId,
            CancellationToken cancellationToken = default)
        {
            var card = await _saRepo.GetStockCardWithDetailsAsync(stockCardId, cancellationToken);

            if (card == null)
                throw new InvalidOperationException("Stok kartı bulunamadı.");

            // Feature seçimlerini getir
            var selections = await _saRepo.GetFeatureSelectionsWithDetailsAsync(stockCardId, cancellationToken);

            return new SAStockCardDetailDto
            {
                Id = card.Id,
                StockCode8 = card.StockCode8,
                Prefix4 = card.Prefix4,
                Serial4 = card.Serial4,
                ProductId = card.SProductId,
                ProductCode = card.SProduct.Code,
                ProductName = card.SProduct.Name,
                FluidId = card.FluidId ?? Guid.Empty,
                FluidCode = card.Fluid.Code,
                FluidName = card.Fluid.Name,
                Description = card.Description,
                OptionKey = card.OptionKey,
                CreatedDate = card.CreatedDate,
                CreatedBy = card.CreatedBy,
                FeatureSelections = selections
                    .Select(s => new FeatureSelectionDto
                    {
                        FeatureId = s.SFeatureId,
                        FeatureName = s.SFeature.Name,
                        ValueId = s.SFeatureValueId,
                        ValueCode = s.SFeatureValue.Code,
                        ValueName = s.SFeatureValue.Name,
                        SortOrder = s.SFeature.SortOrder
                    }).ToList()
            };
        }

        /// <summary>
        /// ✅ 6. Düzenleme için veri getir
        /// </summary>
        public async Task<SAStockCardUpdateDto> GetStockCardForEditAsync(
            Guid stockCardId,
            CancellationToken cancellationToken = default)
        {
            var selections = await _saRepo.GetFeatureSelectionsAsync(stockCardId, cancellationToken);

            if (!selections.Any())
                throw new InvalidOperationException("Stok kartı bulunamadı.");

            return new SAStockCardUpdateDto
            {
                StockCardId = stockCardId,
                FeatureSelections = selections.ToDictionary(
                    fs => fs.SFeatureId,
                    fs => fs.SFeatureValueId)
            };
        }

        public async Task<bool> UpdateStockCardAsync(
            SAStockCardUpdateDto updateDto,
            string userName,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var card = await _stockCardRepo.GetAsync(sc => sc.Id == updateDto.StockCardId && !sc.IsDeleted, tracking: true);

                if (card == null)
                    throw new InvalidOperationException("Stok kartı bulunamadı.");

                // ✅ Sabit feature'ları ekle
                var productId = card.SProductId;
                var fixedRules = await _saRepo.GetFixedProductFeatureRulesAsync(productId, cancellationToken);

                // ✅ YENİ: Önce kullanıcı seçimlerini al, sonra sabit değerleri ekle
                var allSelections = new Dictionary<Guid, Guid>();

                // Kullanıcı seçimlerini ekle
                if (updateDto.FeatureSelections != null)
                {
                    foreach (var kvp in updateDto.FeatureSelections)
                    {
                        allSelections[kvp.Key] = kvp.Value;
                    }
                }

                // Sabit feature'ları ekle (override edebilir)
                foreach (var rule in fixedRules)
                {
                    allSelections[rule.SFeatureId] = rule.FixedValueId!.Value;
                }

                // ✅ DEBUG: Seçimleri logla
                Console.WriteLine($"[UPDATE] StockCardId: {updateDto.StockCardId}");
                Console.WriteLine($"[UPDATE] Total unique selections: {allSelections.Count}");
                foreach (var kvp in allSelections)
                {
                    Console.WriteLine($"  - FeatureId: {kvp.Key}, ValueId: {kvp.Value}");
                }

                // ✅ Transaction başlat
                var transaction = await _saRepo.BeginTransactionAsync(cancellationToken);

                try
                {
                    // ✅ 1. ESKİ KAYITLARI SİL (ExecuteDelete kullan - daha performanslı)
                    await _saRepo.DeleteFeatureSelectionsAsync(updateDto.StockCardId, cancellationToken);

                    Console.WriteLine("[UPDATE] Old selections deleted");

                    // ✅ 2. YENİ KAYITLARI EKLE
                    var newSelections = allSelections
                        .Select(kvp => new StockCardFeatureSelection
                        {
                            Id = Guid.NewGuid(),
                            StockCardId = card.Id,
                            SFeatureId = kvp.Key,
                            SFeatureValueId = kvp.Value,
                            CreatedBy = userName,
                            CreatedDate = DateTime.UtcNow,
                            Status = Domain.Enums.Status.Added
                        })
                        .ToList();

                    Console.WriteLine($"[UPDATE] Adding {newSelections.Count} new selections");

                    // ✅ Duplicate kontrolü
                    var duplicates = newSelections
                        .GroupBy(x => new { x.StockCardId, x.SFeatureId })
                        .Where(g => g.Count() > 1)
                        .ToList();

                    if (duplicates.Any())
                    {
                        Console.WriteLine("[UPDATE ERROR] DUPLICATE DETECTED!");
                        foreach (var dup in duplicates)
                        {
                            Console.WriteLine($"  - StockCardId: {dup.Key.StockCardId}, FeatureId: {dup.Key.SFeatureId} (Count: {dup.Count()})");
                        }
                        throw new InvalidOperationException("Duplicate feature selection detected!");
                    }

                    await _saRepo.AddFeatureSelectionsAsync(newSelections, cancellationToken);

                    Console.WriteLine("[UPDATE] New selections saved");

                    // ✅ 3. DESCRIPTION GÜNCELLE
                    var newDescription = await BuildFeatureDescriptionAsync(allSelections, cancellationToken);
                    Console.WriteLine($"[UPDATE] New description: {newDescription}");

                    card.Description = newDescription;
                    card.ModifiedDate = DateTime.UtcNow;
                    card.ModifiedBy = userName;

                    await _stockCardRepo.UpdateAsync(card);
                    await _saRepo.SaveChangesAsync(cancellationToken);

                    // ✅ 4. TRANSACTION COMMIT
                    await _saRepo.CommitTransactionAsync(transaction, cancellationToken);

                    Console.WriteLine("[UPDATE] Transaction committed successfully");
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[UPDATE ERROR] {ex.Message}");
                    Console.WriteLine($"[UPDATE ERROR] Inner: {ex.InnerException?.Message}");
                    await _saRepo.RollbackTransactionAsync(transaction, cancellationToken);
                    throw;
                }
                finally
                {
                    transaction.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UPDATE OUTER ERROR] {ex.Message}");
                throw new InvalidOperationException($"Güncelleme hatası: {ex.InnerException?.Message ?? ex.Message}", ex);
            }
        }

        /// <summary>
        /// ✅ 8. Silme (soft delete)
        /// </summary>
        public async Task<bool> DeleteStockCardAsync(
            Guid stockCardId,
            string userName,
            CancellationToken cancellationToken = default)
        {
            var card = await _stockCardRepo.GetAsync(sc => sc.Id == stockCardId && !sc.IsDeleted, tracking: true);

            if (card == null)
                throw new InvalidOperationException("Stok kartı bulunamadı.");

            card.IsDeleted = true;
            card.DeletedDate = DateTime.Now;
            card.DeletedBy = userName;

            await _stockCardRepo.UpdateAsync(card);
            await _saRepo.SaveChangesAsync(cancellationToken);

            return true;
        }

        /// <summary>
        /// ✅ 9. Feature değerleri getir
        /// </summary>
        public async Task<List<FeatureValueDto>> GetFeatureValuesAsync(Guid featureId)
        {
            var values = await _saRepo.GetFeatureValuesByFeatureIdAsync(featureId);

            return values.Select(fv => new FeatureValueDto
            {
                Id = fv.Id,
                Code = fv.Code,
                Name = fv.Name,
                SortOrder = fv.SortOrder
            }).ToList();
        }

        // ========== HELPER METHODS ==========

        private async Task<Guid> GetSaGroupIdAsync()
        {
            var groups = await _groupRepo.GetAllAsync(tracking: false);
            var saGroup = groups.FirstOrDefault(x => x.Code == "A");
            if (saGroup == null)
                throw new InvalidOperationException("SA (A) grubu tanımlı değil.");
            return saGroup.Id;
        }

        private async Task<string> BuildOptionKeyAsync(
            Dictionary<Guid, Guid> selectedFeatureValues,
            CancellationToken cancellationToken)
        {
            if (selectedFeatureValues == null || !selectedFeatureValues.Any())
                return string.Empty;

            var featureIds = selectedFeatureValues.Keys.ToList();
            var valueIds = selectedFeatureValues.Values.ToList();

            var features = await _saRepo.GetFeaturesByIdsAsync(featureIds, cancellationToken);
            var values = await _saRepo.GetFeatureValuesByIdsAsync(valueIds, cancellationToken);

            var parts = selectedFeatureValues
                .Select(kvp =>
                {
                    var f = features.FirstOrDefault(x => x.Id == kvp.Key);
                    var v = values.FirstOrDefault(x => x.Id == kvp.Value);
                    if (f == null || v == null) return null;
                    return new { f.SortOrder, f.Code, ValueCode = v.Code };
                })
                .Where(x => x != null)
                .OrderBy(x => x!.SortOrder)
                .Select(x => $"{x!.Code}={x.ValueCode}")
                .ToList();

            return string.Join("|", parts);
        }

        private async Task<string> BuildFeatureDescriptionAsync(
            Dictionary<Guid, Guid> selectedFeatureValues,
            CancellationToken cancellationToken)
        {
            if (selectedFeatureValues == null || !selectedFeatureValues.Any())
                return string.Empty;

            var featureIds = selectedFeatureValues.Keys.ToList();
            var valueIds = selectedFeatureValues.Values.ToList();

            var features = await _saRepo.GetFeaturesByIdsAsync(featureIds, cancellationToken);
            var values = await _saRepo.GetFeatureValuesByIdsAsync(valueIds, cancellationToken);

            // Feature code → value code mapping
            var featureDict = selectedFeatureValues
                .Select(kvp =>
                {
                    var f = features.FirstOrDefault(x => x.Id == kvp.Key);
                    var v = values.FirstOrDefault(x => x.Id == kvp.Value);
                    if (f == null || v == null) return null;
                    return new { FeatureCode = f.Code, ValueCode = v.Code };
                })
                .Where(x => x != null)
                .ToDictionary(x => x!.FeatureCode, x => x!.ValueCode);

            var parts = new List<string>();

            // ✅ 1. PRODUCT_TYPE (sabit: CIVATA)
            parts.Add("CIVATA");

            // ✅ 2. STANDARD
            if (featureDict.ContainsKey("STANDARD"))
                parts.Add(featureDict["STANDARD"]);

            // ✅ 3. THREAD_SYSTEM
            if (featureDict.ContainsKey("THREAD_SYSTEM"))
                parts.Add(featureDict["THREAD_SYSTEM"]);

            // ✅ 4. HEAD_TYPE (varsa)
            if (featureDict.ContainsKey("HEAD_TYPE"))
                parts.Add(featureDict["HEAD_TYPE"]);

            // ✅ 5. METRIC x LENGTH (birleşik format)
            var metric = featureDict.ContainsKey("METRIC") ? featureDict["METRIC"] : "";
            var length = featureDict.ContainsKey("LENGTH") ? featureDict["LENGTH"] : "";

            if (!string.IsNullOrEmpty(metric) && !string.IsNullOrEmpty(length))
                parts.Add($"{metric}x{length}");
            else if (!string.IsNullOrEmpty(metric))
                parts.Add(metric);
            else if (!string.IsNullOrEmpty(length))
                parts.Add(length);

            // ✅ 6. MATERIAL
            if (featureDict.ContainsKey("MATERIAL"))
                parts.Add(featureDict["MATERIAL"]);

            // ✅ 7. STRENGTH
            if (featureDict.ContainsKey("STRENGTH"))
                parts.Add(featureDict["STRENGTH"]);

            // ✅ 8. COATING
            if (featureDict.ContainsKey("COATING"))
                parts.Add(featureDict["COATING"]);

            return string.Join(" | ", parts);
        }

        /// <summary>
        /// ✅ 11. YENİ: Rule-based form data
        /// </summary>
        public async Task<StockCodeSaFormDto> GetFormDataAsync(
            Guid productId,
            CancellationToken cancellationToken = default)
        {
            // Ürün bilgisi
            var product = await _productRepo.GetByIdAsync(productId, tracking: false);
            if (product == null)
                throw new InvalidOperationException("Ürün bulunamadı.");

            // Tüm feature'ları getir
            var features = await _saRepo.GetAllFeaturesOrderedAsync(cancellationToken);

            // Bu ürün için feature kurallarını getir (FixedValue include edilmiş)
            var featureRules = await _saRepo.GetFixedProductFeatureRulesAsync(productId, cancellationToken);

            var formFeatures = new List<StockCodeSaFormFeatureDto>();

            foreach (var feature in features)
            {
                var rule = featureRules.FirstOrDefault(r => r.SFeatureId == feature.Id);

                if (rule == null) continue; // Bu feature bu ürün için kullanılmıyor

                var formFeature = new StockCodeSaFormFeatureDto
                {
                    FeatureId = feature.Id,
                    FeatureCode = feature.Code,
                    FeatureName = feature.Name,
                    IsFixed = rule.IsFixed,
                    FixedValueId = rule.FixedValueId,
                    FixedValueCode = rule.FixedValue?.Code,
                    FixedValueName = rule.FixedValue?.Name,
                    AvailableValues = new List<FeatureValueDto>()
                };

                // Eğer sabit değilse, izinli değerleri getir
                if (!rule.IsFixed)
                {
                    var allowedValues = await _saRepo.GetFeatureValueRulesByFeatureAsync(productId, feature.Id, cancellationToken);

                    formFeature.AvailableValues = FeatureValueSortHelper.SortForUi(
                        allowedValues.Select(r => new FeatureValueDto
                        {
                            Id = r.SFeatureValue.Id,
                            Code = r.SFeatureValue.Code,
                            Name = r.SFeatureValue.Name,
                            SortOrder = r.SortOrder
                        }).ToList());
                }

                formFeatures.Add(formFeature);
            }

            return new StockCodeSaFormDto
            {
                ProductId = productId,
                ProductCode = product.Code,
                ProductName = product.Name,
                Features = formFeatures
            };
        }
    }
}
