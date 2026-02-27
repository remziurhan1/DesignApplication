# SA Grubu Seed Ekleme Notları

SA grubunda yeni **metrik (örn. `M5`)** ve **boy/uzunluk** değerleri eklemek için ana dosya:

- `MVC.ProductManagement.Infrastructure/Seeds/StockCardSeed/SA/Features/SAFeatureValueSeed.cs`

## 1) Tüm SA için yeni metrik veya uzunluk eklemek

- **Metrik listesi**: `metrics` dizisine eklenir.
- **Uzunluk listesi**: `lengths` dizisine eklenir.

Bu dosyadaki dizilere eklenen değerler, SA feature value seed verisine yazılır.

## 2) Prefix bazında (SAA0, SAB3 vb.) görünmesini istiyorsanız

Aynı değerin ürün/prefix filtrelerinde de görünmesi için:

- `MVC.ProductManagement.Infrastructure/Seeds/StockCardSeed/SA/Features/SAFeatureValueRuleSeed.cs`

Bu dosyada `AddAllMetrics(...)` ve `AddAllLengths(...)` helper dizileri kullanılıyor.
Yeni metrik/uzunluk burada da yoksa, bazı prefixlerde UI'da listelenmeyebilir.

## 3) Feature tanımı yoksa (yeni bir feature açacaksanız)

Mevcut durumda `METRIC` ve `LENGTH` feature'ları tanımlı.
Yeni bir feature açılması gerekirse:

- `MVC.ProductManagement.Infrastructure/Seeds/StockCardSeed/SA/Features/SAFeatureSeed.cs`

## 4) Özet

- Sadece SA genel değer eklemek: **`SAFeatureValueSeed.cs`**
- Prefix bazlı kural/izinleri de korumak: **`SAFeatureValueRuleSeed.cs`**
- Yeni feature tipi açmak: **`SAFeatureSeed.cs`**
