using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Enums
{
    public enum QuoteStatus
    {
        /// <summary>
        /// Taslak
        /// </summary>
        Draft = 1,

        /// <summary>
        /// Onay bekliyor
        /// </summary>
        PendingApproval = 2,

        /// <summary>
        /// Onaylandı
        /// </summary>
        Approved = 3,

        /// <summary>
        /// Reddedildi
        /// </summary>
        Rejected = 4,

        /// <summary>
        /// Revize edildi
        /// </summary>
        Revised = 5
    }
}
