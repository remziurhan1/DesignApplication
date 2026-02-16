using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using MVC.ProductManagement.Application.DTOs.StockCodes.SA;
using MVC.ProductManagement.Application.Services.Export;
using MVC.ProductManagement.Application.Services.StockCodes.SA;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.SA;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SAStockCodeController : Controller
    {
        private readonly IStockCodeSaService _saService;
        private readonly IExcelExportService _excelService;

        public SAStockCodeController(
            IStockCodeSaService saService,
            IExcelExportService excelService)
        {
            _saService = saService;
            _excelService = excelService;
        }

        // ========== KOD ÜRETME ==========

        /// <summary>
        /// ✅ Kod üretme formu (GET)
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Generate()
        {
            var vm = new SAStockCodeGenerateVm();
            await FillLookups(vm);
            return View(vm);
        }

        /// <summary>
        /// ✅ Kod üretme (POST)
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Generate(SAStockCodeGenerateVm vm)
        {
            await FillLookups(vm);

            try
            {
                if (vm.SProductId == Guid.Empty)
                    throw new InvalidOperationException("Ürün seçiniz.");

                if (vm.SelectedFeatureValues == null || !vm.SelectedFeatureValues.Any())
                    throw new InvalidOperationException("Tüm özellikleri seçiniz.");

                var result = await _saService.GenerateSaAsync(new SaStockCodeGenerateRequestDto
                {
                    SProductId = vm.SProductId,
                    SelectedFeatureValues = vm.SelectedFeatureValues
                });

                vm.StockCode8 = result.StockCode8;
                vm.Description = result.Description;
                vm.AlreadyExists = result.AlreadyExists;
                vm.ErrorMessage = null;
            }
            catch (Exception ex)
            {
                vm.StockCode8 = null;
                vm.Description = null;
                vm.AlreadyExists = null;
                vm.ErrorMessage = ex.Message;
            }

            return View(vm);
        }

        /// <summary>
        /// ✅ AJAX - Rule-based form data (sabit değerler + dropdown'lar)
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetFormData(Guid productId)
        {
            try
            {
                var formData = await _saService.GetFormDataAsync(productId, CancellationToken.None);
                return Json(formData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // ========== LİSTE ==========

        /// <summary>
        /// ✅ Liste sayfası (Index)
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index(SAStockCardFilterDto filter)
        {
            try
            {
                var result = await _saService.GetStockCardsAsync(filter, CancellationToken.None);

                // Ürün listesi (filtre için)
                var products = await _saService.GetSaProductsAsync();
                ViewBag.Products = products.Select(p => new SelectListItem(
                    $"{p.Code} - {p.Name}",
                    p.Id.ToString(),
                    p.Id == filter.ProductId)).ToList();

                return View(result);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View(new SAStockCardListResultDto());
            }
        }

        /// <summary>
        /// ✅ Detay sayfası
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Detail(Guid id)
        {
            try
            {
                var detail = await _saService.GetStockCardDetailAsync(id, CancellationToken.None);
                return View(detail);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // ========== DÜZENLEME ==========

        /// <summary>
        /// ✅ Edit GET - Düzenleme sayfası (Rule-based)
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                // 1. Stok kartı detayını getir
                var detail = await _saService.GetStockCardDetailAsync(id, CancellationToken.None);

                // 2. Rule-based form data getir (sabit + dropdown'lar)
                var formData = await _saService.GetFormDataAsync(detail.ProductId, CancellationToken.None);

                // 3. Mevcut seçimleri al
                var currentSelections = detail.FeatureSelections.ToDictionary(
                    fs => fs.FeatureId,
                    fs => fs.ValueId);

                // 4. ViewBag'e yükle
                ViewBag.FormData = formData;
                ViewBag.StockCardId = id;
                ViewBag.CurrentStockCode = detail.StockCode8;
                ViewBag.CurrentProductCode = detail.ProductCode;
                ViewBag.CurrentProductName = detail.ProductName;
                ViewBag.ProductId = detail.ProductId;
                ViewBag.CurrentSelections = currentSelections;

                var updateDto = new SAStockCardUpdateDto
                {
                    StockCardId = id,
                    FeatureSelections = currentSelections.Where(kvp =>
                        !formData.Features.Any(f => f.FeatureId == kvp.Key && f.IsFixed)) // Sadece dropdown'ları gönder
                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value)
                };

                return View(updateDto);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        /// <summary>
        /// ✅ Edit POST - Güncelleme işlemi
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, SAStockCardUpdateDto model)
        {
            try
            {
                if (model.FeatureSelections == null || !model.FeatureSelections.Any())
                {
                    TempData["ErrorMessage"] = "Hiçbir özellik seçilmedi!";
                    return RedirectToAction(nameof(Edit), new { id });
                }

                // ✅ Model binding ile gelen seçimler zaten Dictionary<Guid, Guid> formatında
                model.StockCardId = id;

                await _saService.UpdateStockCardAsync(model, "Admin", CancellationToken.None);

                TempData["SuccessMessage"] = "Stok kodu başarıyla güncellendi!";
                return RedirectToAction(nameof(Detail), new { id });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Güncelleme hatası: {ex.Message}";
                return RedirectToAction(nameof(Edit), new { id });
            }
        }
        // ========== SİLME ==========

        /// <summary>
        /// ✅ Silme (POST)
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _saService.DeleteStockCardAsync(id, "Admin", CancellationToken.None);
                TempData["SuccessMessage"] = "Stok kodu başarıyla silindi!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Silme hatası: {ex.Message}";
                return RedirectToAction(nameof(Detail), new { id });
            }
        }

        // ========== EXCEL EXPORT ==========

        [HttpGet]
        public async Task<IActionResult> ExportExcel(SAStockCardFilterDto filter)
        {
            try
            {
                filter.PageSize = int.MaxValue;
                var result = await _saService.GetStockCardsAsync(filter, CancellationToken.None);

                var listDtos = result.Items.Select(item => new SAStockCardListDto
                {
                    Id = item.Id,
                    StockCode8 = item.StockCode8,
                    ProductCode = item.ProductCode,
                    ProductName = item.ProductName,
                    Description = item.Description,
                    CreatedDate = item.CreatedDate,
                    CreatedBy = item.CreatedBy
                }).ToList();

                var bytes = await _excelService.ExportSAStockCardsAsync(listDtos);

                return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    $"SA_StokKodlari_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Excel export hatası: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> ExportDetailExcel(Guid id)
        {
            try
            {
                var detail = await _saService.GetStockCardDetailAsync(id, CancellationToken.None);
                var bytes = await _excelService.ExportSAStockCardDetailAsync(detail);

                return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    $"SA_{detail.StockCode8}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Excel export hatası: {ex.Message}";
                return RedirectToAction(nameof(Detail), new { id });
            }
        }

        // ========== HELPER ==========

        private async Task FillLookups(SAStockCodeGenerateVm vm)
        {
            var products = await _saService.GetSaProductsAsync();
            vm.Products = products
                .Select(x => new SelectListItem($"{x.Code} - {x.Name}", x.Id.ToString()))
                .ToList();
        }
    }
}