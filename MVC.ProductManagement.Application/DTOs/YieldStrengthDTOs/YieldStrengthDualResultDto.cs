using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.YieldStrengthDTOs
{
    public class YieldStrengthDualResultDto
    {
        public double Temperature { get; set; }
        public string MaterialName { get; set; }
        public string MaterialFormName { get; set; }
        public double Rp02_Shell { get; set; }
        public double Rm_Shell { get; set; }

        public double Rp02_Head { get; set; }
        public double Rm_Head { get; set; }
    }
}
