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
    /// Represents a repair (sửa chữa) carried out in a room.
    /// </summary>
    // XAF metadata: hiển thị sửa chữa trong menu Quản lý trọ
    [DefaultClassOptions]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Sửa chữa")]
    [DefaultProperty(nameof(Date))]
    [ImageName("BO_Repair")]
    public class Repair
    {
        [Key]
        [Display(Name = "Mã sửa chữa")]
        public int RepairId { get; set; }

        [ForeignKey(nameof(Room))]
        [Display(Name = "Phòng")]
        public int RoomId { get; set; }

        [Display(Name = "Ngày")]
        public DateTime? Date { get; set; }

        [StringLength(500)]
        [Display(Name = "Nội dung")]
        public string? Content { get; set; }

        [Display(Name = "Chi phí")]
        public decimal? Cost { get; set; }

        /// <summary>
        /// Navigation to the room where the repair took place.
        /// </summary>
        public virtual Room? Room { get; set; }

        // Hiển thị ngày sửa chữa hoặc ID
        public override string ToString() => Date.HasValue ? Date.Value.ToString("yyyy-MM-dd") : $"SC-{RepairId}";
    }
}