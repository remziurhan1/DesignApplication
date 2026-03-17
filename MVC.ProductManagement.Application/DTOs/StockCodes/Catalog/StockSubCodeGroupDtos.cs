namespace MVC.ProductManagement.Application.DTOs.StockCodes.Catalog
{
    public class StockSubCodeGroupListDto
    {
        public Guid Id { get; set; }
        public Guid StockMainCodeGroupId { get; set; }
        public string MainGroupCode { get; set; } = default!;
        public string MainGroupName { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public bool IsEnabled { get; set; }
    }

    public class StockSubCodeGroupDetailDto : StockSubCodeGroupListDto
    {
    }

    public class StockSubCodeGroupCreateDto
    {
        public Guid StockMainCodeGroupId { get; set; }
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public bool IsEnabled { get; set; } = true;
    }

    public class StockSubCodeGroupUpdateDto : StockSubCodeGroupCreateDto
    {
        public Guid Id { get; set; }
    }
}
