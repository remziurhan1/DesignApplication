using MVC.ProductManagement.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Entities
{
    public class Quote : AuditableEntity
    {
        public Guid TankRequestId { get; set; }
        public decimal MaterialCost { get; set; }
        public decimal LaborCost { get; set; }
        public decimal AdditionalCost { get; set; }
        public decimal TotalCost { get; set; }
        public decimal MarginRate { get; set; }
        public decimal SalePrice { get; set; }
        public string CurrencyCode { get; set; } = "TRY";
        public string? Notes { get; set; }

        public virtual TankRequest TankRequest { get; set; } = null!;
    }
}
