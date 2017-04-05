using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopSite.Migrations
{
    public partial class AttributeOther2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AtributeNameId",
                table: "ProductAttributeInts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AtributeNameId",
                table: "ProductAttributeDecs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AtributeNameId",
                table: "ProductAttributeDatas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeInts_AtributeNameId",
                table: "ProductAttributeInts",
                column: "AtributeNameId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeDecs_AtributeNameId",
                table: "ProductAttributeDecs",
                column: "AtributeNameId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeDatas_AtributeNameId",
                table: "ProductAttributeDatas",
                column: "AtributeNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributeDatas_AttributeDbContext_AtributeNameId",
                table: "ProductAttributeDatas",
                column: "AtributeNameId",
                principalTable: "AttributeDbContext",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributeDecs_AttributeDbContext_AtributeNameId",
                table: "ProductAttributeDecs",
                column: "AtributeNameId",
                principalTable: "AttributeDbContext",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributeInts_AttributeDbContext_AtributeNameId",
                table: "ProductAttributeInts",
                column: "AtributeNameId",
                principalTable: "AttributeDbContext",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributeDatas_AttributeDbContext_AtributeNameId",
                table: "ProductAttributeDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributeDecs_AttributeDbContext_AtributeNameId",
                table: "ProductAttributeDecs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributeInts_AttributeDbContext_AtributeNameId",
                table: "ProductAttributeInts");

            migrationBuilder.DropIndex(
                name: "IX_ProductAttributeInts_AtributeNameId",
                table: "ProductAttributeInts");

            migrationBuilder.DropIndex(
                name: "IX_ProductAttributeDecs_AtributeNameId",
                table: "ProductAttributeDecs");

            migrationBuilder.DropIndex(
                name: "IX_ProductAttributeDatas_AtributeNameId",
                table: "ProductAttributeDatas");

            migrationBuilder.DropColumn(
                name: "AtributeNameId",
                table: "ProductAttributeInts");

            migrationBuilder.DropColumn(
                name: "AtributeNameId",
                table: "ProductAttributeDecs");

            migrationBuilder.DropColumn(
                name: "AtributeNameId",
                table: "ProductAttributeDatas");
        }
    }
}
