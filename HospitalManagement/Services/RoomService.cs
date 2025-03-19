using HospitalManagement.Models;

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
        public IEnumerable<Room> GetRooms()
        {
            try
            {
                using(var context = new HospitalManagerContext())
                {
                    return context.Rooms.ToList();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
