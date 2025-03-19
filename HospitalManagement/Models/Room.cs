using System;
using System.Collections.Generic;

namespace HospitalManagement.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public string RoomNumber { get; set; } = null!;

    public string RoomType { get; set; } = null!;

    public int? RoomPrice { get; set; }

    public string Status { get; set; } = null!;

    public int? DepartmentId { get; set; }

    public virtual ICollection<Admission> Admissions { get; set; } = new List<Admission>();

    public virtual Department? Department { get; set; }
}
