using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.StorageTypeDTOs
{
    public class StorageTypeDTO
    {
        public Guid Id { get; set; } // Benzersiz kimlik
        public string Name { get; set; } // Ürün Türü Adı
        public double Density { get; set; } // Yoğunluk (kg/m³)
        public string Description { get; set; } // Açıklama

    }
}
