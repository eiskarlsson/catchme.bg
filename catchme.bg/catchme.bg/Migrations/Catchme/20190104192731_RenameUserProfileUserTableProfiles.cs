using Microsoft.EntityFrameworkCore.Migrations;

namespace catchme.bg.Migrations.Catchme
{
    public partial class RenameUserProfileUserTableProfiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_CatchmebgUser_UserId",
                table: "Profiles");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Profiles",
                newName: "ProfileUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                newName: "IX_Profiles_ProfileUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_CatchmebgUser_ProfileUserId",
                table: "Profiles",
                column: "ProfileUserId",
                principalTable: "CatchmebgUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_CatchmebgUser_ProfileUserId",
                table: "Profiles");

            migrationBuilder.RenameColumn(
                name: "ProfileUserId",
                table: "Profiles",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_ProfileUserId",
                table: "Profiles",
                newName: "IX_Profiles_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_CatchmebgUser_UserId",
                table: "Profiles",
                column: "UserId",
                principalTable: "CatchmebgUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
