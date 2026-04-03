using System.ComponentModel.DataAnnotations;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.EmployeeVMs
{
    public class EmployeeListVm
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string DepartmentRole { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public bool CanAccessSalesArea { get; set; }
        public bool CanAccessDesignArea { get; set; }
    }

    public class EmployeeUpdateVm
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "İsim Soyisim zorunludur")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Departman zorunludur")]
        public string Department { get; set; } = string.Empty;

        [Required(ErrorMessage = "Birim zorunludur")]
        public string DepartmentRole { get; set; } = string.Empty;

        [Required(ErrorMessage = "Title zorunludur")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Numara zorunludur")]
        public string Number { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mail zorunludur")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Lokasyon zorunludur")]
        public string Location { get; set; } = string.Empty;

        public bool CanAccessSalesArea { get; set; }
        public bool CanManageSalesCustomers { get; set; }
        public bool CanCreateSalesRequests { get; set; }
        public bool CanViewSalesPricing { get; set; }
        public bool CanAccessDesignArea { get; set; }
        public bool CanManageDesignCalculations { get; set; }
        public bool CanCreateStockCodes { get; set; }
        public bool CanEditStockCodes { get; set; }
        public bool CanAccessMaterialGroups { get; set; }
        public bool CanManageMaterials { get; set; }
    }

    public class EmployeeCreateVm
    {
        [Required(ErrorMessage = "İsim Soyisim zorunludur")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Departman zorunludur")]
        public string Department { get; set; } = string.Empty;

        [Required(ErrorMessage = "Birim zorunludur")]
        public string DepartmentRole { get; set; } = string.Empty;

        [Required(ErrorMessage = "Title zorunludur")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Numara zorunludur")]
        public string Number { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mail zorunludur")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Lokasyon zorunludur")]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = "Şifre zorunludur")]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;

        public bool CanAccessSalesArea { get; set; }
        public bool CanManageSalesCustomers { get; set; }
        public bool CanCreateSalesRequests { get; set; }
        public bool CanViewSalesPricing { get; set; }
        public bool CanAccessDesignArea { get; set; }
        public bool CanManageDesignCalculations { get; set; }
        public bool CanCreateStockCodes { get; set; }
        public bool CanEditStockCodes { get; set; }
        public bool CanAccessMaterialGroups { get; set; }
        public bool CanManageMaterials { get; set; }
    }
}
