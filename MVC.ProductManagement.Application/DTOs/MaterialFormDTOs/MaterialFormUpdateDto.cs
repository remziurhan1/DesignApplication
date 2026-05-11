using MVC.ProductManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.MaterialFormDTOs
{
    public class MaterialFormUpdateDto
    {
        public Guid Id { get; set; }
        public Guid MaterialId { get; set; }
        public MaterialFormType FormType { get; set; }
        public string MaterialClass { get; set; } = string.Empty;
        public MaterialFamily MaterialFamily { get; set; } = MaterialFamily.Unknown;
        public string Norm { get; set; } = string.Empty;
        public string? SymbolicName { get; set; }
        public string? StockCode { get; set; }
        public double ThicknessMin { get; set; }
        public double ThicknessMax { get; set; }
        public string ProductStandard { get; set; } = string.Empty;
        public double? WeldingFactor { get; set; }
        public string? Notes { get; set; }
        public double UnitPrice { get; set; }
        public double? TargetPrice { get; set; }
        public double? ColdStretchYieldStrength { get; set; }
        public double? SectionArea { get; set; }
        public double? MomentOfInertia { get; set; }
        public double? SectionModulus { get; set; }

    }
}
