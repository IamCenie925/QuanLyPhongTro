using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.DC;
using System.ComponentModel;

namespace PhongTro3.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Location")]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Địa phương")]
    [DefaultProperty(nameof(Name))]
    public class Location : XPObject
    {
        public Location(Session session) : base(session) { }

        private string code;
        [Size(50)]
        [XafDisplayName("Mã")]
        public string Code
        {
            get => code;
            set => SetPropertyValue(nameof(Code), ref code, value);
        }

        private string name;
        [Size(200)]
        [XafDisplayName("Tên")]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        public override string ToString() => Name;
    }
}
