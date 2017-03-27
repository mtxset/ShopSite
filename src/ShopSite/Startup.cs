using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ShopSite.Data;
using ShopSite.Models;
using ShopSite.Services;

namespace ShopSite
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var jBuilder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("Configs/config.json");

            JsonConfiguration = jBuilder.Build();
        }

        public IConfiguration JsonConfiguration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            
            services.AddEntityFramework()
                .AddEntityFrameworkSqlServer()
                .AddDbContext<ShopSiteDbContext>
                (
                    opts => opts.UseSqlServer(JsonConfiguration["database:connection"])
                );


            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ShopSiteDbContext>();

            services.AddSingleton(provider => JsonConfiguration);

            services.AddScoped<ICategoryService, SqlCategoryService>();
            //services.AddScoped<ICategoryService, CategoryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseFileServer();

            app.UseIdentity();

            app.UseMvcWithDefaultRoute();
        }
    }
}
