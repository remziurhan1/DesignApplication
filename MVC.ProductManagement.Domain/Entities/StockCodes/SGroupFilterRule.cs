using MVC.ProductManagement.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Entities.StockCodes
{
    /// <summary>
    /// Kural tablosu:
    /// Category + Fluid -> Hangi SProductGroup'lar açılacak?
    /// </summary>
    public class SGroupFilterRule : AuditableEntity
    {
        public Guid CategoryId { get; set; }
        public Guid FluidId { get; set; }
        public Guid SProductGroupId { get; set; }

        // Navigation (istersen kapatabilirsin)
        public virtual SCategory Category { get; set; } = default!;
        public virtual Fluid Fluid { get; set; } = default!;
        public virtual SProductGroup SProductGroup { get; set; } = default!;
    }
}
