using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// DevExpress attributes to control how this class appears in XAF UI
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.DC;
using System.ComponentModel;

namespace PhongTro3.Module.BusinessObjects
{
    /// <summary>
    /// Represents the association between a room and a piece of equipment.  This
    /// entity stores when the equipment was first used in the room and other
    /// metadata such as warranty information and supplier details.
    /// </summary>
    // Hiển thị mặc định trong XAF và đặt biểu tượng cũng như nhóm menu
    [DefaultClassOptions]
    [ImageName("BO_RoomEquipment")]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Thiết bị phòng")]
    [DefaultProperty(nameof(RoomEquipmentId))]
    public class RoomEquipment
    {
        [Key]
        [Display(Name = "Mã thiết bị phòng")]
        public int RoomEquipmentId { get; set; }

        [ForeignKey(nameof(Room))]
        [Display(Name = "Phòng")]
        public int RoomId { get; set; }

        [ForeignKey(nameof(Equipment))]
        [Display(Name = "Thiết bị")]
        public int EquipmentId { get; set; }

        [Display(Name = "Ngày sử dụng")]
        public DateTime? DateOfUse { get; set; }

        [Display(Name = "Hạn bảo hành")]
        public DateTime? WarrantyExpiry { get; set; }

        [StringLength(200)]
        [Display(Name = "Thông số")]
        public string? Specification { get; set; }

        [StringLength(200)]
        [Display(Name = "Nguồn cung cấp")]
        public string? Supplier { get; set; }

        /// <summary>
        /// Navigation to the associated room.
        /// </summary>
        public virtual Room? Room { get; set; }

        /// <summary>
        /// Navigation to the associated equipment.
        /// </summary>
        public virtual Equipment? Equipment { get; set; }

        /// <summary>
        /// Collection of maintenance records for this room-equipment combination.
        /// </summary>
        public virtual ICollection<Maintenance> Maintenances { get; set; } = new List<Maintenance>();

        // Hiển thị tên thiết bị nếu có, nếu không thì hiển thị mã
        public override string ToString() => Equipment != null && !string.IsNullOrWhiteSpace(Equipment.Name) ? Equipment.Name : $"TBP-{RoomEquipmentId}";
    }
}