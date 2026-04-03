using Microsoft.AspNetCore.Mvc;

namespace MVC.ProductManagement.Presentation.Areas.Design.Controllers
{
    public class HomeController : DesignBaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (!await HasDesignPermissionAsync(x => x.CanAccessDesignArea))
            {
                return Forbid();
            }

            return View();
        }
    }
}
