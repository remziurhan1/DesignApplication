using MVC.ProductManagement.Application.DTOs.StockCodes.SF;
using MVC.ProductManagement.Application.Services.StockCodes.Common;
using MVC.ProductManagement.Application.Services.StockCodes.SF;
using MVC.ProductManagement.Application.Services.Export;
using MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.SF;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SFStockCodeController : Controller
    {
        private readonly IStockCodeSfService _sfService;
        private readonly IStockCardDatasheetService _datasheetService;
        private readonly IStockCardPriceService _priceService;
        private readonly IStockCardInventoryService _inventoryService;
        private readonly IExcelExportService _excelService;

        public SFStockCodeController(
            IStockCodeSfService sfService,
            IStockCardDatasheetService datasheetService,
            IStockCardPriceService priceService,
            IStockCardInventoryService inventoryService,
            IExcelExportService excelService)
        {
            _sfService = sfService;
            _datasheetService = datasheetService;
            _priceService = priceService;
            _inventoryService = inventoryService;
            _excelService = excelService;
        }

        #region KOD ÜRETME
        [HttpGet]
        public async Task<IActionResult> Generate()
        {
            var vm = new SFStockCodeGenerateVm();
            await FillLookups(vm);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Generate(SFStockCodeGenerateVm vm)
        {
            await FillLookups(vm);

            try
            {
                if (vm.SProductId == Guid.Empty)
                    throw new InvalidOperationException("Ürün seçiniz.");

                // Tüm ürünlerde dinamik özellik olmayabilir (sadece sabit kurallar olabilir)
                vm.SelectedFeatureValues ??= new Dictionary<Guid, Guid>();

                var result = await _sfService.GenerateSfAsync(new SfStockCodeGenerateRequestDto
                {
                    SProductId = vm.SProductId,
                    SelectedFeatureValues = vm.SelectedFeatureValues
                });

                vm.StockCode8 = result.StockCode8;
                vm.Description = result.Description;
                vm.AlreadyExists = result.AlreadyExists;
                vm.ErrorMessage = null;

                if (result.AlreadyExists == true)
                    TempData["WarningMessage"] = "Bu kod zaten mevcut! Kayıt oluşturulmadı.";
                else
                    TempData["SuccessMessage"] = $"Stok kodu başarıyla oluşturuldu: {result.StockCode8}";
            }
            catch (Exception ex)
            {
                vm.StockCode8 = null;
                vm.Description = null;
                vm.AlreadyExists = null;
                vm.ErrorMessage = ex.Message;
                TempData["ErrorMessage"] = ex.Message;
            }

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> GetFormData(Guid productId)
        {
            try
            {
                var formData = await _sfService.GetFormDataAsync(productId, CancellationToken.None);
                return Json(formData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        #endregion

        #region LİSTE

        [HttpGet]
        public async Task<IActionResult> Index(SFStockCardFilterDto filter)
        {
            try
            {
                var result = await _sfService.GetStockCardsAsync(filter, CancellationToken.None);
                var products = await _sfService.GetSfProductsAsync();

                ViewBag.Products = products
                    .Select(p => new SelectListItem(
                        $"{p.Code} - {p.Name}",
                        p.Id.ToString(),
                        p.Id == filter.ProductId))
                    .ToList();

                return View(result);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Liste yükleme hatası: {ex.Message}";
                return View(new SFStockCardListResultDto());
            }
        }

        #endregion

        #region DETAY

        [HttpGet]
        public async Task<IActionResult> Detail(Guid id)
        {
            try
            {
                var detail = await _sfService.GetStockCardDetailAsync(id, CancellationToken.None);

                var viewModel = new SFStockCardDetailViewModel { StockCard = detail };

                await LoadDatasheetsAsync(id, viewModel);
                await LoadPricesAsync(id, viewModel);
                await LoadInventoryAsync(id, viewModel);

                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Detay yükleme hatası: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        #endregion

        #region DÜZENLEME

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var detail = await _sfService.GetStockCardDetailAsync(id, CancellationToken.None);
                var formData = await _sfService.GetFormDataAsync(detail.ProductId, CancellationToken.None);

                var currentSelections = detail.FeatureSelections.ToDictionary(
                    fs => fs.FeatureId,
                    fs => fs.ValueId);

                ViewBag.FormData = formData;
                ViewBag.StockCardId = id;
                ViewBag.CurrentStockCode = detail.StockCode8;
                ViewBag.CurrentProductCode = detail.ProductCode;
                ViewBag.CurrentProductName = detail.ProductName;
                ViewBag.ProductId = detail.ProductId;
                ViewBag.CurrentSelections = currentSelections;

                var updateDto = new SFStockCardUpdateDto
                {
                    StockCardId = id,
                    FeatureSelections = currentSelections
                        .Where(kvp => !formData.Features.Any(f => f.FeatureId == kvp.Key && f.IsFixed))
                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value)
                };

                return View(updateDto);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Düzenleme formu yüklenirken hata: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, SFStockCardUpdateDto model)
        {
            try
            {
                if (model.FeatureSelections == null || !model.FeatureSelections.Any())
                {
                    TempData["ErrorMessage"] = "Hiçbir özellik seçilmedi!";
                    return RedirectToAction(nameof(Edit), new { id });
                }

                model.StockCardId = id;
                await _sfService.UpdateStockCardAsync(model, "Admin", CancellationToken.None);

                TempData["SuccessMessage"] = "Stok kodu başarıyla güncellendi!";
                return RedirectToAction(nameof(Detail), new { id });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Güncelleme hatası: {ex.Message}";
                return RedirectToAction(nameof(Edit), new { id });
            }
        }

        #endregion

        #region SİLME

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _sfService.DeleteStockCardAsync(id, "Admin", CancellationToken.None);
                TempData["SuccessMessage"] = "Stok kodu başarıyla silindi!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Silme hatası: {ex.Message}";
                return RedirectToAction(nameof(Detail), new { id });
            }
        }

        #endregion

        #region EXCEL EXPORT

        [HttpGet]
        public async Task<IActionResult> ExportExcel(SFStockCardFilterDto filter)
        {
            try
            {
                filter.PageSize = int.MaxValue;
                var result = await _sfService.GetStockCardsAsync(filter, CancellationToken.None);

                var listDtos = result.Items.Select(item => new SFStockCardListDto
                {
                    Id = item.Id,
                    StockCode8 = item.StockCode8,
                    ProductCode = item.ProductCode,
                    ProductName = item.ProductName,
                    Description = item.Description,
                    CreatedDate = item.CreatedDate,
                    CreatedBy = item.CreatedBy
                }).ToList();

                var bytes = await _excelService.ExportSFStockCardsAsync(listDtos);

                return File(bytes,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    $"SF_StokKodlari_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");
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
                var detail = await _sfService.GetStockCardDetailAsync(id, CancellationToken.None);
                var bytes = await _excelService.ExportSFStockCardDetailAsync(detail);

                return File(bytes,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    $"SF_{detail.StockCode8}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Excel export hatası: {ex.Message}";
                return RedirectToAction(nameof(Detail), new { id });
            }
        }

        #endregion

        #region DATASHEET ACTIONS

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadDatasheet(Guid stockCardId, IFormFile file, string description)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    TempData["ErrorMessage"] = "Lütfen bir dosya seçin.";
                    return RedirectToAction(nameof(Detail), new { id = stockCardId });
                }

                if (file.Length > 10 * 1024 * 1024)
                {
                    TempData["ErrorMessage"] = "Dosya boyutu 10 MB'dan büyük olamaz.";
                    return RedirectToAction(nameof(Detail), new { id = stockCardId });
                }

                var allowedExtensions = new[] { ".pdf", ".jpg", ".jpeg", ".png", ".doc", ".docx", ".xls", ".xlsx" };
                var extension = Path.GetExtension(file.FileName).ToLower();
                if (!allowedExtensions.Contains(extension))
                {
                    TempData["ErrorMessage"] = "Geçersiz dosya tipi.";
                    return RedirectToAction(nameof(Detail), new { id = stockCardId });
                }

                byte[] fileContent;
                using (var ms = new MemoryStream())
                {
                    await file.CopyToAsync(ms);
                    fileContent = ms.ToArray();
                }

                await _datasheetService.UploadDatasheetAsync(new DatasheetUploadDto
                {
                    StockCardId = stockCardId,
                    FileName = file.FileName,
                    ContentType = file.ContentType,
                    FileSize = file.Length,
                    FileContent = fileContent,
                    Description = description
                }, "Admin", CancellationToken.None);

                TempData["SuccessMessage"] = "Dosya başarıyla yüklendi!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Dosya yükleme hatası: {ex.Message}";
            }

            return RedirectToAction(nameof(Detail), new { id = stockCardId });
        }

        [HttpGet]
        public async Task<IActionResult> DownloadDatasheet(Guid id)
        {
            try
            {
                var (content, fileName, contentType) = await _datasheetService.DownloadDatasheetAsync(id, CancellationToken.None);
                return File(content, contentType, fileName);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Dosya indirme hatası: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDatasheet(Guid id, Guid stockCardId)
        {
            try
            {
                await _datasheetService.DeleteDatasheetAsync(id, "Admin", CancellationToken.None);
                TempData["SuccessMessage"] = "Dosya başarıyla silindi!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Dosya silme hatası: {ex.Message}";
            }

            return RedirectToAction(nameof(Detail), new { id = stockCardId });
        }

        #endregion

        #region PRICE ACTIONS

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePrice(PriceCreateDto createDto)
        {
            try
            {
                await _priceService.CreatePriceAsync(createDto, "Admin", CancellationToken.None);
                TempData["SuccessMessage"] = "Fiyat başarıyla eklendi!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Fiyat ekleme hatası: {ex.Message}";
            }
            return RedirectToAction(nameof(Detail), new { id = createDto.StockCardId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePrice(PriceUpdateDto updateDto, Guid stockCardId)
        {
            try
            {
                await _priceService.UpdatePriceAsync(updateDto, "Admin", CancellationToken.None);
                TempData["SuccessMessage"] = "Fiyat başarıyla güncellendi!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Fiyat güncelleme hatası: {ex.Message}";
            }
            return RedirectToAction(nameof(Detail), new { id = stockCardId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeactivatePrice(Guid id, Guid stockCardId)
        {
            try
            {
                await _priceService.DeactivatePriceAsync(id, "Admin", CancellationToken.None);
                TempData["SuccessMessage"] = "Fiyat pasifleştirildi!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Fiyat pasifleştirme hatası: {ex.Message}";
            }
            return RedirectToAction(nameof(Detail), new { id = stockCardId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePrice(Guid id, Guid stockCardId)
        {
            await _priceService.DeletePriceAsync(id, "Admin", CancellationToken.None);
            return RedirectToAction(nameof(Detail), new { id = stockCardId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReactivatePrice(Guid id, Guid stockCardId)
        {
            await _priceService.ReactivatePriceAsync(id, "Admin", CancellationToken.None);
            return RedirectToAction(nameof(Detail), new { id = stockCardId });
        }

        #endregion

        #region INVENTORY ACTIONS

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateInventoryMovement(InventoryMovementCreateDto createDto)
        {
            try
            {
                await _inventoryService.CreateMovementAsync(createDto, "Admin", CancellationToken.None);
                TempData["SuccessMessage"] = "Stok hareketi başarıyla kaydedildi!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Stok hareketi hatası: {ex.Message}";
            }
            return RedirectToAction(nameof(Detail), new { id = createDto.StockCardId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InitialStock(Guid stockCardId, int quantity, string location)
        {
            try
            {
                await _inventoryService.InitialStockAsync(stockCardId, quantity, location, "Admin", CancellationToken.None);
                TempData["SuccessMessage"] = "İlk stok girişi başarıyla yapıldı!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"İlk stok girişi hatası: {ex.Message}";
            }
            return RedirectToAction(nameof(Detail), new { id = stockCardId });
        }

        #endregion

        #region HELPER METHODS

        private async Task FillLookups(SFStockCodeGenerateVm vm)
        {
            var products = await _sfService.GetSfProductsAsync();

            vm.Products = products
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = $"{p.Code} - {p.Name}"
                })
                .ToList();
        }

        private async Task LoadDatasheetsAsync(Guid stockCardId, SFStockCardDetailViewModel vm)
        {
            try { vm.Datasheets = (List<DatasheetDto>)await _datasheetService.GetDatasheetsByStockCardAsync(stockCardId, CancellationToken.None); }
            catch { vm.Datasheets = new List<DatasheetDto>(); }
        }

        private async Task LoadPricesAsync(Guid stockCardId, SFStockCardDetailViewModel vm)
        {
            try
            {
                vm.PriceHistory = (List<PriceDto>)await _priceService.GetPriceHistoryAsync(stockCardId, CancellationToken.None);
                vm.ActivePrice = await _priceService.GetActivePriceAsync(stockCardId, "TRY", CancellationToken.None);
            }
            catch
            {
                vm.PriceHistory = new List<PriceDto>();
                vm.ActivePrice = null;
            }
        }

        private async Task LoadInventoryAsync(Guid stockCardId, SFStockCardDetailViewModel vm)
        {
            try
            {
                vm.CurrentInventory = await _inventoryService.GetCurrentInventoryAsync(stockCardId, CancellationToken.None);
                vm.InventoryMovements = (List<InventoryDto>)await _inventoryService.GetInventoryMovementsAsync(stockCardId, null, null, CancellationToken.None);
            }
            catch
            {
                vm.CurrentInventory = null;
                vm.InventoryMovements = new List<InventoryDto>();
            }
        }

        #endregion
    }
}