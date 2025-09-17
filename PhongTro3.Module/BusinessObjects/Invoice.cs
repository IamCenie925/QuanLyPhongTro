using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.DC;
using DevExpress.Xpo;
using DevExpress.Persistent.Validation;
using System.ComponentModel;

namespace PhongTro3.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Hóa đơn")]
    [DefaultProperty(nameof(Number))]
    [ImageName("BO_Invoice")]
    // 🔹 Rule: Số Hóa đơn phải duy nhất trong phạm vi 1 Chủ trọ
    [RuleCombinationOfPropertiesIsUnique(
        "UniqueInvoiceNumberPerLandlord",
        DefaultContexts.Save,
        "Landlord;Number",
        CustomMessageTemplate = "Số hóa đơn đã tồn tại trong cùng Chủ trọ.")]
    public class Invoice : BaseObject
    {
        public Invoice(Session session) : base(session) { }

        private Landlord landlord;
        private Contract contract;
        private string number;
        private DateTime? date;
        private decimal? total;
        private decimal? debt;
        private string content;

        [Association("Landlord-Invoices")]
        [XafDisplayName("Chủ trọ")]
        [RuleRequiredField(DefaultContexts.Save)]
        public Landlord Landlord
        {
            get => landlord;
            set => SetPropertyValue(nameof(Landlord), ref landlord, value);
        }

        [Association("Contract-Invoices")]
        [XafDisplayName("Hợp đồng")]
        [RuleRequiredField(DefaultContexts.Save)]
        public Contract Contract
        {
            get => contract;
            set => SetPropertyValue(nameof(Contract), ref contract, value);
        }

        [Size(50)]
        [XafDisplayName("Số HĐ")]
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

        [XafDisplayName("Tổng tiền")]
        [RuleValueComparison("Invoice_Total_GreaterOrEqual_0", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]
        public decimal? Total
        {
            get => total;
            set => SetPropertyValue(nameof(Total), ref total, value);
        }

        [XafDisplayName("Còn nợ")]
        [RuleValueComparison("Invoice_Debt_GreaterOrEqual_0", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]
        public decimal? Debt
        {
            get => debt;
            set => SetPropertyValue(nameof(Debt), ref debt, value);
        }

        [Size(500)]
        [XafDisplayName("Nội dung")]
        public string Content
        {
            get => content;
            set => SetPropertyValue(nameof(Content), ref content, value);
        }

        // 🔹 Quan hệ con: xóa Invoice sẽ xóa luôn các con
        [Association("Invoice-InvoiceDetails"), DevExpress.Xpo.Aggregated]
        public XPCollection<InvoiceDetail> InvoiceDetails
            => GetCollection<InvoiceDetail>(nameof(InvoiceDetails));

        [Association("Invoice-InvoiceImages"), DevExpress.Xpo.Aggregated]
        public XPCollection<InvoiceImage> InvoiceImages
            => GetCollection<InvoiceImage>(nameof(InvoiceImages));

        [Association("Invoice-Receipts"), DevExpress.Xpo.Aggregated]
        public XPCollection<Receipt> Receipts
            => GetCollection<Receipt>(nameof(Receipts));

        public override string ToString()
            => !string.IsNullOrWhiteSpace(Number) ? Number : $"HD-{Oid}";
    }
}
