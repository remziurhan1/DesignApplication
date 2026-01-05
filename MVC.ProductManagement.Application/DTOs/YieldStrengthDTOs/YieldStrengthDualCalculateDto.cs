using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.YieldStrengthDTOs
{
    public class YieldStrengthDualCalculateDto
    {
        public Guid MaterialFormId { get; set; }
        public double Temperature { get; set; }
        public string MaterialName { get; set; }
        public string MaterialFormName { get; set; }

        public double ThicknessShell { get; set; }
        public double ThicknessHead { get; set; }
    }
}
