using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.DC;
using System.ComponentModel;

namespace PhongTro3.Module.BusinessObjects;

[DefaultClassOptions]
[ImageName("BO_RevenueCategory")]
[NavigationItem("Quản lý trọ")]
[XafDisplayName("Loại thu")]
[DefaultProperty(nameof(Name))]
public class RevenueCategory : XPObject
{
    public RevenueCategory(Session session) : base(session) { }

    Landlord landlord;
    [Association("Landlord-RevenueCategories")]
    [XafDisplayName("Chủ trọ")]
    public Landlord Landlord
    {
        get => landlord;
        set => SetPropertyValue(nameof(Landlord), ref landlord, value);
    }

    string name;
    [Size(200)]
    [XafDisplayName("Tên khoản thu")]
    public string Name
    {
        get => name;
        set => SetPropertyValue(nameof(Name), ref name, value);
    }

    decimal? monthlyPrice;
    [XafDisplayName("Giá theo tháng")]
    public decimal? MonthlyPrice
    {
        get => monthlyPrice;
        set => SetPropertyValue(nameof(MonthlyPrice), ref monthlyPrice, value);
    }

    decimal? unitPriceIndex;
    [XafDisplayName("Đơn giá chỉ số")]
    public decimal? UnitPriceIndex
    {
        get => unitPriceIndex;
        set => SetPropertyValue(nameof(UnitPriceIndex), ref unitPriceIndex, value);
    }

    bool isDefaultContract;
    [XafDisplayName("Mặc định hợp đồng")]
    public bool IsDefaultContract
    {
        get => isDefaultContract;
        set => SetPropertyValue(nameof(IsDefaultContract), ref isDefaultContract, value);
    }

    bool isRent;
    [XafDisplayName("Tiền nhà")]
    public bool IsRent
    {
        get => isRent;
        set => SetPropertyValue(nameof(IsRent), ref isRent, value);
    }

    [Association("RevenueCategory-InvoiceDetails")]
    public XPCollection<InvoiceDetail> InvoiceDetails =>
        GetCollection<InvoiceDetail>(nameof(InvoiceDetails));

    [Association("RevenueCategory-ContractDetails")]
    public XPCollection<ContractDetail> ContractDetails =>
        GetCollection<ContractDetail>(nameof(ContractDetails));

    public override string ToString() => Name;
}
