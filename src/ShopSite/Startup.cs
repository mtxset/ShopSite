using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using ShopSite.Data;
using ShopSite.Data.Repository;
using ShopSite.Localization;
using ShopSite.Models;
using ShopSite.Orders.Models;
using ShopSite.Orders.Services;
using ShopSite.Orders.Services.SQL;
using ShopSite.ProductAttibutes.Services;
using ShopSite.ProductAttributes.Models;
using ShopSite.ProductAttributes.Services.SQL;
using ShopSite.ProductOptions.Models;
using ShopSite.ProductOptions.Services;
using ShopSite.Services;
using ShopSite.Services.SQL;
using System.Globalization;

namespace ShopSite
{
    public static class CustomAppBuilders
    {
        public static IApplicationBuilder UseCustomLocalization(this IApplicationBuilder app)
        {
            var cultures = new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("vi-VN"),
                new CultureInfo("fr-FR"),
                new CultureInfo("pt-BR"),
                new CultureInfo("uk-UA"),
                new CultureInfo("ru-RU")
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US", "en-US"),
                SupportedCultures = cultures,
                SupportedUICultures = cultures
            });
            return app;
        }
    }

    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var jBuilder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("Configs/config.json");

            JsonConfiguration = jBuilder.Build();

            if (env.IsDevelopment())
                ConnectionString = "database:connectionDev";
            else if (env.IsProduction())
                ConnectionString = "database:connectionPro";
        }

        public string ConnectionString { get; set; } = "database:connectionDev";
        public IConfiguration JsonConfiguration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .AddViewLocalization()
                .AddDataAnnotationsLocalization();

            services.AddEntityFramework()
                 .AddEntityFrameworkSqlServer()
                 .AddDbContext<ShopSiteDbContext>
                 (
                     opts => opts.UseSqlServer(JsonConfiguration[ConnectionString])
                 );

            services.AddIdentity<User, IdentityRole>(opts =>
            {
                opts.Password.RequireDigit = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireUppercase = false;

            }).AddEntityFrameworkStores<ShopSiteDbContext>();

            services.AddTransient<AdminRoleSeed>();

            services.AddSingleton(provider => JsonConfiguration);

            AddCustomServices(services);
            AddProductAttributeServices(services);
        }

        public void AddProductAttributeServices(IServiceCollection services)
        {
            services.AddScoped<IProductAttributeComplexTypeDefinitionsService, ProductAttributeComplexTypeDefinitionsService>();
            services.AddScoped<IRepository<ProductAttribute>, Repository<ProductAttribute>>();

            services.AddScoped<IRepository<ProductAttributeDate>, Repository<ProductAttributeDate>>();
            services.AddScoped<IRepository<ProductAttributeDec>, Repository<ProductAttributeDec>>();
            services.AddScoped<IRepository<ProductAttributeInt>, Repository<ProductAttributeInt>>();
            services.AddScoped<IRepository<ProductAttributeString>, Repository<ProductAttributeString>>();
        }

        public void AddCustomServices(IServiceCollection services)
        {
            services.AddScoped<ICategoryService, SqlCategoryService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IRepository<ProductCategory>, Repository<ProductCategory>>();

            services.AddScoped<IProductOptionService, ProductOptionService>();
            services.AddScoped<IRepository<ProductOption>, Repository<ProductOption>>();
            services.AddScoped<IRepository<ProductOptionValue>, Repository<ProductOptionValue>>();

            services.AddScoped<IResourceService, ResourceService>();
            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); // required for work context
            services.AddScoped<IWorkContext, WorkContext>();

            services.AddScoped<IRepository<Order>, Repository<Order>>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<IRepository<CartItem>, Repository<CartItem>>();
            services.AddScoped<ICartService, CartService>();

            services.AddSingleton<IStringLocalizerFactory, StringLocalizerFactory>();
        }

        public async void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            AdminRoleSeed adminSeeder)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseCustomLocalization();

            app.UseFileServer();

            app.UseIdentity();

            app.UseMvcWithDefaultRoute();

            await adminSeeder.EnsureAdminSeed();
        }
    }
}
