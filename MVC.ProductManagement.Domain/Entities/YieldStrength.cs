using MVC.ProductManagement.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Entities
{
    public class YieldStrength : AuditableEntity
    {
        public Guid MaterialFormId { get; set; }
        public virtual MaterialForm MaterialForm { get; set; }

        public double Temperature { get; set; }    // °C
        public double ThicknessMin { get; set; }
        public double ThicknessMax { get; set; }

        public double Rp02 { get; set; }           // MPa
        public double Rm { get; set; }             // MPa
    }
}
