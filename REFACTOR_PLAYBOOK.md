# Refactor Playbook (Katman Sınırları + DTO/VM Ayrımı + Kullanılmayan Dosya Temizliği)

Bu doküman, repo'nun **çalışan sistemi bozmadan** sürdürülebilir bir mimariye taşınması için uygulanabilir bir yol haritası sunar.

## Tek PR ile yapmak mümkün mü?

Kısa cevap: **Teknik olarak mümkün**, ama bu repo ölçeğinde **yüksek riskli**.

Öneri:
- **1 büyük hedef**,
- **5-7 küçük ve doğrulanabilir PR**.

Bu yaklaşım:
- Kod incelemeyi kolaylaştırır,
- Regresyonu izole eder,
- Rollback'i ucuz hale getirir,
- Ekibe onboarding sırasında netlik sağlar.

## Hedef Mimari Sınırlar

### Application katmanı
- Use-case ve iş kuralları burada yaşar.
- Dış dünyaya DTO döner/alır.
- Presentation'a özgü ViewModel içermez.

### Presentation katmanı
- Controller + View + ViewModel.
- UI odaklı validasyonlar ve dönüştürmeler.
- Domain/Application iş kuralı barındırmaz.

### Geçiş kuralı
- `Controller -> Application Service -> Repository`
- Controller içinde kural hesaplaması/if-else bloğu birikimi engellenir.

## DTO / VM Ayrım Kuralı

- `DTO`: Katmanlar arası veri taşıma (Application sınırı).
- `VM`: Sadece View binding ve UI davranışı.
- İsimlendirme:
  - `...Dto` sadece Application'da,
  - `...Vm`/`...ViewModel` sadece Presentation'da.

## Önerilen PR Planı

### PR-1: Envanter + Sözleşme
- Mevcut servisler, DTO'lar, VM'ler ve controller sorumluluklarının haritasını çıkar.
- "Katmanlar arası kural" belgesini ekle.
- Davranış değiştirme yok.

### PR-2: DTO/VM Ayrımı Sertleştirme
- Presentation içinde yanlışlıkla kullanılan DTO'ları VM'e taşı.
- Application tarafında UI bağımlı sınıfları kaldır.
- Mapping noktalarını tekilleştir.

### PR-3: İş Kurallarını Uygulama Servislerine Taşıma
- Controller içindeki kural kodlarını Application servislerine taşı.
- Her grup (SA/SB/SC/...) için ortak şablon uygula.

### PR-4: Ortak Altyapı / Tekrar Azaltma
- Ortak hesaplama, sıralama ve lookup akışlarını ortak servislerde birleştir.
- Kopyalanmış kod bloklarını tek yere indir.

### PR-5: Kullanılmayan Dosya Temizliği
- Referanssız class/DTO/VM dosyalarını kaldır.
- Namespace ve csproj referanslarını güncelle.
- Temizlik sonrası smoke test.

### PR-6: İsimlendirme ve Klasör Standardizasyonu
- Klasör adları ve sınıf son eklerini standardize et (`Dto`, `Vm`, `Service`).
- Tutarsız dosya adlarını düzelt.

### PR-7: Son Stabilizasyon
- Build/test ve kritik akış smoke testleri.
- Değişiklik özeti + mimari diyagram güncellemesi.

## Kullanılmayan Dosya Temizliği İçin Operasyonel Kriter

Bir dosya silinmeden önce aşağıdakiler sağlanmalı:
- `rg` ile tip/üyenin kod tabanında aktif referansı yok.
- Reflection/dinamik kullanım için explicit allowlist kontrolü yapıldı.
- İlgili route/view/service akışında çağrılmadığı doğrulandı.
- Commit mesajında hangi dosyanın neden kaldırıldığı belirtildi.

## Definition of Done

- Katman ihlali bulunan dosya sayısı: **0**
- Application içinde VM referansı: **0**
- Presentation içinde Domain entity referansı: **0** (zorunlu istisnalar hariç)
- Kullanılmayan dosyalar kaldırılmış ve değişiklikler dokümante edilmiş.
- Yeni gelen bir geliştirici, 30 dakika içinde bir akışı uçtan uca izleyebiliyor.
