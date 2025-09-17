using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.DC;
using DevExpress.Xpo;
using System.ComponentModel;

namespace PhongTro3.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Thiết bị")]
    [DefaultProperty(nameof(Name))]
    [ImageName("BO_Equipment")]
    public class Equipment : BaseObject
    {
        public Equipment(Session session) : base(session) { }

        private string name;
        private string notes;
        private Landlord landlord;

        [Association("Landlord-Equipments")]
        [XafDisplayName("Chủ trọ")]
        public Landlord Landlord
        {
            get => landlord;
            set => SetPropertyValue(nameof(Landlord), ref landlord, value);
        }

        [XafDisplayName("Tên thiết bị")]
        [Size(200)]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        [XafDisplayName("Ghi chú")]
        [Size(500)]
        public string Notes
        {
            get => notes;
            set => SetPropertyValue(nameof(Notes), ref notes, value);
        }

        // Quan hệ nhiều-nhiều với Room thông qua RoomEquipment
        [Association("Equipment-RoomEquipments")]
        public XPCollection<RoomEquipment> RoomEquipments
        {
            get => GetCollection<RoomEquipment>(nameof(RoomEquipments));
        }

        public override string ToString() => Name;
    }
}
