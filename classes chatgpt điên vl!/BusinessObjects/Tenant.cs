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
    /// Represents a tenant (người thuê) who signs contracts and may take up
    /// temporary residence.  Each tenant belongs to a landlord for record keeping.
    /// </summary>
    // Hiển thị mặc định trong XAF và đặt biểu tượng cũng như nhóm menu
    [DefaultClassOptions]
    [ImageName("BO_Tenant")]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Khách thuê")]
    [DefaultProperty(nameof(Name))]
    public class Tenant
    {
        [Key]
        [Display(Name = "Mã khách")]
        public int TenantId { get; set; }

        [ForeignKey(nameof(Landlord))]
        [Display(Name = "Chủ trọ")]
        public int LandlordId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Họ tên")]
        public string Name { get; set; } = string.Empty;

        [StringLength(50)]
        [Display(Name = "Điện thoại")]
        public string? Phone { get; set; }

        [StringLength(100)]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [StringLength(50)]
        [Display(Name = "Số CCCD")]
        public string? CitizenId { get; set; }

        [Display(Name = "Ngày cấp")]
        public DateTime? IssuedDate { get; set; }

        [StringLength(200)]
        [Display(Name = "Mặt trước CCCD")]
        public string? FrontCitizenCardImage { get; set; }

        [StringLength(200)]
        [Display(Name = "Mặt sau CCCD")]
        public string? BackCitizenCardImage { get; set; }

        public virtual Landlord? Landlord { get; set; }

        public virtual ICollection<TemporaryResidence> TemporaryResidences { get; set; } = new List<TemporaryResidence>();

        // Hiển thị tên khách thuê khi hiển thị đối tượng này trong UI
        public override string ToString() => Name;
    }
}