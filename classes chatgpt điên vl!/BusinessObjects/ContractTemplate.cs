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
    /// Represents a contract template (hợp đồng mẫu) defined by a landlord.  A
    /// contract template contains pre-defined content that can be used to
    /// generate multiple contracts.
    /// </summary>
    // XAF metadata: hiển thị mẫu hợp đồng trong menu Quản lý trọ
    [DefaultClassOptions]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Mẫu hợp đồng")]
    [DefaultProperty(nameof(Name))]
    [ImageName("BO_ContractTemplate")]
    public class ContractTemplate
    {
        [Key]
        [Display(Name = "Mã hợp đồng mẫu")]
        public int ContractTemplateId { get; set; }

        [ForeignKey(nameof(Landlord))]
        [Display(Name = "Chủ trọ")]
        public int LandlordId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Tên mẫu")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Nội dung")]
        public string? Content { get; set; }

        public virtual Landlord? Landlord { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

        // Hiển thị tên mẫu
        public override string ToString() => Name;
    }
}