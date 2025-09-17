using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.DC;
using DevExpress.Xpo;
using System.ComponentModel;

namespace PhongTro3.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Quản lý trọ")]
    [XafDisplayName("Nhật ký")]
    [DefaultProperty(nameof(Date))]
    [ImageName("BO_Diary")]
    public class Diary : BaseObject
    {
        public Diary(Session session) : base(session) { }

        private Landlord landlord;
        private TemporaryResidence temporaryResidence;
        private DateTime? date;
        private string content;
        private string imagePath;

        [Association("Landlord-Diaries")]
        [XafDisplayName("Chủ trọ")]
        public Landlord Landlord
        {
            get => landlord;
            set => SetPropertyValue(nameof(Landlord), ref landlord, value);
        }

        [Association("TemporaryResidence-Diaries")]
        [XafDisplayName("Tạm trú")]
        public TemporaryResidence TemporaryResidence
        {
            get => temporaryResidence;
            set => SetPropertyValue(nameof(TemporaryResidence), ref temporaryResidence, value);
        }

        [XafDisplayName("Ngày")]
        public DateTime? Date
        {
            get => date;
            set => SetPropertyValue(nameof(Date), ref date, value);
        }

        [XafDisplayName("Nội dung")]
        [Size(500)]
        public string Content
        {
            get => content;
            set => SetPropertyValue(nameof(Content), ref content, value);
        }

        [XafDisplayName("Ảnh")]
        [Size(200)]
        public string ImagePath
        {
            get => imagePath;
            set => SetPropertyValue(nameof(ImagePath), ref imagePath, value);
        }

        public override string ToString() =>
            Date.HasValue ? Date.Value.ToString("yyyy-MM-dd") : $"NK-{Oid}";
    }
}
