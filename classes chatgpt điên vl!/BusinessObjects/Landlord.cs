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
    /// Represents the landlord (chủ trọ) of the rental system.  A landlord owns rooms
    /// and creates contracts with tenants.  Each property is given an English name
    /// while the <see cref="DisplayAttribute"/> provides a Vietnamese label
    /// for UI elements such as forms or tables.
    /// </summary>
    // Hiển thị mặc định trong XAF và đặt biểu tượng cũng như nhóm menu
    [DefaultClassOptions]
    [ImageName("BO_Landlord")]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Chủ trọ")]
    [DefaultProperty(nameof(FullName))]
    public class Landlord
    {
        /// <summary>
        /// Primary key (Mã chủ trọ).
        /// </summary>
        [Key]
        [Display(Name = "Mã chủ trọ")]
        public int LandlordId { get; set; }

        /// <summary>
        /// Landlord's full name (Họ tên).
        /// </summary>
        [Required]
        [StringLength(200)]
        [Display(Name = "Họ tên")]
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Phone number (Điện thoại).
        /// </summary>
        [StringLength(50)]
        [Display(Name = "Điện thoại")]
        public string? Phone { get; set; }

        /// <summary>
        /// Email address (Email).
        /// </summary>
        [StringLength(100)]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        /// <summary>
        /// Citizen identification number (Số CCCD).
        /// </summary>
        [StringLength(50)]
        [Display(Name = "Số CCCD")]
        public string? CitizenId { get; set; }

        /// <summary>
        /// Date of issue for the citizen ID (Ngày cấp).
        /// </summary>
        [Display(Name = "Ngày cấp")]
        public DateTime? IssuedDate { get; set; }

        /// <summary>
        /// VAT tax rate for the landlord (Mức thuế VAT).
        /// </summary>
        [Display(Name = "Mức thuế VAT")]
        public decimal? VatRate { get; set; }

        /// <summary>
        /// Personal income tax rate (Mức thuế TNCN).
        /// </summary>
        [Display(Name = "Mức thuế TNCN")]
        public decimal? PersonalIncomeTaxRate { get; set; }

        /// <summary>
        /// Bank account number (Số tài khoản).
        /// </summary>
        [StringLength(50)]
        [Display(Name = "Số tài khoản")]
        public string? BankAccountNumber { get; set; }

        /// <summary>
        /// Foreign key to bank information (Ngân hàng ID).
        /// </summary>
        [ForeignKey(nameof(Bank))]
        [Display(Name = "Ngân hàng")]
        public int? BankId { get; set; }

        /// <summary>
        /// Account holder name (Chủ tài khoản).
        /// </summary>
        [StringLength(200)]
        [Display(Name = "Chủ tài khoản")]
        public string? AccountHolder { get; set; }

        /// <summary>
        /// Province identifier (Tỉnh ID) referencing a location entry.
        /// </summary>
        [ForeignKey(nameof(Province))]
        [Display(Name = "Tỉnh")]
        public int? ProvinceId { get; set; }

        /// <summary>
        /// Commune/ward identifier (Xã ID) referencing a location entry.
        /// </summary>
        [ForeignKey(nameof(Ward))]
        [Display(Name = "Xã")]
        public int? WardId { get; set; }

        /// <summary>
        /// Navigation property to the associated bank.
        /// </summary>
        public virtual Bank? Bank { get; set; }

        /// <summary>
        /// Navigation property to the province location.
        /// </summary>
        public virtual Location? Province { get; set; }

        /// <summary>
        /// Navigation property to the ward location.
        /// </summary>
        public virtual Location? Ward { get; set; }

        /// <summary>
        /// Collection of rooms owned by the landlord.
        /// </summary>
        public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

        /// <summary>
        /// Collection of tenants under this landlord.
        /// </summary>
        public virtual ICollection<Tenant> Tenants { get; set; } = new List<Tenant>();

        /// <summary>
        /// Collection of revenue categories defined by this landlord.
        /// </summary>
        public virtual ICollection<RevenueCategory> RevenueCategories { get; set; } = new List<RevenueCategory>();

        /// <summary>
        /// Collection of expense categories defined by this landlord.
        /// </summary>
        public virtual ICollection<ExpenseCategory> ExpenseCategories { get; set; } = new List<ExpenseCategory>();

        /// <summary>
        /// Collection of contracts created by the landlord.
        /// </summary>
        public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

        // Hiển thị họ tên của chủ trọ trong giao diện (ví dụ, danh sách chọn)
        public override string ToString() => FullName;
    }
}