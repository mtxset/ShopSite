using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ShopSite.Data;
using ShopSite.Models;

namespace ShopSite.Migrations
{
    [DbContext(typeof(ShopSiteDbContext))]
    [Migration("20170405113434_primary")]
    partial class primary
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ShopSite.Localization.Models.Culture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Culture");
                });

            modelBuilder.Entity("ShopSite.Localization.Models.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CultureId");

                    b.Property<string>("Key");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CultureId");

                    b.ToTable("ResourceDbContext");
                });

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

            modelBuilder.Entity("ShopSite.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<bool>("IsAllowedToOrder");

                    b.Property<bool>("IsFeatured");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.Property<string>("ShortDescription");

                    b.Property<int?>("StockQuantity");

                    b.HasKey("Id");

                    b.ToTable("ProductDbContext");
                });

            modelBuilder.Entity("ShopSite.Models.ProductAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AtributeType");

                    b.Property<int>("CategoryId");

                    b.Property<string>("Name");

                    b.Property<int>("ProductAttributeCompexTypeDefinitionId");

                    b.Property<int?>("ProductAttributeGroupId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductAttributeCompexTypeDefinitionId");

                    b.HasIndex("ProductAttributeGroupId");

                    b.ToTable("AttributeDbContext");
                });

            modelBuilder.Entity("ShopSite.Models.ProductAttributeCompexType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AtributeNameId");

                    b.Property<int>("ProductId");

                    b.Property<int?>("ValueId");

                    b.HasKey("Id");

                    b.HasIndex("AtributeNameId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ValueId");

                    b.ToTable("ProductAttributeCompexType");
                });

            modelBuilder.Entity("ShopSite.Models.ProductAttributeCompexTypeDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("ProductAttributeCompexTypeDefinition");
                });

            modelBuilder.Entity("ShopSite.Models.ProductAttributeDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AtributeNameId");

                    b.Property<int>("ProductId");

                    b.Property<DateTime>("Value");

                    b.HasKey("Id");

                    b.HasIndex("AtributeNameId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductAttributeDates");
                });

            modelBuilder.Entity("ShopSite.Models.ProductAttributeDec", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AtributeNameId");

                    b.Property<int>("ProductId");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("AtributeNameId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductAttributeDecs");
                });

            modelBuilder.Entity("ShopSite.Models.ProductAttributeGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("AttributeGroupDbContext");
                });

            modelBuilder.Entity("ShopSite.Models.ProductAttributeInt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AtributeNameId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.HasIndex("AtributeNameId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductAttributeInts");
                });

            modelBuilder.Entity("ShopSite.Models.ProductAttributeString", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AtributeNameId");

                    b.Property<int>("ProductId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("AtributeNameId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductAttributeStrings");
                });

            modelBuilder.Entity("ShopSite.Models.ProductAttributeValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AttributeId");

                    b.Property<int>("ProductId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("AttributeId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductAttributeValue");
                });

            modelBuilder.Entity("ShopSite.Models.ProductCategory", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("CategoryId");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("ShopSite.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ShopSite.Models.User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ShopSite.Models.User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShopSite.Models.User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShopSite.Localization.Models.Resource", b =>
                {
                    b.HasOne("ShopSite.Localization.Models.Culture", "Culture")
                        .WithMany("Resources")
                        .HasForeignKey("CultureId");
                });

            modelBuilder.Entity("ShopSite.Models.Category", b =>
                {
                    b.HasOne("ShopSite.Models.Category", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("ShopSite.Models.ProductAttribute", b =>
                {
                    b.HasOne("ShopSite.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShopSite.Models.ProductAttributeCompexTypeDefinition", "ProductAttributeCompexTypeDefinition")
                        .WithMany()
                        .HasForeignKey("ProductAttributeCompexTypeDefinitionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShopSite.Models.ProductAttributeGroup")
                        .WithMany("Attributes")
                        .HasForeignKey("ProductAttributeGroupId");
                });

            modelBuilder.Entity("ShopSite.Models.ProductAttributeCompexType", b =>
                {
                    b.HasOne("ShopSite.Models.ProductAttribute", "AtributeName")
                        .WithMany()
                        .HasForeignKey("AtributeNameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShopSite.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShopSite.Models.ProductAttributeCompexTypeDefinition", "Value")
                        .WithMany()
                        .HasForeignKey("ValueId");
                });

            modelBuilder.Entity("ShopSite.Models.ProductAttributeCompexTypeDefinition", b =>
                {
                    b.HasOne("ShopSite.Models.ProductAttributeCompexTypeDefinition", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("ShopSite.Models.ProductAttributeDate", b =>
                {
                    b.HasOne("ShopSite.Models.ProductAttribute", "AtributeName")
                        .WithMany()
                        .HasForeignKey("AtributeNameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShopSite.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShopSite.Models.ProductAttributeDec", b =>
                {
                    b.HasOne("ShopSite.Models.ProductAttribute", "AtributeName")
                        .WithMany()
                        .HasForeignKey("AtributeNameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShopSite.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShopSite.Models.ProductAttributeInt", b =>
                {
                    b.HasOne("ShopSite.Models.ProductAttribute", "AtributeName")
                        .WithMany()
                        .HasForeignKey("AtributeNameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShopSite.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShopSite.Models.ProductAttributeString", b =>
                {
                    b.HasOne("ShopSite.Models.ProductAttribute", "AtributeName")
                        .WithMany()
                        .HasForeignKey("AtributeNameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShopSite.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShopSite.Models.ProductAttributeValue", b =>
                {
                    b.HasOne("ShopSite.Models.ProductAttribute", "Attribute")
                        .WithMany()
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShopSite.Models.Product", "Product")
                        .WithMany("AttributeValues")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShopSite.Models.ProductCategory", b =>
                {
                    b.HasOne("ShopSite.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShopSite.Models.Product", "Product")
                        .WithMany("Categories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
