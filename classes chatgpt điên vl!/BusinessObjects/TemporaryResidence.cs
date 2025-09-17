using System;
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
    /// Represents a temporary residence record (tạm trú) for a tenant under a contract.
    /// </summary>
    // Hiển thị mặc định trong XAF và đặt biểu tượng cũng như nhóm menu
    [DefaultClassOptions]
    [ImageName("BO_TemporaryResidence")]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Tạm trú")]
    [DefaultProperty(nameof(Notes))]
    public class TemporaryResidence
    {
        [Key]
        [Display(Name = "Mã tạm trú")]
        public int TemporaryResidenceId { get; set; }

        [ForeignKey(nameof(Contract))]
        [Display(Name = "Hợp đồng")]
        public int ContractId { get; set; }

        [ForeignKey(nameof(Tenant))]
        [Display(Name = "Khách")]
        public int TenantId { get; set; }

        [Display(Name = "Ngày đầu")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Ngày kết thúc")]
        public DateTime? EndDate { get; set; }

        [StringLength(500)]
        [Display(Name = "Ghi chú")]
        public string? Notes { get; set; }

        public virtual Contract? Contract { get; set; }
        public virtual Tenant? Tenant { get; set; }

        public virtual ICollection<Diary> Diaries { get; set; } = new List<Diary>();
        public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();
        public virtual ICollection<ExpenseReceipt> ExpenseReceipts { get; set; } = new List<ExpenseReceipt>();

        // Hiển thị ghi chú hoặc ID nếu không có ghi chú
        public override string ToString() => !string.IsNullOrWhiteSpace(Notes) ? Notes! : $"TT-{TemporaryResidenceId}";
    }
}