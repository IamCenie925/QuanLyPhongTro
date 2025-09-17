using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.DC;
using System.ComponentModel;

namespace PhongTro3.Module.BusinessObjects;

[DefaultClassOptions]
[ImageName("BO_Room")]
[NavigationItem("Quản lý trọ")]
[XafDisplayName("Phòng")]
[DefaultProperty(nameof(RoomNumber))]
public class Room : XPObject {
    public Room(Session session) : base(session) { }

    Landlord landlord;
    [Association("Landlord-Rooms")]
    [XafDisplayName("Chủ trọ")]
    public Landlord Landlord {
        get => landlord;
        set => SetPropertyValue(nameof(Landlord), ref landlord, value);
    }

    string roomNumber;
    [Size(50)]
    [XafDisplayName("Số phòng")]
    public string RoomNumber {
        get => roomNumber;
        set => SetPropertyValue(nameof(RoomNumber), ref roomNumber, value);
    }

    decimal? deposit;
    [XafDisplayName("Tiền cọc")]
    public decimal? Deposit {
        get => deposit;
        set => SetPropertyValue(nameof(Deposit), ref deposit, value);
    }

    [Association("Room-Equipments")]
    public XPCollection<RoomEquipment> RoomEquipments =>
        GetCollection<RoomEquipment>(nameof(RoomEquipments));

    [Association("Room-Contracts")]
    public XPCollection<Contract> Contracts =>
        GetCollection<Contract>(nameof(Contracts));

    [Association("Room-Repairs")]
    public XPCollection<Repair> Repairs =>
        GetCollection<Repair>(nameof(Repairs));

    public override string ToString() => RoomNumber;
}
