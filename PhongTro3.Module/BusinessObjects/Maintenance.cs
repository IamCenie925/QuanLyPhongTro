using System;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.DC;
using System.ComponentModel;

namespace PhongTro3.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Bảo trì")]
    [DefaultProperty(nameof(Date))]
    [ImageName("BO_Maintenance")]
    public class Maintenance : XPObject
    {
        public Maintenance(Session session) : base(session) { }

        private RoomEquipment roomEquipment;
        [Association("RoomEquipment-Maintenances")]
        [XafDisplayName("Thiết bị phòng")]
        public RoomEquipment RoomEquipment
        {
            get => roomEquipment;
            set => SetPropertyValue(nameof(RoomEquipment), ref roomEquipment, value);
        }

        private DateTime? date;
        [XafDisplayName("Ngày")]
        public DateTime? Date
        {
            get => date;
            set => SetPropertyValue(nameof(Date), ref date, value);
        }

        private string content;
        [Size(500)]
        [XafDisplayName("Nội dung")]
        public string Content
        {
            get => content;
            set => SetPropertyValue(nameof(Content), ref content, value);
        }

        private decimal? cost;
        [XafDisplayName("Chi phí")]
        public decimal? Cost
        {
            get => cost;
            set => SetPropertyValue(nameof(Cost), ref cost, value);
        }

        public override string ToString() => Date.HasValue ? Date.Value.ToString("yyyy-MM-dd") : $"BT-{Oid}";
    }
}
