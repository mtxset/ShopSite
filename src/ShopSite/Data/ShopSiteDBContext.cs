﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopSite.Models;

namespace ShopSite.Data
{
    public class ShopSiteDbContext : IdentityDbContext<User>
    {
        public ShopSiteDbContext(DbContextOptions<ShopSiteDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> CategoryDbContext { get; set; }
    }
}