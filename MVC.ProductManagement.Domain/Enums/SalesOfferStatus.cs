using System.ComponentModel.DataAnnotations;

namespace MVC.ProductManagement.Domain.Enums
{
    public enum SalesOfferStatus
    {
        [Display(Name = "F: Sözleşme Aşamasında")]
        F = 1,
        [Display(Name = "GA: %90 ve üzeri")]
        GA = 2,
        [Display(Name = "GB: %75-%90 arası")]
        GB = 3,
        [Display(Name = "GC: %50-%75 arası")]
        GC = 4,
        [Display(Name = "H: %50 altı")]
        H = 5,
        [Display(Name = "P: Kaybedildi")]
        P = 6,
        [Display(Name = "S: Satıldı")]
        S = 7
    }
}
