using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopSite.Migrations
{
    public partial class AttributeOther1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AtributeNameId",
                table: "ProductAttributeStrings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeStrings_AtributeNameId",
                table: "ProductAttributeStrings",
                column: "AtributeNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributeStrings_AttributeDbContext_AtributeNameId",
                table: "ProductAttributeStrings",
                column: "AtributeNameId",
                principalTable: "AttributeDbContext",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributeStrings_AttributeDbContext_AtributeNameId",
                table: "ProductAttributeStrings");

            migrationBuilder.DropIndex(
                name: "IX_ProductAttributeStrings_AtributeNameId",
                table: "ProductAttributeStrings");

            migrationBuilder.DropColumn(
                name: "AtributeNameId",
                table: "ProductAttributeStrings");
        }
    }
}
