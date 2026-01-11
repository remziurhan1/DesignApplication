using MVC.ProductManagement.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Entities
{
    public class GasTypeDesignStandard : BaseEntity
    {
        /// <summary>
        /// Gaz tipi ID
        /// </summary>
        public Guid GasTypeId { get; set; }

        /// <summary>
        /// Tasarım standardı ID
        /// </summary>
        public Guid DesignStandardId { get; set; }

        // Navigation Properties
        public virtual GasType GasType { get; set; } = null!;
        public virtual DesignStandard DesignStandard { get; set; } = null!;
    }
}
