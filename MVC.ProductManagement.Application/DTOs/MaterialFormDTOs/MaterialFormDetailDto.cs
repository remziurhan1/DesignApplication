using MVC.ProductManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.MaterialFormDTOs
{
    public class MaterialFormDetailDto
    {
        public Guid Id { get; set; }
        public Guid MaterialId { get; set; }
        public MaterialFormType FormType { get; set; }
        public string MaterialName { get; set; }
        public double ThicknessMin { get; set; }
        public double ThicknessMax { get; set; }
        public string ProductStandard { get; set; } = string.Empty;
        public double? WeldingFactor { get; set; }
        public string? Notes { get; set; }
        public double UnitPrice { get; set; }

    }
}
