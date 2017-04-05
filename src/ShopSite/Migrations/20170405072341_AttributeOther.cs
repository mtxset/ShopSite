using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ShopSite.Migrations
{
    public partial class AttributeOther : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductAttributeDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(nullable: false),
                    Value = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributeDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttributeDatas_ProductDbContext_ProductId",
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
                    ProductId = table.Column<int>(nullable: false),
                    Value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributeDecs", x => x.Id);
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
                    ProductId = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributeInts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttributeInts_ProductDbContext_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductDbContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeDatas_ProductId",
                table: "ProductAttributeDatas",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeDecs_ProductId",
                table: "ProductAttributeDecs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeInts_ProductId",
                table: "ProductAttributeInts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductAttributeDatas");

            migrationBuilder.DropTable(
                name: "ProductAttributeDecs");

            migrationBuilder.DropTable(
                name: "ProductAttributeInts");
        }
    }
}
