using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// DevExpress XAF: UI metadata attributes
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.DC;
using System.ComponentModel;

namespace PhongTro3.Module.BusinessObjects
{
    /// <summary>
    /// Represents an invoice (hóa đơn) generated from a contract.  An invoice
    /// captures the total amount due for a billing period.
    /// </summary>
    // XAF attributes: hiển thị trong menu "Quản lý trọ" với tên "Hóa đơn".
    // DefaultProperty giúp XAF hiển thị thuộc tính Number làm tiêu đề của đối tượng.
    [DefaultClassOptions]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Hóa đơn")]
    [DefaultProperty(nameof(Number))]
    [ImageName("BO_Invoice")]
    public class Invoice
    {
        [Key]
        [Display(Name = "Mã hóa đơn")]
        public int InvoiceId { get; set; }

        [ForeignKey(nameof(Landlord))]
        [Display(Name = "Chủ trọ")]
        public int LandlordId { get; set; }

        [ForeignKey(nameof(Contract))]
        [Display(Name = "Hợp đồng")]
        public int ContractId { get; set; }

        [StringLength(50)]
        [Display(Name = "Số")]
        public string? Number { get; set; }

        [Display(Name = "Ngày")]
        public DateTime? Date { get; set; }

        [Display(Name = "Tổng tiền")]
        public decimal? Total { get; set; }

        [Display(Name = "Còn nợ")]
        public decimal? Debt { get; set; }

        [StringLength(500)]
        [Display(Name = "Nội dung")]
        public string? Content { get; set; }

        public virtual Landlord? Landlord { get; set; }
        public virtual Contract? Contract { get; set; }

        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
        public virtual ICollection<InvoiceImage> InvoiceImages { get; set; } = new List<InvoiceImage>();
        public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();

        // Hiển thị số hóa đơn hoặc ID khi không có số.
        public override string ToString() => !string.IsNullOrWhiteSpace(Number) ? Number : $"HD-{InvoiceId}";
    }
}