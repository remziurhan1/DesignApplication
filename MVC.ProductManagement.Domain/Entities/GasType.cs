using MVC.ProductManagement.Domain.Core.BaseEntities;
using MVC.ProductManagement.Domain.Entities.MVC.ProductManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Entities
{
    /// <summary>
    /// Gaz Tipi (LPG, LIN, LOX, LAR, LNG, LCO2)
    /// </summary>
    public class GasType : AuditableEntity
    {
        /// <summary>
        /// Gaz adı (örn: "LPG", "LIN", "LOX")
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gaz kodu (01, 02, 03, 04, 05, 06)
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// Mamül kodu prefix (CAA0, CDA0, CCA0, CPA0, CBA0, CEA0)
        /// </summary>
        public string ProductCodePrefix { get; set; } = string.Empty;

        /// <summary>
        /// Gaz grubu (LLL, LNG, CO2, LPG)
        /// </summary>
        public string GasGroup { get; set; } = string.Empty;

        /// <summary>
        /// Kimyasal formül (N2, O2, Ar, CH4, CO2)
        /// </summary>
        public string? ChemicalFormula { get; set; }

        /// <summary>
        /// Moleküler ağırlık (g/mol)
        /// </summary>
        public double? MolecularWeight { get; set; }

        /// <summary>
        /// Kritik sıcaklık (°C)
        /// </summary>
        public double? CriticalTemperature { get; set; }

        /// <summary>
        /// Kritik basınç (bar)
        /// </summary>
        public double? CriticalPressure { get; set; }

        /// <summary>
        /// Normal kaynama noktası (°C)
        /// </summary>
        public double? BoilingPoint { get; set; }

        /// <summary>
        /// Açıklama
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Aktif mi?
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Sıralama
        /// </summary>
        public int DisplayOrder { get; set; }

        // Navigation Properties
        public virtual ICollection<GasTypePressure> Pressures { get; set; } = new List<GasTypePressure>();
        public virtual ICollection<GasTypeDesignStandard> DesignStandards { get; set; } = new List<GasTypeDesignStandard>();
        public virtual ICollection<ThermodynamicProperty> ThermodynamicProperties { get; set; } = new List<ThermodynamicProperty>();
    }
}
