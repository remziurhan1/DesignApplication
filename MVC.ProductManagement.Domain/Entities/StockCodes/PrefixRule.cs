using MVC.ProductManagement.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Entities.StockCodes
{
    public class PrefixRule : AuditableEntity
    {
        public Guid SProductGroupId { get; set; }
        public virtual SProductGroup SProductGroup { get; set; } = default!;

        public Guid SProductId { get; set; }
        public virtual SProduct SProduct { get; set; } = default!;

        public string Prefix4 { get; set; } = default!;

    }
}
