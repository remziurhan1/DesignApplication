using MVC.ProductManagement.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Entities
{
    /// <summary>
    /// Gaz Termodinamik Özellikleri (Sıcaklık-Basınç tablosu)
    /// </summary>
    public class ThermodynamicProperty : AuditableEntity
    {
        /// <summary>
        /// Gaz tipi ID
        /// </summary>
        public Guid GasTypeId { get; set; }

        /// <summary>
        /// Sıcaklık (°C)
        /// </summary>
        public double Temperature { get; set; }

        /// <summary>
        /// Basınç (bar)
        /// </summary>
        public double Pressure { get; set; }

        /// <summary>
        /// VL - Sıvı Özgül Hacim (m³/kg)
        /// </summary>
        public double VL { get; set; }

        /// <summary>
        /// VG - Gaz Özgül Hacim (m³/kg)
        /// </summary>
        public double VG { get; set; }

        /// <summary>
        /// HL - Sıvı Entalpi (kJ/kg)
        /// </summary>
        public double HL { get; set; }

        /// <summary>
        /// HG - Gaz Entalpi (kJ/kg)
        /// </summary>
        public double HG { get; set; }

        /// <summary>
        /// R - Özgül Isı Kapasitesi (kJ/kg·K)
        /// </summary>
        public double R { get; set; }

        /// <summary>
        /// SL - Sıvı Entropi (kJ/kg·K)
        /// </summary>
        public double SL { get; set; }

        /// <summary>
        /// SG - Gaz Entropi (kJ/kg·K)
        /// </summary>
        public double SG { get; set; }

        /// <summary>
        /// Veri kaynağı (NIST, REFPROP, vs.)
        /// </summary>
        public string? DataSource { get; set; }

        // Navigation Property
        public virtual GasType GasType { get; set; } = null!;
    }
}
