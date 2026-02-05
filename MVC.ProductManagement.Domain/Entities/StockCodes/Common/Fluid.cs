using MVC.ProductManagement.Domain.Core.BaseEntities;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Entities.StockCodes
{
    public class Fluid : AuditableEntity
    {
        public string Code { get; set; } = default!;  // LPG, LNG, LIN...
        public string Name { get; set; } = default!;

        public virtual ICollection<PrefixRule> PrefixRules { get; set; } = new List<PrefixRule>();
        public virtual ICollection<StockCard> StockCards { get; set; } = new List<StockCard>();
    }
}
