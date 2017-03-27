using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ShopSite.Data;

namespace ShopSite.Migrations
{
    [DbContext(typeof(ShopSiteDbContext))]
    [Migration("20170320131526_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShopSite.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(5000);

                    b.Property<string>("Name");

                    b.Property<int?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("CategoryDbContext");
                });

            modelBuilder.Entity("ShopSite.Models.Category", b =>
                {
                    b.HasOne("ShopSite.Models.Category", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });
        }
    }
}
