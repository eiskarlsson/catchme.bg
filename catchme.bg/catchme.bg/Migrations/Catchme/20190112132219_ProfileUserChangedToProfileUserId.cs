using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace catchme.bg.Migrations.Catchme
{
    public partial class ProfileUserChangedToProfileUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_CatchmebgUser_ProfileUserId",
                table: "Profiles");

            migrationBuilder.DropTable(
                name: "CatchmebgUser");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_ProfileUserId",
                table: "Profiles");

            migrationBuilder.AlterColumn<string>(
                name: "ProfileUserId",
                table: "Profiles",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProfileUserId",
                table: "Profiles",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "CatchmebgUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    UserPhoto = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatchmebgUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ProfileUserId",
                table: "Profiles",
                column: "ProfileUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_CatchmebgUser_ProfileUserId",
                table: "Profiles",
                column: "ProfileUserId",
                principalTable: "CatchmebgUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
