using MVC.ProductManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.YieldStrengthDTOs
{
    public class YieldStrengthListDto
    {
        public Guid Id { get; set; }
        public Guid MaterialFormId { get; set; }
        public string MaterialName { get; set; }
        public string MaterialFormName { get; set; }
        public double Temperature { get; set; }
        public double ThicknessMin { get; set; }
        public double ThicknessMax { get; set; }
        public double Rp02 { get; set; }   // MPa
        public double Rm { get; set; }     // MPa
    }
}
