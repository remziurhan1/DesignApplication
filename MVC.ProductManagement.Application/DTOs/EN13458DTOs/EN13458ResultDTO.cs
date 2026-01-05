using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.EN13458DTOs
{
   public class EN13458ResultDTO
    {
        public Guid Id { get; set; }

        // === GİRİŞ PARAMETRELERİ ===
        public string Name { get; set; }
        public double OuterDiameter { get; set; }
        public double ShellLength { get; set; }
        public double Pressure { get; set; }
        public double LiquidDensity { get; set; }
        public double SectorWidth { get; set; }

        // Malzeme ve Form Id'leri
        public Guid InnerShellMaterialId { get; set; }
        public Guid InnerShellMaterialFormId { get; set; }
        public Guid InnerHeadMaterialId { get; set; }
        public Guid InnerHeadMaterialFormId { get; set; }
        public Guid OuterShellMaterialId { get; set; }
        public Guid OuterShellMaterialFormId { get; set; }
        public Guid OuterHeadMaterialId { get; set; }
        public Guid OuterHeadMaterialFormId { get; set; }

        // === MALZEME DAYANIMLARI ===
        public double InnerShellMaterialStrength { get; set; }
        public double InnerHeadMaterialStrength { get; set; }
        public double OuterShellMaterialStrength { get; set; }
        public double OuterHeadMaterialStrength { get; set; }

        // === KALINLIK SONUÇLARI ===
        public double InnerShellThickness { get; set; }
        public double InnerHeadThickness { get; set; }
        public double OuterShellThickness { get; set; }
        public double OuterHeadThickness { get; set; }

        // Yuvarlanmış kalınlıklar
        public double RoundedInnerShellThickness { get; set; }
        public double RoundedInnerHeadThickness { get; set; }
        public double RoundedOuterShellThickness { get; set; }
        public double RoundedOuterHeadThickness { get; set; }

        // === BASINÇ VE STATİK DEĞERLER ===
        public double DesignPressure { get; set; }
        public double TestPressure { get; set; }
        public double StaticPressure { get; set; }

        // === BOY, MALİYET, UZUNLUK ===
        public double TotalWeldLength { get; set; }
        public double TotalFilmCost { get; set; }
        public double InnerTankTotalLength { get; set; }
        public double OuterTankTotalLength { get; set; }
    }
}
