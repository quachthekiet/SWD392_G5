using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models;

public partial class Medication
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Tên thuốc là bắt buộc.")]
    [StringLength(100, ErrorMessage = "Tên thuốc không được vượt quá 100 ký tự.")]
    public string MedicationName { get; set; } = null!;

    [StringLength(50, ErrorMessage = "Liều lượng không được vượt quá 50 ký tự.")]
    public string? Dosage { get; set; }

    [StringLength(100, ErrorMessage = "Nhà sản xuất không được vượt quá 100 ký tự.")]
    public string? Manufacturer { get; set; }

    public string? Description { get; set; }

    [Required(ErrorMessage = "Giá là bắt buộc.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Giá phải lớn hơn 0.")]
    public decimal Price { get; set; }

    public virtual ICollection<PrescriptionItemDetail> PrescriptionItemDetails { get; set; } = new List<PrescriptionItemDetail>();
}
