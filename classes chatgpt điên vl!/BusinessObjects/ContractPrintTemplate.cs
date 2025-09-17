using System.ComponentModel.DataAnnotations;
// DevExpress attributes to control how this class appears in XAF UI
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.DC;
using System.ComponentModel;

namespace PhongTro3.Module.BusinessObjects
{
    /// <summary>
    /// Represents a printable contract template (mẫu in hợp đồng).  This table
    /// stores templates that define how contracts are formatted when printed.
    /// </summary>
    // Hiển thị mặc định trong XAF và đặt biểu tượng cũng như nhóm menu
    [DefaultClassOptions]
    [ImageName("BO_ContractPrintTemplate")]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Mẫu in hợp đồng")]
    [DefaultProperty(nameof(Name))]
    public class ContractPrintTemplate
    {
        [Key]
        [Display(Name = "Mã mẫu in")]
        public int ContractPrintTemplateId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Tên mẫu")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Nội dung")]
        public string? Content { get; set; }

        // Hiển thị tên mẫu in hợp đồng
        public override string ToString() => Name;
    }
}