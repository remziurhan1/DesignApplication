using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.FeatureAdmin
{
    public class FeatureAdminVm
    {
        public string GroupCode { get; set; } = "SA";
        public List<FeatureItemVm> Features { get; set; } = new();
    }

    public class FeatureItemVm
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int SortOrder { get; set; }
        public List<FeatureValueItemVm> Values { get; set; } = new();
    }

    public class FeatureValueItemVm
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int SortOrder { get; set; }
    }

    public class FeatureCreateVm
    {
        public string GroupCode { get; set; } = "SA";
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int SortOrder { get; set; }
    }

    public class FeatureValueCreateVm
    {
        public Guid FeatureId { get; set; }
        public string GroupCode { get; set; } = "SA";
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int SortOrder { get; set; }
    }
}
