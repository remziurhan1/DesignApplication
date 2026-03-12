# EN 13458-2'ye Göre Kriyojenik Vakum Yalıtımlı Tank Dış Tankı (Outer Vessel) Harici Basınç Hesap Algoritması

Bu doküman, vakum yalıtımlı kriyojenik tanklarda **dış tankın atmosferik harici basınca** dayanımını, EN 13458-2 yaklaşımına göre yazılımda uygulanabilir bir sırada açıklar.

> Not: Verilen denklemler, kullanıcının istediği sadeleştirilmiş mühendislik algoritmasıdır. Nihai tasarımda güncel standart metni, ulusal ekler ve şirket içi doğrulama kuralları ayrıca kontrol edilmelidir.

---

## 1) Giriş Parametreleri (Input)

Aşağıdaki değerler kullanıcıdan veya veri tabanından alınır:

- `Da` : Dış tank dış/karakteristik çapı (m veya mm)
- `s` : Nominal et kalınlığı (m veya mm)
- `c` : Tolerans + korozyon payı (aynı birim)
- `lb` : Desteklenmemiş silindir boyu / burkulma boyu (aynı birim)
- `E` : Elastisite modülü (MPa veya Pa)
- `ν` : Poisson oranı (boyutsuz)
- `K` : Akma dayanımıyla ilişkili malzeme katsayısı (MPa veya Pa)
- `u` : Dairesellik (ovalite) hatası (%)
- `hasStiffener` : Güçlendirme halkası var mı? (bool)
- `I_ring` : Stiffener halka atalet momenti (varsa)
- `A_ring` : Stiffener halka kesit alanı (varsa)

### Fiziksel anlamlar

- **`Da` büyüdükçe** ince cidarlı davranış artar, harici basınç dayanımı düşer.
- **`t = s-c` büyüdükçe** burkulma dayanımı güçlü şekilde artar.
- **`lb` büyüdükçe** panelin serbest boyu artar, burkulma riski yükselir.
- **`E` yükseldikçe** elastik burkulma direnci artar.
- **`ν`**, elastik kabuk davranışındaki enine şekil değiştirme etkisini temsil eder.
- **`K` yükseldikçe** plastik deformasyona karşı direnç artar.
- **`u` (ovalite) arttıkça** gerçek dayanım düşer.

---

## 2) Tasarım Harici Basıncı

Vakum yalıtımlı dış tank için tasarım harici basıncı:

- `p = 1 bar`
- eşdeğer olarak `p = 0.1 MPa`

> Yazılımda tek birim sistemi seçin (öneri: MPa + mm). Girişler farklı birimdeyse önce dönüştürün.

---

## 3) Emniyet Katsayıları

Silindirik dış tank için:

- `Sk = 2.0`  (elastik burkulma emniyet katsayısı)
- `Sp = 1.1`  (plastik deformasyon emniyet katsayısı)

---

## 4) Geometrik Oranlar

Önce etkin et kalınlığı hesaplanır:

\[
 t = s - c
\]

Sonra boyutsuz oranlar:

\[
\text{D\_over\_t} = \frac{Da}{t}
\]

\[
\text{L\_over\_D} = \frac{lb}{Da}
\]

Ayrıca plastik deformasyon dal ayrımı için kullanılacak oran:

\[
\frac{Da}{lb}
\]

---

## 5) Elastik Burkulma Basıncı (`pe`)

### 5.1 Basitleştirilmiş denklem

\[
 p_e = \frac{E}{Sk} \left(\frac{t}{Da}\right)^3 \left(\frac{1}{1.2}\right)
\]

### 5.2 Daha genel denklem

\[
 p_e = \frac{E}{Sk} \left(\frac{t}{Da}\right)^3 \left[\frac{1}{12(1-\nu^2)}\right]
\]

Yazılımda bir parametre ile yöntem seçilebilir (`useGeneralElasticFormula=true/false`).

---

## 6) Plastik Deformasyon Basıncı (`pp`)

Önce dal seçimi:

- Eğer \( Da/lb \le 5 \): kısa/orta panel ifadesi
- Eğer \( Da/lb > 5 \): uzun panel yaklaşımı

### 6.1 Durum A: \(Da/lb \le 5\)

\[
 p_p = \frac{K}{Sp} \left(\frac{t}{Da}\right)
       \left[\frac{1}{1 + 0.2\,(Da/lb)}\right]
       \left[\frac{1}{1-u/100}\right]
\]

### 6.2 Durum B: \(Da/lb > 5\)

İki sınır basıncı hesaplanır:

\[
 p_{p1} = \frac{K}{Sp}\left(\frac{t}{Da}\right)
\]

\[
 p_{p2} = \frac{K}{Sp} \cdot 30 \left(\frac{t}{lb}\right)^2
\]

Sonra:

\[
 p_p = \min(p_{p1},\,p_{p2})
\]

---

## 7) İzin Verilebilir Harici Basınç

Elastik ve plastik limitlerden küçük olan esas alınır:

\[
 p_{allow} = \min(p_e,\,p_p)
\]

---

## 8) Tasarım Uygunluk Kontrolü

Dış tank yeterlilik şartı:

\[
 p_{allow} \ge p
\]

- Şart sağlanıyorsa: tasarım harici basınç açısından uygundur.
- Sağlanmıyorsa: tipik iyileştirmeler
  - `s` artır (dolayısıyla `t` artar),
  - `lb` azalt (ek halka/mesnet ekle),
  - malzeme parametresi `K` daha yüksek kalite seç,
  - ovaliteyi (`u`) azaltacak imalat toleranslarını iyileştir.

---

## 9) Stiffener Ring Varsa Ek Kontroller

`hasStiffener = true` ise halka kesiti aşağıdaki iki şartı da sağlamalıdır:

### 9.1 Atalet momenti

\[
 I \ge \left(\frac{0.124\,p\,Da^3}{E}\right) \cdot 10\,(Da-t)
\]

### 9.2 Kesit alanı

\[
 A \ge \left(\frac{0.75\,p\,Da}{K}\right) \cdot 10\,(Da-t)
\]

Kontrol mantığı:

- `I_ok = (I_ring >= I_required)`
- `A_ok = (A_ring >= A_required)`
- Her ikisi true ise stiffener yeterlidir.

---

## 10) Yazılım İçin Önerilen Hesap Akışı

1. Girişleri doğrula (`s>c`, `Da>0`, `lb>0`, `E>0`, `K>0`, `0<=u<100`)
2. `t = s-c` hesapla
3. `pe` hesapla
4. `pp` hesapla (dal seçimi ile)
5. `p_allow = min(pe, pp)` hesapla
6. `p_allow >= p` kontrolü yap
7. Stiffener varsa `I` ve `A` kontrollerini yap
8. Sonucu raporla (geçti/kaldı + yönlendirici öneriler)

---

## Pseudocode (Mühendislik Yazılımına Uygun)

```pseudo
INPUT: Da, s, c, lb, E, nu, K, u, hasStiffener, I_ring, A_ring
CONST: p = 0.1 MPa, Sk = 2.0, Sp = 1.1

# 1) Validation
if Da <= 0 or lb <= 0 or s <= 0:
    error("Geometri pozitif olmalı")
if c < 0 or s <= c:
    error("Etkin et kalınlığı t = s-c > 0 olmalı")
if E <= 0 or K <= 0:
    error("Malzeme parametreleri pozitif olmalı")
if nu <= -1 or nu >= 0.5:
    warning("Poisson oranı tipik aralık dışında")
if u < 0 or u >= 100:
    error("u için geçerli aralık: 0 <= u < 100")

# 2) Effective thickness and ratios
t = s - c
D_over_t = Da / t
L_over_D = lb / Da
ratio_D_over_lb = Da / lb

# 3) Elastic buckling pressure
# simplified:
pe = (E / Sk) * (t / Da)^3 * (1 / 1.2)
# alternatively general:
# pe = (E / Sk) * (t / Da)^3 * (1 / (12 * (1 - nu^2)))

# 4) Plastic deformation pressure
if ratio_D_over_lb <= 5:
    pp = (K / Sp) * (t / Da) * (1 / (1 + 0.2 * ratio_D_over_lb)) * (1 / (1 - u/100))
else:
    pp1 = (K / Sp) * (t / Da)
    pp2 = (K / Sp) * 30 * (t / lb)^2
    pp = min(pp1, pp2)

# 5) Allowable external pressure
p_allow = min(pe, pp)

# 6) Main design check
design_ok = (p_allow >= p)

# 7) Optional stiffener checks
if hasStiffener:
    I_required = (0.124 * p * Da^3 / E) * 10 * (Da - t)
    A_required = (0.75  * p * Da    / K) * 10 * (Da - t)
    I_ok = (I_ring >= I_required)
    A_ok = (A_ring >= A_required)
else:
    I_required = null
    A_required = null
    I_ok = null
    A_ok = null

# 8) Output report
OUTPUT:
  t, D_over_t, L_over_D,
  pe, pp, p_allow, p,
  design_ok,
  (I_required, A_required, I_ok, A_ok if hasStiffener)
```

---

## Rapor Formatı (Öneri)

- Girdiler ve birimler
- Ara hesaplar: `t`, `Da/t`, `lb/Da`, `Da/lb`
- Limit basınçlar: `pe`, `pp`
- Governing mode: `min(pe, pp)` hangi moddan geldi?
- Son karar: `p_allow >= p`
- Eğer başarısızsa: önerilen minimum değişiklikler (ör. hedef `s` iterasyonu)

Bu yapı, hesap motorunun hem izlenebilirliğini hem de denetlenebilirliğini artırır.
