using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.DC;
using DevExpress.Xpo;
using System.ComponentModel;

namespace PhongTro3.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Bank")]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Ngân hàng")]
    [DefaultProperty(nameof(Name))]
    public class Bank : BaseObject
    {
        public Bank(Session session) : base(session) { }

        private string name;
        private string shortName;
        private string code;
        private string bin;

        [XafDisplayName("Tên ngân hàng")]
        [Size(200)]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        [XafDisplayName("Tên viết tắt")]
        [Size(50)]
        public string ShortName
        {
            get => shortName;
            set => SetPropertyValue(nameof(ShortName), ref shortName, value);
        }

        [XafDisplayName("Mã")]
        [Size(20)]
        public string Code
        {
            get => code;
            set => SetPropertyValue(nameof(Code), ref code, value);
        }

        [XafDisplayName("BIN")]
        [Size(20)]
        public string Bin
        {
            get => bin;
            set => SetPropertyValue(nameof(Bin), ref bin, value);
        }

        public override string ToString() => Name;
    }
}
