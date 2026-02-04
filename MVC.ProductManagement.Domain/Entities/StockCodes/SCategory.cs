using MVC.ProductManagement.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Entities.StockCodes
{
    /// <summary>
    /// Filtreleme için en üst kırılım (UI: Category dropdown)
    /// Örn: "Aksesuar", "Hammadde", "Resimli Parça" vb.
    /// </summary>
    public class SCategory : AuditableEntity
    {
        public string Code { get; set; } = default!; // Kısa Kod 
        public string Name { get; set; } = default!; // Ekranda Gözükecek isim

        // Navigation (opsiyonel)
        // public ICollection<SGroupFilterRule> GroupFilterRules { get; set; } = new List<SGroupFilterRule>();
    }
}
