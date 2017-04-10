using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ShopSite.Migrations
{
    public partial class cartItemV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeDbContext_AttributeGroupDbContext_ProductAttributeGroupId",
                table: "AttributeDbContext");

            migrationBuilder.DropForeignKey(
                name: "FK_CartDbContext_AspNetUsers_UserId1",
                table: "CartDbContext");

            migrationBuilder.DropTable(
                name: "AttributeGroupDbContext");

            migrationBuilder.DropIndex(
                name: "IX_CartDbContext_UserId1",
                table: "CartDbContext");

            migrationBuilder.DropIndex(
                name: "IX_AttributeDbContext_ProductAttributeGroupId",
                table: "AttributeDbContext");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "CartDbContext");

            migrationBuilder.DropColumn(
                name: "ProductAttributeGroupId",
                table: "AttributeDbContext");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CartDbContext",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_CartDbContext_UserId",
                table: "CartDbContext",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartDbContext_AspNetUsers_UserId",
                table: "CartDbContext",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartDbContext_AspNetUsers_UserId",
                table: "CartDbContext");

            migrationBuilder.DropIndex(
                name: "IX_CartDbContext_UserId",
                table: "CartDbContext");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "CartDbContext",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "CartDbContext",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductAttributeGroupId",
                table: "AttributeDbContext",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_CartDbContext_UserId1",
                table: "CartDbContext",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeDbContext_ProductAttributeGroupId",
                table: "AttributeDbContext",
                column: "ProductAttributeGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeDbContext_AttributeGroupDbContext_ProductAttributeGroupId",
                table: "AttributeDbContext",
                column: "ProductAttributeGroupId",
                principalTable: "AttributeGroupDbContext",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CartDbContext_AspNetUsers_UserId1",
                table: "CartDbContext",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
