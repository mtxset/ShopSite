using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ShopSite.Models;

namespace ShopSite.Data
{
    public class ShopSiteDbContext : IdentityDbContext<User>
    {
        public ShopSiteDbContext(DbContextOptions<ShopSiteDbContext> options) : base(options)
        {
        }

        public DbSet<Category> CategoryDbContext { get; set; }
        public DbSet<Product> ProductDbContext { get; set; }

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

    }
}
