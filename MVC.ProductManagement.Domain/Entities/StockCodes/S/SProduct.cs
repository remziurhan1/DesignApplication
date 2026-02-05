using MVC.ProductManagement.Domain.Core.BaseEntities;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Domain.Entities.StockCodes
{
    public class SProduct : AuditableEntity
    {
        public Guid SProductGroupId { get; set; }
        public virtual SProductGroup SProductGroup { get; set; } = default!;

        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;

        // 🔴 PREFIX’İN SON HANESİ (0,1,2…)
        public int PrefixIndex { get; set; }

        public virtual ICollection<PrefixRule> PrefixRules { get; set; } = new List<PrefixRule>();
        public virtual ICollection<StockCard> StockCards { get; set; } = new List<StockCard>();
    }
}
