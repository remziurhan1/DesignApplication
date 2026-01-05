using Microsoft.AspNetCore.Mvc;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
