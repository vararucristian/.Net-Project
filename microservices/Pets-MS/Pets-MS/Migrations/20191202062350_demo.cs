using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pets_MS.Migrations
{
    public partial class demo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("cdd30589-12f7-441a-88c5-7dc669fcc1ae"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("ec6c733e-0d3e-44eb-91a0-40bc3e4edcf1"));

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "City", "Country", "Number", "Street" },
                values: new object[] { new Guid("a4c6e27a-57b8-4715-8073-7cb75ec185c0"), "Iasi", "Romania", "1", "Street" });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "Description", "Genre", "LocationId", "Name", "Species", "Username" },
                values: new object[] { new Guid("ee9a1c4b-8bec-4816-b9f1-730aeeac48a1"), "my dog is happy", "male", new Guid("a4c6e27a-57b8-4715-8073-7cb75ec185c0"), "Otto", "dog", "Cristian" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("ee9a1c4b-8bec-4816-b9f1-730aeeac48a1"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("a4c6e27a-57b8-4715-8073-7cb75ec185c0"));

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "City", "Country", "Number", "Street" },
                values: new object[] { new Guid("ec6c733e-0d3e-44eb-91a0-40bc3e4edcf1"), "Iasi", "Romania", "1", "Street" });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "Description", "Genre", "LocationId", "Name", "Species", "Username" },
                values: new object[] { new Guid("cdd30589-12f7-441a-88c5-7dc669fcc1ae"), "my dog is happy", "male", new Guid("ec6c733e-0d3e-44eb-91a0-40bc3e4edcf1"), "Otto", "dog", "Cristian" });
        }
    }
}
