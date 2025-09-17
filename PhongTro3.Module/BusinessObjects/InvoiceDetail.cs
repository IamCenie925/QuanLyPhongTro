using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.DC;
using DevExpress.Xpo;
using DevExpress.Persistent.Validation;
using System.ComponentModel;
using PhongTro3.Module.BusinessObjects;

[DefaultClassOptions]
[NavigationItem("Quản lý trọ")]
[XafDisplayName("Chi tiết hóa đơn")]
[ImageName("BO_InvoiceDetail")]
// Rule: EndIndex phải >= StartIndex
[RuleCriteria("InvoiceDetail_EndIndex_GreaterOrEqual_StartIndex",
    DefaultContexts.Save,
    "EndIndex >= StartIndex",
    CustomMessageTemplate = "Chỉ số cuối phải >= chỉ số đầu.")]
public class InvoiceDetail : BaseObject
{
    public InvoiceDetail(Session session) : base(session) { }

    private Invoice invoice;
    private RevenueCategory revenueCategory;
    private decimal? startIndex;
    private decimal? endIndex;
    private decimal? quantity;
    private decimal? unitPrice;
    private decimal? amount;
    private string notes;

    [Association("Invoice-InvoiceDetails")]
    [XafDisplayName("Hóa đơn")]
    [RuleRequiredField(DefaultContexts.Save)]
    public Invoice Invoice
    {
        get => invoice;
        set => SetPropertyValue(nameof(Invoice), ref invoice, value);
    }

    [Association("RevenueCategory-InvoiceDetails")]
    [XafDisplayName("Loại thu")]
    [RuleRequiredField(DefaultContexts.Save)]
    public RevenueCategory RevenueCategory
    {
        get => revenueCategory;
        set => SetPropertyValue(nameof(RevenueCategory), ref revenueCategory, value);
    }

    [XafDisplayName("Chỉ số đầu")]
    [RuleValueComparison("InvoiceDetail_StartIndex_GreaterOrEqual_0", DefaultContexts.Save,
        ValueComparisonType.GreaterThanOrEqual, 0)]
    public decimal? StartIndex
    {
        get => startIndex;
        set => SetPropertyValue(nameof(StartIndex), ref startIndex, value);
    }

    [XafDisplayName("Chỉ số cuối")]
    [RuleValueComparison("InvoiceDetail_EndIndex_GreaterOrEqual_0", DefaultContexts.Save,
        ValueComparisonType.GreaterThanOrEqual, 0)]
    public decimal? EndIndex
    {
        get => endIndex;
        set => SetPropertyValue(nameof(EndIndex), ref endIndex, value);
    }

    [XafDisplayName("Số lượng")]
    public decimal? Quantity
    {
        get => quantity;
        set => SetPropertyValue(nameof(Quantity), ref quantity, value);
    }

    [XafDisplayName("Đơn giá")]
    public decimal? UnitPrice
    {
        get => unitPrice;
        set => SetPropertyValue(nameof(UnitPrice), ref unitPrice, value);
    }

    [XafDisplayName("Thành tiền")]
    public decimal? Amount
    {
        get => amount;
        set => SetPropertyValue(nameof(Amount), ref amount, value);
    }

    [Size(500)]
    [XafDisplayName("Ghi chú")]
    public string Notes
    {
        get => notes;
        set => SetPropertyValue(nameof(Notes), ref notes, value);
    }

    public override string ToString() =>
        RevenueCategory != null ? $"{RevenueCategory.Name} - {Amount:N0}" : $"CTHD-{Oid}";
}
