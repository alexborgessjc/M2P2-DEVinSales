using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevInSales.Core.Data.Migrations
{
    public partial class Add_seeds_product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "SuggestedPrice" },
                values: new object[,]
                {
                    { 1, "Coca-Cola", 3.5m },
                    { 2, "cerveja Bohemia", 3.99m },
                    { 3, "Cerveja Itaipava", 3.59m },
                    { 4, "Ceveja Spaten", 3.49m },
                    { 5, "Cerveja Heineken", 5.59m },
                    { 6, "Cerveja Corona", 5.99m },
                    { 7, "Cerveja Stella", 3.19m },
                    { 8, "Cerveja Amstel", 3.49m },
                    { 9, "Cerveja Budweiser", 4.19m },
                    { 10, "Cerveja Brahma", 3.79m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Allie.Spencer@manuel.us", "Allie Spencer", "661845" },
                    { 2, new DateTime(1980, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Earnest@kari.biz", "Lemuel Witting", "800631" },
                    { 3, new DateTime(1980, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adella_Shanahan@kenneth.biz", "Kari Olson I", "661342" },
                    { 4, new DateTime(1980, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Americo.Strosin@kale.tv", "Marion Nolan DDS", "661964" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
