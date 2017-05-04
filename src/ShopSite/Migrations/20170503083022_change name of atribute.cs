using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopSite.Migrations
{
    public partial class changenameofatribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributes_ProductAttributeComplexTypeDefinitions_ProductAttributeCompexTypeDefinitionId",
                table: "ProductAttributes");

            migrationBuilder.RenameColumn(
                name: "ProductAttributeCompexTypeDefinitionId",
                table: "ProductAttributes",
                newName: "ProductAttributeComplexTypeDefinitionId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAttributes_ProductAttributeCompexTypeDefinitionId",
                table: "ProductAttributes",
                newName: "IX_ProductAttributes_ProductAttributeComplexTypeDefinitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributes_ProductAttributeComplexTypeDefinitions_ProductAttributeComplexTypeDefinitionId",
                table: "ProductAttributes",
                column: "ProductAttributeComplexTypeDefinitionId",
                principalTable: "ProductAttributeComplexTypeDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributes_ProductAttributeComplexTypeDefinitions_ProductAttributeComplexTypeDefinitionId",
                table: "ProductAttributes");

            migrationBuilder.RenameColumn(
                name: "ProductAttributeComplexTypeDefinitionId",
                table: "ProductAttributes",
                newName: "ProductAttributeCompexTypeDefinitionId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAttributes_ProductAttributeComplexTypeDefinitionId",
                table: "ProductAttributes",
                newName: "IX_ProductAttributes_ProductAttributeCompexTypeDefinitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributes_ProductAttributeComplexTypeDefinitions_ProductAttributeCompexTypeDefinitionId",
                table: "ProductAttributes",
                column: "ProductAttributeCompexTypeDefinitionId",
                principalTable: "ProductAttributeComplexTypeDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
