using MVC.ProductManagement.Domain.Core.BaseEntities;
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

        public virtual ICollection<EN13458CostAnalysisItem> Items { get; set; } = new List<EN13458CostAnalysisItem>();
    }
}
