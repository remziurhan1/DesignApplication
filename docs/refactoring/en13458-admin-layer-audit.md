# EN13458 Admin Layer Audit

Bu not, Admin alanındaki `EN13458CalculationController` üzerinden başlayan katman gözden geçirmesidir. Amaç; hesaplama, maliyet, teklif ve stok kodu akışlarını Presentation controller yükünden ayırıp tek sorumluluklu servis ve yardımcı sınıflara taşımaktır.

## Yapılan Refaktörler

- `Delete` aksiyonu artık doğrudan `AppDbContext` kullanmıyor; EN13458 hesap, maliyet analizi, maliyet kalemi, satış fiyatı ve maliyet detayı silme akışı `IEN13458CalculationServices.DeleteAsync` metodunda.
- Maliyet parametre lookup sorguları (`LaborRate`, `GugHourlyRate`, `OverheadRate`, `BombeLaborRate`) controller içinden çıkarılıp `IEN13458CalculationServices.GetCostParameterLookupsAsync` metoduna alındı.
- EN13458 DTO ↔ VM mapping blokları `EN13458CalculationVmMapper` sınıfına taşındı.
- Excel detay export üretimi `IEN13458AdminExportService` / `EN13458AdminExportService` arkasına taşındı; controller sadece dosya sonucunu dönüyor.
- Word şartname export üretimi `IEN13458SpecificationExportService` / `EN13458SpecificationExportService` arkasına taşındı; controller sadece şablon yolu ve dosya sonucunu yönetiyor.
- Stok kodu seçiminde ana grup, alt grup ve metin araması için filtre modeli (`GeneratedStockCodeFilterDto`), servis metodu (`GetFilteredAsync`) ve Admin maliyet ekranı filtre UI'ı eklendi.

## Hâlâ Yanlış Katmanda veya Geniş Kalan Kodlar

### Presentation içinde ayrıştırılabilecekler

- **Specification view model hazırlığı:** `BuildSpecificationVmAsync` hâlâ controller içinde EN13458 sonuçlarını şartname ekran modeline çeviriyor. Bir sonraki adımda `IEN13458SpecificationBuilder` gibi ayrı bir sınıfa taşınmalı.
- **Lokal sayı/form parse işlemleri:** `ReadLocalizedDoubleFromForm` ve `ReadBooleanFromForm` HTTP detayı içeriyor ama iş akışlarını etkiliyor. Bunlar küçük bir model binder/helper olarak ayrılmalı; hesap/maliyet servislerine parse edilmiş değer gitmeli.
- **Lookup ViewBag hazırlığı:** Controller artık veri sorgularının çoğunu servisten alıyor; ancak `SelectListItem`/`ViewBag` hazırlığı hâlâ controller içinde. Bu bölüm presentation helper/view component seviyesine alınabilir.

### Application → daha net alt servislere bölünmeli

- **EN13458CalculationServices hâlâ geniş:** Hesaplama, maliyet analizi oluşturma, manuel stok maliyeti, stok grup maliyeti, bombe işçilik ve satış fiyatı aynı serviste. Teklif tarafını stabil hale getirmek için `IEN13458CostAnalysisService`, `IEN13458SalesPriceService`, `IEN13458ManualCostService` ve `IEN13458CalculationQueryService` gibi alt servisler önerilir.
- **Stok kodu filtreleme ilk adımda:** `GeneratedStockCodeService.GetFilteredAsync` mevcut liste DTO'su üzerinden filtreleme yapıyor. Veri büyürse bu filtreler EF query seviyesine indirilmeli ve sayfalama DTO'su ile dönmeli.

## Önerilen Sıradaki Refaktör Adımları

1. `BuildSpecificationVmAsync` bloğunu controller'dan çıkarıp specification builder servisine taşı.
2. `EN13458CalculationServices` içindeki maliyet, manuel stok, satış fiyatı ve query akışlarını ayrı Application servislerine böl.
3. Stok kodu filtrelerini EF tarafına indirip sayfalı sonuç döndür; maliyet/teklif ekranlarının aynı filtre modelini kullanmasını sağla.
4. Teklif akışını Admin hesap ekranından bağımsızlaştırmak için Sales/Design alanlarının kullanacağı Application DTO'larını controller view model'lerinden ayır.
