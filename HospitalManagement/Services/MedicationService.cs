using HospitalManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Services
{
    public class MedicationService
    {
        private readonly HospitalManagerContext _context;

        public MedicationService(HospitalManagerContext context)
        {
            _context = context;
        }
        public async Task<List<Medication>> GetAllMedicationsAsync()
        {
            return await _context.Medications.ToListAsync();
        }

        public async Task<(bool Success, string ErrorMessage)> AddMedicationAsync(Medication medication)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(medication.MedicationName) || medication.Price <= 0)
            {
                return (false, "Nhập sai định dạng,Vui lòng thử lại");
            }

            try
            {
                _context.Medications.Add(medication);
                await _context.SaveChangesAsync();
                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, $"An error occurred while saving the medication: {ex.Message}");
            }
        }
        // New method for UC-35
        public async Task<(bool Success, string ErrorMessage)> UpdateMedicationAsync(Medication medication)
        {
            if (string.IsNullOrWhiteSpace(medication.MedicationName) || medication.Price <= 0)
            {
                return (false, "Dữ liệu không hợp lệ. Vui lòng kiểm tra lại các trường bắt buộc.");
            }

            try
            {
                var existingMedication = await _context.Medications.FindAsync(medication.Id);
                if (existingMedication == null)
                {
                    return (false, "Không tìm thấy thuốc để cập nhật.");
                }

                // Update fields
                existingMedication.MedicationName = medication.MedicationName;
                existingMedication.Dosage = medication.Dosage;
                existingMedication.Manufacturer = medication.Manufacturer;
                existingMedication.Description = medication.Description;
                existingMedication.Price = medication.Price;

                _context.Medications.Update(existingMedication);

                // Sync related PrescriptionItemDetails (only if price changed)
                if (existingMedication.Price != medication.Price)
                {
                    await _context.PrescriptionItemDetails
                        .Where(pid => pid.MedicationId == medication.Id)
                        .ExecuteUpdateAsync(setters => setters.SetProperty(
                            pid => pid.Price,
                            pid => pid.Quantity * medication.Price // Price = Quantity * Medication.Price
                        ));
                }

                await _context.SaveChangesAsync();
                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi khi cập nhật thuốc: {ex.Message}");
            }
        }

        // Helper method to search medications
        public async Task<List<Medication>> SearchMedicationsAsync(string searchTerm)
        {
            return await _context.Medications
                .Where(m => m.MedicationName.Contains(searchTerm) || m.Manufacturer.Contains(searchTerm))
                .ToListAsync();
        }

        // Helper method to get medication by ID
        public async Task<Medication?> GetMedicationByIdAsync(int id)
        {
            return await _context.Medications.FindAsync(id);
        }
    }
}