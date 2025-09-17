using System;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.DC;
using System.ComponentModel;

namespace PhongTro3.Module.BusinessObjects;

[DefaultClassOptions]
[ImageName("BO_RoomEquipment")]
[NavigationItem("Quản lý trọ")]
[XafDisplayName("Thiết bị phòng")]
[DefaultProperty(nameof(Equipment))]
public class RoomEquipment : XPObject
{
    public RoomEquipment(Session session) : base(session) { }

    Room room;
    [Association("Room-Equipments")]
    [XafDisplayName("Phòng")]
    public Room Room
    {
        get => room;
        set => SetPropertyValue(nameof(Room), ref room, value);
    }

    Equipment equipment;
    [Association("Equipment-RoomEquipments")]
    [XafDisplayName("Thiết bị")]
    public Equipment Equipment
    {
        get => equipment;
        set => SetPropertyValue(nameof(Equipment), ref equipment, value);
    }

    DateTime? dateOfUse;
    [XafDisplayName("Ngày sử dụng")]
    public DateTime? DateOfUse
    {
        get => dateOfUse;
        set => SetPropertyValue(nameof(DateOfUse), ref dateOfUse, value);
    }

    DateTime? warrantyExpiry;
    [XafDisplayName("Hạn bảo hành")]
    public DateTime? WarrantyExpiry
    {
        get => warrantyExpiry;
        set => SetPropertyValue(nameof(WarrantyExpiry), ref warrantyExpiry, value);
    }

    string specification;
    [Size(200)]
    [XafDisplayName("Thông số")]
    public string Specification
    {
        get => specification;
        set => SetPropertyValue(nameof(Specification), ref specification, value);
    }

    string supplier;
    [Size(200)]
    [XafDisplayName("Nguồn cung cấp")]
    public string Supplier
    {
        get => supplier;
        set => SetPropertyValue(nameof(Supplier), ref supplier, value);
    }

    [Association("RoomEquipment-Maintenances")]
    public XPCollection<Maintenance> Maintenances =>
        GetCollection<Maintenance>(nameof(Maintenances));

    public override string ToString() =>
        Equipment != null && !string.IsNullOrWhiteSpace(Equipment.Name)
            ? Equipment.Name
            : $"TBP-{Oid}";
}
