# S Grupları Handler + Kural Servisi Mimarisi

Bu doküman S ürün gruplarını (SA, SB, SC, SD, SE, SF, SG, SH) seed'e bağımlı kalmadan servis kuralları ile yönetmek için hedef yapıyı özetler.

## 1) Mevcut Entity Tabanı (korunur)

Aşağıdaki entity'ler kural veri modeli için yeterli çekirdeği sağlar:

- `SProduct` (ürün/prefix tanımı: SAA0, SFA1 ...)
- `SProductFeatureRule` (feature aktif mi, sabit mi?)
- `SFeatureValueRule` (dropdown izinli değerler)
- `SFeatureValueDependency` (feature-değer bağımlılıkları)

## 2) Seed rolü (bootstrap)

Seed verileri ilk kurulum için default rule set olarak tutulur:

- SA için: `Seeds/StockCardSeed/SA/...`
- SF için: `Seeds/StockCardSeed/SF/...`

Canlı değişiklikler seed ile değil Admin Rule ekranı ile yönetilir.

## 3) Yeni uygulama katmanı servisi

Eklenen servis:

- `IStockRuleProfileService`
- `StockRuleProfileService`

Görev:

- Seçilen `S*` grup kodu için ürün + feature + allowed value profilini DB'den okuyup tek DTO döndürmek.
- Bu DTO Admin CRUD ekranı için okunabilir model sağlar.

## 4) Admin uç noktası

Eklenen endpoint:

- `GET /Admin/StockRuleProfile/Profile?groupCode=SA`
- `GET /Admin/StockRuleProfile/Profile?groupCode=SB`
- `GET /Admin/StockRuleProfile/Profile?groupCode=SC`
- `GET /Admin/StockRuleProfile/Profile?groupCode=SD`
- `GET /Admin/StockRuleProfile/Profile?groupCode=SE`
- `GET /Admin/StockRuleProfile/Profile?groupCode=SF`
- `GET /Admin/StockRuleProfile/Profile?groupCode=SG`
- `GET /Admin/StockRuleProfile/Profile?groupCode=SH`

Bu endpoint JSON profile döner, böylece UI tarafında kural yönetim ekranı hızlıca inşa edilebilir.

## 5) Önerilen CRUD fazları

1. **Read**: Profil endpointi ile ilgili S grubu kurallarını listele
2. **Create/Update**: Feature rule ve value rule ekleme/güncelleme handler'ları
3. **Delete**: Rule silme handler'ları
4. **Publish/Audit**: Kural versiyonlama ve değişiklik logu

## 6) M30x3x150 için öneri

- Feature'lar: `METRIC`, `THREAD_PITCH`, `LENGTH`
- Rule:
  - `METRIC=M30` => allowed `THREAD_PITCH=3`
  - `METRIC=M30` => allowed `LENGTH` listesi
- Kod üretim formatı: `M30x3x150`

Bu kurallar `SFeatureValueDependency` + `SFeatureValueRule` ile yönetilir.
