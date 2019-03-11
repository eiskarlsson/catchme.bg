using Microsoft.EntityFrameworkCore.Migrations;

namespace catchme.bg.Migrations
{
    public partial class AddMbtiToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mbti",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mbti",
                table: "AspNetUsers");
        }
    }
}
