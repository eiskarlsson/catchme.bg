using Microsoft.EntityFrameworkCore.Migrations;

namespace catchme.bg.Migrations.Catchme
{
    public partial class CreateQuestionsSchemaAddQuestionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionID",
                table: "Questions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionID",
                table: "Questions");
        }
    }
}
