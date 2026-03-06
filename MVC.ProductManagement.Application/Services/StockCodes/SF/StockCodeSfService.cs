using Microsoft.EntityFrameworkCore;
using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using MVC.ProductManagement.Application.DTOs.StockCodes.SF;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using MVC.ProductManagement.Infrastructure.AppContext;
using MVC.ProductManagement.Application.Services.StockCodes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.SF
{
    public class StockCodeSfService : IStockCodeSfService
    {
        private readonly AppDbContext _db;

        // SF feature kodları
        private const string F_AKIS_MEDYUMU = "SF_AKIS_MEDYUMU";
        private const string F_MARKA = "SF_MARKA";
        private const string F_VANA_TIPI = "SF_VANA_TIPI";
        private const string F_AKTUATOR = "SF_AKTUATOR";
        private const string F_DN = "SF_DN";
        private const string F_BASINC_SINIFI = "SF_BASINC_SINIFI";
        private const string F_BAGLANTI_TIPI = "SF_BAGLANTI_TIPI";
        private const string F_MALZEME = "SF_MALZEME";
        private const string F_AYAR_BASINCI = "SF_AYAR_BASINCI";
        private const string F_GIRIS_BASINCI = "SF_GIRIS_BASINCI";
        private const string F_CIKIS_BASINCI = "SF_CIKIS_BASINCI";
        private const string F_BAGLANTI_CAPI = "SF_BAGLANTI_CAPI";
        private const string F_OLCUM_TIPI = "SF_OLCUM_TIPI";
        private const string F_CIKIS_SINYALI = "SF_CIKIS_SINYALI";
        private const string F_VALF_TIPI = "SF_VALF_TIPI";
        private const string F_SAYAC_TIPI = "SF_SAYAC_TIPI";
        private const string F_GOZNEK = "SF_GOZNEK";
        private const string F_POMPA_TIPI = "SF_POMPA_TIPI";
        private const string F_GUC_KW = "SF_GUC_KW";
        private const string F_ADAPTOR_TIPI = "SF_ADAPTOR_TIPI";
        private const string F_BAGLANTI_1 = "SF_BAGLANTI_1";
        private const string F_BAGLANTI_2 = "SF_BAGLANTI_2";
        private const string F_CAPI_MM = "SF_CAPI_MM";
        private const string F_OLCUM_ARALIGI = "SF_OLCUM_ARALIGI";
        private const string F_MANOMETRE_TIPI = "SF_MANOMETRE_TIPI";
        private const string F_DALDIRMA_BOYU = "SF_DALDIRMA_BOYU";
        private const string F_CONTA_TIPI = "SF_CONTA_TIPI";
        private const string F_TIP = "SF_TIP";
        private const string F_KAPASITE = "SF_KAPASITE";

        public StockCodeSfService(AppDbContext db)
        {
            _db = db;
        }

        // ========== ÜRÜN LİSTESİ ==========
        public async Task<List<SfProductDto>> GetSfProductsAsync(CancellationToken ct = default)
        {
            return await _db.SProducts
                .Where(p => p.SProductGroup.Code == "F" && p.Status != Domain.Enums.Status.Deleted)
                .OrderBy(p => p.PrefixIndex)
                .Select(p => new SfProductDto
                {
                    Id = p.Id,
                    Code = p.Code,
                    Name = p.Name
                })
                .ToListAsync(ct);
        }

        // ========== FORM DATA ==========
        public async Task<StockCodeSfFormDto> GetFormDataAsync(Guid productId, CancellationToken ct = default)
        {
            var product = await _db.SProducts
                .FirstOrDefaultAsync(p => p.Id == productId, ct)
                ?? throw new InvalidOperationException("Ürün bulunamadı.");

            var productRules = await _db.SProductFeatureRules
                .Include(r => r.SFeature)
                .Include(r => r.FixedValue)
                .Where(r => r.SProductId == productId)
                .OrderBy(r => r.SFeature.SortOrder)
                .ToListAsync(ct);

            var valueRules = await _db.SFeatureValueRules
                .Include(r => r.SFeatureValue)
                .Where(r => r.SProductId == productId)
                .OrderBy(r => r.SortOrder)
                .ToListAsync(ct);

            var features = new List<StockCodeSfFormFeatureDto>();

            foreach (var rule in productRules)
            {
                var feature = new StockCodeSfFormFeatureDto
                {
                    FeatureId = rule.SFeatureId,
                    FeatureCode = rule.SFeature.Code,
                    FeatureName = rule.SFeature.Name,
                    FeatureGroup = ResolveFeatureGroup(rule.SFeature.Code),
                    IsFixed = rule.IsFixed
                };

                if (rule.IsFixed && rule.FixedValue != null)
                {
                    feature.FixedValueId = rule.FixedValueId;
                    feature.FixedValueCode = rule.FixedValue.Code;
                    feature.FixedValueName = rule.FixedValue.Name;
                }
                else
                {
                    var sorted = FeatureValueSortHelper.SortForUi(valueRules
                        .Where(v => v.SFeatureId == rule.SFeatureId)
                        .Select(v => new FeatureValueDto
                        {
                            Id = v.SFeatureValueId,
                            Code = v.SFeatureValue.Code,
                            Name = v.SFeatureValue.Name,
                            SortOrder = v.SortOrder
                        }));

                    feature.AvailableValues = sorted
                        .Select(v => new SfFeatureValueOptionDto
                        {
                            Id = v.Id,
                            Code = v.Code,
                            Name = v.Name
                        })
                        .ToList();
                }

                features.Add(feature);
            }

            var segment = ResolveProductSegment(product.Code);

            return new StockCodeSfFormDto
            {
                ProductId = product.Id,
                ProductCode = product.Code,
                ProductName = product.Name,
                ProductSegment = segment,
                SegmentFeatureSummary = BuildSegmentFeatureSummary(segment),
                FilterHints = BuildFilterHints(segment),
                Features = features
            };
        }

        // ========== KOD ÜRETME ==========
        public async Task<SfStockCodeGenerateResultDto> GenerateSfAsync(
    SfStockCodeGenerateRequestDto request,
    CancellationToken ct = default)
        {
            var product = await _db.SProducts
                .Include(p => p.SProductGroup)
                .FirstOrDefaultAsync(p => p.Id == request.SProductId, ct)
                ?? throw new InvalidOperationException("Ürün bulunamadı.");

            // ===============================
            // 1️⃣ Kural tabanlı seçimleri doğrula + sabitleri uygula
            // ===============================
            var validatedSelections = await BuildValidatedSelectionsForProductAsync(
                request.SProductId,
                request.SelectedFeatureValues,
                ct);

            var allSelections = validatedSelections
                .ToDictionary(x => x.FeatureCode, x => x.ValueCode);

            ValidateSfSelectionDependencies(allSelections);

            // ===============================
            // 4️⃣ OPTION KEY üret (kritik)
            // ===============================
            var optionKey = string.Join("|",
                allSelections
                    .OrderBy(x => x.Key)
                    .Select(x => $"{x.Key}:{x.Value}")
            );

            // ===============================
            // 5️⃣ Duplicate kontrol
            // ===============================
            var existing = await _db.Set<StockCard>()
                .FirstOrDefaultAsync(s =>
                    s.SProductId == request.SProductId &&
                    s.OptionKey == optionKey,
                    ct);

            if (existing != null)
                return new SfStockCodeGenerateResultDto
                {
                    StockCode8 = existing.StockCode8,
                    Description = existing.Description,
                    AlreadyExists = true
                };

            // ===============================
            // 6️⃣ Sequence al
            // ===============================
            var sequence = await _db.StockSequences
                .FirstOrDefaultAsync(s => s.Prefix4 == product.Code, ct)
                ?? throw new InvalidOperationException($"Sequence bulunamadı: {product.Code}");

            sequence.LastNumber++;

            var description = BuildDescription(product.Code, product.Name, allSelections);

            // ===============================
            // 7️⃣ StockCard oluştur
            // ===============================
            var stockCard = new StockCard
            {
                Id = Guid.NewGuid(),

                SProductId = product.Id,
                SProductGroupId = product.SProductGroupId,
                StockSequenceId = sequence.Id,

                StockCode8 = $"{product.Code}{sequence.LastNumber:D4}",
                Prefix4 = product.Code,
                Serial4 = sequence.LastNumber,

                OptionKey = optionKey,   // 🔥 KRİTİK
                Description = description,

                CreatedBy = "Admin",
                CreatedDate = DateTime.Now,
                Status = Domain.Enums.Status.Added
            };

            _db.Set<StockCard>().Add(stockCard);
            // ===============================
            // 8️⃣ Feature seçimlerini kaydet
            // ===============================
            await SaveSelectionsAsync(stockCard.Id, allSelections, "Admin", ct);

            await _db.SaveChangesAsync(ct);

            return new SfStockCodeGenerateResultDto
            {
                StockCode8 = stockCard.StockCode8,
                Description = stockCard.Description,
                AlreadyExists = false
            };
        }

        private static void ValidateSfSelectionDependencies(Dictionary<string, string> selections)
        {
            if (!selections.TryGetValue(F_BASINC_SINIFI, out var pressureClass) || string.IsNullOrWhiteSpace(pressureClass))
                return;

            var isPn = pressureClass.StartsWith("PN", StringComparison.OrdinalIgnoreCase);
            var isClass = pressureClass.StartsWith("Class", StringComparison.OrdinalIgnoreCase);

            if (!isPn && !isClass)
                return;

            if (isPn && selections.TryGetValue(F_BAGLANTI_CAPI, out var inchConnection) && !string.IsNullOrWhiteSpace(inchConnection))
            {
                if (inchConnection.Contains("\"", StringComparison.OrdinalIgnoreCase))
                    throw new InvalidOperationException("PN sınıfı seçildiğinde inch bağlantı çapı yerine DN bazlı seçim yapılmalıdır.");
            }

            if (isPn)
            {
                if (!selections.TryGetValue(F_DN, out var dnCode) || string.IsNullOrWhiteSpace(dnCode))
                    throw new InvalidOperationException("PN sınıfı için DN seçimi zorunludur.");
            }

            if (isClass)
            {
                if (selections.TryGetValue(F_DN, out var dnValue) && !string.IsNullOrWhiteSpace(dnValue))
                    throw new InvalidOperationException("Class basınç sınıfında DN yerine inch bazlı bağlantı çapı seçilmelidir.");

                if (!selections.TryGetValue(F_BAGLANTI_CAPI, out var classConn) || string.IsNullOrWhiteSpace(classConn))
                    throw new InvalidOperationException("Class basınç sınıfı için inch bağlantı çapı seçimi zorunludur.");
            }
        }

        private static string ResolveFeatureGroup(string featureCode)
        {
            if (featureCode.Contains("DN") || featureCode.Contains("CAPI") || featureCode.Contains("BAGLANTI"))
                return "Bağlantı ve Ölçüler";

            if (featureCode.Contains("BASINC") || featureCode.Contains("OLCUM_ARALIGI"))
                return "Basınç / Ölçüm";

            if (featureCode.Contains("VANA") || featureCode.Contains("VALF") || featureCode.Contains("POMPA") || featureCode.Contains("SAYAC") || featureCode.Contains("MANOMETRE") || featureCode.Contains("TIP"))
                return "Ekipman Tipi";

            if (featureCode.Contains("MALZEME") || featureCode.Contains("AKIS") || featureCode.Contains("MARKA"))
                return "Akışkan / Malzeme";

            return "Diğer";
        }

        private static string ResolveProductSegment(string productCode)
        {
            if (productCode.StartsWith("SFA") || productCode.StartsWith("SFC") || productCode.StartsWith("SFF") || productCode.StartsWith("SFJ") || productCode.StartsWith("SFK") || productCode.StartsWith("SFL"))
                return "Vana ve Regülasyon Grubu";

            if (productCode.StartsWith("SFG4") || productCode.StartsWith("SFG5") || productCode.StartsWith("SFG8") || productCode.StartsWith("SFH1") || productCode.StartsWith("SFH6"))
                return "Ölçüm / Enstrümantasyon Grubu";

            if (productCode.StartsWith("SFH3") || productCode.StartsWith("SFH4"))
                return "Pompa Grubu";

            return "Genel SF Grubu";
        }

        private static List<string> BuildSegmentFeatureSummary(string segment)
        {
            return segment switch
            {
                "Vana ve Regülasyon Grubu" => new List<string>
                {
                    "Temel: Vana/Valf tipi, DN veya bağlantı çapı, basınç sınıfı, bağlantı tipi, malzeme, marka",
                    "Filtre: DN seçimi varsa PN sınıfı; inch bağlantı varsa Class sınıfı"
                },
                "Ölçüm / Enstrümantasyon Grubu" => new List<string>
                {
                    "Temel: Ölçüm tipi/manometre tipi, ölçüm aralığı, çıkış sinyali, bağlantı çapı, marka",
                    "Filtre: Class seçimi ASME yaklaşımıyla inch bağlantı ister"
                },
                "Pompa Grubu" => new List<string>
                {
                    "Temel: Pompa tipi, güç, kapasite/çıkış basıncı, bağlantı bilgisi, marka"
                },
                _ => new List<string>
                {
                    "Temel: Ürüne tanımlı sabit ve dinamik feature kuralları"
                }
            };
        }

        private static List<string> BuildFilterHints(string segment)
        {
            var hints = new List<string>
            {
                "PN seçimi -> DN tabanlı kombinasyon",
                "Class seçimi -> ASME/inch tabanlı kombinasyon"
            };

            if (segment == "Ölçüm / Enstrümantasyon Grubu")
                hints.Add("Ölçüm grubunda bağlantı çapı ve sinyal tipi birlikte değerlendirilmelidir.");

            return hints;
        }

        private async Task<List<(Guid FeatureId, string FeatureCode, Guid ValueId, string ValueCode)>> BuildValidatedSelectionsForProductAsync(
            Guid productId,
            Dictionary<Guid, Guid> requestSelections,
            CancellationToken ct)
        {
            requestSelections ??= new Dictionary<Guid, Guid>();

            var rules = await _db.SProductFeatureRules
                .AsNoTracking()
                .Include(r => r.SFeature)
                .Include(r => r.FixedValue)
                .Where(r => r.SProductId == productId)
                .ToListAsync(ct);

            if (!rules.Any())
                throw new InvalidOperationException("Bu ürün için feature kuralı bulunamadı.");

            var valueRules = await _db.SFeatureValueRules
                .AsNoTracking()
                .Include(r => r.SFeatureValue)
                .Where(r => r.SProductId == productId)
                .ToListAsync(ct);

            var result = new List<(Guid FeatureId, string FeatureCode, Guid ValueId, string ValueCode)>();

            foreach (var rule in rules.Where(r => r.IsFixed))
            {
                if (!rule.FixedValueId.HasValue || rule.FixedValue == null)
                    throw new InvalidOperationException("Sabit kuralda FixedValue zorunludur.");

                result.Add((rule.SFeatureId, rule.SFeature.Code, rule.FixedValueId.Value, rule.FixedValue.Code));
            }

            foreach (var rule in rules.Where(r => !r.IsFixed))
            {
                if (!requestSelections.TryGetValue(rule.SFeatureId, out var selectedValueId))
                    throw new InvalidOperationException($"Zorunlu özellik seçilmedi. Feature: {rule.SFeature.Code}");

                var selectedRule = valueRules.FirstOrDefault(v =>
                    v.SFeatureId == rule.SFeatureId &&
                    v.SFeatureValueId == selectedValueId);

                if (selectedRule == null)
                    throw new InvalidOperationException($"Seçilen değer izinli değil. Feature: {rule.SFeature.Code}");

                result.Add((rule.SFeatureId, rule.SFeature.Code, selectedValueId, selectedRule.SFeatureValue.Code));
            }

            var allowedFeatureIds = rules.Select(r => r.SFeatureId).ToHashSet();
            var unexpectedFeature = requestSelections.Keys.FirstOrDefault(f => !allowedFeatureIds.Contains(f));
            if (unexpectedFeature != Guid.Empty)
                throw new InvalidOperationException($"Tanımsız feature gönderildi. FeatureId: {unexpectedFeature}");

            return result;
        }

        // ========== LİSTE ==========
        public async Task<SFStockCardListResultDto> GetStockCardsAsync(
            SFStockCardFilterDto filter,
            CancellationToken ct = default)
        {
            var query = _db.Set<StockCard>()
                .Include(s => s.SProduct)
                .Where(s => s.SProduct.SProductGroup.Code == "F"
                         && s.Status != Domain.Enums.Status.Deleted);

            if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
                query = query.Where(s =>
                    s.StockCode8.Contains(filter.SearchTerm) ||
                    s.Description.Contains(filter.SearchTerm) ||
                    s.SProduct.Code.Contains(filter.SearchTerm) ||
                    s.SProduct.Name.Contains(filter.SearchTerm));

            if (filter.ProductId.HasValue)
                query = query.Where(s => s.SProductId == filter.ProductId.Value);

            var totalCount = await query.CountAsync(ct);

            var items = await query
                .OrderByDescending(s => s.CreatedDate)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .Select(s => new SFStockCardListItemDto
                {
                    Id = s.Id,
                    StockCode8 = s.StockCode8,
                    ProductCode = s.SProduct.Code,
                    ProductName = s.SProduct.Name,
                    Description = s.Description,
                    CreatedDate = s.CreatedDate,
                    CreatedBy = s.CreatedBy
                })
                .ToListAsync(ct);

            return new SFStockCardListResultDto
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize
            };
        }

        // ========== DETAY ==========
        public async Task<SFStockCardDetailDto> GetStockCardDetailAsync(
            Guid stockCardId,
            CancellationToken ct = default)
        {
            var stockCard = await _db.Set<StockCard>()
                .AsNoTracking()
                .Include(s => s.SProduct)
                .FirstOrDefaultAsync(s => s.Id == stockCardId && !s.IsDeleted, ct)
                ?? throw new InvalidOperationException("Stok kartı bulunamadı.");

            var selections = await _db.Set<StockCardFeatureSelection>()
                .AsNoTracking()
                .Include(s => s.SFeature)
                .Include(s => s.SFeatureValue)
                .Where(s => s.StockCardId == stockCardId)
                .OrderBy(s => s.SFeature.SortOrder)
                .ToListAsync(ct);

            return new SFStockCardDetailDto
            {
                Id = stockCard.Id,
                StockCode8 = stockCard.StockCode8,
                Prefix4 = stockCard.Prefix4,
                Serial4 = stockCard.Serial4,
                ProductId = stockCard.SProductId,
                ProductCode = stockCard.SProduct.Code,
                ProductName = stockCard.SProduct.Name,
                Description = stockCard.Description,
                CreatedDate = stockCard.CreatedDate,
                CreatedBy = stockCard.CreatedBy,
                FeatureSelections = selections.Select((s, i) => new SFFeatureSelectionDto
                {
                    FeatureId = s.SFeatureId,
                    FeatureCode = s.SFeature.Code,
                    FeatureName = s.SFeature.Name,
                    ValueId = s.SFeatureValueId,
                    ValueCode = s.SFeatureValue.Code,
                    ValueName = s.SFeatureValue.Name,
                    SortOrder = i
                }).ToList()
            };
        }

        // ========== GÜNCELLEME ==========
        public async Task UpdateStockCardAsync(
            SFStockCardUpdateDto dto,
            string updatedBy,
            CancellationToken ct = default)
        {
            var stockCard = await _db.Set<StockCard>()
                .Include(s => s.SProduct)
                .FirstOrDefaultAsync(s => s.Id == dto.StockCardId, ct)
                ?? throw new InvalidOperationException("Stok kartı bulunamadı.");

            // Mevcut seçimleri sil
            var existing = await _db.Set<StockCardFeatureSelection>()
                .Where(s => s.StockCardId == dto.StockCardId)
                .ToListAsync(ct);
            _db.Set<StockCardFeatureSelection>().RemoveRange(existing);

            // Sabit değerleri çek
            var productRules = await _db.SProductFeatureRules
                .Include(r => r.SFeature)
                .Include(r => r.FixedValue)
                .Where(r => r.SProductId == stockCard.SProductId && r.IsFixed && r.FixedValueId != null)
                .ToListAsync(ct);

            var allSelections = new Dictionary<string, string>();

            foreach (var rule in productRules)
                if (rule.FixedValue != null)
                    allSelections[rule.SFeature.Code] = rule.FixedValue.Code;

            // Dinamik seçimleri ekle
            var selectedValueIds = dto.FeatureSelections.Values.ToList();
            var selectedValues = await _db.Set<SFeatureValue>()
                .Include(v => v.SFeature)
                .Where(v => selectedValueIds.Contains(v.Id))
                .ToListAsync(ct);

            foreach (var kvp in dto.FeatureSelections)
            {
                var val = selectedValues.FirstOrDefault(v => v.Id == kvp.Value);
                if (val != null)
                    allSelections[val.SFeature.Code] = val.Code;
            }

            stockCard.Description = BuildDescription(stockCard.SProduct.Code, stockCard.SProduct.Name, allSelections);
            stockCard.ModifiedBy = updatedBy;
            stockCard.ModifiedDate = DateTime.Now;

            await SaveSelectionsAsync(stockCard.Id, allSelections, updatedBy, ct);

            await _db.SaveChangesAsync(ct);
        }

        // ========== SİLME ==========
        public async Task DeleteStockCardAsync(
            Guid stockCardId,
            string deletedBy,
            CancellationToken ct = default)
        {
            var stockCard = await _db.Set<StockCard>()
                .FirstOrDefaultAsync(s => s.Id == stockCardId, ct)
                ?? throw new InvalidOperationException("Stok kartı bulunamadı.");

            stockCard.Status = Domain.Enums.Status.Deleted;
            stockCard.DeletedBy = deletedBy;
            stockCard.DeletedDate = DateTime.Now;

            await _db.SaveChangesAsync(ct);
        }

        // ========== DESCRIPTION BUILDER ==========
        private string BuildDescription(
            string productCode,
            string productName,
            Dictionary<string, string> selections)
        {
            // SF Description formatı:
            // ÜRÜN_ADI | AKIŞ_MEDYUMU | ANA_ÖZELLİK | DN/ÇAPI | BASINÇ | BAĞLANTI | MALZEME | MARKA
            var parts = new List<string>();

            // Ürün adı (kısa versiyon - ilk kelime grubu)
            parts.Add(productName);

            // Akış medyumu (eğer sabit değilse zaten product name'de var)
            if (selections.TryGetValue(F_AKIS_MEDYUMU, out var medyum))
                parts.Add(medyum);

            // Ana özellik (vana tipi / pompa tipi / sayaç tipi vs.)
            TryAdd(parts, selections, F_VANA_TIPI);
            TryAdd(parts, selections, F_VALF_TIPI);
            TryAdd(parts, selections, F_POMPA_TIPI);
            TryAdd(parts, selections, F_SAYAC_TIPI);
            TryAdd(parts, selections, F_ADAPTOR_TIPI);
            TryAdd(parts, selections, F_CONTA_TIPI);
            TryAdd(parts, selections, F_OLCUM_TIPI);
            TryAdd(parts, selections, F_TIP);
            TryAdd(parts, selections, F_MANOMETRE_TIPI);

            // Boyut/Çap
            TryAdd(parts, selections, F_DN);
            TryAdd(parts, selections, F_CAPI_MM);
            TryAdd(parts, selections, F_DALDIRMA_BOYU);
            TryAdd(parts, selections, F_BAGLANTI_CAPI);
            TryAdd(parts, selections, F_BAGLANTI_1);
            TryAdd(parts, selections, F_BAGLANTI_2);
            TryAdd(parts, selections, F_GUC_KW);
            TryAdd(parts, selections, F_KAPASITE);

            // Basınç
            TryAdd(parts, selections, F_BASINC_SINIFI);
            TryAdd(parts, selections, F_AYAR_BASINCI);
            TryAdd(parts, selections, F_GIRIS_BASINCI);
            TryAdd(parts, selections, F_CIKIS_BASINCI);
            TryAdd(parts, selections, F_OLCUM_ARALIGI);

            // Bağlantı / Filtre
            TryAdd(parts, selections, F_BAGLANTI_TIPI);
            TryAdd(parts, selections, F_GOZNEK);
            TryAdd(parts, selections, F_AKTUATOR);
            TryAdd(parts, selections, F_CIKIS_SINYALI);

            // Malzeme
            TryAdd(parts, selections, F_MALZEME);

            // Marka (en sona)
            TryAdd(parts, selections, F_MARKA);

            return string.Join(" | ", parts.Where(p => !string.IsNullOrWhiteSpace(p)));
        }

        private void TryAdd(List<string> parts, Dictionary<string, string> selections, string key)
        {
            if (selections.TryGetValue(key, out var val) && !string.IsNullOrWhiteSpace(val))
                parts.Add(val);
        }

        // ========== SEÇİM KAYDETME (Ortak) ==========
        private async Task SaveSelectionsAsync(
            Guid stockCardId,
            Dictionary<string, string> selections,
            string createdBy,
            CancellationToken ct)
        {
            foreach (var kvp in selections)
            {
                var feature = await _db.Set<SFeature>()
                    .FirstOrDefaultAsync(f => f.Code == kvp.Key, ct);
                if (feature == null) continue;

                var value = await _db.Set<SFeatureValue>()
                    .FirstOrDefaultAsync(v => v.SFeatureId == feature.Id && v.Code == kvp.Value, ct);
                if (value == null) continue;

                _db.Set<StockCardFeatureSelection>().Add(new StockCardFeatureSelection
                {
                    Id = Guid.NewGuid(),
                    StockCardId = stockCardId,
                    SFeatureId = feature.Id,
                    SFeatureValueId = value.Id,
                    CreatedBy = createdBy,
                    CreatedDate = DateTime.Now,
                    Status = Domain.Enums.Status.Added
                });
            }
        }
    }
}
