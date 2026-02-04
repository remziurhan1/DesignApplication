using MVC.ProductManagement.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Entities.StockCodes
{
    public class SPrefixRule : AuditableEntity
    {
        public Guid SProductGroupId { get; set; }
        public Guid FluidId { get; set; }
        public Guid SProductId { get; set; }

        public string Prefix { get; set; } = null!;

        // Navigation (opsiyonel)
        public virtual SProductGroup SProductGroup { get; set; } = default!;
        public virtual Fluid Fluid { get; set; } = default!;
        public virtual SProduct SProduct { get; set; } = default!;
    }
}
