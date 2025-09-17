using System;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.DC;
using System.ComponentModel;

namespace PhongTro3.Module.BusinessObjects;

[DefaultClassOptions]
[NavigationItem("Quản lý trọ")]
[XafDisplayName("Sửa chữa")]
[DefaultProperty(nameof(Date))]
[ImageName("BO_Repair")]
public class Repair : XPObject
{
    public Repair(Session session) : base(session) { }

    Room room;
    [Association("Room-Repairs")]
    [XafDisplayName("Phòng")]
    public Room Room
    {
        get => room;
        set => SetPropertyValue(nameof(Room), ref room, value);
    }

    DateTime? date;
    [XafDisplayName("Ngày")]
    public DateTime? Date
    {
        get => date;
        set => SetPropertyValue(nameof(Date), ref date, value);
    }

    string content;
    [Size(500)]
    [XafDisplayName("Nội dung")]
    public string Content
    {
        get => content;
        set => SetPropertyValue(nameof(Content), ref content, value);
    }

    decimal? cost;
    [XafDisplayName("Chi phí")]
    public decimal? Cost
    {
        get => cost;
        set => SetPropertyValue(nameof(Cost), ref cost, value);
    }

    public override string ToString() =>
        Date.HasValue ? Date.Value.ToString("yyyy-MM-dd") : $"SC-{Oid}";
}
