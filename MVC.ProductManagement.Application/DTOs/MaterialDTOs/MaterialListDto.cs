using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.MaterialDTOs
{
    public class MaterialListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double? ColdStretchYieldStrength { get; set; }
        public double? ElasticModulus { get; set; }
        public double? YieldFactorK { get; set; }
    }
}
