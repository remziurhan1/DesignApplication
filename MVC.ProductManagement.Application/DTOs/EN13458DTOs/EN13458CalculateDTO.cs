using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.EN13458DTOs
{
   public class EN13458CalculateDTO
    {
        public string Name { get; set; }
        public double OuterDiameter { get; set; }
        public double ShellLength { get; set; }
        public double Pressure { get; set; }
        public double LiquidDensity { get; set; }
        public double SectorWidth { get; set; }

        // Malzeme seçimleri
        public Guid InnerShellMaterialId { get; set; }
        public Guid InnerShellMaterialFormId { get; set; }

        public Guid InnerHeadMaterialId { get; set; }
        public Guid InnerHeadMaterialFormId { get; set; }

        public Guid OuterShellMaterialId { get; set; }
        public Guid OuterShellMaterialFormId { get; set; }

        public Guid OuterHeadMaterialId { get; set; }
        public Guid OuterHeadMaterialFormId { get; set; }
    }
}
