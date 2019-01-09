using Microsoft.EntityFrameworkCore.Migrations;

namespace catchme.bg.Migrations.Catchme
{
    public partial class ProfileValueGeneratedOnAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_CatchmebgUser_ProfileUserId",
                table: "Profiles");

            migrationBuilder.AlterColumn<string>(
                name: "ProfileUserId",
                table: "Profiles",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_CatchmebgUser_ProfileUserId",
                table: "Profiles",
                column: "ProfileUserId",
                principalTable: "CatchmebgUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_CatchmebgUser_ProfileUserId",
                table: "Profiles");

            migrationBuilder.AlterColumn<string>(
                name: "ProfileUserId",
                table: "Profiles",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_CatchmebgUser_ProfileUserId",
                table: "Profiles",
                column: "ProfileUserId",
                principalTable: "CatchmebgUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
