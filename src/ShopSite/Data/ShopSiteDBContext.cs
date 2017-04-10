using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopSite.Models;
using ShopSite.Localization.Models;
using ShopSite.Orders.Models;

namespace ShopSite.Data
{
    public class ShopSiteDbContext : IdentityDbContext<User>
    {
        public ShopSiteDbContext(DbContextOptions<ShopSiteDbContext> options) : base(options)
        {
        }

        public DbSet<Category> CategoryDbContext { get; set; }
        public DbSet<Product> ProductDbContext { get; set; }        
        public DbSet<Resource> ResourceDbContext { get; set; }

        public DbSet<CartItem> CartDbContext { get; set; }

        public DbSet<ProductAttribute> AttributeDbContext { get; set; }
        public DbSet<ProductAttributeString> ProductAttributeStrings { get; set; }
        public DbSet<ProductAttributeInt> ProductAttributeInts { get; set; }
        public DbSet<ProductAttributeDec> ProductAttributeDecs { get; set; }
        public DbSet<ProductAttributeDate> ProductAttributeDates { get; set; }
        public DbSet<ProductAttributeCompexType> ProductAttributeCompexType { get; set; }
        public DbSet<ProductAttributeComplexTypeDefinition> ProductAttributeComplexTypeDefinition { get; set; }
        
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
            return ProductDbContext;
        }

        public IQueryable QueryResource()
        {
            return ResourceDbContext;
        }

    }
}
