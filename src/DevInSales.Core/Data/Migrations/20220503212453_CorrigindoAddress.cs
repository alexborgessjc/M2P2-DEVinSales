using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevInSales.Core.Data.Migrations
{
    public partial class CorrigindoAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Addresses_AdressId",
                table: "Deliveries");

            migrationBuilder.RenameColumn(
                name: "AdressId",
                table: "Deliveries",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Deliveries_AdressId",
                table: "Deliveries",
                newName: "IX_Deliveries_AddressId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryForecast",
                table: "Deliveries",
                type: "timestamptz",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Addresses_AddressId",
                table: "Deliveries",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Addresses_AddressId",
                table: "Deliveries");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Deliveries",
                newName: "AdressId");

            migrationBuilder.RenameIndex(
                name: "IX_Deliveries_AddressId",
                table: "Deliveries",
                newName: "IX_Deliveries_AdressId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryForecast",
                table: "Deliveries",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamptz");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Addresses_AdressId",
                table: "Deliveries",
                column: "AdressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }
    }
}
