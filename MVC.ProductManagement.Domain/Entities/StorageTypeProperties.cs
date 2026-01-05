using MVC.ProductManagement.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Entities
{
    public class StorageTypeProperties : AuditableEntity
    {
        public double Temperature_C { get; set; }      // T (°C)
        public double Pressure_bar { get; set; }       // p (bar)

        public double SpecificVolume_Liquid_dm3kg { get; set; } // v_l
        public double SpecificVolume_Gas_m3kg { get; set; }     // v_g

        public double Enthalpy_Liquid_kJkg { get; set; }  // h_l
        public double Enthalpy_Gas_kJkg { get; set; }     // h_g

        public double GasConstant_kJkgK { get; set; }     // R

        public double Entropy_Liquid_kJkgK { get; set; }  // s_l
        public double Entropy_Gas_kJkgK { get; set; }     // s_g
                                                          // Foreign Key
        public Guid StorageTypeId { get; set; }

        // Navigation Property
        public virtual StorageType StorageType { get; set; }

    }
}
