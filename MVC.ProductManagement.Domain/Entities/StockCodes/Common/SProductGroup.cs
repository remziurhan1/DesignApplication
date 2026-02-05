using MVC.ProductManagement.Domain.Core.BaseEntities;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Entities.StockCodes
{
    public class SProductGroup : AuditableEntity
    {
        public string Code { get; set; } = default!; // A,B,C..H,Z
        public string Name { get; set; } = default!;

        public virtual ICollection<SProduct> Products { get; set; } = new List<SProduct>();
     //   public virtual ICollection<SAssemblyGroup> AssemblyGroups { get; set; } = new List<SAssemblyGroup>();
        public virtual ICollection<PrefixRule> PrefixRules { get; set; } = new List<PrefixRule>();
        public virtual ICollection<StockCard> StockCards { get; set; } = new List<StockCard>();
    }
}
