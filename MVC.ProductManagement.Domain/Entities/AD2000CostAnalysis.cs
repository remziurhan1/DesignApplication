using MVC.ProductManagement.Domain.Core.BaseEntities;
using MVC.ProductManagement.Domain.Entities.Costing;
using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Domain.Entities
{
    public class AD2000CostAnalysis : AuditableEntity
    {
        public Guid AD2000CalculationId { get; set; }
        public virtual AD2000Calculation AD2000Calculation { get; set; } = null!;

        public int RevisionNo { get; set; }
        public string RevisionCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;

        public Guid? HeadBombeLaborRateId { get; set; }
        public virtual BombeLaborRate? HeadBombeLaborRate { get; set; }

        public virtual ICollection<AD2000CostAnalysisItem> Items { get; set; } = new List<AD2000CostAnalysisItem>();
        public virtual ICollection<AD2000SalesPrice> SalesPrices { get; set; } = new List<AD2000SalesPrice>();
    }
}
