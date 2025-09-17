using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace PhongTro3.Blazor.Server.Services 
{
    public class CookieService
    {
        private readonly IJSRuntime _js;

        public CookieService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task SetCookie(string name, string value, int days)
        {
            await _js.InvokeVoidAsync("setCookie", name, value, days);
        }

        public async Task<string> GetCookie(string name)
        {
            return await _js.InvokeAsync<string>("getCookie", name);
        }
    }
}
