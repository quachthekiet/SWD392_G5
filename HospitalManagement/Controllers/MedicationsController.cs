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
            //TempData.Remove("SuccessMessage"); // Clear success message on initial load
            return View(new Medication()); // Always return a fresh model
        }

        // POST: Medications/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Medication medication)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Dữ liệu không hợp lệ. Vui lòng nhập lại.";
                return View(medication); // Return with entered data if invalid
            }

            var (success, errorMessage) = await _medicationService.AddMedicationAsync(medication);
            if (success)
            {
                TempData["SuccessMessage"] = "Đã thêm thuốc thành công.";
                return RedirectToAction("Add"); // Redirect to GET Add to clear form
            }

            TempData["ErrorMessage"] = errorMessage;
            return View(medication); // Return with entered data if error
        }

        // GET: Medications/Index (fixed)
        public async Task<IActionResult> Index(string searchTerm)
        {
            var medications = string.IsNullOrWhiteSpace(searchTerm)
                ? await _medicationService.GetAllMedicationsAsync() // Use service, not _context
                : await _medicationService.SearchMedicationsAsync(searchTerm);
            return View(medications);
        }

        // GET: Medications/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var medication = await _medicationService.GetMedicationByIdAsync(id);
            if (medication == null)
            {
                TempData["ErrorMessage"] = "Không tìm thấy thuốc.";
                return RedirectToAction("Index");
            }
            return View(medication);
        }

        // POST: Medications/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Medication medication)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Dữ liệu không hợp lệ. Vui lòng kiểm tra lại.";
                return View(medication);
            }

            var (success, errorMessage) = await _medicationService.UpdateMedicationAsync(medication);
            if (success)
            {
                TempData["SuccessMessage"] = "Cập nhật thông tin thuốc thành công.";
                return RedirectToAction("Index");
            }

            TempData["ErrorMessage"] = errorMessage;
            return View(medication);
        }
    }
}