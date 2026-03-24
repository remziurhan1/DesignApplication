using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.ProductManagement.Presentation.Controllers;

namespace MVC.ProductManagement.Presentation.Areas.Sales.Controllers
{
    [Area("Sales")]
    [Authorize]
    public abstract class SalesBaseController : BaseController
    {
    }
}
