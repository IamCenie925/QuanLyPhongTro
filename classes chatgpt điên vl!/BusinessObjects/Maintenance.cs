using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// DevExpress XAF attributes
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.DC;
using System.ComponentModel;

namespace PhongTro3.Module.BusinessObjects
{
    /// <summary>
    /// Represents a maintenance record (bảo trì) for equipment in a room.
    /// </summary>
    // XAF metadata: hiển thị bảo trì thiết bị trong menu Quản lý trọ
    [DefaultClassOptions]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Bảo trì")]
    [DefaultProperty(nameof(Date))]
    [ImageName("BO_Maintenance")]
    public class Maintenance
    {
        [Key]
        [Display(Name = "Mã bảo trì")]
        public int MaintenanceId { get; set; }

        [ForeignKey(nameof(RoomEquipment))]
        [Display(Name = "Thiết bị phòng")]
        public int RoomEquipmentId { get; set; }

        [Display(Name = "Ngày")]
        public DateTime? Date { get; set; }

        [StringLength(500)]
        [Display(Name = "Nội dung")]
        public string? Content { get; set; }

        [Display(Name = "Chi phí")]
        public decimal? Cost { get; set; }

        /// <summary>
        /// Navigation to the related room-equipment association.
        /// </summary>
        public virtual RoomEquipment? RoomEquipment { get; set; }

        // Hiển thị ngày bảo trì hoặc ID nếu không có ngày
        public override string ToString() => Date.HasValue ? Date.Value.ToString("yyyy-MM-dd") : $"BT-{MaintenanceId}";
    }
}