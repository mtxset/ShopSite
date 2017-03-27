using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ShopSite.Extensions
{
    public static class ServiceCollections
    {
        public static IServiceCollection LoadInstalledModules(
            this IServiceCollection services,
            IList<ModuleInfo> modules, IHostingEnvironment env)
        {
            var moduleRootFolder = new DirectoryInfo(Path.Combine(env.ContentRootPath, "Modules"));
            var moduleFolders = moduleRootFolder.GetDirectories();

            return services;
        }
    }
}
