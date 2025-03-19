using HospitalManagement.Models;

namespace HospitalManagement.Services
{
    public class MedicationService
    {
        private readonly HospitalManagerContext _context;

        public MedicationService(HospitalManagerContext context)
        {
            _context = context;
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
    }
}