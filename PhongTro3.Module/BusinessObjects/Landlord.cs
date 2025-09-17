using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System.ComponentModel;
using AggregatedAttribute = DevExpress.ExpressApp.DC.AggregatedAttribute;

namespace PhongTro3.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Landlord")]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Chủ trọ")]
    [DefaultProperty(nameof(FullName))]
    public class Landlord : BaseObject
    {
        public Landlord(Session session) : base(session) { }

        private string fullName;
        private string phone;
        private string email;
        private string citizenId;
        private DateTime? issuedDate;
        private decimal? vatRate;
        private decimal? personalIncomeTaxRate;
        private string bankAccountNumber;
        private string accountHolder;

        [Size(200)]
        [XafDisplayName("Họ tên")]
        [RuleRequiredField(DefaultContexts.Save)]
        public string FullName
        {
            get => fullName;
            set => SetPropertyValue(nameof(FullName), ref fullName, value);
        }

        [Size(50)]
        [XafDisplayName("Điện thoại")]
        public string Phone
        {
            get => phone;
            set => SetPropertyValue(nameof(Phone), ref phone, value);
        }

        [Size(100)]
        [XafDisplayName("Email")]
        public string Email
        {
            get => email;
            set => SetPropertyValue(nameof(Email), ref email, value);
        }

        [Size(50)]
        [XafDisplayName("Số CCCD")]
        public string CitizenId
        {
            get => citizenId;
            set => SetPropertyValue(nameof(CitizenId), ref citizenId, value);
        }

        [XafDisplayName("Ngày cấp")]
        public DateTime? IssuedDate
        {
            get => issuedDate;
            set => SetPropertyValue(nameof(IssuedDate), ref issuedDate, value);
        }

        [XafDisplayName("Mức thuế VAT")]
        public decimal? VatRate
        {
            get => vatRate;
            set => SetPropertyValue(nameof(VatRate), ref vatRate, value);
        }

        [XafDisplayName("Mức thuế TNCN")]
        public decimal? PersonalIncomeTaxRate
        {
            get => personalIncomeTaxRate;
            set => SetPropertyValue(nameof(PersonalIncomeTaxRate), ref personalIncomeTaxRate, value);
        }

        [Size(50)]
        [XafDisplayName("Số tài khoản")]
        public string BankAccountNumber
        {
            get => bankAccountNumber;
            set => SetPropertyValue(nameof(BankAccountNumber), ref bankAccountNumber, value);
        }

        [Size(200)]
        [XafDisplayName("Chủ tài khoản")]
        public string AccountHolder
        {
            get => accountHolder;
            set => SetPropertyValue(nameof(AccountHolder), ref accountHolder, value);
        }

        // Associations
        [Association("Landlord-ExpenseReceipts"), Aggregated]
        public XPCollection<ExpenseReceipt> ExpenseReceipts => GetCollection<ExpenseReceipt>(nameof(ExpenseReceipts));

        [Association("Landlord-Diaries"), Aggregated]
        public XPCollection<Diary> Diaries => GetCollection<Diary>(nameof(Diaries));

        [Association("Landlord-Equipments"), Aggregated]
        public XPCollection<Equipment> Equipments => GetCollection<Equipment>(nameof(Equipments));

        [Association("Landlord-MaintenanceFees"), Aggregated]
        public XPCollection<MaintenanceFee> MaintenanceFees => GetCollection<MaintenanceFee>(nameof(MaintenanceFees));

        [Association("Landlord-Receipts"), Aggregated]
        public XPCollection<Receipt> Receipts => GetCollection<Receipt>(nameof(Receipts));

        [Association("Landlord-ContractTemplates"), Aggregated]
        public XPCollection<ContractTemplate> ContractTemplates => GetCollection<ContractTemplate>(nameof(ContractTemplates));

        [Association("Landlord-Rooms"), Aggregated]
        public XPCollection<Room> Rooms => GetCollection<Room>(nameof(Rooms));

        [Association("Landlord-Tenants"), Aggregated]
        public XPCollection<Tenant> Tenants => GetCollection<Tenant>(nameof(Tenants));

        [Association("Landlord-RevenueCategories"), Aggregated]
        public XPCollection<RevenueCategory> RevenueCategories => GetCollection<RevenueCategory>(nameof(RevenueCategories));

        [Association("Landlord-ExpenseCategories"), Aggregated]
        public XPCollection<ExpenseCategory> ExpenseCategories => GetCollection<ExpenseCategory>(nameof(ExpenseCategories));

        [Association("Landlord-Contracts"), Aggregated]
        public XPCollection<Contract> Contracts => GetCollection<Contract>(nameof(Contracts));

        [Association("Landlord-Invoices"), Aggregated]
        public XPCollection<Invoice> Invoices => GetCollection<Invoice>(nameof(Invoices));

        public override string ToString() => FullName;
    }
}