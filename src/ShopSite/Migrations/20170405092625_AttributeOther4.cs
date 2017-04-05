using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ShopSite.Migrations
{
    public partial class AttributeOther4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributeDatas_AttributeDbContext_AtributeNameId",
                table: "ProductAttributeDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributeDatas_ProductDbContext_ProductId",
                table: "ProductAttributeDatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAttributeDatas",
                table: "ProductAttributeDatas");

            migrationBuilder.DropColumn(
                name: "AtributeType",
                table: "AttributeDbContext");

            migrationBuilder.RenameTable(
                name: "ProductAttributeDatas",
                newName: "ProductAttributeData");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAttributeDatas_ProductId",
                table: "ProductAttributeData",
                newName: "IX_ProductAttributeData_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAttributeDatas_AtributeNameId",
                table: "ProductAttributeData",
                newName: "IX_ProductAttributeData_AtributeNameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAttributeData",
                table: "ProductAttributeData",
                column: "Id");

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
                name: "ProductAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AtributeType = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ProductAttributeCompexTypeDefinitionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttributes_CategoryDbContext_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryDbContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAttributes_ProductAttributeCompexTypeDefinition_ProductAttributeCompexTypeDefinitionId",
                        column: x => x.ProductAttributeCompexTypeDefinitionId,
                        principalTable: "ProductAttributeCompexTypeDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributes_CategoryId",
                table: "ProductAttributes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributes_ProductAttributeCompexTypeDefinitionId",
                table: "ProductAttributes",
                column: "ProductAttributeCompexTypeDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeCompexTypeDefinition_ParentId",
                table: "ProductAttributeCompexTypeDefinition",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributeData_AttributeDbContext_AtributeNameId",
                table: "ProductAttributeData",
                column: "AtributeNameId",
                principalTable: "AttributeDbContext",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributeData_ProductDbContext_ProductId",
                table: "ProductAttributeData",
                column: "ProductId",
                principalTable: "ProductDbContext",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributeData_AttributeDbContext_AtributeNameId",
                table: "ProductAttributeData");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributeData_ProductDbContext_ProductId",
                table: "ProductAttributeData");

            migrationBuilder.DropTable(
                name: "ProductAttributes");

            migrationBuilder.DropTable(
                name: "ProductAttributeCompexTypeDefinition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAttributeData",
                table: "ProductAttributeData");

            migrationBuilder.RenameTable(
                name: "ProductAttributeData",
                newName: "ProductAttributeDatas");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAttributeData_ProductId",
                table: "ProductAttributeDatas",
                newName: "IX_ProductAttributeDatas_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAttributeData_AtributeNameId",
                table: "ProductAttributeDatas",
                newName: "IX_ProductAttributeDatas_AtributeNameId");

            migrationBuilder.AddColumn<int>(
                name: "AtributeType",
                table: "AttributeDbContext",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAttributeDatas",
                table: "ProductAttributeDatas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributeDatas_AttributeDbContext_AtributeNameId",
                table: "ProductAttributeDatas",
                column: "AtributeNameId",
                principalTable: "AttributeDbContext",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributeDatas_ProductDbContext_ProductId",
                table: "ProductAttributeDatas",
                column: "ProductId",
                principalTable: "ProductDbContext",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
