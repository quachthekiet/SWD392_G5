using HospitalManagement.Models;

namespace HospitalManagement.Services
{
    public class DepartmentService
    {
        public IEnumerable<Department> GetDepartments()
        {
            try
            {
                using(var context = new HospitalManagerContext())
                {
                    return context.Departments.ToList();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
