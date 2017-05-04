using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopSite.Migrations
{
    public partial class againchangeanameofproducttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributeCompexTypes_ProductAttributes_AtributeNameId",
                table: "ProductAttributeCompexTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributeCompexTypes_Products_ProductId",
                table: "ProductAttributeCompexTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributeCompexTypes_ProductAttributeComplexTypeDefinitions_ValueId",
                table: "ProductAttributeCompexTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAttributeCompexTypes",
                table: "ProductAttributeCompexTypes");

            migrationBuilder.RenameTable(
                name: "ProductAttributeCompexTypes",
                newName: "ProductAttributeComplexTypes");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAttributeCompexTypes_ValueId",
                table: "ProductAttributeComplexTypes",
                newName: "IX_ProductAttributeComplexTypes_ValueId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAttributeCompexTypes_ProductId",
                table: "ProductAttributeComplexTypes",
                newName: "IX_ProductAttributeComplexTypes_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAttributeCompexTypes_AtributeNameId",
                table: "ProductAttributeComplexTypes",
                newName: "IX_ProductAttributeComplexTypes_AtributeNameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAttributeComplexTypes",
                table: "ProductAttributeComplexTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributeComplexTypes_ProductAttributes_AtributeNameId",
                table: "ProductAttributeComplexTypes",
                column: "AtributeNameId",
                principalTable: "ProductAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributeComplexTypes_Products_ProductId",
                table: "ProductAttributeComplexTypes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributeComplexTypes_ProductAttributeComplexTypeDefinitions_ValueId",
                table: "ProductAttributeComplexTypes",
                column: "ValueId",
                principalTable: "ProductAttributeComplexTypeDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributeComplexTypes_ProductAttributes_AtributeNameId",
                table: "ProductAttributeComplexTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributeComplexTypes_Products_ProductId",
                table: "ProductAttributeComplexTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributeComplexTypes_ProductAttributeComplexTypeDefinitions_ValueId",
                table: "ProductAttributeComplexTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAttributeComplexTypes",
                table: "ProductAttributeComplexTypes");

            migrationBuilder.RenameTable(
                name: "ProductAttributeComplexTypes",
                newName: "ProductAttributeCompexTypes");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAttributeComplexTypes_ValueId",
                table: "ProductAttributeCompexTypes",
                newName: "IX_ProductAttributeCompexTypes_ValueId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAttributeComplexTypes_ProductId",
                table: "ProductAttributeCompexTypes",
                newName: "IX_ProductAttributeCompexTypes_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAttributeComplexTypes_AtributeNameId",
                table: "ProductAttributeCompexTypes",
                newName: "IX_ProductAttributeCompexTypes_AtributeNameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAttributeCompexTypes",
                table: "ProductAttributeCompexTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributeCompexTypes_ProductAttributes_AtributeNameId",
                table: "ProductAttributeCompexTypes",
                column: "AtributeNameId",
                principalTable: "ProductAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributeCompexTypes_Products_ProductId",
                table: "ProductAttributeCompexTypes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributeCompexTypes_ProductAttributeComplexTypeDefinitions_ValueId",
                table: "ProductAttributeCompexTypes",
                column: "ValueId",
                principalTable: "ProductAttributeComplexTypeDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
