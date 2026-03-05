using MVC.ProductManagement.Application.DTOs.StockCodes.SA;
using MVC.ProductManagement.Application.Services.StockCodes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MVC.ProductManagement.Application.Services.StockCodes.Common;
using MVC.ProductManagement.Application.Services.StockCodes.SA;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.StockCodes.SA;
using MVC.ProductManagement.Application.Services.Export;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SAStockCodeController : Controller
    {
        private readonly IStockCodeSaAppService _saService;
        private readonly IStockCardDatasheetService _datasheetService;
        private readonly IStockCardPriceService _priceService;
        private readonly IStockCardInventoryService _inventoryService;
        private readonly IExcelExportService _excelService;

        public SAStockCodeController(
            IStockCodeSaAppService saService,
            IStockCardDatasheetService datasheetService,
            IStockCardPriceService priceService,
            IStockCardInventoryService inventoryService,
            IExcelExportService excelService)
        {
            _saService = saService;
            _datasheetService = datasheetService;
            _priceService = priceService;
            _inventoryService = inventoryService;
            _excelService = excelService;
        }

        #region KOD ÜRETME

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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Generate(SAStockCodeGenerateVm vm)
        {
            await FillLookups(vm);

            try
            {
                if (vm.SProductId == Guid.Empty)
                    throw new InvalidOperationException("Ürün seçiniz.");

                // Tüm ürünlerde dinamik özellik olmayabilir (sadece sabit kurallar olabilir)
                vm.SelectedFeatureValues ??= new Dictionary<Guid, Guid>();

                var result = await _saService.GenerateSaAsync(new SaStockCodeGenerateRequestDto
                {
                    SProductId = vm.SProductId,
                    SelectedFeatureValues = vm.SelectedFeatureValues
                });

                vm.StockCode8 = result.StockCode8;
                vm.Description = result.Description;
                vm.AlreadyExists = result.AlreadyExists;
                vm.ErrorMessage = null;

                if (result.AlreadyExists == true)
                {
                    TempData["WarningMessage"] = "Bu kod zaten mevcut! Kayıt oluşturulmadı.";
                }
                else
                {
                    TempData["SuccessMessage"] = $"Stok kodu başarıyla oluşturuldu: {result.StockCode8}";
                }
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

        #endregion

        #region LİSTE

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
                TempData["ErrorMessage"] = $"Liste yükleme hatası: {ex.Message}";
                return View(new SAStockCardListResultDto());
            }
        }

        #endregion

        #region DETAY

        /// <summary>
        /// ✅ Detay sayfası (Tab'lı modüller ile - ViewModel Pattern)
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Detail(Guid id)
        {
            try
            {
                // 1. Genel bilgileri al
                var detail = await _saService.GetStockCardDetailAsync(id, CancellationToken.None);
                if (detail == null)
                {
                    TempData["ErrorMessage"] = "Stok kartı bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }

                // 2. ViewModel oluştur
                var viewModel = new SAStockCardDetailViewModel
                {
                    StockCard = detail
                };

                // 3. Modül verilerini SIRAYLA yükle (paralel değil)
                await LoadDatasheetsAsync(id, viewModel);
                await LoadPricesAsync(id, viewModel);
                await LoadInventoryAsync(id, viewModel);

                // DEBUG
                Console.WriteLine($"=== DETAIL DEBUG ===");
                Console.WriteLine($"StockCardId: {id}");
                Console.WriteLine($"PriceHistory Count: {viewModel.PriceHistory?.Count ?? 0}");
                Console.WriteLine($"ActivePrice: {viewModel.ActivePrice?.UnitPrice ?? 0} {viewModel.ActivePrice?.Currency}");

                return View(viewModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Detail ERROR: {ex.Message}");
                TempData["ErrorMessage"] = $"Detay yükleme hatası: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }


        #endregion

        #region DÜZENLEME

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
                TempData["ErrorMessage"] = $"Düzenleme formu yüklenirken hata: {ex.Message}";
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

        #endregion

        #region SİLME

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

        #endregion

        #region EXCEL EXPORT

        /// <summary>
        /// ✅ Liste Excel Export
        /// </summary>
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

        /// <summary>
        /// ✅ Detay Excel Export
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

        #endregion

        #region HELPER METHODS - Modül Yükleme

        /// <summary>
        /// Dropdown verileri yükle
        /// </summary>
        private async Task FillLookups(SAStockCodeGenerateVm vm)
        {
            var products = await _saService.GetSaProductsAsync();
            vm.Products = products
                .Select(x => new SelectListItem($"{x.Code} - {x.Name}", x.Id.ToString()))
                .ToList();
        }

        /// <summary>
        /// Datasheet verilerini yükle
        /// </summary>
        private async Task LoadDatasheetsAsync(Guid stockCardId, SAStockCardDetailViewModel viewModel)
        {
            try
            {
                viewModel.Datasheets = await _datasheetService.GetDatasheetsByStockCardAsync(
                    stockCardId,
                    CancellationToken.None
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Datasheet yükleme hatası: {ex.Message}");
                viewModel.Datasheets = new List<MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör.DatasheetDto>();
            }
        }

        /// <summary>
        /// Fiyat verilerini yükle
        /// </summary>
        private async Task LoadPricesAsync(Guid stockCardId, SAStockCardDetailViewModel viewModel)
        {
            try
            {
                viewModel.PriceHistory = await _priceService.GetPriceHistoryAsync(
                    stockCardId,
                    CancellationToken.None
                );

                viewModel.ActivePrice = await _priceService.GetActivePriceAsync(
                    stockCardId,
                    "TRY",
                    CancellationToken.None
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fiyat yükleme hatası: {ex.Message}");
                viewModel.PriceHistory = new List<MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör.PriceDto>();
                viewModel.ActivePrice = null;
            }
        }

        /// <summary>
        /// Stok verilerini yükle
        /// </summary>
        private async Task LoadInventoryAsync(Guid stockCardId, SAStockCardDetailViewModel viewModel)
        {
            try
            {
                viewModel.CurrentInventory = await _inventoryService.GetCurrentInventoryAsync(
                    stockCardId,
                    CancellationToken.None
                );

                viewModel.InventoryMovements = await _inventoryService.GetInventoryMovementsAsync(
                    stockCardId,
                    null,
                    null,
                    CancellationToken.None
                );
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

        /// <summary>
        /// ✅ Dosya Yükleme
        /// </summary>
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
                    TempData["ErrorMessage"] = "Geçersiz dosya tipi. İzin verilen: PDF, JPG, PNG, DOC, DOCX, XLS, XLSX";
                    return RedirectToAction(nameof(Detail), new { id = stockCardId });
                }

                byte[] fileContent;
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    fileContent = memoryStream.ToArray();
                }

                var uploadDto = new MVC.ProductManagement.Application.DTOs.StockCodes.OrtakKlasör.DatasheetUploadDto
                {
                    StockCardId = stockCardId,
                    FileName = file.FileName,
                    ContentType = file.ContentType,
                    FileSize = file.Length,
                    FileContent = fileContent,
                    Description = description
                };

                await _datasheetService.UploadDatasheetAsync(uploadDto, "Admin", CancellationToken.None);
                TempData["SuccessMessage"] = "Dosya başarıyla yüklendi!";
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                TempData["ErrorMessage"] = $"Dosya yükleme hatası: {ex.Message}\n\nDetay: {innerMessage}";
            }

            return RedirectToAction(nameof(Detail), new { id = stockCardId });
        }

        /// <summary>
        /// ✅ Dosya İndirme
        /// </summary>
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

        /// <summary>
        /// ✅ Dosya Silme
        /// </summary>
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

        /// <summary>
        /// ✅ Fiyat Ekleme
        /// </summary>
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
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                TempData["ErrorMessage"] = $"Fiyat ekleme hatası: {ex.Message}\n\nDetay: {innerMessage}";
            }

            return RedirectToAction(nameof(Detail), new { id = createDto.StockCardId });
        }

        /// <summary>
        /// ✅ Fiyat Güncelleme
        /// </summary>
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

        /// <summary>
        /// ✅ Fiyat Pasifleştirme
        /// </summary>
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

        #endregion

        #region INVENTORY ACTIONS

        /// <summary>
        /// ✅ Stok Hareketi Ekleme
        /// </summary>
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
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                TempData["ErrorMessage"] = $"Stok hareketi hatası: {ex.Message}\n\nDetay: {innerMessage}";
            }

            return RedirectToAction(nameof(Detail), new { id = createDto.StockCardId });
        }

        /// <summary>
        /// ✅ İlk Stok Girişi
        /// </summary>
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
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                TempData["ErrorMessage"] = $"İlk stok girişi hatası: {ex.Message}\n\nDetay: {innerMessage}";
            }

            return RedirectToAction(nameof(Detail), new { id = stockCardId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePrice(Guid id, Guid stockCardId)
        {
            await _priceService.DeletePriceAsync(id, "Admin", CancellationToken.None);
            Console.WriteLine("StockCardId: " + stockCardId);

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
    }
}