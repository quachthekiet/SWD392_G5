using System.ComponentModel;

namespace HospitalManagement.Enums
{
    public class RoomEnum
    {
        public enum RoomType
        {
            [Description("Phòng khám bệnh")]
            Consultation,

            [Description("Phòng điều trị nội trú")]
            Treatment,

            [Description("Phòng phẫu thuật")]
            Surgery,

            [Description("Phòng cấp cứu")]
            Emergency,

            [Description("Phòng hồi sức tích cực (ICU)")]
            IntensiveCare,

            [Description("Phòng xét nghiệm")]
            Laboratory,

            [Description("Phòng chẩn đoán hình ảnh (X-quang, CT, MRI)")]
            Radiology
        }
        public enum RoomStatus
        {
            [Description("Trống")]
            Available,  // Phòng trống, có thể sử dụng

            [Description("Đang sử dụng")]
            Occupied,  // Phòng đang có bệnh nhân

            [Description("Đang vệ sinh")]
            Cleaning,  // Phòng đang được dọn dẹp

            [Description("Bảo trì")]
            Maintenance,  // Phòng đang được bảo trì, không thể sử dụng

            [Description("Đã đặt trước")]
            Reserved  // Phòng đã được đặt trước, chưa sử dụng
        }


    }
}
