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
    /// Represents a rental contract (hợp đồng) between a landlord and a tenant for a specific room.
    /// </summary>
    // Hiển thị mặc định trong XAF và đặt biểu tượng cũng như nhóm menu
    [DefaultClassOptions]
    [ImageName("BO_Contract")]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Hợp đồng")]
    [DefaultProperty(nameof(Number))]
    public class Contract
    {
        [Key]
        [Display(Name = "Mã hợp đồng")]
        public int ContractId { get; set; }

        [ForeignKey(nameof(Landlord))]
        [Display(Name = "Chủ trọ")]
        public int LandlordId { get; set; }

        [ForeignKey(nameof(Room))]
        [Display(Name = "Phòng")]
        public int RoomId { get; set; }

        /// <summary>
        /// Optional reference to a contract template (hợp đồng mẫu) used to generate this contract.
        /// </summary>
        [ForeignKey(nameof(ContractTemplate))]
        [Display(Name = "Mẫu hợp đồng")]
        public int? ContractTemplateId { get; set; }

        [StringLength(50)]
        [Display(Name = "Số")]
        public string? Number { get; set; }

        [Display(Name = "Ngày lập")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Từ ngày")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Đến ngày")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Tiền cọc")]
        public decimal? Deposit { get; set; }

        [StringLength(500)]
        [Display(Name = "Ghi chú")]
        public string? Notes { get; set; }

        [StringLength(50)]
        [Display(Name = "Trạng thái")]
        public string? Status { get; set; }

        [Display(Name = "Thanh toán từ ngày")]
        public DateTime? PaymentFromDate { get; set; }

        [Display(Name = "Thanh toán đến ngày")]
        public DateTime? PaymentToDate { get; set; }

        [StringLength(100)]
        [Display(Name = "Hình thức thanh toán")]
        public string? PaymentMethod { get; set; }

        public virtual Landlord? Landlord { get; set; }
        public virtual Room? Room { get; set; }
        public virtual ContractTemplate? ContractTemplate { get; set; }

        public virtual ICollection<ContractDetail> ContractDetails { get; set; } = new List<ContractDetail>();
        public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
        public virtual ICollection<TemporaryResidence> TemporaryResidences { get; set; } = new List<TemporaryResidence>();

        // Hiển thị số hợp đồng hoặc ID nếu không có số
        public override string ToString() => !string.IsNullOrWhiteSpace(Number) ? Number : $"HD-{ContractId}";
    }
}