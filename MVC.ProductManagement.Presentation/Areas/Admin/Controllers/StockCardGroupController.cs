using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör;
using MVC.ProductManagement.Application.Services.StockCodes.Common;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StockCardGroupController : Controller
    {
        private readonly IStockCardGroupService _groupService;

        public StockCardGroupController(IStockCardGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var groups = await _groupService.GetGroupsAsync();
            return View(groups);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new StockCardGroupCreateDto { CurrencyCode = "TRY" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StockCardGroupCreateDto dto)
        {
            try
            {
                var id = await _groupService.CreateGroupAsync(dto, "Admin");
                TempData["SuccessMessage"] = "Grup oluşturuldu.";
                return RedirectToAction(nameof(Detail), new { id });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View(dto);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Detail(Guid id, string? q = null)
        {
            var detail = await _groupService.GetGroupDetailAsync(id);
            if (detail == null)
                return NotFound();

            var cards = await _groupService.SearchStockCardsAsync(q, 100);
            ViewBag.StockCards = cards.Select(x => new SelectListItem($"{x.StockCode8} - {x.Description}", x.StockCardId.ToString())).ToList();
            ViewBag.SearchTerm = q;
            return View(detail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(Guid groupId, Guid stockCardId, int quantity)
        {
            try
            {
                await _groupService.AddItemAsync(groupId, stockCardId, quantity, "Admin");
                TempData["SuccessMessage"] = "Satır eklendi.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Detail), new { id = groupId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateQty(Guid groupId, Guid itemId, int quantity)
        {
            try
            {
                await _groupService.UpdateItemQuantityAsync(itemId, quantity, "Admin");
                TempData["SuccessMessage"] = "Adet güncellendi.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Detail), new { id = groupId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveItem(Guid groupId, Guid itemId)
        {
            try
            {
                await _groupService.RemoveItemAsync(itemId, "Admin");
                TempData["SuccessMessage"] = "Satır kaldırıldı.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Detail), new { id = groupId });
        }
    }
}
