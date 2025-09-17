using System;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Validation;
using System.ComponentModel;

namespace PhongTro3.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_ContractDetail")]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Chi tiết hợp đồng")]
    [DefaultProperty(nameof(Notes))]
    public class ContractDetail : BaseObject
    {
        public ContractDetail(Session session) : base(session) { }

        private Contract contract;
        private RevenueCategory revenueCategory;
        private decimal? monthlyPrice;
        private decimal? unitPriceIndex;
        private decimal? startIndex;
        private string notes;

        [Association("Contract-ContractDetails")] // khớp tên bên Contract
        [XafDisplayName("Hợp đồng")]
        [RuleRequiredField(DefaultContexts.Save)]
        public Contract Contract
        {
            get => contract;
            set => SetPropertyValue(nameof(Contract), ref contract, value);
        }

        [Association("RevenueCategory-ContractDetails")]
        [XafDisplayName("Loại thu")]
        [RuleRequiredField(DefaultContexts.Save)]
        public RevenueCategory RevenueCategory
        {
            get => revenueCategory;
            set => SetPropertyValue(nameof(RevenueCategory), ref revenueCategory, value);
        }

        [XafDisplayName("Giá theo tháng")]
        [RuleValueComparison(nameof(MonthlyPrice) + ">=0", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]
        public decimal? MonthlyPrice
        {
            get => monthlyPrice;
            set => SetPropertyValue(nameof(MonthlyPrice), ref monthlyPrice, value);
        }

        [XafDisplayName("Đơn giá chỉ số")]
        [RuleValueComparison(nameof(UnitPriceIndex) + ">=0", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]
        public decimal? UnitPriceIndex
        {
            get => unitPriceIndex;
            set => SetPropertyValue(nameof(UnitPriceIndex), ref unitPriceIndex, value);
        }

        [XafDisplayName("Chỉ số đầu")]
        [RuleValueComparison(nameof(StartIndex) + ">=0", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]
        public decimal? StartIndex
        {
            get => startIndex;
            set => SetPropertyValue(nameof(StartIndex), ref startIndex, value);
        }

        [XafDisplayName("Ghi chú")]
        [Size(500)]
        public string Notes
        {
            get => notes;
            set => SetPropertyValue(nameof(Notes), ref notes, value);
        }

        public override string ToString() => !string.IsNullOrWhiteSpace(Notes) ? Notes : $"CTHD-{Oid}";
    }
}