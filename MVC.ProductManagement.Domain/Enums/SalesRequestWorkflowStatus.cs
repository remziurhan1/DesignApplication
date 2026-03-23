using System.ComponentModel.DataAnnotations;

namespace MVC.ProductManagement.Domain.Enums
{
    public enum SalesRequestWorkflowStatus
    {
        [Display(Name = "Taslak")]
        Draft = 1,
        [Display(Name = "Fiyatlandırma Bekliyor")]
        Submitted = 2,
        [Display(Name = "Maliyet Çalışılıyor")]
        PricingInProgress = 3,
        [Display(Name = "Onaylandı")]
        Approved = 4,
        [Display(Name = "Reddedildi")]
        Rejected = 5
    }
}
