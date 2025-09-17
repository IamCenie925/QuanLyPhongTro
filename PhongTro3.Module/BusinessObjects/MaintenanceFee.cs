using System;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.DC;
using System.ComponentModel;

namespace PhongTro3.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Phí duy trì")]
    [DefaultProperty(nameof(Date))]
    [ImageName("BO_MaintenanceFee")]
    public class MaintenanceFee : XPObject
    {
        public MaintenanceFee(Session session) : base(session) { }

        private Landlord landlord;
        [Association("Landlord-MaintenanceFees")]
        [XafDisplayName("Chủ trọ")]
        public Landlord Landlord
        {
            get => landlord;
            set => SetPropertyValue(nameof(Landlord), ref landlord, value);
        }

        private DateTime? date;
        [XafDisplayName("Ngày")]
        public DateTime? Date
        {
            get => date;
            set => SetPropertyValue(nameof(Date), ref date, value);
        }

        private decimal? amount;
        [XafDisplayName("Số tiền")]
        public decimal? Amount
        {
            get => amount;
            set => SetPropertyValue(nameof(Amount), ref amount, value);
        }

        private string content;
        [Size(500)]
        [XafDisplayName("Nội dung")]
        public string Content
        {
            get => content;
            set => SetPropertyValue(nameof(Content), ref content, value);
        }

        private string paymentImage;
        [Size(200)]
        [XafDisplayName("Ảnh thanh toán")]
        public string PaymentImage
        {
            get => paymentImage;
            set => SetPropertyValue(nameof(PaymentImage), ref paymentImage, value);
        }

        public override string ToString() => Date.HasValue ? Date.Value.ToString("yyyy-MM-dd") : $"PF-{Oid}";
    }
}
