namespace MVC.ProductManagement.Application.DTOs.MaterialCatalogDTOs
{
    public class MaterialLookupDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
