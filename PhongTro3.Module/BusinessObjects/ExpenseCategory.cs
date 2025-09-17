using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.DC;
using DevExpress.Xpo;
using System.ComponentModel;
namespace PhongTro3.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Loại chi")]
    [DefaultProperty(nameof(Name))]
    [ImageName("BO_ExpenseCategory")]
    public class ExpenseCategory : BaseObject
    {
        public ExpenseCategory(Session session) : base(session) { }

        private string name;
        private Landlord landlord;

        [Association("Landlord-ExpenseCategories")]
        [XafDisplayName("Chủ trọ")]
        public Landlord Landlord
        {
            get => landlord;
            set => SetPropertyValue(nameof(Landlord), ref landlord, value);
        }

        [XafDisplayName("Tên khoản chi")]
        [Size(200)]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        // 1 Loại chi có nhiều phiếu chi
        [Association("ExpenseCategory-ExpenseReceipts")]
        public XPCollection<ExpenseReceipt> ExpenseReceipts
        {
            get => GetCollection<ExpenseReceipt>(nameof(ExpenseReceipts));
        }

        public override string ToString() => Name;
    }
}
