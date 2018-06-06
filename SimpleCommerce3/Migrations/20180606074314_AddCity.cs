using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimpleCommerce3.Migrations
{
    public partial class AddCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BillingCity",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShipingCity",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillingCity",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ShipingCity",
                table: "Customers");
        }
    }
}
