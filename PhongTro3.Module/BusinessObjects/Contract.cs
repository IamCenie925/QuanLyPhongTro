using System;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Validation;
using System.ComponentModel;

namespace PhongTro3.Module.BusinessObjects;

[DefaultClassOptions]
[ImageName("BO_Contract")]
[NavigationItem("Quản lý trọ")]
[XafDisplayName("Hợp đồng")]
[DefaultProperty(nameof(Number))]
public class Contract : BaseObject
{
    public Contract(Session session) : base(session) { }

    Landlord landlord;
    Room room;
    ContractTemplate contractTemplate;

    string number;
    DateTime? createdDate;
    DateTime startDate;
    DateTime? endDate;
    decimal? deposit;
    string notes;
    string status;
    DateTime? paymentFromDate;
    DateTime? paymentToDate;
    string paymentMethod;

    // 🔹 Chủ trọ
    [Association("Landlord-Contracts")]
    [XafDisplayName("Chủ trọ")]
    public Landlord Landlord
    {
        get => landlord;
        set => SetPropertyValue(nameof(Landlord), ref landlord, value);
    }

    // 🔹 Phòng
    [Association("Room-Contracts")]
    [XafDisplayName("Phòng")]
    public Room Room
    {
        get => room;
        set => SetPropertyValue(nameof(Room), ref room, value);
    }

    // 🔹 Mẫu hợp đồng
    [Association("ContractTemplate-Contracts")]
    [XafDisplayName("Mẫu hợp đồng")]
    public ContractTemplate ContractTemplate
    {
        get => contractTemplate;
        set => SetPropertyValue(nameof(ContractTemplate), ref contractTemplate, value);
    }

    // 🔹 Số hợp đồng
    [Size(50)]
    [XafDisplayName("Số hợp đồng")]
    public string Number
    {
        get => number;
        set => SetPropertyValue(nameof(Number), ref number, value);
    }

    [XafDisplayName("Ngày lập")]
    public DateTime? CreatedDate
    {
        get => createdDate;
        set => SetPropertyValue(nameof(CreatedDate), ref createdDate, value);
    }

    [XafDisplayName("Ngày bắt đầu")]
    [RuleRequiredField(DefaultContexts.Save)]
    public DateTime StartDate
    {
        get => startDate;
        set => SetPropertyValue(nameof(StartDate), ref startDate, value);
    }

    [XafDisplayName("Ngày kết thúc")]
    public DateTime? EndDate
    {
        get => endDate;
        set => SetPropertyValue(nameof(EndDate), ref endDate, value);
    }

    [XafDisplayName("Tiền cọc")]
    [RuleValueComparison(DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]
    public decimal? Deposit
    {
        get => deposit;
        set => SetPropertyValue(nameof(Deposit), ref deposit, value);
    }

    [Size(500)]
    [XafDisplayName("Ghi chú")]
    public string Notes
    {
        get => notes;
        set => SetPropertyValue(nameof(Notes), ref notes, value);
    }

    [Size(50)]
    [XafDisplayName("Trạng thái")]
    public string Status
    {
        get => status;
        set => SetPropertyValue(nameof(Status), ref status, value);
    }

    [XafDisplayName("Thanh toán từ ngày")]
    public DateTime? PaymentFromDate
    {
        get => paymentFromDate;
        set => SetPropertyValue(nameof(PaymentFromDate), ref paymentFromDate, value);
    }

    [XafDisplayName("Thanh toán đến ngày")]
    public DateTime? PaymentToDate
    {
        get => paymentToDate;
        set => SetPropertyValue(nameof(PaymentToDate), ref paymentToDate, value);
    }

    [Size(100)]
    [XafDisplayName("Hình thức thanh toán")]
    public string PaymentMethod
    {
        get => paymentMethod;
        set => SetPropertyValue(nameof(PaymentMethod), ref paymentMethod, value);
    }

    // 🔹 Quan hệ 1-n
    [Association("Contract-ContractDetails")]
    public XPCollection<ContractDetail> ContractDetails =>
        GetCollection<ContractDetail>(nameof(ContractDetails));

    [Association("Contract-Invoices")]
    public XPCollection<Invoice> Invoices =>
        GetCollection<Invoice>(nameof(Invoices));

    [Association("Contract-TemporaryResidences")]
    public XPCollection<TemporaryResidence> TemporaryResidences =>
        GetCollection<TemporaryResidence>(nameof(TemporaryResidences));

    public override string ToString() =>
        !string.IsNullOrWhiteSpace(Number) ? Number : $"HD-{Oid}";
}
