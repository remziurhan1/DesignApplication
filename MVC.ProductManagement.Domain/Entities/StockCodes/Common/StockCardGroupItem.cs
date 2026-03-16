using MVC.ProductManagement.Domain.Core.BaseEntities;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using System;

namespace MVC.ProductManagement.Domain.Entities.StockCodes
{
    public class StockCardGroupItem : AuditableEntity
    {
        public Guid StockCardGroupId { get; set; }
        public virtual StockCardGroup StockCardGroup { get; set; } = default!;

        public Guid? StockCardId { get; set; }
        public virtual StockCard? StockCard { get; set; }

        public bool IsCustomItem { get; set; }
        public string? CustomDescription { get; set; }
        public string? QuantityUnit { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
        public int SortOrder { get; set; }
    }
}
