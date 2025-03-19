using HospitalManagement.Enums;
using HospitalManagement.Models;
using HospitalManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Controllers
{
    public class RoomsController : Controller
    {
        private readonly HospitalManagerContext _context;

        private static readonly RoomService roomService = new RoomService();
        private static readonly DepartmentService departmentService = new DepartmentService();
        public RoomsController(HospitalManagerContext context)
        {
            _context = context;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {

            return View(roomService.GetRooms());
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.Department)
                .FirstOrDefaultAsync(m => m.RoomId == id);
            if(room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(departmentService.GetDepartments(), "DepartmentId", "DepartmentName");
            // ViewBag.roomTypes = EnumHelper.GetEnumDescriptions<RoomEnum.RoomType>();
            ViewBag.roomTypes = Enum.GetValues(typeof(RoomEnum.RoomType)).Cast<RoomEnum.RoomType>().ToList();
            ViewBag.roomStatus = Enum.GetValues(typeof(RoomEnum.RoomStatus)).Cast<RoomEnum.RoomStatus>().ToList();
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomId,RoomNumber,RoomType,RoomPrice,Status,DepartmentId")] Room room)
        {

            string result = roomService.SaveRoom(room);

            ViewData["DepartmentId"] = new SelectList(departmentService.GetDepartments(), "DepartmentId", "DepartmentName", room.DepartmentId);
            ViewBag.roomTypes = EnumHelper.GetEnumDescriptions<RoomEnum.RoomType>();
            ViewBag.roomStatus = Enum.GetValues(typeof(RoomEnum.RoomStatus)).Cast<RoomEnum.RoomStatus>().ToList();
            if(result == "Success")
            {
                TempData["SuccessMessage"] = result;
                ModelState.Clear();
                return View();
            }
            else
            {
                TempData["ErrorMessage"] = result;
                return View(room);
            }

        }


        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var room = roomService.GetRoomByID(id.Value);
            if(room == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", room.DepartmentId);
            ViewBag.roomTypes = Enum.GetValues(typeof(RoomEnum.RoomType)).Cast<RoomEnum.RoomType>().ToList();
            ViewBag.roomStatus = Enum.GetValues(typeof(RoomEnum.RoomStatus)).Cast<RoomEnum.RoomStatus>().ToList();
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomId,RoomNumber,RoomType,RoomPrice,Status,DepartmentId")] Room room)
        {
            if(id != room.RoomId)
            {
                return NotFound();
            }


            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", room.DepartmentId);
            ViewBag.roomTypes = Enum.GetValues(typeof(RoomEnum.RoomType)).Cast<RoomEnum.RoomType>().ToList();
            ViewBag.roomStatus = Enum.GetValues(typeof(RoomEnum.RoomStatus)).Cast<RoomEnum.RoomStatus>().ToList();
            string result = roomService.UpdateRoom(room);
            if(result == "Success")
            {
                TempData["SuccessMessage"] = result;
                return View(roomService.GetRoomByID(id));
            }
            else
            {
                TempData["ErrorMessage"] = result;
                return View(room);
            }


        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.Department)
                .FirstOrDefaultAsync(m => m.RoomId == id);
            if(room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if(room != null)
            {
                _context.Rooms.Remove(room);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.RoomId == id);
        }
    }
}
