using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopSite.Models;
using ShopSite.Localization.Models;
using ShopSite.Orders.Models;
using ShopSite.ProductAttributes.Models;
using ShopSite.ProductOptions.Models;

namespace ShopSite.Data
{
    public class ShopSiteDbContext : IdentityDbContext
    {
        public ShopSiteDbContext(DbContextOptions<ShopSiteDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }        
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<ProductOption> ProductOptions { get; set; } 
        public DbSet<ProductOptionValue> ProductOptionValues { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<ProductAttributeString> ProductAttributeStrings { get; set; }
        public DbSet<ProductAttributeInt> ProductAttributeInts { get; set; }
        public DbSet<ProductAttributeDec> ProductAttributeDecs { get; set; }
        public DbSet<ProductAttributeDate> ProductAttributeDates { get; set; }
        public DbSet<ProductAttributeCompexType> ProductAttributeComplexTypes { get; set; }
        public DbSet<ProductAttributeComplexTypeDefinition> ProductAttributeComplexTypeDefinitions { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductCategory>()
                .HasKey(x => new {x.ProductId, x.CategoryId});
            
            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.Categories)
                .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(t => t.Products)
                .HasForeignKey(pc => pc.CategoryId);
        }
        
        public IQueryable QueryProduct()
        {
            return Products;
        }

        public IQueryable QueryResource()
        {
            return Resources;
        }

    }
}
