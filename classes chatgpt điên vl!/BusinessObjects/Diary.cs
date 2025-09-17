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
    /// Represents a daily diary or log entry (nhật ký) for a temporary residence.
    /// </summary>
    // XAF metadata: hiển thị nhật ký trong menu Quản lý trọ
    [DefaultClassOptions]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Nhật ký")]
    [DefaultProperty(nameof(Date))]
    [ImageName("BO_Diary")]
    public class Diary
    {
        [Key]
        [Display(Name = "Mã nhật ký")]
        public int DiaryId { get; set; }

        [ForeignKey(nameof(Landlord))]
        [Display(Name = "Chủ trọ")]
        public int LandlordId { get; set; }

        [ForeignKey(nameof(TemporaryResidence))]
        [Display(Name = "Tạm trú")]
        public int TemporaryResidenceId { get; set; }

        [Display(Name = "Ngày")]
        public DateTime? Date { get; set; }

        [StringLength(500)]
        [Display(Name = "Nội dung")]
        public string? Content { get; set; }

        [StringLength(200)]
        [Display(Name = "Ảnh")]
        public string? ImagePath { get; set; }

        public virtual Landlord? Landlord { get; set; }
        public virtual TemporaryResidence? TemporaryResidence { get; set; }

        // Hiển thị ngày nhật ký hoặc ID
        public override string ToString() => Date.HasValue ? Date.Value.ToString("yyyy-MM-dd") : $"NK-{DiaryId}";
    }
}