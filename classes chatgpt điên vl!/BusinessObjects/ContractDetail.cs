using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// DevExpress attributes to control how this class appears in XAF UI
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.DC;
using System.ComponentModel;

namespace PhongTro3.Module.BusinessObjects
{
    /// <summary>
    /// Represents a line item attached to a contract (hợp đồng chi tiết).  This class
    /// defines recurring charges such as monthly rent or utility rates that apply
    /// throughout the contract period.
    /// </summary>
    // Hiển thị mặc định trong XAF và đặt biểu tượng cũng như nhóm menu
    [DefaultClassOptions]
    [ImageName("BO_ContractDetail")]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Chi tiết hợp đồng")]
    [DefaultProperty(nameof(Notes))]
    public class ContractDetail
    {
        [Key]
        [Display(Name = "Mã hợp đồng chi tiết")]
        public int ContractDetailId { get; set; }

        [ForeignKey(nameof(Contract))]
        [Display(Name = "Hợp đồng")]
        public int ContractId { get; set; }

        [ForeignKey(nameof(RevenueCategory))]
        [Display(Name = "Loại thu")]
        public int RevenueCategoryId { get; set; }

        [Display(Name = "Giá theo tháng")]
        public decimal? MonthlyPrice { get; set; }

        [Display(Name = "Đơn giá chỉ số")]
        public decimal? UnitPriceIndex { get; set; }

        [Display(Name = "Chỉ số đầu")]
        public decimal? StartIndex { get; set; }

        [StringLength(500)]
        [Display(Name = "Ghi chú")]
        public string? Notes { get; set; }

        public virtual Contract? Contract { get; set; }
        public virtual RevenueCategory? RevenueCategory { get; set; }

        // Hiển thị ghi chú hoặc ID nếu không có ghi chú
        public override string ToString() => !string.IsNullOrWhiteSpace(Notes) ? Notes! : $"CTHD-{ContractDetailId}";
    }
}