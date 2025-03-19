using HospitalManagement.Models;
using HospitalManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    public class MedicationsController : Controller
    {
        private readonly MedicationService _medicationService;

        public MedicationsController(MedicationService medicationService)
        {
            _medicationService = medicationService;
        }

        // GET: Medications/Add
        public IActionResult Add()
        {
            return View(new Medication());
        }

        // POST: Medications/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Medication medication)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Dữ liệu không hợp lệ. Vui lòng nhập lại.";
                return View(medication);
            }

            var (success, errorMessage) = await _medicationService.AddMedicationAsync(medication);
            if (success)
            {
                TempData["SuccessMessage"] = "Đã thêm thuốc thành công.";
                return RedirectToAction("Index");
            }

            TempData["ErrorMessage"] = errorMessage;
            return View(medication);
        }
    }
}