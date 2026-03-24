using Microsoft.AspNetCore.Mvc;

namespace MVC.ProductManagement.Presentation.Areas.Sales.Controllers
{
    public class HomeController : SalesBaseController
    {
        public async Task<IActionResult> Index()
        {
            if (!await HasSalesPermissionAsync(x => x.CanAccessSalesArea))
            {
                return Forbid();
            }

            return View();
        }
    }
}
