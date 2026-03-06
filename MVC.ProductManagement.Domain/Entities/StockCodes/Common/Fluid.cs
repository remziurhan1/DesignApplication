using MVC.ProductManagement.Domain.Core.BaseEntities;
using System.Collections.Generic;

namespace MVC.ProductManagement.Domain.Entities.StockCodes
{
    public class Fluid : AuditableEntity
    {
        public string Code { get; set; } = default!;  // LPG, LNG, LIN...
        public string Name { get; set; } = default!;

        public virtual ICollection<PrefixRule> PrefixRules { get; set; } = new List<PrefixRule>();
    }
}
