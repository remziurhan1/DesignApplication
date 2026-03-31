using Microsoft.AspNetCore.Mvc;

namespace MVC.ProductManagement.Presentation.Areas.Design.Controllers
{
    public class HomeController : DesignBaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
