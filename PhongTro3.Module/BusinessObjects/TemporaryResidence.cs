using System;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.DC;
using System.ComponentModel;

namespace PhongTro3.Module.BusinessObjects;

[DefaultClassOptions]
[ImageName("BO_TemporaryResidence")]
[NavigationItem("Quản lý trọ")]
[XafDisplayName("Tạm trú")]
[DefaultProperty(nameof(Notes))]
public class TemporaryResidence : XPObject
{
    public TemporaryResidence(Session session) : base(session) { }

    Contract contract;
    [Association("Contract-TemporaryResidences")]
    [XafDisplayName("Hợp đồng")]
    public Contract Contract
    {
        get => contract;
        set => SetPropertyValue(nameof(Contract), ref contract, value);
    }

    Tenant tenant;
    [Association("Tenant-TemporaryResidences")]
    [XafDisplayName("Khách")]
    public Tenant Tenant
    {
        get => tenant;
        set => SetPropertyValue(nameof(Tenant), ref tenant, value);
    }

    DateTime? startDate;
    [XafDisplayName("Ngày đầu")]
    public DateTime? StartDate
    {
        get => startDate;
        set => SetPropertyValue(nameof(StartDate), ref startDate, value);
    }

    DateTime? endDate;
    [XafDisplayName("Ngày kết thúc")]
    public DateTime? EndDate
    {
        get => endDate;
        set => SetPropertyValue(nameof(EndDate), ref endDate, value);
    }

    string notes;
    [Size(500)]
    [XafDisplayName("Ghi chú")]
    public string Notes
    {
        get => notes;
        set => SetPropertyValue(nameof(Notes), ref notes, value);
    }

    [Association("TemporaryResidence-Diaries")]
    public XPCollection<Diary> Diaries =>
        GetCollection<Diary>(nameof(Diaries));

    [Association("TemporaryResidence-Receipts")]
    public XPCollection<Receipt> Receipts =>
        GetCollection<Receipt>(nameof(Receipts));

    [Association("TemporaryResidence-ExpenseReceipts")]
    public XPCollection<ExpenseReceipt> ExpenseReceipts =>
        GetCollection<ExpenseReceipt>(nameof(ExpenseReceipts));

    public override string ToString() =>
        !string.IsNullOrWhiteSpace(Notes) ? Notes : $"TT-{Oid}";
}
