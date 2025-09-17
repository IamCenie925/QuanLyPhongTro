using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// DevExpress attributes to control how this class appears in XAF UI
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.DC;
using System.ComponentModel;

namespace PhongTro3.Module.BusinessObjects
{
    /// <summary>
    /// Represents a line item on an invoice (hóa đơn chi tiết).  Each detail
    /// references a revenue category and stores measurement readings and
    /// calculations for the billing period.
    /// </summary>
    // Hiển thị mặc định trong XAF và đặt biểu tượng cũng như nhóm menu
    [DefaultClassOptions]
    [ImageName("BO_InvoiceDetail")]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Chi tiết hóa đơn")]
    [DefaultProperty(nameof(Notes))]
    public class InvoiceDetail
    {
        [Key]
        [Display(Name = "Mã hóa đơn chi tiết")]
        public int InvoiceDetailId { get; set; }

        [ForeignKey(nameof(Invoice))]
        [Display(Name = "Hóa đơn")]
        public int InvoiceId { get; set; }

        [ForeignKey(nameof(RevenueCategory))]
        [Display(Name = "Loại thu")]
        public int RevenueCategoryId { get; set; }

        [Display(Name = "Chỉ số đầu")]
        public decimal? StartIndex { get; set; }

        [Display(Name = "Chỉ số cuối")]
        public decimal? EndIndex { get; set; }

        [Display(Name = "Số lượng")]
        public decimal? Quantity { get; set; }

        [Display(Name = "Đơn giá")]
        public decimal? UnitPrice { get; set; }

        [Display(Name = "Thành tiền")]
        public decimal? Amount { get; set; }

        [StringLength(500)]
        [Display(Name = "Ghi chú")]
        public string? Notes { get; set; }

        public virtual Invoice? Invoice { get; set; }
        public virtual RevenueCategory? RevenueCategory { get; set; }

        // Hiển thị ghi chú chi tiết hóa đơn hoặc ID
        public override string ToString() => !string.IsNullOrWhiteSpace(Notes) ? Notes! : $"CTHDN-{InvoiceDetailId}";
    }
}