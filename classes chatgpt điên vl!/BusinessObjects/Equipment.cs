using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// DevExpress XAF attributes
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.DC;
using System.ComponentModel;

namespace PhongTro3.Module.BusinessObjects
{
    /// <summary>
    /// Represents a piece of equipment (thiết bị) that can be placed in a room.
    /// </summary>
    // XAF metadata: hiển thị thiết bị trong menu Quản lý trọ
    [DefaultClassOptions]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Thiết bị")]
    [DefaultProperty(nameof(Name))]
    [ImageName("BO_Equipment")]
    public class Equipment
    {
        [Key]
        [Display(Name = "Mã thiết bị")]
        public int EquipmentId { get; set; }

        [ForeignKey(nameof(Landlord))]
        [Display(Name = "Chủ trọ")]
        public int LandlordId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Tên thiết bị")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        [Display(Name = "Ghi chú")]
        public string? Notes { get; set; }

        /// <summary>
        /// Navigation back to the owning landlord.
        /// </summary>
        public virtual Landlord? Landlord { get; set; }

        /// <summary>
        /// Collection of relationships between this equipment and rooms.
        /// </summary>
        public virtual ICollection<RoomEquipment> RoomEquipments { get; set; } = new List<RoomEquipment>();

        // Hiển thị tên thiết bị
        public override string ToString() => Name;
    }
}