using HospitalManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly HospitalManagerContext _context;
        public RegistrationController(HospitalManagerContext context)
        {
            _context = context;
        }
        // GET: RegistrationController
        public ActionResult Index()
        {
            var listRegistration = _context.Appointments.Include(r => r.Doctor).Include(p => p.Patient);
            return View(listRegistration);
        }

        // GET: RegistrationController/Details/5
        public ActionResult Details(int id)
        {
            var medicalrecord = _context.MedicalRecords.Include(r => r.Patient).FirstOrDefault(p => p.PatientId == id);
            return View(medicalrecord);
        }

        // GET: RegistrationController/Create
        [HttpGet]
        public IActionResult Create(int id)
        {
            var medicalrecord = _context.MedicalRecords.Include(r => r.Patient).FirstOrDefault(p => p.PatientId == id);
            ViewBag.PatientId = medicalrecord.PatientId;
            ViewBag.PatientName = medicalrecord.Patient.FirstName + " " + medicalrecord.Patient.LastName;
            return View();
        }

        // POST: RegistrationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Createa(int patientId, string diagnosis, string prescription, string status, string note, string instructions)
        {
            var medicalrecord = _context.MedicalRecords.Include(r => r.Patient).FirstOrDefault(p => p.PatientId == patientId);
            medicalrecord.Diagnosis = diagnosis;
            medicalrecord.Prescription = prescription;
            medicalrecord.StatusHealthy = status;
            medicalrecord.Notes = note;

            var precription = _context.PrescriptionItems.Include(q => q.Record).FirstOrDefault(p => p.RecordId == medicalrecord.RecordId);
            if(precription != null)
            {
                precription.Instructions = instructions;
                precription.Status = "Bắt đầu điều trị";
                _context.Update(precription);
            }
            else
            {
                PrescriptionItem a = new PrescriptionItem
                {
                    RecordId = medicalrecord.RecordId,
                    Instructions = instructions,
                    Status = "Bắt đầu điều trị"
                };
                _context.Add(a);
            }
            if (ModelState.IsValid)
            {
                _context.Update(medicalrecord);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Save Success!";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: RegistrationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegistrationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistrationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistrationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
