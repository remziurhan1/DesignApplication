using MVC.ProductManagement.Domain.Core.BaseEntities;
using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Domain.Entities.StockCodes;
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
        /// <summary>
        /// Silinmiş mi?
        /// </summary>
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// Silinme tarihi
        /// </summary>
        public DateTime? DeletedDate { get; set; }

        /// <summary>
        /// Silen kullanıcı
        /// </summary>
        public string? DeletedBy { get; set; }
        public string StockCode8 { get; set; } = default!;
        public string? StockCode { get; set; }
        public string? Unit { get; set; }
        public bool IsActive { get; set; } = true;

        public Guid? MaterialId { get; set; }
        public virtual Material? Material { get; set; }

        public string Prefix4 { get; set; } = default!;
        public int Serial4 { get; set; }
        public string OptionKey { get; set; } = default!;

        public Guid? FluidId { get; set; }
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

        // ========== ORTAK MODÜLLER (Opsiyonel) ==========

        /// <summary>
        /// Datasheet'ler (opsiyonel)
        /// </summary>
        public virtual ICollection<StockCardDatasheet> Datasheets { get; set; } = new List<StockCardDatasheet>();

        /// <summary>
        /// Fiyat geçmişi (opsiyonel)
        /// </summary>
        public virtual ICollection<StockCardPrice> Prices { get; set; } = new List<StockCardPrice>();

        /// <summary>
        /// Stok hareketleri (opsiyonel)
        /// </summary>
        public virtual ICollection<StockCardInventory> InventoryMovements { get; set; } = new List<StockCardInventory>();
    }
}
