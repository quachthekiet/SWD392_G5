using HospitalManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HospitalManagement.Services
{
    public class UserService
    {
        public string CreateUser(User user)
        {
            try
            {
                using (var context = new HospitalManagerContext())
                {
                    if (user.Username.IsNullOrEmpty())
                        return "Username cannot be empty!";
                    if (user.Password.IsNullOrEmpty())
                        return "Password cannot be empty!";
                    if (user.Role.IsNullOrEmpty())
                        return "Role cannot be empty!";
                    if (user.Name.IsNullOrEmpty())
                        return "Name cannot be empty!";
                    if (user.Email.IsNullOrEmpty())
                        return "Email cannot be empty!";
                    if (user.Phone.IsNullOrEmpty())
                        return "Phone cannot be empty!";

                    // Kiểm tra DepartmentId có hợp lệ không
                    if (user.DepartmentId.HasValue)
                    {
                        var department = context.Departments.Find(user.DepartmentId.Value);
                        if (department == null)
                            return "Invalid Department!";
                    }
                    user.DepartmentId = 1;
                    context.Add(user);
                    context.SaveChanges();
                    return "Success";
                }
            }
            catch (Exception)
            {
                return "Fail";
            }
        }

        public string UpdateUser(User user)
        {
            try
            {
                using (var context = new HospitalManagerContext())
                {
                    if (user.Username.IsNullOrEmpty())
                        return "Username cannot be empty!";
                    if (user.Password.IsNullOrEmpty())
                        return "Password cannot be empty!";
                    if (user.Role.IsNullOrEmpty())
                        return "Role cannot be empty!";
                    if (user.Name.IsNullOrEmpty())
                        return "Name cannot be empty!";
                    if (user.Email.IsNullOrEmpty())
                        return "Email cannot be empty!";
                    if (user.Phone.IsNullOrEmpty())
                        return "Phone cannot be empty!";

                    // Kiểm tra DepartmentId có hợp lệ không
                    if (user.DepartmentId.HasValue)
                    {
                        var department = context.Departments.Find(user.DepartmentId.Value);
                        if (department == null)
                            return "Invalid Department!";
                    }
                    user.DepartmentId = 1;
                    context.Update(user);
                    context.SaveChanges();
                    return "Success";
                }
            }
            catch (Exception)
            {
                return "Fail";
            }
        }

        public IEnumerable<User> GetUsers()
        {
            try
            {
                using (var context = new HospitalManagerContext())
                {
                    return context.Users.Include(u => u.Department).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public User GetUserByID(int id)
        {
            try
            {
                using (var context = new HospitalManagerContext())
                {
                    return context.Users.Include(u => u.Department)
                        .FirstOrDefault(user => user.UserId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DeleteUser(int id)
        {
            try
            {
                using (var context = new HospitalManagerContext())
                {
                    var user = context.Users.Find(id);
                    if (user == null)
                        return "User not found!";

                    context.Users.Remove(user);
                    context.SaveChanges();
                    return "Success";
                }
            }
            catch (Exception)
            {
                return "Fail";
            }
        }
    }
}
