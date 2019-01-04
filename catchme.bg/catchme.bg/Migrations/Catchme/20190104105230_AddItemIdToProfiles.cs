using Microsoft.EntityFrameworkCore.Migrations;

namespace catchme.bg.Migrations.Catchme
{
    public partial class AddItemIdToProfiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Weight",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Smokes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Religion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Pets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "MaritalStatus",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "LookingFor",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Languages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Height",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "HairColor",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Gender",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "EyeColor",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Ethnicity",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Education",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Drugs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Drinks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Diet",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Children",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "BodyType",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Age",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Weight");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Smokes");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Religion");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "MaritalStatus");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "LookingFor");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Height");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "HairColor");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Gender");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "EyeColor");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Ethnicity");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Drinks");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Diet");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "BodyType");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Age");
        }
    }
}
