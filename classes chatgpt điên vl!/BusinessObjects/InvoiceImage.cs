using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// DevExpress XAF attributes
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.DC;
using System.ComponentModel;

namespace PhongTro3.Module.BusinessObjects
{
    /// <summary>
    /// Represents a scanned image associated with an invoice.
    /// Storing images outside of the database and saving only a path
    /// or filename is a common practice for large binary data.
    /// </summary>
    // XAF metadata: hiển thị ảnh hóa đơn trong menu Quản lý trọ
    [DefaultClassOptions]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Ảnh hóa đơn")]
    [DefaultProperty(nameof(ImagePath))]
    [ImageName("BO_InvoiceImage")]
    public class InvoiceImage
    {
        [Key]
        [Display(Name = "Mã ảnh")]
        public int InvoiceImageId { get; set; }

        [ForeignKey(nameof(Invoice))]
        [Display(Name = "Hóa đơn")]
        public int InvoiceId { get; set; }

        [StringLength(500)]
        [Display(Name = "Ảnh")]
        public string? ImagePath { get; set; }

        public virtual Invoice? Invoice { get; set; }

        // Trả về đường dẫn hoặc ID nếu không có
        public override string ToString() => !string.IsNullOrWhiteSpace(ImagePath) ? ImagePath : $"IMG-{InvoiceImageId}";
    }
}