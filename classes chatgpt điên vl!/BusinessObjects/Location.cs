using System.ComponentModel.DataAnnotations;
// DevExpress attributes to control how this class appears in XAF UI
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.DC;
using System.ComponentModel;

namespace PhongTro3.Module.BusinessObjects
{
    /// <summary>
    /// Represents a geographical location such as a province or commune (địa phương).
    /// </summary>
    // Hiển thị mặc định trong XAF và đặt biểu tượng cũng như nhóm menu
    [DefaultClassOptions]
    [ImageName("BO_Location")]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Địa phương")]
    [DefaultProperty(nameof(Name))]
    public class Location
    {
        [Key]
        [Display(Name = "Mã địa phương")]
        public int LocationId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Mã")]
        public string Code { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        [Display(Name = "Tên")]
        public string Name { get; set; } = string.Empty;

        // Hiển thị tên địa phương
        public override string ToString() => Name;
    }
}