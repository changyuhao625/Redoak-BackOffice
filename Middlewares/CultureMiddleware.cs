using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Builder;

namespace Redoak.Backoffice.Middlewares
{
    public class CultureMiddleware
    {
        private static readonly List<CultureInfo> _supportedCultures = new List<CultureInfo>()
        {
            new CultureInfo("en-US"),
            new CultureInfo("zh-TW")
        };

        private static readonly RequestLocalizationOptions _localizationOptions = new RequestLocalizationOptions()
        {
            DefaultRequestCulture = new RequestCulture(_supportedCultures.First()),
            SupportedCultures = _supportedCultures,
            SupportedUICultures = _supportedCultures,
            RequestCultureProviders = new List<IRequestCultureProvider>()
            {
                new QueryStringRequestCultureProvider(),
                new CookieRequestCultureProvider()
            }
        };

        public void Configure(IApplicationBuilder app)
        {
            app.UseRequestLocalization(_localizationOptions);
        }
    }
}
