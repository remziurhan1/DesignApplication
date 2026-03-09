using Microsoft.AspNetCore.Mvc;
using MVC.ProductManagement.Application.Services.StockCodes.Rules;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StockRuleProfileController : Controller
    {
        private readonly IStockRuleProfileService _ruleProfileService;

        public StockRuleProfileController(IStockRuleProfileService ruleProfileService)
        {
            _ruleProfileService = ruleProfileService;
        }

        /// <summary>
        /// S grubu kural profilini JSON olarak döner.
        /// Bu endpoint Admin CRUD ekranını geliştirmek için referans okuma modeli sağlar.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Profile(string groupCode = "SA", CancellationToken cancellationToken = default)
        {
            try
            {
                var profile = await _ruleProfileService.GetProfileAsync(groupCode, cancellationToken);
                return Json(profile);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
