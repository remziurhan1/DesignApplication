using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.ProductManagement.Presentation.Controllers;

namespace MVC.ProductManagement.Presentation.Areas.Design.Controllers
{
    [Area("Design")]
    [Authorize(Roles = "DesignEngineer,Admin")]
    public abstract class DesignBaseController : BaseController
    {
    }
}
