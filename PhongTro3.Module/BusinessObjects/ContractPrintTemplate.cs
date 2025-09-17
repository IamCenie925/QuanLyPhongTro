using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.DC;
using DevExpress.Xpo;
using System.ComponentModel;
using DevExpress.Persistent.Validation;

namespace PhongTro3.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_ContractPrintTemplate")]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Mẫu in hợp đồng")]
    [DefaultProperty(nameof(Name))]
    public class ContractPrintTemplate : BaseObject
    {
        public ContractPrintTemplate(Session session) : base(session) { }

        private string name;
        private string content;

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

        public override string ToString() => Name;
    }
}
