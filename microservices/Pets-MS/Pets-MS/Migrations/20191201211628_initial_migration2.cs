using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pets_MS.Migrations
{
    public partial class initial_migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 36, nullable: false),
                    Country = table.Column<string>(maxLength: 36, nullable: false),
                    City = table.Column<string>(maxLength: 36, nullable: false),
                    Street = table.Column<string>(maxLength: 36, nullable: false),
                    Number = table.Column<string>(maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 36, nullable: false),
                    Name = table.Column<string>(maxLength: 36, nullable: false),
                    Species = table.Column<string>(maxLength: 36, nullable: false),
                    Genre = table.Column<string>(maxLength: 36, nullable: false),
                    Username = table.Column<string>(maxLength: 36, nullable: false),
                    Description = table.Column<string>(maxLength: 36, nullable: false),
                    LocationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pets_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "City", "Country", "Number", "Street" },
                values: new object[] { new Guid("ec6c733e-0d3e-44eb-91a0-40bc3e4edcf1"), "Iasi", "Romania", "1", "Street" });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "Description", "Genre", "LocationId", "Name", "Species", "Username" },
                values: new object[] { new Guid("cdd30589-12f7-441a-88c5-7dc669fcc1ae"), "my dog is happy", "male", new Guid("ec6c733e-0d3e-44eb-91a0-40bc3e4edcf1"), "Otto", "dog", "Cristian" });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_LocationId",
                table: "Pets",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
