namespace MVC.ProductManagement.Application.DTOs.StockCodes.Catalog
{
    public class StockMainCodeGroupListDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public bool IsEnabled { get; set; }
    }

    public class StockMainCodeGroupDetailDto : StockMainCodeGroupListDto
    {
    }

    public class StockMainCodeGroupCreateDto
    {
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public bool IsEnabled { get; set; } = true;
    }

    public class StockMainCodeGroupUpdateDto : StockMainCodeGroupCreateDto
    {
        public Guid Id { get; set; }
    }
}
