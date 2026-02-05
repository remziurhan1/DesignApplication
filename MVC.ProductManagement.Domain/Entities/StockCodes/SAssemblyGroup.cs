using MVC.ProductManagement.Domain.Core.BaseEntities;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Entities.StockCodes
{
    public class SAssemblyGroup : AuditableEntity
    {
        public Guid? SProductGroupId { get; set; }
        public virtual SProductGroup? SProductGroup { get; set; }

        public string Step3Letter { get; set; } = default!;
        public int Step4Digit { get; set; }
        public string Name { get; set; } = default!;

        public virtual ICollection<StockCard> StockCards { get; set; } = new List<StockCard>();

    }
}
