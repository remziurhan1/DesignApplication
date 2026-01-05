using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.AllowableStressDTOs
{
    public class AllowableStressDetailDto
    {
        public Guid Id { get; set; }
        public Guid MaterialFormId { get; set; }
        public string? MaterialFormName { get; set; } // İlişkili formun ismi (UI kolaylığı için)
        public double Temperature { get; set; }
        public double Stress { get; set; }
    }
}
