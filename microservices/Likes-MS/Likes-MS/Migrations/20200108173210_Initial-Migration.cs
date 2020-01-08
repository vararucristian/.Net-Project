using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Likes_MS.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 36, nullable: false),
                    PersonId = table.Column<Guid>(maxLength: 36, nullable: false),
                    PetId = table.Column<Guid>(maxLength: 36, nullable: false),
                    PersonLike = table.Column<int>(maxLength: 2, nullable: false),
                    PetLike = table.Column<int>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Likes");
        }
    }
}
