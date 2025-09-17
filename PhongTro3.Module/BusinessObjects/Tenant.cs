using System;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.DC;
using System.ComponentModel;

namespace PhongTro3.Module.BusinessObjects;

[DefaultClassOptions]
[ImageName("BO_Tenant")]
[NavigationItem("Quản lý trọ")]
[XafDisplayName("Khách thuê")]
[DefaultProperty(nameof(Name))]
public class Tenant : XPObject
{
    public Tenant(Session session) : base(session) { }

    Landlord landlord;
    [Association("Landlord-Tenants")]
    [XafDisplayName("Chủ trọ")]
    public Landlord Landlord
    {
        get => landlord;
        set => SetPropertyValue(nameof(Landlord), ref landlord, value);
    }

    string name;
    [Size(200)]
    [XafDisplayName("Họ tên")]
    public string Name
    {
        get => name;
        set => SetPropertyValue(nameof(Name), ref name, value);
    }

    string phone;
    [Size(50)]
    [XafDisplayName("Điện thoại")]
    public string Phone
    {
        get => phone;
        set => SetPropertyValue(nameof(Phone), ref phone, value);
    }

    string email;
    [Size(100)]
    [XafDisplayName("Email")]
    public string Email
    {
        get => email;
        set => SetPropertyValue(nameof(Email), ref email, value);
    }

    string citizenId;
    [Size(50)]
    [XafDisplayName("Số CCCD")]
    public string CitizenId
    {
        get => citizenId;
        set => SetPropertyValue(nameof(CitizenId), ref citizenId, value);
    }

    DateTime? issuedDate;
    [XafDisplayName("Ngày cấp")]
    public DateTime? IssuedDate
    {
        get => issuedDate;
        set => SetPropertyValue(nameof(IssuedDate), ref issuedDate, value);
    }

    string frontCard;
    [Size(200)]
    [XafDisplayName("Mặt trước CCCD")]
    public string FrontCitizenCardImage
    {
        get => frontCard;
        set => SetPropertyValue(nameof(FrontCitizenCardImage), ref frontCard, value);
    }

    string backCard;
    [Size(200)]
    [XafDisplayName("Mặt sau CCCD")]
    public string BackCitizenCardImage
    {
        get => backCard;
        set => SetPropertyValue(nameof(BackCitizenCardImage), ref backCard, value);
    }

    [Association("Tenant-TemporaryResidences")]
    public XPCollection<TemporaryResidence> TemporaryResidences =>
        GetCollection<TemporaryResidence>(nameof(TemporaryResidences));

    public override string ToString() => Name;
}
