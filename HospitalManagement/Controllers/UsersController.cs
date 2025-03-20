using HospitalManagement.Models;
using HospitalManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalManagement.Controllers
{
    public class UsersController : Controller
    {
        private readonly HospitalManagerContext _context;
        private static readonly UserService userService = new UserService();

        public UsersController(HospitalManagerContext context)
        {
            _context = context;
        }

        // GET: Users
        public IActionResult Index()
        {
            return View(userService.GetUsers());
        }

        // GET: Users/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var user = userService.GetUserByID(id.Value);
            if (user == null)
                return NotFound();

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("UserId,Username,Password,Role,Name,Phone,Email,DepartmentId")] User user)
        {
            string result = userService.CreateUser(user);
            if (result == "Success")
            {
                TempData["SuccessMessage"] = "User created successfully!";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["ErrorMessage"] = result;
                ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", user.DepartmentId);
                return View(user);
            }
        }

        // GET: Users/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var user = userService.GetUserByID(id.Value);
            if (user == null)
                return NotFound();

            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", user.DepartmentId);
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("UserId,Username,Password,Role,Name,Phone,Email,DepartmentId")] User user)
        {
            if (id != user.UserId)
                return NotFound();

            string result = userService.UpdateUser(user);
            if (result == "Success")
            {
                TempData["SuccessMessage"] = "User updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["ErrorMessage"] = result;
                ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", user.DepartmentId);
                return View(user);
            }
        }

        // GET: Users/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var user = userService.GetUserByID(id.Value);
            if (user == null)
                return NotFound();

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            string result = userService.DeleteUser(id);
            if (result == "Success")
            {
                TempData["SuccessMessage"] = "User deleted successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to delete user!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
