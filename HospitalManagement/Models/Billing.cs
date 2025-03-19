using System;
using System.Collections.Generic;

namespace HospitalManagement.Models;

public partial class Billing
{
    public int BillId { get; set; }

    public int? PatientId { get; set; }

    public DateTime BillDate { get; set; }

    public decimal TotalAmount { get; set; }

    public string PaymentStatus { get; set; } = null!;

    public DateOnly DueDate { get; set; }

    public string? Notes { get; set; }

    public virtual Patient? Patient { get; set; }
}
