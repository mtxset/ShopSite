using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ShopSite.Migrations
{
    public partial class ChangeModelName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeDbContext_ProductAttributeCompexTypeDefinition_ProductAttributeCompexTypeDefinitionId",
                table: "AttributeDbContext");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributeCompexType_ProductAttributeCompexTypeDefinition_ValueId",
                table: "ProductAttributeCompexType");

            migrationBuilder.DropTable(
                name: "ProductAttributeCompexTypeDefinition");

            migrationBuilder.CreateTable(
                name: "ProductAttributeComplexTypeDefinition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributeComplexTypeDefinition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttributeComplexTypeDefinition_ProductAttributeComplexTypeDefinition_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ProductAttributeComplexTypeDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeComplexTypeDefinition_ParentId",
                table: "ProductAttributeComplexTypeDefinition",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeDbContext_ProductAttributeComplexTypeDefinition_ProductAttributeCompexTypeDefinitionId",
                table: "AttributeDbContext",
                column: "ProductAttributeCompexTypeDefinitionId",
                principalTable: "ProductAttributeComplexTypeDefinition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributeCompexType_ProductAttributeComplexTypeDefinition_ValueId",
                table: "ProductAttributeCompexType",
                column: "ValueId",
                principalTable: "ProductAttributeComplexTypeDefinition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeDbContext_ProductAttributeComplexTypeDefinition_ProductAttributeCompexTypeDefinitionId",
                table: "AttributeDbContext");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributeCompexType_ProductAttributeComplexTypeDefinition_ValueId",
                table: "ProductAttributeCompexType");

            migrationBuilder.DropTable(
                name: "ProductAttributeComplexTypeDefinition");

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeCompexTypeDefinition_ParentId",
                table: "ProductAttributeCompexTypeDefinition",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeDbContext_ProductAttributeCompexTypeDefinition_ProductAttributeCompexTypeDefinitionId",
                table: "AttributeDbContext",
                column: "ProductAttributeCompexTypeDefinitionId",
                principalTable: "ProductAttributeCompexTypeDefinition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributeCompexType_ProductAttributeCompexTypeDefinition_ValueId",
                table: "ProductAttributeCompexType",
                column: "ValueId",
                principalTable: "ProductAttributeCompexTypeDefinition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
