using System;
using System.Collections.Generic;

namespace HospitalManagement.Models;

public partial class PrescriptionItemDetail
{
    public int PrescriptionItemDetailId { get; set; }

    public int? PrescriptionItemId { get; set; }

    public int? MedicationId { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public virtual Medication? Medication { get; set; }

    public virtual PrescriptionItem? PrescriptionItem { get; set; }
}
