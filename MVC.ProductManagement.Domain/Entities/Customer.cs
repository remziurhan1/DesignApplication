using MVC.ProductManagement.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Entities
{
    /// <summary>
    /// Müşteri
    /// </summary>
    public class Customer : AuditableEntity
    {
        /// <summary>
        /// Firma adı
        /// </summary>
        public string CompanyName { get; set; } = string.Empty;

        /// <summary>
        /// Yetkili kişi adı
        /// </summary>
        public string ContactName { get; set; } = string.Empty;

        /// <summary>
        /// E-posta
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Telefon
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// Adres
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Şehir
        /// </summary>
        public string? City { get; set; }

        /// <summary>
        /// Ülke
        /// </summary>
        public string? Country { get; set; }

        /// <summary>
        /// Vergi numarası
        /// </summary>
        public string? TaxNumber { get; set; }

        /// <summary>
        /// Vergi dairesi
        /// </summary>
        public string? TaxOffice { get; set; }

        /// <summary>
        /// Notlar
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// Aktif mi?
        /// </summary>
        public bool IsActive { get; set; } = true;
    }
}
