using MVC.ProductManagement.Domain.Core.BaseEntities;
using MVC.ProductManagement.Domain.Entities.StockCodes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Entities.StockCodes.Features
{
    public class StockCardFeatureSelection : AuditableEntity
    {
        public Guid StockCardId { get; set; }
        public virtual StockCard StockCard { get; set; } = default!;

        public Guid SFeatureId { get; set; }
        public virtual SFeature SFeature { get; set; } = default!;

        public Guid SFeatureValueId { get; set; }
        public virtual SFeatureValue SFeatureValue { get; set; } = default!;
    }
}
