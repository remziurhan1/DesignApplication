using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs;
using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using MVC.ProductManagement.Application.DTOs.StockCodes.SA;
using MVC.ProductManagement.Application.Services.Export;
using MVC.ProductManagement.Application.Services.StockCodes.SA;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.SA;
using System;
using System.Collections.Generic;
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

        /// <summary>
        /// ✅ Yeni kod üretimi sayfası (GET)
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Generate()
        {
            var vm = new SAStockCodeGenerateVm();
            await FillLookups(vm);
            return View(vm);
        }

        /// <summary>
        /// ✅ Yeni kod üretimi (POST)
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Generate(SAStockCodeGenerateVm vm)
        {
            await FillLookups(vm);

            // Feature'ları yükle (POST'ta validation hatası için)
            if (vm.SProductId != Guid.Empty)
            {
                vm.Features = await _saService.GetFeaturesByProductAsync(vm.SProductId);
            }

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
        /// ✅ AJAX için feature'ları getiren action
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> FeaturesByProduct(string productId)
        {
            if (!Guid.TryParse(productId, out var pid))
                return BadRequest("Geçersiz ürün ID");

            try
            {
                var features = await _saService.GetFeaturesByProductAsync(pid);
                return Json(features);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
        /// <summary>
        /// ✅ Düzenleme sayfası (GET)
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                // 1. Stok kartı detayını getir
                var detail = await _saService.GetStockCardDetailAsync(id, CancellationToken.None);

                // 2. Düzenleme DTO'sunu oluştur
                var updateDto = new SAStockCardUpdateDto
                {
                    StockCardId = id,
                    FeatureSelections = detail.FeatureSelections.ToDictionary(
                        fs => fs.FeatureId,
                        fs => fs.ValueId)
                };

                // 3. Ürüne ait feature'ları getir
                var features = await _saService.GetFeaturesByProductAsync(detail.ProductId);

                // 4. ViewBag'e yükle
                ViewBag.Features = features;
                ViewBag.StockCardId = id;
                ViewBag.CurrentStockCode = detail.StockCode8;
                ViewBag.CurrentProductCode = detail.ProductCode;
                ViewBag.CurrentProductName = detail.ProductName;
                ViewBag.SelectedProductId = detail.ProductId;
                ViewBag.SelectedFeatures = updateDto.FeatureSelections;

                return View(updateDto);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        /// <summary>
        /// ✅ Düzenleme işlemi (POST)
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [FromForm] Dictionary<string, string> featureSelections)
        {
            try
            {
                // Null check
                if (featureSelections == null || !featureSelections.Any())
                {
                    TempData["ErrorMessage"] = "Hiçbir özellik seçilmedi!";
                    return RedirectToAction(nameof(Edit), new { id });
                }

                // Dictionary'i Guid'e çevir
                var selections = new Dictionary<Guid, Guid>();

                foreach (var kvp in featureSelections)
                {
                    // Key: "featureSelections[guid]" formatında geliyor, sadece guid'i al
                    var key = kvp.Key.Replace("featureSelections[", "").Replace("]", "");

                    if (Guid.TryParse(key, out var featureId) && Guid.TryParse(kvp.Value, out var valueId))
                    {
                        selections[featureId] = valueId;
                    }
                }

                if (!selections.Any())
                {
                    TempData["ErrorMessage"] = "Geçerli özellik seçimi yapılmadı!";
                    return RedirectToAction(nameof(Edit), new { id });
                }

                var updateDto = new SAStockCardUpdateDto
                {
                    StockCardId = id,
                    FeatureSelections = selections
                };

                // Güncelle
                await _saService.UpdateStockCardAsync(updateDto, "Admin", CancellationToken.None);

                TempData["SuccessMessage"] = "Stok kodu başarıyla güncellendi!";
                return RedirectToAction(nameof(Detail), new { id });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Güncelleme hatası: {ex.Message}";
                return RedirectToAction(nameof(Edit), new { id });
            }
        }

        /// <summary>
        /// ✅ Silme işlemi (POST)
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

        /// <summary>
        /// ✅ Excel Export (Liste)
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ExportExcel(SAStockCardFilterDto filter)
        {
            try
            {
                filter.PageSize = int.MaxValue; // Tümünü al
                var result = await _saService.GetStockCardsAsync(filter, CancellationToken.None);

                // ✅ SAStockCardListItemDto'dan SAStockCardListDto'ya dönüştür
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

        /// <summary>
        /// ✅ Excel Export (Detay)
        /// </summary>
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

        private async Task FillLookups(SAStockCodeGenerateVm vm)
        {
            var products = await _saService.GetSaProductsAsync();
            vm.Products = products
                .Select(x => new SelectListItem($"{x.Code} - {x.Name}", x.Id.ToString()))
                .ToList();
        }
    }
}