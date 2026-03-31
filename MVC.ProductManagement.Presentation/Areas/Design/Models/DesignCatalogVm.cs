namespace MVC.ProductManagement.Presentation.Areas.Design.Models
{
    public class DesignCatalogVm
    {
        public List<DesignSimpleLookupVm> Materials { get; set; } = new();
        public List<DesignSimpleLookupVm> MaterialForms { get; set; } = new();
        public List<DesignYieldStrengthVm> YieldStrengths { get; set; } = new();
        public List<DesignSimpleLookupVm> StorageTypes { get; set; } = new();
        public List<DesignSimpleLookupVm> Calculations { get; set; } = new();
        public List<DesignStockGroupVm> StockGroups { get; set; } = new();
    }

    public class DesignSimpleLookupVm
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }

    public class DesignYieldStrengthVm
    {
        public string MaterialForm { get; set; } = string.Empty;
        public double Temperature { get; set; }
        public double Rp02 { get; set; }
        public double Rm { get; set; }
    }

    public class DesignStockGroupVm
    {
        public string GroupName { get; set; } = string.Empty;
        public List<string> Codes { get; set; } = new();
    }
}
