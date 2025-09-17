using System;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.DC;
using System.ComponentModel;

namespace PhongTro3.Module.BusinessObjects;

[DefaultClassOptions]
[ImageName("BO_Receipt")]
[NavigationItem("Quản lý trọ")]
[XafDisplayName("Phiếu thu")]
[DefaultProperty(nameof(Number))]
public class Receipt : XPObject
{
    public Receipt(Session session) : base(session) { }

    Landlord landlord;
    [Association("Landlord-Receipts")]
    [XafDisplayName("Chủ trọ")]
    public Landlord Landlord
    {
        get => landlord;
        set => SetPropertyValue(nameof(Landlord), ref landlord, value);
    }

    Invoice invoice;
    [Association("Invoice-Receipts")]
    [XafDisplayName("Hóa đơn")]
    public Invoice Invoice
    {
        get => invoice;
        set => SetPropertyValue(nameof(Invoice), ref invoice, value);
    }

    TemporaryResidence temporaryResidence;
    [Association("TemporaryResidence-Receipts")]
    [XafDisplayName("Tạm trú")]
    public TemporaryResidence TemporaryResidence
    {
        get => temporaryResidence;
        set => SetPropertyValue(nameof(TemporaryResidence), ref temporaryResidence, value);
    }

    string number;
    [Size(50)]
    [XafDisplayName("Số")]
    public string Number
    {
        get => number;
        set => SetPropertyValue(nameof(Number), ref number, value);
    }

    DateTime? date;
    [XafDisplayName("Ngày")]
    public DateTime? Date
    {
        get => date;
        set => SetPropertyValue(nameof(Date), ref date, value);
    }

    decimal? amount;
    [XafDisplayName("Số tiền")]
    public decimal? Amount
    {
        get => amount;
        set => SetPropertyValue(nameof(Amount), ref amount, value);
    }

    string content;
    [Size(500)]
    [XafDisplayName("Nội dung")]
    public string Content
    {
        get => content;
        set => SetPropertyValue(nameof(Content), ref content, value);
    }

    string paymentImage;
    [Size(200)]
    [XafDisplayName("Ảnh thanh toán")]
    public string PaymentImage
    {
        get => paymentImage;
        set => SetPropertyValue(nameof(PaymentImage), ref paymentImage, value);
    }

    public override string ToString() =>
        !string.IsNullOrWhiteSpace(Number) ? Number : $"PT-{Oid}";
}
