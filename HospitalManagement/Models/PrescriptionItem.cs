using System;
using System.Collections.Generic;

namespace HospitalManagement.Models;

public partial class PrescriptionItem
{
    public int PrescriptionItemId { get; set; }

    public int? RecordId { get; set; }

    public string? Instructions { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<PrescriptionItemDetail> PrescriptionItemDetails { get; set; } = new List<PrescriptionItemDetail>();

    public virtual MedicalRecord? Record { get; set; }
}
