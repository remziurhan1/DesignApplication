using MVC.ProductManagement.Application.DTOs.StockCodes.SC;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MVC.ProductManagement.Application.Services.StockCodes.Common;
using MVC.ProductManagement.Application.Services.StockCodes.SC;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.SC;
using MVC.ProductManagement.Application.Services.Export;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SCStockCodeController : Controller
    {
        private readonly IStockCodeScService _scService;
        private readonly IStockCardDatasheetService _datasheetService;
        private readonly IStockCardPriceService _priceService;
        private readonly IStockCardInventoryService _inventoryService;
        private readonly IExcelExportService _excelService;

        public SCStockCodeController(
            IStockCodeScService scService,
            IStockCardDatasheetService datasheetService,
            IStockCardPriceService priceService,
            IStockCardInventoryService inventoryService,
            IExcelExportService excelService)
        {
            _scService = scService;
            _datasheetService = datasheetService;
            _priceService = priceService;
            _inventoryService = inventoryService;
            _excelService = excelService;
        }

        #region KOD ÜRETME

        [HttpGet]
        public async Task<IActionResult> Generate()
        {
            var vm = new SCStockCodeGenerateVm();
            await FillLookups(vm);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Generate(SCStockCodeGenerateVm vm)
        {
            await FillLookups(vm);

            try
            {
                if (vm.SProductId == Guid.Empty)
                    throw new InvalidOperationException("Ürün seçiniz.");

                if (vm.SelectedFeatureValues == null || !vm.SelectedFeatureValues.Any())
                    throw new InvalidOperationException("Tüm özellikleri seçiniz.");

                var result = await _scService.GenerateScAsync(new ScStockCodeGenerateRequestDto
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
                var formData = await _scService.GetFormDataAsync(productId, CancellationToken.None);
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
        public async Task<IActionResult> Index(SCStockCardFilterDto filter)
        {
            try
            {
                var result = await _scService.GetStockCardsAsync(filter, CancellationToken.None);

                var products = await _scService.GetScProductsAsync();
                ViewBag.Products = products.Select(p => new SelectListItem(
                    $"{p.Code} - {p.Name}",
                    p.Id.ToString(),
                    p.Id == filter.ProductId)).ToList();

                return View(result);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Liste yükleme hatası: {ex.Message}";
                return View(new SCStockCardListResultDto());
            }
        }

        #endregion

        #region DETAY

        [HttpGet]
        public async Task<IActionResult> Detail(Guid id)
        {
            try
            {
                var detail = await _scService.GetStockCardDetailAsync(id, CancellationToken.None);
                if (detail == null)
                {
                    TempData["ErrorMessage"] = "Stok kartı bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }

                var viewModel = new SCStockCardDetailViewModel { StockCard = detail };

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
                var detail = await _scService.GetStockCardDetailAsync(id, CancellationToken.None);
                var formData = await _scService.GetFormDataAsync(detail.ProductId, CancellationToken.None);

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

                var updateDto = new SCStockCardUpdateDto
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
        public async Task<IActionResult> Edit(Guid id, SCStockCardUpdateDto model)
        {
            try
            {
                if (model.FeatureSelections == null || !model.FeatureSelections.Any())
                {
                    TempData["ErrorMessage"] = "Hiçbir özellik seçilmedi!";
                    return RedirectToAction(nameof(Edit), new { id });
                }

                model.StockCardId = id;
                await _scService.UpdateStockCardAsync(model, "Admin", CancellationToken.None);

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
                await _scService.DeleteStockCardAsync(id, "Admin", CancellationToken.None);
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
        public async Task<IActionResult> ExportExcel(SCStockCardFilterDto filter)
        {
            try
            {
                filter.PageSize = int.MaxValue;
                var result = await _scService.GetStockCardsAsync(filter, CancellationToken.None);

                var listDtos = result.Items.Select(item => new SCStockCardListDto
                {
                    Id = item.Id,
                    StockCode8 = item.StockCode8,
                    ProductCode = item.ProductCode,
                    ProductName = item.ProductName,
                    Description = item.Description,
                    CreatedDate = item.CreatedDate,
                    CreatedBy = item.CreatedBy
                }).ToList();

                var bytes = await _excelService.ExportSCStockCardsAsync(listDtos);

                return File(bytes,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    $"SC_StokKodlari_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");
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
                var detail = await _scService.GetStockCardDetailAsync(id, CancellationToken.None);
                var bytes = await _excelService.ExportSCStockCardDetailAsync(detail);

                return File(bytes,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    $"SC_{detail.StockCode8}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Excel export hatası: {ex.Message}";
                return RedirectToAction(nameof(Detail), new { id });
            }
        }

        #endregion

        #region HELPER METHODS

        private async Task FillLookups(SCStockCodeGenerateVm vm)
        {
            var products = await _scService.GetScProductsAsync();
            vm.Products = products
                .Select(x => new SelectListItem($"{x.Code} - {x.Name}", x.Id.ToString()))
                .ToList();
        }

        private async Task LoadDatasheetsAsync(Guid stockCardId, SCStockCardDetailViewModel viewModel)
        {
            try
            {
                viewModel.Datasheets = (List<Application.DTOs.StockCodes.OrtakKlasör.DatasheetDto>)await _datasheetService.GetDatasheetsByStockCardAsync(
                    stockCardId, CancellationToken.None);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Datasheet yükleme hatası: {ex.Message}");
                viewModel.Datasheets = new List<MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör.DatasheetDto>();
            }
        }

        private async Task LoadPricesAsync(Guid stockCardId, SCStockCardDetailViewModel viewModel)
        {
            try
            {
                viewModel.PriceHistory = (List<Application.DTOs.StockCodes.OrtakKlasör.PriceDto>)await _priceService.GetPriceHistoryAsync(
                    stockCardId, CancellationToken.None);
                viewModel.ActivePrice = await _priceService.GetActivePriceAsync(
                    stockCardId, "TRY", CancellationToken.None);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fiyat yükleme hatası: {ex.Message}");
                viewModel.PriceHistory = new List<MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör.PriceDto>();
                viewModel.ActivePrice = null;
            }
        }

        private async Task LoadInventoryAsync(Guid stockCardId, SCStockCardDetailViewModel viewModel)
        {
            try
            {
                viewModel.CurrentInventory = await _inventoryService.GetCurrentInventoryAsync(
                    stockCardId, CancellationToken.None);
                viewModel.InventoryMovements = (List<Application.DTOs.StockCodes.OrtakKlasör.InventoryDto>)await _inventoryService.GetInventoryMovementsAsync(
                    stockCardId, null, null, CancellationToken.None);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Stok yükleme hatası: {ex.Message}");
                viewModel.CurrentInventory = null;
                viewModel.InventoryMovements = new List<MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör.InventoryDto>();
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

                await _datasheetService.UploadDatasheetAsync(
                    new MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör.DatasheetUploadDto
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
        public async Task<IActionResult> CreatePrice(MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör.PriceCreateDto createDto)
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
        public async Task<IActionResult> UpdatePrice(MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör.PriceUpdateDto updateDto, Guid stockCardId)
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
        public async Task<IActionResult> CreateInventoryMovement(MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör.InventoryMovementCreateDto createDto)
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
    }
}