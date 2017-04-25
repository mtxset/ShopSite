using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopSite.Migrations
{
    public partial class OptionValueForOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OptionValue",
                table: "OrderItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OptionValue",
                table: "CartItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OptionValue",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "OptionValue",
                table: "CartItems");
        }
    }
}
