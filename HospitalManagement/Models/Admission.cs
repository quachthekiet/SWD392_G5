using System;
using System.Collections.Generic;

namespace HospitalManagement.Models;

public partial class Admission
{
    public int AdmissionId { get; set; }

    public int? PatientId { get; set; }

    public DateTime AdmissionDate { get; set; }

    public DateTime? DischargeDate { get; set; }

    public int? RoomId { get; set; }

    public string? Reason { get; set; }

    public string Status { get; set; } = null!;

    public string? Notes { get; set; }

    public string? RelativeName { get; set; }

    public string? RelativePhone { get; set; }

    public string? RelativeRelationship { get; set; }

    public virtual Patient? Patient { get; set; }

    public virtual Room? Room { get; set; }
}
