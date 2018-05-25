using System.Reflection;
using Microsoft.Extensions.Localization;

namespace Redoak.Backoffice
{
    public class LocalizeService
    {
        private readonly IStringLocalizer _localizer;

        public LocalizeService(IStringLocalizerFactory factory)
        {
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            //_localizer = factory.Create("SharedResource", assemblyName.Name);
            _localizer = factory.Create(type);

        }

        public LocalizedString GetLocalizedHtmlString(string key)
        {
            return _localizer[key];
        }


        public string this[string key] => _localizer[key];
    }
}
