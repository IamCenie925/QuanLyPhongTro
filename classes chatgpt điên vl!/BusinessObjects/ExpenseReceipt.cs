using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// DevExpress XAF attributes
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.DC;
using System.ComponentModel;

namespace PhongTro3.Module.BusinessObjects
{
    /// <summary>
    /// Represents an expense receipt (phiếu chi).  Expense receipts record
    /// out-going payments made by the landlord for services or purchases.
    /// </summary>
    // XAF metadata: hiển thị phiếu chi trong menu Quản lý trọ
    [DefaultClassOptions]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Phiếu chi")]
    [DefaultProperty(nameof(Number))]
    [ImageName("BO_ExpenseReceipt")]
    public class ExpenseReceipt
    {
        [Key]
        [Display(Name = "Mã phiếu chi")]
        public int ExpenseReceiptId { get; set; }

        [ForeignKey(nameof(Landlord))]
        [Display(Name = "Chủ trọ")]
        public int LandlordId { get; set; }

        [ForeignKey(nameof(TemporaryResidence))]
        [Display(Name = "Tạm trú")]
        public int? TemporaryResidenceId { get; set; }

        [ForeignKey(nameof(ExpenseCategory))]
        [Display(Name = "Loại chi")]
        public int ExpenseCategoryId { get; set; }

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
        public virtual TemporaryResidence? TemporaryResidence { get; set; }
        public virtual ExpenseCategory? ExpenseCategory { get; set; }

        // Hiển thị số phiếu chi hoặc ID nếu không có số
        public override string ToString() => !string.IsNullOrWhiteSpace(Number) ? Number : $"PC-{ExpenseReceiptId}";
    }
}