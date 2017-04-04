using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using ShopSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopSite.Localization
{
    public class StringLocalizerFactory : IStringLocalizerFactory
    {
        private IResourceService _resourceService;
        private IList<ResourceString> _resourceStrings;

        public StringLocalizerFactory(IResourceService resourceService)
        {
            _resourceService = resourceService;
            LoadResources();
        }

        public IStringLocalizer Create(Type resourceSource)
        {
            return new StringLocalizer(_resourceStrings);
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            return new StringLocalizer(_resourceStrings);
        }

        private void LoadResources()
        {
            _resourceStrings = _resourceService.Query().Include(x => x.Culture).Select(x => new ResourceString
            {
                Culture = x.Culture.Name,
                Key = x.Key,
                Value = x.Value
            }).ToList();
        }
    }
}
