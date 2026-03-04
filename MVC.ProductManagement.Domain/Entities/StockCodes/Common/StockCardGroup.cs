using MVC.ProductManagement.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Domain.Entities.StockCodes
{
    public class StockCardGroup : AuditableEntity
    {
        public string GroupCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string CurrencyCode { get; set; } = "TRY";
        public decimal TotalAmount { get; set; }

        public virtual ICollection<StockCardGroupItem> Items { get; set; } = new List<StockCardGroupItem>();
    }
}
