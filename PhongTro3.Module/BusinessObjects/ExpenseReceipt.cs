using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.DC;
using DevExpress.Xpo;
using System.ComponentModel;
namespace PhongTro3.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Phiếu chi")]
    [DefaultProperty(nameof(Number))]
    [ImageName("BO_ExpenseReceipt")]
    public class ExpenseReceipt : BaseObject
    {
        public ExpenseReceipt(Session session) : base(session) { }

        private string number;
        private DateTime? date;
        private decimal? amount;
        private string content;
        private string paymentImage;

        private Landlord landlord;
        private TemporaryResidence temporaryResidence;
        private ExpenseCategory expenseCategory;

        [Association("Landlord-ExpenseReceipts")]
        [XafDisplayName("Chủ trọ")]
        public Landlord Landlord
        {
            get => landlord;
            set => SetPropertyValue(nameof(Landlord), ref landlord, value);
        }

        [Association("TemporaryResidence-ExpenseReceipts")]
        [XafDisplayName("Tạm trú")]
        public TemporaryResidence TemporaryResidence
        {
            get => temporaryResidence;
            set => SetPropertyValue(nameof(TemporaryResidence), ref temporaryResidence, value);
        }

        [Association("ExpenseCategory-ExpenseReceipts")]
        [XafDisplayName("Loại chi")]
        public ExpenseCategory ExpenseCategory
        {
            get => expenseCategory;
            set => SetPropertyValue(nameof(ExpenseCategory), ref expenseCategory, value);
        }

        [Size(50)]
        [XafDisplayName("Số")]
        public string Number
        {
            get => number;
            set => SetPropertyValue(nameof(Number), ref number, value);
        }

        [XafDisplayName("Ngày")]
        public DateTime? Date
        {
            get => date;
            set => SetPropertyValue(nameof(Date), ref date, value);
        }

        [XafDisplayName("Số tiền")]
        public decimal? Amount
        {
            get => amount;
            set => SetPropertyValue(nameof(Amount), ref amount, value);
        }

        [Size(500)]
        [XafDisplayName("Nội dung")]
        public string Content
        {
            get => content;
            set => SetPropertyValue(nameof(Content), ref content, value);
        }

        [Size(200)]
        [XafDisplayName("Ảnh thanh toán")]
        public string PaymentImage
        {
            get => paymentImage;
            set => SetPropertyValue(nameof(PaymentImage), ref paymentImage, value);
        }

        public override string ToString()
        {
            return !string.IsNullOrWhiteSpace(Number) ? Number : $"PC-{Oid}";
        }
    }
}
