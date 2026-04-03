using MVC.ProductManagement.Domain.Core.BaseEntities;

namespace MVC.ProductManagement.Domain.Entities
{
    public class EmployeeProfile : AuditableEntity
    {
        public string UserId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string DepartmentRole { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;

        // Area access flags (on/off)
        public bool CanAccessSalesArea { get; set; }
        public bool CanManageSalesCustomers { get; set; }
        public bool CanCreateSalesRequests { get; set; }
        public bool CanViewSalesPricing { get; set; }

        // Design area access flags (on/off)
        public bool CanAccessDesignArea { get; set; }
        public bool CanManageDesignCalculations { get; set; }
        public bool CanCreateStockCodes { get; set; }
        public bool CanEditStockCodes { get; set; }
        public bool CanAccessMaterialGroups { get; set; }
        public bool CanManageMaterials { get; set; }
    }
}
