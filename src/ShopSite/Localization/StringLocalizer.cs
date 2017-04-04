using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ShopSite.Localization
{
    public class StringLocalizer : IStringLocalizer
    {
        private IList<ResourceString> _resourceStrings;

        public StringLocalizer(IList<ResourceString> resourceStrings)
        {
            _resourceStrings = resourceStrings;
        }
    
        private string GetString(string name)
        {
            return _resourceStrings
                .Where(r => r.Culture == CultureInfo.CurrentCulture.Name)
                .FirstOrDefault(r => r.Key == name)?.Value;     
        }

        public LocalizedString this[string name]
        {
            get
            {
                var val = GetString(name);

                return new LocalizedString(name, val ?? name, val == null);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            throw new NotImplementedException();
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            CultureInfo.DefaultThreadCurrentCulture = culture;
            return new StringLocalizer(_resourceStrings);
        }
    }
}
