using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs.StockCodes.Common;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.SE
{
    /// <summary>
    /// SE Stok Kodu Üretim Sayfası için ViewModel
    /// </summary>
    public class SEStockCodeGenerateVm
    {
        // ========== INPUT (Kullanıcıdan Gelen) ==========

        /// <summary>
        /// Seçilen SE ürününün ID'si (SEA0, SEB1, SEC2...)
        /// </summary>
        public Guid SProductId { get; set; }

        /// <summary>
        /// SE ürünleri dropdown listesi (GET action'da doldurulur)
        /// </summary>
        public List<SelectListItem> Products { get; set; } = new();

        /// <summary>
        /// Seçilen ürüne ait feature'lar (AJAX ile yüklenir)
        /// 6 adet: Ürün Kategorisi, Malzeme, Kesit/Kapasite, Voltaj, Standart, Renk/Tip
        /// </summary>
        public IReadOnlyList<FeatureDto> Features { get; set; } = new List<FeatureDto>();

        /// <summary>
        /// Kullanıcının seçtiği feature değerleri
        /// Key: SFeatureId (örn: PRODUCT_CATEGORY)
        /// Value: SFeatureValueId (örn: Kablo Tesisat)
        /// </summary>
        public Dictionary<Guid, Guid> SelectedFeatureValues { get; set; } = new();

        // ========== OUTPUT (Kullanıcıya Gösterilen Sonuç) ==========

        /// <summary>
        /// Üretilen/bulunan 8 haneli stok kodu (örn: SEA01000)
        /// </summary>
        public string? StockCode8 { get; set; }

        /// <summary>
        /// Stok kartı açıklaması
        /// Örn: "Elektrik Malzemeleri | KABLO TESİSAT | Kablo Tesisat | Bakır | 2.5mm² | 220V | IEC 60227 | Siyah"
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Kod daha önce oluşturulmuş mu?
        /// true: Mevcut kod getirildi (sarı alert)
        /// false: Yeni kod oluşturuldu (yeşil alert)
        /// </summary>
        public bool? AlreadyExists { get; set; }

        /// <summary>
        /// Hata mesajı (varsa)
        /// Örn: "Ürün seçiniz", "Tüm özellikleri seçiniz"
        /// </summary>
        public string? ErrorMessage { get; set; }
    }
}