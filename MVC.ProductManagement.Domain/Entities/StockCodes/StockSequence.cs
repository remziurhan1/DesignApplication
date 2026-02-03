using MVC.ProductManagement.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Entities.StockCodes
{
    public class StockSequence : AuditableEntity
    {
        public string Prefix4 { get; set; } = default!;
        public int StartNumber { get; set; }
        public int LastNumber { get; set; }

        public virtual ICollection<StockCard> StockCards { get; set; } = new List<StockCard>();

    }
}
