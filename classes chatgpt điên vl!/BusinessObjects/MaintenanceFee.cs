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
    /// Represents a maintenance or subscription fee (phí duy trì) that a landlord pays.
    /// </summary>
    // XAF metadata: hiển thị phí duy trì trong menu Quản lý trọ
    [DefaultClassOptions]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Phí duy trì")]
    [DefaultProperty(nameof(Date))]
    [ImageName("BO_MaintenanceFee")]
    public class MaintenanceFee
    {
        [Key]
        [Display(Name = "Mã phí duy trì")]
        public int MaintenanceFeeId { get; set; }

        [ForeignKey(nameof(Landlord))]
        [Display(Name = "Chủ trọ")]
        public int LandlordId { get; set; }

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

        // Hiển thị ngày phí duy trì; nếu rỗng thì dùng ID.
        public override string ToString() => Date.HasValue ? Date.Value.ToString("yyyy-MM-dd") : $"PF-{MaintenanceFeeId}";
    }
}