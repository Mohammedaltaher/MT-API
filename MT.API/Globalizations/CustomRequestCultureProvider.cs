using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System.Linq;
using System.Threading.Tasks;

namespace  AggriPortal.API.Globalizations
{
    public class MyCustomRequestCultureProvider : RequestCultureProvider
    {
        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            var userLangs = httpContext.Request.Headers["Content-Language"].ToString();
            var firstLang = userLangs.Split(',').FirstOrDefault();
            var defaultLang = string.IsNullOrEmpty(firstLang) ? "en" : firstLang;
            return Task.FromResult(new ProviderCultureResult(defaultLang, defaultLang));
        }
    }
}
