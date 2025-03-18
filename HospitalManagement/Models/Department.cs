using System;
using System.Collections.Generic;

namespace HospitalManagement.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
