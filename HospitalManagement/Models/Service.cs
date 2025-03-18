using System;
using System.Collections.Generic;

namespace HospitalManagement.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    public string ServiceName { get; set; } = null!;

    public string? ServiceDescription { get; set; }

    public decimal ServicePrice { get; set; }
}
