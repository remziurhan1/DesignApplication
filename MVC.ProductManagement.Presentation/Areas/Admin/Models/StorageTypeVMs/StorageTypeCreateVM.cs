namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.StorageTypeVMs
{
    public class StorageTypeCreateVM
    {
        public string Name { get; set; } // Ürün Türü Adı
        public double Density { get; set; } // Yoğunluk (kg/m³)
        public string Description { get; set; } // Açıklama
    }
}
