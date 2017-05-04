using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopSite.Migrations
{
    public partial class nullableproductAttr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributes_ProductAttributeComplexTypeDefinitions_ProductAttributeComplexTypeDefinitionId",
                table: "ProductAttributes");

            migrationBuilder.AlterColumn<int>(
                name: "ProductAttributeComplexTypeDefinitionId",
                table: "ProductAttributes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributes_ProductAttributeComplexTypeDefinitions_ProductAttributeComplexTypeDefinitionId",
                table: "ProductAttributes",
                column: "ProductAttributeComplexTypeDefinitionId",
                principalTable: "ProductAttributeComplexTypeDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributes_ProductAttributeComplexTypeDefinitions_ProductAttributeComplexTypeDefinitionId",
                table: "ProductAttributes");

            migrationBuilder.AlterColumn<int>(
                name: "ProductAttributeComplexTypeDefinitionId",
                table: "ProductAttributes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributes_ProductAttributeComplexTypeDefinitions_ProductAttributeComplexTypeDefinitionId",
                table: "ProductAttributes",
                column: "ProductAttributeComplexTypeDefinitionId",
                principalTable: "ProductAttributeComplexTypeDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
