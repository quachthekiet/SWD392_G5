using System;
using System.Collections.Generic;

namespace HospitalManagement.Models;

public partial class Medication
{
    public int Id { get; set; }

    public string MedicationName { get; set; } = null!;

    public string? Dosage { get; set; }

    public string? Manufacturer { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<PrescriptionItemDetail> PrescriptionItemDetails { get; set; } = new List<PrescriptionItemDetail>();
}
