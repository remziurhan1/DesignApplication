using MVC.ProductManagement.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Entities
{
    public class ProductCode : AuditableEntity
    {
        public Guid GasTypeId { get; set; }
        public string Prefix { get; set; } = string.Empty;
        public int Sequence { get; set; }
        public string Code { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        public virtual GasType GasType { get; set; } = null!;
    }
}
