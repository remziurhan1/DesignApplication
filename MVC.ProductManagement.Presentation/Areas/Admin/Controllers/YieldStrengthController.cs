using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ProductManagement.Application.DTOs.YieldStrengthDTOs;
using MVC.ProductManagement.Application.Services.IYieldStrengthServices;
using MVC.ProductManagement.Application.Services.MaterialFormServices;
using MVC.ProductManagement.Application.Services.MaterialServices;
using MVC.ProductManagement.Presentation.Areas.Admin.Models.YieldStrengthListVMs;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Controllers
{
    public class YieldStrengthController : AdminBaseController
    {
        private readonly IYieldStrengthService _yieldStrengthService;
        private readonly IMaterialFormService _materialFormService;
        private readonly IMaterialService _materialService;

        public YieldStrengthController(IYieldStrengthService yieldStrengthService, IMaterialFormService materialFormService, IMaterialService materialService)
        {
            _yieldStrengthService = yieldStrengthService;
            _materialFormService = materialFormService;
            _materialService = materialService;
        }

        public async Task<IActionResult> Index(Guid? materialId, Guid? materialFormId)
        {
            // 1. Malzeme listesi (ilk dropdown)
            var materials = await _materialService.GetAllAsync();
            ViewBag.Materials = new SelectList(materials, "Id", "Name", materialId);

            // 2. Eğer bir material seçildiyse ona bağlı formları doldur
            if (materialId.HasValue)
            {
                var forms = await _materialFormService.GetByMaterialIdAsync(materialId.Value);
                ViewBag.Forms = new SelectList(forms, "Id", "FormType", materialFormId);
            }
            else
            {
                ViewBag.Forms = new SelectList(Enumerable.Empty<SelectListItem>());
            }

            // 3. YieldStrength listesi
            var dtos = new List<YieldStrengthListDto>();

            if (materialFormId.HasValue)
            {
                dtos = await _yieldStrengthService.GetByMaterialFormIdAsync(materialFormId.Value);
            }

            var vms = new List<YieldStrengthListVM>();
            foreach (var dto in dtos)
            {
                vms.Add(new YieldStrengthListVM
                {
                    Id = dto.Id,
                    MaterialFormId = dto.MaterialFormId,
                    Temperature = dto.Temperature,
                    ThicknessMin = dto.ThicknessMin,
                    ThicknessMax = dto.ThicknessMax,
                    Rp02 = dto.Rp02,
                    Rm = dto.Rm,
                    MaterialName = dto.MaterialName,
                    MaterialFormName = dto.MaterialFormName
                });
            }

            ViewBag.MaterialId = materialId;
            ViewBag.FormId = materialFormId;

            return View(vms);
        }


        [HttpGet]
        public async Task<IActionResult> CalculateDual(Guid materialFormId)
        {

            // Tüm form listesini servisten çekelim
            var forms = await _materialFormService.GetAllWithMaterialAsync();

            var materialForms = new List<SelectListItem>();
            foreach (var form in forms)
            {
                materialForms.Add(new SelectListItem
                {
                    Value = form.Id.ToString(),
                    Text = $"{form.Material.Name} - {form.FormType} [{form.ThicknessMin}-{form.ThicknessMax} mm]"
                });
            }

            ViewBag.MaterialForms = materialForms;
            // seçili form bilgisini bul
            var selectedForm = forms.FirstOrDefault(f => f.Id == materialFormId);

            ViewBag.MaterialName = selectedForm?.Material?.Name;
            ViewBag.FormInfo = $"{selectedForm?.FormType} [{selectedForm?.ThicknessMin}-{selectedForm?.ThicknessMax} mm]";
            var vm = new YieldStrengthDualCalculateVM
            {
                MaterialFormId = materialFormId
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> CalculateDual(YieldStrengthDualCalculateVM vm)
        {
            // Gövde için interpolasyon
            var shell = await _yieldStrengthService
                .GetByConditionsAsync(vm.MaterialFormId, vm.Temperature, vm.ThicknessShell);

            // Bombe için interpolasyon
            var head = await _yieldStrengthService
                .GetByConditionsAsync(vm.MaterialFormId, vm.Temperature, vm.ThicknessHead);

            if (shell == null && head == null)
            {
                ViewBag.Error = "Interpolasyon yapılamadı. Veri bulunamadı.";
                return View(vm);
            }

            // 📌 Form bilgisini çek
            var form = await _materialFormService.GetByIdWithMaterialAsync(vm.MaterialFormId);
            var material = await _materialService.GetByIdAsync(form.MaterialId);


            var resultVm = new YieldStrengthDualResultVM
            {
                MaterialName = material.Name,
                MaterialFormName = form.FormType.ToString(),

                Temperature = vm.Temperature,
                Rp02_Shell = shell.Rp02,
                Rm_Shell = shell.Rm,
                Rp02_Head = head.Rp02,
                Rm_Head = head.Rm
            };

            return View("CalculateDualResult", resultVm);

        }
    }
}
