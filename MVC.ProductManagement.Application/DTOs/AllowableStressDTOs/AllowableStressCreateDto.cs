using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.AllowableStressDTOs
{
    public class AllowableStressCreateDto
    {
        public Guid MaterialFormId { get; set; }
        public double Temperature { get; set; }
        public double Stress { get; set; }
    }
}
