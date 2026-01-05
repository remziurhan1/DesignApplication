using MVC.ProductManagement.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Entities
{
    public class AllowableStress : AuditableEntity
    {
        public Guid MaterialFormId { get; set; }
        public virtual MaterialForm MaterialForm { get; set; }

        public double Temperature { get; set; }    // °C
        public double Stress { get; set; }         // MPa
    }
}
