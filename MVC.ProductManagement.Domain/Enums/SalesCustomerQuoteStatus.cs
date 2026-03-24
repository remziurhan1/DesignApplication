using System.ComponentModel.DataAnnotations;

namespace MVC.ProductManagement.Domain.Enums
{
    public enum SalesCustomerQuoteStatus
    {
        [Display(Name = "Teklif Müşteriye İletilmedi")]
        NotShared = 1,
        [Display(Name = "Şartname Hazırlanıyor")]
        PreparingSpecification = 2,
        [Display(Name = "Teklif Müşteriye İletildi")]
        SharedWithCustomer = 3
    }
}
