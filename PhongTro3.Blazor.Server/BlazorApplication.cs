using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ApplicationBuilder;
using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.ClientServer;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Xpo;
using Microsoft.JSInterop;
using PhongTro3.Blazor.Server.Services;


namespace PhongTro3.Blazor.Server;
/// <summary>
/// class CustomCookieStorage mới thêm vào để lưu trữ các tùy chọn của người dùng trong cookie.(Thầy chỉ)
/// </summary>
public class CustomCookieStorage : SettingsStorage
{
    readonly IServiceProvider serviceProvider;
    readonly IHttpContextAccessor httpCont;
    public CustomCookieStorage(IServiceProvider _serviceProvider)
    {
        serviceProvider = _serviceProvider;
        jsRuntime = (IJSRuntime)serviceProvider.GetService(typeof(IJSRuntime));
        httpCont = (IHttpContextAccessor)serviceProvider.GetService(typeof(IHttpContextAccessor));
    }
    IJSRuntime jsRuntime;
    public override string LoadOption(string optionPath, string optionName)
    {
        if (httpCont != null)
        {
            var val = httpCont.HttpContext.Request.Cookies[optionName];
            return val;
        }
        return null;
    }
    public override void SaveOption(string optionPath, string optionName, string optionValue)
    {
        Task.Run(async () => await jsRuntime.InvokeAsync<object>("blazorExtensions.WriteCookie", new object[] { optionName, optionValue, 30 }));
    }
}

public class PhongTro3BlazorApplication : BlazorApplication {
    public PhongTro3BlazorApplication() {
        ApplicationName = "PhongTro3";
        CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.DatabaseSchema;
        DatabaseVersionMismatch += PhongTro3BlazorApplication_DatabaseVersionMismatch;
    }
    protected override void OnSetupStarted() {
        base.OnSetupStarted();
#if DEBUG
        if(System.Diagnostics.Debugger.IsAttached && CheckCompatibilityType == CheckCompatibilityType.DatabaseSchema) {
            DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways;
        }
#endif
    }
    private void PhongTro3BlazorApplication_DatabaseVersionMismatch(object sender, DatabaseVersionMismatchEventArgs e) {
#if EASYTEST
        e.Updater.Update();
        e.Handled = true;
#else
        if(System.Diagnostics.Debugger.IsAttached) {
            e.Updater.Update();
            e.Handled = true;
        }
        else {
            string message = "The application cannot connect to the specified database, " +
                "because the database doesn't exist, its version is older " +
                "than that of the application or its schema does not match " +
                "the ORM data model structure. To avoid this error, use one " +
                "of the solutions from the https://www.devexpress.com/kb=T367835 KB Article.";

            if(e.CompatibilityError != null && e.CompatibilityError.Exception != null) {
                message += "\r\n\r\nInner exception: " + e.CompatibilityError.Exception.Message;
            }
            throw new InvalidOperationException(message);
        }
#endif
    }
}
