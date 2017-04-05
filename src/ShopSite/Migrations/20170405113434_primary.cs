using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ShopSite.Migrations
{
    public partial class primary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "Culture",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Culture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryDbContext",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 5000, nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryDbContext", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryDbContext_CategoryDbContext_ParentId",
                        column: x => x.ParentId,
                        principalTable: "CategoryDbContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductDbContext",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    IsAllowedToOrder = table.Column<bool>(nullable: false),
                    IsFeatured = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    ShortDescription = table.Column<string>(nullable: true),
                    StockQuantity = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDbContext", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributeCompexTypeDefinition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributeCompexTypeDefinition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttributeCompexTypeDefinition_ProductAttributeCompexTypeDefinition_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ProductAttributeCompexTypeDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttributeGroupDbContext",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeGroupDbContext", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceDbContext",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CultureId = table.Column<int>(nullable: true),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceDbContext", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceDbContext_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategory_CategoryDbContext_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryDbContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategory_ProductDbContext_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductDbContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributeDbContext",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AtributeType = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ProductAttributeCompexTypeDefinitionId = table.Column<int>(nullable: false),
                    ProductAttributeGroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeDbContext", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeDbContext_CategoryDbContext_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryDbContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttributeDbContext_ProductAttributeCompexTypeDefinition_ProductAttributeCompexTypeDefinitionId",
                        column: x => x.ProductAttributeCompexTypeDefinitionId,
                        principalTable: "ProductAttributeCompexTypeDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttributeDbContext_AttributeGroupDbContext_ProductAttributeGroupId",
                        column: x => x.ProductAttributeGroupId,
                        principalTable: "AttributeGroupDbContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributeCompexType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AtributeNameId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ValueId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributeCompexType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttributeCompexType_AttributeDbContext_AtributeNameId",
                        column: x => x.AtributeNameId,
                        principalTable: "AttributeDbContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAttributeCompexType_ProductDbContext_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductDbContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAttributeCompexType_ProductAttributeCompexTypeDefinition_ValueId",
                        column: x => x.ValueId,
                        principalTable: "ProductAttributeCompexTypeDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributeDates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AtributeNameId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Value = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributeDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttributeDates_AttributeDbContext_AtributeNameId",
                        column: x => x.AtributeNameId,
                        principalTable: "AttributeDbContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAttributeDates_ProductDbContext_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductDbContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributeDecs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AtributeNameId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributeDecs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttributeDecs_AttributeDbContext_AtributeNameId",
                        column: x => x.AtributeNameId,
                        principalTable: "AttributeDbContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAttributeDecs_ProductDbContext_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductDbContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributeInts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AtributeNameId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributeInts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttributeInts_AttributeDbContext_AtributeNameId",
                        column: x => x.AtributeNameId,
                        principalTable: "AttributeDbContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAttributeInts_ProductDbContext_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductDbContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributeStrings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AtributeNameId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributeStrings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttributeStrings_AttributeDbContext_AtributeNameId",
                        column: x => x.AtributeNameId,
                        principalTable: "AttributeDbContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAttributeStrings_ProductDbContext_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductDbContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributeValue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttributeId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributeValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttributeValue_AttributeDbContext_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "AttributeDbContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAttributeValue_ProductDbContext_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductDbContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceDbContext_CultureId",
                table: "ResourceDbContext",
                column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryDbContext_ParentId",
                table: "CategoryDbContext",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeDbContext_CategoryId",
                table: "AttributeDbContext",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeDbContext_ProductAttributeCompexTypeDefinitionId",
                table: "AttributeDbContext",
                column: "ProductAttributeCompexTypeDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeDbContext_ProductAttributeGroupId",
                table: "AttributeDbContext",
                column: "ProductAttributeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeCompexType_AtributeNameId",
                table: "ProductAttributeCompexType",
                column: "AtributeNameId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeCompexType_ProductId",
                table: "ProductAttributeCompexType",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeCompexType_ValueId",
                table: "ProductAttributeCompexType",
                column: "ValueId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeCompexTypeDefinition_ParentId",
                table: "ProductAttributeCompexTypeDefinition",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeDates_AtributeNameId",
                table: "ProductAttributeDates",
                column: "AtributeNameId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeDates_ProductId",
                table: "ProductAttributeDates",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeDecs_AtributeNameId",
                table: "ProductAttributeDecs",
                column: "AtributeNameId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeDecs_ProductId",
                table: "ProductAttributeDecs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeInts_AtributeNameId",
                table: "ProductAttributeInts",
                column: "AtributeNameId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeInts_ProductId",
                table: "ProductAttributeInts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeStrings_AtributeNameId",
                table: "ProductAttributeStrings",
                column: "AtributeNameId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeStrings_ProductId",
                table: "ProductAttributeStrings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeValue_AttributeId",
                table: "ProductAttributeValue",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeValue_ProductId",
                table: "ProductAttributeValue",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_CategoryId",
                table: "ProductCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ResourceDbContext");

            migrationBuilder.DropTable(
                name: "ProductAttributeCompexType");

            migrationBuilder.DropTable(
                name: "ProductAttributeDates");

            migrationBuilder.DropTable(
                name: "ProductAttributeDecs");

            migrationBuilder.DropTable(
                name: "ProductAttributeInts");

            migrationBuilder.DropTable(
                name: "ProductAttributeStrings");

            migrationBuilder.DropTable(
                name: "ProductAttributeValue");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Culture");

            migrationBuilder.DropTable(
                name: "AttributeDbContext");

            migrationBuilder.DropTable(
                name: "ProductDbContext");

            migrationBuilder.DropTable(
                name: "CategoryDbContext");

            migrationBuilder.DropTable(
                name: "ProductAttributeCompexTypeDefinition");

            migrationBuilder.DropTable(
                name: "AttributeGroupDbContext");
        }
    }
}
