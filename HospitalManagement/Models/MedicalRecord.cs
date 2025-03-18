using System;
using System.Collections.Generic;

namespace HospitalManagement.Models;

public partial class MedicalRecord
{
    public int RecordId { get; set; }

    public int? PatientId { get; set; }

    public int? DoctorId { get; set; }

    public DateTime VisitDate { get; set; }

    public string? Diagnosis { get; set; }

    public string? Prescription { get; set; }

    public string? StatusHealthy { get; set; }

    public string? Notes { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual Patient? Patient { get; set; }

    public virtual ICollection<PrescriptionItem> PrescriptionItems { get; set; } = new List<PrescriptionItem>();
}
