using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// DevExpress attributes to control how this class appears in XAF UI
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.DC;
using System.ComponentModel;

namespace PhongTro3.Module.BusinessObjects
{
    /// <summary>
    /// Represents a revenue receipt (phiếu thu) issued by a landlord.  Receipts
    /// record payments collected from tenants for invoices or temporary stays.
    /// </summary>
    // Hiển thị mặc định trong XAF và đặt biểu tượng cũng như nhóm menu
    [DefaultClassOptions]
    [ImageName("BO_Receipt")]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Phiếu thu")]
    [DefaultProperty(nameof(Number))]
    public class Receipt
    {
        [Key]
        [Display(Name = "Mã phiếu thu")]
        public int ReceiptId { get; set; }

        [ForeignKey(nameof(Landlord))]
        [Display(Name = "Chủ trọ")]
        public int LandlordId { get; set; }

        /// <summary>
        /// Optional link to an invoice (hóa đơn) that this receipt settles.
        /// </summary>
        [ForeignKey(nameof(Invoice))]
        [Display(Name = "Hóa đơn")]
        public int? InvoiceId { get; set; }

        /// <summary>
        /// Optional link to a temporary residence record (tạm trú) for which payment is collected.
        /// </summary>
        [ForeignKey(nameof(TemporaryResidence))]
        [Display(Name = "Tạm trú")]
        public int? TemporaryResidenceId { get; set; }

        [StringLength(50)]
        [Display(Name = "Số")]
        public string? Number { get; set; }

        [Display(Name = "Ngày")]
        public DateTime? Date { get; set; }

        [Display(Name = "Số tiền")]
        public decimal? Amount { get; set; }

        [StringLength(500)]
        [Display(Name = "Nội dung")]
        public string? Content { get; set; }

        [StringLength(200)]
        [Display(Name = "Ảnh thanh toán")]
        public string? PaymentImage { get; set; }

        public virtual Landlord? Landlord { get; set; }
        public virtual Invoice? Invoice { get; set; }
        public virtual TemporaryResidence? TemporaryResidence { get; set; }

        // Hiển thị số phiếu thu hoặc ID nếu không có số
        public override string ToString() => !string.IsNullOrWhiteSpace(Number) ? Number : $"PT-{ReceiptId}";
    }
}