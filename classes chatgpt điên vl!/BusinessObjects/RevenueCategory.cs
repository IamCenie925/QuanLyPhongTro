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
    /// Represents a classification of income (phân loại thu).  Examples might
    /// include base rent, electricity usage, or water usage.  A landlord can
    /// define many revenue categories and assign them to contracts and invoices.
    /// </summary>
    // Hiển thị mặc định trong XAF và đặt biểu tượng cũng như nhóm menu
    [DefaultClassOptions]
    [ImageName("BO_RevenueCategory")]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Loại thu")]
    [DefaultProperty(nameof(Name))]
    public class RevenueCategory
    {
        [Key]
        [Display(Name = "Mã loại thu")]
        public int RevenueCategoryId { get; set; }

        [ForeignKey(nameof(Landlord))]
        [Display(Name = "Chủ trọ")]
        public int LandlordId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Tên khoản thu")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Giá theo tháng")]
        public decimal? MonthlyPrice { get; set; }

        [Display(Name = "Đơn giá chỉ số")]
        public decimal? UnitPriceIndex { get; set; }

        [Display(Name = "Mặc định hợp đồng")]
        public bool IsDefaultContract { get; set; }

        [Display(Name = "Tiền nhà")]
        public bool IsRent { get; set; }

        public virtual Landlord? Landlord { get; set; }

        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

        public virtual ICollection<ContractDetail> ContractDetails { get; set; } = new List<ContractDetail>();

        // Hiển thị tên loại thu
        public override string ToString() => Name;
    }
}