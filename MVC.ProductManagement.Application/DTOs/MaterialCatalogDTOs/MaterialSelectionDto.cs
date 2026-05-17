namespace MVC.ProductManagement.Application.DTOs.MaterialCatalogDTOs
{
    public class MaterialSelectionDto
    {
        public Guid? MaterialFamilyId { get; set; }
        public string MaterialFamilyName { get; set; } = string.Empty;
        public Guid? MaterialFormId { get; set; }
        public string MaterialFormName { get; set; } = string.Empty;
        public Guid? MaterialStandardId { get; set; }
        public string StandardCode { get; set; } = string.Empty;
        public Guid MaterialId { get; set; }
        public string Grade { get; set; } = string.Empty;
        public string MaterialNumber { get; set; } = string.Empty;
    }
}
