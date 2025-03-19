using System.ComponentModel;

namespace HospitalManagement.Models;

public partial class Room
{
    public int RoomId { get; set; }
    // [DisplayName("Số phòng")]
    public string RoomNumber { get; set; }

    public string RoomType { get; set; }

    public int RoomPrice { get; set; }

    public string Status { get; set; }

    [DisplayName("Department")]
    public int? DepartmentId { get; set; }

    public virtual ICollection<Admission> Admissions { get; set; } = new List<Admission>();

    public virtual Department? Department { get; set; }
}
