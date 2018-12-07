using Microsoft.EntityFrameworkCore.Migrations;

namespace catchme.bg.Migrations.Catchme
{
    public partial class CreateQuestionsSchemaNoAnswerUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Answers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Answers",
                nullable: true);
        }
    }
}
