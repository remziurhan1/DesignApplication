using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.ProductManagement.Presentation.Controllers;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin,DesignEngineer,DesignManager")]
    public class AdminBaseController : BaseController
    {
       
    }
}
