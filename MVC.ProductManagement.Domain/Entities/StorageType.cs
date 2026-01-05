using MVC.ProductManagement.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Entities
{
    public class StorageType : AuditableEntity
    {
        public string Name { get; set; }
    //    public string Density { get; set; }
    //deneme
        public string? Description { get; set; }

        public virtual ICollection<EN13458Calculation> EN13458Calculations { get; set; } = new List<EN13458Calculation>();
        public virtual ICollection<StorageTypeProperties> ProductProperties { get; set; }
        = new List<StorageTypeProperties>();

    }
}
