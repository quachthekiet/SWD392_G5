using System;
using System.Collections.Generic;

namespace HospitalManagement.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int? PatientId { get; set; }

    public int? DoctorId { get; set; }

    public DateTime AppointmentDate { get; set; }

    public string Status { get; set; } = null!;

    public string? Reason { get; set; }

    public string? Notes { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual Patient? Patient { get; set; }
}
