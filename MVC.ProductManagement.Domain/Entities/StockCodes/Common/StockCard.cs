using MVC.ProductManagement.Domain.Core.BaseEntities;
using MVC.ProductManagement.Domain.Entities.StockCodes.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Entities.StockCodes.Common
{
    public class StockCard : AuditableEntity
    {
        public string StockCode8 { get; set; } = default!;
        public string Prefix4 { get; set; } = default!;
        public int Serial4 { get; set; }
        public string OptionKey { get; set; } = default!;

        public Guid FluidId { get; set; }
        public virtual Fluid Fluid { get; set; } = default!;

        public Guid SProductGroupId { get; set; }
        public virtual SProductGroup SProductGroup { get; set; } = default!;

        public Guid SProductId { get; set; }
        public virtual SProduct SProduct { get; set; } = default!;

        // 🔹 ARTIK OPSİYONEL (LEGACY)
        public Guid? SAssemblyGroupId { get; set; }
        public virtual SAssemblyGroup? SAssemblyGroup { get; set; }

        public Guid StockSequenceId { get; set; }
        public virtual StockSequence StockSequence { get; set; } = default!;

        public virtual ICollection<StockCardFeatureSelection> FeatureSelections { get; set; }
    = new List<StockCardFeatureSelection>();

        public string Description { get; set; } = default!;
    }
}
