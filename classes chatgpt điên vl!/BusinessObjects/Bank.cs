using System.ComponentModel.DataAnnotations;
// DevExpress attributes to control how this class appears in XAF UI
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.DC;
using System.ComponentModel;

namespace PhongTro3.Module.BusinessObjects
{
    /// <summary>
    /// Represents a bank (ngân hàng) used to store landlord account information.
    /// </summary>
    // Hiển thị mặc định trong XAF và đặt biểu tượng cũng như nhóm menu
    [DefaultClassOptions]
    [ImageName("BO_Bank")]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Ngân hàng")]
    [DefaultProperty(nameof(Name))]
    public class Bank
    {
        [Key]
        [Display(Name = "Mã ngân hàng")]
        public int BankId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Tên ngân hàng")]
        public string Name { get; set; } = string.Empty;

        [StringLength(50)]
        [Display(Name = "Tên viết tắt")]
        public string? ShortName { get; set; }

        [StringLength(20)]
        [Display(Name = "Mã")]
        public string? Code { get; set; }

        /// <summary>
        /// Bank Identification Number (BIN) if applicable.
        /// </summary>
        [StringLength(20)]
        [Display(Name = "BIN")]
        public string? Bin { get; set; }

        // Hiển thị tên ngân hàng
        public override string ToString() => Name;
    }
}