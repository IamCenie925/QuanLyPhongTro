using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// DevExpress XAF attributes
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.DC;
using System.ComponentModel;

namespace PhongTro3.Module.BusinessObjects
{
    /// <summary>
    /// Represents a classification of expenses (phân loại chi).  Landlords define
    /// expense categories to categorize payments such as maintenance, utilities,
    /// repairs, etc.
    /// </summary>
    // XAF metadata: hiển thị loại chi trong menu Quản lý trọ
    [DefaultClassOptions]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Loại chi")]
    [DefaultProperty(nameof(Name))]
    [ImageName("BO_ExpenseCategory")]
    public class ExpenseCategory
    {
        [Key]
        [Display(Name = "Mã loại chi")]
        public int ExpenseCategoryId { get; set; }

        [ForeignKey(nameof(Landlord))]
        [Display(Name = "Chủ trọ")]
        public int LandlordId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Tên khoản chi")]
        public string Name { get; set; } = string.Empty;

        public virtual Landlord? Landlord { get; set; }
        public virtual ICollection<ExpenseReceipt> ExpenseReceipts { get; set; } = new List<ExpenseReceipt>();

        // Hiển thị tên loại chi
        public override string ToString() => Name;
    }
}