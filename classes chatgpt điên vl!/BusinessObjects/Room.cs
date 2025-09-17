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
    /// Represents a rental room (phòng) owned by a landlord.
    /// </summary>
    // Hiển thị mặc định trong XAF và đặt biểu tượng cũng như nhóm menu
    [DefaultClassOptions]
    [ImageName("BO_Room")]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Phòng")]
    [DefaultProperty(nameof(RoomNumber))]
    public class Room
    {
        [Key]
        [Display(Name = "Mã phòng")]
        public int RoomId { get; set; }

        [ForeignKey(nameof(Landlord))]
        [Display(Name = "Chủ trọ")]
        public int LandlordId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Số phòng")]
        public string RoomNumber { get; set; } = string.Empty;

        [Display(Name = "Tiền cọc")]
        public decimal? Deposit { get; set; }

        /// <summary>
        /// Navigation back to the landlord that owns this room.
        /// </summary>
        public virtual Landlord? Landlord { get; set; }

        /// <summary>
        /// Collection of equipment assigned to this room.
        /// </summary>
        public virtual ICollection<RoomEquipment> RoomEquipments { get; set; } = new List<RoomEquipment>();

        /// <summary>
        /// Collection of contracts for this room.
        /// </summary>
        public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

        /// <summary>
        /// Collection of repairs performed in this room.
        /// </summary>
        public virtual ICollection<Repair> Repairs { get; set; } = new List<Repair>();

        // Phương thức này hiển thị tên phòng trong UI (ListView, Lookup).
        public override string ToString() => RoomNumber;
    }
}