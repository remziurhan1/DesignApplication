using System.ComponentModel.DataAnnotations;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.SalesRequestVMs
{
    public class CustomerListVm
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string ContactName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public bool IsActive { get; set; }
    }

    public class CustomerFormVm
    {
        public Guid? Id { get; set; }

        [Required, StringLength(200)]
        [Display(Name = "Firma adı")]
        public string CompanyName { get; set; } = string.Empty;

        [Required, StringLength(100)]
        [Display(Name = "Yetkili kişi")]
        public string ContactName { get; set; } = string.Empty;

        [EmailAddress, StringLength(100)]
        [Display(Name = "E-posta")]
        public string? Email { get; set; }

        [StringLength(30)]
        [Display(Name = "Telefon")]
        public string? Phone { get; set; }

        [StringLength(500)]
        [Display(Name = "Adres")]
        public string? Address { get; set; }

        [StringLength(100)]
        [Display(Name = "Şehir")]
        public string? City { get; set; }

        [StringLength(100)]
        [Display(Name = "Ülke")]
        public string? Country { get; set; }

        [StringLength(50)]
        [Display(Name = "Vergi numarası")]
        public string? TaxNumber { get; set; }

        [StringLength(100)]
        [Display(Name = "Vergi dairesi")]
        public string? TaxOffice { get; set; }

        [StringLength(1000)]
        [Display(Name = "Notlar")]
        public string? Notes { get; set; }

        [Display(Name = "Aktif")]
        public bool IsActive { get; set; } = true;
    }
}
