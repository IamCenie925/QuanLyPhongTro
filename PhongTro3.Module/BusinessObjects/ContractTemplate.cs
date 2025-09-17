using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.DC;
using DevExpress.Xpo;
using System.ComponentModel;
using DevExpress.Persistent.Validation;

namespace PhongTro3.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Mẫu hợp đồng")]
    [DefaultProperty(nameof(Name))]
    [ImageName("BO_ContractTemplate")]
    public class ContractTemplate : BaseObject
    {
        public ContractTemplate(Session session) : base(session) { }

        private string name;
        private string content;
        private Landlord landlord;

        [Association("Landlord-ContractTemplates")]
        [XafDisplayName("Chủ trọ")]
        [RuleRequiredField(DefaultContexts.Save)]
        public Landlord Landlord
        {
            get => landlord;
            set => SetPropertyValue(nameof(Landlord), ref landlord, value);
        }

        [XafDisplayName("Tên mẫu")]
        [Size(200)]
        [RuleRequiredField(DefaultContexts.Save)]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        [XafDisplayName("Nội dung")]
        [Size(SizeAttribute.Unlimited)]
        public string Content
        {
            get => content;
            set => SetPropertyValue(nameof(Content), ref content, value);
        }

        [Association("ContractTemplate-Contracts")]
        public XPCollection<Contract> Contracts
        {
            get => GetCollection<Contract>(nameof(Contracts));
        }

        public override string ToString() => Name;
    }
}
