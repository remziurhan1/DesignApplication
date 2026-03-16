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
            return View(new StockCardGroupCreateDto { CurrencyCode = "EUR" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StockCardGroupCreateDto dto)
        {
            try
            {
                dto.CurrencyCode = "EUR";
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

            var cards = await _groupService.SearchStockCardsAsync(q, 500);
            ViewBag.StockCardsByGroup = BuildGroupedStockCardSelectList(cards);
            ViewBag.SearchTerm = q;
            return View(detail);
        }

        private static Dictionary<string, List<SelectListItem>> BuildGroupedStockCardSelectList(IReadOnlyList<StockCardLookupDto> cards)
        {
            var orderedPrefixes = new[] { "SA", "SB", "SC", "SD", "SE", "SF", "SG" };

            var grouped = cards
                .OrderBy(x => x.StockCode8)
                .GroupBy(x =>
                {
                    var prefix = (x.StockCode8 ?? string.Empty).Trim().ToUpperInvariant();
                    prefix = prefix.Length >= 2 ? prefix[..2] : prefix;
                    return orderedPrefixes.Contains(prefix) ? prefix : "Diger";
                })
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(x => new SelectListItem($"{x.StockCode8} - {x.Description}", x.StockCardId.ToString())).ToList());

            var result = new Dictionary<string, List<SelectListItem>>();
            foreach (var prefix in orderedPrefixes)
            {
                result[prefix] = grouped.TryGetValue(prefix, out var items) ? items : new List<SelectListItem>();
            }

            result["Diger"] = grouped.TryGetValue("Diger", out var otherItems) ? otherItems : new List<SelectListItem>();
            return result;
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
        public async Task<IActionResult> AddCustomItem(Guid groupId, string customDescription, int quantity, string quantityUnit, decimal unitPrice)
        {
            try
            {
                await _groupService.AddCustomItemAsync(groupId, customDescription, quantity, quantityUnit, unitPrice, "Admin");
                TempData["SuccessMessage"] = "Hammadde satırı eklendi.";
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
