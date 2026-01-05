using MVC.ProductManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.MaterialDTOs
{
    public class MaterialDetailDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string MaterialNumber { get; set; } = string.Empty;
        public MaterialStandard Standard { get; set; }
        public string Group { get; set; } = string.Empty;
        public double Density { get; set; }
        public string? Notes { get; set; }
    }
}
