using MVC.ProductManagement.Domain.Core.BaseEntities;
using MVC.ProductManagement.Domain.Entities.Costing;
using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Domain.Entities
{
    public class EN13458CostAnalysis : AuditableEntity
    {
        public Guid EN13458CalculationId { get; set; }
        public virtual EN13458Calculation EN13458Calculation { get; set; } = null!;

        public int RevisionNo { get; set; }
        public string RevisionCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;

        public Guid? InnerHeadBombeLaborRateId { get; set; }
        public virtual BombeLaborRate? InnerHeadBombeLaborRate { get; set; }

        public Guid? OuterHeadBombeLaborRateId { get; set; }
        public virtual BombeLaborRate? OuterHeadBombeLaborRate { get; set; }

        public virtual ICollection<EN13458CostAnalysisItem> Items { get; set; } = new List<EN13458CostAnalysisItem>();
        public virtual ICollection<EN13458SalesPrice> SalesPrices { get; set; } = new List<EN13458SalesPrice>();
    }
}
