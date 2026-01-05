using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.YieldStrengthDTOs
{
    public class YieldStrengthCreateDto
    {
        public Guid MaterialFormId { get; set; }
        public double Temperature { get; set; }
        public double ThicknessMin { get; set; }
        public double ThicknessMax { get; set; }
        public double Rp02 { get; set; }
        public double Rm { get; set; }
    }
}
