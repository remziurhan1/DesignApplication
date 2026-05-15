using System.ComponentModel.DataAnnotations;

namespace MVC.ProductManagement.Presentation.Areas.Design.Models.StockCodes.Permissions
{
    public class StockCodePermissionListVm
    {
        public List<StockCodePermissionItemVm> Employees { get; set; } = new();
    }

    public class StockCodePermissionItemVm
    {
        public Guid EmployeeProfileId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string DepartmentRole { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool CanCreateStockCodes { get; set; }
        public bool CanEditStockCodes { get; set; }
        public bool CanManageStockCodeDefinitions { get; set; }
    }

    public class StockCodePermissionUpdateVm
    {
        [Required]
        public Guid EmployeeProfileId { get; set; }

        public bool CanCreateStockCodes { get; set; }
        public bool CanEditStockCodes { get; set; }
        public bool CanManageStockCodeDefinitions { get; set; }
    }
}
