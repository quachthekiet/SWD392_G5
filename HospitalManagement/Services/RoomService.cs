using HospitalManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HospitalManagement.Services
{
    public class RoomService
    {
        public String SaveRoom(Room room)
        {
            try
            {
                using(var context = new HospitalManagerContext())
                {
                    if(room.RoomNumber.IsNullOrEmpty())
                        return "Room number can not be empty!";
                    if(room.RoomType.IsNullOrEmpty())
                        return "Room type can not be empty!";
                    if(room.Status.IsNullOrEmpty())
                        return "Room status can not be empty!";
                    if(room.RoomPrice < 0)
                        return "Room price must be equal or greater than zero!";
                    context.Add(room);
                    context.SaveChanges();
                    return "Success";
                }
            }
            catch(Exception ex)
            {
                return "Fail";
            }
        }
        public String UpdateRoom(Room room)
        {
            try
            {
                using(var context = new HospitalManagerContext())
                {
                    if(room.RoomNumber.IsNullOrEmpty())
                        return "Room number can not be empty!";
                    if(room.RoomType.IsNullOrEmpty())
                        return "Room type can not be empty!";
                    if(room.Status.IsNullOrEmpty())
                        return "Room status can not be empty!";
                    if(room.RoomPrice < 0)
                        return "Room price must be equal or greater than zero!";
                    context.Update(room);
                    context.SaveChanges();
                    return "Success";
                }
            }
            catch(Exception ex)
            {
                return "Fail";
            }
        }
        public IEnumerable<Room> GetRooms()
        {
            try
            {
                using(var context = new HospitalManagerContext())
                {
                    return context.Rooms.Include(r => r.Department).ToList();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Room GetRoomByID(int id)
        {

            try
            {
                using(var context = new HospitalManagerContext())
                {
                    return context.Rooms.FirstOrDefault(room => room.RoomId == id);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
