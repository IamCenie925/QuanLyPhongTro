using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.DC;
using DevExpress.Xpo;
using System.ComponentModel;
using DevExpress.Persistent.Validation;

namespace PhongTro3.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Ảnh hóa đơn")]
    [DefaultProperty(nameof(ImagePath))]
    [ImageName("BO_InvoiceImage")]
    public class InvoiceImage : BaseObject
    {
        public InvoiceImage(Session session) : base(session) { }

        private Invoice invoice;
        private string imagePath;

        [Association("Invoice-InvoiceImages")]
        [XafDisplayName("Hóa đơn")]
        [RuleRequiredField(DefaultContexts.Save)]
        public Invoice Invoice
        {
            get => invoice;
            set => SetPropertyValue(nameof(Invoice), ref invoice, value);
        }
        
        private void SetPropertyValue(string v, ref Invoice invoice, Invoice value)
        {
            throw new NotImplementedException();
        }

        [Size(500)]
        [XafDisplayName("Ảnh")]
        public string ImagePath
        {
            get => imagePath;
            set => SetPropertyValue(nameof(ImagePath), ref imagePath, value);
        }

        private void SetPropertyValue(string v, ref string imagePath, string value)
        {
            throw new NotImplementedException();
        }

        public override string ToString() =>
            !string.IsNullOrWhiteSpace(ImagePath) ? ImagePath : $"IMG-{Oid}";
    }
}
