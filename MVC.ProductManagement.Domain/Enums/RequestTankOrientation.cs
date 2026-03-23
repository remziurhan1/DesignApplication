using System.ComponentModel.DataAnnotations;

namespace MVC.ProductManagement.Domain.Enums
{
    public enum RequestTankOrientation
    {
        [Display(Name = "Dikey")]
        Vertical = 1,
        [Display(Name = "Yatay")]
        Horizontal = 2
    }
}
